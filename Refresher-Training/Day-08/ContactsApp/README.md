# 📇 ContactsApp - ASP.NET Core Minimal API

A professional **Contact Management Backend API** built using **ASP.NET Core Minimal API**, **ADO.NET**, and **SQL Server**.

The project demonstrates a clean layered architecture with Repository Pattern, Service Layer, Stored Procedures, Database Indexing, Triggers, and API testing using Postman.

---

# 🚀 Project Overview

ContactsApp is a backend application that provides RESTful APIs to manage contact information.

The application follows a layered architecture approach where:

- Minimal API handles HTTP requests
- Service Layer manages business logic
- Repository Layer communicates with SQL Server
- ADO.NET executes stored procedures
- SQL Server manages data persistence

---

# 🛠️ Tech Stack

## Backend

| Technology | Purpose |
|------------|---------|
| C# | Programming Language |
| .NET 8 | Backend Framework |
| ASP.NET Core Minimal API | API Development |
| ADO.NET | Database Connectivity |
| Microsoft.Data.SqlClient | SQL Server Provider |

---

## Database

| Technology | Purpose |
|------------|---------|
| SQL Server | Relational Database |
| Stored Procedures | Database Operations |
| Indexes | Query Optimization |
| Triggers | Audit Management |

---

## Testing

| Tool | Purpose |
|------|---------|
| Postman | API Testing |
| Git/GitHub | Version Control |

---

# 🏗️ Architecture

The project follows a layered architecture:

```
Client
  |
  |
Minimal API Endpoints
  |
  |
Service Layer
  |
  |
Repository Layer
  |
  |
ADO.NET
  |
  |
SQL Server
  |
  |
Stored Procedures
```

---

# 📂 Project Structure

```
ContactsApp
│
├── Data
│   └── DbConnection.cs
│
├── Endpoints
│   └── ContactEndpoints.cs
│
├── Interfaces
│   ├── IContactRepository.cs
│   └── IContactService.cs
│
├── Models
│   └── Contact.cs
│
├── Repository
│   └── ContactRepository.cs
│
├── Services
│   └── ContactService.cs
│
├── Program.cs
├── appsettings.json
└── ContactsApp.csproj
```

---

# 🗄️ Database Design

## Database

```
ContactDB
```

## Main Table

### Contacts

| Column | Data Type | Description |
|--------|-----------|-------------|
| ContactId | INT | Primary Key |
| FirstName | NVARCHAR(50) | Contact First Name |
| LastName | NVARCHAR(50) | Contact Last Name |
| Email | VARCHAR(150) | Unique Email |
| PhoneNumber | VARCHAR(15) | Contact Number |
| CreatedAt | DATETIME2 | Creation Timestamp |
| IsActive | BIT | Soft Delete Flag |

---

# 🔐 Database Features Implemented

## Primary Key

```sql
ContactId INT IDENTITY(1,1) PRIMARY KEY
```

Provides a unique identifier for every contact.

---

## Unique Constraint

```sql
UNIQUE(Email)
```

Prevents duplicate email records.

---

## Indexing

Created indexes for faster searching:

```
IX_Contacts_LastName

IX_Contacts_PhoneNumber
```

---

## Soft Delete

Instead of permanently deleting records:

```
IsActive = 0
```

is used.

This preserves historical data.

---

## Audit Trigger

An audit table tracks updates:

```
ContactAudit
```

Trigger:

```
trg_Contact_Update
```

stores update activity.

---

# ⚙️ Stored Procedures

The application communicates with SQL Server using stored procedures.

Implemented procedures:

| Procedure | Purpose |
|-----------|---------|
| sp_GetAllContacts | Retrieve all active contacts |
| sp_GetContactsById | Retrieve contact by ID |
| sp_AddContact | Insert new contact |
| sp_UpdateContact | Update existing contact |
| sp_DeleteContact | Soft delete contact |

---

# 🌐 API Endpoints

Base URL:

```
http://localhost:5179
```

---

## 1. Get All Contacts

### Request

```
GET /api/contacts
```

### Response

```json
[
  {
    "contactId":1,
    "firstName":"Rahul",
    "lastName":"Sharma",
    "email":"rahul@gmail.com",
    "phoneNumber":"9876543210",
    "isActive":true
  }
]
```

---

## 2. Get Contact By Id

### Request

```
GET /api/contacts/{id}
```

Example:

```
GET /api/contacts/1
```

---

## 3. Create Contact

### Request

```
POST /api/contacts
```

### Request Body

```json
{
  "firstName":"Vikas",
  "lastName":"Kumar",
  "email":"vikas@gmail.com",
  "phoneNumber":"9999999999"
}
```

---

## 4. Update Contact

### Request

```
PUT /api/contacts/{id}
```

### Request Body

```json
{
  "firstName":"Vikas",
  "lastName":"Sharma",
  "email":"vikas.updated@gmail.com",
  "phoneNumber":"8888888888"
}
```

---

## 5. Delete Contact

### Request

```
DELETE /api/contacts/{id}
```

Uses soft delete:

```
IsActive = 0
```

---

# 🔌 ADO.NET Implementation

The project uses:

## SqlConnection

Responsible for connecting with SQL Server.

---

## SqlCommand

Used to execute stored procedures.

---

## CommandType.StoredProcedure

Example:

```csharp
command.CommandType =
CommandType.StoredProcedure;
```

---

## Execute Methods

| Method | Usage |
|--------|-------|
| ExecuteReaderAsync() | Fetch data |
| ExecuteScalarAsync() | Retrieve generated ID |
| ExecuteNonQueryAsync() | Update/Delete |

---

# 🧪 API Testing

API endpoints were tested using Postman.

Test cases:

## Successful Requests

✅ Get all contacts  
✅ Get contact by ID  
✅ Create contact  
✅ Update contact  
✅ Delete contact  

---

## Negative Test Cases

✅ Invalid contact ID  
✅ Duplicate email validation  

---

# 🚀 Setup Instructions

## Prerequisites

Install:

- .NET 8 SDK
- SQL Server
- SQL Server Management Studio
- Postman


---

# 1. Clone Repository

```bash
git clone <https://shorturl.at/HQeAW>
```

---

# 2. Configure Database

Create database:

```
ContactDB
```

Execute SQL scripts to create:

- Tables
- Constraints
- Indexes
- Stored Procedures
- Triggers

---

# 3. Update Connection String

Modify:

```
appsettings.json
```

Example:

```json
{
 "ConnectionStrings":{
   "ContactDbConnection":
   "Server=localhost;Database=ContactDB;Trusted_Connection=True;TrustServerCertificate=True;"
 }
}
```

---

# 4. Install Dependencies

Run:

```bash
dotnet restore
```

---

# 5. Run Application

```bash
dotnet run
```

Application will start:

```
http://localhost:5179
```

---

# 📌 Learning Outcomes

Through this project, the following concepts were implemented:

- ASP.NET Core Minimal API
- REST API Design
- Repository Pattern
- Service Layer Architecture
- Dependency Injection
- ADO.NET
- SQL Server Integration
- Stored Procedures
- Indexing
- Triggers
- Soft Delete
- Postman API Testing

---

# 🔮 Future Enhancements

Possible improvements:

- JWT Authentication
- Global Exception Handling Middleware
- DTO Layer
- Fluent Validation
- Pagination
- Logging using Serilog
- Docker Containerization
- Unit Testing
- Swagger Documentation

---

