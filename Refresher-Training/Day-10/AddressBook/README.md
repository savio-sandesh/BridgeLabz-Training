# AddressBook API

A layered ASP.NET Core Web API for managing contacts using Entity Framework Core and SQL Server.

The project demonstrates a clean separation of concerns using **Models, Repository, Business, and Controller layers**, along with **Entity Framework Core, LINQ, Dependency Injection, and EF Core Migrations**.

---

## Features

- Create a new contact
- Retrieve all contacts
- Retrieve a contact by ID
- Update an existing contact
- Delete a contact
- Entity Framework Core integration
- SQL Server database integration
- LINQ-based database queries
- Dependency Injection
- Repository Pattern
- Business Layer
- RESTful API endpoints
- Swagger/OpenAPI documentation
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

```text
                    Client / Swagger
                          |
                          v
                  +----------------+
                  |   Controller   |
                  +----------------+
                          |
                          v
                  +----------------+
                  | Business Layer |
                  +----------------+
                          |
                          v
                  +----------------+
                  | Repository     |
                  |    Layer       |
                  +----------------+
                          |
                          v
                  +----------------+
                  |  EF Core /     |
                  |   DbContext    |
                  +----------------+
                          |
                          v
                  +----------------+
                  |   SQL Server   |
                  +----------------+
```

### Layer Responsibilities

#### Models

Contains the application's entities.

```text
Models
└── Entity
    └── Contact.cs
```

#### Repository

Responsible for database access and persistence operations.

```text
Repository
├── Context
│   └── AddressBookContext.cs
├── Interface
│   └── IContactRepository.cs
├── Service
│   └── ContactRepository.cs
└── Migrations
```

#### Business

Contains the application's business/application logic and communicates with the Repository layer.

```text
Business
├── Interface
│   └── IContactBusiness.cs
└── Service
    └── ContactBusiness.cs
```

#### AddressBook API

Contains the REST API controllers and application configuration.

```text
AddressBook
├── Controllers
│   └── ContactsController.cs
├── Program.cs
└── appsettings.json
```

---

## Contact Entity

The application currently works with a single entity: `Contact`.

```text
Contact
--------------------------------
Id
FirstName
LastName
PhoneNumber
Email
Address
```

The `Contact` entity is mapped to the `Contacts` table in SQL Server through Entity Framework Core.

---

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Contacts` | Get all contacts |
| GET | `/api/Contacts/{id}` | Get a contact by ID |
| POST | `/api/Contacts` | Create a new contact |
| PUT | `/api/Contacts/{id}` | Update an existing contact |
| DELETE | `/api/Contacts/{id}` | Delete a contact |

---

## Sample Request

### Create Contact

**POST**

```http
/api/Contacts
```

Request body:

```json
{
  "firstName": "Rahul",
  "lastName": "Sharma",
  "phoneNumber": "9876543210",
  "email": "rahul.sharma@gmail.com",
  "address": "Mathura, Uttar Pradesh"
}
```

### Update Contact

**PUT**

```http
/api/Contacts/1
```

Request body:

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

The application uses **SQL Server** with Entity Framework Core.

The database is created and managed using **EF Core Code-First Migrations**.

The database schema follows this flow:

```text
Contact Entity
      |
      v
AddressBookContext
      |
      v
EF Core Migration
      |
      v
SQL Server Database
      |
      v
Contacts Table
```

### Database Tables

The application contains:

```text
AddressBookDB
│
├── Contacts
│
└── __EFMigrationsHistory
```

`__EFMigrationsHistory` is maintained automatically by Entity Framework Core to track applied migrations.

---

## Entity Framework Core

The application uses `AddressBookContext` as the database context.

```csharp
public DbSet<Contact> Contacts { get; set; }
```

This provides EF Core with an entry point for querying and managing `Contact` entities.

Database operations are performed using Entity Framework Core methods such as:

```csharp
_context.Contacts.ToListAsync();

_context.Contacts.FirstOrDefaultAsync(c => c.Id == id);

_context.Contacts.Add(contact);

_context.Contacts.Update(contact);

_context.Contacts.Remove(contact);

await _context.SaveChangesAsync();
```

---

## LINQ

LINQ is used to query the `Contact` entities.

Example:

```csharp
var contact = await _context.Contacts
    .FirstOrDefaultAsync(c => c.Id == id);
