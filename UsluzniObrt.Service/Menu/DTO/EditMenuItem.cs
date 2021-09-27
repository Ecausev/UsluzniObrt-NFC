using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;

namespace UsluzniObrt.Service.Menu.DTO
{
    public class EditMenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public MenuItemStatus Status { get; set; }
        public int? CategoryId { get; set; }
    }
}
