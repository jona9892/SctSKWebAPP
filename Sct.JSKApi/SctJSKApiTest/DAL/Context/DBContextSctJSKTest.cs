using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Sct.JSKDAL.Context;

namespace SctJSKApiTest.Context
{
    public class DBContextSctJSKTest : DBContext
    {
        public DBContextSctJSKTest() : base("TESTDB")
        {
        }
    }
}
