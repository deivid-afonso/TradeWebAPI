# TradeWebAPI

REST API for trade management and risk categorization, built with ASP.NET Core.

## Architecture

```
Controllers/        → HTTP endpoints (CRUD + categorization)
Services/           → Business logic (risk classification by value + sector)
Repository/         → Data access abstraction (ITradeRepository)
Models/             → Domain entities (Trade, TradeCategory enum)
Data/               → EF Core DbContext and configuration
```

**Key decisions:**
- **Repository Pattern** with interface abstraction for testability
- **Dependency Injection** via ASP.NET Core built-in container
- **Entity Framework Core** with SQL Server for persistence
- **Service layer** separates categorization rules from data access

## Risk Categorization Logic

| Value       | Client Sector | Category    |
|-------------|---------------|-------------|
| < 1M        | Public        | LOW RISK    |
| ≥ 1M        | Public        | MEDIUM RISK |
| ≥ 1M        | Private       | HIGH RISK   |

## Endpoints

| Method | Route             | Description           |
|--------|-------------------|-----------------------|
| GET    | /api/trade        | List all trades       |
| GET    | /api/trade/{id}   | Get trade by ID       |
| POST   | /api/trade        | Create a new trade    |
| PUT    | /api/trade/{id}   | Update an existing trade |
| DELETE | /api/trade/{id}   | Delete a trade        |

## Tech Stack

- **C# / ASP.NET Core** — Web API
- **Entity Framework Core** — ORM
- **SQL Server** — Database
- **Swagger** — API documentation (dev environment)

## Running locally

```bash
dotnet restore
dotnet run
# Swagger UI at https://localhost:{port}/swagger
```

Requires SQL Server connection string in `appsettings.json`.
