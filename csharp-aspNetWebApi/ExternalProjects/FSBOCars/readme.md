# FSBOCars

FSBOCars is a hybrid ASP.NET MVC application built by following Evan Gudmestad’s YouTube tutorial. The project combines traditional MVC views with an API controller that consumes the external MarketCheck API to fetch car listings dynamically. This design separates concerns: MVC handles the UI and routing, while the API controller integrates external data securely through configuration and User Secrets.

## Getting Started
- Clone the repository
- Run `dotnet restore` to install dependencies
- Configure `MarketCheck:ApiKey` using `dotnet user-secrets`
- Start the app with `dotnet run`
- Access the search endpoint at `/api/cars/search` with query parameters (e.g. `make`, `model`, `year`)

## Configuration
- `appsettings.json` contains non-sensitive values like `BaseUrl`
- Sensitive values such as `ApiKey` are stored in User Secrets and never committed to source control
