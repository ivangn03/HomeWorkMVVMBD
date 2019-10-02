using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        DbContext context;
        IDbSet<T> dbSet;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public void CreateOrUpdate(T data)
        {
            dbSet.AddOrUpdate<T>(data);
        }

        public void Delete(T data)
        {
            dbSet.Remove(data);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public void Save()
        {
            context.SaveChanges();
        }
        ~GenericRepository()
        {
            context.Dispose();
        }
    }
}
