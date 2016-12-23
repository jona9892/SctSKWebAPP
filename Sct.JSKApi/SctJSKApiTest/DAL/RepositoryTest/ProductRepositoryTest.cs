﻿using NUnit.Framework;
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
    public class ProductRepositoryTest
    {
        private Facade facade;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
        }

        [Test]
        public void Product_is_in_db_after_add_test()
        {
            var category = new Category
            {
                Id = -1,
                Name = "BRød",
                Description = "Godt Brøde"
            };
            facade.GetCategoryRepository().Add(category);

            var product = new Product()
            {
                Id = -1,
                Title = "Brød",
                Category = category
            };

            facade.GetProductRepository().Add(product);

            Assert.IsTrue(product.Id > 0);

            var product2 = facade.GetProductRepository().Read(product.Id);
            Assert.AreEqual(product, product2);
        }

        [Test]
        public void Product_get_by_Id_test()
        {
            var category = new Category
            {
                Id = -1,
                Name = "BRød",
                Description = "Godt Brøde"
            };
            facade.GetCategoryRepository().Add(category);
            var product = new Product()
            {
                Id = -1,
                Title = "Brød",
                Description = "Alt med brød",
                Category = category
            };
            facade.GetProductRepository().Add(product);

            Assert.IsTrue(product.Id > 0);

            var product2 = facade.GetProductRepository().Read(product.Id);
            Assert.AreEqual(product, product2);

        }

        [Test]
        public void Product_is_updated_after_update()
        {
            var category = new Category
            {
                Id = -1,
                Name = "BRød",
                Description = "Godt Brøde"
            };
            facade.GetCategoryRepository().Add(category);
            var product = new Product()
            {
                Id = -1,
                Title = "Brød",
                Description = "Alt med brød", 
                Category = category
            };
            facade.GetProductRepository().Add(product);

            Assert.IsNotNull(product);
            Assert.AreEqual(product.Title, "Brød");

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
            Assert.IsEmpty(products2);
        }
    }
}
