using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;

namespace UsluzniObrt.Service.DTO
{
    public class OrderCreate
    {
        public int TableNumber { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get =>(int)OrderStatus.Pending; }
        public List<OrderItem> Items { get; set; }
    }
}
