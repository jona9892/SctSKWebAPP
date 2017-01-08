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
                Username = "Jona1234",
                Password = "123456",

                Adress = new Adress
                {
                    Id = 1, AdressLine = "Adress1", City = "by1", ZipCode = 6800
                },
                Email = "EmailTest@hotmail.dk",
                Roles = role,
                Phone = 41289203
            };

            facade.GetUserRepository().Add(user);

            Assert.IsTrue(user.Id > 0);

            var user2 = facade.GetUserRepository().Read(user.Id);
            Assert.AreEqual(user, user2);
        }

        [Test]
        public void User_get_by_username_and_Id_test()
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

            var user2 = facade.GetUserRepository().Read(user.Id);
            var user3 = facade.GetUserRepository().Get(user.Username);
            Assert.AreEqual(user, user2);
           // Assert.AreEqual(user, user3);

        }

        [Test]
        public void User_login_test()
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

            var user2 = facade.GetUserRepository().Login(user.Username, user.Password); 
            Assert.AreEqual(user.FirstName, user2.FirstName);
            Assert.AreEqual(user.LastName, user2.LastName);
            Assert.AreEqual(user.Adress.AdressLine, user2.Adress.AdressLine);
            Assert.AreEqual(user.Roles.Title, user2.Roles.Title);


        }

        [Test]
        public void User_is_updated_after_update()
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
            Assert.IsNotNull(user);
            Assert.AreEqual(user.FirstName, "Jonathan");

            var newname = "shaun";
            user.FirstName = newname;

            facade.GetUserRepository().Update(user);
            Assert.AreEqual(newname, user.FirstName);

            facade.GetUserRepository().Delete(user);
        }
                
        [Test]
        public void User_get_orders_test()
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
            var order1 = new Order
            {
                Id = 1,
                User = user,
                OrderDate = bd,
                OrderCreated = DateTime.Now,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };

            var order2 = new Order
            {
                Id = 2,
                User = user,
                OrderDate = bd,
                OrderCreated = DateTime.Now,
                TimeOfDay = "09:50",
                TotalPrice = 100
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
            var order1 = new Order
            {
                Id = 1,
                User = user,
                OrderDate = current,
                OrderCreated = DateTime.Now,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };

            var order2 = new Order
            {
                Id = 2,
                User = user, 
                OrderDate = current,
                OrderCreated = DateTime.Now,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };

            facade.GetOrderRepository().Add(order1);
            facade.GetOrderRepository().Add(order2);

            var orders = facade.GetUserRepository().GetCurrentOrders(user.Id);
            foreach(var order in orders)
            {
                Assert.IsTrue(order.OrderDate >= now);
            }

            foreach (var order in orders)
            {
                facade.GetOrderRepository().Delete(user.Id, order);
            }

            var users = facade.GetUserRepository().ReadAll();
            foreach (var u in users)
            {
                facade.GetUserRepository().Delete(u);
            }


        }

        [Test]
        public void User_get_previous_orders_test()
        {
            DateTime previous = new DateTime(2015, 10, 9, 0, 0, 0);
            DateTime now = DateTime.Now;
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
                OrderDate = previous,
                OrderCreated = now,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };

            facade.GetOrderRepository().Add(order1);
            facade.GetOrderRepository().Add(order2);

            var orders = facade.GetUserRepository().GetPreviousOrders(user.Id);
            foreach (var order in orders)
            {
                Assert.IsTrue(order.OrderDate <= now);
            }
            
            foreach (var order in orders)
            {
                facade.GetOrderRepository().Delete(user.Id, order);
            }

            var users = facade.GetUserRepository().ReadAll();
            foreach (var u in users)
            {
                facade.GetUserRepository().Delete(u);
            }
        }


        [Test]
        public void User_is_removed_from_db()
        {
            var users = facade.GetUserRepository().ReadAll();
            foreach (var user in users)
            {
                facade.GetUserRepository().Delete(user);
            }

            var users2 = facade.GetUserRepository().ReadAll();
            Assert.IsEmpty(users2);
        }


        [Test]
        public void User_order_is_removed_from_db()
        {
            DateTime previous = new DateTime(2015, 10, 9, 0, 0, 0);
            DateTime now = DateTime.Now;
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
                OrderDate = previous,
                OrderCreated = now,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };

            facade.GetOrderRepository().Add(order1);
            facade.GetOrderRepository().Add(order2);

            facade.GetUserRepository().DeleteOrderByUser(order1, user.Id);
            facade.GetUserRepository().DeleteOrderByUser(order2, user.Id);
            var getOrder1 = facade.GetOrderRepository().Read(order1.Id);
            Assert.IsNull(getOrder1);
            var getOrder2 = facade.GetOrderRepository().Read(order2.Id);
            Assert.IsNull(getOrder2);


        }
    }
}
