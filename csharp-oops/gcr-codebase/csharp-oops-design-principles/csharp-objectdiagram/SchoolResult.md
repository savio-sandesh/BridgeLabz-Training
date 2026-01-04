# Sample Problem 1: School Results Application

This document demonstrates the use of Class Diagram, Object Diagram, and Sequence Diagram
for a School Results Application using Mermaid.

---

## Class Diagram

The class diagram shows the structure of the system and relationships between classes.

```mermaid
classDiagram
    class Student {
        +name : String
        +requestGrade()
    }

    class Subject {
        +subjectName : String
        +marks : int
    }

    class GradeCalculator {
        +calculateGrade()
    }

    Student "1" o-- "*" Subject : has
    Student --> GradeCalculator : uses
```
## Object Diagram

The object diagram represents the state of objects at a particular moment in time.

```mermaid
classDiagram
    class student1 {
        name = "John"
    }

    class subject1 {
        subjectName = "Maths"
        marks = 90
    }

    class subject2 {
        subjectName = "Science"
        marks = 85
    }

    student1 -- subject1
    student1 -- subject2
```
## Sequence Diagram
The sequence diagram shows interaction between objects over time.

```mermaid
sequenceDiagram
    participant Student
    participant GradeCalculator

    Student->>GradeCalculator: requestGrade()
    GradeCalculator-->>Student: returnGrade()
```