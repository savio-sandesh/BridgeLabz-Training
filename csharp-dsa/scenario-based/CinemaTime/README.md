# 🎬 CinemaTime – Movie Schedule Manager

## 📌 Project Overview

**CinemaTime** is a console-based C# application designed to manage movie schedules for a cinema.  
It allows users to add movies with showtimes, view all scheduled movies, search movies by keyword, and generate a printable report.

The project is implemented using **core Object-Oriented Programming (OOPS)** concepts such as **Encapsulation**, **Interface**, **Abstraction**, and **Polymorphism**, while deliberately using **arrays instead of collections** to match training-level requirements.

---

## 🎯 Features

- Add movie titles with showtimes  
- Validate showtime format (`HH:MM`)  
- Display all movies  
- Search movies using keyword (`Contains`)  
- Generate printable movie report  
- Menu-driven console interface  

---

## 🛠️ Technologies Used

- **Language:** C#  
- **Platform:** .NET Console Application  
- **IDE:** Visual Studio  

---

## 📂 Project Structure

``` text
CinemaTime/
│
├── IMovieManager.cs
├── MovieScheduleManager.cs
└── Program.cs
```


---

## 🧩 OOPS Concepts Used

| OOPS Concept | Implementation |
|--------------|----------------|
Encapsulation  | Private arrays with public methods |
Interface      | `IMovieManager` |
Abstraction    | Interface defines movie operations |
Polymorphism   | Interface reference used in `Main()` |
Inheritance    | `MovieScheduleManager` implements `IMovieManager` |
Arrays         | Used instead of List for data storage |

---

## 📐 Design Description

### 🔹 Interface: `IMovieManager`
Defines the contract for movie management operations:
- `AddMovie`
- `SearchMovie`
- `DisplayMovies`
- `GenerateReport`

---

### 🔹 Class: `MovieScheduleManager`
- Implements `IMovieManager`
- Contains all business logic
- Stores movie titles and showtimes using **arrays**
- Applies **encapsulation** by keeping data members private

---

### 🔹 Class: `Program`
- Contains the `Main()` method
- Provides a menu-driven interface
- Interacts with the system using the interface reference

---

## ▶️ How to Run the Project

1. Open **Visual Studio**
2. Create a **Console App (.NET)**
3. Add the following files:
   - `IMovieManager.cs`
   - `MovieScheduleManager.cs`
   - `Program.cs`
4. Build and run the project
5. Use the menu options to interact with the application

---

## 🧪 Sample Output

``` text 
CinemaTime – Movie Schedule Manager

1.Add Movie
2.Display All Movies
3.Search Movie
4.Generate Report
5.Exit
Enter your choice: 1
Enter movie title: Avengers
Enter showtime (HH:MM): 18:30
Movie Added Successfully
```