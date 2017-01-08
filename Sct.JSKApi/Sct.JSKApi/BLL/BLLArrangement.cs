using Sct.JSKApi.Models;
using Sct.JSKDAL;
using Sct.JSKDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sct.JSKApi.BLL
{
    public class BLLArrangement
    {
        Facade facade;

        public BLLArrangement(DBContext context)
        {
            facade = new Facade(context);
        }

        public List<Events> convertArrangementDataToEvents()
        {
            var arrangements = facade.GetArrangementRepository().ReadAll();
            var events = new List<Events>();
            foreach (var arrangement in arrangements)
            {
                Events e = new Events();
                e.id = arrangement.Id;
                e.title = arrangement.Title;
                e.start = arrangement.Date;
                e.end = arrangement.Date;
                e.allDay = false;

                events.Add(e);
            }
            return events;
        }
    }
}