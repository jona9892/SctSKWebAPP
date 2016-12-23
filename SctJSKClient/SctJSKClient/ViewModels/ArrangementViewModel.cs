using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.ViewModels
{
    public class ArrangementViewModel
    {
        public ArrangementViewModel()
        {
            ArrangementProducts = new List<ArrangementProduct>();
            Products = new List<Product>();
            Categrories = new List<Category>();
        }

        public Arrangement Arrangement { get; set; }
        public IEnumerable<ArrangementProduct> ArrangementProducts { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categrories { get; set; }
        public string[] selected { get; set; }
    }
}