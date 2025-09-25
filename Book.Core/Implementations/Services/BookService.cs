using AutoMapper;
using Book.Core.Abstractions.Repositories;
using Book.Core.Abstractions.Services;
using Book.Core.Exceptions;
using LibraryManagement.Contracts.Requests.Book;
using LibraryManagement.Contracts.Responses;
using LibraryManagement.Contracts.Responses.Book;
using Microsoft.EntityFrameworkCore;

namespace Book.Core.Implementations.Services;

/// <inheritdoc cref="IBookService"/>
public class BookService : IBookService
{
    private readonly IBaseRepository<LibraryManagement.Contracts.Entities.Book> _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBaseRepository<LibraryManagement.Contracts.Entities.Book> bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<List<BookDescriptionResponse>> Get(string? name, int page = 0, int limit = 20)
    {
        // Если название книги не пустое, то возвращает одну книгу
        if (name != null)
        {
            var result = await _bookRepository.GetAll().FirstOrDefaultAsync(x => x.Name == name);
            
            // Если по названию книги ничего не найдето, то выбрасывает исключение
            if (result is null)
            {
                throw new BookException("Книга с таким именем не найдена. Повторите попытку.");
            }
            
            // Возвращает книгу в виде списка из одного элемента через маппинг
            return new List<BookDescriptionResponse>([_mapper.Map<BookDescriptionResponse>(result)]);
        }

        // Если название книги не передано, то возвращает список всех книг
        var queryResult = await _bookRepository.GetAll()
            .Skip(page * limit)
            .Take(limit)
            .ToListAsync();
        // Если результат пустой, выбрасывает исключение
        if (queryResult.Count == 0)
        {
            throw new BookException("Результат не найдет. Повторите попытку");
        }
        
        // Возвращает список всех книг через маппинг
        return new List<BookDescriptionResponse>(queryResult.Select(s => _mapper.Map<BookDescriptionResponse>(s)));
    }

    public async Task<BookDescriptionResponse> Create(PostBookRequest request)
    {
        // Создание книги с переданными данными
        var result = await _bookRepository.Create(new LibraryManagement.Contracts.Entities.Book
        {
            Name = request.Name,
            Description = request.Description,
            PublishDate = request.PublishDate,
            Pages = request.Pages,
            Genre = request.Genre,
            Publisher = request.Publisher,
            Instances = request.Instances,
            Authors = request.Authors,
            AddCatalog = request.AddCatalog,
            Status = request.Status
        });
        
        // Возвращает ифнормацию о созданной книге через маппинг
        return _mapper.Map<BookDescriptionResponse>(result);
    }

    public async Task<BookDescriptionResponse> Update(PatchBookRequest request)
    {
        // Проверка существования книги по ID, если такой нет - выбрасывает иселючение
        var result = await _bookRepository.GetById(request.Id);

        if (result is null)
        {
            throw new BookException("Книга с указанным ID не найдена. Повторите попытку.");
        }
        
        // Обновляем данные книги
        result.Name = request.Name;
        result.Description = request.Description;
        result.Pages = request.Pages;
        result.Genre = request.Genre;
        result.Publisher = request.Publisher;
        result.Instances = request.Instances;
        result.Authors = request.Authors;
        result.Status = request.Status;
        
        result = await _bookRepository.Update(result);
        
        // Возвращаем обновлённые данные через маппинг
        return _mapper.Map<BookDescriptionResponse>(result);
    }

    public async Task<BookResponse> Delete(Guid id)
    {
        // Проверка существования книги по ID, если такой нет - выбрасывает иселючение
        var result = await _bookRepository.GetById(id);

        if (result is null)
        {
            throw new BookException("Книга с указанным ID не найдена. Повторите попытку.");
        }
        
        // Удаляет книгу из БД
        result =  await _bookRepository.Delete(result);
        
        // Возвращает информацию об удалённой книги через маппинг
        return _mapper.Map<BookResponse>(result);
    }
}