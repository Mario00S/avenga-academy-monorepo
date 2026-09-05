using System.Text.Json;
using LibraryApi.Domain.Enums;
using LibraryApi.Dtos;
using Microsoft.Playwright;

namespace LibraryApi.PlaywrightTests;

[TestFixture]
[NonParallelizable]
public class BooksWriteTests : ApiTestBase
{
    private static int createdBookId;

    private static readonly string TooLongTitle = new('A', 201);
    private static readonly string TooLongIsbn = new('1', 21);

    [Test, Order(1)]
    public async Task CreateBook_Valid()
    {
        var response = await Api.PostAsync("/api/books", JsonBody(new
        {
            title = "The Hobbit",
            isbn = "978-0547928227",
            year = 1937,
            pageCount = 310,
            genre = Genre.Fantasy,
            authorId = 1
        }));

        Assert.That(response.Status, Is.EqualTo(201));
        var book = await ReadJsonAsync<BookDto>(response);
        Assert.That(book.Id, Is.GreaterThan(0));
        Assert.That(book.Title, Is.EqualTo("The Hobbit"));
        Assert.That(book.Isbn, Is.EqualTo("978-0547928227"));
        Assert.That(book.Year, Is.EqualTo(1937));
        Assert.That(book.PageCount, Is.EqualTo(310));
        Assert.That(book.Genre, Is.EqualTo(Genre.Fantasy));
        Assert.That(book.AuthorFullName, Is.EqualTo("George Orwell"));
        createdBookId = book.Id;

        response.Headers.TryGetValue("location", out var location);
        Assert.That(location?.ToLowerInvariant(), Does.Contain($"/api/books/{createdBookId}"));
    }

    [Test, Order(2)]
    public async Task CreateBook_MissingTitle()
    {
        var response = await Api.PostAsync("/api/books", JsonBody(new
        {
            title = "",
            isbn = "978-0547928227",
            year = 1937,
            pageCount = 310,
            genre = Genre.Fantasy,
            authorId = 1
        }));

        await AssertRequiredField(response, "Title", "Title is a required field.");
    }

    [Test, Order(3)]
    public async Task CreateBook_WhitespaceTitle()
    {
        var response = await Api.PostAsync("/api/books", JsonBody(new
        {
            title = "   ",
            isbn = "9780547928227",
            year = 1937,
            pageCount = 310,
            genre = Genre.Fantasy,
            authorId = 1
        }));

        await AssertRequiredField(response, "Title", "Title is a required field.");
    }

    [Test, Order(4)]
    public async Task CreateBook_TitleTooLong()
    {
        var response = await Api.PostAsync("/api/books", JsonBody(new
        {
            title = TooLongTitle,
            isbn = "9780547928228",
            year = 1937,
            pageCount = 310,
            genre = Genre.Fantasy,
            authorId = 1
        }));

        await AssertBookDataException(response, "Title cannot contain more than 200 characters.");
    }

    [Test, Order(5)]
    public async Task CreateBook_MissingIsbn()
    {
        var response = await Api.PostAsync("/api/books", JsonBody(new
        {
            title = "No Isbn Book",
            isbn = "",
            year = 2000,
            pageCount = 100,
            genre = Genre.Fantasy,
            authorId = 1
        }));

        await AssertRequiredField(response, "Isbn", "Isbn is a required field.");
    }

    [Test, Order(6)]
    public async Task CreateBook_IsbnTooLong()
    {
        var response = await Api.PostAsync("/api/books", JsonBody(new
        {
            title = "Long Isbn Book",
            isbn = TooLongIsbn,
            year = 2000,
            pageCount = 100,
            genre = Genre.Fantasy,
            authorId = 1
        }));

        await AssertBookDataException(response, "Isbn cannot contain more than 20 characters.");
    }

    [Test, Order(7)]
    public async Task CreateBook_InvalidYear()
    {
        var response = await Api.PostAsync("/api/books", JsonBody(new
        {
            title = "Future Book",
            isbn = "1234567890",
            year = 3000,
            pageCount = 100,
            genre = Genre.Fantasy,
            authorId = 1
        }));

        await AssertBookDataException(response, "Year '3000' is not a valid publication year.");
    }

    [Test, Order(8)]
    public async Task CreateBook_YearTooOld()
    {
        var response = await Api.PostAsync("/api/books", JsonBody(new
        {
            title = "Ancient Book",
            isbn = "1234567891",
            year = 1449,
            pageCount = 100,
            genre = Genre.History,
            authorId = 1
        }));

        await AssertBookDataException(response, "Year '1449' is not a valid publication year.");
    }

