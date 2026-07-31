# Health Clinic App - ER Diagram

```mermaid
erDiagram

    PATIENT ||--o{ APPOINTMENT : books
    DOCTOR ||--o{ APPOINTMENT : has

    PATIENT {
        int PatientId PK
        varchar FirstName
        varchar LastName
        date DateOfBirth
        varchar Gender
        varchar Phone
        varchar Email
        varchar Address
    }

    DOCTOR {
        int DoctorId PK
        varchar FirstName
        varchar LastName
        varchar Specialization
        varchar Phone
        varchar Email
    }

    APPOINTMENT {
        int AppointmentId PK
        int PatientId FK
        int DoctorId FK
        date AppointmentDate
        time AppointmentTime
        varchar Reason
        varchar Status
    }
```