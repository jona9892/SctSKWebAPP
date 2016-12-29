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
    public class ArrangementProductService : IArrangementProductService<ArrangementProduct>
    {
        protected static readonly string END_POINT = END_POINT + "http://localhost:55391/API/ArrangementProduct";

        public void create(ArrangementProduct arrangementProduct)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(END_POINT + "/", arrangementProduct).Result;
            }
        }

        public ArrangementProduct Delete(ArrangementProduct item)
        {
            throw new NotImplementedException();
        }

        public ArrangementProduct Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArrangementProduct> GetAll()
        {
            throw new NotImplementedException();
        }

        public ArrangementProduct Update(ArrangementProduct item)
        {
            throw new NotImplementedException();
        }
    }
}
