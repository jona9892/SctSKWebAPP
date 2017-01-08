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
    public class ArrangementProductRepository
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

            var category = new Category
            {
                Id = -1,
                Name = "BRød",
                Description = "Godt Brøde"
            };
            facade.GetCategoryRepository().Add(category);
            var product = new Product()
            {
                Id = 20,
                Title = "Pizza",
                Price = 100,
                Image = "PizzaImg",
                Description = "Desc Pizza",
                availableforStudents = true,
                onlyForHeadmasters = false,
                Category = category
            };
            facade.GetProductRepository().Add(product);

            var ap = new ArrangementProduct
            {
                Id = 1,
                Quantity = 2,
                Arrangement = arrangement,
                Product = product

            };
            facade.GetArrangementProductRepository().create(ap);

            Assert.IsTrue(ap.Id > 0);
            var ap2 = facade.GetArrangementRepository().Read(arrangement.Id);
            var product2 = facade.GetProductRepository().Read(product.Id);
            Assert.IsTrue(ap2.Id > 0);
            Assert.AreEqual(ap2.Products.Select(a => a.Id).FirstOrDefault(), ap.Id);

            facade.GetArrangementRepository().Delete(arrangement);
        }
    }
}
