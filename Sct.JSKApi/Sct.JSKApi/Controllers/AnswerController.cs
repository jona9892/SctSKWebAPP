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

        public HttpResponseMessage PostAnswer(Answer p)
        {


            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetAnswerRepository().Add(p));
            return response;
        }

        [Route("api/Answer/{id}/user")]
        [HttpGet]
        public HttpResponseMessage GetAllByUser(int id)
        {

            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetAnswerRepository().ReadAllByUser(id));
            return response;
        }

        [Route("api/Answer/{id}/polls")]
        [HttpGet]
        public HttpResponseMessage GetAllUnAnsweredByUser(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, ba.GetUnAnsweredPolls(id));
            return response;
        }

        [Route("api/Answer/{id}/results")]
        [HttpGet]
        public HttpResponseMessage GetResultsOfPoll(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetAnswerRepository().ReadResults(id));
            return response;
        }
    }
}
