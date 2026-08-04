-- ===========================================
-- PATIENT TRIGGERS
-- ===========================================

-- After Insert Trigger

create trigger trg_Patient_Insert_Audit
on Patient
After Insert
As
Begin
	insert into Patient_Audit(PatientId, FirstName, LastName, DateOfBirth, Gender, Phone, Email, Address, OperationType)
	select PatientId, FirstName, LastName, DateOfBirth, Gender, Phone, Email, Address, 'INSERT'
	from inserted;
End;
Go


-- Query to test Insert Trigger

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
(
'Virat',
'Kohli',
'1988-11-05',
'Male',
'9999998888',
'virat@gmail.com',
'Delhi'
);

Select * From Patient;
Select * From Patient_Audit;


-- After Update Trigger

create trigger tgr_Patient_Update_Audit
on Patient
After Update
As
Begin
	insert into Patient_Audit(PatientId, FirstName, LastName, DateOfBirth, Gender, Phone, Email, Address, OperationType)
	select PatientId, FirstName, LastName, DateOfBirth, Gender, Phone, Email, Address, 'UPDATE'
	from inserted;
End;
Go


-- Query to test Update Trigger

Update Patient
Set FirstName = 'Rohit',
	LastName = 'Sharma',
	Phone = '8888889999'
Where PatientId = 6;

Select * From Patient;
Select * From Patient_Audit;


-- After Delete Trigger

create trigger tgr_patient_delete
on Patient
After Delete
As
Begin
	insert into Patient_Audit(PatientId, FirstName, LastName, DateOfBirth, Gender, Phone, Email, Address, OperationType)
	select PatientId, FirstName, LastName, DateOfBirth, Gender, Phone, Email, Address, 'DELETE'
	from deleted;
End;
Go


-- Note:
-- The AFTER DELETE trigger executes only if the DELETE operation succeeds.
-- If child records exist (e.g., in Appointment or Patient_Phones),
-- the foreign key constraint prevents deletion, so the trigger will not fire.


-- Query to test Delete Trigger

Delete From Appointment
Where PatientId = 3;

Delete From Patient_Phones
Where PatientId = 3;

Delete From Patient
Where PatientId = 3;

Select * From Patient;
Select * From Appointment;
Select * From Patient_Audit;
Select * From Patient_Phones
Where PatientId = 3;

-- ===========================================
-- DOCTOR TRIGGERS
-- ===========================================


-- After Insert Trigger on Doctor Table

Create Trigger tgr_Doctor_Insert_Audit
On Doctor
After Insert
As
Begin
	insert into Doctor_Audit(DoctorId, FirstName, LastName, Specialization, Phone, Email, OperationType)
	select DoctorId, FirstName, LastName, Specialization, Phone, Email, 'INSERT'
	from inserted;
End;
Go


-- Query to test Insert Trigger

INSERT INTO Doctor
(
    FirstName,
    LastName,
    Specialization,
    Phone,
    Email
)
VALUES
(
'Raj',
'Verma',
'Cardiologist',
'9999997777',
'raj@gmail.com'
);

Select * From Doctor;
Select * From Doctor_Audit;



-- After Update Trigger on Doctor Table

Create Trigger tgr_Doctor_Update_Audit
On Doctor
After Update
As
Begin
	insert into Doctor_Audit(DoctorId, FirstName, LastName, Specialization, Phone, Email, OperationType)
	select DoctorId, FirstName, LastName, Specialization, Phone, Email, 'UPDATE'
	from inserted;
End;
Go


-- Query to test Update Trigger

Update Doctor
Set Phone = '8888887777'
Where DoctorId = 1;

Select * From Doctor;
Select * From Doctor_Audit;



-- After Delete Trigger on Doctor Table

Create Trigger tgr_Doctor_Delete_Audit
On Doctor
After Delete
As
Begin
	insert into Doctor_Audit(DoctorId, FirstName, LastName, Specialization, Phone, Email, OperationType)
	select DoctorId, FirstName, LastName, Specialization, Phone, Email, 'DELETE'
	from deleted;
End;
Go


-- Query to test Delete Trigger

Delete From Doctor
Where DoctorId = 5;

Select * From Doctor;
Select * From Doctor_Audit;

-- ===========================================
-- APPOINTMENT TRIGGERS
-- ===========================================


-- After Insert Trigger on Appointment Table

Create Trigger tgr_Appointment_Insert_Audit
On Appointment
After Insert
As
Begin
	insert into Appointment_Audit(AppointmentId, PatientId, DoctorId, AppointmentDate, AppointmentTime, Reason, Status, OperationType)
	select AppointmentId, PatientId, DoctorId, AppointmentDate, AppointmentTime, Reason, Status, 'INSERT'
	from inserted;
End;
Go


-- Query to test Insert Trigger

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
(
1,
2,
'2026-08-15',
'10:00',
'General Checkup',
'Scheduled'
);

Select * From Appointment;
Select * From Appointment_Audit;



-- After Update Trigger on Appointment Table

Create Trigger tgr_Appointment_Update_Audit
On Appointment
After Update
As
Begin
	insert into Appointment_Audit(AppointmentId, PatientId, DoctorId, AppointmentDate, AppointmentTime, Reason, Status, OperationType)
	select AppointmentId, PatientId, DoctorId, AppointmentDate, AppointmentTime, Reason, Status, 'UPDATE'
	from inserted;
End;
Go


-- Query to test Update Trigger

Update Appointment
Set Status = 'Completed'
Where AppointmentId = 11;

Select * From Appointment;
Select * From Appointment_Audit;



-- After Delete Trigger on Appointment Table

Create Trigger tgr_Appointment_Delete_Audit
On Appointment
After Delete
As
Begin
	insert into Appointment_Audit(AppointmentId, PatientId, DoctorId, AppointmentDate, AppointmentTime, Reason, Status, OperationType)
	select AppointmentId, PatientId, DoctorId, AppointmentDate, AppointmentTime, Reason, Status, 'DELETE'
	from deleted;
End;
Go


-- Query to test Delete Trigger

Delete From Appointment
Where AppointmentId = 23;

Select * From Appointment;
Select * From Appointment_Audit;