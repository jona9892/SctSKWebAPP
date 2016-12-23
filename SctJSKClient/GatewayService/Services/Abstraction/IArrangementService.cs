using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOModel;

namespace GatewayService.Services.Abstraction
{
    public interface IArrangementService<Arrangement>
    {
        Arrangement Add(Arrangement item);
        IEnumerable<Arrangement> GetAll();
        Arrangement Get(int id);
        Arrangement Update(Arrangement item);
        Arrangement Delete(Arrangement item);
        IEnumerable<Events> GetEvents(int id);
    }
}
