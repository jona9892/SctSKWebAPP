using NUnit.Framework;
using Sct.JSKDAL;
using Sct.JSKDAL.DomainModel;
using SctJSKApiTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.RepositoryTest
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private Facade facade;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
        }

        [Test]
        public void User_is_in_db_after_add_test()
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
                Username = "Jona123",
                Password = "123456",
                Adress = new Adress
                {
                    Id = 1, AdressLine = "Adress1", City = "by1", ZipCode = 6800
                },
                Email = "EmailTest",
                Roles = role,
                Phone = 41289203
            };

            facade.GetUserRepository().Add(user);

            Assert.IsTrue(user.Id > 0);

            var user2 = facade.GetUserRepository().Read(user.Id);
            Assert.AreEqual(user, user2);
        }

        [Test]
        public void User_get_by_Email_and_Id_test()
        {
            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            var user = new User
            {
                Id = -1,
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

            var user2 = facade.GetUserRepository().Read(user.Id);
            var user3 = facade.GetUserRepository().Get(user.Username);
            Assert.AreEqual(user, user2);
           // Assert.AreEqual(user, user3);

        }

        [Test]
        public void User_login_test()
        {
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
                Email = "EmailTest",
                Phone = 41289203
            };

            facade.GetUserRepository().Add(user);

            var user2 = facade.GetUserRepository().Login(user.Username, user.Password); 
            Assert.AreEqual(user, user2);

        }

        [Test]
        public void User_is_updated_after_update()
        {
            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            var user = new User
            {
                Id = -1,
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
            Assert.IsNotNull(user);
            Assert.AreEqual(user.FirstName, "Jonathan");

            var newname = "shaun";
            user.FirstName = newname;

            facade.GetUserRepository().Update(user);
            Assert.AreEqual(newname, user.FirstName);
        }

        [Test]
        public void User_is_removed_from_db()
        {
            var users = facade.GetUserRepository().ReadAll();
            foreach(var user in users)
            {
                facade.GetUserRepository().Delete(user);
            }

            var users2 = facade.GetUserRepository().ReadAll();
            Assert.IsEmpty(users2);
        }

        [Test]
        public void User_get_orders_test()
        {
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
            var order1 = new Order
            {
                Id = 1,
                User = user,
                OrderDate = bd,
                OrderCreated = DateTime.Now
            };

            var order2 = new Order
            {
                Id = 2,
                User = user,
                OrderDate = bd,
                OrderCreated = DateTime.Now
            };

            facade.GetOrderRepository().Add(order1);
            facade.GetOrderRepository().Add(order2);

            List<Order> orders = facade.GetUserRepository().GetOrdersByUser(user.Id);
            Assert.AreEqual(orders.FirstOrDefault(), order1);
        }

        [Test]
        public void User_get_current_orders_test()
        {
            DateTime current = new DateTime(2017, 10, 9, 0, 0, 0);
            DateTime now = DateTime.Now;
            var user = new User
            {
                Id = -1,
                FirstName = "Jonathan",
                LastName = "Gjøl",
                Username = "Jona123",
                Password = "123456",
                Birthday = current,
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
            var order1 = new Order
            {
                Id = 1,
                User = user,
                OrderDate = current,
                OrderCreated = DateTime.Now
            };

            var order2 = new Order
            {
                Id = 2,
                User = user, 
                OrderDate = current,
                OrderCreated = DateTime.Now
            };

            facade.GetOrderRepository().Add(order1);
            facade.GetOrderRepository().Add(order2);

            var orders = facade.GetUserRepository().GetCurrentOrders(user.Id);
            foreach(var order in orders)
            {
                Assert.IsTrue(order.OrderDate >= now);
            }
        }

        [Test]
        public void User_get_previous_orders_test()
        {
            DateTime previous = new DateTime(2015, 10, 9, 0, 0, 0);
            DateTime now = DateTime.Now;
            var user = new User
            {
                Id = -1,
                FirstName = "Jonathan",
                LastName = "Gjøl",
                Username = "Jona123",
                Password = "123456",
                Birthday = now,
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
            var order1 = new Order
            {
                Id = 1,
                User = user,
                OrderDate = previous,
                OrderCreated = now
            };

            var order2 = new Order
            {
                Id = 2,
                User = user,
                OrderDate = previous,
                OrderCreated = now
            };

            facade.GetOrderRepository().Add(order1);
            facade.GetOrderRepository().Add(order2);

            var orders = facade.GetUserRepository().GetCurrentOrders(1);
            foreach (var order in orders)
            {
                Assert.IsTrue(order.OrderDate <= now);
            }
        }

    }
}
