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
    public class PollService : IPollService<Poll>
    {
        protected static readonly string END_POINT = END_POINT + "http://localhost:55391/API/Poll";

        public Poll Add(Poll poll)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(END_POINT + "/", poll).Result;
                return response.Content.ReadAsAsync<Poll>().Result;
            }
        }

        public Poll Delete(Poll p)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync(END_POINT + "/" + p.Id).Result;
                return response.Content.ReadAsAsync<Poll>().Result;
            }
        }

        public Poll Read(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + id).Result;
                return response.Content.ReadAsAsync<Poll>().Result;
            }
        }

        public IEnumerable<Poll> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Poll>>().Result;
            }
        }

        public Poll Update(Poll p)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync(END_POINT + "/" + p.Id, p).Result;
                return response.Content.ReadAsAsync<Poll>().Result;
            }
        }
    }
}
