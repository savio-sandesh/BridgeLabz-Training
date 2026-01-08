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

## 🖥️ Sample Execution Output

``` text
Stored Employee Details:
1. fdsfvsfdg (ID: 45535)
2. fdfbdb (ID: 4543)
3. dbgfbhgd (ID: 54536)

Select Employee (Enter number): 2
Attendance Status: Absent

(Employee is absent - wage options disabled)
9. Change Employee
0. Exit
```

---

## 🧠 Design Principles Used

- **Abstraction:** Interface (`IEmployee`) defines wage-related contracts
- **Encapsulation:** Business logic is hidden inside implementation classes
- **Single Responsibility Principle:**
  - Program.cs → Entry point
  - EmployeeMain.cs → Application flow & employee selection
  - EmployeeMenu.cs → Menu handling
  - Utility class → Wage computation logic
- **Clean Control Flow:** Employee switching without restarting application

---


