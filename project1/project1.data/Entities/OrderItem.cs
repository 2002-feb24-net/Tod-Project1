using System;
using System.Collections.Generic;

namespace project1.data.Entities
{
    public partial class OrderItem
    {
        public int Ordernum { get; set; }
        public string Item { get; set; }

        public virtual Food ItemNavigation { get; set; }
        public virtual FoodOrder OrdernumNavigation { get; set; }
    }
}
