using Microsoft.EntityFrameworkCore;

namespace User.Persistence;

/// <summary>
///     Модель для подключения к БД (PostgreSQL)
/// </summary>
public class ApplicationContext : DbContext
{
    // Определение сущности
    public DbSet<LibraryManagement.Contracts.Entities.User> Users => Set<LibraryManagement.Contracts.Entities.User>();

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