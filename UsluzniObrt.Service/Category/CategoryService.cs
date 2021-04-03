using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;
using UsluzniObrt.Repository;

namespace UsluzniObrt.Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService()
        {
                    
        }

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Add(Category newItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void edit(Category item)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll().ToList();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
