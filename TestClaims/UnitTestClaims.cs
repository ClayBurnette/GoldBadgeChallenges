using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoClaims;
using System;

namespace TestClaims
{
    [TestClass]
    public class Tests
    {
        private Repository _repo;
        private Claims _claims;
        private Claims _lateClaims;
        public Repository Repo { get => _repo; set => _repo = value; }
        [TestInitialize]
        public void Initialize()
        {
            Repo = new Repository();
            _claims = new Claims(3, TypeOfClaim.Theft, "Stolen Bicycle", 3000, DateTime.Parse("10/11/2012"), DateTime.Parse("10/13/2012"), true);
            _lateClaims = new Claims(2, TypeOfClaim.Home, "House Fire", 100000, DateTime.Parse("06/15/2015"), DateTime.Parse("08/15/2015"), false);
        }
        [TestMethod]
        public void POCOsTest()
        {
            Claims newClaim = new Claims(2, TypeOfClaim.Home, "Roof Damage", 2500, DateTime.Parse("09/02/2017"), DateTime.Parse("09/27/2017"), true);

            Assert.AreEqual(2, newClaim.ClaimID);
            Assert.AreEqual(TypeOfClaim.Home, newClaim.Type);
            Assert.AreEqual("Roof Damage", newClaim.Description);
            Assert.AreEqual(DateTime.Parse("09/02/2017"), newClaim.DateOfAccident);
            Assert.AreEqual(DateTime.Parse("09/27/2017"), newClaim.DateOfClaim);
            Assert.AreEqual(true, newClaim.IsValid);
        }
        [TestMethod]
        public void AddClaimTest()
        {
            Repo.AddClaim(_claims);
            int expected = 1;
            int actual = Repo.GetList().Count;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void RemoveClaimTest()
        {
            _ = new Repository();
        }
        [TestMethod]
        public void ValidTestTrue()
        {
            Repo.AddClaim(_claims);
            bool expected = true;
            bool actual = _claims.IsValid;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidTestFalse()
        {
            Repo.AddClaim(_lateClaims);
            bool expected = false;
            bool actual = _lateClaims.IsValid;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetListTest()
        {
            Repo.GetList();
            Assert.IsNotNull(Repo);
        }
    }
}