using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Entities
{
    public class Adress
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string AdressLine { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        public int ZipCode { get; set; }

        public virtual User User { get; set; }
    }
}
