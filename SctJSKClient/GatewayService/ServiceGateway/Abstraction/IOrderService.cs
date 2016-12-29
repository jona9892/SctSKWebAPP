using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GatewayService.Services.Abstraction
{
    public interface IOrderService<T>
    {
        T Add(T item);
        IEnumerable<T> GetAll();
        T Get(int id);
        HttpResponseMessage Delete(int userid, int orderid);
        IEnumerable<User> GetAllOrderedCustomers(string orderdate);
        Order GetOrderedCustomerDetails(string orderdate, int id);
        IEnumerable<ProductCount> GetOrderedProducts(string orderdate);
        IEnumerable<ProductCount> GetOrderedProductsByDates(string startDate, string endDate);
    }
}
