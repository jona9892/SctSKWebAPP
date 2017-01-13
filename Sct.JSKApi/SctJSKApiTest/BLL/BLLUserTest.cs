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

        private User user;
        private Order order1;
        private Order order2;


        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
            bo = new BLLUser(new DBContextSctJSKTest());
            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd = DateTime.Now.AddDays(2).Date;
            

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

            
            order1 = new Order
            {
                Id = -1,
                User = user,
                OrderCreated = bd,
                OrderDate = bd,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };

            order2 = new Order
            {
                Id = -1,
                User = user,
                OrderCreated = bd,
                OrderDate = bd,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };
        }

        [Test]
        public void Convert_User_Order_To_Event_test()
        {
            var m_user = facade.GetUserRepository().Add(user);
            var m_order1 = facade.GetOrderRepository().Add(order1);
            var m_order2 = facade.GetOrderRepository().Add(order2);
            TimeSpan ts = new TimeSpan(10, 0, 0);
            m_order1.OrderDate = m_order1.OrderDate + ts;
            m_order2.OrderDate = m_order2.OrderDate + ts;

            var events = bo.convertToOrdersToEvents(user.Id);
            Assert.IsTrue(events.Count() == 2);

            var m_event = events.ElementAt(0);
            Assert.AreEqual(m_event.title, "Ordre Nr:" + m_order1.Id);
            Assert.AreEqual(m_event.start, m_order2.OrderDate);
            var m_event2 = events.ElementAt(1);
            Assert.AreEqual(m_event2.title, "Ordre Nr:" + order2.Id);
            Assert.AreEqual(m_event2.start, order2.OrderDate);

            facade.GetUserRepository().DeleteOrderByUser(m_order1, m_user.Id);
            facade.GetUserRepository().DeleteOrderByUser(m_order2, m_user.Id);

        }
    }
}
