using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsluzniObrt.Model;
using UsluzniObrt.Service.DTO;

namespace UsluzniObrt.MVC.ViewModels
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public List<MenuItem> MenuItemList { get; set; }
        public int Table {get; set;}
    }
}