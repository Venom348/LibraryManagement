using Author.Core.Abstractions.Repositories;
using Author.Core.Abstractions.Services;
using Author.Core.Implementations.Services;
using Author.Core.Mapping;
using Author.Persistence;
using Author.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration; // Получение доступа к конфигурации

builder.Services.AddControllers(); // Регистрирует сервисы для работы с контроллерами
builder.Services.AddSwaggerGen(); // Генерация документации Swagger

builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Psql")));
builder.Services.AddTransient<IBaseRepository<LibraryManagement.Contracts.Entities.Author>, AuthorRepository>();

// Добавление профиля для автомаппера
builder.Services.AddAutoMapper(opt => opt.AddProfile<AuthorProfile>());

var app = builder.Build();

app.MapControllers(); // Машрутизация контроллеров
app.UseSwagger(); // Включает middleware для генерации Swagger JSON
app.UseSwaggerUI(); // Включает веб-интерфейс для документации API
app.UseHttpsRedirection(); // Перенаправляет HTTP запросы на HTTPS

app.Run();