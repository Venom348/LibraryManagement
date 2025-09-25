using AutoMapper;
using LibraryManagement.Contracts.Requests.User;
using LibraryManagement.Contracts.Responses;
using LibraryManagement.Contracts.Responses.User;
using Microsoft.EntityFrameworkCore;
using User.Core.Abstractions.Repositories;
using User.Core.Abstractions.Services;
using User.Core.Exceptions;

namespace User.Core.Implementations.Services;

/// <inheritdoc cref="IUserService"/>
public class UserService : IUserService
{
    private readonly IBaseRepository<LibraryManagement.Contracts.Entities.User> _userRepository;
    private readonly IMapper  _mapper;

    public UserService(IBaseRepository<LibraryManagement.Contracts.Entities.User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserDescriptionResponse>> Get(string email)
    {
        // Если поле Email не пустое, то ищет пользователя по полю Email
        if (email != null)
        {
            var result = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Email == email);
            
            // Если Email не найдет, выбрасывает исключение
            if (result is null)
            {
                throw new UserException("Пользователь с таким Email не найден. Повторите попытку или зарегистрируйтесь.");
            }
            
            // Возвращает пользователя в виде списка из одного элемента через маппинг
            return new List<UserDescriptionResponse>([_mapper.Map<UserDescriptionResponse>(result)]);
        }
        
        // Если ничего не нашло, выбрасывает исключение
        throw new UserException("Результат не найден. Попробуйте зарегистрироваться.");
    }

    public async Task<UserDescriptionResponse> Update(PatchUserRequest request)
    {
        // Проверка существования пользователя по ID, если такого нет - выбрасывает исключение
        var result = await _userRepository.GetById(request.Id);

        if (result is null)
        {
            throw new UserException("Пользователь с таким ID не найдет. Повторите попытку.");
        }
        
        // Обновляет поля пользователя
        result.Email = request.Email;
        result.Password = request.Password;
        result.FirstName = request.FirstName;
        result.LastName = request.LastName;
        
        result = await _userRepository.Update(result);
        
        // Возвращает обновлённые данные через маппинг
        return _mapper.Map<UserDescriptionResponse>(result);
    }

    public async Task<UserResponse> Delete(Guid id)
    {
        // Проверка существования пользователя по ID, если такого нет - выбрасывает исключение
        var result = await _userRepository.GetById(id);

        if (result is null)
        {
            throw new UserException("Пользователь с таким ID не найдет. Повторите попытку.");
        }
        
        // Удаляет пользователя
        result = await _userRepository.Delete(result);
        
        // Возвращает информацию об удалённом пользователе через маппинг
        return _mapper.Map<UserResponse>(result);
    }
}