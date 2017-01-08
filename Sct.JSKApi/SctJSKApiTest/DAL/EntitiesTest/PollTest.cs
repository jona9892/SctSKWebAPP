using NUnit.Framework;
using Sct.JSKDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.DAL.EntitiesTest
{
    [TestFixture]
    public class PollTest
    {
        [Test]
        public void Poll_props_are_set_test()
        {
            var poll = new Poll
            {
                Id = 1,
                Active = true, 
                Question = "Yes"
            };

            Assert.AreEqual(poll.Id, 1);
            Assert.AreEqual(poll.Question, "Yes");
        }
    }
}
