# 🚀 NotifyHub  
### Concurrent Notification Processing System (.NET 6)

![.NET](https://img.shields.io/badge/.NET-6.0+-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-Programming-239120?logo=c-sharp)
![Concurrency](https://img.shields.io/badge/Architecture-Concurrent-blue)
![Status](https://img.shields.io/badge/Project-Academic%20%7C%20Portfolio-success)

---

## 📖 Overview

**NotifyHub** is a high-performance, console-based concurrent notification processing system built using **C# and .NET 6+**.

It demonstrates real-world backend engineering concepts including:

- Asynchronous programming (`async/await`)
- Multithreading with task-based concurrency
- Priority-based workload scheduling
- Thread-safe collections
- Clean architecture principles
- SOLID design patterns

The system enables users to create and process notifications (Email, SMS, App Alert) concurrently, ensuring responsiveness even under heavy load.

---

## ✨ Key Highlights

- ⚡ Non-blocking asynchronous processing
- 🎯 Priority-based scheduling using `PriorityQueue`
- 🔒 Thread-safe state tracking with `ConcurrentDictionary`
- 🧠 Strategy & Factory design patterns
- 🧩 Clean layered architecture
- 🛡 Robust failure isolation per task

---

## 🏗 Architecture Overview

NotifyHub follows a layered and extensible architecture:

```
Presentation Layer
    ↓
Service Layer (Business Logic + Queue Management)
    ↓
Strategy Layer (Sender Abstraction)
    ↓
Model & Validation Layer
```

### 🔹 Presentation Layer
Handles console UI and user interaction.

### 🔹 Service Layer
Manages:
- Notification lifecycle
- Worker task orchestration
- Priority queue processing
- Concurrency coordination

### 🔹 Strategy & Factory Layer
- `INotificationSender` abstraction
- Concrete sender implementations
- `NotificationSenderFactory` for runtime resolution

### 🔹 Model & Validation Layer
- Domain models
- DataAnnotations
- Custom recipient validation attributes

---

## 📂 Project Structure

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

### 1️⃣ Multi-Channel Notifications

- 📧 Email  
- 📱 SMS  
- 🔔 App Alert  

Each channel is dynamically selected using the Strategy Pattern.

---

### 2️⃣ Priority-Based Processing

Uses `.NET` built-in:

```
PriorityQueue<TElement, TPriority>
```

| Priority | Value |
|----------|-------|
| High     | 1 |
| Medium   | 2 |
| Low      | 3 |

Lower value = Higher processing priority.

---

### 3️⃣ Concurrent Worker Model

- Background worker tasks created via `Task.Run()`
- Non-blocking processing using `async/await`
- Thread synchronization using `lock`
- Thread-safe notification tracking via `ConcurrentDictionary`

✔ Intake operations never block processing  
✔ Multiple notifications processed simultaneously  

---

### 4️⃣ Validation & Data Integrity

Validation implemented using:

- `System.ComponentModel.DataAnnotations`
- Custom `NotificationRecipientAttribute`

Rules enforced:

- ID → Required  
- Message → Required  
- Recipient → Format-specific validation:
  - Email → Valid email format
  - SMS → 10-digit number
  - App Alert → Ends with `.appalert`

---

### 5️⃣ Fault Tolerance & Status Tracking

Each notification is processed independently.

Lifecycle states:

- Pending
- Processing
- Sent
- Failed

Failures in one task do **not** impact others.

---

## 🧵 Concurrency Design

| Component | Purpose |
|-----------|----------|
| `PriorityQueue` | Maintains execution order |
| `ConcurrentDictionary` | Thread-safe state storage |
| `Task` | Worker execution |
| `async/await` | Non-blocking IO simulation |
| `lock` | Critical section protection |

This hybrid model balances safety and performance.

---

## 🏛 Design Principles Applied

- ✅ Encapsulation  
- ✅ Abstraction  
- ✅ Inheritance  
- ✅ Polymorphism  
- ✅ Strategy Pattern  
- ✅ Factory Pattern  
- ✅ Open/Closed Principle  
- ✅ Separation of Concerns  
- ✅ Single Responsibility Principle  

---

## 🖥 Installation & Execution

### 🔧 Prerequisites

- .NET 6 SDK or later  
- Visual Studio 2022 / VS Code  

### ▶ Run the Application

```bash
git clone <repository-url>
cd NotifyHub
dotnet build
dotnet run
```

---

## 🧪 Sample Execution Flow

```
1. Add Notification
2. View All Notifications
3. Exit
```

1. User creates notification  
2. Model validation executed  
3. Added to priority queue  
4. Background workers process asynchronously  
5. Status updated in real-time  

---

## 📈 Scalability Considerations

NotifyHub is designed with scalability in mind:

- Non-blocking asynchronous processing
- Independent task lifecycle
- Thread-safe collections
- Priority scheduling
- Extensible sender architecture

Future improvements can easily integrate:

- Database persistence
- Distributed queue systems
- REST API layer
- Configurable worker pool sizing

---

## 🛠 Technology Stack

- C#
- .NET 6+
- Task-based Asynchronous Pattern (TAP)
- Collections Framework
- Concurrent Collections
- DataAnnotations
- Custom Attributes

---

# 🏁 Final Thoughts
NotifyHub demonstrates how  .NET applications can leverage asynchronous programming and concurrent collections to build responsive, scalable backend systems.

It reflects strong understanding of:

- Concurrency management
- Clean architecture
- Design patterns
- Real-world system reliability
- Production-oriented coding practices
