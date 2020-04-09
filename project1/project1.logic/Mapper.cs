using System;
using System.Collections.Generic;
using System.Text;
using project1.logic.Models;
using project1.data.Entities;

namespace project1.logic
{
    public static class Mapper
    {
        //error checking in future
        public static Locations Map(Location entityLoc)
        {
            Locations loc = new Locations(entityLoc.Name, entityLoc.Storenum);
            return loc;
        }

        public static Customers Map(Customer entityCustomer)
        {
            Customers custom =
                new Customers(entityCustomer.Name, entityCustomer.Address, entityCustomer.Phone, entityCustomer.Storenum);
            return custom;
        }

        public static MenuItem Map(Food entityFood)
        {
            //FoodType food = (FoodType)Enum.Parse(typeof(FoodType), menuList[i].Foodtype);
            FoodType category = (FoodType)Enum.Parse(typeof(FoodType), entityFood.Foodtype);
            var menu = new MenuItem(entityFood.Name, (double)entityFood.Price, category);
            return menu;
        }
    }
}
