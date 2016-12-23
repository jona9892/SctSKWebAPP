using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Sct.JSKDAL.Context;

namespace Sct.JSKDAL.Context
{
    public class DBContextSctJSK : DBContext
    {
        public DBContextSctJSK() : base("SctJSKAPPDB")
        {
            Database.SetInitializer(new DBInitialize());
        }
    }
}
