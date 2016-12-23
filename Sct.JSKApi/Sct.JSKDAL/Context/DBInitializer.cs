using Sct.JSKDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Context
{
    public class DBInitialize : DropCreateDatabaseIfModelChanges<DBContextSctJSK>
    {
        protected override void Seed(DBContextSctJSK ctx)
        {

            //Adresses
            var adresse1 = new Adress()
            {
                Id = 1,
                AdressLine = "TestVej 1",
                City = "By1",
                ZipCode = 6800
            };
            var adresse2 = new Adress()
            {
                Id = 2,
                AdressLine = "TestVej 2",
                City = "By2",
                ZipCode = 6800
            };
            var adresse3 = new Adress()
            {
                Id = 3,
                AdressLine = "Lerpøtparken 14 tv. st.",
                City = "Varde",
                ZipCode = 6800
            };
            var adresse4 = new Adress()
            {
                Id = 4,
                AdressLine = "Lerpøtparken 14 tv. st.",
                City = "Varde",
                ZipCode = 6800
            };

            ctx.Adresses.Add(adresse1);
            ctx.Adresses.Add(adresse2);


            DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);

            var role1 = new Role
            {
                Id = 1,
                Title = "Student",
                Description = "Student of the school"
            };
            var role2 = new Role
            {
                Id = 2,
                Title = "Teacher",
                Description = "Teacher of the school"
            };
            var role3 = new Role
            {
                Id = 3,
                Title = "Admin",
                Description = "Cafeteria staff, who is the administrator of the application"
            };
            var role4 = new Role
            {
                Id = 4,
                Title = "HeadMaster",
                Description = "One of the few headmasters at school"
            };
            ctx.Roles.Add(role1);
            ctx.Roles.Add(role2);
            ctx.Roles.Add(role3);
            ctx.Roles.Add(role4);

            var user1 = new User
            {
                Id = 1,
                FirstName = "User 1",
                LastName = "User 1",
                Birthday = date1,
                Email = "Email1",
                Phone = 1,
                Adress = adresse1,
                Username = "jona9892",
                Password = "123456",
                Roles = role1

            };
            var user2 = new User
            {
                Id = 2,
                FirstName = "User 2",
                LastName = "User 2",
                Birthday = date1,
                Email = "Email2",
                Phone = 2,
                Adress = adresse2,
                Roles = role2

            };
            var user3 = new User
            {
                Id = 3,
                FirstName = "Knud",
                LastName = "Gjøl",
                Birthday = date1,
                Email = "Knud@sighotel.dk",
                Phone = 41289200,
                Adress = adresse3,
                Roles = role3,
                Username = "Knud1234",
                Password = "123456"

            };
            var user4 = new User
            {
                Id = 4,
                FirstName = "HeadMaster",
                LastName = "The third",
                Birthday = date1,
                Email = "Knud@sighotel.dk",
                Phone = 41289200,
                Adress = adresse4,
                Roles = role4,
                Username = "HeadMaster3",
                Password = "123456"

            };

            ctx.Users.Add(user1);
            ctx.Users.Add(user2);
            ctx.Users.Add(user3);
            ctx.Users.Add(user4);

            var category1 = new Category
            {
                Id = 1,
                Name = "Brød",
                Description = "Alle de produlter der har med brød at gør"
            };

            var category2 = new Category
            {
                Id = 2,
                Name = "Drikkevarer",
                Description = "Alle de produlter der har med drikke varer at gør"
            };
            ctx.Categories.Add(category1);
            ctx.Categories.Add(category2);

            var product1 = new Product
            {
                Id = 1,
                Title = "Sandwhich",
                Price = 20,
                Description = "Lovely sandwich",
                Image = "http://thesandwichguide.com/wp-content/uploads/sandwich.jpg",
                CategoryId = 1,
                availableforStudents = true,
                onlyForHeadmasters = false
            };

            var product2 = new Product
            {
                Id = 2,
                Title = "Mælk",
                Price = 20,
                Description = "Arla mini mælk",
                Image = "https://skolemad.dk/lev61/ill/b107.jpg",
                CategoryId = 2,
                availableforStudents = true,
                onlyForHeadmasters = false
            };
            var product3 = new Product
            {
                Id = 3,
                Title = "Sandwhich",
                Price = 20,
                Description = "Lovely sandwich",
                Image = "http://thesandwichguide.com/wp-content/uploads/sandwich.jpg",
                CategoryId = 1,
                availableforStudents = true,
                onlyForHeadmasters = false
            };

            var product4 = new Product
            {
                Id = 4,
                Title = "Kaffe",
                Price = 20,
                Description = "En kande kaffe",
                Image = "http://static.gigantium.dk/image.php?mwidth=268&mheight=298&filename=./upload/kaffekande.jpg",
                CategoryId = 2,
                availableforStudents = false,
                onlyForHeadmasters = true
            };
            var product5 = new Product
            {
                Id = 5,
                Title = "Kaffe",
                Price = 20,
                Description = "En kande kaffe",
                Image = "http://static.gigantium.dk/image.php?mwidth=268&mheight=298&filename=./upload/kaffekande.jpg",
                CategoryId = 1,
                availableforStudents = false,
                onlyForHeadmasters = false
            };

            var product6 = new Product
            {
                Id = 6,
                Title = "Mælk",
                Price = 20,
                Description = "Arla mini mælk",
                Image = "https://skolemad.dk/lev61/ill/b107.jpg",
                CategoryId = 2,
                availableforStudents = true,
                onlyForHeadmasters = false
            };
            var product7 = new Product
            {
                Id = 7,
                Title = "Sandwhich",
                Price = 20,
                Description = "Lovely sandwich",
                Image = "http://thesandwichguide.com/wp-content/uploads/sandwich.jpg",
                CategoryId = 1,
                availableforStudents = true,
                onlyForHeadmasters = false
            };

            var product8 = new Product
            {
                Id = 8,
                Title = "Mælk",
                Price = 20,
                Description = "Arla mini mælk",
                Image = "https://skolemad.dk/lev61/ill/b107.jpg",
                CategoryId = 2,
                availableforStudents = true,
                onlyForHeadmasters = false
            };
            var product9 = new Product
            {
                Id = 9,
                Title = "Sandwhich",
                Price = 20,
                Description = "Lovely sandwich",
                Image = "http://thesandwichguide.com/wp-content/uploads/sandwich.jpg",
                CategoryId = 1,
                availableforStudents = true,
                onlyForHeadmasters = false
            };

            var product10 = new Product
            {
                Id = 10,
                Title = "Mælk",
                Price = 20,
                Description = "Arla mini mælk",
                Image = "https://skolemad.dk/lev61/ill/b107.jpg",
                CategoryId = 2,
                availableforStudents = true,
                onlyForHeadmasters = false
            };

            ctx.Products.Add(product1);
            ctx.Products.Add(product2);
            ctx.Products.Add(product3);
            ctx.Products.Add(product4);
            ctx.Products.Add(product5);
            ctx.Products.Add(product6);
            ctx.Products.Add(product7);
            ctx.Products.Add(product8);
            ctx.Products.Add(product9);
            ctx.Products.Add(product10);

            List<ArrangementProduct> prodList = new List<ArrangementProduct>();

            var arrangementproducts1 = new ArrangementProduct
            {
                ProductId = 1,
                Quantity = 20
            };
            var arrangementproducts2 = new ArrangementProduct
            {
                ProductId = 2,
                Quantity = 20
            };
            var arrangementproducts3 = new ArrangementProduct
            {
                ProductId = 3,
                Quantity = 20
            };
            var arrangement1 = new Arrangement
            {
                Id = 1,
                Description = "nice",
                Date = DateTime.Now,
                Products = new List<ArrangementProduct>
                {
                    arrangementproducts1, arrangementproducts2, arrangementproducts3
                }

            };
            ctx.Arrangements.Add(arrangement1);
             var arrangement2 = new Arrangement
            {
                Id = 2,
                Description = "nice",
                Date = DateTime.Now,
                Products = new List<ArrangementProduct>
                {
                    arrangementproducts1, arrangementproducts2, arrangementproducts3
                }

            };
            ctx.Arrangements.Add(arrangement2);


            // ctx.ArrangementProducts.Add(arrangementproducts1);
            // ctx.ArrangementProducts.Add(arrangementproducts2);


            /*
            var UserRole1 = new UserRole
            {
                UserId = 1,
                RoleId = 1
            };
            ctx.UserRoles.Add(UserRole1);*/

        }
    }
}