    [Test, Order(9)]
    public async Task CreateBook_PageCountZero()
    {
        var response = await Api.PostAsync("/api/books", JsonBody(new
        {
            title = "Empty Book",
            isbn = "1234567892",
            year = 2000,
            pageCount = 0,
            genre = Genre.Fantasy,
            authorId = 1
        }));

        await AssertBookDataException(response, "PageCount must be greater than zero.");
    }

    [Test, Order(10)]
    public async Task CreateBook_InvalidGenre()
    {
        var response = await Api.PostAsync("/api/books", JsonBody(new
        {
            title = "Weird Genre",
            isbn = "1234567890",
            year = 2000,
            pageCount = 200,
            genre = 42,
            authorId = 1
        }));

        await AssertInvalidGenre(response);
    }

    [Test, Order(11)]
    public async Task CreateBook_UnknownAuthor()
    {
        var response = await Api.PostAsync("/api/books", JsonBody(new
        {
            title = "Orphan Book",
            isbn = "1234567893",
            year = 2000,
            pageCount = 120,
            genre = Genre.Fantasy,
            authorId = 9999
        }));

        Assert.That(response.Status, Is.EqualTo(400));
        var raw = await response.TextAsync();
        var body = JsonSerializer.Deserialize<ProblemDetailsDto>(raw, JsonOptions);
        Assert.That(body, Is.Not.Null);
        Assert.That(body!.Status, Is.EqualTo(400));

        if (body.Title == "Invalid author")
        {
            Assert.That(body.Detail, Is.EqualTo("Author with id 9999 does not exist."));
            return;
        }

        Assert.That(body.Title, Is.EqualTo("One or more validation errors occurred."));
    }

    [Test, Order(12)]
    public async Task UpdateBook_Valid()
    {
        await EnsureCreatedBookAsync();

        var response = await Api.PutAsync("/api/books", JsonBody(new
        {
            id = createdBookId,
            title = "The Hobbit (Updated)",
            isbn = "978-0547928227",
            year = 1937,
            pageCount = 320,
            genre = Genre.Fantasy
        }));

        Assert.That(response.Status, Is.EqualTo(204));
        Assert.That(await response.TextAsync(), Is.Empty);
    }

    [Test, Order(13)]
    public async Task GetBookAfterUpdate()
    {
        await EnsureCreatedBookAsync();

        var response = await Api.GetAsync($"/api/books/{createdBookId}");

        Assert.That(response.Status, Is.EqualTo(200));
        var book = await ReadJsonAsync<BookDto>(response);
        Assert.That(book.Id, Is.EqualTo(createdBookId));
        Assert.That(book.Title, Is.EqualTo("The Hobbit (Updated)"));
        Assert.That(book.PageCount, Is.EqualTo(320));
        Assert.That(book.Genre, Is.EqualTo(Genre.Fantasy));
    }

    [Test, Order(14)]
    public async Task UpdateBook_NotFound()
    {
        var response = await Api.PutAsync("/api/books", JsonBody(new
        {
            id = 9999,
            title = "Nonexistent",
            isbn = "1234567890",
            year = 2000,
            pageCount = 100,
            genre = Genre.Fantasy
        }));

        Assert.That(response.Status, Is.EqualTo(404));
        var body = await ReadJsonAsync<ProblemDetailsDto>(response);
        Assert.That(body.Status, Is.EqualTo(404));
        Assert.That(body.Title, Is.EqualTo("Book not found"));
        Assert.That(body.Detail, Does.Contain("9999"));
    }

    [Test, Order(15)]
    public async Task UpdateBook_MissingTitle()
    {
        await EnsureCreatedBookAsync();

        var response = await Api.PutAsync("/api/books", JsonBody(new
        {
            id = createdBookId,
            title = "",
            isbn = "978-0547928227",
            year = 1937,
            pageCount = 320,
            genre = Genre.Fantasy
        }));

        await AssertRequiredField(response, "Title", "Title is a required field.");
    }

    [Test, Order(16)]
    public async Task UpdateBook_InvalidYear()
    {
        await EnsureCreatedBookAsync();

        var response = await Api.PutAsync("/api/books", JsonBody(new
        {
            id = createdBookId,
            title = "The Hobbit (Updated)",
            isbn = "978-0547928227",
            year = 3000,
            pageCount = 320,
            genre = Genre.Fantasy
        }));

        await AssertBookDataException(response, "Year '3000' is not a valid publication year.");
    }

    [Test, Order(17)]
    public async Task UpdateBook_InvalidPageCount()
    {
        await EnsureCreatedBookAsync();

        var response = await Api.PutAsync("/api/books", JsonBody(new
        {
            id = createdBookId,
            title = "The Hobbit (Updated)",
            isbn = "978-0547928227",
            year = 1937,
            pageCount = -5,
            genre = Genre.Fantasy
        }));

        await AssertBookDataException(response, "PageCount must be greater than zero.");
    }

