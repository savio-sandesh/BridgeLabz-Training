--3 different queries against the appointments table 
--one with no index, one using a single-column index, one --using the composite index — and
--note the differences in the type and rows columns.


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



--Create a covering index for a query that reports doctor_id, appointment_date,
--status from the appointments table, and verify with EXPLAIN that Extra shows Using index.


CREATE INDEX IN_APPOINTMENT_DOCTORID_STATUS
ON Appointment
(
    DoctorId,
    AppointmentDate,
    Status
);