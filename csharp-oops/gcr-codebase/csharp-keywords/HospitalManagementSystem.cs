namespace BridgeLabzTraining.csharp_keywords
{
	// patient class
	// uses static members for shared hospital data,
	// readonly patient id for unique identification,
	// this keyword for constructor initialization,
	// and is operator for safe type checking

	internal class Patient
	{
		// static member shared by all patients
		public static string HospitalName = "All India Institute Of Medical Science";

		// static counter
		private static int totalPatients = 0;

		// readonly member
		public readonly long PatientID;

		// instance members
		public string Name;

		public int Age;
		public string Ailment;

		// stores all patients
		private static List<Patient> patientList = new List<Patient>();

		// parameterized constructor
		public Patient(long patientID, string name, int age, string ailment)
		{
			this.PatientID = patientID;
			this.Name = name;
			this.Age = age;
			this.Ailment = ailment;
			totalPatients++;
			patientList.Add(this);
		}

		// displays patient details
		public void DisplayPatientDetails()
		{
			Console.WriteLine("Hospital Name : " + HospitalName);
			Console.WriteLine("Patient ID    : " + PatientID);
			Console.WriteLine("Patient Name  : " + Name);
			Console.WriteLine("Age           : " + Age);
			Console.WriteLine("Ailment       : " + Ailment);
		}

		// static method to get total patients
		public static void GetTotalPatients()
		{
			Console.WriteLine("Total Patients : " + totalPatients);
		}

		// displays all patients using is operator
		public static void DisplayAllPatients()
		{
			foreach (object obj in patientList)
			{
				if (obj is Patient patient)
				{
					patient.DisplayPatientDetails();
					Console.WriteLine();
				}
			}
		}
	}

	internal class HospitalManagementSystem
	{
		private static void Main()
		{
			string choice;

			do
			{
				Console.Write("Enter Patient ID : ");
				long id = Convert.ToInt64(Console.ReadLine());

				Console.Write("Enter Patient Name : ");
				string name = Console.ReadLine();

				Console.Write("Enter Age : ");
				int age = Convert.ToInt32(Console.ReadLine());

				Console.Write("Enter Ailment : ");
				string ailment = Console.ReadLine();

				new Patient(id, name, age, ailment);

				Console.Write("Would you like to add more patients? (yes/no) : ");
				choice = Console.ReadLine().ToLower();

				Console.WriteLine();
			} while (choice == "yes");

			Patient.DisplayAllPatients();
			Patient.GetTotalPatients();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}