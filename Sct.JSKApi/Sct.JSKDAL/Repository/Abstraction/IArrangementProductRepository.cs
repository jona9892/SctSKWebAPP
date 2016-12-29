using Sct.JSKDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Absttraction
{
    public interface IArrangementProductRepository<ArrangementProduct>
    {
        void create(ArrangementProduct ap);
        List<ArrangementProduct> ReadAll();
        ArrangementProduct Read(int id);
        ArrangementProduct Update(ArrangementProduct ap);
        ArrangementProduct Delete(ArrangementProduct ap);
    }
}
