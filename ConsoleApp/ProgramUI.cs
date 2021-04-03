using CafeRepositoryConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeConsoleApp
{
    class ProgramUI
    {
        private MenuContent_Repository _menuContentRepo = new MenuContent_Repository();
        public void Run()
        {
            SeedContentList();
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Menu display
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Item\n" +
                    "2. View All Items\n" +
                    "3. Delete Existing Items\n" +
                    "4. Exit");

                //Get user input
                string input = Console.ReadLine();

                //Evaluate user input with a switch
                switch (input)
                {
                    case "1":
                        //Create a new item
                        CreateNewItem();
                        break;
                    case "2":
                        //Show all items
                        DisplayAllItems();
                        break;
                    case "3":
                        //Remove an item from the list
                        DeleteExistingItem();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
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

        //Methods for the cases go below
        private void CreateNewItem()
        {
            Console.Clear();
            MenuContent newItem = new MenuContent();

            //Meal Number
            Console.WriteLine("Enter the meal number for the item:");
            string numberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(numberAsString);

            //Meal Name
            Console.WriteLine("Enter the name of the meal:");
            newItem.MealName = Console.ReadLine();

            //Description
            Console.WriteLine("Enter a description of the meal:");
            newItem.Description = Console.ReadLine();

            //Ingredients
            Console.WriteLine("Enter the ingredients in the meal:");
            newItem.Ingredients = Console.ReadLine();

            //Price
            Console.WriteLine("Enter the price of the meal:");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);

            _menuContentRepo.AddMenuContent(newItem);

            Console.Clear();
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
        }
        private void DisplayAllItems()
        {
            Console.Clear();

            List<MenuContent> listOfMenuContent = _menuContentRepo.GetMenuList();

            foreach(MenuContent mealName in listOfMenuContent)
            {
                Console.WriteLine($"Meal number is: {mealName.MealNumber}\t" +
                    $"Meal name: {mealName.MealName}\t" +
                    $"Meal price: {mealName.Price}\n" +
                    $"Meal description: {mealName.Description}\t" +
                    $"Meal ingredients include: {mealName.Ingredients}\n");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }
        private void DeleteExistingItem()
        {
            DisplayAllItems();

            //Get the name they want to delete
            Console.WriteLine("\nEnter the name of the meal you want to remove:");
            string input = Console.ReadLine().ToLower();

            //call the delete method
            bool wasDeleted = _menuContentRepo.RemoveMenuContent(input);

            //If the content was deleted, say it was, otherwise say it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The meal was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The meal could not be deleted.");
            }
        }
        //Seed Method
        private void SeedContentList()
        {
            MenuContent burgerSingle = new MenuContent(1, "Single", "A burger with one patty made to order", "Lettuce, tomato, pickle, beef patty, on a bun", 4.99);
            MenuContent burgerDouble = new MenuContent(2, "Double", "A burger with two patties made to order", "Lettuce, tomato, pickle, 2 beef patties, on a bun", 6.99);
            MenuContent chickenTenders = new MenuContent(1, "Chicken Tenders", "8 chicken tenders", "Deep fried chicken with fries", 4.79);

            _menuContentRepo.AddMenuContent(burgerSingle);
            _menuContentRepo.AddMenuContent(burgerDouble);
            _menuContentRepo.AddMenuContent(chickenTenders);
        }
    }
}
