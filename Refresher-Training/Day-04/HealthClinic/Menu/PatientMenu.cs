using System;
using System.Collections.Generic;
using HealthClinic.Entity;
using HealthClinic.Interface;

namespace HealthClinic.Menu
{
    // PatientMenu represents the user interface for patient management.
    // It interacts with the user and calls PatientService through interface.
    public class PatientMenu
    {
        // Reference to patient service abstraction.
        private readonly IPatientService patientService;


        // Constructor Injection
        public PatientMenu(IPatientService patientService)
        {
            this.patientService = patientService;
        }


        // Displays patient related operations.
        public void ShowMenu()
        {
            int choice;

            do
            {
                Console.Clear();

                Console.WriteLine("===================================");
                Console.WriteLine("        PATIENT MANAGEMENT");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. View All Patients");
                Console.WriteLine("3. Search Patient By ID");
                Console.WriteLine("4. Update Patient");
                Console.WriteLine("5. Delete Patient");
                Console.WriteLine("0. Back");
                Console.WriteLine("===================================");

                Console.Write("Enter your choice : ");

                choice = Convert.ToInt32(Console.ReadLine());


                switch(choice)
                {
                    case 1:

                        // Create patient object using user input.
                        Patient patient = new Patient();


                        Console.Write("Enter First Name : ");
                        patient.FirstName = Console.ReadLine();


                        Console.Write("Enter Last Name : ");
                        patient.LastName = Console.ReadLine();


                        Console.Write("Enter Date Of Birth (yyyy-mm-dd) : ");
                        patient.DateOfBirth = Convert.ToDateTime(Console.ReadLine());


                        Console.Write("Enter Gender : ");
                        patient.Gender = Console.ReadLine();


                        Console.Write("Enter Phone : ");
                        patient.Phone = Console.ReadLine();


                        Console.Write("Enter Email : ");
                        patient.Email = Console.ReadLine();


                        Console.Write("Enter Address : ");
                        patient.Address = Console.ReadLine();


                        patientService.AddPatient(patient);

                        break;



                    case 2:

                        List<Patient> patients =
                            patientService.GetAllPatients();


                        foreach(Patient item in patients)
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine(item);
                        }

                        break;



                    case 3:

                        Console.Write("Enter Patient ID : ");

                        int patientId =
                            Convert.ToInt32(Console.ReadLine());


                        Patient result =
                            patientService.GetPatientById(patientId);


                        if(result != null)
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine("Patient not found.");
                        }

                        break;



                    case 4:

                        Patient updatePatient = new Patient();


                        Console.Write("Enter Patient ID : ");
                        updatePatient.PatientId =
                            Convert.ToInt32(Console.ReadLine());


                        Console.Write("Enter First Name : ");
                        updatePatient.FirstName =
                            Console.ReadLine();


                        Console.Write("Enter Last Name : ");
                        updatePatient.LastName =
                            Console.ReadLine();


                        Console.Write("Enter Date Of Birth : ");
                        updatePatient.DateOfBirth =
                            Convert.ToDateTime(Console.ReadLine());


                        Console.Write("Enter Gender : ");
                        updatePatient.Gender =
                            Console.ReadLine();


                        Console.Write("Enter Phone : ");
                        updatePatient.Phone =
                            Console.ReadLine();


                        Console.Write("Enter Email : ");
                        updatePatient.Email =
                            Console.ReadLine();


                        Console.Write("Enter Address : ");
                        updatePatient.Address =
                            Console.ReadLine();


                        patientService.UpdatePatient(updatePatient);

                        break;



                    case 5:

                        Console.Write("Enter Patient ID : ");

                        int deleteId =
                            Convert.ToInt32(Console.ReadLine());


                        patientService.DeletePatient(deleteId);

                        break;



                    case 0:

                        Console.WriteLine("Returning to Main Menu...");
                        break;



                    default:

                        Console.WriteLine("Invalid choice.");
                        break;
                }


                if(choice != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }


            } while(choice != 0);
        }
    }
}