using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOModel;
using System.Net.Http;

namespace GatewayService.Services.Abstraction
{
    public interface IArrangementService<Arrangement>
    {
        Arrangement Add(Arrangement item);
        IEnumerable<Arrangement> GetAll();
        Arrangement Get(int id);
        HttpResponseMessage Update(Arrangement item);
        HttpResponseMessage Delete(Arrangement item);
        IEnumerable<Events> GetEvents();
    }
}
