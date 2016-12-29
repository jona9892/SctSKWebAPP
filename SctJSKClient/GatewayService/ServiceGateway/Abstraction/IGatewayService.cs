using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GatewayService.Services.Abstraction
{
    public interface IGatewayService<T>
    {
        HttpResponseMessage Add(T item);
        IEnumerable<T> GetAll();
        T Get(int id);
        HttpResponseMessage Update(T item);
        HttpResponseMessage Delete(T item);
    }
}
