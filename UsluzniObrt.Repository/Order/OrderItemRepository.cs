using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;

namespace UsluzniObrt.Repository
{
    public class OrderItemRepository : BaseRepository<OrderItem> , IOrderItemRepository
    {
        public OrderItemRepository(DbContext context) : base (context)
        {

        }
    }
}
