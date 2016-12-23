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
        [Display(Name = "Titel")]
        public string Title { get; set; }
        [Display(Name = "Billede")]
        public string Image { get; set; }
        [Display(Name = "Pris")]
        public int Price { get; set; }
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
        [Display(Name = "Kategori")]
        public virtual Category Category { get; set; }
        [Display(Name = "Tilgængelig for elever")]
        public bool availableforStudents { get; set; }
        [Display(Name = "Kun for skoleledere")]
        public bool onlyForHeadmasters { get; set; }

       
        public virtual ICollection<Arrangement> Arrangements { get; set; }


    }
}
