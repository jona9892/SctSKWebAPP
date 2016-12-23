using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.DomainModel
{
    public class UserRole
    {
        [Key]
        [Column(Order = 2)]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
