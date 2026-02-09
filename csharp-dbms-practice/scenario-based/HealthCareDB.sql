CREATE DATABASE HealthcareDB;
GO

USE HealthcareDB;
GO


-- Patients Table

CREATE TABLE Patients (
    PatientID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DOB DATE NOT NULL,
    Gender NVARCHAR(10),
    Address NVARCHAR(100),
    BloodGroup NVARCHAR(5),
    ContactNumber NVARCHAR(15) UNIQUE NOT NULL,
    Email NVARCHAR(50) UNIQUE
);


-- Specializations Table

CREATE TABLE Specializations (
    SpecializationID INT PRIMARY KEY IDENTITY(1,1),
    SpecializationName NVARCHAR(100) NOT NULL UNIQUE
);

-- Doctors Table

CREATE TABLE Doctors (
    DoctorID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    ContactNumber NVARCHAR(15) UNIQUE NOT NULL,
    Email NVARCHAR(50) UNIQUE,
    ConsultationFee DECIMAL(10,2) NOT NULL,
    Is_Active BIT DEFAULT 1,
    SpecializationID INT NOT NULL,

    CONSTRAINT FK_Doctors_Specializations
        FOREIGN KEY (SpecializationID)
        REFERENCES Specializations(SpecializationID)
);


-- Appointments Table

CREATE TABLE Appointments (
    AppointmentID INT PRIMARY KEY IDENTITY(1,1),

    PatientID INT NOT NULL,
    DoctorID INT NOT NULL,

    AppointmentDate DATE NOT NULL,
    AppointmentTime TIME NOT NULL,

    AppointmentStatus NVARCHAR(20) NOT NULL
        CONSTRAINT DF_AppointmentStatus DEFAULT 'SCHEDULED',

    CONSTRAINT FK_Appointments_Patients
        FOREIGN KEY (PatientID)
        REFERENCES Patients(PatientID),

    CONSTRAINT FK_Appointments_Doctors
        FOREIGN KEY (DoctorID)
        REFERENCES Doctors(DoctorID),

    CONSTRAINT CHK_AppointmentStatus
        CHECK (AppointmentStatus IN
        ('SCHEDULED','CANCELLED','COMPLETED','RESCHEDULED'))
);


-- Visits Table

CREATE TABLE Visits (
    VisitID INT PRIMARY KEY IDENTITY(1,1),

    AppointmentID INT NOT NULL,

    Diagnosis NVARCHAR(255) NOT NULL,
    Notes NVARCHAR(MAX),

    VisitDate DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),

    CONSTRAINT FK_Visits_Appointments
        FOREIGN KEY (AppointmentID)
        REFERENCES Appointments(AppointmentID)
);


-- Prescriptions Table

CREATE TABLE Prescriptions (
    PrescriptionID INT PRIMARY KEY IDENTITY(1,1),

    VisitID INT NOT NULL,

    MedicineName NVARCHAR(100) NOT NULL,
    Dosage NVARCHAR(50) NOT NULL,
    Frequency NVARCHAR(50) NOT NULL,
    Duration NVARCHAR(50) NOT NULL,

    CONSTRAINT FK_Prescriptions_Visits
        FOREIGN KEY (VisitID)
        REFERENCES Visits(VisitID)
);


-- Bills Table

CREATE TABLE Bills (
    BillID INT PRIMARY KEY IDENTITY(1,1),

    VisitID INT NOT NULL,

    TotalAmount DECIMAL(10,2) NOT NULL,

    PaymentStatus NVARCHAR(20) NOT NULL
        CONSTRAINT DF_BillStatus DEFAULT 'UNPAID',

    BillingDate DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),

    CONSTRAINT FK_Bills_Visits
        FOREIGN KEY (VisitID)
        REFERENCES Visits(VisitID),

    CONSTRAINT CHK_BillStatus
        CHECK (PaymentStatus IN ('PAID','UNPAID','PARTIAL'))
);


-- Payments Table

CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),

    BillID INT NOT NULL,

    AmountPaid DECIMAL(10,2) NOT NULL,

    PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),

    PaymentMode NVARCHAR(20) NOT NULL,

    CONSTRAINT FK_Payments_Bills
        FOREIGN KEY (BillID)
        REFERENCES Bills(BillID),

    CONSTRAINT CHK_PaymentMode
        CHECK (PaymentMode IN ('CASH','CARD','UPI','NETBANKING'))
);

/* ============================================================
   TABLE: AuditLogs

   PURPOSE:
   This table stores all important database activities such as
   INSERT, UPDATE, and DELETE operations.

   It helps administrators:
   - Track who modified data
   - Detect unauthorized access
   - Debug system issues
   - Maintain legal records

   DATA SOURCE:
   This table is populated automatically using database triggers.

   USED BY:
   Administrator (for monitoring system activity)
============================================================ */

CREATE TABLE AuditLogs
(
    Audit_ID INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(50) NOT NULL,
    ActionType NVARCHAR(20) NOT NULL,
    TableName NVARCHAR(50) NOT NULL,
    RecordID INT,
    ActionDateTime DATETIME NOT NULL DEFAULT GETDATE()
);


/* ============================================================
   TABLE: AppointmentAudit

   PURPOSE:
   This table maintains the history of appointment status changes.

   Whenever an appointment is cancelled, rescheduled, or completed,
   the old and new status are recorded here.

   This helps:
   - Track appointment modifications
   - Resolve patient complaints
   - Generate management reports
   - Maintain transparency

   DATA SOURCE:
   Data is inserted automatically using triggers on Appointments.

   USED BY:
   Receptionist, Administrator
============================================================ */

CREATE TABLE AppointmentAudit
(
    AuditID INT PRIMARY KEY IDENTITY(1,1),
    AppointmentID INT NOT NULL,
    OldStatus NVARCHAR(20),
    NewStatus NVARCHAR(20),
    ChangedBy NVARCHAR(50) NOT NULL,
    ChangeDateTime DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_AppointmentAudit_Appointments
        FOREIGN KEY (AppointmentID)
        REFERENCES Appointments(AppointmentID)
);

/* ============================================================
   TABLE: Payment_Transactions

   PURPOSE:
   This table stores complete payment transaction history
   for each bill.

   It records:
   - Partial payments
   - Multiple payments
   - Refunds
   - Adjustments

   This ensures:
   - Financial transparency
   - Accurate accounting
   - Audit compliance
   - Dispute resolution

   DATA SOURCE:
   Records are inserted when a payment is processed
   through stored procedures.

   USED BY:
   Administrator, Accounts Department
============================================================ */

CREATE TABLE Payment_Transactions
(
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    BillID INT NOT NULL,
    AmountPaid DECIMAL(10,2) NOT NULL,
    PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),
    PaymentMode NVARCHAR(20) NOT NULL,
    TransactionDate DATETIME NOT NULL DEFAULT GETDATE(),
    PerformedBy NVARCHAR(50) NOT NULL,

    CONSTRAINT FK_Payment_Transactions_Bills
        FOREIGN KEY (BillID)
        REFERENCES Bills(BillID),

    CONSTRAINT CHK_PaymentMode_Transactions
        CHECK (PaymentMode IN ('CASH','CARD','UPI','NETBANKING'))
);


/* ============================================================
   PROCEDURE: sp_MakePayment_Transaction

   PURPOSE:
   Records payment and transaction safely.
   If any step fails, entire operation is rolled back.

   USED BY:
   Receptionist / Administrator
============================================================ */

