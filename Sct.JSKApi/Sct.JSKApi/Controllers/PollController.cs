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
    public class PollController : ApiController
    {
        private IPollRepository<Poll> pr;
        public PollController()
        {
            pr = new Facade(new DBContextSctJSK()).GetPollRepository();
        }

        public IEnumerable<Poll> GetPolls()
        {
            var polls = pr.ReadAll();
            //var response = Request.CreateResponse(HttpStatusCode.OK, poll);
            return polls;
        }

        [ResponseType(typeof(Poll))]
        public IHttpActionResult GetPoll(int id)
        {
            /*
            var poll = facade.GetPollRepository().Read(id);
            if (poll != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, poll);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }*/
            var poll = pr.Read(id);
            if (poll == null)
            {
                return NotFound();
            }

            return Ok(poll);
        }

        [ResponseType(typeof(Poll))]
        public IHttpActionResult PostPoll(Poll p)
        {
            /*
            var poll = facade.GetPollRepository().Add(p);
            if (poll != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, poll);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }*/
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var poll = pr.Add(p);
            if(poll == null)
            {
                return InternalServerError();
            }
            return Content(HttpStatusCode.Created, poll);
            //return CreatedAtRoute("DefaultApi", new { id = poll.Id }, poll);
        }

        [ResponseType(typeof(Category))]
        public IHttpActionResult PutPoll(int id, Poll p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var poll = pr.Update(p);
            if(poll == null)
            {
                return InternalServerError();
            }
            return Ok(poll);
            /*
            var poll = facade.GetPollRepository().Update(p);
            if (poll != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created, poll);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }*/
        }

        public void DeletePoll(int id)
        {
            var poll = pr.Read(id);
            if (poll == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            pr.Delete(poll);
        }
    }
}
