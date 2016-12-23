using SctJSKClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.ViewModels
{
    public class OrderDateViewModel
    {
        public List<OrderDate> dates { get; set; }
        public string timeofday { get; set; }
        public List<string> breaks { get; set; }
    }
}