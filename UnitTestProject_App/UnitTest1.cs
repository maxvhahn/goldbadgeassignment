using CafeRepositoryConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject_App
{
    //This has a specific task for testing our code
    //Click view, then test explorer. Inside the explorer you can run individual methods
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_SeedContentListTest()
        {
            // Arrange - Set up testing Varibles
            MenuContent_Repository _menuContentRepo = new MenuContent_Repository();
            MenuContent burgerSingle = new MenuContent(1, "Single", "A burger with one patty made to order", "Lettuce, tomato, pickle, beef patty, on a bun", 4.99);
            MenuContent burgerDouble = new MenuContent(2, "Double", "A burger with two patties made to order", "Lettuce, tomato, pickle, 2 beef patties, on a bun", 6.99);
            MenuContent chickenTenders = new MenuContent(1, "Chicken Tenders", "8 chicken tenders", "Deep fried chicken with fries", 4.79);
            int expectedNumberOfMenuContent = 3;

            // Act - Perform Logic to test
            _menuContentRepo.AddMenuContent(burgerSingle);
            _menuContentRepo.AddMenuContent(burgerDouble);
            _menuContentRepo.AddMenuContent(chickenTenders);

            // Assert - Compare the expectedNumber to the Actual
            Assert.AreEqual(expectedNumberOfMenuContent, _menuContentRepo.GetMenuList().Count);
        }

        [TestMethod]
        public void Test_AddMenuContent()
        {
            //Arrange
            List<MenuContent> _listOfMenuContent = new List<MenuContent>();
            MenuContent menuContent = new MenuContent();
            MenuContent_Repository repo = new MenuContent_Repository();
            List<MenuContent> localList = repo.GetMenuList();

            //Act
            int beforeCount = localList.Count;
            repo.AddMenuContent(menuContent);
            int actual = localList.Count;
            int expected = beforeCount + 1;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_RemoveMenuContent()
        {
            //Arrange
            MenuContent_Repository repo = new MenuContent_Repository();
            MenuContent TestItem = new MenuContent(1, "Single", "A burger with one patty made to order", "Lettuce, tomato, pickle, beef patty, on a bun", 4.99);
            repo.AddMenuContent(TestItem);
            List<MenuContent> localList = repo.GetMenuList();
            //Act
            int beforeCount = localList.Count;
            repo.RemoveMenuContent(TestItem.MealName);
            int actual = localList.Count;
            int expected = beforeCount - 1;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_GetMenuList()
        {
            //Arrange
            MenuContent_Repository repo = new MenuContent_Repository();
            MenuContent testItem = new MenuContent(1, "Single", "A burger with one patty made to order", "Lettuce, tomato, pickle, beef patty, on a bun", 4.99);
            repo.AddMenuContent(testItem);

            //Act
            int listOfMenuContentCount = repo.GetMenuList().Count;

            //Assert
            Assert.IsTrue(listOfMenuContentCount == 1);
        }

        [TestMethod]
        public void Test_GetMenuContent()
        {
            //Arrange
            MenuContent_Repository repo = new MenuContent_Repository();
            MenuContent testItem = new MenuContent(1, "Single", "A burger with one patty made to order", "Lettuce, tomato, pickle, beef patty, on a bun", 4.99);
            repo.AddMenuContent(testItem);

            //Act
            var results = repo.GetMenuContent("Single");
            var expectedMealNumber = 1;
            var actualMealNumber = results.MealNumber;

            //Assert
            Assert.AreEqual(expectedMealNumber, actualMealNumber);
        }
    }
}
