using System;
using System.Collections.Generic;
using System.Text;
using project1.logic.Interfaces;
using project1.data.Entities;
using project1.logic.Models;
using project1.logic.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace project1.logic
{
    public class Repository : IRepository
    {
        private readonly restaurantContext restContext;
        public Repository(restaurantContext restContext)
        {
            this.restContext = restContext;
        }
       
        public List<Locations> GetLocationList()
        {
            List<Location> entityLoc = restContext.Location.ToList();
            var modelLoc = new List<Locations>();
            foreach (var locale in entityLoc)
            {
                modelLoc.Add(Mapper.Map(locale));
            }
            return modelLoc;
        }

        public List<Customers> GetCustomerList(int storeNum, string search="")
        {
            var CustomerContext = restContext.Customer.Include(c => c.StorenumNavigation);
            //var wholeList = await restaurantContext.ToListAsync();
            var modelCustomer = new List<Customers>();
            foreach(var person in CustomerContext)
            {
                if(storeNum == person.Storenum && person.Name.ToLower().Contains(search.ToLower()))
                    modelCustomer.Add(Mapper.Map(person));
            }
            return modelCustomer;
        }

        public bool PlaceOrder(string items, string customerName)
        {
            List<string> order = items.Split(',').ToList();
            var orderList = restContext.FoodOrder.Include(f => f.NameNavigation);
            int orderNum = orderList.ToList().Count + 1;
            
         
                var ordered = new FoodOrder
                {
                    Name = customerName,
                    Ordernum = orderNum,
                    Ordertime = DateTime.Now
                };
                using (var context = new restaurantContext())
                {
                    context.FoodOrder.Add(ordered);
                    context.SaveChanges();
                }
                
                    foreach (string item in order)
                    {
                        var itemList = new OrderItem
                        {
                            Item = item,
                            Ordernum = orderNum
                        };
                    using (var context = new restaurantContext())
                    { 
                        context.OrderItem.Add(itemList);
                        context.SaveChanges();
                    }
                }          
            return true;
        }
        public List<MenuItem> GetMenu()
        {
            var MenuContext = restContext.Food.ToList();
            List<MenuItem> Menu = new List<MenuItem>();
            FoodType temp = new FoodType();
            for (int i = 0; i < Enum.GetNames(typeof(FoodType)).Length; i++) //needs error check
            {
                for (int j = 0; j < MenuContext.Count; j++)
                {
                    temp = (FoodType)i;
                    if (MenuContext[j].Foodtype == temp.ToString())
                    {

                        Menu.Add(Mapper.Map(MenuContext[j]));
                    }
                }
            }
            return Menu;
        }

        public List<MenuItemViewModel> GetMenuViewModel()
        {
            var MenuContext = restContext.Food.ToList();
            List<MenuItemViewModel> modMenu = new List<MenuItemViewModel>();
            FoodType temp = new FoodType();
            for (int i = 0; i < Enum.GetNames(typeof(FoodType)).Length; i++) //needs error check
            {
                for (int j = 0; j < MenuContext.Count; j++)
                {
                    temp = (FoodType)i;
                    if (MenuContext[j].Foodtype == temp.ToString())
                    {
                        modMenu.Add(Mapper.Map(Mapper.Map(MenuContext[j])));
                    }
                }
            }
            return modMenu;
        }

        public bool AddCustomer(string name, string address, string storeNum, string phone)
        {
            try
            {
                var newCustomer = new Customer
                {

                    Name = name,
                    Address = address,
                    Storenum = int.Parse(storeNum),
                    Phone = phone

                };
                using (var context = new restaurantContext())
                {
                    context.Customer.Add(newCustomer);
                    context.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
