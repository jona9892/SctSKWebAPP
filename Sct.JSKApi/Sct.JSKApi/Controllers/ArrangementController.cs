using Sct.JSKApi.BLL;
using Sct.JSKApi.Models;
using Sct.JSKDAL;
using Sct.JSKDAL.Context;
using Sct.JSKDAL.DomainModel;
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

        public IEnumerable<Arrangement> GetArrangements()
        {
            return facade.GetArrangementRepository().ReadAll();
        }

        public Arrangement GetArrangement(int id)
        {
            return facade.GetArrangementRepository().Read(id);
        }

        public Arrangement PostArrangement(Arrangement p)
        {
            return facade.GetArrangementRepository().Add(p);
        }

        public Arrangement PutArrangement(int id, Arrangement p)
        {
            if (p == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            p.Id = id;


            facade.GetArrangementRepository().Update(p);
            return p;
        }

        public void DeleteArrangement(int id)
        {
            var e = facade.GetArrangementRepository().Read(id);
            facade.GetArrangementRepository().Delete(e);
        }

        [Route("api/arrangement/{id}/events")]
        [HttpGet]
        public IEnumerable<Events> GetEvents(int id)
        {
            return ba.convertToArrangementsToEvents(id);
        }

    }
}
