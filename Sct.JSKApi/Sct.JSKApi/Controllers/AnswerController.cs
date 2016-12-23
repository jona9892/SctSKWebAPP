using Sct.JSKApi.BLL;
using Sct.JSKDAL;
using Sct.JSKDAL.Context;
using Sct.JSKDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sct.JSKApi.Controllers
{
    public class AnswerController : ApiController
    {
        private Facade facade;
        private BLLAnswer ba;
        public AnswerController()
        {
            facade = new Facade(new DBContextSctJSK());
            ba = new BLLAnswer(new DBContextSctJSK());
        }

        public Answer PostAnswer(Answer p)
        {
            return facade.GetAnswerRepository().Add(p);
        }

        [Route("api/Answer/{id}/user")]
        [HttpGet]
        public List<Answer> GetAllByUser(int id)
        {
            return facade.GetAnswerRepository().ReadAllByUser(id);
        }

        [Route("api/Answer/{id}/polls")]
        [HttpGet]
        public List<Poll> GetAllUnAnsweredByUser(int id)
        {
            return ba.GetUnAnsweredPolls(id);
        }

        [Route("api/Answer/{id}/results")]
        [HttpGet]
        public List<PollResult> GetResultsOfPoll(int id)
        {
            return facade.GetAnswerRepository().ReadResults(id);
        }
    }
}
