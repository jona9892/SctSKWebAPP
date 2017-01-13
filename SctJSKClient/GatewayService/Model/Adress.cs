using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    public class Adress
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string AdressLine { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Skal være over 0")]
        public int ZipCode { get; set; }

        public virtual User User { get; set; }
    }
}
