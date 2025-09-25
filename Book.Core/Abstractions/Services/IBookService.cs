using LibraryManagement.Contracts.Requests.Book;
using LibraryManagement.Contracts.Responses;
using LibraryManagement.Contracts.Responses.Book;

namespace Book.Core.Abstractions.Services;

/// <summary>
///     Сервис для работы с книгами
/// </summary>
public interface IBookService
{
    /// <summary>
    ///     Получение книги из БД
    /// </summary>
    /// <param name="name">Название книги</param>
    /// <param name="page">Страница для пагинации</param>
    /// <param name="limit">Лимит пагинации</param>
    /// <returns></returns>
    Task<List<BookDescriptionResponse>> Get(string name, int page = 0, int limit = 20);
    
    /// <summary>
    ///     Создание книги
    /// </summary>
    /// <param name="request">Данные о книге</param>
    /// <returns></returns>
    Task<BookDescriptionResponse> Create(PostBookRequest  request);
    
    /// <summary>
    ///     Обновление данных книги
    /// </summary>
    /// <param name="request">Данные об обновлении книги</param>
    /// <returns></returns>
    Task<BookDescriptionResponse> Update(PatchBookRequest  request);
    
    /// <summary>
    ///     Удаление пользователя
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <returns></returns>
    Task<BookResponse> Delete(Guid id);
}