namespace BridgeLabzTraining
{
	// patient class
	internal class Patient
	{
		public string Name;

		public Patient(string name)
		{
			Name = name;
		}
	}

	// doctor class
	internal class Doctor
	{
		public string Name;
		public List<Patient> patients;

		public Doctor(string name)
		{
			Name = name;
			patients = new List<Patient>();
		}

		// communication between doctor and patient
		public void Consult(Patient patient)
		{
			patients.Add(patient);
			Console.WriteLine("Doctor " + Name + " consulted patient " + patient.Name);
		}

		public void ShowPatients()
		{
			Console.WriteLine("Patients of Doctor " + Name + " :");
			foreach (Patient p in patients)
			{
				Console.WriteLine("  " + p.Name);
			}
		}
	}

	internal class HospitalDoctorAndPatients
	{
		private static void Main()
		{
			Doctor d1 = new Doctor("Agarwal");
			Doctor d2 = new Doctor("Verma");

			Patient p1 = new Patient("Sandesh");
			Patient p2 = new Patient("Riya");

			d1.Consult(p1);
			d1.Consult(p2);
			d2.Consult(p1);

			Console.WriteLine();

			d1.ShowPatients();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}