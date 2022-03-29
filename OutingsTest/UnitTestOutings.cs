using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outings_Repository;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class Outing_RepoTests
    {
        Outings _outingOne = new Outings(TypeOfEvent.Bowling, DateTime.Parse("06/15/1993"), 25, 20, 3000.00m);
        Outings _outingTwo = new Outings(TypeOfEvent.Golf, DateTime.Parse("06/15/1993"), 10, 10, 1000.00m);
        Repository _outingsRepo = new Repository();

        [TestMethod]
        public void AddOutings_ShouldReturnTrue()
        {
            _outingsRepo.AddOutings(_outingOne);
            
            bool wasAdded = _outingsRepo.AddOutingsBool(_outingOne);
            
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void GetAllOutings_ShouldRightCollection()
        {            
            _outingsRepo.AddOutings(_outingOne);
            _outingsRepo.AddOutings(_outingTwo);
            
            List<Outings> contents = _outingsRepo.ListOutings();
            bool hasOutingOne = contents.Contains(_outingOne);
            bool hasOutingTwo = contents.Contains(_outingTwo);
            
            Assert.IsTrue(hasOutingOne);
            Assert.IsTrue(hasOutingTwo);
        }
        [TestMethod]
        public void CombineCosts_ShouldBeEqual()
        {          
            _outingsRepo.AddOutings(_outingOne);
            _outingsRepo.AddOutings(_outingTwo);
            
            decimal total = 4000.00m;
            
            Assert.AreEqual(_outingsRepo.TotalOutingCosts(), total);
        }
        [TestMethod]
        public void GetCostsByType_ShouldReturn()
        {         
            _outingsRepo.AddOutings(_outingOne);
            _outingsRepo.AddOutings(_outingTwo);
            
            decimal total = 3000.00m;
            
            Assert.AreEqual(_outingsRepo.TotalOutingCostsPerType(TypeOfEvent.Bowling), total);
        }
    }
}