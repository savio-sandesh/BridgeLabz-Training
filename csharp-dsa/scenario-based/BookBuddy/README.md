# 📚 BookBuddy – Digital Bookshelf Application

## 📌 Project Overview

**BookBuddy** is a console-based C# application that allows users to maintain a personal digital bookshelf.  
Users can add books, view all books, search books by author, and sort books alphabetically.

The project is designed strictly following **Object-Oriented Programming (OOPS)** principles and a **trainer-approved folder structure**, using **arrays instead of collections** and **without exception handling**, as per training guidelines.

---

## 🎯 Features

- Add a book with title and author
- Display all stored books
- Search books by author name
- Sort books alphabetically using **Bubble Sort**
- Menu-driven console interface
- Input validation to avoid garbage values

---

## 🛠️ Technologies Used

- **Language:** C#
- **Framework:** .NET Console Application
- **IDE:** Visual Studio

---

## 📂 Project Structure (Trainer Approved)

``` text
BookBuddy/
│
├── Program.cs
│ Entry point of the application
│
├── BookMain.cs
│ Controls application flow and coordination
│
├── BookMenu.cs
│ Handles menu display and user choice (no logic)
│
├── IBookManager.cs
│ Public interface defining book operations
│
├── BookUtility.cs
│ Contains all business logic (add, search, sort, display)
│
├── Book.cs
│ Encapsulated model class (fields with getters/setters only)

```

---

## 🧩 OOPS Concepts Used

| OOPS Concept | Implementation |
|--------------|----------------|
Encapsulation  | `Book` class with properties |
Interface      | `IBookManager` |
Abstraction    | Logic accessed through interface |
Polymorphism   | Interface reference used in `BookMain` |

---

## 📐 Class Responsibilities

### 🔹 `Book`
- Encapsulated model class
- Stores `Title` and `Author`
- Contains only properties (no logic)

---

### 🔹 `IBookManager`
- Public interface
- Defines operations like:
  - AddBook
  - DisplayBooks
  - SearchByAuthor
  - SortBooksAlphabetically

---

### 🔹 `BookUtility`
- Implements `IBookManager`
- Contains all application logic
- Uses arrays to store books
- Implements **Bubble Sort**
- Handles validation using conditional statements

---

### 🔹 `BookMenu`
- Displays menu options
- Takes user choice
- Contains **no business logic**

---

### 🔹 `BookMain`
- Controls program flow
- Invokes menu and utility methods
- Acts as coordinator between components

---

### 🔹 `Program`
- Contains the `Main()` method
- Entry point of the application
- Starts execution by calling `BookMain`

---

## ▶️ How to Run the Project

1. Open **Visual Studio**
2. Create a **Console App (.NET)**
3. Add all the project files as per the structure
4. Build the solution
5. Run the program
6. Use menu options to interact with BookBuddy

---

## 🧪 Sample Output
``` text
BookBuddy – Digital Bookshelf

Add Book

Display All Books

Search Book by Author

Sort Books Alphabetically

Exit
Enter your choice: 1

Enter book title: Clean Code
Enter author name: Robert Martin
Book added successfully.
```