using Sct.JSKApi.BLL;
using Sct.JSKApi.Models;
using Sct.JSKDAL;
using Sct.JSKDAL.Context;
using Sct.JSKDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sct.JSKApi.Controllers
{
    public class UserController : ApiController
    {
        private Facade facade;
        private BLLUser bu;
        public UserController()
        {
            facade = new Facade(new DBContextSctJSK());
            bu = new BLLUser(new DBContextSctJSK());
        }

        // GET: api/User
        /// <summary>
        /// this returns an IEnumerable, which contains all Users.
        /// </summary>
        /// <returns>an IEnumerable with users</returns>
        public IEnumerable<User> GetUsers()
        {
            return facade.GetUserRepository().ReadAll();
        }

        public User GetUser(int id)
        {
            return facade.GetUserRepository().Read(id);
        }

        public User GetUser(string username)
        {
            return facade.GetUserRepository().Get(username);
        }

        public User GetUser(string username, string password)
        {
            return facade.GetUserRepository().Login(username, password);
        }

        public User PostUser(User e)
        {
            return facade.GetUserRepository().Add(e);
        }

        public User PutUser(int id, User e)
        {
            if (e == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            e.Id = id;


            facade.GetUserRepository().Update(e);
            return e;
        }

        public void DeleteUser(int id)
        {
            var e = facade.GetUserRepository().Read(id);
            facade.GetUserRepository().Delete(e);
        }

        [Route("api/user/{id}/orders")]
        [HttpGet]
        public IEnumerable<Order> GetOrdersByUser(int id)
        {
            return facade.GetUserRepository().GetOrdersByUser(id);
        }

        [Route("api/user/{id}/currentorders")]
        [HttpGet]
        public IEnumerable<Order> GetCurrentOrders(int id)
        {
            return facade.GetUserRepository().GetCurrentOrders(id); 
        }

        [Route("api/user/{id}/previousorders")]
        [HttpGet]
        public IEnumerable<Order> GetPreviousOrders(int id)
        {
            return facade.GetUserRepository().GetPreviousOrders(id); 
        }

        [Route("api/user/{id}/events")]
        [HttpGet]
        public IEnumerable<Events> GetEvents(int id)
        {
            return bu.convertToOrdersToEvents(id);
        }
    }
}
