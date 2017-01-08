using NUnit.Framework;
using Sct.JSKDAL;
using Sct.JSKDAL.Entities;
using SctJSKApiTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.DAL.RepositoryTest
{
    [TestFixture]
    public class ArrangementRepositoryTest
    {
        private Facade facade;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
        }

        [Test]
        public void Arrangement_is_in_db_after_add_test()
        {

            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);
            var arrangement = new Arrangement
            {
                Id = 1,
                Title = "Julefrokost",
                Description = "En julefrokost for 52 personer",
                Date = bd
            };

            facade.GetArrangementRepository().Add(arrangement);

            Assert.IsTrue(arrangement.Id > 0);
            var arrangement2 = facade.GetArrangementRepository().Read(arrangement.Id);
            Assert.AreEqual(arrangement, arrangement2);
            Assert.AreEqual(arrangement2.Title, "Julefrokost");
            Assert.AreEqual(arrangement2.Description, "En julefrokost for 52 personer");
        }

        [Test]
        public void Arrangement_get_by_Id_test()
        {
            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);
            var arrangement = new Arrangement
            {
                Id = 1,
                Title = "Julefrokost",
                Description = "En julefrokost for 52 personer",
                Date = bd
            };

            facade.GetArrangementRepository().Add(arrangement);

            Assert.IsTrue(arrangement.Id > 0);

            var arrangement2 = facade.GetArrangementRepository().Read(arrangement.Id);
            Assert.AreEqual(arrangement, arrangement2);

        }

        [Test]
        public void Arrangement_is_removed_from_db()
        {
            var arrangements = facade.GetArrangementRepository().ReadAll();
            // Assert.IsTrue(products.Count > 0);
            foreach (var arrangement in arrangements)
            {
                facade.GetArrangementRepository().Delete(arrangement);
            }

            var arrangements2 = facade.GetArrangementRepository().ReadAll();
            //Assert.IsEmpty(products2);
        }

    }
}