CREATE PROCEDURE sp_MakePayment_Transaction
(
    @BillID INT,
    @Amount DECIMAL(10,2),
    @Mode NVARCHAR(20),
    @UserName NVARCHAR(50)
)
AS
BEGIN
    BEGIN TRY

        BEGIN TRANSACTION;

        -- Insert into Payments
        INSERT INTO Payments (BillID, AmountPaid, PaymentMode)
        VALUES (@BillID, @Amount, @Mode);

        -- Insert into Payment Transactions
        INSERT INTO Payment_Transactions
        (BillID, AmountPaid, PaymentMode, PerformedBy)
        VALUES (@BillID, @Amount, @Mode, @UserName);

        -- Update Bill Status
        UPDATE Bills
        SET PaymentStatus = 'PAID'
        WHERE BillID = @BillID;

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        ROLLBACK TRANSACTION;

        RAISERROR('Payment Failed. Transaction Rolled Back.',16,1);

    END CATCH
END;



/* ============================================================
   PROCEDURE: sp_CheckDoctorAvailability

   PURPOSE:
   Checks how many appointments a doctor has on a given date.

   USED BY:
   Receptionist
============================================================ */

CREATE PROCEDURE sp_CheckDoctorAvailability
(
    @DoctorID INT,
    @Date DATE
)
AS
BEGIN
    SELECT 
        DoctorID,
        COUNT(*) AS BookedSlots
    FROM Appointments
    WHERE DoctorID = @DoctorID
      AND AppointmentDate = @Date
      AND AppointmentStatus = 'SCHEDULED'
    GROUP BY DoctorID;
END;


/* ============================================================
   REPORT: Total Hospital Revenue
============================================================ */

SELECT 
    SUM(TotalAmount) AS TotalRevenue
FROM Bills
WHERE PaymentStatus = 'PAID';


/* ============================================================
   REPORT: Revenue Per Doctor
============================================================ */

SELECT 
    d.FirstName + ' ' + d.LastName AS DoctorName,
    SUM(b.TotalAmount) AS Revenue
FROM Bills b
JOIN Visits v ON b.VisitID = v.VisitID
JOIN Appointments a ON v.AppointmentID = a.AppointmentID
JOIN Doctors d ON a.DoctorID = d.DoctorID
GROUP BY d.FirstName, d.LastName;


/* ============================================================
   REPORT: Pending Payments
============================================================ */

SELECT 
    b.BillID,
    p.FirstName + ' ' + p.LastName AS PatientName,
    b.TotalAmount,
    b.PaymentStatus
FROM Bills b
JOIN Visits v ON b.VisitID = v.VisitID
JOIN Appointments a ON v.AppointmentID = a.AppointmentID
JOIN Patients p ON a.PatientID = p.PatientID
WHERE b.PaymentStatus = 'UNPAID';


/* ============================================================
   REPORT: Daily Appointments
============================================================ */

SELECT 
    AppointmentDate,
    COUNT(*) AS TotalAppointments
FROM Appointments
GROUP BY AppointmentDate;


/* ============================================================
   BACKUP: Healthcare Database
============================================================ */

--BACKUP DATABASE HealthcareDB
--TO DISK = 'C:\DB_Backup\HealthcareDB.bak'
--WITH INIT;


/* ============================================================
   SECTION: Performance Indexes
   PURPOSE: Improve query and JOIN performance
============================================================ */


-- Speed up patient-wise appointment searches
CREATE NONCLUSTERED INDEX IDX_Appointments_PatientID
ON Appointments (PatientID);


-- Speed up doctor-wise appointment searches
CREATE NONCLUSTERED INDEX IDX_Appointments_DoctorID
ON Appointments (DoctorID);


-- Speed up date-based appointment queries
CREATE NONCLUSTERED INDEX IDX_Appointments_Date
ON Appointments (AppointmentDate);


-- Speed up Bill�Visit joins
CREATE NONCLUSTERED INDEX IDX_Bills_VisitID
ON Bills (VisitID);


-- Speed up payment history lookup
CREATE NONCLUSTERED INDEX IDX_Payments_BillID
ON Payments (BillID);


-- Speed up Visit�Appointment joins
CREATE NONCLUSTERED INDEX IDX_Visits_AppointmentID
ON Visits (AppointmentID);


-- Speed up prescription retrieval
CREATE NONCLUSTERED INDEX IDX_Prescriptions_VisitID
ON Prescriptions (VisitID);


