using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.ViewModels
{
    public class ProductViewModel 
    {
        public ProductViewModel()
        {
            Categories = new List<Category>();
        }
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}