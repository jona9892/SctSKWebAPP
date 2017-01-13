using NUnit.Framework;
using Sct.JSKDAL;
using Sct.JSKDAL.Entities;
using SctJSKApiTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.RepositoryTest
{
    [TestFixture]
    public class ProductRepositoryTest
    {
        private Facade facade;
        private Category category;
        private Product product;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
            category = new Category
            {
                Id = -1,
                Name = "Brød",
                Description = "Godt Brød"
            };
            product = new Product()
            {
                Id = -1,
                Title = "Pizza",
                Price = 100,
                Image = "PizzaImg",
                Description = "Desc Pizza",
                availableforStudents = true,
                onlyForHeadmasters = false,
                Category = category
            };

        }

        [Test]
        public void Product_is_in_db_after_add_test()
        {

            var m_category = facade.GetCategoryRepository().Add(category);
            var m_product = facade.GetProductRepository().Add(product);

            Assert.IsTrue(product.Id > 0);
            var product2 = facade.GetProductRepository().Read(product.Id);
            Assert.AreEqual(m_product, product2);
            Assert.AreEqual(product2.Title, "Pizza");
            Assert.AreEqual(product2.Category.Id, m_category.Id);
            Assert.AreEqual(product2.Price, 100);
        }

        [Test]
        public void Product_get_by_Id_test()
        {
            facade.GetCategoryRepository().Add(category);
            facade.GetProductRepository().Add(product);

            Assert.IsTrue(product.Id > 0);

            var product2 = facade.GetProductRepository().Read(product.Id);
            Assert.AreEqual(product, product2);

        }

        [Test]
        public void Product_get_by_category_test()
        {
            facade.GetCategoryRepository().Add(category);
            facade.GetProductRepository().Add(product);

            Assert.IsTrue(product.Id > 0);

            var products = facade.GetProductRepository().GetProductsByCategory("Brød");
            Assert.IsTrue(products.Count() >= 1);

        }

        [Test]
        public void Product_is_updated_after_update()
        {
            facade.GetCategoryRepository().Add(category);
            facade.GetProductRepository().Add(product);

            Assert.IsNotNull(product);
            Assert.AreEqual(product.Title, "Pizza");

            var newname = "Mælk";
            product.Title = newname;

            facade.GetProductRepository().Update(product);
            Assert.AreEqual(newname, product.Title);
        }

        [Test]
        public void Product_is_removed_from_db()
        {
            var products = facade.GetProductRepository().ReadAll();
           // Assert.IsTrue(products.Count > 0);
            foreach (var product in products)
            {
                facade.GetProductRepository().Delete(product);
            }

            var products2 = facade.GetProductRepository().ReadAll();
            //Assert.IsEmpty(products2);

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
