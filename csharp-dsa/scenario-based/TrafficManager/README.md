# TrafficManager – Roundabout Vehicle Flow (Circular Linked List & Queue)

## 📌 Project Overview

**TrafficManager** is a console-based C# application designed using **Data Structures and Algorithms (DSA)**, **Object-Oriented Programming (OOP)**, and **Core C#** concepts.
The application simulates a **smart city roundabout system**, where vehicles enter and exit dynamically.

* Vehicles inside the roundabout are managed using a **Circular Linked List**
* Vehicles waiting to enter are managed using an **array-based Queue**
* The system supports real-time updates, overflow/underflow handling, and state visualization

---

## 🎯 Problem Statement

A smart city roundabout allows vehicles to enter and exit dynamically:

* Each vehicle inside the roundabout is represented as a node in a **Circular Linked List**
* Vehicles waiting to enter are stored in a **Queue**
* The system must:

  * Add or remove vehicles dynamically
  * Handle queue overflow and underflow
  * Display the current state of the roundabout at any time

---

## 🧠 Concepts Applied

* Data Structures:

  * Circular Linked List
  * Queue (array-based)
* Object-Oriented Programming:

  * Encapsulation
  * Abstraction
  * Interfaces
  * Separation of Concerns
* Core C# (Console Application)
* Menu-driven application design

---

## 🗂️ Project Structure

```
TrafficManager/
│
├── Program.cs
│   Entry point of the application
│
├── TrafficMain.cs
│   Controls application flow and coordination
│
├── TrafficMenu.cs
│   Displays menu options and accepts user input
│
├── ITrafficManager.cs
│   Interface defining traffic operations
│
├── TrafficUtility.cs
│   Business logic using Circular Linked List and Queue
│
├── Vehicle.cs
│   Model class representing a vehicle (node)
│
├── README.md
│   Project documentation
```

---

## 🧩 Class Responsibilities

### Program.cs

* Entry point of the application
* Starts execution by invoking `TrafficMain`

---

### TrafficMain.cs

* Acts as the controller
* Manages application flow
* Connects menu and logic using an interface

---

### TrafficMenu.cs

* Displays menu options
* Accepts user input
* Contains no business logic

---

### ITrafficManager.cs

* Defines abstraction for traffic operations:

  * AddVehicleToQueue()
  * AllowVehicleToEnter()
  * RemoveVehicleFromRoundabout()
  * DisplayRoundabout()

---

### TrafficUtility.cs

* Implements `ITrafficManager`
* Uses:

  * **Circular Linked List** to manage vehicles in the roundabout
  * **Queue** to manage waiting vehicles
* Handles:

  * Queue overflow and underflow
  * Vehicle entry and exit
  * Displaying roundabout state

---

### Vehicle.cs

* Represents a vehicle
* Acts as a node in the circular linked list
* Contains vehicle data and reference to the next vehicle

---

## ⚙️ Features

* Add vehicles to waiting queue
* Allow vehicles to enter the roundabout
* Remove vehicles from the roundabout
* Handle queue overflow and underflow
* Display current roundabout state
* Menu-driven console interface

---

## 🔢 Data Structures Used

### Circular Linked List

* Represents continuous vehicle flow in the roundabout
* Last vehicle points back to the first vehicle

### Queue (Array-Based)

* Manages vehicles waiting to enter
* Supports overflow and underflow checks

---

## 🚀 How to Run the Application

1. Open the project in **Visual Studio** or **VS Code**
2. Build the solution
3. Run the application
4. Use the menu to:

   * Add vehicles to queue
   * Allow entry into roundabout
   * Remove vehicles
   * Display roundabout state

---

## 🧪 Sample Output

```                                   
 Traffic Manager Menu:
1. Add Vehicle to Waiting Queue
2. Allow Vehicle to Enter Roundabout
3. Remove Vehicle from Roundabout
4. Display Roundabout State
5. Exit
Enter your choice: 1

Enter Vehicle Number: UP83 0101
Vehicle added to queue.

 Traffic Manager Menu:
1. Add Vehicle to Waiting Queue
2. Allow Vehicle to Enter Roundabout
3. Remove Vehicle from Roundabout
4. Display Roundabout State
5. Exit
Enter your choice: 1

Enter Vehicle Number: UP85 0202
Vehicle added to queue.

 Traffic Manager Menu:
1. Add Vehicle to Waiting Queue
2. Allow Vehicle to Enter Roundabout
3. Remove Vehicle from Roundabout
4. Display Roundabout State
5. Exit
Enter your choice: 1

Enter Vehicle Number: UP81 0303
Vehicle added to queue.

 Traffic Manager Menu:
1. Add Vehicle to Waiting Queue
2. Allow Vehicle to Enter Roundabout
3. Remove Vehicle from Roundabout
4. Display Roundabout State
5. Exit
Enter your choice: 2

Vehicle entered the roundabout.

 Traffic Manager Menu:
1. Add Vehicle to Waiting Queue
2. Allow Vehicle to Enter Roundabout
3. Remove Vehicle from Roundabout
4. Display Roundabout State
5. Exit
Enter your choice: 4

Vehicles in Roundabout:
Vehicle Number: UP83 0101

 Traffic Manager Menu:
1. Add Vehicle to Waiting Queue
2. Allow Vehicle to Enter Roundabout
3. Remove Vehicle from Roundabout
4. Display Roundabout State
5. Exit
Enter your choice:
```

---
