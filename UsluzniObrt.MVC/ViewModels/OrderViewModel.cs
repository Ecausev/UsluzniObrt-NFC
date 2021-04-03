using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsluzniObrt.Model;

namespace UsluzniObrt.MVC.ViewModels
{
    public class OrderViewModel
    {
        public List<Order> OrderList = new List<Order>();
        public List<OrderItem> itemOrderList = new List<OrderItem>();
    }
}