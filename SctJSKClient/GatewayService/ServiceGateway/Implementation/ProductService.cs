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
    public class ProductService : IProductService<Product>
    {
        //Constant, the address of the web api
        protected static readonly string END_POINT = "http://localhost:55391/API/Product";

        public HttpResponseMessage Add(Product item)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(END_POINT + "/", item).Result;
                return response;
            }
        }

        public HttpResponseMessage Delete(Product item)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync(END_POINT + "/" + item.Id).Result;
                return response;
            }
        }

        public Product Get(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + id).Result;
                return response.Content.ReadAsAsync<Product>().Result;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "?category=" + category).Result;
                return response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            }

        }

        public HttpResponseMessage Update(Product item)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync(END_POINT + "/" + item.Id, item).Result;
                return response;
            }
        }
    }
}
