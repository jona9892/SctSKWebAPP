using Sct.JSKDAL.Context;
using Sct.JSKDAL.DomainModel;
using Sct.JSKDAL.Repository.Absttraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Implementation
{
    public class ProductRepository : IProductRepository<Product>
    {

        private DBContext ctx;

        public ProductRepository(DBContext context)
        {
            ctx = context;
        }

        public Product Add(Product product)
        {
            ctx.Categories.Attach(product.Category);
            Product newProduct = ctx.Products.Add(product);
            ctx.SaveChanges();
            return newProduct;
        }

        public void Delete(Product p)
        {
            var product = ctx.Products.FirstOrDefault(x => x.Id == p.Id);
            ctx.Products.Remove(product);
            ctx.SaveChanges();

        }

        public Product Read(int id)
        {
            var product = ctx.Products.Include("Category").Where(c => c.Id == id).FirstOrDefault();
            return product;

        }

        public List<Product> ReadAll()
        {
            //return ctx.Users.Include("Adress").Include("Roles").Include(x => x.Roles.Select(z =>z.Role)).ToList();
            return ctx.Products.Include("Category").ToList();
        }

        public void Update(Product p)
        {
            var productDB = ctx.Products.FirstOrDefault(c => c.Id == p.Id);
            var getCategoryId = p.Category.Id;
            productDB.Category = ctx.Categories.FirstOrDefault(item => item.Id == getCategoryId);
            productDB.Title = p.Title;
            productDB.Price = p.Price;
            productDB.Description = p.Description;
            productDB.Image = p.Image;
            productDB.availableforStudents = p.availableforStudents;
            productDB.onlyForHeadmasters = p.onlyForHeadmasters;

            ctx.SaveChanges();
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return ctx.Products.Where(c => c.Category.Name == category).ToList();
        }

    }
}
