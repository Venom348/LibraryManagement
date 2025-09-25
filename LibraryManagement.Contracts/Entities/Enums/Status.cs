namespace LibraryManagement.Contracts.Entities.Enums;

/// <summary>
///     Статус книги
/// </summary>
public enum Status
{
    /// <summary>
    ///     Доступна
    /// </summary>
    Available,
    
    /// <summary>
    ///     В использовании
    /// </summary>
    InService,
    
    /// <summary>
    ///     Удалена
    /// </summary>
    Deleted
}