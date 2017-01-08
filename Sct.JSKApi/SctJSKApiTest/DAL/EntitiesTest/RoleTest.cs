
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
    public class RoleTest
    {
        [Test]
        public void Role_props_are_set_test()
        {
            var role = new Role
            {
                Id = 1,
                Title = "admin",
                Description = "An administrator"                
            };

            Assert.AreEqual(role.Id, 1);
            Assert.AreEqual(role.Title, "admin");
            Assert.AreEqual(role.Description, "An administrator");
        }
    }
}
