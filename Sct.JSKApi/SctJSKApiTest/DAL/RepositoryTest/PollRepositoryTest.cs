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
    public class PollRepositoryTest
    {
        private Facade facade;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
        }

        [Test]
        public void Poll_is_in_db_after_add_test()
        {
            var poll = new Poll
            {
                Id = 1,
                Active = true,
                Question = "Yes"
            };

            facade.GetPollRepository().Add(poll);

            Assert.IsTrue(poll.Id > 0);

            var poll2 = facade.GetPollRepository().Read(poll.Id);
            Assert.AreEqual(poll, poll2);
        }

        [Test]
        public void Poll_get_by_Id_test()
        {
            var poll = new Poll
            {
                Id = 1,
                Active = true,
                Question = "Yes"
            };
            facade.GetPollRepository().Add(poll);

            Assert.IsTrue(poll.Id > 0);

            var poll2 = facade.GetPollRepository().Read(poll.Id);
            Assert.AreEqual(poll, poll2);

        }

        [Test]
        public void Poll_is_updated_after_update()
        {
            var poll = new Poll
            {
                Id = 1,
                Active = true,
                Question = "Yes"
            };
            facade.GetPollRepository().Add(poll);

            Assert.IsNotNull(poll);
            Assert.AreEqual(poll.Question, "Yes");

            var newname = "No";
            poll.Question = newname;

            facade.GetPollRepository().Update(poll);
            Assert.AreEqual(newname, poll.Question);
        }

        [Test]
        public void Poll_is_removed_from_db()
        {
            var polls = facade.GetPollRepository().ReadAll();
            foreach (var poll in polls)
            {
                facade.GetPollRepository().Delete(poll);
            }

            var polls2 = facade.GetPollRepository().ReadAll();
            Assert.IsEmpty(polls2);
        }
    }
}
