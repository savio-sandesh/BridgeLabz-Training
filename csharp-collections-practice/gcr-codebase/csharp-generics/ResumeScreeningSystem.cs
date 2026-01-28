using System;
using System.Collections.Generic;

namespace ResumeScreeningSystem
{
    // Abstract Job Role
    abstract class JobRole
    {
        public string CandidateName { get; set; }
        public int Experience { get; set; }

        protected JobRole(string candidateName, int experience)
        {
            CandidateName = candidateName;
            Experience = experience;
        }

        public abstract void DisplayRoleDetails();
    }

    // Software Engineer Role
    class SoftwareEngineer : JobRole
    {
        public string ProgrammingLanguage { get; set; }

        public SoftwareEngineer(string candidateName, int experience, string language)
            : base(candidateName, experience)
        {
            ProgrammingLanguage = language;
        }

        public override void DisplayRoleDetails()
        {
            Console.WriteLine("Job Role: Software Engineer");
            Console.WriteLine("Candidate Name: " + CandidateName);
            Console.WriteLine("Experience (Years): " + Experience);
            Console.WriteLine("Primary Language: " + ProgrammingLanguage);
        }
    }

    // Data Scientist Role
    class DataScientist : JobRole
    {
        public string Domain { get; set; }

        public DataScientist(string candidateName, int experience, string domain)
            : base(candidateName, experience)
        {
            Domain = domain;
        }

        public override void DisplayRoleDetails()
        {
            Console.WriteLine("Job Role: Data Scientist");
            Console.WriteLine("Candidate Name: " + CandidateName);
            Console.WriteLine("Experience (Years): " + Experience);
            Console.WriteLine("Domain Expertise: " + Domain);
        }
    }

    // Generic Resume Class with Constraint
    class Resume<T> where T : JobRole
    {
        private List<T> resumes = new List<T>();

        public void AddResume(T resume)
        {
            resumes.Add(resume);
            Console.WriteLine("Resume added to screening pipeline.");
            Console.WriteLine();
        }

        public void DisplayResumes()
        {
            if (resumes.Count == 0)
            {
                Console.WriteLine("No resumes available for this role.");
                Console.WriteLine();
                return;
            }

            foreach (T resume in resumes)
            {
                resume.DisplayRoleDetails();
                Console.WriteLine();
            }
        }
    }

    // Utility Class with Generic Method
    class ResumeScreeningUtility
    {
        public static void ScreenResume<T>(T resume) where T : JobRole
        {
            Console.WriteLine("Screening Resume:");
            resume.DisplayRoleDetails();
            Console.WriteLine("Resume screening completed.");
            Console.WriteLine();
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Resume<SoftwareEngineer> softwareEngineerResumes = new Resume<SoftwareEngineer>();
            Resume<DataScientist> dataScientistResumes = new Resume<DataScientist>();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("AI-Driven Resume Screening System :");
                Console.WriteLine("1. Add Software Engineer Resume");
                Console.WriteLine("2. Add Data Scientist Resume");
                Console.WriteLine("3. View Software Engineer Resumes");
                Console.WriteLine("4. View Data Scientist Resumes");
                Console.WriteLine("5. Exit");
                Console.Write("Please enter your menu choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                    Console.WriteLine();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Candidate Name: ");
                        string seName = Console.ReadLine() ?? "";

                        Console.Write("Enter Years of Experience: ");
                        int seExperience = int.Parse(Console.ReadLine() ?? "0");

                        Console.Write("Enter Primary Programming Language: ");
                        string language = Console.ReadLine() ?? "";

                        SoftwareEngineer softwareEngineer =
                            new SoftwareEngineer(seName, seExperience, language);

                        softwareEngineerResumes.AddResume(softwareEngineer);
                        ResumeScreeningUtility.ScreenResume(softwareEngineer);
                        break;

                    case 2:
                        Console.Write("Enter Candidate Name: ");
                        string dsName = Console.ReadLine() ?? "";

                        Console.Write("Enter Years of Experience: ");
                        int dsExperience = int.Parse(Console.ReadLine() ?? "0");

                        Console.Write("Enter Domain Expertise: ");
                        string domain = Console.ReadLine() ?? "";

                        DataScientist dataScientist =
                            new DataScientist(dsName, dsExperience, domain);

                        dataScientistResumes.AddResume(dataScientist);
                        ResumeScreeningUtility.ScreenResume(dataScientist);
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Software Engineer Resumes :");
                        softwareEngineerResumes.DisplayResumes();
                        break;

                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Data Scientist Resumes :");
                        dataScientistResumes.DisplayResumes();
                        break;

                    case 5:
                        exit = true;
                        Console.WriteLine("Exiting AI-Driven Resume Screening System.");
                        break;

                    default:
                        Console.WriteLine("Invalid menu selection.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
