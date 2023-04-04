using System.Globalization;

namespace CodingTracker
{
    internal class GetUserInput
    {
        CodingController codingController = new(); // controller for sending the data (Coding object) to the bd.
        public void MainMenu()
        {
            Console.Clear();

            bool appRunning = true;
            while (appRunning)
            {
                Console.WriteLine("\nCoding Tracker");
                Console.WriteLine("-----------------------\n");
                Console.WriteLine("Type 1 - VIEW RECORD");
                Console.WriteLine("Type 2 - ADD RECORD");
                Console.WriteLine("Type 3 - UPDATE RECORD");
                Console.WriteLine("Type 4 - DELETE RECORD");
                Console.WriteLine("Type 0 - Close App");
                Console.WriteLine("-----------------------");

                string userInput = Console.ReadLine();

                while (String.IsNullOrEmpty(userInput))
                {
                    ErrorMessage();
                    userInput = Console.ReadLine();
                }

                switch (userInput)
                {
                    case "0":
                        appRunning = false;
                        Environment.Exit(0);
                        break;
                    case "1":

                        break;
                    case "2":
                        ProcessAdd();
                        break;
                    case "3":
                        //UpdateRecord();
                        break;
                    case "4":
                        //DeleteRecord();
                        break;
                    default:
                        ErrorMessage();
                        break;
                }
            }
        }
        public void ErrorMessage()
        {
            Console.WriteLine("\nInvalid input, please try again.");
        }
        private void ProcessAdd()
        {
            string date = GetDate();
            string duration = GetDuration();

            Coding coding = new();
            coding.Date = date;
            coding.Duration = duration;

            codingController.Post(coding);
        }

        private string GetDuration()
        {
            Console.Write("\nPlease insert the duration (Format: hh:mm). Type 0 to return to the Main Menu: ");
            string userInput = Console.ReadLine();

            if (userInput == "0") MainMenu();
            while (!TimeSpan.TryParseExact(userInput, "h\\:mm", CultureInfo.InvariantCulture, out _))
            {
                ErrorMessage();
                userInput = Console.ReadLine();
                if (userInput == "0") MainMenu();
            }

            return userInput;
        }

        private string GetDate()
        {
            Console.Write("\nPlease insert a date (Format: dd-mm-yy). Type 0 to return to the Main Menu: ");
            string userInput = Console.ReadLine();

            if (userInput == "0") MainMenu();
            while(!DateTime.TryParseExact(userInput, "dd-MM-yy", new CultureInfo("cs-CZ"), DateTimeStyles.None, out _))
            {
                ErrorMessage();
                userInput = Console.ReadLine();
                if (userInput == "0") MainMenu();
            }

            return userInput;
        }
    }
}