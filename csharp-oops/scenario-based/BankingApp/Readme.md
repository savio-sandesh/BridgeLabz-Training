# 🏦 Banking Application (C# – Console, In-Memory)

A **role-based banking system simulation** built in **C#** using clean object-oriented design and in-memory data structures.  
The project models **real-world banking workflows** such as customer onboarding, account creation, KYC verification, deposits, withdrawals, interest application, and account control — **without using a database or APIs**.

This application is **menu-driven** and enforces **authentication and authorization** between different roles.

---

## 🎯 Project Objective

To design a **secure, modular, and realistic banking domain model** that demonstrates:

- Separation of responsibilities  
- Role-based access control (Manager vs Customer)  
- Encapsulation of sensitive data (balance, identity)  
- Realistic banking rules and workflows  
- Use of only **core C# concepts**

The focus is on **logic, correctness, and architecture**, not UI or persistence.

---

## 🧠 System Design Overview

### Core Design Principles

- **Customer ≠ Authority**
- Customers request operations, **manager approves**
- **All critical logic flows through a central manager**
- Money is **never modified directly**
- Bank → Branch → Accounts hierarchy
- In-memory data storage using collections

---

## 👥 System Roles

### 🧑‍💼 Bank Manager
Responsible for **administrative and compliance operations**:
- Create customers  
- Create bank accounts  
- Verify KYC  
- Freeze / unfreeze accounts  
- Apply interest  
- Close accounts  

### 👤 Bank Customer
Can perform **self-service banking operations**:
- Login using CIF + Account Number  
- Deposit money  
- Withdraw money  
- Check account balance  

Customers **cannot** perform administrative actions.

---

## 🔐 Authentication & Authorization

- **Manager Login**
  - Manager ID + Password (demo credentials)
- **Customer Login**
  - CIF Number + Account Number
- Invalid credentials are rejected
- Customers can log in **only after** manager creates their account

This ensures **secure role-based access**.

---

## 🏗️ Project Structure

BankingApp
│
├── Bank.cs // Bank-level details & branch management
├── Branch.cs // Branch-level account storage
├── BankAccount.cs // Balance & account state rules
├── User.cs // Customer identity & KYC state
├── BankAccountManager.cs // Central authority / service layer
└── Program.cs // Menu-driven role-based console UI


---

## 🧩 Class Responsibilities

### 🏦 Bank
- Stores bank details (name, email, phone)
- Manages branches
- Prevents duplicate IFSC entries

### 🏢 Branch
- Identified by IFSC
- Owns multiple bank accounts
- Creates, retrieves, and closes accounts

### 💰 BankAccount
- Stores account number & balance
- Enforces:
  - No overdraft
  - No negative deposits
  - No withdrawals if frozen or blocked
- Balance is **not directly editable**

### 👤 User
- Stores customer identity (CIF)
- Linked to exactly one account
- Tracks KYC verification status
- Contains no banking logic

### 🧑‍💼 BankAccountManager (Authority Layer)
- **Single entry point for all operations**
- Enforces banking rules and compliance
- Handles:
  - Account lifecycle
  - Deposits & withdrawals
  - KYC verification
  - Freeze / unfreeze
  - Interest application
  - Account closure

---

## 🔐 Security & Encapsulation Highlights

- `Balance` → private set  
- `AccountNumber` → immutable after creation  
- KYC status → manager-controlled  
- Account state → not user-editable  
- Internal collections are not exposed  

---

## 💼 Supported Operations

✔ Create customer  
✔ Create account  
✔ Verify KYC  
✔ Deposit money  
✔ Withdraw money  
✔ Check balance  
✔ Freeze / unfreeze account  
✔ Apply interest  
✔ Close account  

All operations are validated against **role and account state**.

---

## 🔄 Program Flow (Flowchart)

Start
↓
Login Screen
├── Manager Login
│ ↓
│ Manager Menu
│ ├── Create Customer
│ ├── Create Account
│ ├── Verify KYC
│ ├── Freeze / Unfreeze
│ ├── Apply Interest
│ └── Close Account
│
└── Customer Login
↓
Customer Menu
├── Deposit Money
├── Withdraw Money
└── Check Balance
↓
Logout / Exit


---

## ▶️ Demo Workflow

A typical successful flow:

1. Manager logs in  
2. Manager creates customer  
3. Manager creates account for customer  
4. Manager verifies KYC  
5. Customer logs in  
6. Customer deposits money  
7. Customer withdraws money  
8. Customer checks balance  

All steps follow **real banking constraints**.

---

## 🧪 Data Storage

- Uses **in-memory collections** (`List<User>`, `List<Account>`)
- No database, SQL, or APIs
- Easily extendable to persistence later

---

## 🚀 How to Run

1. Clone the repository  
2. Open in Visual Studio  
3. Run the project  
4. Use the console menus to interact as Manager or Customer  

---

## 📌 Future Enhancements

- Transaction history  
- Daily withdrawal limits  
- Account types (Savings / Current)  
- Persistent storage  
- Login attempt limits  
- Interest schedules  

---

## 🎓 Learning Outcomes

This project demonstrates:

- Real-world OOP modeling  
- Role-based system design  
- Secure state management  
- Clean separation of concerns  
- Backend-focused thinking  

---

## ✨ Created By

**Sandesh**
