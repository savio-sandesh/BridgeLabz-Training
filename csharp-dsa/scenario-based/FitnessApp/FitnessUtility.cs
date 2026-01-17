using System;

namespace FitnessApp
{
    // Handles business logic for fitness tracking
    public class FitnessUtility : IFitnessManager
    {
        // Array to store users (small group)
        private FitnessUser[] users;
        private int count;

        // Constructor initializes storage
        public FitnessUtility()
        {
            users = new FitnessUser[20]; // Max 20 users as per problem statement
            count = 0;
        }

        // Adds a new user with daily step count
        public void AddUser()
        {
            if (count >= users.Length)
            {
                Console.WriteLine("User limit reached.\n");
                return;
            }

            FitnessUser user = new FitnessUser();

            Console.Write("Enter User Name: ");
            user.UserName = Console.ReadLine();

            Console.Write("Enter Daily Steps: ");
            user.DailySteps = int.Parse(Console.ReadLine());

            users[count] = user;
            count++;

            Console.WriteLine("User added successfully.\n");
        }

        // Displays all users and their step counts
        public void DisplayUsers()
        {
            if (count == 0)
            {
                Console.WriteLine("No users available.\n");
                return;
            }

            Console.WriteLine("Daily Step Rankings:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("User Name: " + users[i].UserName);
                Console.WriteLine("Steps: " + users[i].DailySteps);
                Console.WriteLine("---------------------------");
            }
        }

        // Sorts users based on daily steps using Bubble Sort
        public void SortUsersBySteps()
        {
            if (count <= 1)
            {
                Console.WriteLine("Not enough users to sort.\n");
                return;
            }

            BubbleSort();
            Console.WriteLine("Users sorted by steps (High to Low).\n");
        }

        // Bubble Sort implementation (Descending order)
        private void BubbleSort()
        {
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (users[j].DailySteps < users[j + 1].DailySteps)
                    {
                        Swap(j, j + 1);
                    }
                }
            }
        }

        // Swaps two user objects
        private void Swap(int i, int j)
        {
            FitnessUser temp = users[i];
            users[i] = users[j];
            users[j] = temp;
        }
    }
}
