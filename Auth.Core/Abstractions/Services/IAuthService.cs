using LibraryManagement.Contracts.Requests.User;

namespace Auth.Core.Abstractions.Services;

/// <summary>
///     Сервис для аутентификации пользователя
/// </summary>
public interface IAuthService
{
    /// <summary>
    ///     Регистрация пользователя
    /// </summary>
    /// <param name="request">Данные для регистрации пользователя</param>
    /// <returns></returns>
    Task Register(PostUserRequest request);
    
    /// <summary>
    ///     Авторизация пользователя
    /// </summary>
    /// <param name="request">Данные для авторизации пользователя</param>
    /// <returns></returns>
    Task<string> Login(PostUserRequest request);
}