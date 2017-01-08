using Sct.JSKDAL.Context;
using Sct.JSKDAL.Entities;
using Sct.JSKDAL.Repository.Absttraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Implementation
{
    public class UserRepository : IUser<User>
    {
        private DBContext ctx;

        public UserRepository(DBContext context)
        {
            ctx = context;
        }

        /// <summary>
        /// Add a User and returns it
        /// </summary>
        public User Add(User user)
        {
            //Adress newAdress = ctx.Adresses.Add(user.Adress);
            User newUser = ctx.Users.Add(user);
            ctx.SaveChanges();
            return newUser;

        }

        /// <summary>
        /// List all users
        /// </summary>
        /// <returns>a list containing all users</returns>
        public void Delete(User e)
        {
            var user = ctx.Users.Include("Adress").Include("Order").FirstOrDefault(x => x.Id == e.Id);
            ctx.Users.Remove(user);
            ctx.SaveChanges();

        }


        public User Get(string username)
        {
            var user = ctx.Users.Include("Adress").Include("Roles")
            .Where(c => c.Username.Equals(username)).FirstOrDefault();
            return user;

        }

        public User Login(string username, string password)
        {
            var user = ctx.Users.Include("Adress").Include("Roles").Where(c => c.Username.Equals(username)
            && c.Password.Equals(password)).FirstOrDefault();
            return user;

        }

        /// <summary>
        /// returns a users with a specified Id
        /// </summary>
        /// <param name="id">the Id of the user</param>
        /// <returns></returns>
        public User Read(int id)
        {
            var user = ctx.Users.Include("Adress").Include("Roles").Where(c => c.Id == id).FirstOrDefault();
            return user;

        }

        public List<User> ReadAll()
        {
            return ctx.Users.Include("Adress").Include("Roles").ToList();

        }

        public void Update(User e)
        {
            var user = ctx.Users.Where(c => c.Id == e.Id).FirstOrDefault();
            user.FirstName = e.FirstName;
            user.LastName = e.LastName;
            user.Birthday = e.Birthday;
            user.Email = e.Email;
            user.Phone = e.Phone;
            /*
            user.Adress = ctx.Adresses.FirstOrDefault(x => x.Id == e.Adress.Id);
            user.Adress.AdressLine = e.Adress.AdressLine;
            user.Adress.City = e.Adress.City;
            user.Adress.ZipCode = e.Adress.ZipCode;*/

            ctx.SaveChanges();

        }

        public List<Order> GetOrdersByUser(int id)
        {
            return ctx.Orders.OrderByDescending(o => o.OrderCreated)
                .Include("OrderDetails").Include(od => od.OrderDetails.Select(p => p.Product))
                .Where(c => c.User.Id == id).ToList();
        }

        public IEnumerable<Order> GetCurrentOrders(int id)
        {
            DateTime currentDate = DateTime.Today;
            
            return ctx.Orders.Include("OrderDetails").Include(p => p.OrderDetails.Select(od => od.Product))
                .Where(or => or.OrderDate >= currentDate && or.User.Id == id).ToList();

        }


        public IEnumerable<Order> GetPreviousOrders(int id)
        {
            DateTime currentDate = DateTime.Today;
            
            return ctx.Orders.Include("OrderDetails").Include(p => p.OrderDetails.Select(od => od.Product))
                .Where(or => or.OrderDate <= currentDate && or.User.Id == id).ToList();


        }

        public void DeleteOrderByUser(Order o, int id)
        {
            var order = ctx.Orders.FirstOrDefault(x => x.Id == o.Id && x.User.Id == id);
            ctx.Orders.Remove(order);
            ctx.SaveChanges();
        }
    }
}