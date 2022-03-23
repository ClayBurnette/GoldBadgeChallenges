using RepoCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCafe
{
    public class ProgramUI
    {
        private readonly Repository _orderRepo = new Repository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("The Komodo Cafe Console App.\n" +
                    "\n" + 
                    "Please Enter A Number From The List Below To Start Navigating The Menu.\n" +
                    "\n" +
                    "1. Items On The Menu. . . \n" +
                    "2. Create An Order. . . \n" +
                    "3. Remove An Order. . . \n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ListAllOrders();                     
                        break;
                    case "2":
                        CreateOrder();
                        break;
                    case "3":
                        RemoveOrderFromList();
                        break;
                    default:
                        Console.WriteLine("That Is Not A Valid Input");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public void ListAllOrders()
        {
            Console.Clear();
            List<Menu> ItemList = _orderRepo.ListOrders();
            foreach (Menu content in ItemList)
            {
                Console.WriteLine($"#{content.ItemNumber} {content.Name}\n" +
                    $"Description: {content.Desc}\n" +
                    $"Ingredients: {content.Ingredients}\n" +
                    $"Price:{content.Price}\n");
            }
            Console.WriteLine("Press ENTER Key To Continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public void CreateOrder()
        {
            Menu content = new Menu();

            Console.Clear();
            Console.WriteLine("(ID) (Name) (Description) (Ingrediants) (Price)\n");
            // Loop If No Valid Input
            Console.WriteLine("Enter The New Item Number: #4-10 ");
            content.ItemNumber = int.Parse(Console.ReadLine());
            while (true)
            {
                if (content.ItemNumber >= 4 && content.ItemNumber <= 10)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter A Number That Is 4-10!");
                    content.ItemNumber = int.Parse(Console.ReadLine());
                }
            }
            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) (Name) (Description) (Ingrediants) (Price)\n");

            Console.WriteLine("Enter The New Menu Items Name: ");
            content.Name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) ({content.Name}) (Description) (Ingrediants) (Price)\n");

            Console.WriteLine($"Enter A New Description For The Item {content.Name}: ");
            content.Desc = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) ({content.Name}) ({content.Desc}) (Ingrediants) (Price)\n");

            Console.WriteLine($"Enter The Ingrediants For The New {content.Name} Item: ");
            content.Ingredients = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"Enter The New Price Of The {content.Name}:" + $" Example $2.00");
            content.Price = Console.ReadLine();
            Console.WriteLine(" ");

            Console.WriteLine("Here Is A Look At Your Order Summary:\n");

            Console.WriteLine($"Item Number: {content.ItemNumber}\n" +
                $"Item Name: {content.Name}\n" +
                $"Item Description: {content.Desc}\n" +
                $"Item Ingrediants: {content.Ingredients}\n" +
                $"Item Price: {content.Price}\n");

            Console.WriteLine("Press The ENTER Key To Confirm Your Order");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Order Successfully Added To The Menu.\n" + "\n" +
                "Press The ENTER Key To Continue...");
            Console.ReadKey();
            _orderRepo.AddOrder(content);
        }
        public void RemoveOrderFromList()
        {
            Console.Clear();
            Console.WriteLine("Which Order Would You Like To Remove?\n" +
                "(Select The Item Using Its Associated Number)" + "\n");
            
            List<Menu> ItemList = _orderRepo.ListOrders();
            foreach (Menu order in ItemList)
            {
                Console.WriteLine($"{order.ItemNumber} - {order.Name}\n");
            }
            int numRemove = int.Parse(Console.ReadLine());
            Menu menuObject = _orderRepo.FindOrderByID(numRemove);
            _orderRepo.RemoveOrder(menuObject);

            Console.WriteLine("\n" + "Order Successfully Removed.\n" + "\n" + "Press The ENTER Key To Continue...");
            Console.ReadKey();
        }
        public void SeedContent()
        {
            Menu chickenSoup = new Menu(1, "Chicken Soup", "A Delightful Chicken Soup", "Chicken, Chicken Stock, Noodles", "$2.50");
            Menu breakfastSandwich = new Menu(2, "Breakfast Sandwich", "A Warm Breakfast Sandwich On A Bagel", "Bagel, Eggs, Bacon, Tomato, Mayo", "$5.00");
            Menu freshSalad = new Menu(3, "Fresh Salad", "A Light Cesar Salad.", "Salad Mix, Parmesan Cheese, Croutons, Red Wine Vinegar", "$6.50");

            _orderRepo.AddOrder(chickenSoup);
            _orderRepo.AddOrder(breakfastSandwich);
            _orderRepo.AddOrder(freshSalad);
        }
    }
}