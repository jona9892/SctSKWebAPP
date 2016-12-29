using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    public class Poll
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Spørgsmål")]
        public string Question { get; set; }

        [Required]
        [Display(Name = "Aktiv")]
        public bool Active { get; set; }
        public virtual ICollection<PollOption> PollOptions { get; set; }
    }
}
