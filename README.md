# Training Progress

## Day 1 – Data Structures & Linked Lists (C#)

### Topics Covered
- Overview of Data Structures
- Features of Data Structures in C#
- Types of Data Structures:
  - Linear
  - Hierarchical
  - Graph
  - Hash-based
  - Advanced
- Linked Lists:
  - Singly Linked List
  - Doubly Linked List
  - Circular Linked List

### Hands-on Practice
- Implemented Linked List–based programs:
  - Employee Record Management using Singly Linked List
  - Playlist Management using Circular Linked List
- Solved **Employee Wage Computation Problem** (OOP-based) 
  - Attendance check
  - Daily and monthly wage calculation
  - Full-time and part-time employee wage handling
  - Conditional wage computation using loops and control statements

### Key Learnings
- Practical application of Linked Lists for dynamic data handling
- Improved understanding of object-oriented programming concepts
- Experience implementing real-world problems using classes and methods

---

## Day 2 – Stacks, Queues, Dictionary & OOP Concepts (C#)

### Topics Covered
- Stack data structure and LIFO principle
- Balanced Parentheses validation using Stack
- Queue data structure and FIFO principle
- Dictionary (HashMap) and hashing concepts
- Core OOP concepts:
  - Abstraction
  - Interfaces
  - Polymorphism

### Hands-on Practice
- Implemented Balanced Parentheses Checker using Stack
- Practiced Stack operations: Push, Pop, Peek
- Implemented Queue-based task scheduling example
- Implemented Dictionary for word frequency counting

### Scenario-Based Problems Solved
- **FitTrack – Fitness Tracker**
  - Classes: `UserProfile`, `Workout`
  - Interface: `ITrackable`
  - Implemented `CardioWorkout` and `StrengthWorkout`
    
### Key Learnings
- Stack is effective for validation and backtracking problems
- Queues are suitable for scheduling and request handling
- Dictionary enables efficient key-value data access
- Interfaces and polymorphism improve code flexibility and design

---


## Day 3 – Sorting Algorithms & Scenario-Based Problems (C#)

### Topics Covered
- Sorting Algorithms in C#:
  - Bubble Sort
  - Insertion Sort
  - Merge Sort
  - Quick Sort
- Overview of advanced sorting techniques:
  - Selection Sort
  - Heap Sort
  - Counting Sort
  - Radix Sort
  - Bucket Sort

### Hands-on Practice
- Implemented and tested sorting algorithms:
  - Bubble Sort
  - Insertion Sort
  - Merge Sort
  - Quick Sort

### Scenario-Based Problems Solved
- **FitTrack – Fitness Tracker**
  - Classes: `UserProfile`, `Workout`
  - Interface: `ITrackable`
  - Implemented workout types:
    - `CardioWorkout`
    - `StrengthWorkout`

- **ATM Dispenser Logic**
  - Designed logic to dispense minimum number of currency notes
  - Scenario A: Optimal note combination for ₹880
  - Scenario B: Strategy update after removing ₹500 notes
  - Scenario C: Fallback handling when exact change is not possible

### Key Learnings
- Different sorting algorithms have different performance characteristics
- Algorithm selection depends on input size and constraints
- Scenario-based problems help apply logical thinking and OOP concepts

--- 


## Day 4 – File Handling, Strings, Searching Algorithms & Scenario-Based Design (C#)

### Topics Covered
- File handling in C#:
  - `StreamReader` as an equivalent to Java’s `BufferedReader`
  - Difference between `FileStream` and `StreamReader`
  - Handling character encoding while reading files
- String handling in C#:
  - `String` vs `StringBuilder`
  - Performance considerations and mutability
- Searching Algorithms:
  - Linear Search
  - Binary Search
  - Search optimization using sorting and hashing

### Hands-on Practice
- Read text data from files and console using `StreamReader`
- Implemented file reading using `FileStream`
- Compared performance of `String` and `StringBuilder`
- Implemented word search in large text files using:
  - Linear Search
  - Binary Search (after sorting)
