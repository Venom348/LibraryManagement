using Book.Core.Abstractions.Repositories;
using Book.Core.Abstractions.Services;
using Book.Core.Implementations.Services;
using Book.Core.Mapping;
using Book.Persistence;
using Book.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration; // Получение доступа к конфигурации

builder.Services.AddControllers(); // Регистрирует сервисы для работы с контроллерами
builder.Services.AddSwaggerGen(); // Генерация документации Swagger

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Psql")));
builder.Services.AddTransient<IBaseRepository<LibraryManagement.Contracts.Entities.Book>, BookRepository>();

// Добавление профиля для автомаппера
builder.Services.AddAutoMapper(opt => opt.AddProfile<BookProfile>());

var app = builder.Build();

app.MapControllers(); // Машрутизация контроллеров
app.UseSwagger(); // Включает middleware для генерации Swagger JSON
app.UseSwaggerUI(); // Включает веб-интерфейс для документации API
app.UseHttpsRedirection(); // Перенаправляет HTTP запросы на HTTPS

app.Run();