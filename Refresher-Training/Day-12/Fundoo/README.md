# Fundoo Notes App

A Google Keep–inspired note-taking backend built with ASP.NET Core Web API, following a layered (multi-project) architecture with JWT-based authentication.

---

## Table of Contents

- [Overview](#overview)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Features Implemented](#features-implemented)
- [API Endpoints](#api-endpoints)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Database Migrations](#database-migrations)
- [Testing the API](#testing-the-api)
- [Roadmap](#roadmap)

---

## Overview

Fundoo Notes App is being built as a multi-day training project, progressively growing from a simple User Management module into a full microservices-based notes application (registration, notes CRUD, pinning/archiving, labels, reminders, and more). This README reflects progress as of the **User Management + JWT Authentication** milestone.

## Tech Stack

| Layer | Technology |
|---|---|
| Runtime | .NET 10 |
| Web Framework | ASP.NET Core Web API |
| ORM | Entity Framework Core 10 |
| Database | SQL Server |
| Authentication | JWT Bearer tokens |
| Password Hashing | BCrypt.Net-Next |
| API Documentation | Swagger / Swashbuckle |

## Architecture

The solution follows a **4-project layered architecture**, with each layer compiled as its own class library and explicit project references enforcing the dependency direction:

```
Fundoo (WebAPI)  →  BusinessLayer  →  RepositoryLayer  →  ModelLayer
```

- **ModelLayer** — Entities and DTOs. No dependencies on any other layer.
- **RepositoryLayer** — EF Core `DbContext` and data access (repositories). Depends only on ModelLayer.
- **BusinessLayer** — Business logic, password hashing, JWT generation, external service calls (e.g., email). Depends on RepositoryLayer and ModelLayer.
- **Fundoo (WebAPI)** — Controllers, middleware pipeline, and dependency injection wiring. Depends on all three layers below it.

This separation means the database technology, business rules, and HTTP layer can each evolve independently — and each layer can be unit tested in isolation by mocking the layer beneath it.

## Project Structure

```
Fundoo/
├── Fundoo.slnx
├── Fundoo/                          # WebAPI host project
│   ├── Controllers/
│   │   └── UserController.cs
│   ├── Program.cs
│   └── appsettings.json
├── ModelLayer/                      # Entities & DTOs
│   ├── Entities/
│   │   └── User.cs
│   └── DTOs/
│       └── UserDTOs.cs
├── RepositoryLayer/                 # Data access
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Interfaces/
│   │   └── IUserRepository.cs
│   ├── Repositories/
│   │   └── UserRepository.cs
│   └── Migrations/
└── BusinessLayer/                   # Business logic
    ├── Interfaces/
    │   └── IUserService.cs
    ├── Services/
    │   ├── UserService.cs
    │   └── EmailService.cs
    └── Helpers/
        ├── PasswordHasher.cs
        └── TokenService.cs
```

## Features Implemented

### User Management
- User registration with duplicate email validation
- Login with credential verification
- Forgot password flow (generates a time-limited reset token)
- Reset password flow (validates token and expiry before allowing reset)
- Passwords are hashed with BCrypt — never stored or logged in plain text

### Authentication & Authorization
- JWT Bearer authentication configured end-to-end (token issuance + validation)
- Tokens are signed with HMAC-SHA256 and include user ID, email, and name as claims
- `[Authorize]`-protected endpoint (`/profile`) to verify token validation is working
- Swagger UI configured with an **Authorize** button for testing protected routes directly

### Infrastructure
- Dependency Injection wired across all four layers (Scoped/Singleton lifetimes applied appropriately)
- CORS enabled (currently permissive — to be scoped down in a later milestone)
- `HttpClient` configured for consuming an external email API (password reset notifications)
- EF Core Code-First migrations against SQL Server

## API Endpoints

| Method | Route | Auth Required | Description |
|---|---|---|---|
| POST | `/api/v1/user/register` | No | Register a new user |
| POST | `/api/v1/user/login` | No | Authenticate and receive a JWT |
| POST | `/api/v1/user/forgot-password` | No | Request a password reset token |
| POST | `/api/v1/user/reset-password` | No | Reset password using a valid token |
| GET | `/api/v1/user/profile` | **Yes** | Returns the authenticated user's claims |

## Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local instance, Express, or LocalDB)

### Setup

```bash
# 1. Restore dependencies across all projects
dotnet restore

# 2. Apply EF Core migrations (creates the database)
dotnet ef database update --project RepositoryLayer --startup-project Fundoo

# 3. Run the API
dotnet run --project Fundoo
```

Swagger UI will be available at `http://localhost:5000/swagger/index.html` when running in the `Development` environment.

> **Note:** If Swagger shows a blank page, ensure `ASPNETCORE_ENVIRONMENT` is set to `Development` — Swagger middleware is intentionally disabled outside of Development.

## Configuration

Connection string and JWT settings live in `Fundoo/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=FundooNotesDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "<a random 32+ character secret>",
    "Issuer": "Fundoo",
    "Audience": "FundooUsers",
    "ExpiryMinutes": 60
  }
}
```

- Update `DefaultConnection` to match your SQL Server instance name.
- Generate a random `Jwt:Key` (minimum 32 characters, required for HMAC-SHA256 signing) rather than using a placeholder value.
- Changing `Jwt:Key` invalidates all previously issued tokens.

## Database Migrations

The `DbContext` lives in `RepositoryLayer`, but configuration (connection string) lives in `Fundoo`, so migration commands must specify both projects and be run from the solution root:

```bash
# Create a new migration after changing an entity
dotnet ef migrations add <MigrationName> --project RepositoryLayer --startup-project Fundoo

# Apply pending migrations to the database
dotnet ef database update --project RepositoryLayer --startup-project Fundoo
```

## Testing the API

1. Run the app and open Swagger.
2. `POST /register` with a name, email, and password.
3. `POST /login` with the same credentials — copy the `token` from the response.
4. Click **Authorize** in Swagger, paste the token (no `Bearer ` prefix needed).
5. Call `GET /profile` — should return your user claims.
6. Log out of Swagger's Authorize dialog and call `/profile` again — should return `401 Unauthorized`, confirming the endpoint is actually protected.

---