```

EF Core translates the LINQ expression into SQL and executes it against SQL Server.

The overall flow is:

```text
C# LINQ Query
      |
      v
Entity Framework Core
      |
      v
SQL Query
      |
      v
SQL Server
```

---

## Dependency Injection

The application uses ASP.NET Core's built-in Dependency Injection container.

Repository registration:

```csharp
builder.Services.AddScoped<IContactRepository, ContactRepository>();
```

Business registration:

```csharp
builder.Services.AddScoped<IContactBusiness, ContactBusiness>();
```

Database context registration:

```csharp
builder.Services.AddDbContext<AddressBookContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
```

This allows dependencies to be injected through constructors rather than creating them manually.

---

## Project Structure

```text
AddressBook/
│
├── AddressBook.slnx
├── README.md
├── .gitignore
│
├── AddressBook/
│   ├── Controllers/
│   │   └── ContactsController.cs
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── Program.cs
│   ├── appsettings.json
│   └── AddressBook.csproj
│
├── Business/
│   ├── Interface/
│   │   └── IContactBusiness.cs
│   ├── Service/
│   │   └── ContactBusiness.cs
│   └── Business.csproj
│
├── Models/
│   ├── Entity/
│   │   └── Contact.cs
│   └── Models.csproj
│
└── Repository/
    ├── Context/
    │   └── AddressBookContext.cs
    ├── Interface/
    │   └── IContactRepository.cs
    ├── Service/
    │   └── ContactRepository.cs
    ├── Migrations/
    │   └── EF Core migration files
    └── Repository.csproj
```

---

## Prerequisites

Make sure the following are installed:

- .NET SDK
- SQL Server
- SQL Server Management Studio (SSMS)
- Git

Verify .NET installation:

```bash
dotnet --version
```

Verify EF Core CLI:

```bash
dotnet ef --version
```

---

## Configuration

Update the connection string in:

```text
AddressBook/appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> Update the SQL Server instance name according to your local environment.

---

## Running the Project

From the solution root:

```bash
dotnet restore
```

Build the solution:

```bash
dotnet build
```

Run the Web API:

```bash
cd AddressBook
dotnet run
```

The API will be available at the URL shown in the terminal.

---

## Database Migration

The project uses Entity Framework Core migrations.

Create a migration:

```bash
dotnet ef migrations add InitialCreate --project Repository --startup-project AddressBook --output-dir Migrations
```

Apply the migration:

```bash
dotnet ef database update --project Repository --startup-project AddressBook
```

This creates or updates the SQL Server database and applies the generated schema.

---

## Swagger

After running the application, open the Swagger UI using:

```text
http://localhost:5091/swagger
```

Swagger can be used to test all available CRUD endpoints.

---

## CRUD Flow

### Create

```text
POST
  ↓
Controller
  ↓
Business
  ↓
Repository
  ↓
EF Core
  ↓
SQL INSERT
```

### Read

```text
GET
  ↓
Controller
  ↓
Business
  ↓
Repository
  ↓
EF Core + LINQ
  ↓
SQL SELECT
```

### Update

```text
PUT
  ↓
Controller
  ↓
Business
  ↓
Repository
  ↓
EF Core
  ↓
SQL UPDATE
```

### Delete

```text
DELETE
  ↓
Controller
  ↓
Business
  ↓
Repository
  ↓
EF Core
  ↓
SQL DELETE
```

---

## Learning Objectives

This project was created to practice and understand:

- ASP.NET Core Web API
- REST API design
- Layered Architecture
- Repository Pattern
- Business Layer
- Dependency Injection
- Entity Framework Core
- `DbContext` and `DbSet`
- LINQ to Entities
- Asynchronous database operations
- `async` and `await`
- SQL Server integration
- EF Core Code-First Migrations
- Swagger/OpenAPI
- CRUD operations

---

## Current Scope

The current version intentionally focuses on a single entity:

```text
Contact
```

and provides complete CRUD functionality.

Additional concerns such as DTOs, advanced validation, and global exception handling can be introduced as future enhancements.

---

## Future Enhancements

- Add DTOs for request and response models
- Add model validation
- Add global exception handling
- Add pagination and sorting
- Add search and filtering
- Add unit and integration tests
- Add authentication and authorization
- Add logging and structured error responses

---

