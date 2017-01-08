
using Sct.JSKDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sct.JSKApi.Models
{
    public class ProductCount
    {
        public Product product { get; set; }
        public int NumberOfProduct { get; set; }
        public int TotalPrice { get; set; }
    }
}