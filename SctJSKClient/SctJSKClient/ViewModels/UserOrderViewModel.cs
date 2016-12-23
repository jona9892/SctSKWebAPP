using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.ViewModels
{
    public class UserOrderViewModel
    {
        public UserOrderViewModel()
        {
            Orders = new List<Order>();
            OrderDetails = new List<OrderDetail>();
        }

        public Product Product { get; set; }
        public User Userd { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        
        
    }
}