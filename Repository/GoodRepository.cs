﻿using DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GoodRepository:GenericRepository<Good>
    {
        public GoodRepository(DbContext context) : base(context) { }
    }
}
