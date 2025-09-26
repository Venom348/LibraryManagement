using Book.Core.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Book.Persistence.Repositories;

/// <inheritdoc cref="IBaseRepository{Book}"/>
public class BookRepository : IBaseRepository<LibraryManagement.Contracts.Entities.Book>
{
    private readonly ApplicationContext _dbContext;

    public BookRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    // Получение всех записей
    public IQueryable<LibraryManagement.Contracts.Entities.Book> GetAll() => _dbContext.Books;
    
    // Получение по ID
    public async Task<LibraryManagement.Contracts.Entities.Book> GetById(Guid id) => await _dbContext.Books.FirstOrDefaultAsync(s => s.Id == id);
    
    // Создание сущности
    public async Task<LibraryManagement.Contracts.Entities.Book> Create(LibraryManagement.Contracts.Entities.Book entity)
    {
        _dbContext.Books.Add(entity);
        await SaveChangesAsync();
        return entity;
    }
    
    // Изменение сущности
    public async Task<LibraryManagement.Contracts.Entities.Book> Update(LibraryManagement.Contracts.Entities.Book entity)
    {
        _dbContext.Books.Update(entity);
        await SaveChangesAsync();
        return entity;
    }
    
    // Удаление сущности
    public async Task<LibraryManagement.Contracts.Entities.Book> Delete(LibraryManagement.Contracts.Entities.Book entity)
    {
        _dbContext.Books.Remove(entity);
        await SaveChangesAsync();
        return entity;
    }

    // Метод сохранения
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}