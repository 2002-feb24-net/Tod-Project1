using project1.logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project1.logic.ViewModels
{
    public class MenuItemViewModel 
    {

        public MenuItemViewModel(string item, double price, FoodType category)
        {
            this.item=item;
            this.price = price;
            this.category = category;
            this.isChecked = false;

        }
        [Required]
        public string item { get; set; }
        [Required]
        public double price { get; set; }

        public FoodType category { get; set; }

        public bool isChecked {get; set; }

    }
}
