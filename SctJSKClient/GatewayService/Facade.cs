using DTOModel;
using GatewayService.Services.Abstraction;
using GatewayService.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayService
{
    public class Facade
    {
        public IUserGateway<User> GetUserService()
        {
            return new UserService();
        }

        public IProductService<Product> GetProductService()
        {
            return new ProductService();
        }

        public IGatewayService<Category> GetCategoryService()
        {
            return new CategoryService();
        }

        public IOrderService<Order> GetOrderService()
        {
            return new OrderService();
        }

        public IOrderDetailService GetOrderDetailService()
        {
            return new OrderDetailService();
        }

        public IArrangementService<Arrangement> GetArrangementService()
        {
            return new ArrangementService();
        }

        public IArrangementProductService<ArrangementProduct> GetArrangementProductService()
        {
            return new ArrangementProductService();
        }

        public IPollService<Poll> GetPollService()
        {
            return new PollService();
        }

        public IAnswerService<Answer> GetAnswerService()
        {
            return new AnswerService();
        }

    }
}
