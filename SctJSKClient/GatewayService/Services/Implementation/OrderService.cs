using DTOModel;
using GatewayService.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GatewayService.Services.Implementation
{
    public class OrderService : IOrderService<Order>
    {
        //Constant, the address of the web api
        protected static readonly string END_POINT = END_POINT + "http://localhost:55391/API/Order";

        public Order Add(Order item)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(END_POINT + "/", item).Result;
                return response.Content.ReadAsAsync<Order>().Result;
            }
        }

        public void Delete(int orderid, int userid)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync(END_POINT + "?" + "orderid="+orderid + "&userid=" + userid).Result;
            }
        }

        public Order Get(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + id).Result;
                return response.Content.ReadAsAsync<Order>().Result;
            }
        }

        public IEnumerable<Order> GetAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
            }
        }

        public IEnumerable<User> GetAllOrderedCustomers(string orderdate)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + orderdate + "/users").Result;
                return response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
        }

        public Order GetOrderedCustomerDetails(string orderdate, int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + orderdate + "/" + id+ "/users").Result;
                return response.Content.ReadAsAsync<Order>().Result;
            }
        }

        public IEnumerable<ProductCount> GetOrderedProducts(string orderdate)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + orderdate + "/products").Result;
                return response.Content.ReadAsAsync<IEnumerable<ProductCount>>().Result;
            }
        }

        public IEnumerable<ProductCount> GetOrderedProductsByDates(string startDate, string endDate)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + startDate + "/" + endDate + "/products").Result;
                return response.Content.ReadAsAsync<IEnumerable<ProductCount>>().Result;
            }
        }
    }
}
