using System;
using project1.data;
using System.Linq;



namespace project1.logic.Models
{

    /// <summary>
    /// Food items and the category they belong into
    /// </summary>
    public class MenuItem
    {
        public string item { get; set; }
        public double price { get; set; }
        public FoodType category { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="cat"></param>

        public MenuItem(string name, double cost, FoodType cat)
        {
            item = name;
            price = cost;
            category = cat;

        }
        /// <summary>
        /// string override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return item + "-" + price;


        }
    }
}
