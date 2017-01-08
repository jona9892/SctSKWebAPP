
using Sct.JSKDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Absttraction
{
    public interface IUser<T>
    {
        User Get(string email);
        List<T> ReadAll();
        T Add(T t);
        T Read(int id);
        void Update(T e);
        void Delete(T e);
        T Login(string username, string password);
        List<Order> GetOrdersByUser(int id);
        IEnumerable<Order> GetCurrentOrders(int id);
        IEnumerable<Order> GetPreviousOrders(int id);
        void DeleteOrderByUser(Order order, int id);


    }
}
