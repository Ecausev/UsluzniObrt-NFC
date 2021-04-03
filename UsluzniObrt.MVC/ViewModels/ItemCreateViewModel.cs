using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UsluzniObrt.Model;

namespace UsluzniObrt.MVC.ViewModels
{
    public class ItemCreateViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [Range(0,999)]
        public int Price { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public MenuItemStatus Status { get; set; }

    }
}