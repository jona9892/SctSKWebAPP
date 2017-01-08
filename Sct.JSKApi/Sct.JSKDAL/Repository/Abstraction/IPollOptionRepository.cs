using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Absttraction
{
    public interface IPollOptionRepository<PollOption>
    {
        PollOption Add(PollOption pollOption);
    }
}
