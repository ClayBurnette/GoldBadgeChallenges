using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoCafe
{

    public class Menu
    {
        public Menu() { }
        public int ItemNumber { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Ingredients { get; set; }
        public string Price { get; set; }
        public Menu(int itemNumber, string name, string desc, string ingredients, string price)
        {
            ItemNumber = itemNumber;
            Name = name;
            Desc = desc;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
