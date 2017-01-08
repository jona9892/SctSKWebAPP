using System.Data.Entity;
using Sct.JSKDAL.Entities;

namespace Sct.JSKDAL.Context
{
    public class DBContext : DbContext
    {
        /// <summary>
        ///     Sets the Database with a string name
        ///     and creates a new Db.
        /// </summary>
        public DBContext(string name) : base(name)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        ///     All the tables that will be created in the Db
        /// </summary>
        public DbSet<Adress> Adresses { get; set; }
        //public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Arrangement> Arrangements { get; set; }
        public DbSet<ArrangementProduct> ArrangementProducts { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

    }
}
