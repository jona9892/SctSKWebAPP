using Sct.JSKDAL.Context;
using Sct.JSKDAL.Repository.Absttraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Sct.JSKDAL.Entities;

namespace Sct.JSKDAL.Repository.Implementation
{
    public class ArrangementRepository : IRepository<Arrangement>
    {

        private DBContext ctx;

        public ArrangementRepository(DBContext context)
        {
            ctx = context;
        }

        public Arrangement Add(Arrangement a)
        {
            Arrangement newArrangement = ctx.Arrangements.Add(a);
            ctx.SaveChanges();
            return newArrangement;
        }

        public void Delete(Arrangement a)
        {
            var arrangement = ctx.Arrangements.FirstOrDefault(x => x.Id == a.Id);
            ctx.Arrangements.Remove(arrangement);
            ctx.SaveChanges();
        }

        public Arrangement Read(int id)
        {
            var arrangement = ctx.Arrangements.Include("Products").Include(p => p.Products.Select(od => od.Product))
                .Where(c => c.Id == id).FirstOrDefault();
            return arrangement;
        }

        public List<Arrangement> ReadAll()
        {
            return ctx.Arrangements.Include("Products").ToList();
        }

        public Arrangement Update(Arrangement e)
        {
            throw new NotImplementedException();
        }
    }
}
