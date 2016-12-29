using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.DomainModel
{
    public class Product { 
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(12)]
        public string Title { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        public bool availableforStudents { get; set; }
        [Required]
        public bool onlyForHeadmasters { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Arrangement> Arrangements { get; set; }
    }
}
