using Newtonsoft.Json.Linq;
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
    public class OrderController : ApiController
    {
        private Facade facade;
        private BLLOrder bo;
        public OrderController()
        {
            facade = new Facade(new DBContextSctJSK());
            bo = new BLLOrder(new DBContextSctJSK());
        }
        
        public HttpResponseMessage PostOrder(Order order)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, facade.GetOrderRepository().Add(order));
            return response;
        }

        public HttpResponseMessage GetOrder(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetOrderRepository().Read(id));
            return response;
        }

        public HttpResponseMessage GetOrder()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetOrderRepository().ReadAll());
            return response;
        }

        [Route("api/order/{orderdate}/users")]
        [HttpGet]
        public HttpResponseMessage GetOrderedCustomers(string orderdate)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetOrderRepository().GetAllOrderedCustomers(orderdate));
            return response;
        }

        [Route("api/order/{orderdate}/{id}/users")]
        [HttpGet]
        public Order HttpResponseMessage(string orderdate, int id)
        {
            return facade.GetOrderRepository().GetAllOrderedCustomerDetail(orderdate, id);
        }

        [Route("api/order/{orderdate}/products")]
        [HttpGet]
        public HttpResponseMessage GetOrderedProducts(string orderdate)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, bo.CountOrderedProductsByDate(orderdate));
            return response;
        }

        public HttpResponseMessage DeleteOrder(int orderid, int userid)
        {
            return bo.ConfirmDeleteOrder(orderid, userid);
        }

        [Route("api/order/{startdate}/{enddate}/products")]
        [HttpGet]
        public HttpResponseMessage GetOrderedProductsByDates(string startdate, string enddate)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, bo.CountOrderedProductsByDates(startdate, enddate));
            return response;
        }
    }
}
