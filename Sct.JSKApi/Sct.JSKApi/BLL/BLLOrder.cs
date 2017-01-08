using Sct.JSKApi.Models;
using Sct.JSKDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Sct.JSKDAL.Context;
using System.Net;
using System.Net.Http;
using Sct.JSKDAL.Entities;

namespace Sct.JSKApi.BLL
{
    public class BLLOrder
    {
        Facade facade;

        public BLLOrder(DBContext context)
        {
            facade = new Facade(context);
        }

        public IEnumerable<ProductCount> CountOrderedProductsByDate(string orderdate)
        {
            List<ProductCount> productCounts = new List<ProductCount>();
            List<Order> getAllOrders = facade.GetOrderRepository().GetOrderedProductsByOrder(orderdate).ToList();
            foreach (var order in getAllOrders)
            {                
                foreach (var od in order.OrderDetails)
                {
                    ProductCount productCount = new ProductCount();
                    productCount.NumberOfProduct = od.Quantity;
                    productCount.product = od.Product;
                    productCount.TotalPrice = od.Quantity * od.Product.Price; 
                    if (productCounts.Select(z =>z.product).Contains(od.Product))
                    {
                        var getObj = productCounts.FirstOrDefault(x => x.product == od.Product);
                        getObj.NumberOfProduct = getObj.NumberOfProduct + od.Quantity;
                        getObj.TotalPrice = od.Price * getObj.NumberOfProduct;
                    }
                    else
                    {
                        productCounts.Add(productCount);
                    }                                    
                } 
            }
            return productCounts;
        }
        //------------------------sprint 3----------------------------------------------
        public IEnumerable<ProductCount> CountOrderedProductsByDates(string startDate, string endDate)
        {
            List<ProductCount> productCounts = new List<ProductCount>();
            List<Order> getOrders = facade.GetOrderRepository().GetOrderedProductsByDates(startDate, endDate).ToList();
            foreach (var order in getOrders)
            {
                foreach (var od in order.OrderDetails)
                {
                    ProductCount productCount = new ProductCount();
                    productCount.NumberOfProduct = od.Quantity;
                    productCount.product = od.Product;
                    productCount.TotalPrice = od.Quantity * od.Product.Price;
                    if (productCounts.Select(z => z.product).Contains(od.Product))
                    {
                        var getObj = productCounts.FirstOrDefault(x => x.product == od.Product);
                        getObj.NumberOfProduct = getObj.NumberOfProduct + od.Quantity;
                        getObj.TotalPrice = od.Price * getObj.NumberOfProduct;
                    }
                    else
                    {
                        productCounts.Add(productCount);
                    }
                }
            }
            return productCounts;
        }

        public HttpResponseMessage ConfirmDeleteOrder(int orderid, int userid)
        {
            Order order = facade.GetOrderRepository().Read(orderid);
            HttpResponseMessage response; 
            DateTime now = DateTime.Now;
            DateTime deadline = order.OrderDate;
            if(now > deadline.AddDays(-24) && now < deadline)
            {
                response = new HttpResponseMessage(System.Net.HttpStatusCode.Conflict);
            }else
            {
                facade.GetOrderRepository().Delete(userid, order);
                response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            
            return response;
            
            
        }
    }
}