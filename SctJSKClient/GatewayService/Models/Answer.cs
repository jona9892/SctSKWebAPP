using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    public class Answer
    {
        
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("PollOption")]
        public int PollOptionId { get; set; }
        public virtual PollOption PollOption { get; set; }

        public int PollId { get; set; }
    }
}
