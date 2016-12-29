using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.DomainModel
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(12)]
        public string Name { get; set; }
        [Required]
        [StringLength(90)]
        public string Description { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
