using CompanyOutings_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CompanyOuting_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_DisplayCompanyOutings()
        {
            //Arrange - what does my method need in order to run
            CompanyContent_Repository repo = new CompanyContent_Repository();

            //Act
            int listOfCompanyOutings = repo.DisplayCompanyOutings().Count;

            //Assert
            Assert.AreEqual(0, listOfCompanyOutings);
        }

        [TestMethod]
        public void Test_AddCompanyOuting()
        {
            //Arrange
            CompanyContent content = new CompanyContent();
            CompanyContent_Repository repo = new CompanyContent_Repository();
            //List<CompanyContent> localList = new List<CompanyContent>(); //= repo.DisplayCompanyOutings();
            //localList.Add(new CompanyContent { }); //Fill in parameters
            //Build count method in repository - public int count() that returns list(variable).count
            

            //Act
            int beforeCount = repo.DisplayCompanyOutings().Count;
            repo.AddCompanyOuting(content);
            int actual = repo.DisplayCompanyOutings().Count;
            int expected = beforeCount + 1;

            //Assert
            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void Test_UpdateExistingOutings()
        {
            //Arrange
            CompanyContent_Repository repo = new CompanyContent_Repository();
            CompanyContent oldContent = new CompanyContent("Elton John", 26, new DateTime(2021, 8, 15), 50, 1300, EventType.Concert);
            repo.AddCompanyOuting(oldContent);
            CompanyContent updatedContent = new CompanyContent("Earth, Wind, and Fire", 26, new DateTime(2021, 8, 15), 50, 1300, EventType.Concert);
            string name = "Elton John";

            //Act
            bool result = repo.UpdateExistingOutings(name, updatedContent);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_GetContentByType()
        {
            //Arrange
            CompanyContent_Repository repo = new CompanyContent_Repository();
            CompanyContent testItem = new CompanyContent("Golf Outing", 12, new DateTime(2021, 4, 12), 45, 540, EventType.Golf);
            repo.AddCompanyOuting(testItem);

            //Act
            //testItem.TypeOfEvent = (EventType)Convert.ChangeType(testItem, EventType.Golf);
            var results = repo.GetContentByType(1);
            var expectedOuting = 1;
            var actualOuting = (int)results.TypeOfEvent;

            //Assert
            Assert.AreEqual(expectedOuting, actualOuting);
        }
    }
}
