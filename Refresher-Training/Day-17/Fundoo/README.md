# Fundoo Notes App

A Google Keep–inspired note-taking backend built with ASP.NET Core Web API, following a layered (multi-project) architecture with JWT-based authentication, Cloudinary media handling, label management, RabbitMQ-driven reminders, and automated MSTest unit test coverage.

---

## Table of Contents

- [Overview](#overview)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Features Implemented](#features-implemented)
- [Asynchronous Architecture (RabbitMQ)](#asynchronous-architecture-rabbitmq)
- [Input Validation & Security Rules](#input-validation--security-rules)
- [API Endpoints](#api-endpoints)
- [Unit Testing (MSTest + Moq)](#unit-testing-mstest--moq)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Database Migrations](#database-migrations)
- [Testing the API (Step-by-Step Manual Flow)](#testing-the-api-step-by-step-manual-flow)

---

## Overview

Fundoo Notes App is being built as a multi-day training project, progressively growing from a simple User Management module into a full enterprise-grade notes application (registration, notes CRUD, pinning/archiving, labels/tags management, Cloudinary CDN uploads, RabbitMQ-based reminders, trash lifecycle, and unit test suites). This README reflects progress as of the **User Management + Notes Core & Media + Lifecycle + Labels Management + Reminders (RabbitMQ) + MSTest Suite** milestone.

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
| Message Broker | RabbitMQ / CloudAMQP (`RabbitMQ.Client`) |
| Background Processing | .NET `BackgroundService` (`IHostedService`) |
| Unit Testing | MSTest, Moq |
| API Documentation | Swagger / Swashbuckle |

## Architecture

The solution follows a **layered clean architecture**, with each layer compiled as its own class library and explicit project references enforcing the dependency direction:

```
Fundoo (WebAPI Host)  →  BusinessLayer  →  RepositoryLayer  →  ModelLayer
         │                     │
         ▼                     ▼
[BackgroundService]    [IRabbitMqProducer] ──► [RabbitMQ / CloudAMQP Queue]
         ▲                                                │
         └──────────────── (Async Consumer) ──────────────┘
```

- **ModelLayer** — Database entities (`User`, `Note`, `Label`, `NoteLabel`) and Request/Response DTOs.
- **RepositoryLayer** — EF Core `AppDbContext`, database migrations, and repository implementations (`UserRepository`, `NoteRepository`, `LabelRepository`).
- **BusinessLayer** — Business workflows, password hashing, JWT token generation, Cloudinary media processing, `IRabbitMqProducer`/`RabbitMqProducer` publishing logic, and label/note business rules.
- **Fundoo (WebAPI Host)** — Controllers, route guards (`[Authorize]`), middleware pipeline, DI registration, and the `ReminderNotificationConsumer` `BackgroundService` (`IHostedService`) that listens for and consumes queued reminder events.
- **FundooTests** — Isolated automated unit tests using **MSTest** and **Moq** to test service-layer logic without hitting a real database.
- **RabbitMQ / CloudAMQP Queue** — Decouples reminder notification delivery from the request/response cycle. `RabbitMqProducer` publishes reminder events to the queue from the API request path; the `ReminderNotificationConsumer` background worker consumes them asynchronously and triggers the SMTP email send, so the API responds immediately without waiting on email delivery.

## Project Structure

```
Fundoo/
├── Fundoo.slnx
├── README.md
├── Fundoo/                          # WebAPI host & Background Services
│   ├── BackgroundServices/
│   │   └── ReminderNotificationConsumer.cs
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
│   │   ├── ReminderDTOs.cs
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
│   │   ├── IRabbitMqProducer.cs
│   │   └── IUserService.cs
│   └── Services/
│       ├── EmailService.cs
│       ├── LabelService.cs
│       ├── NoteService.cs
│       ├── RabbitMqProducer.cs
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

### Reminders & RabbitMQ Asynchronous Notifications (Day 17)
- **Reminder Operations:** Set, update, clear, and view notes with active reminder timestamps.
- **Decoupled Architecture:** When a reminder is set, the API does not block for email delivery. It publishes an event payload to RabbitMQ in ~3 ms.
- **Background Hosted Consumer:** A background worker (`ReminderNotificationConsumer`) continuously listens to the message queue, acknowledges processed payloads, and triggers SMTP reminder notifications asynchronously.

## Asynchronous Architecture (RabbitMQ)

### Event Flow:
1. Client calls `PUT /api/Notes/{id}/reminder`
2. `NoteService` updates SQL Server timestamp
3. `RabbitMqProducer` publishes `ReminderNotificationMessage` to `reminder_notifications_queue`
4. API immediately returns `200 OK` (Non-blocking)
5. `BackgroundService` consumes message and sends SMTP Email asynchronously

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
| PUT | `/api/Notes/{noteId}/reminder` | **Yes** | Set a reminder timestamp on a note (async via RabbitMQ) |
| GET | `/api/Notes/reminders` | **Yes** | Get all notes with upcoming reminders |
| DELETE | `/api/Notes/{noteId}/reminder` | **Yes** | Remove a note's reminder |
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
- CloudAMQP Instance (Free Tier) or Local RabbitMQ / Docker

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
  "RabbitMQ": {
    "Uri": "amqps://<user>:<password>@<host>.cloudamqp.com/<vhost>"
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

## Testing the API (Step-by-Step Manual Flow)

Follow this end-to-end sequence in Swagger UI or Postman to test the full application workflow:

### 1. Authentication Flow
1. **Register:** Send `POST /api/v1/user/register` with `name`, `email`, and a strong `password`.
2. **Login:** Send `POST /api/v1/user/login` with your credentials. Copy the `jwtToken` from the response.
3. **Authorize:** Click the green **Authorize** button in Swagger UI, enter `Bearer <your_jwt_token>`, and click **Authorize**.

### 2. Core Notes Operations
4. **Create Note:** Send `POST /api/Notes` with `{ "title": "Meeting Notes", "description": "Discuss architecture", "backgroundcolor": "#FFE4C4" }`. Note down the returned `noteId`.
5. **Get Active Notes:** Send `GET /api/Notes` to confirm the created note appears in your active list.
6. **Update Note:** Send `PUT /api/Notes/{noteId}` to edit the title, description, or color.
7. **Pin / Archive:** Test `PUT /api/Notes/{noteId}/pin` to toggle pin status and `PUT /api/Notes/{noteId}/archive` to archive the note.

### 3. Media Upload (Cloudinary)
8. **Attach Image:** Send `PUT /api/Notes/{noteId}/image` using `multipart/form-data` with key `image` (upload any image file) to verify Cloudinary upload.

### 4. Tags / Labels Management
9. **Create Label:** Send `POST /api/Labels` with `{ "labelName": "Work" }`. Note down the `labelId`.
10. **Tag Note:** Send `POST /api/Labels/note/{noteId}/attach/{labelId}` to link the label to your note.
11. **Filter by Label:** Send `GET /api/Labels/{labelId}/notes` to verify only notes with this tag are returned.
12. **Untag Note:** Send `DELETE /api/Labels/note/{noteId}/detach/{labelId}` to remove the mapping.

### 5. Reminders & RabbitMQ Asynchronous Processing
13. **Set Reminder:** Send `PUT /api/Notes/{noteId}/reminder` with `{ "reminder": "2026-08-30T18:00:00Z" }`.
14. **Verify RabbitMQ Queue:** Check your terminal output to verify that:
    - The API returned `200 OK` instantly (non-blocking).
    - `RabbitMqProducer` published the event to `reminder_notifications_queue`.
    - `ReminderNotificationConsumer` picked up the message and triggered the background email notification.
15. **Get Reminders:** Send `GET /api/Notes/reminders` to view all notes with upcoming reminders.
16. **Remove Reminder:** Send `DELETE /api/Notes/{noteId}/reminder` to clear the reminder timestamp.

### 6. Trash & Permanent Delete Lifecycle
17. **Soft Delete:** Send `PUT /api/Notes/{noteId}/trash` to move the note to trash.
18. **View Trash:** Send `GET /api/Notes/trash` to confirm the note is in the trash bin (it will no longer appear in `GET /api/Notes`).
19. **Restore Note:** Send `PUT /api/Notes/{noteId}/restore` to move it back to active notes.
20. **Hard Delete:** Send `DELETE /api/Notes/{noteId}/forever` to permanently destroy the note, or `DELETE /api/Notes/trash/empty` to wipe out all trashed notes.