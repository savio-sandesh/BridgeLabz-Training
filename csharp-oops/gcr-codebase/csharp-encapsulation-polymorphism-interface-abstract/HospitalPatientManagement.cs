namespace BridgeLabzTraining.csharp_encapsulation_polymorphism_interface_abstract
{
	// Hospital Patient Management System using OOP concepts in C#
	// Demonstrates abstraction, encapsulation, inheritance, interface, and polymorphism
	// Manages in-patients and out-patients with different billing logic

	internal class HospitalPatientManagement
	{
		public static void Main()
		{
			// Polymorphism: base class reference handling different patient types
			List<Patient> patients = new List<Patient>();

			patients.Add(new InPatient(1, "John Doe", 45, 5));
			patients.Add(new OutPatient(2, "Jane Smith", 30, 2));

			foreach (Patient patient in patients)
			{
				Console.WriteLine(patient.GetPatientDetails());
				Console.WriteLine("Total Bill: " + patient.CalculateBill());

				// Interface-based polymorphism for medical records
				if (patient is IMedicalRecord record)
				{
					record.AddRecord("Routine check-up completed.");
					record.ViewRecords();
				}

				Console.WriteLine();
			}
		}
	}

	// Abstract base class defining common patient structure (Abstraction)
	internal abstract class Patient
	{
		// Encapsulation: private setters protect patient identity details
		public int PatientId { get; private set; }

		public string Name { get; private set; }
		public int Age { get; private set; }

		// Encapsulation: sensitive medical data kept private
		private string diagnosis;

		public Patient(int patientId, string name, int age)
		{
			PatientId = patientId;
			Name = name;
			Age = age;
		}

		// Concrete method shared by all patient types
		public string GetPatientDetails()
		{
			return $"Patient ID: {PatientId}, Name: {Name}, Age: {Age}";
		}

		// Abstract method forcing subclasses to implement billing logic
		public abstract double CalculateBill();
	}

	// Interface defining medical record behavior (Abstraction)
	internal interface IMedicalRecord
	{
		void AddRecord(string record);

		void ViewRecords();
	}

	// InPatient class inheriting Patient
	internal class InPatient : Patient, IMedicalRecord
	{
		private int numberOfDays;
		private const double DailyCharge = 2000;
		private List<string> medicalRecords = new List<string>();

		public InPatient(int patientId, string name, int age, int days)
			: base(patientId, name, age)
		{
			numberOfDays = days;
		}

		// Billing logic for in-patients
		public override double CalculateBill()
		{
			return numberOfDays * DailyCharge;
		}

		public void AddRecord(string record)
		{
			medicalRecords.Add(record);
		}

		public void ViewRecords()
		{
			Console.WriteLine("Medical Records (In-Patient):");
			foreach (string record in medicalRecords)
			{
				Console.WriteLine("- " + record);
			}
		}
	}

	// OutPatient class inheriting Patient
	internal class OutPatient : Patient, IMedicalRecord
	{
		private int numberOfVisits;
		private const double VisitCharge = 500;
		private List<string> medicalRecords = new List<string>();

		public OutPatient(int patientId, string name, int age, int visits)
			: base(patientId, name, age)
		{
			numberOfVisits = visits;
		}

		// Billing logic for out-patients
		public override double CalculateBill()
		{
			return numberOfVisits * VisitCharge;
		}

		public void AddRecord(string record)
		{
			medicalRecords.Add(record);
		}

		public void ViewRecords()
		{
			Console.WriteLine("Medical Records (Out-Patient):");
			foreach (string record in medicalRecords)
			{
				Console.WriteLine("- " + record);
			}
		}
	}
}