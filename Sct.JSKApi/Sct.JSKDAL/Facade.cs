using Sct.JSKDAL.Context;
using Sct.JSKDAL.DomainModel;
using Sct.JSKDAL.Entities;
using Sct.JSKDAL.Repository.Absttraction;
using Sct.JSKDAL.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL
{
    public class Facade
    {
        private readonly DBContext ctx;

        public Facade(DBContext context)
        {
            ctx = context;
        }

        public IUser<User> GetUserRepository()
        {
            return new UserRepository(ctx);
        }

        public IProductRepository GetProductRepository()
        {
            return new ProductRepository(ctx);
        }

        public IRepository<Category> GetCategoryRepository()
        {
            return new CategoryRepository(ctx);
        }

        public IOrderRepository<Order> GetOrderRepository()
        {
            return new OrderRepository(ctx);
        }

        public IOrderDetailRepository GetOrderDetailRepository()
        {
            return new OrderDetailRepository(ctx);
        }

        public IArrangementRepository<Arrangement> GetArrangementRepository()
        {
            return new ArrangementRepository(ctx);
        }

        public IArrangementProductRepository<ArrangementProduct> GetArrangementProductRepository()
        {
            return new ArrangementProductRepository(ctx);
        }

        public IPollRepository<Poll> GetPollRepository()
        {
            return new PollRepository(ctx);
        }

        public IPollOptionRepository<PollOption> GetPollOptionRepository()
        {
            return new PollOptionRepository(ctx);
        }

        public IAnswerRepository<Answer> GetAnswerRepository()
        {
            return new AnswerRepository(ctx);
        }
    }
}
