-- Day-03

create table Patient_Audit(

	-- to store the audit information of the patient table
	AuditId int identity(1,1) primary key,
	AuditDate datetime not null default getdate(),
	PatientId int not null,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	DateOfBirth date not null,
	Gender varchar(20),
	Phone varchar(15),
	Email varchar(100),
	Address varchar(200),

	-- to insert what kind of operation was performed 
	-- on the patient table (insert, update, delete)
	OperationType varchar(20) not null
);


create table Doctor_Audit(

	-- to store the audit information of the doctor table
	-- primmary key for audit table 
	AuditId int identity(1,1) primary key,

	-- to store the date and time when the operation was performed
	AuditDate datetime not null default getdate(),

	DoctorId int not null,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	Specialization varchar(100),
	Phone varchar(15),
	Email varchar(100),
	RoomId int,

	-- to insert what kind of operation was performed 
	-- on the doctor table (insert, update, delete)
	OperationType varchar(20) not null
);

Create Table Appointment_Audit
(
    -- Audit Table Primary Key
    AuditId Int Identity(1,1) Primary Key,

    -- Date and Time of Operation
    AuditDate DateTime Not Null Default GetDate(),

    -- Appointment Details
    AppointmentId Int Not Null,
    PatientId Int Not Null,
    DoctorId Int Not Null,
    AppointmentDate Date Not Null,
    AppointmentTime Time Not Null,
    Reason Varchar(255),
    Status Varchar(20),

    -- Type of Operation
    OperationType Varchar(20) Not Null
);