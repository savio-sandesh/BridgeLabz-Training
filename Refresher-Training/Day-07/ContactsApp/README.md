# ContactsApp

A lightweight **Contacts Management REST API** built using **ASP.NET Core Minimal APIs**.

The application provides full CRUD operations for managing contacts, along with input validation, appropriate HTTP status codes, and interactive API documentation via Swagger/OpenAPI.

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Project Structure](#project-structure)
- [Contact Entity](#contact-entity)
- [API Endpoints](#api-endpoints)
- [API Operations](#api-operations)
- [Validation](#validation)
- [HTTP Status Codes](#http-status-codes)
- [Swagger / OpenAPI](#swagger--openapi)
- [Getting Started](#getting-started)
- [Data Storage](#data-storage)
- [Application Flow](#application-flow)
- [Key Concepts Demonstrated](#key-concepts-demonstrated)
- [Future Enhancements](#future-enhancements)
- [Learning Objective](#learning-objective)

---

## Overview

ContactsApp is a simple backend application built to demonstrate the fundamentals of designing RESTful APIs using ASP.NET Core Minimal APIs.

The application currently stores contact data in an **in-memory collection** (`List<Contact>`). As a result, data persists only while the application is running and is reset whenever the application restarts.

---

## Features

- Create a new contact
- Retrieve all contacts
- Retrieve a contact by ID
- Update an existing contact
- Delete a contact
- Basic input validation
- Appropriate HTTP status codes for every operation
- Swagger/OpenAPI integration for interactive API testing

---

## Technology Stack

| Technology | Purpose |
|---|---|
| C# | Programming language |
| .NET 8 | Runtime and framework |
| ASP.NET Core Minimal APIs | REST API development |
| Swagger / OpenAPI | API documentation and testing |
| Swashbuckle.AspNetCore | Swagger integration |
| In-memory collection | Temporary data storage |

---

## Project Structure

```text
ContactsApp/
│
├── Entity/
│   └── Contact.cs
│
├── Program.cs
│
├── appsettings.json
├── appsettings.Development.json
├── .gitignore
└── ContactsApp.csproj
```

---

## Contact Entity

The `Contact` class represents a single contact within the application.

```csharp
public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
```

---

## API Endpoints

| HTTP Method | Endpoint | Description |
|---|---|---|
| `GET` | `/contacts` | Retrieves all contacts |
| `GET` | `/contacts/{id}` | Retrieves a contact by ID |
| `POST` | `/contacts` | Creates a new contact |
| `PUT` | `/contacts/{id}` | Updates an existing contact |
| `DELETE` | `/contacts/{id}` | Deletes a contact |

---

## API Operations

### 1. Get All Contacts

```
GET /contacts
```

Returns all available contacts.

**Example response:**

```json
[
  {
    "id": 1,
    "name": "Rahul",
    "email": "rahul@gmail.com",
    "phone": "9876543210"
  },
  {
    "id": 2,
    "name": "Aman",
    "email": "aman@gmail.com",
    "phone": "9123456780"
  }
]
```

### 2. Get Contact by ID

```
GET /contacts/1
```

Returns the contact associated with the specified ID.

If the contact does not exist, the API returns:

```
404 Not Found
```

### 3. Create a Contact

```
POST /contacts
```

**Request body:**

```json
{
  "name": "Sandesh",
  "email": "sandesh@gmail.com",
  "phone": "9149320023"
}
```

**Successful response:**

```
201 Created
```

The application automatically generates a new contact ID.

### 4. Update a Contact

```
PUT /contacts/1
```

**Request body:**

```json
{
  "name": "Rahul Updated",
  "email": "rahul.updated@gmail.com",
  "phone": "9999999999"
}
```

**Successful response:**

```
200 OK
```

### 5. Delete a Contact

```
DELETE /contacts/1
```

**Successful response:**

```
204 No Content
```

---

## Validation

The API performs basic validation when creating or updating a contact. The following fields are required:

- `Name`
- `Email`
- `Phone`

**Example error response:**

```
400 Bad Request
Name is required.
```

---

## HTTP Status Codes

| Status Code | Description |
|---|---|
| `200 OK` | Request completed successfully |
| `201 Created` | New contact successfully created |
| `204 No Content` | Contact successfully deleted |
| `400 Bad Request` | Invalid or missing input |
| `404 Not Found` | Contact does not exist |

---

## Swagger / OpenAPI

The application uses **Swashbuckle.AspNetCore** to provide interactive Swagger documentation.

After running the application, navigate to:

```
http://localhost:<PORT>/swagger
```

Swagger allows you to:

- View all available endpoints
- Execute `GET`, `POST`, `PUT`, and `DELETE` requests directly from the browser
- View request and response data
- Inspect HTTP status codes

---

## Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
```

### 2. Navigate to the Project

```bash
cd ContactsApp
```

### 3. Restore Dependencies

```bash
dotnet restore
```

### 4. Run the Application

```bash
dotnet run
```

The terminal will display the application URL:

```
Now listening on: http://localhost:<PORT>
```

### 5. Open Swagger

Navigate to:

```
http://localhost:<PORT>/swagger
```

---

## Data Storage

The current version uses an in-memory collection:

```csharp
var contacts = new List<Contact>();
```

As a result:

- Contacts are stored only in application memory.
- `POST` adds a contact to the runtime collection.
- `PUT` updates the contact in the runtime collection.
- `DELETE` removes the contact from the runtime collection.
- Restarting the application resets all data.

---

## Application Flow

```
Client / Swagger
       │
       ▼
ASP.NET Core Minimal API
       │
       ▼
    Endpoint
       │
       ▼
  List<Contact>
       │
       ▼
Application Memory (RAM)
```

**Request routing overview:**

```
                    ContactsApp
                         │
                         ▼
              ASP.NET Core Minimal API
                         │
     ┌──────────────┬────────────┬──────────────┐
     │              │            │              │
    GET             POST         PUT           DELETE
     │              │            │              │
     └──────────────┴────────────┴──────────────┘
                         │
                         ▼
                  List<Contact> (RAM)
```

---

## Key Concepts Demonstrated

This project demonstrates practical, hands-on understanding of:

- ASP.NET Core Minimal APIs
- RESTful API design
- CRUD operations
- HTTP methods and route parameters
- Lambda expressions and LINQ (`FirstOrDefault()`)
- In-memory data collections
- Input validation
- HTTP status codes
- Swagger/OpenAPI documentation
- Request and response handling
- Razor-independent backend API development

---

## Future Enhancements

- SQL Server database integration
- ADO.NET data access
- Entity Framework Core
- Repository pattern
- Service layer separation
- DTOs (Data Transfer Objects)
- Advanced validation
- Global exception handling
- Logging
- Authentication and authorization
- Pagination and filtering
- Unit and integration testing

---

## Learning Objective

The primary objective of this project is to understand how to build a simple RESTful backend using ASP.NET Core Minimal APIs — implementing CRUD operations, handling HTTP responses and validation, and testing endpoints interactively using Swagger.