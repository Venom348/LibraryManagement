using Microsoft.EntityFrameworkCore;

namespace Author.Persistence;

/// <summary>
///     Модель для подключения к БД (PostgreSQL)
/// </summary>
public class ApplicationContext :  DbContext
{
    public DbSet<LibraryManagement.Contracts.Entities.Author> Authors => Set<LibraryManagement.Contracts.Entities.Author>();
    
    public ApplicationContext(DbContextOptions options) : base(options)
    {
        // Проверяет, существует ли БД
        // Если нет, то создаёт её
        // Если существует - возвращает false
        if (Database.EnsureCreated())
        {
            Init();
        }
    }

    private void Init()
    {
        SaveChanges();
    }
}