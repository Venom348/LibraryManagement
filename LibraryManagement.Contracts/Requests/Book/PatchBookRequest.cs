namespace LibraryManagement.Contracts.Requests.Book;

/// <summary>
///     Модель изменения книги на сервере
/// </summary>
public class PatchBookRequest : PostBookRequest
{
    /// <summary>
    ///     Идентификатор книги
    /// </summary>
    public Guid Id { get; set; }
}