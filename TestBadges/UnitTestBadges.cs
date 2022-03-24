using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoBadges;
using System;
using System.Collections.Generic;


namespace TestBadges
{
    [TestClass]
    public class UnitTestBadges
    {
        readonly Badges badges = new Badges(007, new List<string> { "A1", "B3", "C2" });
        readonly Badges badges1 = new Badges(007, new List<string> { "A1", "B3" });
        Repository _repo = new Repository();
        [TestMethod]
        public void AddBadge_ShouldReturnTrue()
        {
            //Arrange
            Badges badge = new Badges(69);
            Repository repo = new Repository();
            //Act
            bool wasMade = repo.CreateNewBadge(badge);
            //Assert
            Assert.IsTrue(wasMade);
        }
        [TestMethod]
        public void GetAllBadges_ShouldReturnRightList()
        {
            //Arrange
            _repo.CreateNewBadge(badges);
            //Act
            Dictionary<int, List<string>> dict = _repo.GetDictonary();
            bool containsThem = dict.ContainsKey(badges.BadgeID);
            //Assert
            Assert.IsTrue(containsThem);
        }
        [TestMethod]
        public void GetBadgeByID_ShouldReturnRightList()
        {
            //Arrange
            _repo.CreateNewBadge(badges);
            int id = 007;
            //Act
            Badges result = _repo.GetBadgeByID(id);
            //Assert
            Assert.AreEqual(result.BadgeID, badges.BadgeID);
        }
    }
}