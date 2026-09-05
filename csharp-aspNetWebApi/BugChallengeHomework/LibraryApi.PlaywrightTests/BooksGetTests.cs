using LibraryApi.Domain.Enums;
using LibraryApi.Dtos;

namespace LibraryApi.PlaywrightTests;

[TestFixture]
public class BooksGetTests : ApiTestBase
{
    [Test]
    public async Task GetAllBooks()
    {
        var response = await Api.GetAsync("/api/books");

        Assert.That(response.Status, Is.EqualTo(200));
        Assert.That(response.Headers["content-type"], Does.Contain("application/json"));

        var books = await ReadJsonAsync<List<BookDto>>(response);
        Assert.That(books, Has.Count.GreaterThanOrEqualTo(9));

        foreach (var book in books)
        {
            Assert.That(book.Id, Is.GreaterThan(0));
            Assert.That(book.Title, Is.Not.Empty);
            Assert.That(book.AuthorFullName, Is.Not.EqualTo("Unknown"));
        }

        var nineteenEightyFour = books.Single(book => book.Id == 1);
        Assert.That(nineteenEightyFour.Title, Is.EqualTo("1984"));
        Assert.That(nineteenEightyFour.AuthorFullName, Is.EqualTo("George Orwell"));
        Assert.That(nineteenEightyFour.Genre, Is.EqualTo(Genre.Fiction));
    }

    [Test]
    public async Task GetAllBooks_FilterByGenre()
    {
        var response = await Api.GetAsync("/api/books?genre=Fantasy");

        Assert.That(response.Status, Is.EqualTo(200));
        var books = await ReadJsonAsync<List<BookDto>>(response);
        Assert.That(books, Is.Not.Empty);
        Assert.That(books.Select(book => book.Genre), Is.All.EqualTo(Genre.Fantasy));

        var titles = books.Select(book => book.Title).ToList();
        Assert.That(titles, Does.Contain("A Wizard of Earthsea"));
        Assert.That(titles, Does.Contain("The Left Hand of Darkness"));
    }

    [Test]
    public async Task GetAllBooks_FilterByMinYear_Exclusive()
    {
        var response = await Api.GetAsync("/api/books?minYear=1950");

        Assert.That(response.Status, Is.EqualTo(200));
        var books = await ReadJsonAsync<List<BookDto>>(response);
        Assert.That(books, Is.Not.Empty);
        Assert.That(books.Select(book => book.Year), Is.All.GreaterThanOrEqualTo(1950));

        var titles = books.Select(book => book.Title).ToList();
        Assert.That(titles, Does.Not.Contain("1984"));
        Assert.That(titles, Does.Contain("Foundation"));
    }

    [Test]
    public async Task GetAllBooks_Filtered()
    {
        var response = await Api.GetAsync("/api/books?genre=Fantasy&minYear=1950");

        Assert.That(response.Status, Is.EqualTo(200));
        var books = await ReadJsonAsync<List<BookDto>>(response);
        Assert.That(books, Is.Not.Empty);

        foreach (var book in books)
        {
            Assert.That(book.Genre, Is.EqualTo(Genre.Fantasy));
            Assert.That(book.Year, Is.GreaterThan(1950));
        }
    }

    [Test]
    public async Task GetAllBooks_InvalidGenreQuery()
    {
        var response = await Api.GetAsync("/api/books?genre=NotAGenre");

        Assert.That(response.Status, Is.EqualTo(400));
        var body = await response.TextAsync();
        Assert.That(body.ToLowerInvariant(), Does.Contain("genre"));
    }

    [Test]
    public async Task GetBookById_Valid()
    {
        var response = await Api.GetAsync("/api/books/1");

        Assert.That(response.Status, Is.EqualTo(200));
        var book = await ReadJsonAsync<BookDto>(response);
        Assert.That(book.Id, Is.EqualTo(1));
        Assert.That(book.Title, Is.EqualTo("1984"));
        Assert.That(book.Isbn, Is.EqualTo("9780451524935"));
        Assert.That(book.Year, Is.EqualTo(1949));
        Assert.That(book.PageCount, Is.EqualTo(328));
        Assert.That(book.Genre, Is.EqualTo(Genre.Fiction));
        Assert.That(book.AuthorFullName, Is.EqualTo("George Orwell"));
    }

    [Test]
    public async Task GetBookById_NotFound()
    {
        var response = await Api.GetAsync("/api/books/9999");

        Assert.That(response.Status, Is.EqualTo(404));
        var body = await ReadJsonAsync<ProblemDetailsDto>(response);
        Assert.That(body.Status, Is.EqualTo(404));
        Assert.That(body.Title, Is.EqualTo("Book not found"));
        Assert.That(body.Detail, Does.Contain("9999"));
    }

    [Test]
    public async Task GetBookById_Zero()
    {
        var response = await Api.GetAsync("/api/books/0");

        Assert.That(response.Status, Is.EqualTo(404));
        var body = await ReadJsonAsync<ProblemDetailsDto>(response);
        Assert.That(body.Status, Is.EqualTo(404));
        Assert.That(body.Title, Is.EqualTo("Book not found"));
        Assert.That(body.Detail, Does.Contain("0"));
    }

    [Test]
    public async Task GetBooksByAuthor_Valid()
    {
        var response = await Api.GetAsync("/api/books/by-author/1");

        Assert.That(response.Status, Is.EqualTo(200));
        var books = await ReadJsonAsync<List<BookDto>>(response);
        Assert.That(books, Has.Count.GreaterThanOrEqualTo(3));
        Assert.That(books.Select(book => book.Title), Does.Contain("1984").And.Contain("Animal Farm").And.Contain("Homage to Catalonia"));
        Assert.That(books.Select(book => book.AuthorFullName), Is.All.EqualTo("George Orwell"));
    }

    [Test]
    public async Task GetBooksByAuthor_NotFound()
    {
        var response = await Api.GetAsync("/api/books/by-author/9999");

        Assert.That(response.Status, Is.EqualTo(404));
        var body = await ReadJsonAsync<ProblemDetailsDto>(response);
        Assert.That(body.Status, Is.EqualTo(404));
        Assert.That(body.Title, Is.EqualTo("Author not found"));
        Assert.That(body.Detail, Does.Contain("9999"));
    }
}
