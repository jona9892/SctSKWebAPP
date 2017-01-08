using Sct.JSKDAL.Context;
using Sct.JSKDAL.Entities;
using Sct.JSKDAL.Repository.Absttraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Implementation
{
    public class PollOptionRepository : IPollOptionRepository<PollOption>
    {
        private DBContext ctx;

        public PollOptionRepository(DBContext context)
        {
            ctx = context;
        }


        public PollOption Add(PollOption pollOption)
        {
            PollOption newPollOption = ctx.PollOptions.Add(pollOption);
            ctx.SaveChanges();
            return newPollOption;
        }
    }
}
