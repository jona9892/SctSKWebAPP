using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Entities
{
    public class Poll
    {
        [Key]
        public int Id { get; set; }

        public string Question { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<PollOption> PollOptions { get; set; }
    }
}
