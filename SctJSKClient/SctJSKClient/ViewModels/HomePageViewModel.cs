using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.ViewModels
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            Products = new List<Product>();
            Categories = new List<Category>();
        }

        public Category Category { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}