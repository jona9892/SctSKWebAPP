using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.DomainModel
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //public virtual ICollection<UserRole> Roles { get; set; }
        public virtual Role Roles { get; set; }

        public virtual ICollection<Order> Order { get; set; }

        public virtual Adress Adress { get; set; }

    }
}
