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
    public class ArrangementProductTest
    {
        [Test]
        public void Arrangement_Product_props_are_set_test()
        {
            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);
            var arrangement = new Arrangement
            {
                Id = 1,
                Title = "Julefrokost",
                Description = "En julefrokost for 52 personer",
                Date = bd
            };

            var category = new Category
            {
                Id = 1,
                Name = "Brød",
                Description = "Alt med brød"
            };

            var product = new Product
            {
                Id = 1,
                Title = "bolle",
                Price = 20,
                Description = "normal bolle",
                Image = "billede",
                Category = category
                
            };

            var ap = new ArrangementProduct
            {
                Id = 1,
                Quantity = 2, 
                Arrangement = arrangement,
                Product = product
                
            };

            Assert.AreEqual(ap.Id, 1);
            Assert.AreEqual(ap.Product.Title, "bolle");
            Assert.AreEqual(ap.Arrangement.Title, "Julefrokost");
        }
    }
}
