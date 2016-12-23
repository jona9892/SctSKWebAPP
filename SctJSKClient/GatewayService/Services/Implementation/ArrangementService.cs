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
        public Arrangement Add(Arrangement item)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(END_POINT + "/", item).Result;
                return response.Content.ReadAsAsync<Arrangement>().Result;
            }
        }

        public Arrangement Delete(Arrangement item)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync(END_POINT + "/" + item.Id).Result;
                return response.Content.ReadAsAsync<Arrangement>().Result;
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

        public Arrangement Update(Arrangement item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Events> GetEvents(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + id + "/events").Result;
                return response.Content.ReadAsAsync<IEnumerable<Events>>().Result;
            }
        }
    }
}
