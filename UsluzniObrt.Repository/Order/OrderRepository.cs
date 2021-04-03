using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;
using System.Data.Entity;

namespace UsluzniObrt.Repository
{
   public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base (context)
        {

        }

    }
}
