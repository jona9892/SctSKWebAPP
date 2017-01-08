﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(12)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        //public virtual ICollection<UserRole> Users { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
