using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Absttraction
{
    public interface IProductRepository<Product>
    {
        List<Product> ReadAll();
        Product Add(Product product);
        Product Read(int id);
        void Update(Product p);
        void Delete(Product p);
        List<Product> GetProductsByCategory(string category);
    }
}