    [Test, Order(18)]
    public async Task UpdateBook_InvalidGenre()
    {
        await EnsureCreatedBookAsync();

        var response = await Api.PutAsync("/api/books", JsonBody(new
        {
            id = createdBookId,
            title = "The Hobbit (Updated)",
            isbn = "978-0547928227",
            year = 1937,
            pageCount = 320,
            genre = 42
        }));

        await AssertInvalidGenre(response);
    }

    [Test, Order(19)]
    public async Task DeleteBook_Valid()
    {
        await EnsureCreatedBookAsync();

        var response = await Api.DeleteAsync($"/api/books/{createdBookId}");

        Assert.That(response.Status, Is.EqualTo(204));
        Assert.That(await response.TextAsync(), Is.Empty);
    }

    [Test, Order(20)]
    public async Task GetBookAfterDelete()
    {
        await EnsureCreatedBookAsync();
        await Api.DeleteAsync($"/api/books/{createdBookId}");

        var response = await Api.GetAsync($"/api/books/{createdBookId}");

        Assert.That(response.Status, Is.EqualTo(404));
        var body = await ReadJsonAsync<ProblemDetailsDto>(response);
        Assert.That(body.Title, Is.EqualTo("Book not found"));
    }

    [Test, Order(21)]
    public async Task DeleteBook_NotFound()
    {
        var response = await Api.DeleteAsync("/api/books/9999");

        Assert.That(response.Status, Is.EqualTo(404));
        var body = await ReadJsonAsync<ProblemDetailsDto>(response);
        Assert.That(body.Status, Is.EqualTo(404));
        Assert.That(body.Title, Is.EqualTo("Book not found"));
        Assert.That(body.Detail, Does.Contain("9999"));
    }

    private async Task EnsureCreatedBookAsync()
    {
        if (createdBookId > 0)
        {
            var existing = await Api.GetAsync($"/api/books/{createdBookId}");
            if (existing.Status == 200)
            {
                return;
            }
        }

        var response = await Api.PostAsync("/api/books", JsonBody(new
        {
            title = "The Hobbit",
            isbn = "978-0547928227",
            year = 1937,
            pageCount = 310,
            genre = Genre.Fantasy,
            authorId = 1
        }));

        Assert.That(response.Status, Is.EqualTo(201), await response.TextAsync());
        var book = await ReadJsonAsync<BookDto>(response);
        createdBookId = book.Id;
        Assert.That(createdBookId, Is.GreaterThan(0));
    }

    /// <summary>
    /// Serialize with System.Text.Json defaults (enums as numbers).
    /// Playwright DataObject can emit "Fantasy" as a string; the API JSON binder only accepts 1-5.
    /// </summary>
    private static APIRequestContextOptions JsonBody(object data) => new()
    {
        Data = JsonSerializer.Serialize(data),
        Headers = new Dictionary<string, string>
        {
            ["Content-Type"] = "application/json"
        }
    };

    private async Task AssertRequiredField(IAPIResponse response, string fieldName, string bookServiceMessage)
    {
        Assert.That(response.Status, Is.EqualTo(400));
        var raw = await response.TextAsync();
        var body = JsonSerializer.Deserialize<ProblemDetailsDto>(raw, JsonOptions);
        Assert.That(body, Is.Not.Null);

        if (body!.Title == "Invalid book data")
        {
            Assert.That(body.Detail, Is.EqualTo(bookServiceMessage));
            return;
        }

        Assert.That(body.Title, Is.EqualTo("One or more validation errors occurred."));
        Assert.That(raw, Does.Contain(fieldName).IgnoreCase);
    }

    private async Task AssertBookDataException(IAPIResponse response, string expectedDetail)
    {
        Assert.That(response.Status, Is.EqualTo(400));
        var raw = await response.TextAsync();
        var body = JsonSerializer.Deserialize<ProblemDetailsDto>(raw, JsonOptions);
        Assert.That(body, Is.Not.Null);

        if (body!.Title == "Invalid book data")
        {
            Assert.That(body.Detail, Is.EqualTo(expectedDetail));
            return;
        }

        Assert.That(body.Title, Is.EqualTo("One or more validation errors occurred."));
    }

    private async Task AssertInvalidGenre(IAPIResponse response)
    {
        Assert.That(response.Status, Is.EqualTo(400));
        var raw = await response.TextAsync();
        var body = JsonSerializer.Deserialize<ProblemDetailsDto>(raw, JsonOptions);
        Assert.That(body, Is.Not.Null);

        if (body!.Title == "Invalid book data")
        {
            Assert.That(body.Detail, Is.EqualTo("Genre '42' is not a valid value."));
            return;
        }

        Assert.That(body.Title, Is.EqualTo("One or more validation errors occurred."));
        Assert.That(raw.ToLowerInvariant(), Does.Contain("genre"));
    }
}
