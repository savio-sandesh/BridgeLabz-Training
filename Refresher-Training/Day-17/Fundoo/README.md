# Fundoo Notes App

A Google Keep–inspired note-taking backend built with ASP.NET Core Web API, following a layered (multi-project) architecture with JWT-based authentication, Cloudinary media handling, label management, and automated MSTest unit test coverage.

---

## Table of Contents

- [Overview](#overview)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Features Implemented](#features-implemented)
- [Input Validation & Security Rules](#input-validation--security-rules)
- [API Endpoints](#api-endpoints)
- [Unit Testing (MSTest + Moq)](#unit-testing-mstest--moq)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Database Migrations](#database-migrations)
- [Testing the API](#testing-the-api)

---

## Overview

Fundoo Notes App is being built as a multi-day training project, progressively growing from a simple User Management module into a full enterprise-grade notes application (registration, notes CRUD, pinning/archiving, labels/tags management, Cloudinary CDN uploads, trash lifecycle, and unit test suites). This README reflects progress as of the **User Management + Notes Core & Media + Lifecycle + Labels Management + MSTest Suite** milestone.

## Tech Stack

| Layer | Technology |
|---|---|
| Runtime | .NET 10 |
| Web Framework | ASP.NET Core Web API |
| ORM | Entity Framework Core 10 |
| Database | SQL Server |
| Authentication | JWT Bearer tokens (HMAC-SHA256) |
| Password Hashing | BCrypt.Net-Next |
| Cloud Storage | Cloudinary (Image & Media uploads) |
| Email Service | SMTP / MailKit |
| Unit Testing | MSTest, Moq |
| API Documentation | Swagger / Swashbuckle |

## Architecture

The solution follows a **layered clean architecture**, with each layer compiled as its own class library and explicit project references enforcing the dependency direction:

```
Fundoo (WebAPI)  →  BusinessLayer  →  RepositoryLayer  →  ModelLayer
                              ↑
                     FundooTests (MSTest)
```

- **ModelLayer** — Database entities (`User`, `Note`, `Label`, `NoteLabel`) and Request/Response DTOs.
- **RepositoryLayer** — EF Core `AppDbContext`, database migrations, and repository implementations (`UserRepository`, `NoteRepository`, `LabelRepository`).
- **BusinessLayer** — Business workflows, password hashing, JWT token generation, Cloudinary media processing, and label/note business rules.
- **Fundoo (WebAPI)** — Controllers, route guards (`[Authorize]`), middleware pipeline, and DI registration.
- **FundooTests** — Isolated automated unit tests using **MSTest** and **Moq** to test service-layer logic without hitting a real database.

## Project Structure

```
Fundoo/
├── Fundoo.slnx
├── README.md
├── Fundoo/                          # WebAPI host project
│   ├── Controllers/
│   │   ├── LabelsController.cs
│   │   ├── NotesController.cs
│   │   └── UserController.cs
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── Program.cs
│   └── appsettings.json
├── ModelLayer/                      # Entities & DTOs
│   ├── DTOs/
│   │   ├── LabelDTOs.cs
│   │   ├── NoteDTOs.cs
│   │   └── UserDTOs.cs
│   └── Entities/
│       ├── Label.cs
│       ├── Note.cs
│       ├── NoteLabel.cs
│       └── User.cs
├── RepositoryLayer/                 # Data access & EF Core
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Interfaces/
│   │   ├── ILabelRepository.cs
│   │   ├── INoteRepository.cs
│   │   └── IUserRepository.cs
│   ├── Migrations/
│   └── Repositories/
│       ├── LabelRepository.cs
│       ├── NoteRepository.cs
│       └── UserRepository.cs
├── BusinessLayer/                   # Business logic
│   ├── Helpers/
│   │   ├── PasswordHasher.cs
│   │   └── TokenService.cs
│   ├── Interfaces/
│   │   ├── IEmailService.cs
│   │   ├── ILabelService.cs
│   │   ├── INoteService.cs
│   │   └── IUserService.cs
│   └── Services/
│       ├── EmailService.cs
│       ├── LabelService.cs
│       ├── NoteService.cs
│       └── UserService.cs
└── FundooTests/                     # Automated Unit Testing Suite
    ├── NoteServiceTests.cs
    ├── LabelServiceTests.cs
    └── MSTestSettings.cs
```

## Features Implemented

### User Management & Security
- User registration with duplicate email validation and regex-enforced strong passwords.
- Login with BCrypt hash verification issuing signed HMAC-SHA256 JWT tokens.
- Secure time-limited password reset workflow via SMTP email tokens.
- Scheduled reminder notifications delivered through RabbitMQ and SMTP email.
- User isolation: All operations strictly guarded and filtered by authenticated `UserId`.

### Notes Management & Media
- **Rich Notes CRUD:** Create, read, update, and soft/hard delete notes.
- **Cloudinary Integration:** Image uploading directly attached to notes via Cloudinary CDN.
- **Pin & Archive Operations:** Pinning notes to top and archiving workflows (auto-unpins archived notes).
- **Search & Filter:** Keyword-based searching across note titles and descriptions.
- **Trash Lifecycle:** Complete soft delete (`Move to Trash`), `Restore`, `Delete Forever`, and `Empty Trash` workflows.

### Tags / Labels Management
- **Master Label CRUD:** Create, view, update, and delete custom user labels.
- **Many-to-Many Mapping:** Implemented normalized junction table (`NoteLabels`) preventing duplicate associations.
- **Tag / Untag Notes:** Attach and detach labels to/from specific notes seamlessly.
- **Filter by Label:** Fetch all active notes associated with a specific label.
- **Fetch Note Labels:** Retrieve all attached labels for a specific note.

## Input Validation & Security Rules

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

## API Endpoints

### User Endpoints
| Method | Route | Auth Required | Description |
|---|---|---|---|
| POST | `/api/v1/user/register` | No | Register a new user |
| POST | `/api/v1/user/login` | No | Authenticate and receive JWT |
| POST | `/api/v1/user/forgot-password` | No | Request a password reset token |
| POST | `/api/v1/user/reset-password` | No | Reset password using token |

### Notes Endpoints
| Method | Route | Auth Required | Description |
|---|---|---|---|
| POST | `/api/Notes` | **Yes** | Create a new note |
| GET | `/api/Notes` | **Yes** | Get all active notes for user |
| GET | `/api/Notes/{noteId}` | **Yes** | Get specific note by ID |
| PUT | `/api/Notes/{noteId}` | **Yes** | Update an existing note |
| PUT | `/api/Notes/{noteId}/image` | **Yes** | Upload and attach image via Cloudinary |
| PUT | `/api/Notes/{noteId}/pin` | **Yes** | Toggle Pin/Unpin status |
| PUT | `/api/Notes/{noteId}/archive` | **Yes** | Toggle Archive/Unarchive status |
| GET | `/api/Notes/archive` | **Yes** | Get all archived notes |
| GET | `/api/Notes/search?keyword={text}` | **Yes** | Search notes by title or description |
| PUT | `/api/Notes/{noteId}/trash` | **Yes** | Move note to Trash (Soft Delete) |
| PUT | `/api/Notes/{noteId}/restore` | **Yes** | Restore note from Trash |
| GET | `/api/Notes/trash` | **Yes** | Get all trashed notes |
| DELETE | `/api/Notes/{noteId}/forever` | **Yes** | Permanently delete a single note |
| DELETE | `/api/Notes/trash/empty` | **Yes** | Permanently delete all trashed notes |

### Labels Endpoints
| Method | Route | Auth Required | Description |
|---|---|---|---|
| POST | `/api/Labels` | **Yes** | Create a new custom label |
| GET | `/api/Labels` | **Yes** | Get all labels created by user |
| PUT | `/api/Labels/{labelId}` | **Yes** | Rename an existing label |
| DELETE | `/api/Labels/{labelId}` | **Yes** | Delete a label and its mappings |
| POST | `/api/Labels/note/{noteId}/attach/{labelId}` | **Yes** | Tag/attach a label to a note |
| DELETE | `/api/Labels/note/{noteId}/detach/{labelId}` | **Yes** | Untag/detach a label from a note |
| GET | `/api/Labels/note/{noteId}` | **Yes** | Get all labels attached to a note |
| GET | `/api/Labels/{labelId}/notes` | **Yes** | Get all active notes mapped to a label |

---

## Unit Testing (MSTest + Moq)

The application utilizes **MSTest** and **Moq** for automated unit testing, adhering to the **Arrange-Act-Assert (AAA)** pattern to ensure complete isolation from real databases and external network calls.

### Running the Test Suite

Execute the following command from the root solution folder:

```bash
dotnet test
```

### Coverage Highlights

- **`NoteServiceTests`:** Tests note creation, retrieval by ID, edge-case null returns, and soft-delete trash operations.
- **`LabelServiceTests`:** Tests master label creation and note-label attachment mappings.
- **Dependency Isolation:** Repositories are stubbed using `Mock<T>` with argument matchers (`It.IsAny<T>()`) and behavior verification (`Times.Once`).

---

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (Local instance, Express, or LocalDB)
- Cloudinary Account (Free Tier)

### Setup & Run

```bash
# 1. Restore dependencies across all projects
dotnet restore

# 2. Apply EF Core database migrations
dotnet ef database update --project RepositoryLayer --startup-project Fundoo

# 3. Run the API host
dotnet run --project Fundoo
```

Swagger UI will be accessible at: `http://localhost:5000/swagger/index.html` (in Development mode).

---

## Configuration

Connection strings, JWT secrets, SMTP credentials, and Cloudinary API keys are managed in `Fundoo/appsettings.json`:

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

---

## Database Migrations

Run database migrations from the solution root:

```bash
# Add a new migration
dotnet ef migrations add <MigrationName> --project RepositoryLayer --startup-project Fundoo

# Apply migrations to database
dotnet ef database update --project RepositoryLayer --startup-project Fundoo
```

---

## Testing the API

1. `POST /api/v1/user/register` and `POST /api/v1/user/login` to obtain your JWT token.
2. Click **Authorize** in Swagger UI and input your token.
3. Create notes using `POST /api/Notes`.
4. Create labels using `POST /api/Labels`.
5. Attach labels to notes using `POST /api/Labels/note/{noteId}/attach/{labelId}`.
6. Verify labeled notes via `GET /api/Labels/{labelId}/notes`.
7. Upload images to notes using `PUT /api/Notes/{noteId}/image` (multipart form-data).
8. Soft-delete and manage the trash bin via `/api/Notes/{noteId}/trash` and `/api/Notes/trash`.