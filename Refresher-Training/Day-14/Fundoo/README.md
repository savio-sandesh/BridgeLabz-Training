# Fundoo Notes App

A Google Keep–inspired note-taking backend built with ASP.NET Core Web API, following a layered (multi-project) architecture with JWT-based authentication.

---

## Table of Contents

- [Overview](#overview)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Features Implemented](#features-implemented)
- [Input Validation & Security Rules](#input-validation--security-rules)
- [API Endpoints](#api-endpoints)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Database Migrations](#database-migrations)
- [Testing the API](#testing-the-api)

---

## Overview

Fundoo Notes App is being built as a multi-day training project, progressively growing from a simple User Management module into a full microservices-based notes application (registration, notes CRUD, pinning/archiving, labels, reminders, and more). This README reflects progress as of the **User Management + Notes Core CRUD & Cloudinary Image Upload** milestone.

## Tech Stack

| Layer | Technology |
|---|---|
| Runtime | .NET 10 |
| Web Framework | ASP.NET Core Web API |
| ORM | Entity Framework Core 10 |
| Database | SQL Server |
| Authentication | JWT Bearer tokens |
| Password Hashing | BCrypt.Net-Next |
| Cloud Storage | Cloudinary (Image & Media uploads) |
| Email Service | SMTP / MailKit |
| API Documentation | Swagger / Swashbuckle |

## Architecture

The solution follows a **4-project layered architecture**, with each layer compiled as its own class library and explicit project references enforcing the dependency direction:

```
Fundoo (WebAPI)  →  BusinessLayer  →  RepositoryLayer  →  ModelLayer
```

- **ModelLayer** — Entities and DTOs. No dependencies on any other layer.
- **RepositoryLayer** — EF Core `DbContext` and data access (repositories). Depends only on ModelLayer.
- **BusinessLayer** — Business logic, password hashing, JWT generation, Cloudinary media processing, and external service calls (e.g., SMTP email). Depends on RepositoryLayer and ModelLayer.
- **Fundoo (WebAPI)** — Controllers, middleware pipeline, and dependency injection wiring. Depends on all three layers below it.

This separation means the database technology, business rules, and HTTP layer can each evolve independently — and each layer can be unit tested in isolation by mocking the layer beneath it.

## Project Structure

```
Fundoo/
├── Fundoo.slnx
├── README.md
├── Fundoo/                          # WebAPI host project
│   ├── Fundoo.csproj
│   ├── Controllers/
│   │   ├── NotesController.cs
│   │   └── UserController.cs
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── Program.cs
│   └── appsettings.json
├── ModelLayer/                      # Entities & DTOs
│   ├── ModelLayer.csproj
│   ├── DTOs/
│   │   ├── NoteDTOs.cs
│   │   └── UserDTOs.cs
│   └── Entities/
│       ├── Note.cs
│       └── User.cs
├── RepositoryLayer/                 # Data access
│   ├── RepositoryLayer.csproj
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Interfaces/
│   │   ├── INoteRepository.cs
│   │   └── IUserRepository.cs
│   ├── Migrations/
│   │   ├── 20260816172110_InitialCreate.cs
│   │   ├── 20260819163000_RenameArchieveToArchive.cs
│   │   └── AppDbContextModelSnapshot.cs
│   └── Repositories/
│       ├── NoteRepository.cs
│       └── UserRepository.cs
└── BusinessLayer/                   # Business logic
    ├── BusinessLayer.csproj
    ├── Helpers/
    │   ├── PasswordHasher.cs
    │   └── TokenService.cs
    ├── Interfaces/
    │   ├── IEmailService.cs
    │   ├── INoteService.cs
    │   └── IUserService.cs
    └── Services/
        ├── EmailService.cs
        ├── NoteService.cs
        └── UserService.cs
```

## Features Implemented

### User Management
- User registration with duplicate email validation
- Login with credential verification
- Forgot password flow (generates a time-limited reset token sent via SMTP email)
- Reset password flow (validates token and expiry before allowing reset)
- Passwords are hashed with BCrypt — never stored or logged in plain text
- Strict DTO model constraints and strong password validation

### Authentication & Authorization
- JWT Bearer authentication configured end-to-end (token issuance + validation)
- Tokens are signed with HMAC-SHA256 and include user ID (`nameid`), email, and name as claims
- `[Authorize]` attribute protecting user profile and all note operations
- User isolation: Logged-in users can only view, retrieve, edit, and delete their own notes
- Swagger UI configured with an **Authorize** button for testing protected routes directly

### Notes Management (CRUD & Media)
- **Create Note:** Create rich notes with Title, Description, and custom Background Color with automatic timestamps.
- **Get All Notes:** Retrieve all notes belonging strictly to the authenticated user.
- **Get Note by ID:** Fetch a single note by ID with user authorization validation.
- **Delete Note:** Safely remove a note belonging to the authenticated user.
- **Cloudinary Image Upload:** Dedicated `[HttpPut]` endpoint allowing users to upload and attach images directly to specific notes using `IFormFile` stream and Cloudinary CDN storage.

## Input Validation & Security Rules

To ensure clean and safe input handling, DTO-level validations are enforced before requests hit the business layer:

### Email Format
- **Rule:** Required field, validated against standard email conventions using `[EmailAddress]`.
- **Applied On:** `RegisterRequest`, `LoginRequest`, `ForgotPasswordRequest`, `ResetPasswordRequest`.

### Strong Password Policy
- **Rule:** Minimum **8 characters**, must contain at least:
  - 1 Uppercase letter (`A-Z`)
  - 1 Lowercase letter (`a-z`)
  - 1 Numeric digit (`0-9`)
  - 1 Special character (`@$!%*?&#`)
  - **No whitespace/spaces** allowed
- **Pattern:** `^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$`
- **Applied On:** `RegisterRequest`, `ResetPasswordRequest`.

### Infrastructure
- Dependency Injection wired across all four layers (Scoped lifetimes applied appropriately)
- CORS enabled for cross-origin frontend communication
- SMTP Mail service configured for password recovery emails
- Cloudinary SDK integration for external cloud asset handling
- EF Core Code-First migrations against SQL Server

## API Endpoints

### User Endpoints
| Method | Route | Auth Required | Description |
|---|---|---|---|
| POST | `/api/v1/user/register` | No | Register a new user |
| POST | `/api/v1/user/login` | No | Authenticate and receive a JWT |
| POST | `/api/v1/user/forgot-password` | No | Request a password reset token |
| POST | `/api/v1/user/reset-password` | No | Reset password using a valid token |
| GET | `/api/v1/user/profile` | **Yes** | Returns the authenticated user's claims |

### Notes Endpoints
| Method | Route | Auth Required | Description |
|---|---|---|---|
| POST | `/api/Notes` | **Yes** | Create a new note |
| GET | `/api/Notes` | **Yes** | Get all notes for the authenticated user |
| GET | `/api/Notes/{noteId}` | **Yes** | Get a specific note by ID |
| DELETE | `/api/Notes/{noteId}` | **Yes** | Delete a note by ID |
| PUT | `/api/Notes/{noteId}/image` | **Yes** | Upload and attach an image to a note (via Cloudinary) |

## Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local instance, Express, or LocalDB)
- Cloudinary Account (Free Tier)

### Setup

```bash
# 1. Restore dependencies across all projects
dotnet restore

# 2. Apply EF Core migrations (creates the database & applies latest schemas)
dotnet ef database update --project RepositoryLayer --startup-project Fundoo

# 3. Run the API
dotnet run --project Fundoo
```

Swagger UI will be available at `http://localhost:5000/swagger/index.html` when running in the Development environment.

> **Note:** If Swagger shows a blank page, ensure `ASPNETCORE_ENVIRONMENT` is set to `Development` — Swagger middleware is intentionally disabled outside of Development.

## Configuration

Connection string, JWT settings, SMTP, and Cloudinary keys live in `Fundoo/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=FundooNotesDb;Integrated Security=true;TrustServerCertificate=True;"
  },
  "SmtpSettings": {
    "Server": "smtp.gmail.com",
    "Port": 587,
    "SenderName": "Fundoo Notes Support",
    "SenderEmail": "<your-sender-email>",
    "Password": "<your-app-password>"
  },
  "CloudinarySettings": {
    "CloudName": "<your-cloud-name>",
    "ApiKey": "<your-api-key>",
    "ApiSecret": "<your-api-secret>"
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
- Add your active Cloudinary credentials under `CloudinarySettings`.
- Generate a random `Jwt:Key` (minimum 32 characters, required for HMAC-SHA256 signing) rather than using a placeholder value.

## Database Migrations

The `DbContext` lives in `RepositoryLayer`, but configuration (connection string) lives in `Fundoo`, so migration commands must specify both projects and be run from the solution root:

```bash
# Create a new migration after changing an entity
dotnet ef migrations add <MigrationName> --project RepositoryLayer --startup-project Fundoo

# Apply pending migrations to the database
dotnet ef database update --project RepositoryLayer --startup-project Fundoo
```

## Testing the API

1. Run the app and open Swagger UI or Postman.
2. `POST /api/v1/user/register` with `Name`, `Email`, and `Password`.
3. `POST /api/v1/user/login` with the registered credentials — copy the token from the response.
4. Set the Authorization Header as `Bearer <token>` (or paste into Swagger's Authorize modal).
5. `POST /api/Notes` with JSON body:
   ```json
   { "title": "My Note", "description": "Note content", "backgroundcolor": "#FFFFFF" }
   ```
6. `GET /api/Notes` to retrieve the created notes list.
7. `PUT /api/Notes/{noteId}/image` using form-data with key `image` (File) to upload an image to Cloudinary and attach the URL to the note.
8. `DELETE /api/Notes/{noteId}` to remove the note from the database.