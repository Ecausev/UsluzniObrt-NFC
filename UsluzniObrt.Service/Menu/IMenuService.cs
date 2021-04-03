using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;

namespace UsluzniObrt.Service
{
   public interface IMenuService
    {
        List<MenuItem> GetAll();
        void Add(MenuItem newItem);
        void Delete(int id);
        void edit(MenuItem item);
        MenuItem GetById(int id);
    }
}
