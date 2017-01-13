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
    }
}
