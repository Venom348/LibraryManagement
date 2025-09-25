namespace LibraryManagement.Contracts.Requests.Author;

/// <summary>
///     Можель изменения автора на сервере
/// </summary>
public class PatchAuthorRequest : PostAuthorRequest
{
    /// <summary>
    ///     Идентификатор автора
    /// </summary>
    public Guid Id { get; set; }
}