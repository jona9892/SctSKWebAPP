using NUnit.Framework;
using Sct.JSKApi.BLL;
using Sct.JSKApi.Models;
using Sct.JSKDAL;
using Sct.JSKDAL.DomainModel;
using SctJSKApiTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.BLL
{
    [TestFixture]
    public class BLLOrderTest
    {

        private Facade facade;
        private BLLOrder bo;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
            bo = new BLLOrder(new DBContextSctJSKTest());
        }

        [Test]
        public void Get_ordered_products_counted_test()
        {
            //User
            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);
            var user = new User
            {
                Id = 1,
                FirstName = "Jonathan",
                LastName = "Gjøl",
                Birthday = bd,
                Username = "Jona123",
                Password = "123456",
                Adress = new Adress
                {
                    Id = 1,
                    AdressLine = "Adress1",
                    City = "by1",
                    ZipCode = 6800
                },
                Email = "EmailTest",
                Phone = 41289203
            };

            facade.GetUserRepository().Add(user);

            //Category
            var category1 = new Category
            {
                Id = -1,
                Name = "BRød",
                Description = "Godt Brøde"
            };
            var category2 = new Category
            {
                Id = -1,
                Name = "mælk",
                Description = "Godt Brøde"
            };
            facade.GetCategoryRepository().Add(category1);
            facade.GetCategoryRepository().Add(category2);
            //Product

            var product1 = new Product
            {
                Id = -1,
                Title = "bolle",
                Price = 20,
                Description = "normal bolle",
                Image = "billede",
                Category = category1
            };
            var product2 = new Product
            {
                Id = 2,
                Title = "mælk",
                Price = 10,
                Description = "normal mælk",
                Category = category2
            };
            facade.GetProductRepository().Add(product1);
            facade.GetProductRepository().Add(product2);

            //orders
            DateTime orderdate = new DateTime(2016, 12, 9, 0, 0, 0);
            var order1 = new Order
            {
                Id = 1,
                OrderDate = orderdate,
                OrderCreated = DateTime.Now,
                TotalPrice = 120,
                User = user
            };
            var order2 = new Order
            {
                Id = 2,
                OrderDate = orderdate,
                OrderCreated = DateTime.Now,
                TotalPrice = 50,
                User = user
            };
            facade.GetOrderRepository().Add(order1);
            facade.GetOrderRepository().Add(order2);

            //orderdetails
            var orderdetail1 = new OrderDetail
            {
                Id = 1, 
                Order = order1,
                OrderId = order1.Id,
                Price = 20,                
                Product = product1,
                ProductId = product1.Id,
                Quantity = 2
            };
            var orderdetail2 = new OrderDetail
            {
                Id = 2,
                Order = order2,
                OrderId = order2.Id,
                Price = 20,
                Product = product2,
                ProductId = product2.Id,
                Quantity = 3
            };
            var orderdetail3 = new OrderDetail
            {
                Id = 3,
                Order = order2,
                OrderId = order2.Id,
                Price = 20,
                Product = product1,
                ProductId = product1.Id,
                Quantity = 2
            };
            var orderdetail4 = new OrderDetail
            {
                Id = 4,
                Order = order2,
                OrderId = order2.Id,
                Price = 20,
                Product = product2,
                ProductId = product2.Id,
                Quantity = 3
            };

            facade.GetOrderDetailRepository().create(orderdetail1);
            facade.GetOrderDetailRepository().create(orderdetail2);
            facade.GetOrderDetailRepository().create(orderdetail3);
            facade.GetOrderDetailRepository().create(orderdetail4);
            //------------------------------------------------------------------------
            List<ProductCount> countedOrders = bo.CountOrderedProductsByDate("2016-12-09").ToList();
            //ProductCounts expected
            var productCount1 = new ProductCount
            {
                product = product1,
                NumberOfProduct = 4

            };
            var productCount2 = new ProductCount
            {
                product = product2,
                NumberOfProduct = 6

            };

            Assert.That(countedOrders.Count == 2);


        }
    }
}
