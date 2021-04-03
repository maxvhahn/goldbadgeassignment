using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoClaims_Console;
using KomodoClaims_Repo;

namespace KomodoClaims_Console
{
    class ProgramUI
    {

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Menu Display
                Console.WriteLine("Select a menu option:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                //Get user input
                string input = Console.ReadLine();

                //Evaluate user option with a switch
                switch (input)
                {
                    case "1":
                        //See all claims
                        SeeAllClaims();
                        break;
                    case "2":
                        //Take care of next claim
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        //Enter a new claim
                        EnterNewClaim();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid number.");
                        break;    
                }
            }
        }
        public void SeeAllClaims()
        {
            Console.Clear();

        }

        public void TakeCareOfNextClaim()
        {
            // <'data_type'>
            // List<Student>
            // List<string>
            // List<int>
            //Queue<string> claimQueue = new Queue<>();
            //claimQueue.Enqueue(claim1);
            //claimQueue.Enqueue(claim2);
            //claimQueue.Enqueue(claim3);
        }

        public void EnterNewClaim()
        {

        }
        public enum ClaimType
        {
            Car = 1,
            Home,
            Theft
        }
        public void seedData()
        {
            // Creates 3 initial Claims and adds to Queue
            ClaimsContent carClaim = new ClaimsContent(
                1,
                ClaimType.Car,
                "Car accident on 465",
                400,
                new DateTime(2018, 4, 25),
                new DateTime(2018, 4, 27),
                true);

        }
    }
}
