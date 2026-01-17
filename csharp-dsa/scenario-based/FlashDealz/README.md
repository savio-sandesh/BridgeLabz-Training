# FlashDealz – Product Sorting by Discount 

## 📌 Project Overview

**FlashDealz** is a console-based C# application developed using **Object-Oriented Programming (OOP) principles**.  
The application simulates an e-commerce flash sale system where products are sorted based on their **discount percentage** using the **Quick Sort algorithm**.

This project focuses on:

- Proper OOP design  
- Algorithm implementation without collections  
- Clean separation of concerns  

---

## 🎯 Problem Statement

During flash sales, e-commerce platforms must quickly display products with the **highest discounts first**.  
To efficiently handle unsorted product data, **Quick Sort** is used due to its fast average-case performance.

---

## 🧠 Concepts Used

- Object-Oriented Programming (OOP)
  - Encapsulation  
  - Abstraction  
  - Interfaces  
  - Separation of Concerns  
- Quick Sort Algorithm  
- Arrays (No Collections Used)  
- Console-based Menu System  

---

## 🗂️ Project Folder Structure

``` text
FlashDealz/
│
├── Program.cs
│ Entry point of the application
│
├── DealMain.cs
│ Controls application flow and coordination
│
├── DealMenu.cs
│ Displays menu and takes user choice
│
├── IDealManager.cs
│ Interface defining deal operations
│
├── DealUtility.cs
│ Business logic and Quick Sort implementation
│
├── Deal.cs
│ Model class with getters and setters
```


---

## 🧩 Class Description

### 1. Program.cs

- Contains the `Main()` method  
- Starts the application by invoking `DealMain`  

---

### 2. DealMain.cs

- Acts as the controller  
- Manages application flow  
- Connects menu and business logic using the interface  

---

### 3. DealMenu.cs

- Displays menu options  
- Accepts user input  
- Does not contain any business logic  

---

### 4. IDealManager.cs

- Interface defining core operations:
  - `AddDeal()`  
  - `DisplayDeals()`  
  - `SortDealsByDiscount()`  

---

### 5. DealUtility.cs

- Implements `IDealManager`  
- Stores deals in an array  
- Implements **Quick Sort** (descending order)  
- Calculates and displays **discounted price**  

---

### 6. Deal.cs

- Model / entity class  
- Uses private fields with public getters and setters  
- Contains no logic  

---

## ⚙️ Features

- Add product deals  
- Display all deals with:
  - Original price  
  - Discount percentage  
  - Discounted price  
- Sort products by discount (High → Low)  
- Menu-driven console interface  

---

## 🔢 Discount Formula Used
``` text
Discounted Price = Original Price − (Original Price × Discount Percentage / 100)
```


---

## 🚀 How to Run the Project

1. Open the project in **Visual Studio / VS Code**  
2. Build the solution  
3. Run the application  
4. Use the menu to:
   - Add deals  
   - Display deals  
   - Sort by discount  

---

## 🧪 Sample Output

``` text
Product Name: Laptop
Original Price: 50000
Discount: 20%
Discounted Price: 40000
```

## 🧠 Algorithm Used – Quick Sort

- Pivot-based sorting  
- Implemented manually on arrays  
- Sorted in **descending order**  
- Average Time Complexity: **O(n log n)** 

## 📌 Note

This project is designed for **learning purposes**, focusing on algorithm implementation and object-oriented design principles.