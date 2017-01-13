using Sct.JSKApi.Models;
using Sct.JSKDAL;
using Sct.JSKDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sct.JSKApi.BLL
{
    public class BLLUser
    {
        Facade facade;

        public BLLUser(DBContext context)
        {
            facade = new Facade(context);
        }

        public List<Events> convertToOrdersToEvents(int id)
        {
            var currentOrders = facade.GetUserRepository().GetCurrentOrders(id);
            var events = new List<Events>();
            foreach(var order in currentOrders)
            {
                if(order.TimeOfDay == "09:50")
                {
                    TimeSpan ts = new TimeSpan(10,0,0);
                    order.OrderDate = order.OrderDate + ts;
                }else
                {
                    TimeSpan ts = new TimeSpan(12, 0, 0);
                    order.OrderDate = order.OrderDate + ts;
                }
                Events e = new Events();
                e.id = order.Id;
                e.title = "Ordre Nr:" + order.Id;
                e.start = order.OrderDate;
                e.allDay = false;
                
                events.Add(e);
            }
            return events;
        }
    }
}