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
        private ClaimRepository _claimRepository;
        public void Run()
        {
            _claimRepository = seedData();
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
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void SeeAllClaims()
        {
            // This should loop through every item in the Queue and print the data.
            Console.Clear();
            var claims = _claimRepository.GetClaims(); 
            // Queue<Claim Contents>
            // [0] <ClaimContents: carClaim......
            // [1] <ClaimContents: homeClaim......
            foreach (ClaimsContent claim in claims)
            {
                Console.WriteLine($"{claim.ClaimID} \t" +
                    $"{claim.TypeOfClaim} \t" +
                    $"{claim.Description} \t" +
                    $"{claim.ClaimAmount} \t" +
                    $"{claim.DateOfIncident} \t" +
                    $"{claim.DateOfClaim}");
            }
        }

        public void TakeCareOfNextClaim()
        {
            var claimsDisplay = _claimRepository.GetClaims();
            Console.WriteLine("Enter Y for next Claim, N to return to menu");
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "y")
            {
                var claims = _claimRepository.GetClaims();
                var nextClaim = claims.Dequeue();
                Console.WriteLine($"{nextClaim.ClaimID} \t" +
                    $"{nextClaim.Description} \t" +
                    $"{nextClaim.TypeOfClaim} \t" +
                    $"{nextClaim.ClaimAmount} \t" +
                    $"{nextClaim.DateOfIncident} \t" +
                    $"{nextClaim.DateOfClaim}");
            }
            else if (userInput == "n")
            {
                Console.WriteLine("Returning to Menu");
                Menu();
            }
            else
            {
                // Invalid option
                // Prompt user to enter another input an
                Console.WriteLine("Please enter a valid option.");
            }
        }

        public void EnterNewClaim()
        {
            Console.Clear();
            var claims = _claimRepository.GetClaims();
            ClaimsContent newItem = new ClaimsContent();

            //ClaimID
            Console.WriteLine("Enter an ID number for this claim.");
            string numberAsString = Console.ReadLine();
            newItem.ClaimID = int.Parse(numberAsString);

            //ClaimType
            Console.WriteLine("Enter the number that corresponds to the type of claim. (1. Car, 2. Home, 3. Theft)");
            string input = Console.ReadLine();
            newItem.TypeOfClaim = (ClaimType)Convert.ToInt32(input);

            //Description
            Console.WriteLine("Enter a description of the claim.");
            newItem.Description = Console.ReadLine();

            //Claim Amount
            Console.WriteLine("Enter the claim amount.");
            string doubleAsString = Console.ReadLine();
            newItem.ClaimAmount = double.Parse(doubleAsString);

            //Date of incident
            Console.WriteLine("Enter the date of the incident (yyyy-mm-dd).");
            DateTime incidentDate = Convert.ToDateTime(Console.ReadLine());
            newItem.DateOfIncident = incidentDate;

            //Date of claim
            Console.WriteLine("Enter the date of the claim (yyyy-mm-dd).");
            DateTime claimDate = Convert.ToDateTime(Console.ReadLine());
            newItem.DateOfClaim = claimDate;

            //Within the 30 day limit
            Console.WriteLine("Is this claim within 30 days of the incident? Type y or n");
            string isValid = Console.ReadLine();
            if (isValid.ToLower() == "y")
            {
                newItem.IsValid = true;
            }
            else //(isValid.ToLower() == "n")
            {
                newItem.IsValid = false;
            }
            claims.Enqueue(newItem);

            // Prompt user to enter data to create new Claim
            // IE) Prompt user to enter fields for the claim
            // string claimDescription = Console.ReadLine();
            ClaimsContent testingClaim = new ClaimsContent(
                claims.Count()+1,
                ClaimType.Car,
                "ETSEFDSAFDSFDASFAEWRFGASRF",
                40000000,
                new DateTime(2018, 4, 25),
                new DateTime(2018, 4, 27),
                true);
            claims.Enqueue(testingClaim);
        }

        public ClaimRepository seedData()
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

            ClaimsContent homeClaim = new ClaimsContent(
                1,
                ClaimType.Home,
                "House fire in kitchen",
                4000,
                new DateTime(2018, 4, 11),
                new DateTime(2018, 4, 12),
                true);

            ClaimsContent theftClaim = new ClaimsContent(
                3,
                ClaimType.Theft,
                "Stolen pancakes",
                4,
                new DateTime(2018, 4, 27),
                new DateTime(2018, 6, 1),
                false);

            KomodoClaims_Repo.ClaimRepository claimRepository = new ClaimRepository();
            claimRepository.AddNewClaim(carClaim);
            claimRepository.AddNewClaim(homeClaim);
            claimRepository.AddNewClaim(theftClaim);

            return claimRepository;
        }
    }
}
