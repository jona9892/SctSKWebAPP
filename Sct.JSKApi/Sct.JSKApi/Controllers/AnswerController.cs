using Sct.JSKApi.BLL;
using Sct.JSKDAL;
using Sct.JSKDAL.Context;
using Sct.JSKDAL.Entities;
using Sct.JSKDAL.Repository.Absttraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Sct.JSKApi.Controllers
{
    public class AnswerController : ApiController
    {
        private IAnswerRepository ar;
        private BLLAnswer ba;
        public AnswerController()
        {
            ar = new Facade(new DBContextSctJSK()).GetAnswerRepository();
            ba = new BLLAnswer(new DBContextSctJSK());
        }

        [ResponseType(typeof(Answer))]
        public IHttpActionResult PostAnswer(Answer p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answer = ar.Add(p);

            if(answer == null)
            {
                return InternalServerError();
            }
            return Content(HttpStatusCode.Created, answer); 

        }

        [Route("api/Answer/{id}/user")]
        [HttpGet]
        public IEnumerable<Answer> GetAllByUser(int id)
        {
            var answer = ar.ReadAllByUser(id);
 
            //var response = Request.CreateResponse(HttpStatusCode.OK, answer);
            return answer;
        }

        [Route("api/Answer/{id}/polls")]
        [HttpGet]
        public IEnumerable<Poll> GetAllUnAnsweredByUser(int id)
        {
            var polls = ba.GetUnAnsweredPolls(id);

            //var response = Request.CreateResponse(HttpStatusCode.OK, polls);
            return polls;

        }

        [Route("api/Answer/{id}/results")]
        [HttpGet]
        public IEnumerable<PollResult> GetResultsOfPoll(int id)
        {
            var pollResult = ar.ReadResults(id);
            //var response = Request.CreateResponse(HttpStatusCode.OK, pollResult);
            return pollResult;
        }
    }
}
