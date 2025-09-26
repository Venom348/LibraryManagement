using Author.Core.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Author.Persistence.Repositories;

/// <inheritdoc cref="IBaseRepository{Author}"/>
public class AuthorRepository : IBaseRepository<LibraryManagement.Contracts.Entities.Author>
{
    private readonly ApplicationContext _dbContext;

    public AuthorRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    // Получение всех записей
    public IQueryable<LibraryManagement.Contracts.Entities.Author> GetAll() => _dbContext.Authors;
    
    // Получение по ID
    public async Task<LibraryManagement.Contracts.Entities.Author> GetById(Guid id) => await _dbContext.Authors.FirstOrDefaultAsync(s => s.Id == id);

    // Создание сущности
    public async Task<LibraryManagement.Contracts.Entities.Author> Create(LibraryManagement.Contracts.Entities.Author author)
    {
        _dbContext.Authors.Add(author);
        await SaveChangesAsync();
        return author;
    }
    
    // Изменение сущности
    public async Task<LibraryManagement.Contracts.Entities.Author> Update(LibraryManagement.Contracts.Entities.Author entity)
    {
        _dbContext.Authors.Update(entity);
        await SaveChangesAsync();
        return entity;
    }
    
    // Удаление сущности
    public async Task<LibraryManagement.Contracts.Entities.Author> Delete(LibraryManagement.Contracts.Entities.Author entity)
    {
        _dbContext.Authors.Remove(entity);
        await SaveChangesAsync();
        return entity;
    }

    // Метод сохранения
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}