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
    public class ArrangementService : IArrangementService<Arrangement>
    {
        protected static readonly string END_POINT = END_POINT + "http://localhost:55391/API/Arrangement";

        public HttpResponseMessage Add(Arrangement item)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(END_POINT + "/", item).Result;
                return response;
            }
        }

        public HttpResponseMessage Delete(Arrangement item)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync(END_POINT + "/" + item.Id).Result;
                return response.EnsureSuccessStatusCode();
            }
        }

        public Arrangement Get(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + id).Result;
                return response.Content.ReadAsAsync<Arrangement>().Result;
            }
        }

        public IEnumerable<Arrangement> GetAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Arrangement>>().Result;
            }
        }

        public HttpResponseMessage Update(Arrangement item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Events> GetEvents()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + "/events").Result;
                return response.Content.ReadAsAsync<IEnumerable<Events>>().Result;
            }
        }
    }
}
