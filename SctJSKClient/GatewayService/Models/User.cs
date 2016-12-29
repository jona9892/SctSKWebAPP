using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Doesn't look like an email")]
        public string Email { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Must be positive")]
        public int Phone { get; set; }

        [Required]
        [MinLength(8)]
        [Display(Name = "Brugernavn")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The password needs to have a length of 6-20.")]
        [Display(Name = "Kodeord")]
        public string Password { get; set; }

        public virtual Role Roles { get; set; }

        public virtual ICollection<Order> Order { get; set; }

        public virtual Adress Adress { get; set; }
    }
}
