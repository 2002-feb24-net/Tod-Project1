using System;
using System.Collections.Generic;
using System.Text;

namespace project1.logic.Models
{
    /// <summary>
    /// class of customers and what store they contacted
    /// </summary>
    public class Customers
    {
        public string name { get; set; }
        public string address { get; set; }
        public int storeNum { get; set; }
        public string phone { get; set; }
        /// <summary>
        /// customer constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="storeNum"></param>

        public Customers(string name, string address, string phone, int storeNum)
        {
            this.name = name;
            this.address = address;
            this.storeNum = storeNum;
            this.phone = phone;

        }
        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="copyC"></param>
        public Customers(Customers copyC)
        {
            this.name = copyC.name;
            this.address = copyC.address;
            this.storeNum = copyC.storeNum;
            this.phone = copyC.phone;
        }
        /// <summary>
        /// to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name + ":" + address + ":" + phone;
        }
    }
}
