using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.Models
{
    public class CheckoutItem
    {
        public CheckoutItem() {
            orderDetails = new List<OrderDetail>();
        }
        public Order order { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}