using Author.Core.Abstractions.Services;
using Author.Core.Exceptions;
using LibraryManagement.Contracts.Requests.Author;
using Microsoft.AspNetCore.Mvc;

namespace Author.API.Controllers;

/// <summary>
///     Контроллер авторов
/// </summary>
[ApiController]
[Route("api/authors")]
public class AuthorController : Controller
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string? firstname, string? lastname, int page = 0, int limit = 20)
    {
        try
        {
            var response = await _authorService.Get(firstname, lastname, page, limit);
            return Ok(response);
        }
        catch (AuthorException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Неизвестная ошибка");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PostAuthorRequest request)
    {
        try
        {
            var response = await _authorService.Create(request);
            return Ok(response);
        }
        catch (AuthorException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Неизвестная ошибка");
        }
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] PatchAuthorRequest request)
    {
        try
        {
            var response = await _authorService.Update(request);
            return Ok(response);
        }
        catch (AuthorException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Неизвестная ошибка");
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var response = await _authorService.Delete(id);
            return Ok(response);
        }
        catch (AuthorException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Неизвестная ошибка");
        }
    }
}