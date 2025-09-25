using AutoMapper;
using LibraryManagement.Contracts.Responses;
using LibraryManagement.Contracts.Responses.User;

namespace User.Core.Mapping;

/// <summary>
///     Профиль автомаппера для пользователя
/// </summary>
public class UserProfile : Profile
{
    public UserProfile()
    {
        // Создания маппинга для сущности
        CreateMap<LibraryManagement.Contracts.Entities.User, UserResponse>();
        CreateMap<UserResponse, LibraryManagement.Contracts.Entities.User>();
        CreateMap<LibraryManagement.Contracts.Entities.User, UserDescriptionResponse>();
        CreateMap<UserDescriptionResponse, LibraryManagement.Contracts.Entities.User>();
    }
}