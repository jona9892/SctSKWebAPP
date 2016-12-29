using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GatewayService.Services.Abstraction
{
    public interface IPollService<Poll>
    {
        IEnumerable<Poll> ReadAll();
        HttpResponseMessage Add(Poll poll);
        Poll Read(int id);
        HttpResponseMessage Update(Poll p);
        HttpResponseMessage Delete(Poll p);
    }
}
