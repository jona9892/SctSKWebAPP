using NUnit.Framework;
using Sct.JSKDAL.Context;
using Sct.JSKDAL.DomainModel;
using SctJSKApiTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.DAL.Context
{
    [TestFixture]
    public class ContextTest
    {
        private DBContext Context()
        {
            var dbc = new DBContextSctJSKTest();

            return dbc;
        }

        [Test]
        public void Can_create_and_read_category_to_context()
        {
            var ctx = Context();
            var category = new Category { Id = 1, Name = "Brød", Description = "yay"};

            ctx.Categories.Add(category);
            ctx.SaveChanges();

            var catDb = ctx.Categories.FirstOrDefault(x => x.Id == category.Id);


            Assert.AreEqual(category.Id, catDb.Id);
        }

        [Test]
        public void Can_update_category_to_context()
        {
            var ctx = Context();
            var category = new Category { Id = 1, Name = "Brød", Description = "yay" };

            ctx.Categories.Add(category);
            ctx.SaveChanges();

            var newName = "Deterdanser";
            category.Name = newName;
            ctx.SaveChanges();
            Assert.AreEqual(category.Name, newName);
        }

        [Test]
        public void Can_delete_and_category_to_context()
        {
            var ctx = Context();
            var category = new Category { Id = 1, Name = "Brød", Description = "yay" };

            ctx.Categories.Add(category);
            ctx.SaveChanges();


            ctx.Categories.Remove(category);
            ctx.SaveChanges();

            var categoryDb = ctx.Categories.FirstOrDefault(x => x.Id == category.Id);
            Assert.IsNull(categoryDb);

        }
    }
}