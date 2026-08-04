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