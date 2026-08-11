Create Database ContactDB;
Go

Use ContactDB;
Go

Create Table Contacts(
		ContactId int identity(1,1) Primary Key, -- Unique identifier
		FirstName NVarchar(50) Not Null,		 -- Contact's first name
		LastName NVarchar(50) Not Null,			 -- Contact's last name
		Email Varchar(150) Not Null,			 -- Email address
		PhoneNumber Varchar(15) Not Null,		 -- Contact Number
		CreatedAt Datetime2 Not Null			 -- Creation Timestamp
		Default Sysutcdatetime(),				 
		IsActive Bit Not Null					 -- Soft deletion
		Default 1
);
Go


Alter Table Contacts
Add Constraint UQ_Contact_Email
Unique (Email);
Go


-- Indexing 
Create Index IX_Contacts_LastName
On Contacts(LastName);
Go

Create Index IX_Contacts_PhoneNumber
On Contacts(PhoneNumber);
GO

-- Store Procedures

-- Get all contacts
Create Procedure sp_GetAllContacts
As
Begin
	Select ContactId,
			FirstName,
			LastName,
			Email,
			PhoneNumber,
			CreatedAt,
			IsActive
		From Contacts
		Where IsActive = 1;
END;
GO

-- Get contact by ID
Create Procedure sp_GetContactsById
	@ContactId Int
As
Begin
	Select ContactId,
			FirstName,
			LastName,
			Email,
			PhoneNumber,
			CreatedAt,
			IsActive
		From Contacts
		Where ContactId = @ContactId;
End;
Go

-- Insert contact
Create Procedure sp_AddContact
		@FirstName NVarchar(50),		 
		@LastName NVarchar(50),			
		@Email Varchar(150),			
		@PhoneNumber Varchar(15)
As 
Begin
	Insert into Contacts
	(
		FirstName,
        LastName,
        Email,
        PhoneNumber
    )
    Values
    (
        @FirstName,
        @LastName,
        @Email,
        @PhoneNumber
    );

	-- SCOPE_IDENTITY() returns the last identity value generated in the current scope and session.
	-- It is commonly used after INSERT operations to retrieve the newly generated primary key value, especially for tables using IDENTITY columns.
	Select SCOPE_IDENTITY() As ContactId;
End;
Go

-- Update Contact Stored Procedure
Create Procedure sp_UpdateContact
    @ContactId Int,
    @FirstName Nvarchar(50),
    @LastName Nvarchar(50),
    @Email Varchar(150),
    @PhoneNumber Varchar(15)
As
Begin

    If Exists(Select 1 From Contacts Where ContactId = @ContactId)
    Begin

        Update Contacts
        Set
            FirstName = @FirstName,
            LastName = @LastName,
            Email = @Email,
            PhoneNumber = @PhoneNumber
        Where ContactId = @ContactId;

    End

End;
Go

-- Delete Contact Stored Procedure
Create Procedure sp_DeleteContact
    @ContactId Int
As
Begin

    Update Contacts
    Set
        IsActive = 0
    Where ContactId = @ContactId;

End;
Go


-- Triggers

-- Creating a AuditTable First 
Create Table ContactAudit
(
    AuditId Int Identity(1,1) Primary Key,

    ContactId Int Not Null,

    ActionType Varchar(20) Not Null,

    ActionDate DateTime2 Not Null
        Default SysUTCDateTime()
);
Go

Create Trigger trg_Conatact_Update
On Contacts
After update
As
Begin
	Insert into ContactAudit(
		ContactId,
		ActionType
		)
	Select ContactId,'Updated'
	From inserted;
End;
Go


-- Inserting Data Into Contacts
Insert Contacts
(
    FirstName,
    LastName,
    Email,
    PhoneNumber
)
Values
('Rahul', 'Sharma', 'rahul@gmail.com', '9876543210'),

('Aman', 'Verma', 'aman@gmail.com', '9876543211'),

('Priya', 'Singh', 'priya@gmail.com', '9876543212');
Go

Select*From Contacts;

EXEC sp_help Contacts;