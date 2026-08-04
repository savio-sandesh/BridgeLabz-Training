-- ===========================================
-- PATIENT STORED PROCEDURES
-- ===========================================


-- Get All Patients

Create Procedure sp_GetAllPatients
As
Begin

    Select *
    From Patient;

End;
Go



-- Insert Patient

Create Procedure sp_InsertPatient
(
    @FirstName Varchar(50),
    @LastName Varchar(50),
    @DateOfBirth Date,
    @Gender Varchar(20),
    @Phone Varchar(15),
    @Email Varchar(100),
    @Address Varchar(255)
)
As
Begin

    Insert Into Patient
    (
        FirstName,
        LastName,
        DateOfBirth,
        Gender,
        Phone,
        Email,
        Address
    )
    Values
    (
        @FirstName,
        @LastName,
        @DateOfBirth,
        @Gender,
        @Phone,
        @Email,
        @Address
    );

End;
Go



-- Get Patient By Id

Create Procedure sp_GetPatientById
(
    @PatientId Int
)
As
Begin

    Select *
    From Patient
    Where PatientId = @PatientId;

End;
Go



-- Update Patient

Create Procedure sp_UpdatePatient
(
    @PatientId Int,
    @FirstName Varchar(50),
    @LastName Varchar(50),
    @DateOfBirth Date,
    @Gender Varchar(20),
    @Phone Varchar(15),
    @Email Varchar(100),
    @Address Varchar(255)
)
As
Begin

    Update Patient
    Set
        FirstName = @FirstName,
        LastName = @LastName,
        DateOfBirth = @DateOfBirth,
        Gender = @Gender,
        Phone = @Phone,
        Email = @Email,
        Address = @Address

    Where PatientId = @PatientId;

End;
Go



-- Delete Patient

Create Procedure sp_DeletePatient
(
    @PatientId Int
)
As
Begin

    Begin Transaction;

    Begin Try

        Delete From Appointment
        Where PatientId = @PatientId;


        Delete From Patient_Phones
        Where PatientId = @PatientId;


        Delete From Patient
        Where PatientId = @PatientId;


        Commit Transaction;

        Print 'Patient Deleted Successfully';

    End Try

    Begin Catch

        Rollback Transaction;

        Print Error_Message();

    End Catch

End;
Go



-- ===========================================
-- APPOINTMENT STORED PROCEDURES
-- ===========================================


-- Update Appointment Status

Create Procedure sp_UpdateAppointmentStatus
(
    @AppointmentId Int,
    @Status Varchar(20)
)
As
Begin

    If @Status Not In ('Scheduled','Completed','Cancelled')
    Begin

        Print 'Invalid Status';
        Return;

    End


    Update Appointment
    Set Status = @Status
    Where AppointmentId = @AppointmentId;


    Print 'Appointment Status Updated Successfully';

End;
Go



-- Get Patient Appointments

Create Procedure sp_GetPatientAppointments
(
    @PatientId Int
)
As
Begin

    Select *
    From Appointment
    Where PatientId = @PatientId;

End;
Go