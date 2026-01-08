# Employee Wage Computation Program

## 📌 Overview

The **Employee Wage Computation Program** is a console-based application developed in **C#** using **Object-Oriented Programming (OOP)** principles.  
The application simulates real-world employee wage computation by considering employee attendance, working hours, working days, and system-defined constraints.

The project is implemented incrementally using **Use Cases (UC-1 to UC-6)** and follows clean design practices such as **abstraction, encapsulation, and separation of concerns**.

---

## 🎯 Objectives of the Project

- Apply **Object-Oriented Programming concepts** in C#
- Use **interfaces** to define business contracts
- Implement use cases step by step
- Build a **menu-driven console application**
- Handle **multiple employees** with clear selection flow
- Maintain a **clean Git commit history**

---

## 🛠️ Technologies Used

- **Language:** C#
- **Framework:** .NET (Console Application)
- **IDE:** Visual Studio
- **Version Control:** Git & GitHub

---

## 📁 Project Structure

``` text
EmployeeWage/
│
├── Program.cs // Entry point of the application
├── EmployeeMain.cs // Controls application flow & employee selection
├── EmployeeMenu.cs // Menu handling using switch-case (UC-4)
├── IEmployee.cs // Interface defining employee wage operations
├── EmployeeUtilityImplementation.cs// Business logic for UC-1 to UC-6
├── Employee.cs // Employee model (ID, Name, Role, Department)
└── README.md // Project documentation
```


---


---

## 👥 Application Flow (High Level)

1. Application starts from `Program.cs`
2. User enters **number of employees**
3. User provides employee details:
   - Employee ID
   - Name
   - Role
   - Department
4. All employees are stored in a `List<Employee>`
5. User selects **one employee** to work with
6. A **menu-driven system** is displayed for wage computation
7. User can:
   - Perform wage-related operations
   - Change the selected employee
   - Exit the application

---

## ✅ Implemented Use Cases

### 🔹 UC-1: Employee Attendance Check
- Attendance is determined **randomly** (Present / Absent)
- Attendance is checked **only once per employee session**
- The result is stored and reused across all wage calculations

If the employee is **Absent**:
- Wage-related use cases are disabled
- User can only **change employee** or **exit**

---

### 🔹 UC-2: Daily Wage Calculation
- Executed **only if employee is present**
- User enters **working hours for the day**
- Daily wage is calculated as:
``` text
- Daily Wage = Working Hours × Wage Per Hour
```


(Default wage per hour = 20)

---

### 🔹 UC-3: Wage Based on Employee Type
- Employee type is decided based on working hours:
  - **≥ 8 hours → Full-Time**
  - **< 8 hours → Part-Time**
- Wage is calculated using user-entered working hours

---

### 🔹 UC-4: Menu-Driven Execution (Switch Case)
- Implemented in `EmployeeMenu.cs`
- Uses `switch-case` to execute different use cases
- Menu options are **dynamic**:
  - Attendance option appears only once
  - Wage options appear only if employee is present

---

### 🔹 UC-5: Monthly Wage Calculation
- Executed only if employee is present
- User provides:
  - Number of working days
  - Working hours per day
- Monthly wage is calculated as:
```text
- Monthly Wage = Working Days × Working Hours × Wage Per Hour
```

---

### 🔹 UC-6: Wage Calculation with Constraints
- Wage is calculated with system-defined limits:
  - Maximum working days = **20**
  - Maximum working hours = **100**
- User enters daily working hours
- Before adding hours, the program checks:

``` text
If totalHours + todayHours > maxWorkingHours → stop calculation
```

This ensures that wage calculation never exceeds allowed limits.

---

## 📋 Sample Menu Output



---

``` text --- Employee Wage Computation ---
1. UC1 - Check Attendance
2. UC2 - Calculate Daily Wage
3. UC3 - Part Time Employee Wage
4. UC5 - Calculate Monthly Wage (20 Days)
5. UC6 - Wage with Max Hour & Day Limit
0. Exit

```

