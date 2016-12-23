using Sct.JSKDAL.Context;
using Sct.JSKDAL.DomainModel;
using Sct.JSKDAL.Repository.Absttraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Implementation
{
    public class ArrangementProductRepository : IArrangementProductRepository<ArrangementProduct>
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

        public ArrangementProduct Delete(ArrangementProduct ap)
        {
            throw new NotImplementedException();
        }

        public ArrangementProduct Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<ArrangementProduct> ReadAll()
        {
            throw new NotImplementedException();
        }

        public ArrangementProduct Update(ArrangementProduct ap)
        {
            throw new NotImplementedException();
        }
    }
}
