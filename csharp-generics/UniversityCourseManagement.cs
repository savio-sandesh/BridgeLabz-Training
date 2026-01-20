using System;
using System.Collections.Generic;

namespace UniversityCourseManagement
{
    // Covariant interface for read-only access
    interface ICourseViewer<out T>
    {
        void DisplayCourses();
    }

    // Abstract base class
    abstract class CourseType
    {
        public string CourseName { get; set; }
        public int Credits { get; set; }

        protected CourseType(string courseName, int credits)
        {
            CourseName = courseName;
            Credits = credits;
        }

        public abstract void DisplayEvaluation();
    }

    // Exam-based course
    class ExamCourse : CourseType
    {
        public int ExamDuration { get; set; }

        public ExamCourse(string courseName, int credits, int examDuration)
            : base(courseName, credits)
        {
            ExamDuration = examDuration;
        }

        public override void DisplayEvaluation()
        {
            Console.WriteLine("Evaluation Type: Written Exam");
            Console.WriteLine("Exam Duration (Minutes): " + ExamDuration);
        }
    }

    // Assignment-based course
    class AssignmentCourse : CourseType
    {
        public int NumberOfAssignments { get; set; }

        public AssignmentCourse(string courseName, int credits, int assignments)
            : base(courseName, credits)
        {
            NumberOfAssignments = assignments;
        }

        public override void DisplayEvaluation()
        {
            Console.WriteLine("Evaluation Type: Assignments");
            Console.WriteLine("Number of Assignments: " + NumberOfAssignments);
        }
    }

    // Generic Course class with constraint
    class Course<T> : ICourseViewer<T> where T : CourseType
    {
        private List<T> courses = new List<T>();

        public void AddCourse(T course)
        {
            courses.Add(course);
            Console.WriteLine("Course added successfully.");
            Console.WriteLine();
        }

        public void DisplayCourses()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses available.");
                Console.WriteLine();
                return;
            }

            foreach (T course in courses)
            {
                Console.WriteLine("Course Name: " + course.CourseName);
                Console.WriteLine("Credits: " + course.Credits);
                course.DisplayEvaluation();
                Console.WriteLine();
            }
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Course<ExamCourse> examCourses = new Course<ExamCourse>();
            Course<AssignmentCourse> assignmentCourses = new Course<AssignmentCourse>();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("University Course Management System :");
                Console.WriteLine("1. Add Exam Based Course");
                Console.WriteLine("2. Add Assignment Based Course");
                Console.WriteLine("3. View Exam Based Courses");
                Console.WriteLine("4. View Assignment Based Courses");
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
                        Console.Write("Enter Course Name: ");
                        string examCourseName = Console.ReadLine() ?? "";

                        Console.Write("Enter Course Credits: ");
                        int examCredits = int.Parse(Console.ReadLine() ?? "0");

                        Console.Write("Enter Exam Duration in Minutes: ");
                        int duration = int.Parse(Console.ReadLine() ?? "0");

                        examCourses.AddCourse(
                            new ExamCourse(examCourseName, examCredits, duration)
                        );
                        break;

                    case 2:
                        Console.Write("Enter Course Name: ");
                        string assignmentCourseName = Console.ReadLine() ?? "";

                        Console.Write("Enter Course Credits: ");
                        int assignmentCredits = int.Parse(Console.ReadLine() ?? "0");

                        Console.Write("Enter Number of Assignments: ");
                        int assignments = int.Parse(Console.ReadLine() ?? "0");

                        assignmentCourses.AddCourse(
                            new AssignmentCourse(assignmentCourseName, assignmentCredits, assignments)
                        );
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Exam Based Courses :");
                        ICourseViewer<CourseType> examViewer = examCourses;
                        examViewer.DisplayCourses();
                        break;

                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Assignment Based Courses :");
                        ICourseViewer<CourseType> assignmentViewer = assignmentCourses;
                        assignmentViewer.DisplayCourses();
                        break;

                    case 5:
                        exit = true;
                        Console.WriteLine("Exiting University Course Management System.");
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
