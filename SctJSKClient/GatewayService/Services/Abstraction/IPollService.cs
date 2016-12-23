using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayService.Services.Abstraction
{
    public interface IPollService<Poll>
    {
        IEnumerable<Poll> ReadAll();
        Poll Add(Poll poll);
        Poll Read(int id);
        Poll Update(Poll p);
        Poll Delete(Poll p);
    }
}
