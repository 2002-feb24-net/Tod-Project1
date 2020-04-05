using System;
using System.Collections.Generic;

namespace project1.data.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            FoodOrder = new HashSet<FoodOrder>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public int Storenum { get; set; }
        public string Phone { get; set; }

        public virtual Location StorenumNavigation { get; set; }
        public virtual ICollection<FoodOrder> FoodOrder { get; set; }
    }
}
