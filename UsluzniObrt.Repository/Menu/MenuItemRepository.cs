using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;

namespace UsluzniObrt.Repository
{
    public class MenuItemRepository : BaseRepository<MenuItem>, IMenuitemRepository
    {
        public MenuItemRepository(DbContext context) : base(context)
        {

        }
    }
}
