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
    public class AdressTest
    {
        [Test]
        public void Adress_props_are_set_test()
        {
            var user = new User
            {
                Id = 1,
                FirstName = "Jonathan",
                LastName = "Gjøl",
                Username = "Jona123",
                Password = "123456",
                Email = "EmailTest",
                Phone = 41289203,
            };

            var adress = new Adress
            {
                Id = 1,
                AdressLine = "Adress1test",
                City = "By1test",
                ZipCode = 6800,
                User = user
            };

            Assert.AreEqual(adress.Id, 1);
            Assert.AreEqual(adress.AdressLine, "Adress1test");
            Assert.AreEqual(adress.City, "By1test");
            Assert.AreEqual(adress.ZipCode, 6800);
            Assert.AreEqual(adress.User, user);
        }
    }
}
