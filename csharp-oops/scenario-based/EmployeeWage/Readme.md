# Employee Wage Computation Program

## 📌 Overview

The **Employee Wage Computation Program** is a console-based application developed in **C#** using **Object-Oriented Programming (OOP)** principles.  
The application simulates employee wage calculations based on attendance, employee type, working days, and working hour constraints.

This project is implemented step by step using clearly defined **Use Cases (UC-1 to UC-6)**, following the official BridgeLabz problem statement and best coding practices.

---

## 🎯 Purpose of the Project

- Understand and apply **OOP concepts in C#**
- Use **interfaces** to define business contracts
- Implement logic incrementally using **use cases**
- Build a **menu-driven console application**
- Maintain **clean and meaningful Git commit history**

---

## 🛠️ Technologies Used

- **Programming Language:** C#
- **Framework:** .NET (Console Application)
- **IDE:** Visual Studio
- **Version Control:** Git & GitHub

---

## 📁 Project Structure

``` text
EmployeeWage/
│
├── Program.cs // Entry point of the application
├── EmployeeMain.cs // Starts the application flow
├── EmployeeMenu.cs // Menu & switch-case (UC-4)
├── IEmployee.cs // Interface defining employee operations
├── EmployeeUtilityImplementation.cs // Business logic (UC-1 to UC-6)
├── Employee.cs // Employee model class
└── README.md // Project documentation

```


---

## ✅ Implemented Use Cases

### 🔹 UC-1: Employee Attendance Check
- Randomly determines whether an employee is **Present** or **Absent**

### 🔹 UC-2: Daily Wage Calculation
- Calculates daily wage based on attendance
- Assumptions:
  - Wage per hour = 20
  - Full-time working hours = 8

### 🔹 UC-3: Wage Based on Employee Type
- Calculates wage depending on employee type:
  - Full-time employee → 8 hours
  - Part-time employee → 4 hours
  - Absent employee → 0 hours

### 🔹 UC-4: Menu-Driven Execution Using Switch Case
- Allows users to select different use cases through a console menu
- Implemented using `switch-case` for better control flow

### 🔹 UC-5: Monthly Wage Calculation
- Calculates total wage for **20 working days**
- Uses daily wage logic repeatedly

### 🔹 UC-6: Wage Calculation with Constraints
- Calculates wage until either condition is met:
  - Maximum working days = 20
  - Maximum working hours = 100
- Ensures controlled wage computation

---

``` text --- Employee Wage Computation ---
1. UC1 - Check Attendance
2. UC2 - Calculate Daily Wage
3. UC3 - Part Time Employee Wage
4. UC5 - Calculate Monthly Wage (20 Days)
5. UC6 - Wage with Max Hour & Day Limit
0. Exit

```
