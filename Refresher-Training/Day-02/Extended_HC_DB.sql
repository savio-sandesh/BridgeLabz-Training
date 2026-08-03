
USE Health_Clinic;
GO


-- PATIENT TABLE

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

    CONSTRAINT CHK_Patient_Gender
    CHECK (Gender IN ('Male', 'Female', 'Other'))
);

GO


-- DOCTOR TABLE

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


-- APPOINTMENT TABLE

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

CREATE TABLE Room
(
    RoomId INT IDENTITY(1,1) PRIMARY KEY,
    RoomNumber VARCHAR(20) UNIQUE,
    FloorNo INT,
    RoomType VARCHAR(50)
);

-- changes in doctor table

ALTER TABLE Doctor
ADD RoomId INT;

ALTER TABLE Doctor
ADD CONSTRAINT FK_Doctor_Room
FOREIGN KEY(RoomId)
REFERENCES Room(RoomId);

SELECT * From Patient;
SELECT * From Doctor;
SELECT * From Appointment;
SELECT * From Room;


--3 different queries against the appointments table 
--one with no index, one using a single-column index, one --using the composite index — and
--note the differences in the type and rows columns.


-- Insert Rooms Data
INSERT INTO Room (RoomNumber, FloorNo, RoomType)
VALUES
('R101', 1, 'Consultation'),
('R102', 1, 'Consultation'),
('R201', 2, 'Consultation'),
('R202', 2, 'Consultation');
('R203', 2, 'Surgery');
('R204', 2, 'Surgery');


--Insert Doctors Data
INSERT INTO Doctor
(
    FirstName,
    LastName,
    Specialization,
    Phone,
    Email,
    RoomId
)
VALUES
('Amit','Sharma','Cardiologist','9876500001','amit@clinic.com',1),
('Priya','Mehta','Dermatologist','9876500002','priya@clinic.com',2),
('Rahul','Verma','Orthopedic','9876500003','rahul@clinic.com',3),
('Neha','Singh','Neurologist','9876500004','neha@clinic.com',4);

--Insert Patient Data
INSERT INTO Patient
(
    FirstName,
    LastName,
    DateOfBirth,
    Gender,
    Phone,
    Email,
    Address
)
VALUES
('Sandesh','Kumar','2003-08-12','Male','9871111111','sandesh@gmail.com','Mathura'),
('Rohan','Gupta','1999-02-15','Male','9871111112','rohan@gmail.com','Delhi'),
('Anjali','Sharma','2001-06-20','Female','9871111113','anjali@gmail.com','Agra'),
('Sneha','Verma','1998-10-10','Female','9871111114','sneha@gmail.com','Noida'),
('Aman','Yadav','2002-01-05','Male','9871111115','aman@gmail.com','Lucknow'),
('Pooja','Singh','2000-12-25','Female','9871111116','pooja@gmail.com','Kanpur');

--Insert Appointment Data
INSERT INTO Appointment
(
    PatientId,
    DoctorId,
    AppointmentDate,
    AppointmentTime,
    Reason,
    Status
)
VALUES
(1,1,'2026-08-01','09:00','Fever','Completed'),
(2,1,'2026-08-01','09:30','Chest Pain','Completed'),
(3,2,'2026-08-02','10:00','Skin Allergy','Scheduled'),
(4,3,'2026-08-02','10:30','Back Pain','Scheduled'),
(5,4,'2026-08-03','11:00','Headache','Completed'),
(6,2,'2026-08-03','11:30','Rash','Cancelled'),
(1,3,'2026-08-04','09:00','Knee Pain','Completed'),
(2,4,'2026-08-04','09:30','Migraine','Scheduled'),
(3,1,'2026-08-05','10:00','Heart Checkup','Scheduled'),
(4,2,'2026-08-05','10:30','Acne','Completed'),
(5,3,'2026-08-06','11:00','Fracture','Scheduled'),
(6,4,'2026-08-06','11:30','Nerve Pain','Completed'),
(1,2,'2026-08-07','09:00','Skin Infection','Scheduled'),
(2,3,'2026-08-07','09:30','Shoulder Pain','Completed'),
(3,4,'2026-08-08','10:00','Dizziness','Scheduled'),
(4,1,'2026-08-08','10:30','ECG','Completed'),
(5,2,'2026-08-09','11:00','Hair Fall','Scheduled'),
(6,3,'2026-08-09','11:30','Joint Pain','Completed'),
(1,4,'2026-08-10','09:00','Brain Checkup','Scheduled'),
(2,1,'2026-08-10','09:30','BP Check','Completed');


-- no index (by default cluster index)
SELECT *
FROM Appointment
WHERE PatientId = 3;

-- one using a single-column index
create index IN_Appointment_PatientId
on Appointment(PatientId);

--using the composite index
create index IN_Appointment_Doctor_Date
on Appointment(DoctorId, AppointmentDate);

-- SQL Server's Query Optimizer chooses the execution plan with the lowest estimated cost.
-- For a small table or when using SELECT *, a Clustered Index Scan may be 
-- cheaper than using a non-clustered composite index followed by Key Lookups. 
-- Therefore, creating an index does not guarantee that SQL Server will use it.
-- in both above cases single-column index and composite index there is only 20 rows.
-- Single-column index: Index Seek (when selecting only the indexed column).



--3.Take the patient_phones design and verify it satisfies 1NF, 2NF, and 3NF — 
--write a short justification for each.

-- CREATING A NEW TABLE NAMED PATIENT_PHONES
CREATE TABLE Patient_Phones
(
    PatientId INT,
    Phone VARCHAR(15),

    PRIMARY KEY (PatientId, Phone),

    FOREIGN KEY (PatientId)
    REFERENCES Patient(PatientId)
);

--ENTERING SOME VALUES TO ABOVE TABLE
INSERT INTO Patient_Phones
VALUES
(1,'9871111111'),
(1,'9123456789'),
(2,'9872222222'),
(3,'9873333333'),
(3,'9998887776');


--Create a covering index for a query that reports doctor_id, appointment_date,
--status from the appointments table, and verify with EXPLAIN that Extra shows Using index.


CREATE INDEX IN_APPOINTMENT_DOCTORID_STATUS
ON Appointment
(
    DoctorId,
    AppointmentDate,
    Status
);