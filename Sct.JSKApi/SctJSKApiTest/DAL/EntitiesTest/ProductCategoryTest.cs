﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sct.JSKDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.DomainModelTest
{
    [TestClass]
    public class ProductCategoryTest
    {
        [TestMethod]
        public void Product_Category_props_are_set_test()
        {
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

            Assert.AreEqual(product.Id, 1);
            Assert.AreEqual(product.Title, "bolle");
            Assert.AreEqual(product.Price, 20);
            Assert.AreEqual(product.Description, "normal bolle");
            Assert.AreEqual(product.Image, "billede");

            Assert.AreEqual(product.Category.Id, 1);
            Assert.AreEqual(product.Category.Name, "Brød");
            Assert.AreEqual(product.Category.Description, "Alt med brød");
        }
    }
}