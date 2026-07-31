
USE Health_Clinic;
GO


-- =============================================
-- PATIENT TABLE
-- =============================================

CREATE TABLE Patient
(
    PatientId INT IDENTITY(1,1) PRIMARY KEY,

    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender VARCHAR(20),

    Phone VARCHAR(15) NOT NULL,
    Email VARCHAR(100),
    Address VARCHAR(255)
);

GO


-- =============================================
-- DOCTOR TABLE
-- =============================================

CREATE TABLE Doctor
(
    DoctorId INT IDENTITY(1,1) PRIMARY KEY,

    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Specialization VARCHAR(100) NOT NULL,

    Phone VARCHAR(15),
    Email VARCHAR(100)
);

GO


-- =============================================
-- APPOINTMENT TABLE
-- =============================================

CREATE TABLE Appointment
(
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,

    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,

    AppointmentDate DATE NOT NULL,
    AppointmentTime TIME NOT NULL,

    Reason VARCHAR(255),
    Status VARCHAR(20) NOT NULL DEFAULT 'Scheduled',

    CONSTRAINT FK_Appointment_Patient
        FOREIGN KEY (PatientId)
        REFERENCES Patient(PatientId),

    CONSTRAINT FK_Appointment_Doctor
        FOREIGN KEY (DoctorId)
        REFERENCES Doctor(DoctorId),

    CONSTRAINT CHK_Appointment_Status
        CHECK (Status IN ('Scheduled', 'Completed', 'Cancelled'))
);

GO

USE Health_Clinic;
GO

SELECT * FROM Patient;
SELECT * FROM Doctor;
SELECT * FROM Appointment;


