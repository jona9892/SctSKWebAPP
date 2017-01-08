
using NUnit.Framework;
using Sct.JSKDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.EntitiesTest
{
    [TestFixture]
    public class Order_OrderDetailsTest
    {
        [Test]
        public void Order_Orderdetails_are_set_test()
        {
            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            var order = new Order
            {
                Id = 1,
                OrderDate = bd,
                TotalPrice = 120,
                OrderCreated = bd,
            };

            var product = new Product
            {
                Id = 1
            };

            var orderdetail1 = new OrderDetail
            {
                Id = 1,
                Order = order,
                Quantity = 20,
                Product = product
            };

            Assert.AreEqual(order.Id, 1);
            Assert.AreEqual(order.OrderCreated, bd);

            Assert.AreEqual(orderdetail1.Id, 1);
            Assert.AreEqual(orderdetail1.Quantity, 20);
            Assert.AreEqual(orderdetail1.Product, product);
        }
    }
}
