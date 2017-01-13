using Sct.JSKDAL.Context;
using Sct.JSKDAL.Entities;
using Sct.JSKDAL.Repository.Absttraction;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Implementation
{
    public class AnswerRepository : IAnswerRepository
    {
        private DBContext ctx;

        public AnswerRepository(DBContext context)
        {
            ctx = context;
        }

        public Answer Add(Answer answer)
        {
            Answer newAnswer = ctx.Answers.Add(answer);
            ctx.SaveChanges();
            return newAnswer;
        }

        public List<Answer> ReadAllByUser(int userid)
        {
            return ctx.Answers.Where(u => u.UserId == userid).ToList();
        }

        public List<PollResult> ReadResults(int pollid)
        {
            var query = ctx.Answers.Where(a => a.PollId == pollid)
                .GroupBy(po => po.PollOption)
                .Select(r => new PollResult { OptionText = r.Key.OptionText,  Votes = r.Count() })
                .ToList();

            return query;
        }
    }
}
