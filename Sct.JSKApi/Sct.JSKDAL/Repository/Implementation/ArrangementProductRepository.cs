using Sct.JSKDAL.Context;
using Sct.JSKDAL.Entities;
using Sct.JSKDAL.Repository.Absttraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Implementation
{
    public class ArrangementProductRepository : IArrangementProductRepository
    {

        private DBContext ctx;

        public ArrangementProductRepository(DBContext context)
        {
            ctx = context;
        }

        public void create(ArrangementProduct ap)
        {
            ArrangementProduct newArrangementProduct = ctx.ArrangementProducts.Add(ap);
            ctx.SaveChanges();
        }
    }
}