-- Speed up doctor-specialization filtering
CREATE NONCLUSTERED INDEX IDX_Doctors_SpecializationID
ON Doctors (SpecializationID);



/* Log appointment status changes */

CREATE TRIGGER TRG_Appointment_StatusChange
ON Appointments
AFTER UPDATE
AS
BEGIN

    -- Run only when status is updated
    IF UPDATE(AppointmentStatus)
    BEGIN

        -- Insert old and new status into audit table
        INSERT INTO AppointmentAudit
        (
            AppointmentID,
            OldStatus,
            NewStatus,
            ChangedBy
        )
        SELECT
            i.AppointmentID,
            d.AppointmentStatus,
            i.AppointmentStatus,
            SYSTEM_USER
        FROM inserted i
        JOIN deleted d
            ON i.AppointmentID = d.AppointmentID;

    END
END;


/* Track insert, update, delete on Patients */

CREATE TRIGGER TRG_Patients_Audit
ON Patients
AFTER INSERT, UPDATE, DELETE
AS
BEGIN

    DECLARE @Action NVARCHAR(20);

    -- Detect operation type
    IF EXISTS (SELECT * FROM inserted) 
       AND EXISTS (SELECT * FROM deleted)
        SET @Action = 'UPDATE';

    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @Action = 'INSERT';

    ELSE
        SET @Action = 'DELETE';


    -- Save activity in AuditLogs
    INSERT INTO AuditLogs
    (
        UserName,
        ActionType,
        TableName,
        RecordID
    )
    SELECT
        SYSTEM_USER,
        @Action,
        'Patients',
        ISNULL(i.PatientID, d.PatientID)
    FROM inserted i
    FULL JOIN deleted d
        ON i.PatientID = d.PatientID;

END;

DROP PROCEDURE sp_RegisterPatient;
GO


CREATE PROCEDURE sp_RegisterPatient
(
    @FirstName     NVARCHAR(50),
    @LastName      NVARCHAR(50),
    @DOB           DATE,
    @Gender        NVARCHAR(10),
    @Address       NVARCHAR(100),
    @BloodGroup    NVARCHAR(5),
    @ContactNumber NVARCHAR(15),
    @Email         NVARCHAR(50)
)
AS
BEGIN

    INSERT INTO Patients
    (
        FirstName,
        LastName,
        DOB,
        Gender,
        Address,
        BloodGroup,
        ContactNumber,
        Email
    )
    VALUES
    (
        @FirstName,
        @LastName,
        @DOB,
        @Gender,
        @Address,
        @BloodGroup,
        @ContactNumber,
        @Email
    );

END;
GO


INSERT INTO Patients
(
    FirstName,
    LastName,
    DOB,
    Gender,
    Address,
    BloodGroup,
    ContactNumber,
    Email
)
VALUES
(
    'Aman',
    'Yadav',
    '2001-05-12',
    'Male',
    'Delhi',
    'O+',
    '9878675432',
    'aman@test.com'
);


SELECT * FROM Patients;
SELECT * FROM Doctors;


EXEC sp_helptext sp_RegisterPatient;

CREATE PROCEDURE sp_BookAppointment
(
    @PatientID INT,
    @DoctorID INT,
    @Date DATE,
    @Time TIME
)
AS
BEGIN

    INSERT INTO Appointments
    (
        PatientID,
        DoctorID,
        AppointmentDate,
        AppointmentTime,
        AppointmentStatus
    )
    VALUES
    (
        @PatientID,
        @DoctorID,
        @Date,
        @Time,
        'SCHEDULED'
    );

END;
GO

INSERT INTO Appointments
(
    PatientID,
    DoctorID,
    AppointmentDate,
    AppointmentTime
)
VALUES
(
    1,
    1,
    '2026-02-10',
    '10:30'
);

SELECT * FROM Specializations;

INSERT INTO Specializations (SpecializationName)
VALUES
('Cardiology'),
('Neurology'),
('Orthopedics'),
('Dermatology'),
('Pediatrics'),
('General Medicine');
