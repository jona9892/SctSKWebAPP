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
    public class PollController : ApiController
    {
        private Facade facade;
        public PollController()
        {
            facade = new Facade(new DBContextSctJSK());
        }

        public HttpResponseMessage GetPolls()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetPollRepository().ReadAll());
            return response;
        }

        public Poll GetPoll(int id)
        {
            return facade.GetPollRepository().Read(id);
        }

        public Poll PostPoll(Poll p)
        {
            return facade.GetPollRepository().Add(p);
        }

        public Poll PutPoll(int id, Poll p)
        {
            if (p == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            p.Id = id;


            facade.GetPollRepository().Update(p);
            return p;
        }

        public void DeletePoll(int id)
        {
            var poll = facade.GetPollRepository().Read(id);
            facade.GetPollRepository().Delete(poll);
        }
    }
}
