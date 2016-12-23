using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    public class Adress
    {
        public int Id { get; set; }
        public string AdressLine { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }

        public virtual User User { get; set; }
    }
}
