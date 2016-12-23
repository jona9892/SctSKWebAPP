
using NUnit.Framework;
using Sct.JSKDAL;
using Sct.JSKDAL.DomainModel;
using SctJSKApiTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.RepositoryTest
{
    [TestFixture]
    public class CategoryRepository
    {
        private Facade facade;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
        }

        [Test]
        public void Category_is_in_db_after_add_test()
        {
            var category = new Category()
            {
                Id = -1,
                Name = "Brød",
                Description = "Alt med brød"
            };

            facade.GetCategoryRepository().Add(category);

            Assert.IsTrue(category.Id > 0);

            var category2 = facade.GetCategoryRepository().Read(category.Id);
            Assert.AreEqual(category, category2);
        }

        [Test]
        public void Category_get_by_Id_test()
        {
            var category = new Category()
            {
                Id = -1,
                Name = "Brød",
                Description = "Alt med brød"
            };
            facade.GetCategoryRepository().Add(category);

            Assert.IsTrue(category.Id > 0);

            var category2 = facade.GetCategoryRepository().Read(category.Id);
            Assert.AreEqual(category, category2);

        }

        [Test]
        public void Category_is_updated_after_update()
        {
            var category = new Category()
            {
                Id = -1,
                Name = "Brød",
                Description = "Alt med brød"
            };
            facade.GetCategoryRepository().Add(category);

            Assert.IsNotNull(category);
            Assert.AreEqual(category.Name, "Brød");

            var newname = "Mælk";
            category.Name = newname;

            facade.GetCategoryRepository().Update(category);
            Assert.AreEqual(newname, category.Name);
        }

        [Test]
        public void Category_is_removed_from_db()
        {
            var categories = facade.GetCategoryRepository().ReadAll();
            foreach (var category in categories)
            {
                facade.GetCategoryRepository().Delete(category);
            }

            var categories2 = facade.GetCategoryRepository().ReadAll();
            Assert.IsEmpty(categories2);
        }

    }
}
