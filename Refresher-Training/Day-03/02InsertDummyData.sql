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