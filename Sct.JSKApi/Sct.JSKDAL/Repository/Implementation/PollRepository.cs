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
    public class PollRepository : IPollRepository<Poll>
    {

        private DBContext ctx;

        public PollRepository(DBContext context)
        {
            ctx = context;
        }
        
        public Poll Add(Poll poll)
        {
            Poll newPoll = ctx.Polls.Add(poll);
            ctx.SaveChanges();
            return newPoll;
        }

        public void Delete(Poll p)
        {
            var poll = ctx.Polls.FirstOrDefault(x => x.Id == p.Id);
            ctx.Polls.Remove(poll);
            ctx.SaveChanges();
        }

        public Poll Read(int id)
        {
            var poll = ctx.Polls.Include("PollOptions").Where(c => c.Id == id).FirstOrDefault();
            return poll;
        }

        public List<Poll> ReadAll()
        {
            return ctx.Polls.Include("PollOptions").ToList();
        }

        public Poll Update(Poll p)
        {
            var pollDB = ctx.Polls.FirstOrDefault(c => c.Id == p.Id);
            pollDB.Question = p.Question;
            pollDB.Active = p.Active;

            ctx.SaveChanges();
            return pollDB;
        }
    }
}
