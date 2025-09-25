using LibraryManagement.Contracts.Requests.Author;
using LibraryManagement.Contracts.Responses;
using LibraryManagement.Contracts.Responses.Author;

namespace Author.Core.Abstractions.Services;

/// <summary>
///     Сервис для работы с авторами книг
/// </summary>
public interface IAuthorService
{
    /// <summary>
    ///     Получение автора из БД
    /// </summary>
    /// <param name="firstname">Имя автора</param>
    /// <param name="lastname">Фамилия автора</param>
    /// <param name="page">Страница для пагинации</param>
    /// <param name="limit">Лимит пагинации</param>
    /// <returns></returns>
    Task<List<AuthorDescriptionResponse>> Get(string firstname, string lastname, int page = 0, int limit = 20);
    
    /// <summary>
    ///     Добавления автора
    /// </summary>
    /// <param name="request">Данные об авторе</param>
    /// <returns></returns>
    Task<AuthorDescriptionResponse> Create(PostAuthorRequest request);
    
    /// <summary>
    ///     Обновление данных автора
    /// </summary>
    /// <param name="request">Данные об обновлении автора</param>
    /// <returns></returns>
    Task<AuthorDescriptionResponse> Update(PatchAuthorRequest request);
    
    /// <summary>
    ///     Удаление автора
    /// </summary>
    /// <param name="id">Идентификатор автора</param>
    /// <returns></returns>
    Task<AuthorResponse> Delete(Guid id);
}