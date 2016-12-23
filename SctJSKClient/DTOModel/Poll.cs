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

        [Display(Name = "Spørgsmål")]
        public string Question { get; set; }
        [Display(Name = "Aktiv")]
        public bool Active { get; set; }
        public virtual ICollection<PollOption> PollOptions { get; set; }
    }
}
