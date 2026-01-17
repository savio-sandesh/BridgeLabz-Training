# BookShelf – Library Organization System (HashMap & LinkedList)

## 📌 Project Overview

**BookShelf** is a console-based C# application developed using **Data Structures and Algorithms (DSA)**, **Object-Oriented Programming (OOP)**, and **Core C#** concepts.
The application simulates a **library organization system**, where books are arranged **genre-wise** and managed efficiently as they are borrowed or returned.

* Each genre is mapped using a **HashMap (Dictionary)**
* Books under each genre are stored in a **LinkedList**
* Duplicate book entries are optionally prevented using a **HashSet**

This design ensures **efficient insertion, deletion, and retrieval** of books.

---

## 🎯 Problem Statement

In a library system:

* Books are organized based on **genre and author**
* Each genre maintains a dynamic list of books
* Books may be borrowed or returned frequently

The system must:

* Maintain a **genre-wise catalog**
* Support **efficient insert and delete operations**
* Optionally avoid duplicate book entries

---

## 🧠 Concepts Applied

* **Data Structures**

  * HashMap (`Dictionary`)
  * LinkedList
  * HashSet (for duplicate prevention)
* **Object-Oriented Programming**

  * Encapsulation
  * Abstraction
  * Interfaces
  * Separation of Concerns
* **Core C#**
* Menu-driven console application

---

## 🗂️ Project Structure

```
BookShelf/
│
├── Program.cs
│   Entry point of the application
│
├── BookShelfMain.cs
│   Controls application flow and coordination
│
├── BookShelfMenu.cs
│   Displays menu options and accepts user input
│
├── IBookShelfManager.cs
│   Interface defining bookshelf operations
│
├── BookShelfUtility.cs
│   Business logic using Dictionary, LinkedList, and HashSet
│
├── Book.cs
│   Model class representing a book
│
├── README.md
│   Project documentation
```

---

## 🧩 Class Responsibilities

### Program.cs

* Entry point of the application
* Starts execution by invoking `BookShelfMain`

---

### BookShelfMain.cs

* Acts as the controller
* Manages application flow
* Connects menu and business logic using an interface

---

### BookShelfMenu.cs

* Displays menu options
* Accepts user input
* Contains no business logic

---

### IBookShelfManager.cs

* Defines abstraction for bookshelf operations:

  * AddBook()
  * RemoveBook()
  * DisplayBooksByGenre()
  * DisplayAllBooks()

---

### BookShelfUtility.cs

* Implements `IBookShelfManager`
* Uses:

  * **Dictionary** to map genres to books
  * **LinkedList** for efficient insert and delete operations
  * **HashSet** to prevent duplicate entries (optional)
* Contains all business logic

---

### Book.cs

* Model / entity class
* Encapsulates book details:

  * Title
  * Author
  * Genre
* Uses private fields with public getters and setters
* Contains no business logic

---

## ⚙️ Features

* Add books to the library catalog
* Remove books from a specific genre
* Display books by genre
* Display all books grouped by genre
* Prevent duplicate book entries
* Clean, menu-driven console interface

---

## 🔢 Data Structures Used

### HashMap (Dictionary)

* Maps **Genre → LinkedList of Books**
* Enables fast lookup of genre-wise collections

### LinkedList

* Stores books under each genre
* Allows efficient insertion and deletion

### HashSet (Optional)

* Prevents duplicate book entries
* Ensures data integrity

---

## 🚀 How to Run the Application

1. Open the project in **Visual Studio** or **VS Code**
2. Build the solution
3. Run the application
4. Use the menu to:

   * Add books
   * Remove books
   * View books by genre
   * View entire catalog

---

## 🧪 Sample Output

```
===== BookShelf Menu =====
1. Add Book
2. Remove Book
3. Display Books by Genre
4. Display All Books
5. Exit
Enter your choice: 1

Enter Book Title: Truth Without Apology
Enter Author Name: Prashant Tripathi
Enter Genre: Philosophy
Book added successfully.

===== BookShelf Menu =====
1. Add Book
2. Remove Book
3. Display Books by Genre
4. Display All Books
5. Exit
Enter your choice: 1

Enter Book Title: Dopamine Detox
Enter Author Name: Andrew 
Enter Genre: Self Help
Book added successfully.

===== BookShelf Menu =====
1. Add Book
2. Remove Book
3. Display Books by Genre
4. Display All Books
5. Exit
Enter your choice: 1

Enter Book Title: Let Us C#
Enter Author Name: Savio
Enter Genre: Academia
Book added successfully.

===== BookShelf Menu =====
1. Add Book
2. Remove Book
3. Display Books by Genre
4. Display All Books
5. Exit
Enter your choice: 3

Enter Genre: Academia
Books in Genre: Academia
Title: Let Us C#, Author: Savio

===== BookShelf Menu =====
1. Add Book
2. Remove Book
3. Display Books by Genre
4. Display All Books
5. Exit
Enter your choice: 4

Genre: Philosophy
  Title: Truth Without Apology, Author: Prashant Tripathi

Genre: Self Help
  Title: Dopamine Detox, Author: Andrew

Genre: Academia
  Title: Let Us C#, Author: Savio

===== BookShelf Menu =====
1. Add Book
2. Remove Book
3. Display Books by Genre
4. Display All Books
5. Exit
Enter your choice:
```

