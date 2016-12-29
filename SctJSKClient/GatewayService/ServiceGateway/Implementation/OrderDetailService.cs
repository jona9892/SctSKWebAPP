using GatewayService.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOModel;
using System.Net.Http;

namespace GatewayService.Services.Implementation
{
    public class OrderDetailService : IOrderDetailService
    {
        //Constant, the address of the web api
        protected static readonly string END_POINT = END_POINT + "http://localhost:55391/API/OrderDetail";

        public void create(OrderDetail orderDetail)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(END_POINT + "/", orderDetail).Result;
            }
        }
    }
}
