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
            Assert.AreEqual("Chicken Soup", neworder.Name);
            Assert.AreEqual("A Delightful Soup", neworder.Desc);
            Assert.AreEqual("Chicken Noodles, Broth", neworder.Ingredients);
            Assert.AreEqual("$3.50", neworder.Price);

            Menu neworder2 = new Menu(1, "Stew", "Hot & Spicy", "Tofu, Broth", "$5.00");

            Assert.AreEqual(1, neworder2.ItemNumber);
            Assert.AreEqual("Stew", neworder2.Name);
            Assert.AreEqual("Hot & Spicy", neworder2.Desc);
            Assert.AreEqual("Tofu, Broth", neworder2.Ingredients);
            Assert.AreEqual("$5.00", neworder2.Price);
        }
    }
}