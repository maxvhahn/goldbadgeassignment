using CompanyOutings_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOuting_Console
{
    class ProgramUI
    {
        private CompanyContent_Repository _CompanyOutingsRepo = new CompanyContent_Repository();

        public void Run()
        {
            SeedContentList();
            Menu();
        }

        public void Menu()
        {
            bool keepRunnning = true;
            while (keepRunnning)
            {
                Console.WriteLine("Select an option:\n" +
                    "1. Show a list of all outings\n" +
                    "2. Add an outing to the list\n" +
                    "3. Calculations\n" +
                    "4. Exit");

                //Get user input
                string input = Console.ReadLine();

                //Evaluate the user's input
                switch (input)
                {
                    case "1":
                        //Show a list of all items
                        DisplayListOfOutings();
                        break;
                    case "2":
                        //Create a new item
                        AddOuting();
                        break;
                    case "3":
                        //Show the calculations
                        DisplayCalculations();
                        //Display combined cost of all outings
                        //Display cost of outing by Event Type
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunnning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
            }
            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //Methods for the cases are below

        public void DisplayListOfOutings()
        {
            Console.Clear();
            List<CompanyContent> listOfOutings = _CompanyOutingsRepo.DisplayCompanyOutings();

            foreach (CompanyContent outing in listOfOutings)
            {
                Console.WriteLine($"The event is: {outing.EventName}\t" +
                    $"The number of attendees is: {outing.Attendees}\t" +
                    $"The date of the outing is: {outing.Date}\t" +
                    $"The cost per person is: {outing.CostPerPerson}\t" +
                    $"The total cost is: {outing.TotalCost}\t" +
                    $"This is a {outing.TypeOfEvent} outing.\n");
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        public void AddOuting()
        {
            Console.Clear();
            CompanyContent newItem = new CompanyContent();

            Console.WriteLine("Enter the name of the event:");
            newItem.EventName = Console.ReadLine();

            Console.WriteLine("Enter the number of attendees: ");
            string attendees = Console.ReadLine();
            newItem.Attendees = int.Parse(attendees);

            Console.WriteLine("Enter the date of the outing: yyyy-mm-dd");
            DateTime eventDate = Convert.ToDateTime(Console.ReadLine());
            newItem.Date = eventDate;

            Console.WriteLine("Enter the cost per person: ");
            string pricePerPerson = Console.ReadLine();
            newItem.CostPerPerson = double.Parse(pricePerPerson);

            Console.WriteLine("Enter the total cost: ");
            string totalCost = Console.ReadLine();
            newItem.TotalCost = double.Parse(totalCost);

            Console.WriteLine("Enter the number that corresponds with the event (1 Golf, 2 Bowling, 3 Amusement Park, 4 Concert): ");
            string input = Console.ReadLine();
            newItem.TypeOfEvent = (EventType)Convert.ToInt32(input);

            _CompanyOutingsRepo.AddCompanyOuting(newItem);

            Console.WriteLine("Would you like to enter another event? y for yes or n for no");
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "y")
            {
                Console.Clear();
                AddOuting();
            }
            else if (userInput == "n")
            {
                Console.Clear();
                Menu();
            }
            else
            {
                Console.WriteLine("Please enter a valid answer.");
            }
        }

        public void DisplayCalculations()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select how you'd like the cost to be displayed: \n" +
                "1. Total cost of all outings\n" +
                "2. Total cost of golf outings\n" +
                "3. Total cost of bowling outings\n" +
                "4. Total cost of amusement park outings \n" +
                "5. Total cost of concert outing\n" +
                "6. Back to main menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CalculateTotal();
                        break;
                    case "2":
                        CalculateGolfTotal();
                        break;
                    case "3":
                        CalculateBowlingTotal();
                        break;
                    case "4":
                        CalculateAmusementParkTotal();
                        break;
                    case "5":
                        CalculateConcertTotal();
                        break;
                    case "6":
                        Console.Clear();
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        keepRunning = false;
                        break;
                }
            }
        }
        public double CalculateTotal()
        {
            List<CompanyContent> listOfOutings = _CompanyOutingsRepo.DisplayCompanyOutings();
            double totalCost = 0;
            foreach (CompanyContent outing in listOfOutings)
            {
                totalCost += outing.TotalCost;
            }
            Console.WriteLine(totalCost);
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
            return totalCost;
        }
        

        public double CalculateGolfTotal()
        {
            List<CompanyContent> listOfOutings = _CompanyOutingsRepo.DisplayCompanyOutings();
            //double golfTotal = listOfOutings.Where(p => p.TypeOfEvent == (EventType)1).Sum(p => p.TotalCost);
            double totalCost = 0;
            foreach (CompanyContent outing in listOfOutings)
            {
                if(outing.TypeOfEvent == EventType.Golf)
                totalCost += outing.TotalCost;
            }
            Console.WriteLine(totalCost);
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
            return totalCost;
        }

        public double CalculateBowlingTotal()
        {
            List<CompanyContent> listOfOutings = _CompanyOutingsRepo.DisplayCompanyOutings();
            double totalCost = 0;
            foreach (CompanyContent outing in listOfOutings)
            {
                if (outing.TypeOfEvent == EventType.Bowling)
                    totalCost += outing.TotalCost;
            }
            Console.WriteLine(totalCost);
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
            return totalCost;
        }
        public double CalculateAmusementParkTotal()
        {
            List<CompanyContent> listOfOutings = _CompanyOutingsRepo.DisplayCompanyOutings();
            double totalCost = 0;
            foreach (CompanyContent outing in listOfOutings)
            {
                if (outing.TypeOfEvent == EventType.AmusementPark)
                    totalCost += outing.TotalCost;
            }
            Console.WriteLine(totalCost);
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
            return totalCost;
        }
        public double CalculateConcertTotal()
        {
            List<CompanyContent> listOfOutings = _CompanyOutingsRepo.DisplayCompanyOutings();
            double totalCost = 0;
            foreach (CompanyContent outing in listOfOutings)
            {
                if (outing.TypeOfEvent == EventType.Concert)
                    totalCost += outing.TotalCost;
            }
            Console.WriteLine(totalCost);
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
            return totalCost;
        }
        //CompanyContent_Repository _repo = new CompanyContent_Repository();
        //foreach (double type in Enum.GetValues(typeof(EventType)))
        //{
        //    if(type == 1)
        //    {
        //        return Enum.GetValues(typeof(CompanyContent.));
        //    }
        //    else if( type == 2)
        //    {

        //    }
        //    else if(type == 3)
        //    {

        //    }
        //    else if(type == 4)
        //    {

        //    }
        //    else if( type == 0)
        //    {

        //    }
        //    else
        //    {
        //        Console.WriteLine("Please enter a valid number.");
        //    }


        private void SeedContentList()
        {
            CompanyContent adeleConcert = new CompanyContent("Adele", 10, new DateTime(2021, 04, 02), 12.50, 125, EventType.Concert);
            CompanyContent bowling = new CompanyContent("Bowl-over Beethoven", 12, new DateTime(2021, 04, 02), 8.25, 123.75, EventType.Bowling);
            CompanyContent kingsIsland = new CompanyContent("John Mayer", 15, new DateTime(2021, 04, 02), 10.10, 151.50, EventType.AmusementPark);
            CompanyContent mayerConcert = new CompanyContent("John Mayer", 60, new DateTime(2020, 08, 015), 67.70, 4062, EventType.Concert);
            CompanyContent golfOuting = new CompanyContent("Mystic Hills", 20, new DateTime(2021, 04, 02), 200, 4000, EventType.Golf);

            _CompanyOutingsRepo.AddCompanyOuting(adeleConcert);
            _CompanyOutingsRepo.AddCompanyOuting(bowling);
            _CompanyOutingsRepo.AddCompanyOuting(kingsIsland);
            _CompanyOutingsRepo.AddCompanyOuting(mayerConcert);
            _CompanyOutingsRepo.AddCompanyOuting(golfOuting);
        }
    }
}
