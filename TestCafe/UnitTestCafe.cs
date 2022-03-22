using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoCafe;
using System;

namespace TestCafe
{
    [TestClass]
    public class Tests
    {
        private Repository _contentRepo;
        private Menu _content;
        [TestInitialize]
        public void Initialize()
        {
            _contentRepo = new Repository();
            _content = new Menu(5, "Chicken Soup", "A Delightful Soup", "Chicken Noodles, Broth", "$3.50");
        }
        [TestMethod]
        public void AddContentToList()
        {
            _contentRepo.AddOrder(_content);
            int expected = 1;
            int actual = _contentRepo.ListOrders().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveContentFromList()
        {
            Repository contentRepo = new Repository();
            contentRepo.AddOrder(_content);
            bool wasRemoved = contentRepo.RemoveOrder(_content);
            Assert.IsTrue(wasRemoved);
        }
        [TestMethod]
        public void POCOTest()
        {
            Menu neworder = new Menu(1, "Chicken Soup", "A Delightful Soup", "Chicken Noodles, Broth", "$3.50");

            Assert.AreEqual(1, neworder.ItemNumber);
            Assert.AreEqual("Cheeseburger", neworder.Name);
            Assert.AreEqual("Plain old burger", neworder.Desc);
            Assert.AreEqual("2 buns, 1 patty", neworder.Ingredients);
            Assert.AreEqual("$3.50", neworder.Price);
        }
    }
}