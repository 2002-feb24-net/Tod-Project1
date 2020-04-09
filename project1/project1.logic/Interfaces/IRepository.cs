using System;
using System.Collections.Generic;
using System.Text;
using project1.logic.Models;

namespace project1.logic.Interfaces
{
    public interface IRepository
    {
        List<Locations> GetLocationList();

        List<Customers> GetCustomerList(int storeNum, string search = "");


   }
}
