using System;
using System.Collections.Generic;

namespace project1.data.Entities
{
    public partial class Food
    {
        public Food()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Foodtype { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
