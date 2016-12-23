using Sct.JSKDAL;
using Sct.JSKDAL.Context;
using Sct.JSKDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sct.JSKApi.BLL
{
    public class BLLAnswer
    {
        Facade facade;

        public BLLAnswer(DBContext context)
        {
            facade = new Facade(context);
        }

        public List<Poll> GetUnAnsweredPolls(int id)
        {
            var polls = facade.GetPollRepository().ReadAll();
            var answersByUser = facade.GetAnswerRepository().ReadAllByUser(id);

            var pollslist = polls.Where(p => !answersByUser.Any(p2 => p2.PollId == p.Id));

            return pollslist.ToList();
        }       


    }
}