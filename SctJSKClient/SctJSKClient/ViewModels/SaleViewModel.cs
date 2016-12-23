using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.ViewModels
{
    public class SaleViewModel
    {
        public SaleViewModel()
        {
            CountOfProducts = new List<ProductCount>();
        }
        public int Total { get; set; } 
        public int TotalProduct { get; set; }
        public List<ProductCount> CountOfProducts { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string MonthDate { get; set; }
        public string FullDate { get; set; }

    }
}