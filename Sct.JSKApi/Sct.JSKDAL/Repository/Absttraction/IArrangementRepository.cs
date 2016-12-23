using Sct.JSKDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Absttraction
{
    public interface IArrangementRepository<Arrangement>
    {
        List<Arrangement> ReadAll();
        Arrangement Add(Arrangement a);
        Arrangement Read(int id);
        Arrangement Update(Arrangement a);
        Arrangement Delete(Arrangement a);
    }
}
