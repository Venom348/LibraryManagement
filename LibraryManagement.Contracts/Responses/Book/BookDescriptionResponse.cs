using LibraryManagement.Contracts.Entities.Enums;

namespace LibraryManagement.Contracts.Responses.Book;

/// <summary>
///     Класс для представления информации о книге
/// </summary>
public class BookDescriptionResponse : BookResponse
{
    /// <summary>
    ///     Название книги
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    ///     Описание книги
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    ///     Дата публикации
    /// </summary>
    public DateOnly PublishDate { get; set; }
    
    /// <summary>
    ///     Количество страниц
    /// </summary>
    public int Pages { get; set; }
    
    /// <summary>
    ///     Жанр книги
    /// </summary>
    public string Genre { get; set; }
    
    /// <summary>
    ///     Издатель
    /// </summary>
    public string Publisher { get; set; }
    
    /// <summary>
    ///     Экземпляры книг
    /// </summary>
    public int Instances { get; set; }
    
    /// <summary>
    ///     Авторы
    /// </summary>
    public List<string> Authors { get; set; }
    
    /// <summary>
    ///     Дата добавления в каталог
    /// </summary>
    public DateOnly AddCatalog { get; set; }
    
    /// <summary>
    ///     Статус книги
    /// </summary>
    public Status Status { get; set; }
}