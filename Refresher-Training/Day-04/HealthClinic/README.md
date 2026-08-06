# Health Clinic Management System

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![C#](https://img.shields.io/badge/C%23-Language-purple)
![SQL%20Server](https://img.shields.io/badge/SQL%20Server-Database-red)
![ADO.NET](https://img.shields.io/badge/ADO.NET-Data%20Access-green)
![License](https://img.shields.io/badge/License-MIT-blue)


A console-based Health Clinic Management System built using **C#**, **ADO.NET**, and **SQL Server**. The application follows a layered architecture to separate presentation, business logic, and data access concerns, making the project modular, maintainable, and easy to extend.

---

## Overview

The system enables reception staff to manage patients, doctors, and appointments through a menu-driven console application.

### Features

### Patient Management
- Register Patient
- View All Patients
- Search Patient by ID
- Update Patient Information
- Delete Patient

### Doctor Management
- Register Doctor
- View All Doctors
- Search Doctor by ID
- Update Doctor Information
- Delete Doctor

### Appointment Management
- Book Appointment
- View All Appointments
- Search Appointment by ID
- View Patient Appointments
- Update Appointment Status
- Cancel Appointment

---

## Technology Stack

| Technology | Description |
|------------|-------------|
| C# | Application Development |
| .NET | Console Application |
| ADO.NET | Database Connectivity |
| SQL Server | Relational Database |
| Microsoft.Data.SqlClient | SQL Server Provider |
| Git | Version Control |

---

## Project Architecture

The application follows a layered architecture.

```
Presentation Layer
        │
        ▼
      Menu
        │
        ▼
Business Logic Layer
     Services
        │
        ▼
Data Access
 DBConnection (ADO.NET)
        │
        ▼
    SQL Server
```

### Project Structure

```
HealthClinic
│
├── Connection
│   └── DBConnection.cs
│
├── Entity
│   ├── Appointment.cs
│   ├── Doctor.cs
│   └── Patient.cs
│
├── Interface
│   ├── IAppointmentService.cs
│   ├── IDoctorService.cs
│   └── IPatientService.cs
│
├── Service
│   ├── AppointmentService.cs
│   ├── DoctorService.cs
│   └── PatientService.cs
│
├── Menu
│   ├── MainMenu.cs
│   ├── AppointmentMenu.cs
│   ├── DoctorMenu.cs
│   └── PatientMenu.cs
│
└── Program.cs
```

---

## Database Design

### Core Tables

- Patient
- Doctor
- Appointment

The database is designed using relational principles with appropriate primary and foreign key constraints to maintain data integrity.

---

## Design Principles

- Layered Architecture
- Separation of Concerns
- Interface-Based Programming
- Object-Oriented Design
- Centralized Database Connection Management
- Parameterized SQL Queries
- Reusable Service Layer

---

## Security Considerations

- Uses parameterized queries to prevent SQL Injection.
- Database connections are managed through a centralized `DBConnection` class.
- Business logic is isolated from the presentation layer.

---

## Getting Started

### Prerequisites

- .NET SDK
- SQL Server
- Visual Studio 2022

### Installation

Clone the repository

```bash
git clone https://github.com/<username>/HealthClinic.git
```

Navigate to the project directory

```bash
cd HealthClinic
```

Restore dependencies

```bash
dotnet restore
```

Update the SQL Server connection string inside:

```
Connection/DBConnection.cs
```

Build the project

```bash
dotnet build
```

Run the application

```bash
dotnet run
```

---

## Future Improvements

- Exception Handling
- Input Validation
- Logging
- Authentication & Authorization
- Doctor Schedule Management
- Billing & Payment Module
- Entity Framework Core Migration

---

## Author

**Sandesh**

Computer Science & Engineering Student

Aspiring .NET Backend Developer

---

## License

This project is intended for educational and learning purposes.