// Health App 
// Author: Lionel Villanueva
// Purpose: This application allows a new user to create a profile by inputting personal information and completing a questionnaire. The application then displays a summary of the user's profile.

namespace HealthApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Accept user inputs
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter your birth year (yyyy): ");
            int birthYear = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your gender (M/F/O): ");
            char gender = Convert.ToChar(Console.ReadLine().ToUpper());

            // Validate user inputs
            if (string.IsNullOrEmpty(firstName) || firstName.Any(char.IsDigit) || firstName.Any(char.IsSymbol))
            {
                throw new ArgumentException("First name is invalid.");
            }

            if (string.IsNullOrEmpty(lastName) || lastName.Any(char.IsDigit) || lastName.Any(char.IsSymbol))
            {
                throw new ArgumentException("Last name is invalid.");
            }

            if (birthYear < 1900 || birthYear > DateTime.Now.Year)
            {
                throw new ArgumentException("Birth year is invalid.");
            }

            if (gender != 'M' && gender != 'F' && gender != 'O')
            {
                throw new ArgumentException("Gender is invalid.");
            }

            // Create and store user responses in a list
            List<string> responses = new List<string>();
            Console.WriteLine("Please answer the following questions:");

            Console.Write("1)Do you run daily? ");
            responses.Add(Console.ReadLine());

            Console.Write("2)Do you go to the gym daily? ");
            responses.Add(Console.ReadLine());

            Console.Write("3)How many push ups are you able to do? ");
            responses.Add(Console.ReadLine());

            Console.Write("4)How much can you lift? ");
            responses.Add(Console.ReadLine());

            Console.Write("5)Do you eat a balanced diet? ");
            responses.Add(Console.ReadLine());

            Console.Write("6)How many hours of sleep do you get per night? ");
            responses.Add(Console.ReadLine());

            Console.Write("7)How many glasses of water do you drink per day? ");
            responses.Add(Console.ReadLine());

            Console.Write("8)Do you smoke or use tobacco products? ");
            responses.Add(Console.ReadLine());

            Console.Write("9)Do you drink alcohol? ");
            responses.Add(Console.ReadLine());

            Console.Write("10)Do you have any medical conditions we should be aware of? ");
            responses.Add(Console.ReadLine());

            // Display user profile summary
            Console.WriteLine();
            Console.WriteLine("===== User Profile Summary =====");
            Console.WriteLine($"Name: {lastName}, {firstName}");
            Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
            Console.WriteLine($"Gender: {GetGenderDescription(gender)}");
            Console.WriteLine();

            Console.WriteLine("===== Questionnaire Responses =====");
            for (int i = 0; i < responses.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}: {responses[i]}");
            }
        }

        // Get gender description based on input
        /// <summary>
        /// Returns the full description of the user's gender based on the input character.
        /// </summary>
        /// <param name="gender">The user's gender character (M/F/O).</param>
        /// <returns>The full description of the user's gender (Male/Female/Other not listed).</returns>
        
        private static string GetGenderDescription(char gender)
        {
            switch (gender)
            {
                case 'M':
                    return "Male";
                case 'F':
                    return "Female";
                case 'O':
                    return "Other not listed";
                default:
                    throw new ArgumentException("Gender is invalid.");
            }
        }
    }
}
