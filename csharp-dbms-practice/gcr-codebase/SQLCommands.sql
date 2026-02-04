--CREATE DATABASE PracticeDB;

USE PracticeDB;

-- DML Commands Practice

CREATE TABLE Students(
	StudentID INT Primary key,
	Name VARCHAR(50),
	Age INT,
	Department VARCHAR(30)
);


-- shows you the structure of thetable
-- for 
--SELECT * 
--FROM INFORMATION_SCHEMA.COLUMNS
--WHERE TABLE_NAME = 'Students';


USE PracticeDB;
GO

INSERT INTO Students
VALUES(1,'Sandesh',22,'CSE');

INSERT INTO Students
VALUES(2,'Aman',22,'EE');

INSERT INTO Students
VALUES(3,'Savio',21,'ECE');

SELECT * FROM Students;

-- Change the structure of an existing table
-- (without deleting data)
-- ALTER (DDL command)
ALTER TABLE Students
ADD Email VARCHAR(100);

-- DQL - View All Data
-- Check what is inside the table
SELECT * FROM Students;

-- data updation (UPDATE -- dml command)
UPDATE Students
SET Email = 'aman@gmail.com'
WHERE StudentID = 2;

UPDATE Students
SET Email = 'sandesh.cse00@gmail.com'
WHERE StudentID = 1;


--  creating a new table
CREATE TABLE Professor(
	ProfessorID INT Primary key,
	Name VARCHAR(50),
	Department VARCHAR(30)
);

SELECT * FROM Professor;


-- adding data to the table(INSERT--DML ommand)
INSERT INTO Professor
VALUES(1234,'Krishnan Iyyer','CSE');

INSERT INTO Professor
VALUES(1223,'Tukaram Shinde','ECE');

INSERT INTO Professor
VALUES(1901,'Ayyangar Swami','EE');

-- data deleted (DELETE--DML command)
DELETE FROM Professor
WHERE ProfessorID =1901;

-- permanently remove professor table(DROP -- DDL Command)
DROP TABLE Professor;

-- create a new table Courses
CREATE TABLE Courses(
	CourseID INT,
	CourseName VARCHAR(100),
	Department VARCHAR(50)
);

SELECT *FROM Courses;

INSERT INTO Courses
VALUES(0011,'Electrical Engineering','EE');

INSERT INTO Courses
VALUES(0021,'Mechanical Engineering','CE');

INSERT INTO Courses
VALUES(0013,'Computer Science Engineering','CSE');

-- remove all the rows from a table
-- keep table structure
-- TRUNCATE(DDL Command)

TRUNCATE TABLE Courses;


-- tcl command (Commit savepoint rollback)
-- COMMIT(TCL command)
BEGIN TRANSACTION;

UPDATE Students
SET Department = 'IT'
WHERE StudentID = 2;

UPDATE Students
SET Department = 'IT'
WHERE StudentID = 3;

COMMIT;

SELECT * FROM Students;


-- ROLLBACK (TCL command)
BEGIN TRANSACTION;

UPDATE Students
SET Age = 30
WHERE StudentID = 1;

SELECT * FROM Students;

ROLLBACK;

SELECT * FROM Students;


-- DCL: Create a Login (Server Level)
CREATE LOGIN testuser
WITH PASSWORD = 'test@2912';

-- creating user in database 
USE PracticeDB;
GO

CREATE USER testuser
FOR LOGIN testuser;

-- DCL: Grant Permissions
GRANT SELECT, INSERT
ON Students
TO testuser;

-- we can verify grant permission
--databases->practicedb->security->testuser ^_^.

-- Revoke Permission
REVOKE INSERT
ON Students
FROM testuser;
