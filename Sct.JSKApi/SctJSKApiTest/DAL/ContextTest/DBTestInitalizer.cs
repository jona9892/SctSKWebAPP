using SctJSKApiTest.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.DAL.Context
{
    public class DBTestInitalizer : DropCreateDatabaseAlways<DBContextSctJSKTest>
    {
        protected override void Seed(DBContextSctJSKTest ctx)
        {
        }
    }
}
