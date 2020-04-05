using System;
using System.Collections.Generic;

namespace project1.data.Entities
{
    public partial class FoodOrder
    {
        public FoodOrder()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public string Name { get; set; }
        public int Ordernum { get; set; }
        public DateTime Ordertime { get; set; }

        public virtual Customer NameNavigation { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
