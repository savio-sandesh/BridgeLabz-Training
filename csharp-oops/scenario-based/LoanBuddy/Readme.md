# 📘 LoanBuddy – Loan Approval Automation System

## 📌 Project Overview

**LoanBuddy** is a console-based loan approval automation system developed for a fintech startup **FinlyTech**.  
The application automates the process of evaluating loan applications, approving or rejecting loans based on eligibility criteria, and calculating **monthly EMIs** using standard financial formulas.

This project demonstrates strong usage of **Object-Oriented Programming (OOP)** principles in **C#**, including encapsulation, inheritance, polymorphism, interfaces, and access control.

---

## 🎯 Objectives

- Collect applicant details  
- Evaluate credit eligibility  
- Approve or reject loans using internal rules  
- Calculate **EMI (Equated Monthly Installment)**  
- Support multiple loan types  
- Implement clean and scalable OOP design  

---

## 🛠️ Technologies Used

- **Language:** C#  
- **Platform:** .NET Console Application  
- **IDE:** Visual Studio  

---

## 📂 Project Structure

``` text
LoanBuddy
│
├── Applicant.cs
├── IApprovable.cs
├── Loan.cs
├── HomeLoan.cs
├── AutoLoan.cs
├── PersonalLoan.cs
└── Program.cs

```


---

## 🧩 Class & Interface Description

### 🔹 Applicant.cs
- Stores applicant information:
  - Name  
  - Credit Score *(private)*  
  - Monthly Income  
  - Loan Amount  
- Demonstrates **encapsulation** by restricting direct access to credit score.

---

### 🔹 IApprovable.cs
- Interface defining loan behavior:
  - `ApproveLoan()`
  - `CalculateEMI()`
- Enables **polymorphism** across loan types.

---

### 🔹 Loan.cs (Abstract Base Class)
- Implements `IApprovable`
- Contains:
  - Common loan attributes  
  - Loan approval status *(private)*  
  - Eligibility checking logic  
- Demonstrates:
  - **Inheritance**
  - **Encapsulation**
  - **Access control**

---

### 🔹 HomeLoan.cs
- Inherits from `Loan`
- Lower interest rate
- Moderate eligibility rules
- Overrides EMI and approval logic

---

### 🔹 AutoLoan.cs
- Inherits from `Loan`
- Medium interest rate
- Relaxed eligibility rules
- Overrides EMI and approval logic

---

### 🔹 PersonalLoan.cs
- Inherits from `Loan`
- Higher interest rate
- Stricter eligibility rules
- Overrides EMI and approval logic

---

### 🔹 Program.cs
- Entry point of the application
- Menu-driven user interface
- Dynamically creates loan objects
- Displays loan approval status and EMI

---

## 📐 EMI Calculation Formula

The EMI is calculated using the standard formula:

```text
EMI = (P × R × (1 + R)^N) / ((1 + R)^N − 1)
```


Where:
- **P** = Loan Amount (Principal)  
- **R** = Monthly Interest Rate  
- **N** = Loan Term (in months)  

---

## ✅ OOP Concepts Used

``` text

| Concept | Implementation |
|---------|----------------|
| Encapsulation		| Private credit score & loan status |
| Inheritance		| Loan → HomeLoan / AutoLoan / PersonalLoan |
| Polymorphism		| Overridden EMI & approval methods |
| Interface			| IApprovable |
| Constructors		| Loan-specific initialization |
| Access Modifiers  | Restricted status updates |

```

---

## ▶️ How to Run the Project

1. Open **Visual Studio**
2. Create a **Console App (.NET)**
3. Add all `.cs` files to the project
4. Build and run the application
5. Follow the on-screen instructions

---

## 🧪 Sample Output

``` text 
===== Welcome to LoanBuddy =====

Enter Applicant Name: Rahul
Enter Credit Score: 720
Enter Monthly Income: 50000
Enter Loan Amount: 600000

Select Loan Type:
1. Home Loan
2. Auto Loan
3. Personal Loan
Enter choice: 1

Enter Loan Term (in months): 240

Loan Approved!
Monthly EMI: 4653.78
```