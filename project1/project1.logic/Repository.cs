using System;
using System.Collections.Generic;
using System.Text;
using project1.logic.Interfaces;
using project1.data.Entities;
using project1.logic.Models;
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
    }
}
