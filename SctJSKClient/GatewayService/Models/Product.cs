using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name = "Titel")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Billede")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Pris")]
        [Range(0, int.MaxValue, ErrorMessage = "Skal være over 0")]
        public int Price { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Kategori")]
        public virtual Category Category { get; set; }

        [Required]
        [Display(Name = "Tilgængelig for elever")]
        public bool availableforStudents { get; set; }

        [Required]
        [Display(Name = "Kun for skoleledere")]
        public bool onlyForHeadmasters { get; set; }

       
        public virtual ICollection<Arrangement> Arrangements { get; set; }


    }
}
