using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    public class ArrangementProduct
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Arrangement")]
        public int ArrangementId { get; set; }
        public virtual Arrangement Arrangement { get; set; }

        public int Quantity { get; set; }
    }
}
