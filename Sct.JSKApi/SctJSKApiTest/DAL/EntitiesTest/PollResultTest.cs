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
    public class PollResultTest
    {
        [Test]
        public void PollResult_props_are_set_test()
        {
            var pollResult = new PollResult
            {
                OptionText = "Test",
                Votes = 2
            };

            Assert.AreEqual(pollResult.OptionText, "Test");
            Assert.AreEqual(pollResult.Votes, 2);
        }
    }
}
