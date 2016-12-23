using Sct.JSKDAL.Context;
using Sct.JSKDAL.DomainModel;
using Sct.JSKDAL.Repository.Absttraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Implementation
{
    public class OrderDetailRepository : IOrderDetailRepository
    {

        private DBContext ctx;

        public OrderDetailRepository(DBContext context)
        {
            ctx = context;
        }

        public void create(OrderDetail orderDetail)
        {
            OrderDetail newOrderDetail = ctx.OrderDetails.Add(orderDetail);
            ctx.SaveChanges();
        }
    }
}
