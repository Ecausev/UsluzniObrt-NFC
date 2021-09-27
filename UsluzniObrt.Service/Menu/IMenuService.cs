using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;
using UsluzniObrt.Service.Menu.DTO;

namespace UsluzniObrt.Service
{
   public interface IMenuService
    {
        List<MenuItem> GetAll();
        void Add(CreateMenuItem newItem);
        void Delete(int id);
        void edit(EditMenuItem item);
        MenuItem GetById(int id);
    }
}
