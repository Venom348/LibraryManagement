namespace Author.Core.Exceptions;

/// <summary>
///     Класс для вывода сообщения об ошибке у автора
/// </summary>
/// <param name="msg">Сообщение ошибки</param>
public class AuthorException(string msg = "") : Exception(msg);