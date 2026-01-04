# Sample Problem 2: Grocery Store Bill Generation Application

This document demonstrates the use of Class Diagram, Object Diagram, and Sequence Diagram
for a Grocery Store Bill Generation Application using Mermaid.

---

## Class Diagram

The class diagram shows the structure of the grocery billing system and relationships between classes.

```mermaid
classDiagram
    class Customer {
        +name : String
        +checkout()
    }

    class Product {
        +productName : String
        +quantity : int
        +pricePerUnit : double
    }

    class BillGenerator {
        +generateBill()
    }

    Customer "1" *-- "*" Product : purchases
    Customer --> BillGenerator : uses
```

## Object Diagram
The object diagram represents the state of objects at a particular moment in time.
```mermaid
classDiagram
    class customer1 {
        name = "Alice"
    }

    class product1 {
        productName = "Apples"
        quantity = 2
        pricePerUnit = 3
    }

    class product2 {
        productName = "Milk"
        quantity = 1
        pricePerUnit = 2
    }

    customer1 -- product1
    customer1 -- product2
```

## Sequence Diagram
The sequence diagram shows interaction between objects during bill generation.

```mermaid
sequenceDiagram
    participant Customer
    participant BillGenerator

    Customer->>BillGenerator: checkout()
    BillGenerator-->>Customer: returnTotalBill()
```