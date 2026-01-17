# FlashDealz – Product Sorting by Discount (C# OOP Project)

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