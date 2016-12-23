using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.Models
{
    public class UserOrderModel
    {
        public UserOrderModel()
        {
            Orders = new List<Order>();
            OrderDetails = new List<OrderDetail>();
        }
        
        public IEnumerable<Order> Orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public Order order { get; set; }
    }
}