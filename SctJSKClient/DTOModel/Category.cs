using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Navn")]
        public string Name { get; set; }
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
