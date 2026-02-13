# 📌 NotifyHub – Concurrent Notification Processing System

## 📖 Introduction

**NotifyHub** is a console-based concurrent notification processing system built using **C# and .NET 6+**.  
It demonstrates advanced concepts including multithreading, asynchronous programming, concurrent collections, clean architecture, and core object-oriented design principles.

The system allows users to create notifications (Email, SMS, App Alert) which are processed concurrently using priority-based scheduling.

---

## 🚀 Key Objectives

- Implement concurrent notification processing using modern .NET practices  
- Ensure priority-based execution using a queueing mechanism  
- Maintain system responsiveness under high load  
- Apply clean architecture and OOP best practices  
- Implement safe failure handling without interrupting system flow  

---

## 🏗 Project Structure

```
NotifyHub/
│
├── Program.cs
├── NotificationMain.cs
├── NotificationMenu.cs
├── INotificationService.cs
├── NotificationServiceImplementation.cs
├── Notification.cs
├── NotificationValidator.cs
├── NotificationRecipientAttribute.cs
├── NotificationSenderFactory.cs
├── INotificationSender.cs
├── Senders/
│     ├── EmailSender.cs
│     ├── SmsSender.cs
│     └── AppAlertSender.cs
└── README.md
```

---

## ⚙️ Core Features

### 1️⃣ Multiple Notification Types

- Email  
- SMS  
- App Alert  

Each type is processed dynamically using the Strategy pattern.

---

### 2️⃣ Model Validation (Using Custom Attributes)

Validation rules are implemented directly within the model using **DataAnnotations** and custom attributes:

- Notification ID → Required  
- Recipient → Format validation based on type:
  - Email → Valid email format  
  - SMS → 10-digit numeric format  
  - App Alert → Must end with `.appalert`  
- Message → Required  

This ensures strong input validation before processing.

---

### 3️⃣ Priority-Based Processing

Notifications are stored using the built-in `PriorityQueue<TElement, TPriority>`.

| Priority | Internal Value |
|----------|---------------|
| High     | 1 |
| Medium   | 2 |
| Low      | 3 |

Lower numeric value = higher processing priority.

---

### 4️⃣ Concurrent Processing Architecture

- Multiple background worker tasks  
- Implemented using `Task` and `async/await`  
- Non-blocking intake mechanism  
- Thread-safe tracking using `ConcurrentDictionary`  
- Queue synchronization using `lock`  

This ensures multiple notifications are processed simultaneously without affecting system responsiveness.

---

### 5️⃣ Robust Failure Handling

- Each notification is processed independently  
- Failures do not interrupt other tasks  
- Status lifecycle tracking:

  - Pending  
  - Processing  
  - Sent  
  - Failed  

This improves reliability and fault tolerance.

---

## 🧠 System Architecture

The system follows a layered architecture design:

### 🔹 1. Presentation Layer
- Console UI
- Menu interaction
- User input handling

### 🔹 2. Service Layer
- Business logic
- Priority queue management
- Worker lifecycle management

### 🔹 3. Strategy & Factory Layer
- `INotificationSender` abstraction
- Concrete sender implementations
- `NotificationSenderFactory` for dynamic selection

### 🔹 4. Model & Validation Layer
- Domain models
- DataAnnotations
- Custom recipient validation attribute

---

## 🧵 Concurrency Model Overview

| Component | Purpose |
|-----------|----------|
| `PriorityQueue` | Maintains processing order |
| `ConcurrentDictionary` | Thread-safe state tracking |
| `Task.Run()` | Background workers |
| `async/await` | Non-blocking execution |
| `lock` | Critical section protection |

This hybrid model ensures both performance and thread safety.

---

## 🏛 Object-Oriented Principles Demonstrated

- Encapsulation  
- Abstraction  
- Inheritance  
- Polymorphism  
- Strategy Pattern  
- Factory Pattern  
- Open/Closed Principle  
- Separation of Concerns  

---

## 🖥️ Installation & Setup

### Prerequisites

- .NET 6 SDK or higher  
- Visual Studio 2022 / VS Code  

### Steps to Run

1. Clone or download the repository  
2. Open the solution in your IDE  
3. Build the project  
4. Run the console application  

```bash
dotnet build
dotnet run
```

---

## 🧪 Application Flow

```
1. Add Notification
2. View All Notifications
3. Exit
```

### Execution Steps:

1. User adds notification via menu  
2. System validates input  
3. Notification enters priority queue  
4. Background workers process asynchronously  
5. Status updates in real-time  

---

## 🧰 Technologies Used

- C#  
- .NET 6+  
- Collections Framework  
- Multithreading  
- Asynchronous Programming  
- DataAnnotations  
- Custom Validation Attributes  

---

## 📈 Scalability Considerations

- Asynchronous non-blocking architecture  
- Independent task processing  
- Thread-safe collections  
- Priority-based scheduling  

The system can scale to handle increasing notification volumes without degrading user experience.

---

## 🎓 Academic & Concept Coverage

This project demonstrates:

- Core & Advanced OOP  
- Concurrent Programming  
- Async/Await Pattern  
- Thread Safety & Synchronization  
- Collections Framework  
- Custom Attributes  
- Exception Handling  
- Design Patterns Implementation  

---

# 🏁 Final Summary

**NotifyHub** is a well-architected, scalable, and concurrent notification processing system built using modern .NET practices.  
It effectively demonstrates real-world concurrency handling, priority scheduling, and dynamic behavior selection while maintaining clean architecture principles.
