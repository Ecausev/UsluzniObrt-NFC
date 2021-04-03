using System.Collections.Generic;
using UsluzniObrt.Model;
namespace UsluzniObrt.Service
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        void Add(Category newItem);
        void Delete(int id);
        void edit(Category item);
        Category GetById(int id);
    }
}