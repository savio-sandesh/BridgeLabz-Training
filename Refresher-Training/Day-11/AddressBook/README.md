# AddressBook API

A layered ASP.NET Core Web API for managing contacts using Entity Framework Core and SQL Server.

The project demonstrates a clean separation of concerns using **Models, Repository, Business, and Controller layers**, along with **Entity Framework Core, LINQ, Dependency Injection, DTOs, and EF Core Code-First Migrations**.

---

## Features

- Full CRUD operations for contacts (Create, Read, Update, Delete)
- Entity Framework Core with SQL Server integration
- LINQ-based database queries
- Dependency Injection
- Repository and Business layer separation
- Data Transfer Objects (DTOs) for request/response models
- Custom exception handling for missing contacts
- RESTful API endpoints with Swagger/OpenAPI documentation
- EF Core Code-First Migrations

---

## Technology Stack

| Technology | Purpose |
|---|---|
| C# | Programming language |
| .NET | Application platform |
| ASP.NET Core Web API | REST API development |
| Entity Framework Core | ORM and database access |
| SQL Server | Relational database |
| LINQ | Database querying |
| Swagger / OpenAPI | API documentation and testing |
| Git & GitHub | Version control |

---

## Architecture

The project follows a layered architecture:

```
Client / Swagger → Controller (DTOs) → Business Layer (DTO ↔ Entity) → Repository → EF Core → SQL Server
```

**Request flow:** Client → DTO → Controller → Business Layer → Entity → Repository → EF Core → SQL Server
**Response flow:** SQL Server → EF Core → Repository → Entity → Business Layer → DTO → Controller → Client

### Layer Responsibilities

**Models** — Contains entities, DTOs, and application-specific exceptions.
```
Models
├── Entity/Contact.cs
├── DTO/CreateContactDto.cs, UpdateContactDto.cs, ContactResponseDto.cs
└── Exception/ContactNotFoundException.cs
```

DTOs decouple the API contract from the database entity:
- `CreateContactDto` — used for POST requests
- `UpdateContactDto` — used for PUT requests
- `ContactResponseDto` — used for API responses

**Repository** — Handles database access and persistence, working directly with `Contact` entities (not DTOs).
```
Repository
├── Context/AddressBookContext.cs
├── Interface/IContactRepository.cs
├── Service/ContactRepository.cs
└── Migrations/
```

**Business** — Bridges DTOs and entities; performs DTO↔Entity mapping, existence checks, and coordinates with the Repository.
```
Business
├── Interface/IContactBusiness.cs
└── Service/ContactBusiness.cs
```

**AddressBook API** — Hosts controllers and application configuration.
```
AddressBook
├── Controllers/ContactsController.cs
├── Program.cs
└── appsettings.json
```

---

## Contact Entity

```
Contact
├── Id
├── FirstName
├── LastName
├── PhoneNumber
├── Email
└── Address
```

Mapped to the `Contacts` table in SQL Server via Entity Framework Core.

---

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Contacts` | Get all contacts |
| GET | `/api/Contacts/{id}` | Get a contact by ID |
| POST | `/api/Contacts` | Create a new contact |
| PUT | `/api/Contacts/{id}` | Update an existing contact |
| DELETE | `/api/Contacts/{id}` | Delete a contact |

### Sample Requests

**Create Contact** — `POST /api/Contacts`
```json
{
  "firstName": "Rahul",
  "lastName": "Sharma",
  "phoneNumber": "9876543210",
  "email": "rahul.sharma@gmail.com",
  "address": "Mathura, Uttar Pradesh"
}
```

**Update Contact** — `PUT /api/Contacts/1`
```json
{
  "firstName": "Rahul",
  "lastName": "Sharma",
  "phoneNumber": "9999999999",
  "email": "rahul.sharma@gmail.com",
  "address": "Delhi, India"
}
```
> The `id` is supplied via the URL, not the request body.

**Response Example** — `ContactResponseDto`
```json
{
  "id": 1,
  "firstName": "Rahul",
  "lastName": "Sharma",
  "phoneNumber": "9999999999",
  "email": "rahul.sharma@gmail.com",
  "address": "Delhi, India"
}
```

---

## Database

The application uses SQL Server, managed via EF Core Code-First Migrations.

```
AddressBookDB
├── Contacts
└── __EFMigrationsHistory   (managed automatically by EF Core)
```

`AddressBookContext` exposes `DbSet<Contact> Contacts` as the entry point for querying and managing data. Common Repository-layer operations include:

```csharp
_context.Contacts.ToListAsync();
_context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
_context.Contacts.Add(contact);
_context.Contacts.Update(contact);
_context.Contacts.Remove(contact);
await _context.SaveChangesAsync();
```

### LINQ

Used throughout the Repository and Business layers, e.g.:

```csharp
var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);

