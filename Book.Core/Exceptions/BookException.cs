namespace Book.Core.Exceptions;

/// <summary>
///     Класс для вывода сообщения об ошибке у книги
/// </summary>
/// <param name="msg">Сообщение ошибки</param>
public class BookException(string msg = "") : Exception(msg);