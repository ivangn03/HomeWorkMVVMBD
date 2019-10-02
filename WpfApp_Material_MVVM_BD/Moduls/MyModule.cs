using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using Ninject.Modules;
using Repository;

namespace WpfApp_Material_MVVM_BD.Moduls
{
    class MyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ShopDBEntities1>();
            Bind<IRepository<Category>>().To<CategotyRepository>();
            Bind<IRepository<Manufacture>>().To<ManufactureRepository>();
            Bind<IRepository<Good>>().To<GoodRepository>();
        }
    }
}
