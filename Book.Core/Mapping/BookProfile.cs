using AutoMapper;
using LibraryManagement.Contracts.Responses;
using LibraryManagement.Contracts.Responses.Book;

namespace Book.Core.Mapping;

/// <summary>
///     Профиль автомаппера для книги
/// </summary>
public class BookProfile : Profile
{
    public BookProfile()
    {
        // Создание маппинга для сущности
        CreateMap<LibraryManagement.Contracts.Entities.Book, BookResponse>();
        CreateMap<BookResponse, LibraryManagement.Contracts.Entities.Book>();
        CreateMap<LibraryManagement.Contracts.Entities.Book, BookDescriptionResponse>();
        CreateMap<BookDescriptionResponse, LibraryManagement.Contracts.Entities.Book>();
    }
}