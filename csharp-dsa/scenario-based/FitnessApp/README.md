# FitnessaApp – Daily Step Count Ranking (Bubble Sort)

## 📌 Project Overview

**FitnessTracker** is a console-based C# application designed using **Object-Oriented Programming (OOP) principles**.
The application tracks daily step counts of users in a **small fitness group** and displays a **leaderboard** ranked by steps taken.

Since the dataset is small and frequently updated, the application uses the **Bubble Sort algorithm**, which is simple, efficient, and suitable for real-time re-sorting in such scenarios.

---

## 🎯 Problem Statement

A fitness application tracks the daily steps of fewer than 20 users.
At the end of the day, users are ranked based on their step counts.
Because step data can change frequently due to last-minute syncing, a **simple sorting approach** is preferred.

---

## 🧠 Concepts Applied

* Object-Oriented Programming (OOP)

  * Encapsulation
  * Abstraction
  * Interfaces
  * Separation of Concerns
* Bubble Sort Algorithm
* Array-based data storage (No collections used)
* Menu-driven console application

---

## 🗂️ Project Structure

```
FitnessApp/
│
├── Program.cs
│   Entry point of the application
│
├── FitnessMain.cs
│   Controls application flow and coordination
│
├── FitnessMenu.cs
│   Displays menu options and accepts user input
│
├── IFitnessManager.cs
│   Interface defining fitness-related operations
│
├── FitnessUtility.cs
│   Business logic and Bubble Sort implementation
│
├── User.cs
│   Model class encapsulating user data
│
├── README.md
│   Project documentation
```

---

## 🧩 Class Responsibilities

### Program.cs

* Entry point of the application
* Starts execution by invoking `FitnessMain`

---

### FitnessMain.cs

* Acts as the controller
* Manages application flow
* Connects menu and business logic using an interface

---

### FitnessMenu.cs

* Displays menu options
* Accepts user input
* Contains no business logic

---

### IFitnessManager.cs

* Defines abstraction for fitness operations:

  * AddUser()
  * DisplayUsers()
  * SortUsersBySteps()

---

### FitnessUtility.cs

* Implements `IFitnessManager`
* Stores users in an array
* Implements **Bubble Sort** to rank users by step count
* Handles all business logic

---

### User.cs

* Model / entity class
* Encapsulates user name and daily step count
* Uses private fields with public getters and setters
* Contains no logic

---

## ⚙️ Features

* Add user daily step counts
* Display all users with step data
* Rank users by steps (High → Low)
* Real-time re-sorting using Bubble Sort
* Clean, menu-driven interface

---

## 🔢 Algorithm Used – Bubble Sort

* Suitable for small datasets
* Simple and easy to implement
* Performs efficiently for fewer than 20 users

**Time Complexity:**

* Worst Case: O(n²)
* Best Case (nearly sorted): O(n)

---

## 🚀 How to Run the Application

1. Open the project in **Visual Studio** or **VS Code**
2. Build the solution
3. Run the application
4. Use the menu to:

   * Add users
   * Display rankings
   * Sort by daily steps

---

## 🧪 Sample Output

```
Fitness Tracker Menu:
1. Add User Step Count
2. Display Daily Rankings
3. Sort Users by Steps
4. Exit
Enter your choice: 1

Enter User Name: Sandesh Yadav
Enter Daily Steps: 10000
User added successfully.

Fitness Tracker Menu:
1. Add User Step Count
2. Display Daily Rankings
3. Sort Users by Steps
4. Exit
Enter your choice: 1

Enter User Name: Sahil Kumar
Enter Daily Steps: 12000
User added successfully.

Fitness Tracker Menu:
1. Add User Step Count
2. Display Daily Rankings
3. Sort Users by Steps
4. Exit
Enter your choice: 2

Daily Step Rankings:
User Name: Sandesh Yadav
Steps: 10000
---------------------------
User Name: Sahil Kumar
Steps: 12000
---------------------------
Fitness Tracker Menu:
1. Add User Step Count
2. Display Daily Rankings
3. Sort Users by Steps
4. Exit
Enter your choice: 3

Users sorted by steps (High to Low).

Fitness Tracker Menu:
1. Add User Step Count
2. Display Daily Rankings
3. Sort Users by Steps
4. Exit
Enter your choice: 2

Daily Step Rankings:
User Name: Sahil Kumar
Steps: 12000
---------------------------
User Name: Sandesh Yadav
Steps: 10000
---------------------------
Fitness Tracker Menu:
1. Add User Step Count
2. Display Daily Rankings
3. Sort Users by Steps
4. Exit
Enter your choice:
```

---

## 📌 Note

This project is intended for **Learning purposes**, focusing on algorithm understanding and object-oriented design rather than advanced libraries.
