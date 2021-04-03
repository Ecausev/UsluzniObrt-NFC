using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;
using UsluzniObrt.Repository;

namespace UsluzniObrt.Service
{

    public class MenuService : IMenuService
    {
        public IMenuitemRepository _menuitemRepository;
        
        public MenuService()
        {


        }
        public MenuService(IMenuitemRepository menuitemRepository)
        {
            _menuitemRepository = menuitemRepository;
        }
        public void Add(MenuItem newItem)
        {
            _menuitemRepository.Insert(newItem);
            _menuitemRepository.Save();
            
        }

        public void Delete(int id)
        {
            _menuitemRepository.Delete(id);
            _menuitemRepository.Save();
        }

        public void edit(MenuItem item)
        {
            _menuitemRepository.Update(item);
            _menuitemRepository.Save();
        }

        public List<MenuItem> GetAll()
        {
            return _menuitemRepository.GetAll().ToList();
        }

        public MenuItem GetById(int id)
        {
            return _menuitemRepository.GetById(id);
        }
    }
}