return contacts.Select(contact => new ContactResponseDto
{
    Id = contact.Id,
    FirstName = contact.FirstName,
    LastName = contact.LastName,
    PhoneNumber = contact.PhoneNumber,
    Email = contact.Email,
    Address = contact.Address
});
```

EF Core translates these LINQ queries into SQL and executes them against SQL Server.

---

## Dependency Injection

Registered in `Program.cs` using ASP.NET Core's built-in DI container:

```csharp
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactBusiness, ContactBusiness>();
builder.Services.AddDbContext<AddressBookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

## Exception Handling

A custom `ContactNotFoundException` is thrown by the Business layer when a requested contact cannot be found:

```csharp
if (contact == null)
{
    throw new ContactNotFoundException(id);
}
```

> A global exception handler is not yet implemented and is planned as a future enhancement.

---

## Project Structure

```
AddressBook/
├── AddressBook.slnx
├── README.md
├── .gitignore
│
├── AddressBook/
│   ├── Controllers/ContactsController.cs
│   ├── Properties/launchSettings.json
│   ├── Program.cs
│   ├── appsettings.json
│   └── AddressBook.csproj
│
├── Business/
│   ├── Interface/IContactBusiness.cs
│   ├── Service/ContactBusiness.cs
│   └── Business.csproj
│
├── Models/
│   ├── Entity/Contact.cs
│   ├── DTO/CreateContactDto.cs, UpdateContactDto.cs, ContactResponseDto.cs
│   ├── Exception/ContactNotFoundException.cs
│   └── Models.csproj
│
└── Repository/
    ├── Context/AddressBookContext.cs
    ├── Interface/IContactRepository.cs
    ├── Service/ContactRepository.cs
    ├── Migrations/
    └── Repository.csproj
```

---

## Getting Started

### Prerequisites
- .NET SDK
- SQL Server
- SQL Server Management Studio (SSMS)
- Git

Verify installation:
```bash
dotnet --version
dotnet ef --version
```

### Configuration

Update the connection string in `AddressBook/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### Running the Project

```bash
dotnet restore
dotnet build
cd AddressBook
dotnet run
```

The API will be available at the URL shown in the terminal.

### Database Migrations

```bash
dotnet ef migrations add InitialCreate --project Repository --startup-project AddressBook --output-dir Migrations
dotnet ef database update --project Repository --startup-project AddressBook
```

Migration files are stored in `Repository/Migrations` and should be committed to source control.

### Swagger

Once running, open Swagger UI at:
```
http://localhost:5091/swagger
```

Use it to test all available CRUD endpoints.

---

## Learning Objectives

This project was built to practice:

- ASP.NET Core Web API & REST design
- Layered architecture and the Repository pattern
- Dependency Injection
- Entity Framework Core (DbContext, DbSet, migrations)
- LINQ to Entities
- DTOs and entity mapping
- Asynchronous programming (`async`/`await`)
- Swagger/OpenAPI documentation
- Basic custom exception handling

---

## Current Scope

The current version implements complete CRUD functionality for a single entity, `Contact`, using DTOs to separate API models from the database entity, plus a custom `ContactNotFoundException` for missing contacts.

Global exception handling, advanced validation, and other production-level concerns are not yet implemented.

---

## Future Enhancements

- Model validation
- Global exception handling
- Pagination and sorting
- Search and filtering
- Duplicate contact/email validation
- Unit and integration tests
- Authentication and authorization
- Logging and structured error responses
- AutoMapper (or similar) for entity/DTO mapping
- API versioning