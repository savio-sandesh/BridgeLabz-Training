# 📘 .NET Full-Stack Developer — Refresher Program Log

**Duration:** Day 1 – Day 10
**Track:** Database Programming → Backend Development (ASP.NET Core) → Backend with Entity Framework
**Stack:** MS SQL Server, T-SQL, ADO.NET, ASP.NET Core, WebAPI, MVC, Minimal APIs, Entity Framework, LINQ, Postman, C#
**Repository:** [BridgeLabz-Training (Refresher-Training branch)](https://github.com/savio-sandesh/BridgeLabz-Training/tree/Refresher-Training/Refresher-Training)

---

## 📌 Overview

This log documents the technical topics covered and hands-on deliverables completed during a 7-day refresher program focused on core **database programming** and **.NET backend development** fundamentals. The program was structured in two stages:

| Stage | Days | Focus Area |
|-------|------|------------|
| Stage 1 | Day 1 – Day 4 | Database (DB) Programming — MS SQL Server, T-SQL, ADO.NET |
| Stage 2 | Day 5 – Day 8 | Backend Basics — ASP.NET Core, WebAPI, MVC, Minimal APIs, Distributed Architectures, SDLC |
| Stage 3 | Day 9 – Day 10 | Backend with Entity Framework — ORM, EF Core, LINQ to Entities |

**Primary projects delivered:**
- Health Clinic Management App (console-based, MS SQL Server + ADO.NET)
- Address Book App (ASP.NET Core WebAPI, MS SQL Server + Entity Framework)

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

## 🧰 Technical Skills Acquired

- **Database Design:** ER modeling, normalization (1NF–BCNF), indexing strategy
- **T-SQL:** DDL, DML, joins, stored procedures, triggers
- **Data Access:** ADO.NET, CRUD operations, connection management
- **Backend Development:** ASP.NET Core, WebAPI, Minimal APIs, MVC architecture, Dependency Injection
- **ORM & Data Access:** Entity Framework, LINQ to Entities
- **API Design:** RESTful principles, HTTP protocol, routing, controllers
- **API Testing:** Postman
- **Architecture & Process:** Distributed architecture concepts, SDLC exposure

---

## 📂 Projects Summary

| Project | Type | Stack | Status |
|---------|------|-------|--------|
| Health Clinic App | Console Application | MS SQL Server, ADO.NET, C# | ✅ Completed |
| Greetings App | Web Application | ASP.NET Core MVC / WebAPI | ✅ Completed |
| Contacts App | Backend API | ASP.NET Core Minimal APIs, MS SQL Server, Postman (testing) | ✅ Completed |
| Address Book App | Backend API | ASP.NET Core WebAPI, MS SQL Server, Entity Framework, LINQ | ✅ Completed |

---
