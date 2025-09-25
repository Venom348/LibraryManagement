using Book.Core.Abstractions.Services;
using Book.Core.Exceptions;
using LibraryManagement.Contracts.Requests.Book;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers;

/// <summary>
///     Контроллер книг
/// </summary>
[ApiController]
[Route("api/books")]
public class BooksController : Controller
{
    private readonly IBookService _bookService;
    
    public BooksController(IBookService bookService)
    { 
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string? name, int page = 0, int limit = 20)
    {
        try
        {
            var response = await _bookService.Get(name, page, limit);
            return Ok(response);
        }
        catch (BookException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Неизвестная ошибка");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PostBookRequest request)
    {
        try
        {
            var response = await _bookService.Create(request);
            return Ok(response);
        }
        catch (BookException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception )
        {
            return BadRequest("Неизвестная ошибка");
        }
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] PatchBookRequest request)
    {
        try
        {
            var response = await _bookService.Update(request);
            return Ok(response);
        }
        catch (BookException ex)
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
            var response = await _bookService.Delete(id);
            return Ok(response);
        }
        catch (BookException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Неизвестная ошибка");
        }
    }
}