<!--
/*
===============================================================================
EMPLOYEE WAGE COMPUTATION – FINAL EVALUATOR WALKTHROUGH
===============================================================================

1. PROJECT OVERVIEW
-------------------
This console-based application simulates an Employee Wage Computation system
using Object-Oriented Programming principles in C#.

The program supports multiple employees and implements all required use cases
(UC-1 to UC-6) in a structured, menu-driven manner.

-------------------------------------------------------------------------------

2. APPLICATION FLOW
-------------------
Program.cs
- Acts as the entry point of the application.
- Displays the welcome message.
- Transfers control to EmployeeMain to start the application flow.

EmployeeMain.cs
- Accepts user input to create multiple employees.
- Stores employee data (ID, Name, Role, Department) in a List<Employee>.
- Displays stored employees and allows the user to select one employee.
- Controls the overall flow of employee selection and menu execution.
- Allows switching between employees without restarting the program.

-------------------------------------------------------------------------------

3. EMPLOYEE SELECTION LOGIC
---------------------------
- Once employees are created, the user must select one employee.
- All wage-related operations apply only to the selected employee.
- The user can switch employees at any time using the menu option "Change Employee".
- This avoids ambiguity when multiple employees exist.

-------------------------------------------------------------------------------

4. MENU-DRIVEN DESIGN (UC-4)
----------------------------
EmployeeMenu.cs
- Displays a menu using switch-case logic.
- Calls the appropriate use case methods based on user choice.
- Does not control application flow; it only returns control to EmployeeMain
  when employee change is requested.

Menu Options:
1  → UC-1 Check Attendance
2  → UC-2 Calculate Daily Wage
3  → UC-3 Calculate Wage by Employee Type
4  → UC-5 Calculate Monthly Wage
5  → UC-6 Calculate Wage with Hour/Day Limits
9  → Change Employee
0  → Exit Application

-------------------------------------------------------------------------------

5. ATTENDANCE HANDLING (UC-1)
-----------------------------
- Attendance is generated randomly (Present / Absent).
- Attendance is checked ONLY ONCE per employee session.
- The attendance state is stored internally and reused.
- This prevents inconsistent behavior across multiple use cases.

If the employee is absent:
- Wage-related use cases (UC-2, UC-3, UC-5, UC-6) are disabled.
- The user can only exit or change the employee.

-------------------------------------------------------------------------------

6. DAILY WAGE CALCULATION (UC-2)
--------------------------------
- Executed only if the employee is present.
- User provides working hours for the day.
- Daily wage is calculated as:
  
  Daily Wage = Working Hours × Wage Per Hour

-------------------------------------------------------------------------------

7. EMPLOYEE TYPE & WAGE (UC-3)
------------------------------
- Employee type is determined based on working hours:
  - ≥ 8 hours → Full-Time
  - < 8 hours → Part-Time
- Wage is calculated using user-entered working hours.

-------------------------------------------------------------------------------

8. MONTHLY WAGE CALCULATION (UC-5)
----------------------------------
- Executed only if the employee is present.
- User enters:
  - Number of working days
  - Working hours per day
- Monthly wage is calculated as:

  Monthly Wage = Working Days × Working Hours × Wage Per Hour

-------------------------------------------------------------------------------

9. WAGE WITH LIMITS (UC-6)
--------------------------
- Calculates wage with constraints:
  - Maximum 20 working days
  - Maximum 100 working hours
- User enters daily working hours.
- Before adding hours, the program checks:
  
  If totalHours + todayHours > maxWorkingHours → stop input

This prevents exceeding allowed limits and ensures accurate calculation.

-------------------------------------------------------------------------------

10. DESIGN PRINCIPLES USED
--------------------------
- Abstraction: Interface (IEmployee) defines contracts.
- Encapsulation: Logic is hidden inside implementation classes.
- Single Responsibility: Each class handles one specific role.
- Clean Control Flow: EmployeeMain controls navigation, Menu handles choices.

-------------------------------------------------------------------------------

11. KEY LEARNING OUTCOMES
------------------------
- Importance of maintaining application state (attendance).
- Separation of business logic and control flow.
- Handling boundary conditions in loops.
- Writing maintainable, user-friendly console applications.

===============================================================================
END OF WALKTHROUGH
===============================================================================
*/
-->
