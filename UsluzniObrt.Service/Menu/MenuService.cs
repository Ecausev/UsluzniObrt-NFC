using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;
using UsluzniObrt.Repository;
using UsluzniObrt.Service.Menu.DTO;

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
        public void Add(CreateMenuItem Item)
        {
            var newItem = new MenuItem {

                Name = Item.Name,
                Description = Item.Description,
                Price = Item.Price,
                Status = Item.Status,
                CategoryId = Item.CategoryId
            };
            _menuitemRepository.Insert(newItem);
            _menuitemRepository.Save();
            
        }

        public void Delete(int id)
        {
            _menuitemRepository.Delete(id);
            _menuitemRepository.Save();
        }

        public void edit(EditMenuItem item)
        {
            var oldItem = _menuitemRepository.GetById(item.Id);
            if (oldItem != null)
            {
                oldItem.Status = item.Status;
                oldItem.Name = item.Name;
                oldItem.Price = item.Price;
                oldItem.Description = item.Description;
                oldItem.CategoryId = item.CategoryId;
                _menuitemRepository.Update(oldItem);
                _menuitemRepository.Save();
            }

            
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
