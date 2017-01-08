using NUnit.Framework;
using Sct.JSKDAL;
using Sct.JSKDAL.Entities;
using SctJSKApiTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.DAL.RepositoryTest
{
    [TestFixture]
    public class PollOptionRepositoryTest
    {
        private Facade facade;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
        }

        [Test]
        public void PollOption_is_in_db_after_add_test()
        {

            var poll = new Poll
            {
                Id = 1,
                Active = true,
                Question = "Yes"
            };
            facade.GetPollRepository().Add(poll);

            var pollOption = new PollOption
            {
                Id = 1,
                Poll = poll,
                OptionText = "No"
            };
            facade.GetPollOptionRepository().Add(pollOption);
            

            Assert.IsTrue(pollOption.Id > 0);
            var poll2 = facade.GetPollRepository().Read(poll.Id);
            Assert.IsTrue(poll2.Id > 0);
            Assert.AreEqual(poll2.PollOptions.Select(p => p.Id).FirstOrDefault(), pollOption.Id);

            facade.GetPollRepository().Delete(poll2);
        }
    }
}
