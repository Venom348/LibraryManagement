using Microsoft.AspNetCore.Mvc;
using Auth.Core.Abstractions.Services;
using LibraryManagement.Contracts.Requests.User;

namespace Auth.API.Controllers;

/// <summary>
///     Контроллер аутентификации
/// </summary>
[ApiController]
[Route("api/authentication")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] PostUserRequest request)
    {
        try
        {
            await _authService.Register(request);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest("Неизвестная ошибка");
        }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] PostUserRequest request)
    {
        try
        {
            await _authService.Login(request);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest("Неизвестная ошибка");
        }
    }
}