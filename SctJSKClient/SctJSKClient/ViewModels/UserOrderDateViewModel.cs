using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.ViewModels
{
    public class UserOrderDateViewModel
    {
        public UserOrderDateViewModel()
        {
            users = new List<User>();
        }

        public List<User> users { get; set; }
        public string orderdate { get; set; }
        public int price { get; set; }
    }
}