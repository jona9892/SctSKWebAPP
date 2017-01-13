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


        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OrderCreated { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Skal være over 0")]
        public int TotalPrice { get; set; }

        [Required]
        public string TimeOfDay { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
