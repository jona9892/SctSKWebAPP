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
    public class OrderDetailRepositoryTest
    {

        private Facade facade;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
        }

        [Test]
        public void OrderDetail_is_in_db_after_add_test()
        {
            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            var user = new User
            {
                Id = -1,
                FirstName = "Jonathan",
                LastName = "Gjøl",
                Birthday = bd,
                Username = "Jona1234",
                Password = "123456",

                Adress = new Adress
                {
                    Id = 1,
                    AdressLine = "Adress1",
                    City = "by1",
                    ZipCode = 6800
                },
                Email = "EmailTest@hotmail.dk",
                Roles = role,
                Phone = 41289203
            };

            facade.GetUserRepository().Add(user);

            var order = new Order
            {
                Id = -1,
                User = user,
                OrderCreated = bd,
                OrderDate = bd,
                TimeOfDay = "09:50",
                TotalPrice = 100
            };

            facade.GetOrderRepository().Add(order);

            var category = new Category
            {
                Id = -1,
                Name = "Brød",
                Description = "Godt Brød"
            };
            facade.GetCategoryRepository().Add(category);
            var product = new Product()
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
            facade.GetProductRepository().Add(product);

            OrderDetail orderdetail = new OrderDetail
            {
                Order = order, 
                Product = product, 
                Quantity = 20,
                Price = 100,                

            };

            facade.GetOrderDetailRepository().create(orderdetail);

            var order2 = facade.GetOrderRepository().Read(order.Id);
            Assert.AreEqual(order2.OrderDetails.Select(x=> x.Id).FirstOrDefault(), orderdetail.Id);

            facade.GetOrderRepository().Delete(user.Id, order);

        }


    }
}
