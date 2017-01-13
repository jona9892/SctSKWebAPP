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
    public class PollOptionController : ApiController
    {
        private IPollOptionRepository por;
        public PollOptionController()
        {
            por = new Facade(new DBContextSctJSK()).GetPollOptionRepository();
        }

        [ResponseType(typeof(PollOption))]
        public IHttpActionResult PostPollOption(PollOption p)
        {
            /*
            var pollOption = facade.GetPollOptionRepository().Add(p);
            if(pollOption != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created, facade.GetPollOptionRepository().Add(p));
                return response;
            }else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }*/
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pollOption = por.Add(p);
            if (pollOption == null)
            {
                return InternalServerError();
            }
            return Content(HttpStatusCode.Created, pollOption);

        }
    }
}
