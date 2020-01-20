using EShop.DBContext;
using EShop.Resolver;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EShop.Repository
{
    public class GenericRepository<T,Q> : IGenericRepository<T,Q> where T : class where Q : BaseContext
    {
        private readonly BaseContext _context;
        private readonly DbSet<T> table;

        public GenericRepository(IDbContextResolver _dbContextResolver)
        {
            _context = _dbContextResolver.Resolve(typeof(Q));
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public T Insert(T obj)
        {
            return table.Add(obj).Entity;
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
