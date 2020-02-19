using NewMTest.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;

namespace NewMTest.Data.Repository
{
    public class DataRepository<T> : IDisposable, IDataRepository<T> where T : class
    {
        protected ApplicationDbContext context = new ApplicationDbContext();

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void AddList(IList<T> obj)
        {
            context.Set<T>().AddRange(obj);
        }
        public void AddOrUpdate(T obj)
        {
            EntityEntry<T> entry = context.Entry(obj);
            IKey primaryKey = entry.Metadata.FindPrimaryKey();
            if (primaryKey != null)
            {
                object[] keys = primaryKey.Properties.Select(x => x.FieldInfo.GetValue(obj))
                                                .ToArray();
                T result = context.Find<T>(keys);
                if (result == null)
                {
                    context.Add(obj);
                }
                else
                {
                    context.Entry(result).State = EntityState.Detached;
                    context.Update(obj);
                }
            }
        }
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public void DeleteList(IList<T> list)
        {
            context.Set<T>().RemoveRange(list);
        }
        public async Task<T> SaveAsync(T entity)
        {
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
        public IQueryable<T> GetAllAsNoTracking()
        {
            return context.Set<T>().AsNoTracking();
        }
        public async Task<bool> Exist(long id)
        {
            var t = await GetById(id);
            return t == null;
        }
        public async Task<T> GetById(long id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
