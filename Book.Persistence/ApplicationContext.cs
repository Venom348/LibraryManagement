using Microsoft.EntityFrameworkCore;

namespace Book.Persistence;

/// <summary>
///     Модель для подключения к БД (PostgreSQL)
/// </summary>
public class ApplicationContext : DbContext
{
    public DbSet<LibraryManagement.Contracts.Entities.Book> Books => Set<LibraryManagement.Contracts.Entities.Book>();
    
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