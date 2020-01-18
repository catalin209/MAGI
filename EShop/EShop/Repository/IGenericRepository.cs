using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace EShop.Repository
{
    public interface IGenericRepository<T,Q> where T : class where Q : DbContext
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}