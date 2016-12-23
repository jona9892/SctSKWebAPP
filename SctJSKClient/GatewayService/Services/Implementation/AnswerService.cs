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
    public class AnswerService : IAnswerService<Answer>
    {
        protected static readonly string END_POINT = END_POINT + "http://localhost:55391/API/Answer";

        public Answer Add(Answer answer)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(END_POINT + "/", answer).Result;
                return response.Content.ReadAsAsync<Answer>().Result;
            }
        }

        public IEnumerable<Poll> GetAllUnAnsweredPolls(int userid)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + userid + "/polls").Result;
                return response.Content.ReadAsAsync<IEnumerable<Poll>>().Result;
            }
        }

        public IEnumerable<PollResult> ReadResults(int pollid)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + pollid + "/results").Result;
                return response.Content.ReadAsAsync<IEnumerable<PollResult>>().Result;
            }
        }
    }
}
