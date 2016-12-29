using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    public class ProductCount
    {
        public Product product { get; set; }
        public int NumberOfProduct { get; set; }
        public int TotalPrice { get; set; }
    }
}
