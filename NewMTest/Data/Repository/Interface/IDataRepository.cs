using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMTest.Data.Repository
{
    public interface IDataRepository<T> where T : class
    {
        void Add(T entity);
        void AddList(IList<T> obj);
        void AddOrUpdate(T obj);
        void Update(T entity);
        void Delete(T entity);
        void DeleteList(IList<T> list);
        Task<T> SaveAsync(T entity);
        Task<int> SaveChangesAsync();
        IQueryable<T> GetAllAsNoTracking();
        Task<T> GetById(long id);
        Task<bool> Exist(long id);
        void Dispose();
    }
}
