using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTOModel
{
    public class Arrangement
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public virtual ICollection<ArrangementProduct> Products { get; set; }
    }
}
