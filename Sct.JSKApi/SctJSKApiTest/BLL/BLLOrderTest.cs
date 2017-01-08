using NUnit.Framework;
using Sct.JSKApi.BLL;
using Sct.JSKApi.Models;
using Sct.JSKDAL;
using Sct.JSKDAL.Entities;
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
        private User user;
        private Category category1;
        private Category category2;
        private Product product1;
        private Product product2;
        private Order order1;
        private Order order2;
        private OrderDetail orderdetail1;
        private OrderDetail orderdetail2;
        private OrderDetail orderdetail3;
        private OrderDetail orderdetail4;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
            bo = new BLLOrder(new DBContextSctJSKTest());

            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };
            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);
            user = new User
            {
                Id = -1,
                FirstName = "Jonathan",
                LastName = "Gjøl",
                Birthday = bd,
                Username = "Jona1234",
                Password = "123456",

                Adress = new Adress
                {
                    Id = 1,
                    AdressLine = "Adress1",
                    City = "by1",
                    ZipCode = 6800
                },
                Email = "EmailTest@hotmail.dk",
                Roles = role,
                Phone = 41289203
            };
            //--------------------------------------
            //Category
            category1 = new Category
            {
                Id = -1,
                Name = "Brød",
                Description = "Godt Brød"
            };
            category2 = new Category
            {
                Id = -1,
                Name = "Brød",
                Description = "Godt Brød"
            };
            //---------------------------------------
            product1 = new Product()
            {
                Id = -1,
                Title = "Pizza",
                Price = 100,
                Image = "PizzaImg",
                Description = "Desc Pizza",
                availableforStudents = true,
                onlyForHeadmasters = false,
                Category = category1
            };
            product2 = new Product()
            {
                Id = -1,
                Title = "Pizza",
                Price = 100,
                Image = "PizzaImg",
                Description = "Desc Pizza",
                availableforStudents = true,
                onlyForHeadmasters = false,
                Category = category1
            };
            //----------------------------------------
            //orders
            DateTime orderdate = new DateTime(2016, 12, 9, 0, 0, 0);
            order1 = new Order
            {
                Id = 1,
                OrderDate = orderdate,
                OrderCreated = DateTime.Now,
                TimeOfDay = "09:50",
                TotalPrice = 120,
                User = user
            };
            order2 = new Order
            {
                Id = 2,
                OrderDate = orderdate,
                OrderCreated = DateTime.Now,
                TotalPrice = 50,
                TimeOfDay = "09:50",
                User = user
            };
            //--------------------------------------
            //orderdetails
            orderdetail1 = new OrderDetail
            {
                Id = 1,
                Order = order1,
                OrderId = order1.Id,
                Price = 20,
                Product = product1,
                ProductId = product1.Id,
                Quantity = 2
            };
            orderdetail2 = new OrderDetail
            {
                Id = 2,
                Order = order2,
                OrderId = order2.Id,
                Price = 20,
                Product = product2,
                ProductId = product2.Id,
                Quantity = 3
            };
            orderdetail3 = new OrderDetail
            {
                Id = 3,
                Order = order2,
                OrderId = order2.Id,
                Price = 20,
                Product = product1,
                ProductId = product1.Id,
                Quantity = 2
            };
            orderdetail4 = new OrderDetail
            {
                Id = 4,
                Order = order2,
                OrderId = order2.Id,
                Price = 20,
                Product = product2,
                ProductId = product2.Id,
                Quantity = 3
            };
        }

        [Test]
        public void Get_ordered_products_counted_test()
        {
            //User
            facade.GetUserRepository().Add(user);            
            facade.GetCategoryRepository().Add(category1);        
            facade.GetCategoryRepository().Add(category2);
            facade.GetProductRepository().Add(product1);            
            facade.GetProductRepository().Add(product2);
            
            facade.GetOrderRepository().Add(order1);
            facade.GetOrderRepository().Add(order2);            

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
                product = product1,
                NumberOfProduct = 6

            };

            Assert.That(countedOrders.Count == 2);
            facade.GetOrderRepository().Delete(user.Id, order1);
            facade.GetOrderRepository().Delete(user.Id, order2);
        }

        [Test]
        public void User_order_is_removed_from_db()
        {
            DateTime previous = new DateTime(2015, 10, 9, 0, 0, 0);
            DateTime orderdate = DateTime.Now.AddHours(20);
            DateTime now = DateTime.Now;

            facade.GetUserRepository().Add(user);
            var order1 = new Order
            {
                Id = 1,
                User = user,
                OrderDate = previous,
                OrderCreated = now,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };

            var order2 = new Order
            {
                Id = 2,
                User = user,
                OrderDate = orderdate,
                OrderCreated = now,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };

            facade.GetOrderRepository().Add(order1);
            facade.GetOrderRepository().Add(order2);

            bo.ConfirmDeleteOrder(order1.Id, user.Id);
            bo.ConfirmDeleteOrder(order2.Id, user.Id);
            var getOrder1 = facade.GetOrderRepository().Read(order1.Id);
            Assert.IsNull(getOrder1);
            var getOrder2 = facade.GetOrderRepository().Read(order2.Id);
            Assert.IsNotNull(getOrder2);
            facade.GetOrderRepository().Delete(user.Id, getOrder2);
        }

        [Test]
        public void Get_ordered_products_counted_by_dates_test()
        {
            //User
            facade.GetUserRepository().Add(user);

            //Category - products
            facade.GetCategoryRepository().Add(category1);
            facade.GetCategoryRepository().Add(category2);
            facade.GetProductRepository().Add(product1);                      
            facade.GetProductRepository().Add(product2);

            //orders
            facade.GetOrderRepository().Add(order1);
            facade.GetOrderRepository().Add(order2);

            //orderdetails        
            facade.GetOrderDetailRepository().create(orderdetail1);
            facade.GetOrderDetailRepository().create(orderdetail2);
            facade.GetOrderDetailRepository().create(orderdetail3);
            facade.GetOrderDetailRepository().create(orderdetail4);
            //------------------------------------------------------------------------
            List<ProductCount> countedOrders = bo.CountOrderedProductsByDates("2016-12-05", "2016-12-15").ToList();
            //ProductCounts expected
            var productCount1 = new ProductCount
            {
                product = product1,
                NumberOfProduct = 4
            };
            var productCount2 = new ProductCount
            {
                product = product1,
                NumberOfProduct = 6
            };

            Assert.IsTrue(countedOrders.Count == 2);


            facade.GetOrderRepository().Delete(user.Id, order1);
            facade.GetOrderRepository().Delete(user.Id, order2);
        }
    }
}