- Built word index using `Dictionary<string, int>`

### Scenario-Based / Story-Based Problems Solved
- **Metal Factory Pipe Cutting**
  - Maximized revenue by determining optimal cut strategy
  - Evaluated impact of custom-length orders
  - Analyzed revenue loss due to non-optimized cuts

- **Custom Furniture Manufacturing**
  - Designed logic to maximize earnings for wooden rod cutting
  - Incorporated waste constraints into solution
  - Balanced revenue maximization with minimal waste

- **LoanBuddy – Loan Approval Automation**
  - Designed core loan approval engine
  - Implemented:
    - `Applicant` and `LoanApplication` classes
    - `IApprovable` interface
    - Multiple loan types using inheritance
  - Applied:
    - Encapsulation for sensitive data
    - Polymorphism for EMI calculation
    - Constructors for different loan configurations

### Key Learnings
- Proper file-handling approach depends on data type and encoding needs
- `StringBuilder` is more efficient for frequent string modifications
- Binary Search significantly improves performance on sorted data
- Scenario-based design improves understanding of OOP principles
- Encapsulation and polymorphism are critical for real-world system design

  ---

## Day 5 – Runtime Analysis, Big-O Notation & Scenario-Based Applications

### Topics Covered
- Runtime Analysis and algorithm efficiency
- Big-O Notation:
  - O(1), O(log N), O(N), O(N log N), O(N²), O(2ⁿ), O(N!)
- Time Complexity:
  - Best, Average, and Worst case analysis
- Space Complexity:
  - Constant and Linear space usage
- Performance comparison of common algorithms:
  - Linear Search, Binary Search
  - Bubble Sort, Merge Sort, Quick Sort
- Best practices for optimizing C# code:
  - Choosing efficient data structures
  - Reducing nested loops
  - Avoiding unnecessary recursion
  - Using built-in optimized libraries

### Hands-on Practice
- Analyzed time and space complexity of sample C# programs
- Compared algorithm performance using Big-O notation
- Evaluated impact of sorting and searching strategies
- Applied optimization techniques to reduce runtime overhead

### Scenario-Based / Story-Based Problems Solved
- **CinemaTime – Movie Schedule Manager**
  - Managed movie titles and showtimes using lists
  - Implemented add, search, and display operations
  - Applied string formatting and exception handling
  - Converted collections to arrays for reporting

- **BookBuddy – Digital Bookshelf App**
  - Stored and managed books using ArrayList
  - Implemented sorting and author-based search
  - Applied string parsing and custom exceptions
  - Exported data by converting collections to arrays

### Key Learnings
- Big-O notation helps evaluate scalability before implementation
- Time and space complexity guide algorithm selection
- Proper data structure choice significantly improves performance
- Exception handling is essential for robust real-world applications
- Scenario-based problems reinforce analytical and design skills

---

## Day 6 – Address Book System & File I/O (C#)

### Topics Covered
- Address Book system design using OOP principles
- Managing contact data using arrays
- Searching and sorting data stored in arrays
- File I/O operations in C#
- Reading and writing data to files
- Understanding extensible system design concepts

### Hands-on Practice
- Created Address Book application using arrays for data storage
- Implemented contact management features:
  - Add new contact
  - Edit existing contact
  - Delete contact
  - Prevent duplicate contact entries
- Managed multiple contacts using array-based structures
- Implemented search functionality by name, city, and state
- Implemented sorting using array-based logic:
  - Sort by name
  - Sort by city, state, and zip
- Read and write address book data using File I/O
- Worked with structured data storage using files

### Assignment Worked On
- **Address Book System (UC 1 – UC 18)**
  - Console-based address book application
  - Array-based data management
  - File persistence for contact information
  - Designed for future extension of data sources

### Key Learnings
- Arrays require manual management of size and indexing
- Sorting and searching logic is more explicit with arrays
- File I/O is essential for data persistence
- Clean OOP structure improves readability and maintenance
- Early design decisions impact scalability and flexibility

