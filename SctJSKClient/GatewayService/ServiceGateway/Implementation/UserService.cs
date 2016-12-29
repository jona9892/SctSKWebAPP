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
    public class UserService : IUserGateway<User>
    {
        //Constant, the address of the web api
        protected static readonly string END_POINT = END_POINT + "http://localhost:55391/API/User";


        /// <summary>
        /// sends a user that will then be added to the database.
        /// </summary>
        /// <param name="item">the user to be added</param>
        /// <returns>the user with the correct primary key.</returns>
        public User Add(User item)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(END_POINT + "/", item).Result;
                return response.Content.ReadAsAsync<User>().Result;
            }
        }

        public User Get(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + id).Result;
                return response.Content.ReadAsAsync<User>().Result;
            }
        }

        public User Get(string username)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = 
                    httpClient.GetAsync(END_POINT + "?username=" + username).Result;

                return response.Content.ReadAsAsync<User>().Result;

            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/").Result;
                return response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
        }

        public User Update(User item)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync(END_POINT + "/" + item.Id, item).Result;
                return response.Content.ReadAsAsync<User>().Result;
            }
        }

        public User Delete(User item)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync(END_POINT + "/" + item.Id).Result;
                return response.Content.ReadAsAsync<User>().Result;
            }
        }

        public User Login(string username, string password)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response =
                    httpClient.GetAsync(END_POINT + "?username=" + username + "&password=" + password).Result;
                return response.Content.ReadAsAsync<User>().Result;

            }
        }

        public IEnumerable<Order> GetOrdersByUser(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + id + "/orders").Result;
                return response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
            }
        }

        public IEnumerable<Order> GetCurrentOrders(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + id + "/currentorders").Result;
                return response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
            }
        }

        public IEnumerable<Order> GetPreviousOrders(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + id + "/previousorders").Result;
                return response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
            }
        }

        public IEnumerable<Events> GetEvents(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(END_POINT + "/" + id + "/events").Result;
                return response.Content.ReadAsAsync<IEnumerable<Events>>().Result;
            }
        }
    }
}
