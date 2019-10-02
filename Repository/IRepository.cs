using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> 
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void CreateOrUpdate(T data);
        void Delete(T data);
        void Save();
    }
}
