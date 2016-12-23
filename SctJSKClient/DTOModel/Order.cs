using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    public class Order
    {
        public int Id { get; set; }

        public virtual User User { get; set; }


        public DateTime OrderCreated { get; set; }


        [Display(Name ="Bestillings dato")]
        public DateTime OrderDate { get; set; }

        public int TotalPrice { get; set; }

        public string TimeOfDay { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
