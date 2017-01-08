using Sct.JSKApi.BLL;
using Sct.JSKApi.Models;
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
    public class ArrangementController : ApiController
    {
        private Facade facade;
        private BLLArrangement ba;
        public ArrangementController()
        {
            facade = new Facade(new DBContextSctJSK());
            ba = new BLLArrangement(new DBContextSctJSK());
        }

        public HttpResponseMessage GetArrangements()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetArrangementRepository().ReadAll());
            return response;
        }

        public HttpResponseMessage GetArrangement(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetArrangementRepository().Read(id));
            return response;
        }

        public HttpResponseMessage PostArrangement(Arrangement p)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, facade.GetArrangementRepository().Add(p));
            return response;
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
            var e = facade.GetArrangementRepository().Read(id);
            facade.GetArrangementRepository().Delete(e);
        }

        [Route("api/arrangement/events")]
        [HttpGet]
        public IEnumerable<Events> GetEvents()
        {
            return ba.convertArrangementDataToEvents();
        }

    }
}
