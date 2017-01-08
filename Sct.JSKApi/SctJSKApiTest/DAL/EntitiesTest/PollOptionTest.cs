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
    public class PollOptionTest
    {
        [Test]
        public void PollOption_props_are_set_test()
        {

            var poll = new Poll
            {
                Id = 1,
                Active = true,
                Question = "Yes"
            };

            var pollOption = new PollOption
            {
                Id = 1,
                Poll = poll,
                OptionText = "No"
            };

            Assert.AreEqual(pollOption.Id, 1);
            Assert.AreEqual(pollOption.OptionText, "No");
        }
    }
}
