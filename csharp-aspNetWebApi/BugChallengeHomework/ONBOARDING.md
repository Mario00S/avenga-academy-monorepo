# Codebase Onboarding

LibraryApi — a layered ASP.NET Core Web API homework for books and authors. Local-only; no auth, Docker, or CI.

## Quick Start

1. Clone the monorepo and open `csharp-aspNetWebApi/BugChallengeHomework`
2. Prerequisites: [.NET 10 SDK](https://dotnet.microsoft.com/download), SQL Server LocalDB (Windows / VS)
3. Restore and apply migrations:

```powershell
dotnet restore LibraryApi.slnx
dotnet tool install -g dotnet-ef   # if needed
dotnet ef database update --project LibraryApi.DataAccess --startup-project LibraryApi
```

4. Start the API:

```powershell
dotnet run --project LibraryApi --launch-profile https
```

5. Open Swagger: [https://localhost:7205/swagger](https://localhost:7205/swagger)

Optional: import `Books_collection.json` into Postman (`baseUrl` = `https://localhost:7205`).

**Gotchas**

- Migrations are **not** applied on startup — run `dotnet ef database update` yourself.
- LocalDB (`(localdb)\MSSQLLocalDB`) is Windows-oriented; change `ConnectionStrings:LibraryDb` on other OSes.
- First HTTPS run may need `dotnet dev-certs https --trust`.
- Solution uses `.slnx` (modern VS / recent SDK).

---

## Architecture

**Parent context:** Lives under `avenga-academy-monorepo/csharp-aspNetWebApi/` (course monorepo — no Nx/Turbo). Sibling folders are other homework solutions.

**Stack:** ASP.NET Core Web API · **.NET 10** · EF Core 10 + SQL Server · Swashbuckle · NUnit + Playwright (API tests)

### Solution projects

| Project | Role |
|---------|------|
| **LibraryApi** | Web host: `Program.cs`, DI, controllers, Swagger |
| **LibraryApi.Domain** | Entities (`Book`, `Author`, `BaseEntity`), `Genre` enum |
| **LibraryApi.Dtos** | API contracts |
| **LibraryApi.Mappers** | Domain ↔ DTO mapping |
| **LibraryApi.DataAccess** | DbContext, repositories, Fluent config, migrations |
| **LibraryApi.Services** | Business logic + domain exceptions |
| **LibraryApi.PlaywrightTests** | API tests against a running server |

Dependency flow: **Domain ← Dtos / Mappers / DataAccess ← Services ← LibraryApi**

```
BugChallengeHomework/
├── LibraryApi.slnx
├── Books_collection.json
├── LibraryApi/
├── LibraryApi.Domain/
├── LibraryApi.Dtos/
├── LibraryApi.Mappers/
├── LibraryApi.DataAccess/
├── LibraryApi.Services/
└── LibraryApi.PlaywrightTests/
```

---

## Data Models

| Concern | Choice |
|--------|--------|
| Database | SQL Server LocalDB → `LibraryDb` |
| ORM | EF Core (SqlServer) |
| Connection | `ConnectionStrings:LibraryDb` in `appsettings.json` |

```
Author (1) ──< Book (many)   FK Book.AuthorId → Author.Id, cascade delete
```

### Entities

**BaseEntity:** `Id`, `CreatedDate`, `UpdatedDate`

**Author:** `FirstName`, `LastName` (indexed), `Country`, computed `FullName` (not mapped), `Books`

**Book:** `Title`, `Isbn`, `Year`, `PageCount`, `Genre` (stored as string), `AuthorId`, `Author`

**Genre:** Fiction=1, Fantasy=2, Science=3, History=4, Biography=5

### Seed (via EF `HasData`)

- 4 authors: Orwell, Asimov, Le Guin, Harari
- 9 books (e.g. 1984, Foundation, Sapiens, …)

### Repositories

- `IBookRepository` / `BookRepository` — includes `Author`; `GetByAuthorIdAsync`
- `IAuthorRepository` / `AuthorRepository` — standard CRUD

### DTOs

| DTO | Purpose |
|-----|---------|
| `BookDto` | Response: includes `AuthorFullName` |
| `AddBookDto` | Create: includes `AuthorId` |
| `UpdateBookDto` | Update: includes `Id`, **no** `AuthorId` |

---

## API Reference

REST · single controller · JSON · **no auth**. Swagger only in Development.

| Method | Path | Success | Notes |
|--------|------|---------|--------|
| GET | `/api/books` | 200 `List<BookDto>` | Query: `genre`, `minYear` |
| GET | `/api/books/{id}` | 200 `BookDto` | 404 if missing |
| GET | `/api/books/by-author/{authorId}` | 200 `List<BookDto>` | 404 if author missing |
| POST | `/api/books` | 201 `BookDto` | Body: `AddBookDto` |
| PUT | `/api/books` | 204 | Body: `UpdateBookDto` (id in body) |
| DELETE | `/api/books/{id}` | 204 | |

Errors use Problem Details (400 / 404 / 500).

Local URLs: `http://localhost:5224`, `https://localhost:7205`

---

## Authentication

**None.** No JWT, Identity, cookies, or `[Authorize]`.

`UseAuthorization()` is in the pipeline as a template stub with no auth scheme registered — every endpoint is anonymous, including create/update/delete.

---

## Deployment

**Not deployed.** No Dockerfile, publish profiles, Azure/Terraform, or CI workflows in this folder or the monorepo root. Local development only.

| Config | Purpose |
|--------|---------|
| `appsettings.json` | `ConnectionStrings:LibraryDb`, logging, `AllowedHosts` |
| `launchSettings.json` | Profiles `http` / `https` / IIS Express; opens Swagger |
| `API_BASE_URL` (env) | Optional Playwright override (default `https://localhost:7205`) |

**Run Playwright tests** (API must already be running):

```powershell
$env:API_BASE_URL = "https://localhost:7205"   # optional
dotnet test LibraryApi.PlaywrightTests
```

`DatabaseReset.cs` has `EnsureDeleted` / `Migrate` commented out — enable carefully (stop the API before DROP DATABASE).

---

## Key Files to Know

| File | Why |
|------|-----|
| `LibraryApi.slnx` | Open the solution |
| `LibraryApi/Program.cs` | DI, DbContext, middleware, Swagger |
| `LibraryApi/Controllers/BooksController.cs` | All HTTP endpoints |
| `LibraryApi/appsettings.json` | LocalDB connection string |
| `LibraryApi.Services/Implementations/BookService.cs` | Business rules |
| `LibraryApi.DataAccess/Data/LibraryDbContext.cs` | EF model |
| `LibraryApi.DataAccess/Helpers/EntityConfigurationHelper.cs` | Fluent config + seed |
| `Books_collection.json` / `LibraryApi/LibraryApi.http` | Manual verification |
| `LibraryApi.PlaywrightTests/ApiTestBase.cs` | Test base URL & setup |
