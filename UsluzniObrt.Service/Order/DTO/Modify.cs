using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;

namespace UsluzniObrt.Service.DTO
{
    public class ModifyOrder
    {
        public int OrderId { get; set; }
        public OrderStatus status { get; set; }
    }
}
