using AutoMapper;
using LibraryManagement.Contracts.Responses;
using LibraryManagement.Contracts.Responses.Author;

namespace Author.Core.Mapping;

/// <summary>
///     Профиль автомаппера для автора
/// </summary>
public class AuthorProfile :  Profile
{
    public AuthorProfile()
    {
        // Создание маппинга для сущности
        CreateMap<LibraryManagement.Contracts.Entities.Author, AuthorResponse>();
        CreateMap<AuthorResponse, LibraryManagement.Contracts.Entities.Author>();
        CreateMap<LibraryManagement.Contracts.Entities.Author, AuthorDescriptionResponse>();
        CreateMap<AuthorDescriptionResponse, LibraryManagement.Contracts.Entities.Author>();
    }
}