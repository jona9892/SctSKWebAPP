using NUnit.Framework;
using Sct.JSKApi.BLL;
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
    public class BLLUserTest
    {
        private Facade facade;
        private BLLUser bo;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
            bo = new BLLUser(new DBContextSctJSKTest());
        }

        [Test]
        public void Convert_User_Order_To_Event_test()
        {

            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd = DateTime.Now.AddDays(2);

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

            var events = bo.convertToOrdersToEvents(user.Id);
            Assert.IsTrue(events.Count() >=1);

            facade.GetOrderRepository().Delete(user.Id, order);

        }
    }
}
