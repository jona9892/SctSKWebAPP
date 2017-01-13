using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Absttraction
{
    public interface IRepository<T>
    {
        List<T> ReadAll();
        T Add(T t);
        T Read(int id);
        T Update(T e);
        void Delete(T e);
    }
}
