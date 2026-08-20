# 📘 .NET Full-Stack Developer — Refresher Program Log

**Duration:** Day 1 – Day 15 (In Progress)
**Track:** Database Programming → Backend Development (ASP.NET Core) → Backend with Entity Framework → Advanced Backend Architecture & Enterprise Modules
**Stack:** MS SQL Server, T-SQL, ADO.NET, ASP.NET Core, WebAPI, MVC, Minimal APIs, Entity Framework Core, LINQ, JWT, BCrypt, Cloudinary, SMTP MailKit, Swagger, Postman, C#
**Repository:** [BridgeLabz-Training (Refresher-Training branch)](https://github.com/savio-sandesh/BridgeLabz-Training/tree/Refresher-Training/Refresher-Training)

---

## 📌 Overview

This log documents the technical topics covered and hands-on deliverables completed during the comprehensive refresher program focused on **database programming**, **.NET backend development**, and **enterprise-grade modular REST APIs**. The program is structured into progressive stages:

| Stage | Days | Focus Area |
|---|---|---|
| Stage 1 | Day 1 – Day 4 | Database (DB) Programming — MS SQL Server, T-SQL, ADO.NET |
| Stage 2 | Day 5 – Day 8 | Backend Basics — ASP.NET Core, WebAPI, MVC, Minimal APIs, Distributed Architectures, SDLC |
| Stage 3 | Day 9 – Day 10 | Backend with Entity Framework — ORM, EF Core, LINQ to Entities |
| Stage 4 | Day 11 – Day 12 | Enterprise Service Design — Multi-Layer Architecture, Dependency Injection Scopes, Logging & Postman Testing |
| Stage 5 | Day 13 – Day 15 | Advanced Backend Development — JWT Security, Secure Notes CRUD, Cloudinary Integration, Organization & Lifecycle Modules |

**Primary projects delivered:**
- Health Clinic Management App (console-based, MS SQL Server + ADO.NET)
- Address Book App (ASP.NET Core WebAPI, MS SQL Server + Entity Framework)
- **Fundoo Notes App** (4-Layer ASP.NET Core WebAPI, Clean Architecture, JWT Authentication, Cloudinary CDN, Pin/Archive/Trash/Search Lifecycle)

**Additional projects delivered:** Greetings App (ASP.NET Core MVC), Contacts App (ASP.NET Core Minimal APIs)

---

## 🗓️ Day-by-Day Log

### Day 1 — DBMS Fundamentals & RDBMS Basics
**Stage:** Data Base (DB Programming)

**Key Concepts:**
- Relational vs Non-Relational DBMS — comparative use cases
- Introduction to MS SQL Server and T-SQL
- Core RDBMS concepts: DDL (Data Definition Language) and DML (Data Manipulation Language)

**Deliverables:**
- Configured local MS SQL Server development environment
- Drafted initial ER Diagram for the Health Clinic App (entities: Patients, Doctors, Appointments)

---

### Day 2 — ER Diagram, Indexing & Normalization
**Stage:** Data Base (DB Programming)

**Key Concepts:**
- ER modeling principles — entities, relationships, cardinality
- Indexing strategy and its impact on query performance
- Normalization theory: 1NF, 2NF, 3NF, BCNF

**Deliverables:**
- Finalized the ER Diagram for the Health Clinic App
- Normalized the Patient / Doctor / Appointment schema to eliminate redundancy

---

### Day 3 — Joins, Stored Procedures & Triggers
**Stage:** Data Base (DB Programming)

**Key Concepts:**
- SQL Joins — Inner, Left, Right, Full Outer
- Stored Procedures — design, creation, and reusability
- Triggers — automated database actions and use cases

**Deliverables:**
- Implemented joins, stored procedures, and triggers against the Health Clinic App schema
- Example: trigger-based auto-update of patient visit history on new appointment records

---

### Day 4 — ADO.NET & Health Clinic App Completion
**Stage:** Data Base (DB Programming)

**Key Concepts:**
- ADO.NET fundamentals — connecting a .NET application to MS SQL Server
- CRUD operations via ADO.NET, mapped to the finalized ER Diagram

**Deliverables — Health Clinic App (Console, MS SQL Server + ADO.NET):**
- Patient registration
- Doctor and specialty management
- Appointment scheduling
- Visit history tracking
- Basic billing module
- Live demo of the completed console-based application

---

### Day 5 — ASP.NET Core, WebAPI & RESTful Services
**Stage:** Backend Basics

**Key Concepts:**
- Introduction to ASP.NET Core and ASP.NET WebAPI
- RESTful service design principles

**Deliverables:**
- Scaffolded a foundational ASP.NET Core WebAPI project

---

### Day 6 — MVC Pattern & REST Request Handling
**Stage:** Backend Basics

**Key Concepts:**
- Model-View-Controller (MVC) architectural pattern
- Consuming REST APIs via C# (Request/Response handling)
- HTTP protocol fundamentals — controllers and routing

**Deliverables:**
- Built the "Greetings App" using ASP.NET Core MVC / WebAPI

---

### Day 7 — Minimal APIs
**Stage:** Backend Basics

**Key Concepts:**
- Minimal APIs in ASP.NET Core — lightweight endpoint definitions without controller overhead

**Deliverables:**
- Initiated development of the Contacts App backend using Minimal APIs

---

### Day 8 — MS SQL Server via ADO.NET Wrapper, Distributed Architectures & SDLC Exposure
**Stage:** Backend Basics

**Key Concepts:**
- Database integration using an ADO.NET wrapper (H2Sharp pattern), implemented against MS SQL Server
- Distributed Architectures — overview and motivation
- API testing fundamentals using Postman
- SDLC (Software Development Life Cycle) exposure

**Deliverables:**
- Continued building out the Contacts App backend, applying concepts introduced in live sessions
- Tested Contacts App endpoints using Postman

---

### Day 9 — ORM & Entity Framework Fundamentals
**Stage:** Backend with Entity Framework

**Key Concepts:**
- ORM (Object-Relational Mapping) concepts and introduction to Entity Framework
- WebAPI-powered REST API development using EF
- Dependency Injection in ASP.NET Core

**Deliverables:**
- Bootstrapped Entity Framework in a new ASP.NET Core WebAPI project
- Continued building the Contacts App backend using EF

---

### Day 10 — MS SQL Server with Entity Framework, C# REST API & LINQ to Entities
**Stage:** Backend with Entity Framework

**Key Concepts:**
- MS SQL Server integration with Entity Framework
- C# REST API design patterns using EF
- LINQ to Entities — querying the database via LINQ

**Deliverables:**
- Wired MS SQL Server into the backend using Entity Framework
- Built the **Address Book App** (ASP.NET Core WebAPI, MS SQL Server + EF), selected from the available project options (Employee Wage App / Address Book App)

---

### Day 11 — Service Layer Architecture, Entity Mapping & Template-Based Data Access
**Stage:** Enterprise Service Design

**Key Concepts:**
- Separation of Concerns: Implementing 4-layer clean architecture (`ModelLayer`, `RepositoryLayer`, `BusinessLayer`, `WebAPI Host`)
- Service-layer business encapsulation and repository design pattern
- Database entity modeling, migrations, and relationship scaffolding

**Deliverables:**
- Scaffolded the multi-tier solution architecture for the enterprise **Fundoo Notes App**
- Implemented core database entities and EF Core Code-First configuration for User schemas

---

### Day 12 — Dependency Injection Scopes, Middleware & Postman Verification
**Stage:** Enterprise Service Design

**Key Concepts:**
- Service lifetimes in ASP.NET Core (Transient, Scoped, Singleton)
- Global exception handling and middleware pipeline configuration
- Comprehensive API testing workflows using Postman environments and collections

**Deliverables:**
- Configured Scoped DI bindings across all 4 layers
- Set up automated API collection testing for foundational user endpoints

---

### Day 13 — Advanced Backend Security: User Management & Authentication Module
**Stage:** Advanced Backend Development

**Key Concepts:**
- Token-based security architecture and JWT (JSON Web Token) standards
- Cryptographic password hashing using BCrypt algorithms
- SMTP integration for asynchronous time-limited password recovery tokens

**Deliverables — Fundoo Notes App (User Management Module):**
- User registration with regex-driven password policy and email uniqueness validation
- User login issuing signed HMAC-SHA256 JWT tokens containing user claims
- Password recovery pipeline (`Forgot Password` & `Reset Password`) via SMTP email dispatch

---

### Day 14 — Authorization Pipeline & Core Notes Management Module
**Stage:** Advanced Backend Development

**Key Concepts:**
- Authentication vs. Authorization — claims extraction (`nameid`, `sub`) and route guard enforcement (`[Authorize]`)
- One-to-Many relational entity design between Users and Notes
- Third-party cloud asset management integration (`IFormFile` multi-part stream handling)

**Deliverables — Fundoo Notes App (Notes Core & Media):**
- Secured notes creation and retrieval endpoints strictly isolated per authenticated user
- Integrated **Cloudinary CDN SDK** for seamless image upload and association with notes
- Full note update and individual note retrieval by ID

---

### Day 15 — Note Organization, Search & Lifecycle Management Modules
**Stage:** Advanced Backend Development

**Key Concepts:**
- Designing organization-oriented REST endpoints (state-based filtering and conditional query executions)
- Search and query design utilizing dynamic LINQ predicates
- Soft delete vs. Hard delete lifecycles (trash bin vs. permanent purge patterns)

**Deliverables — Fundoo Notes App (Organization & Lifecycle):**
- **Pin & Archive Module:** State toggle endpoints with archive segregation and automatic unpin-on-archive logic
- **Search Module:** Case-insensitive search filter across note titles and descriptions
- **Complete Trash Lifecycle:** Soft delete (`Move to Trash`), `Restore Note`, `Trash Bin Listing`, `Delete Forever` (hard delete), and `Empty Trash` (bulk hard delete)

---

## 🧰 Technical Skills Acquired

- **Database Design & Architecture:** ER modeling, normalization (1NF–BCNF), indexing strategies, EF Core Code-First migrations
- **T-SQL & Data Access:** DDL, DML, joins, stored procedures, triggers, ADO.NET, Repository Pattern
- **Backend Frameworks:** ASP.NET Core WebAPI, Minimal APIs, MVC, 4-Project Clean Layered Architecture
- **Security & Identity:** JWT token generation/validation, claims authorization (`[Authorize]`), BCrypt password hashing
- **Cloud & External Services:** Cloudinary Media API integration, SMTP / MailKit email delivery
- **Querying & ORM:** Entity Framework Core, LINQ to Entities, state filtering
- **Testing & Tools:** Swagger UI, Postman, Git version control

---

## 📂 Projects Summary

| Project | Type | Stack | Status |
|---|---|---|---|
| Health Clinic App | Console Application | MS SQL Server, ADO.NET, C# | ✅ Completed |
| Greetings App | Web Application | ASP.NET Core MVC / WebAPI | ✅ Completed |
| Contacts App | Backend API | ASP.NET Core Minimal APIs, MS SQL Server, Postman (testing) | ✅ Completed |
| Address Book App | Backend API | ASP.NET Core WebAPI, MS SQL Server, Entity Framework, LINQ | ✅ Completed |
| **Fundoo Notes App** | Enterprise Web API | ASP.NET Core, EF Core, JWT, BCrypt, Cloudinary, SQL Server | ✅ Day 15 Milestone Completed |

---