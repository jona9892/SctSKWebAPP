using Newtonsoft.Json.Linq;
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
    public class OrderController : ApiController
    {
        private Facade facade;
        private BLLOrder bo;
        public OrderController()
        {
            facade = new Facade(new DBContextSctJSK());
            bo = new BLLOrder(new DBContextSctJSK());
        }
        
        public Order PostOrder(Order order)
        {
            return facade.GetOrderRepository().Add(order);
        }

        public Order GetOrder(int id)
        {
            return facade.GetOrderRepository().Read(id); 
        }

        public IEnumerable<Order> GetOrder()
        {
            return facade.GetOrderRepository().ReadAll();
        }

        [Route("api/order/{orderdate}/users")]
        [HttpGet]
        public IEnumerable<User> GetOrderedCustomers(string orderdate)
        {
            return facade.GetOrderRepository().GetAllOrderedCustomers(orderdate);
        }

        [Route("api/order/{orderdate}/{id}/users")]
        [HttpGet]
        public Order GetOrderedCustomers(string orderdate, int id)
        {
            return facade.GetOrderRepository().GetAllOrderedCustomerDetail(orderdate, id);
        }

        [Route("api/order/{orderdate}/products")]
        [HttpGet]
        public IEnumerable<ProductCount> GetOrderedProducts(string orderdate)
        {
            return bo.CountOrderedProductsByDate(orderdate);
        }

        public void DeleteOrder(int orderid, int userid)
        {
            bo.ConfirmOrder(orderid, userid);
        }

        [Route("api/order/{startdate}/{enddate}/products")]
        [HttpGet]
        public IEnumerable<ProductCount> GetOrderedProductsByDates(string startdate, string enddate)
        {
            return bo.CountOrderedProductsByDates(startdate, enddate);
        }
    }
}
