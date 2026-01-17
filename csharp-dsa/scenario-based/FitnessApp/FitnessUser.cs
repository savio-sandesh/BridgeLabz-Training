using System;

namespace FitnessApp
{
    // Represents a fitness app user
    public class FitnessUser
    {
        // Private fields for encapsulation
        private string userName;
        private int dailySteps;

        // Gets or sets the user name
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        // Gets or sets the daily step count
        public int DailySteps
        {
            get { return dailySteps; }
            set { dailySteps = value; }
        }
    }
}
