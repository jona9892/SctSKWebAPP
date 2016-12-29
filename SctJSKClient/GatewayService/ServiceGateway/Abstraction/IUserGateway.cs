using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayService.Services.Abstraction
{
    public interface IUserGateway<T>
    {
        T Get(string username);
        T Add(T item);
        IEnumerable<T> GetAll();
        T Get(int id);
        T Update(T item);
        T Delete(T item);
        T Login(string username, string password);
        IEnumerable<Order> GetOrdersByUser(int id);
        IEnumerable<Order> GetCurrentOrders(int id);
        IEnumerable<Order> GetPreviousOrders(int id);
        IEnumerable<Events> GetEvents(int id);
    }
}
