using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.ViewModels
{
    public class ArrangementProductViewModel
    {
        public ArrangementProductViewModel()
        {
            Arrangements = new List<Arrangement>();
            ArrangementProducts = new List<ArrangementProduct>();
        }

        public Arrangement Arrangement { get; set; }
        public List<Arrangement> Arrangements { get; set; }
        public List<ArrangementProduct> ArrangementProducts { get; set; }
    }
}