using Sct.JSKDAL.Context;
using Sct.JSKDAL.DomainModel;
using Sct.JSKDAL.Repository.Absttraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Implementation
{
    public class CategoryRepository : IRepository<Category>
    {

        private DBContext ctx;

        public CategoryRepository(DBContext context)
        {
            ctx = context;
        }

        public Category Add(Category category)
        {
            Category newCategory = ctx.Categories.Add(category);
            ctx.SaveChanges();
            return newCategory;
        }

        public void Delete(Category c)
        {
            var category = ctx.Categories.FirstOrDefault(x => x.Id == c.Id);
            ctx.Categories.Remove(category);
            ctx.SaveChanges();
        }

        public Category Read(int id)
        {
            var category = ctx.Categories.Where(c => c.Id == id).FirstOrDefault();
            return category;
        }

        public List<Category> ReadAll()
        {
            //return ctx.Users.Include("Adress").Include("Roles").Include(x => x.Roles.Select(z =>z.Role)).ToList();
            return ctx.Categories.Include("Product").ToList();
        }

        public void Update(Category c)
        {
            var categoryDB = ctx.Categories.FirstOrDefault(item => item.Id == c.Id);
            categoryDB.Name = c.Name;
            categoryDB.Description = c.Description;

            ctx.SaveChanges();
        }
    }
}
