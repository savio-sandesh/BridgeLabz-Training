# 🧭 BrowserBuddy – Tab History Manager

## 📖 Introduction
**BrowserBuddy** is a console-based browser simulation project developed using **C#** and core **Object-Oriented Programming (OOP)** principles.  
The application demonstrates how modern browsers manage tabs and navigation history using fundamental **data structures**, without relying on advanced collections.

This project is **beginner-friendly**, **syllabus-aligned**, and ideal for students learning OOP and data structures through practical implementation.

---

## 📑 Table of Contents
- [Project Overview](#-project-overview)
- [Features](#-features)
- [Concepts Used](#-concepts-used)
- [Project Structure](#-project-structure)
- [OOP Principles Applied](#-oop-principles-applied)
- [Data Structure Usage](#-data-structure-usage)
- [How to Run the Project](#-how-to-run-the-project)
- [Sample Execution Flow](#-sample-execution-flow)
- [Future Enhancements](#-future-enhancements)

---

## 📌 Project Overview
BrowserBuddy simulates a basic web browser that supports:
- Multiple tabs
- Page navigation (Back / Forward)
- Page history management
- Restoration of recently closed pages

The project intentionally avoids built-in collections to reinforce understanding of **manual data structure implementation**.

---

## 🎯 Features
- Open and close multiple browser tabs
- Visit web pages within a tab
- Navigate **Back** and **Forward** through page history
- Restore recently closed pages
- View the current active tab and page
- Display complete browsing history for the active tab
- Menu-driven console interface

---

## 🧠 Concepts Used

### Object-Oriented Programming
- Encapsulation
- Abstraction
- Interface-based design

### Data Structures
- Doubly Linked List
- Stack (Array-based implementation)

### Application Design
- Menu-driven console application
- Separation of concerns
- Modular architecture

---

## 🏗️ Project Structure
``` text
BrowserBuddy/
│
├── Program.cs // Application entry point
├── BrowserMain.cs // Controls overall application flow
├── BrowserMenu.cs // Displays menu options
├── IBrowser.cs // Interface for abstraction
├── BrowserUtility.cs // Core business logic
├── Tab.cs // Encapsulated tab model
├── HistoryManager.cs // Doubly Linked List + Stack logic
└── README.md // Project documentation

``` 

---

## 🔐 OOP Principles Applied

### 1️⃣ Encapsulation
- Implemented in `Tab.cs`
- Tab details are stored using private fields and public properties
- Internal data is protected from direct external access

### 2️⃣ Abstraction
- Achieved using the `IBrowser` interface
- Defines browser operations without exposing implementation details

---

## 📚 Data Structure Usage

### 🔁 Doubly Linked List
- Implemented in `HistoryManager`
- Enables efficient **Back** and **Forward** navigation
- Maintains previous and next page references

### 📦 Stack (Array-Based)
- Stores recently closed pages
- Follows **LIFO (Last In, First Out)** principle
- Implemented manually without using collections

---

## ▶️ How to Run the Project
1. Open the project in **Visual Studio**
2. Build the solution
3. Run the application
4. Follow the menu options displayed in the console

---

## 🧪 Sample Execution Flow
```
1 → Open New Tab
2 → Visit Page (google.com)
2 → Visit Page (youtube.com)
3 → Back
7 → Show Current Status
8 → Show Page History
0 → Exit
```


---

## 🙌 Contributors
- Developed by **Sandesh Yadav**
