namespace LibraryManagement.Contracts.Requests.Author;

/// <summary>
///     Модель отправки автора на сервер
/// </summary>
public class PostAuthorRequest
{
    /// <summary>
    ///     Имя автора
    /// </summary>
    public string? FirstName { get; set; }
    
    /// <summary>
    ///     Фамилия автора
    /// </summary>
    public string? LastName { get; set; }
    
    /// <summary>
    ///     Биография
    /// </summary>
    public string Biography  { get; set; }
    
    /// <summary>
    ///     Дата рождения
    /// </summary>
    public DateOnly BirthDate { get; set; }
    
    /// <summary>
    ///     Дата смерти
    /// </summary>
    public DateOnly DeathDate { get; set; }
    
    /// <summary>
    ///     Страна
    /// </summary>
    public string Country { get; set; }
    
    /// <summary>
    ///     Список книг
    /// </summary>
    public List<string> Books { get; set; }
}