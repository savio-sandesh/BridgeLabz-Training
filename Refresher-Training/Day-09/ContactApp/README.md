# ContactApp — ASP.NET Core Web API

A minimal RESTful Contacts Management API built using **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**.

The application connects to an existing SQL Server database and provides CRUD operations with **soft delete** using the `IsActive` flag.

---

## 🛠️ Tech Stack

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Postman

---

## 🏗️ Project Structure

```text
ContactApp/
│
├── Controllers/
│   └── ContactsController.cs
│
├── Models/
│   └── Contact.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Program.cs
├── appsettings.json
└── README.md
```

### Responsibilities

- **Models** — Contains the `Contact` entity.
- **Data** — Contains `AppDbContext` for EF Core database access.
- **Controllers** — Contains REST API endpoints.
- **Program.cs** — Configures Dependency Injection, EF Core, and the application pipeline.

---

## 🗄️ Database

The project uses an existing SQL Server database:

```text
Server: localhost\SQLEXPRESS
Database: ContactDB
Table: Contacts
```

### Contact Entity

```text
ContactId
FirstName
LastName
Email
PhoneNumber
CreatedAt
IsActive
```

`IsActive` is used for **soft deletion**:

```text
1 → Active
0 → Inactive / Deleted
```

---

## 🔌 Entity Framework Core

`AppDbContext` manages database operations through EF Core.

```csharp
public DbSet<Contact> Contacts { get; set; }
```

The context is registered using Dependency Injection:

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ContactDbConnection")));
```

---

## 🔄 API Endpoints

| Method | Endpoint              | Description               |
|--------|------------------------|----------------------------|
| GET    | `/api/contacts`        | Get all active contacts   |
| GET    | `/api/contacts/{id}`   | Get contact by ID         |
| POST   | `/api/contacts`        | Create a contact          |
| PUT    | `/api/contacts/{id}`   | Update a contact          |
| DELETE | `/api/contacts/{id}`   | Soft delete a contact     |

---

## 📡 Example API Requests

### Get All Contacts

```http
GET {{BaseUrl}}/api/contacts
```

### Get Contact by ID

```http
GET {{BaseUrl}}/api/contacts/1
```

### Create Contact

```http
POST {{BaseUrl}}/api/contacts
```

```json
{
  "firstName": "Chhavi",
  "lastName": "Garg",
  "email": "chhavi1@gmail.com",
  "phoneNumber": "8820112233"
}
```

### Update Contact

```http
PUT {{BaseUrl}}/api/contacts/1
```

### Delete Contact

```http
DELETE {{BaseUrl}}/api/contacts/1
```

The DELETE operation sets:

```text
IsActive = false
```

instead of physically removing the database record.

---

## ⚙️ SQL Server Trigger Configuration

The existing `Contacts` table contains a SQL Server trigger. To make EF Core compatible with the table, the output clause is disabled:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Contact>()
        .ToTable("Contacts", table =>
            table.UseSqlOutputClause(false));
}
```

---

## 🧪 API Testing

APIs were tested using **Postman**.

```text
Base URL:
http://localhost:5097
```

All CRUD operations were tested successfully.

---

## 🚀 Run the Project

```bash
dotnet restore
dotnet build
dotnet run
```

API:

```text
http://localhost:5097
```

---

## 🎯 Learning Outcomes

- Entity Framework Core and ORM
- `DbContext` and `DbSet`
- Dependency Injection
- RESTful APIs
- CRUD operations
- EF Core Change Tracking
- Soft Delete
- SQL Server integration
- Working with existing databases and triggers
- Postman API testing

---

## 📌 Project Status

**Completed — All CRUD operations are working successfully.**