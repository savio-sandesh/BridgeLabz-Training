using System;
using System.Collections.Generic;

namespace PersonalizedMealPlanGenerator
{
    // Meal Plan Interface
    interface IMealPlan
    {
        string GetMealType();
        void DisplayMealDetails();
    }

    // Vegetarian Meal
    class VegetarianMeal : IMealPlan
    {
        public string MainDish { get; set; }

        public VegetarianMeal(string mainDish)
        {
            MainDish = mainDish;
        }

        public string GetMealType()
        {
            return "Vegetarian Meal";
        }

        public void DisplayMealDetails()
        {
            Console.WriteLine("Meal Type: Vegetarian");
            Console.WriteLine("Main Dish: " + MainDish);
        }
    }

    // Vegan Meal
    class VeganMeal : IMealPlan
    {
        public string MainDish { get; set; }

        public VeganMeal(string mainDish)
        {
            MainDish = mainDish;
        }

        public string GetMealType()
        {
            return "Vegan Meal";
        }

        public void DisplayMealDetails()
        {
            Console.WriteLine("Meal Type: Vegan");
            Console.WriteLine("Main Dish: " + MainDish);
        }
    }

    // Keto Meal
    class KetoMeal : IMealPlan
    {
        public string MainDish { get; set; }

        public KetoMeal(string mainDish)
        {
            MainDish = mainDish;
        }

        public string GetMealType()
        {
            return "Keto Meal";
        }

        public void DisplayMealDetails()
        {
            Console.WriteLine("Meal Type: Keto");
            Console.WriteLine("Main Dish: " + MainDish);
        }
    }

    // High Protein Meal
    class HighProteinMeal : IMealPlan
    {
        public string MainDish { get; set; }

        public HighProteinMeal(string mainDish)
        {
            MainDish = mainDish;
        }

        public string GetMealType()
        {
            return "High Protein Meal";
        }

        public void DisplayMealDetails()
        {
            Console.WriteLine("Meal Type: High Protein");
            Console.WriteLine("Main Dish: " + MainDish);
        }
    }

    // Generic Meal Class with Constraint
    class Meal<T> where T : IMealPlan
    {
        private List<T> meals = new List<T>();

        public void AddMeal(T meal)
        {
            meals.Add(meal);
            Console.WriteLine("Meal plan added successfully.");
            Console.WriteLine();
        }

        public void DisplayMeals()
        {
            if (meals.Count == 0)
            {
                Console.WriteLine("No meal plans available.");
                Console.WriteLine();
                return;
            }

            foreach (T meal in meals)
            {
                meal.DisplayMealDetails();
                Console.WriteLine();
            }
        }
    }

    // Utility Class with Generic Method
    class MealPlanUtility
    {
        public static void ValidateAndGenerateMeal<T>(T meal)
            where T : IMealPlan
        {
            Console.WriteLine("Generating meal plan:");
            meal.DisplayMealDetails();
            Console.WriteLine("Meal plan generated successfully.");
            Console.WriteLine();
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Meal<VegetarianMeal> vegetarianMeals = new Meal<VegetarianMeal>();
            Meal<VeganMeal> veganMeals = new Meal<VeganMeal>();
            Meal<KetoMeal> ketoMeals = new Meal<KetoMeal>();
            Meal<HighProteinMeal> highProteinMeals = new Meal<HighProteinMeal>();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Personalized Meal Plan Generator :");
                Console.WriteLine("1. Add Vegetarian Meal");
                Console.WriteLine("2. Add Vegan Meal");
                Console.WriteLine("3. Add Keto Meal");
                Console.WriteLine("4. Add High Protein Meal");
                Console.WriteLine("5. View All Meal Plans");
                Console.WriteLine("6. Exit");
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
                        Console.Write("Enter Vegetarian Main Dish Name: ");
                        string vegDish = Console.ReadLine() ?? "";

                        VegetarianMeal vegetarianMeal = new VegetarianMeal(vegDish);
                        vegetarianMeals.AddMeal(vegetarianMeal);
                        MealPlanUtility.ValidateAndGenerateMeal(vegetarianMeal);
                        break;

                    case 2:
                        Console.Write("Enter Vegan Main Dish Name: ");
                        string veganDish = Console.ReadLine() ?? "";

                        VeganMeal veganMeal = new VeganMeal(veganDish);
                        veganMeals.AddMeal(veganMeal);
                        MealPlanUtility.ValidateAndGenerateMeal(veganMeal);
                        break;

                    case 3:
                        Console.Write("Enter Keto Main Dish Name: ");
                        string ketoDish = Console.ReadLine() ?? "";

                        KetoMeal ketoMeal = new KetoMeal(ketoDish);
                        ketoMeals.AddMeal(ketoMeal);
                        MealPlanUtility.ValidateAndGenerateMeal(ketoMeal);
                        break;

                    case 4:
                        Console.Write("Enter High Protein Main Dish Name: ");
                        string proteinDish = Console.ReadLine() ?? "";

                        HighProteinMeal highProteinMeal = new HighProteinMeal(proteinDish);
                        highProteinMeals.AddMeal(highProteinMeal);
                        MealPlanUtility.ValidateAndGenerateMeal(highProteinMeal);
                        break;

                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("Vegetarian Meal Plans :");
                        vegetarianMeals.DisplayMeals();

                        Console.WriteLine("Vegan Meal Plans :");
                        veganMeals.DisplayMeals();

                        Console.WriteLine("Keto Meal Plans :");
                        ketoMeals.DisplayMeals();

                        Console.WriteLine("High Protein Meal Plans :");
                        highProteinMeals.DisplayMeals();
                        break;

                    case 6:
                        exit = true;
                        Console.WriteLine("Exiting Personalized Meal Plan Generator.");
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
