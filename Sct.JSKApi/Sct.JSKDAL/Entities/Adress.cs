using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.DomainModel
{
    public class Adress
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }
        public string AdressLine { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }

        public virtual User User { get; set; }
    }
}
