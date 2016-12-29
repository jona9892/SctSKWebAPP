using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayService.Services.Abstraction
{
    public interface IArrangementProductService<ArrengementProduct>
    {
        void create(ArrengementProduct arrengementProduct);
        IEnumerable<ArrengementProduct> GetAll();
        ArrengementProduct Get(int id);
        ArrengementProduct Update(ArrengementProduct item);
        ArrengementProduct Delete(ArrengementProduct item);
    }
}
