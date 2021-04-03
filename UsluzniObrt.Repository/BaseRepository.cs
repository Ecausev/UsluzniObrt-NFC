using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace UsluzniObrt.Repository
{ 
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private DbContext _entities ;
        private DbSet<T> _dbset ;
        public BaseRepository(DbContext context)
        {

            _entities = context;
            _dbset = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }
        public T GetById(object id)
        {
            return _dbset.Find(id);
        }
        public void Insert(T obj)
        {
            _dbset.Add(obj);
        }
        public void Update(T obj)
        {
            _dbset.Attach(obj);
            _entities.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = _dbset.Find(id);
            _dbset.Remove(existing);
        }
        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}
