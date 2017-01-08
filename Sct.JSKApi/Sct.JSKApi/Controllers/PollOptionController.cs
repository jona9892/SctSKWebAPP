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
    public class PollOptionController : ApiController
    {
        private Facade facade;
        public PollOptionController()
        {
            facade = new Facade(new DBContextSctJSK());
        }

        public HttpResponseMessage PostPollOption(PollOption p)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, facade.GetPollOptionRepository().Add(p));
            return response;            
        }
    }
}
