using Author.Core.Abstractions.Repositories;
using Author.Core.Abstractions.Services;
using Author.Core.Exceptions;
using AutoMapper;
using LibraryManagement.Contracts.Requests.Author;
using LibraryManagement.Contracts.Responses;
using LibraryManagement.Contracts.Responses.Author;
using Microsoft.EntityFrameworkCore;

namespace Author.Core.Implementations.Services;

/// <inheritdoc cref="IAuthorService"/>
public class AuthorService : IAuthorService
{
    private readonly IBaseRepository<LibraryManagement.Contracts.Entities.Author> _authorRepository;
    private readonly IMapper _mapper;

    public AuthorService(IBaseRepository<LibraryManagement.Contracts.Entities.Author> authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<List<AuthorDescriptionResponse>> Get(string? firstname, string? lastname, int page = 0, int limit = 20)
    {
        // Если имя и/или фамилия не пустые, то возвращает одного автора
        if (firstname != null || lastname != null)
        {
            var result = await _authorRepository.GetAll().FirstOrDefaultAsync(x => x.FirstName == firstname || x.LastName == lastname);
            
            // Если по имени и/или фамилии ничего не найдено, то выбрасывает исключение
            if (result is null)
            {
                throw new AuthorException("Автор с таким именем и/или фамилией не найдет. Повторите попытку");
            }
            
            // Возвращает автора в виде списка их одного элемента через маппинг
            return new List<AuthorDescriptionResponse>([_mapper.Map<AuthorDescriptionResponse>(result)]);
        }
        
        // Если имя и/или фамилия не переданы, то возвращает список всех авторов
        var queryResult = await _authorRepository.GetAll()
            .Skip(page * limit)
            .Take(limit)
            .ToListAsync();
        // Если результат пустой, выбрасывает исключение
        if (queryResult.Count == 0)
        {
            throw new AuthorException("Результат не найдет. Повторите попытку");
        }
        
        // Возвращает список всех авторов через маппинг
        return new List<AuthorDescriptionResponse>(queryResult.Select(s => _mapper.Map<AuthorDescriptionResponse>(s)));
    }

    public async Task<AuthorDescriptionResponse> Create(PostAuthorRequest request)
    {
        // Добавления автора с переданными данными
        var result = await _authorRepository.Create(new LibraryManagement.Contracts.Entities.Author
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Biography = request.Biography,
            BirthDate = request.BirthDate,
            DeathDate = request.DeathDate,
            Country = request.Country,
            Books = request.Books,
        });
        
        // Возвращает ифнормацию о добавленном авторе через маппинг
        return _mapper.Map<AuthorDescriptionResponse>(result);
    }

    public async Task<AuthorDescriptionResponse> Update(PatchAuthorRequest request)
    {
        // Проверка существования автора по ID, если такого нет - выбрасывает иселючение
        var result = await _authorRepository.GetById(request.Id);

        if (result is null)
        {
            throw new AuthorException("Автор с указанным ID не найден. Повторите попытку");
        }
        
        // Обновляем данные автора
        result.FirstName = request.FirstName;
        result.LastName = request.LastName;
        result.Biography = request.Biography;
        result.BirthDate = request.BirthDate;
        result.DeathDate = request.DeathDate;
        result.Country = request.Country;
        result.Books = request.Books;
        
        result = await _authorRepository.Update(result);
        
        // Возвращаем обновлённые данные через маппинг
        return _mapper.Map<AuthorDescriptionResponse>(result);
    }

    public async Task<AuthorResponse> Delete(Guid id)
    {
        // Проверка существования автора по ID, если такого нет - выбрасывает иселючение
        var result = await _authorRepository.GetById(id);

        if (result is null)
        {
            throw new AuthorException("Автор с указанным ID не найден. Повторите попытку");
        }
        
        //  Удаляем автора из БД
        result = await _authorRepository.Delete(result);
        
        // Возвращает информацию об удалённом авторе через маппинг
        return _mapper.Map<AuthorResponse>(result);
    }
}