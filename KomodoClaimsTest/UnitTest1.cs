using KomodoClaims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoClaimsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddNewClaim_Test()
        {
            //Arrange
            Queue<ClaimsContent> _claimList = new Queue<ClaimsContent>();
            ClaimsContent claimContent = new ClaimsContent();
            ClaimRepository repo = new ClaimRepository();
            Queue<ClaimsContent> localQueue = repo.GetClaims();

            //Act
            int beforeCount = localQueue.Count;
            repo.AddNewClaim(claimContent);
            int actual = localQueue.Count;
            int expected = beforeCount + 1;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetClaims_Test()
        {
            //Arrange
            ClaimRepository repo = new ClaimRepository();
            ClaimsContent testItem = new ClaimsContent(1, ClaimType.Car, "Car wreck on Meridian", 1200, new DateTime(2021, 03, 27), new DateTime(2021, 03, 28), true);
            repo.AddNewClaim(testItem);

            //Act
            int listOfClaimContent = repo.GetClaims().Count;

            //Assert
            Assert.IsTrue(listOfClaimContent == 1);
        }
    }
}
