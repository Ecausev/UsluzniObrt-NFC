using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsluzniObrt.Model;

namespace UsluzniObrt.MVC.ViewModels
{
    public class Cart
    {
        public int Table;
        public List<OrderItem> itemOrderList = new List<OrderItem>();
        public void AddItem(MenuItem item, int qty)
        {
            OrderItem itemOnList = itemOrderList.Where(x => x.MenuItemId == item.Id ).FirstOrDefault();

            if (itemOnList == null)
            {
                itemOrderList.Add(new OrderItem { MenuItemId = item.Id ,  Quantity = qty });
            }
            else
            {
                itemOnList.Quantity += qty;
            }

        }
        public void RemoveItem(MenuItem item)
        {

            itemOrderList.RemoveAll(x => x.MenuItemId == item.Id);

        }
        public void RemoveOne(MenuItem item, int qty)
        {
            OrderItem itemOnList = itemOrderList.Where(x => x.MenuItemId == item.Id).FirstOrDefault();

            if (itemOnList.Quantity == 1)
            {
                itemOrderList.RemoveAll(x => x.MenuItemId == item.Id);
            }
            else
            {
                itemOnList.Quantity -= qty;
            }

        }

        
        public void Clear()
        {
            itemOrderList.Clear();
        }

        public IEnumerable<OrderItem> OrderList { get { return itemOrderList; } }
    }
}