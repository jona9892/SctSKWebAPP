using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public virtual ICollection<UserRole> Users { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
