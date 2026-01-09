# 🏋️ FitTrack  
### Fitness Tracker Console Application (C#)

## 📌 Overview

**FitTrack** is a menu-driven console application developed in **C#** using **Object-Oriented Programming (OOP)** principles.  
The application allows users to record fitness activities, calculate calories burned, and view workout history in a structured and user-friendly manner.

This project demonstrates real-world implementation of **abstraction, inheritance, interfaces, polymorphism, and encapsulation** through a fitness tracking scenario.

---

## 🎯 Objectives

- Apply core **OOP concepts** in a practical scenario  
- Design a **menu-driven console application**  
- Implement **interfaces** to define behavior contracts  
- Use **inheritance** to model different workout types  
- Maintain clean code structure and readability  

---

## 🛠️ Technologies Used

- **Language:** C#  
- **Framework:** .NET (Console Application)  
- **IDE:** Visual Studio  
- **Version Control:** Git & GitHub  

---

## 📁 Project Structure

```text
FitTrack/
│
├── Program.cs              // Application entry point
├── UserProfile.cs          // Stores user details and workout history
├── ITrackable.cs           // Interface defining workout behavior
├── Workout.cs              // Abstract base class for workouts
├── CardioWorkout.cs        // Cardio workout implementation
├── StrengthWorkout.cs      // Strength workout implementation
└── README.md               // Project documentation
```

## 🧩 Core Components

### UserProfile

--> Stores user information (ID and Name)

--> Maintains a list of completed workouts

--> Displays workout history

### ITrackable (Interface)

--> Defines common workout behaviors:

--> Track workout

--> Calculate calories burned

--> Display workout summary

### Workout (Abstract Class)

--> Implements ITrackable

``` text
--> Provides shared properties:

├── Workout name           
├── Duration             
├── Calories burned       


```
--> Acts as a base class for all workout types

### CardioWorkout

--> Inherits from Workout

--> Tracks distance-based activities

--> Calculates calories using distance covered

### StrengthWorkout

--> Inherits from Workout

--> Tracks sets and repetitions

--> Calculates calories based on workout intensity


## 🔄 Application Flow

1. User enters profile details (ID and Name)

2. Main menu is displayed

3. User can:

Add a cardio workout

Add a strength workout

View workout history

4. Calories are calculated automatically

5. User can repeat actions until exiting the application

## 🧮 Calorie Calculation Logic
    Cardio Workout
``` text
Calories = Distance (km) × 60
```

    Strength Workout
``` text
Calories = Sets × Reps × 2
```

## 🖥️ Sample Menu Output

--- FitTrack Menu ---
1. Add Cardio Workout
2. Add Strength Workout
3. View Workout History
0. Exit


## 🧠 OOP Concepts Demonstrated

``` text
# Abstraction
Interface (ITrackable) and abstract base class (Workout)

# Inheritance
CardioWorkout and StrengthWorkout inherit from Workout

# Polymorphism
Common workout behavior handled through base types

# Encapsulation
Data managed through class methods and properties
```
