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
    public class OrderDetailController : ApiController
    {
        private Facade facade;
        public OrderDetailController()
        {
            facade = new Facade(new DBContextSctJSK());
        }

        public void PostOrderDetail(OrderDetail od)
        {
            facade.GetOrderDetailRepository().create(od);
        }
    }
}
