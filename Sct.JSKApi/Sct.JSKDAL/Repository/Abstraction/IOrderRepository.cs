
using Sct.JSKDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Absttraction
{
    public interface IOrderRepository<T>
    {
        IEnumerable<T> ReadAll();
        T Add(T t);
        T Read(int id);
        Order Delete(int userid, Order order);
        IEnumerable<User> GetAllOrderedCustomers(string orderdate);
        Order GetAllOrderedCustomerDetail(string orderdate, int id);
        IEnumerable<T> GetOrderedProductsByOrder(string orderdate);
        IEnumerable<T> GetOrderedProductsByDates(string startDate, string endDate);
    }
}
