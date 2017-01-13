using Newtonsoft.Json.Linq;
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
    public class OrderController : ApiController
    {
        private IOrderRepository<Order> or;
        private BLLOrder bo;
        public OrderController()
        {
            or = new Facade(new DBContextSctJSK()).GetOrderRepository();
            bo = new BLLOrder(new DBContextSctJSK());
        }

        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(Order order)
        {
            /*
            var getOrder = facade.GetOrderRepository().Add(order);

            if (getOrder != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created, getOrder);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable);
            }*/
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var getOrder = or.Add(order);
            if(getOrder == null)
            {
                return InternalServerError();
            }
            return Content(HttpStatusCode.Created, getOrder);
            //return CreatedAtRoute("DefaultApi", new { id = getOrder.Id }, getOrder);
        }

        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(int id)
        {
            /*
            var getOrder = facade.GetOrderRepository().Read(id);

            if (getOrder != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, getOrder);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }*/
            var getOrder = or.Read(id);
            if (getOrder == null)
            {
                return NotFound();
            }

            return Ok(getOrder);
        }

        public IEnumerable<Order> GetOrder()
        {
            var getOrders = or.ReadAll();

            //var response = Request.CreateResponse(HttpStatusCode.OK, getOrder);
            return getOrders;

        }

        [Route("api/order/{orderdate}/users")]
        [HttpGet]
        public IEnumerable<User> GetOrderedCustomers(string orderdate)
        {
            var getUsers = or.GetAllOrderedCustomers(orderdate);

            //var response = Request.CreateResponse(HttpStatusCode.OK, getOrder);
            return getUsers;

        }

        [Route("api/order/{orderdate}/{id}/users")]
        [HttpGet]
        [ResponseType(typeof(Order))]
        public IHttpActionResult getOrderedCustomerDetail(string orderdate, int id)
        {
            var getOrder = or.GetAllOrderedCustomerDetail(orderdate, id);
            /*var response = Request.CreateResponse(HttpStatusCode.OK, getOrder);
            return response;*/
            if (getOrder == null)
            {
                return NotFound();
            }
            return Ok(getOrder);
        }

        [Route("api/order/{orderdate}/products")]
        [HttpGet]
        public IEnumerable<ProductCount> GetOrderedProducts(string orderdate)
        {
            var productCounts = bo.CountOrderedProductsByDate(orderdate);

            //var response = Request.CreateResponse(HttpStatusCode.OK, getOrder);
            return productCounts;

        }

        public HttpResponseMessage DeleteOrder(int orderid, int userid)
        {
            return bo.ConfirmDeleteOrder(orderid, userid);
        }

        [Route("api/order/{startdate}/{enddate}/products")]
        [HttpGet]
        public IEnumerable<ProductCount> GetOrderedProductsByDates(string startdate, string enddate)
        {
            var productCounts = bo.CountOrderedProductsByDates(startdate, enddate);
            //var response = Request.CreateResponse(HttpStatusCode.OK, getOrder);
            return productCounts;

        }
    }
}
