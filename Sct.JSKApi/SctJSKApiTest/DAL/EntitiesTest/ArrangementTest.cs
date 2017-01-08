using NUnit.Framework;
using Sct.JSKDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.DAL.EntitiesTest
{
    [TestFixture]
    public class ArrangementTest
    {
        [Test]
        public void Arrangement_props_are_set_test()
        {
            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);
            var arrangement = new Arrangement
            {
                Id = 1,
                Title = "Julefrokost",
                Description = "En julefrokost for 52 personer",
                Date = bd
            };


            Assert.AreEqual(arrangement.Id, 1);
            Assert.AreEqual(arrangement.Title, "Julefrokost");
            Assert.AreEqual(arrangement.Description, "En julefrokost for 52 personer");
        }
    }
}
