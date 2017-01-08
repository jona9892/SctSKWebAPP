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
    public class UserTest
    {
        [Test]
        public void User_Adress_props_are_set_test()
        {
            var adress = new Adress
            {
                Id = 1,
                AdressLine = "Adress1test",
                City = "By1test",
                ZipCode = 6800                
            };

            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            var order = new Order
            {
                Id = 1,
                TotalPrice = 100
            };
            List<Order> listOrders = new List<Order>();
            listOrders.Add(order);

            var user = new User
            {
                Id = 1,
                FirstName = "Jonathan",
                LastName = "Gjøl",
                Birthday = bd, 
                Username = "Jona123",
                Password = "123456",
                Adress = adress,
                Email = "EmailTest",
                Roles = role,
                Phone = 41289203,
                Order = listOrders
            };

            Assert.AreEqual(user.Id, 1);
            Assert.AreNotEqual(user.Id, 10);

            Assert.AreEqual(user.FirstName, "Jonathan");
            Assert.AreNotEqual(user.FirstName, "Jona");

            Assert.AreEqual(user.LastName, "Gjøl");
            Assert.AreNotEqual(user.LastName, "Jona");

            Assert.AreEqual(user.Birthday, bd);
            Assert.AreNotEqual(user.Birthday, "Jona");

            Assert.AreEqual(user.Username, "Jona123");
            Assert.AreNotEqual(user.Username, "Jona");

            Assert.AreEqual(user.Password, "123456");
            Assert.AreNotEqual(user.FirstName, "Jona");

            Assert.AreEqual(user.Adress, adress);
            Assert.AreNotEqual(user.Adress, "Jona");

            Assert.AreEqual(user.Email, "EmailTest");
            Assert.AreNotEqual(user.FirstName, "Jona");

            Assert.AreEqual(user.Roles, role);
            Assert.AreNotEqual(user.Roles, "Jona");

            Assert.AreEqual(user.Phone, 41289203);
            Assert.AreNotEqual(user.Phone, 123456);

            Assert.AreEqual(user.Order, listOrders);
            Assert.AreNotEqual(user.Order, "Jona");

        }
    }
}
