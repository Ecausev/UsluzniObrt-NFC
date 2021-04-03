using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;
using System.Data.Entity;
namespace UsluzniObrt.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }
    }
}
