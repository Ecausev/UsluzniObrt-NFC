using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UsluzniObrt.Model;

namespace UsluzniObrt.MVC.ViewModels
{
    public class ItemViewModel
    {

        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public int Price { get; set; }
        [Required]
        public MenuItemStatus Status { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}