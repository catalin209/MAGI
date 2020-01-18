using EShop.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Repository
{
    public class GenericRepository<T,Q> : IGenericRepository<T,Q> where T : class where Q : DbContext
    {
        private readonly DbContext _context;
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

        public void Insert(T obj)
        {
            table.Add(obj);
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
