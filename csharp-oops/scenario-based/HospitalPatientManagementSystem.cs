namespace BridgeLabzTraining.scenario_based
{
	// hospital patient management system
	// demonstrates encapsulation, abstraction, inheritance, and polymorphism
	// manages patients, doctors, and billing in a hospital scenario

	// interface for bill payment behavior

	internal class HospitalPatientManagementSystem
	{
		// main method to execute the program
		private static void Main(string[] args)
		{
			// creating doctor object
			Doctor doctor = new Doctor(101, "dr. sharma", "cardiology");
			doctor.DisplayDoctorInfo();

			Console.WriteLine();

			// creating in-patient object
			Patient inPatient = new InPatient(1, "rahul", 5, 2000);
			inPatient.DisplayInfo();

			Console.WriteLine();

			// creating out-patient object
			Patient outPatient = new OutPatient(2, "anita", 800);
			outPatient.DisplayInfo();

			Console.WriteLine();

			// generating bill using bill class
			Bill bill = new Bill();
			bill.GenerateBill((IPayable)inPatient);
			bill.GenerateBill((IPayable)outPatient);
		}

		internal interface IPayable
		{
			double CalculateBill();
		}

		// base class representing a patient
		internal class Patient
		{
			protected int patientId;
			protected string patientName;

			// constructor to initialize patient details
			public Patient(int patientId, string patientName)
			{
				this.patientId = patientId;
				this.patientName = patientName;
			}

			// virtual method for polymorphic behavior
			public virtual void DisplayInfo()
			{
				Console.WriteLine($"patient id: {patientId}");
				Console.WriteLine($"patient name: {patientName}");
			}
		}

		// derived class for in-patient
		internal class InPatient : Patient, IPayable
		{
			private int numberOfDays;
			private double dailyCharge;

			public InPatient(int patientId, string patientName, int numberOfDays, double dailyCharge)
				: base(patientId, patientName)
			{
				this.numberOfDays = numberOfDays;
				this.dailyCharge = dailyCharge;
			}

			// calculates bill based on stay duration
			public double CalculateBill()
			{
				return numberOfDays * dailyCharge;
			}

			public override void DisplayInfo()
			{
				base.DisplayInfo();
				Console.WriteLine("patient type: in-patient");
				Console.WriteLine($"total bill: {CalculateBill()}");
			}
		}

		// derived class for out-patient
		internal class OutPatient : Patient, IPayable
		{
			private double consultationFee;

			public OutPatient(int patientId, string patientName, double consultationFee)
				: base(patientId, patientName)
			{
				this.consultationFee = consultationFee;
			}

			// calculates consultation bill
			public double CalculateBill()
			{
				return consultationFee;
			}

			public override void DisplayInfo()
			{
				base.DisplayInfo();
				Console.WriteLine("patient type: out-patient");
				Console.WriteLine($"total bill: {CalculateBill()}");
			}
		}

		// class representing a doctor
		internal class Doctor
		{
			public int DoctorId { get; set; }
			public string DoctorName { get; set; }
			public string Specialization { get; set; }

			// constructor to initialize doctor details
			public Doctor(int doctorId, string doctorName, string specialization)
			{
				DoctorId = doctorId;
				DoctorName = doctorName;
				Specialization = specialization;
			}

			// displays doctor information
			public void DisplayDoctorInfo()
			{
				Console.WriteLine($"doctor id: {DoctorId}");
				Console.WriteLine($"doctor name: {DoctorName}");
				Console.WriteLine($"specialization: {Specialization}");
			}
		}

		// separate bill class to handle billing display
		internal class Bill
		{
			// prints bill amount for payable entities
			public void GenerateBill(IPayable payable)
			{
				Console.WriteLine($"generated bill amount: {payable.CalculateBill()}");
			}
		}
	}
}