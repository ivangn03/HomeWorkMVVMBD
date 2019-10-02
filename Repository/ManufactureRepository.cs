using DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ManufactureRepository:GenericRepository<Manufacture>
    {
        public ManufactureRepository(DbContext context) : base(context) { }
    }
}
