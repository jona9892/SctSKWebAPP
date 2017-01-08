using NUnit.Framework;
using Sct.JSKDAL;
using Sct.JSKDAL.Entities;
using SctJSKApiTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.RepositoryTest
{   
    [TestFixture]
    public class OrderRepositoryTest
    {
        private Facade facade;        

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
        }

        [Test]
        public void Order_is_in_db_after_add_test()
        {
            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            var user = new User
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

            facade.GetUserRepository().Add(user);

            var order = new Order
            {
                Id = -1,
                User = user,
                OrderCreated = bd,
                OrderDate = bd, 
                TimeOfDay = "09:50",
                TotalPrice = 100                
            };

            facade.GetOrderRepository().Add(order);

            Assert.IsTrue(order.Id > 0);

            var order2 = facade.GetOrderRepository().Read(order.Id);
            Assert.AreEqual(order, order2);
            facade.GetOrderRepository().Delete(user.Id, order);
            var orders2 = facade.GetOrderRepository().ReadAll();
            Assert.IsEmpty(orders2);

        }

        [Test]
        public void Get_all_orders_from_db()
        {

            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            var user = new User
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

            facade.GetUserRepository().Add(user);

            var order = new Order
            {
                Id = -1,
                User = user,
                OrderCreated = bd,
                OrderDate = bd,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };

            facade.GetOrderRepository().Add(order);

            var orders = facade.GetOrderRepository().ReadAll();
            Assert.IsTrue(orders.Count() >= 1);

            facade.GetOrderRepository().Delete(user.Id, order);
            var orders2 = facade.GetOrderRepository().ReadAll();
            Assert.IsEmpty(orders2);

        }

        [Test]
        public void Get_all_ordered_customers_from_db()
        {

            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            var user = new User
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

            facade.GetUserRepository().Add(user);

            var order = new Order
            {
                Id = -1,
                User = user,
                OrderCreated = bd,
                OrderDate = bd,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };

            facade.GetOrderRepository().Add(order);
            String bd2 = bd.ToString();

            var orders = facade.GetOrderRepository().GetAllOrderedCustomers(bd2.Split(' ')[0]);
            Assert.IsTrue(orders.Count() >= 1);
            Assert.AreEqual(orders.Select(o => o.FirstName).FirstOrDefault(), user.FirstName);

            facade.GetOrderRepository().Delete(user.Id, order);
            var orders2 = facade.GetOrderRepository().ReadAll();
            Assert.IsEmpty(orders2);

        }


        [Test]
        public void Get_all_products_orderered_from_db()
        {

            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            var user = new User
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

            facade.GetUserRepository().Add(user);

            var order = new Order
            {
                Id = -1,
                User = user,
                OrderCreated = bd,
                OrderDate = bd,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };

            facade.GetOrderRepository().Add(order);
            String bd2 = bd.ToString();

            var orders = facade.GetOrderRepository().GetOrderedProductsByOrder(bd2.Split(' ')[0]);
            Assert.IsTrue(orders.Count() >= 1);
            Assert.AreEqual(orders.Select(o => o.OrderDate).FirstOrDefault(), bd);

            facade.GetOrderRepository().Delete(user.Id, order);
            var orders2 = facade.GetOrderRepository().ReadAll();
            Assert.IsEmpty(orders2);

        }

        [Test]
        public void Get_order_by_user_and_date_test()
        {
            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            var user = new User
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

            facade.GetUserRepository().Add(user);

            var order = new Order
            {
                Id = -1,
                User = user,
                OrderCreated = bd,
                OrderDate = bd,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };

            facade.GetOrderRepository().Add(order);

            Assert.IsTrue(order.Id > 0);
            String bd2 = bd.ToString();
            var order2 = facade.GetOrderRepository().GetAllOrderedCustomerDetail(bd2.Split(' ')[0], user.Id);
            Assert.AreEqual(order, order2);


            facade.GetOrderRepository().Delete(user.Id, order);
            var orders2 = facade.GetOrderRepository().ReadAll();
            Assert.IsEmpty(orders2);

        }        
        

    }
}
