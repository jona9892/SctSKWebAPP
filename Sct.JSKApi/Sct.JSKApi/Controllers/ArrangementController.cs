using Sct.JSKApi.BLL;
using Sct.JSKApi.Models;
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
    public class ArrangementController : ApiController
    {
        private IRepository<Arrangement> ar;
        private BLLArrangement ba;
        public ArrangementController()
        {
            ar = new Facade(new DBContextSctJSK()).GetArrangementRepository();
            ba = new BLLArrangement(new DBContextSctJSK());
        }

        public IEnumerable<Arrangement> GetArrangements()
        {
            var arrangements = ar.ReadAll();
            //var response = Request.CreateResponse(HttpStatusCode.OK, arrangements);
            return arrangements;
          
        }

        [ResponseType(typeof(Arrangement))]
        public IHttpActionResult GetArrangement(int id)
        {

            /*
            if(arrangement != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, arrangement);
                return response;
            }else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }*/
            var arrangement = ar.Read(id);
            if (arrangement == null)
            {
                return NotFound();
            }

            return Ok(arrangement);

        }

        [ResponseType(typeof(Arrangement))]
        public IHttpActionResult PostArrangement(Arrangement p)
        {
            /*
            var arrangement = ar.Add(p);
            if (arrangement != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created, arrangement);
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
            var arrangement = ar.Add(p);
            return Content(HttpStatusCode.Created, arrangement);
            //return CreatedAtRoute("DefaultApi", new { id = arrangement.Id }, arrangement);
        }
        /*
        public void PutArrangement(int id, Arrangement p)
        {
            if (p == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            p.Id = id;


            facade.GetArrangementRepository().Update(p);
        }*/

        public void DeleteArrangement(int id)
        {
            var e = ar.Read(id);
            if (e == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            ar.Delete(e);
        }

        [Route("api/arrangement/events")]
        [HttpGet]
        public IEnumerable<Events> GetEvents()
        {
            var events = ba.convertArrangementDataToEvents();

            return events;
        }

    }
}
