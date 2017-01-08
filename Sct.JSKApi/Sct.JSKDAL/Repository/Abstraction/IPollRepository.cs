using Sct.JSKDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Absttraction
{
    public interface IPollRepository<Poll>
    {
        List<Poll> ReadAll();
        Poll Add(Poll poll);
        Poll Read(int id);
        void Update(Poll p);
        void Delete(Poll p);
    }
}
