using EShop.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace EShop.Repository
{
    public interface IGenericRepository< T, out Q> where T : class where Q : BaseContext
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}