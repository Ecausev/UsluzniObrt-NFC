using System;
using System.Collections.Generic;

namespace UsluzniObrt.Model
{
    public class Order
    {
        public Order()
        {
            Items = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int TableNumber { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }

}
