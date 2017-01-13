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
    public class CategoryService : IGatewayService<Category>
    {
        //Constant, the address of the web api
        protected static readonly string END_POINT = END_POINT + "http://localhost:55391/API/Category";

        public HttpResponseMessage Add(Category item)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(END_POINT + "/", item).Result;
                return response;
            }
        }

        public HttpResponseMessage Delete(Category item)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync(END_POINT + "/" + item.Id).Result;
                return response.EnsureSuccessStatusCode();
            }
        }

        public Category Get(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + id).Result;
                return response.Content.ReadAsAsync<Category>().Result;
            }
        }

        public IEnumerable<Category> GetAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
            }
        }

        public HttpResponseMessage Update(Category item)
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
