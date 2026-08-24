using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HomeworkClass03.Api.DataAccess;
using HomeworkClass03.Api.Models;

namespace HomeworkClass03.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    //[HttpGet]
    //public ActionResult<Book> GetAllBooks()
    //{
    //    return Ok(StaticDb.books);
    //}

    //merging the two methods into one by making the query parameter optional
    //GET /api/books
    //GET /api/books?index=value(int) -- optional
    [HttpGet]
    public ActionResult<Book> BookByIndex([FromQuery] int? index)
    {
        //returns all books if we do not use the parameter
        if (index is null)
        {
            return Ok(StaticDb.books);
        }

        //handling client related invalid index request
        if (index < 0 || index >= StaticDb.books.Count)
        {
            return NotFound(new
            {
                StatusCode = 404,
                Message = $"The book with index {index} was not found"
            });
        }

        try
        {
            Book singleBook = StaticDb.books[index.Value];
            return Ok(singleBook);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "A system error occured, please contact the admin");
        }
    }

    //GET /api/books?author=value&title=value
    [HttpGet("search")]
    public ActionResult<Book> BookAuthorAndTitle([FromQuery] string? author, string? title)
    {
        var result = StaticDb.books;

        if (!string.IsNullOrEmpty(author))
        {
            result = result.Where(a => a.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrEmpty(title))
        {
            result = result.Where(a => a.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!result.Any())
        {
            return NotFound(new
            {
                StatusCode = 404,
                Message = "No books mached your search"
            });
        }

        return Ok(result);
    }

    //Implement a POST endpoint that accepts a Book object from the request body using the [FromBody] attribute and adds it to the list.
    //Post api/books
    [HttpPost]
    public ActionResult<Book> InsertBook([FromBody] Book book)
    {
        try
        {
            if (string.IsNullOrEmpty(book.Author))
            {
                return BadRequest("The author of the book is required");
            }
            if (string.IsNullOrEmpty(book.Title))
            {
                return BadRequest("The title of the book is required");
            }
            StaticDb.books.Add(book);
            return StatusCode(StatusCodes.Status201Created, book);
        }
        catch (Exception ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
