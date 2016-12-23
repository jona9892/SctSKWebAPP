using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GatewayService.Services.Abstraction
{
    public interface IProductService<Product>
    {
        HttpResponseMessage Add(Product item);
        IEnumerable<Product> GetAll();
        Product Get(int id);
        HttpResponseMessage Update(Product item);
        HttpResponseMessage Delete(Product item);
        IEnumerable<Product> GetProductsByCategory(string category);
    }
}
