using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Entities
{
    public class PollOption
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Poll")]
        public int PollId { get; set; }
        public virtual Poll Poll { get; set; }

        [Required]
        [StringLength(15)]
        public string OptionText { get; set; }
    }
}
