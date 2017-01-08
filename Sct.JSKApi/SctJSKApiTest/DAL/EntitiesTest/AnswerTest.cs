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
    public class AnswerTest
    {
        [Test]
        public void answer_props_are_set_test()
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

            var user = new User
            {
                Id = 1,
                FirstName = "Jonathan",
                LastName = "Gjøl",
                Username = "Jona123",
                Password = "123456",
                Email = "EmailTest",
                Phone = 41289203,
            };

            var answer = new Answer
            {
                Id = 1, 
                PollOption = pollOption,
                PollId = 1,
                User = user,
                PollOptionId = pollOption.Id,
                UserId = user.Id
            };

            Assert.AreEqual(answer.Id, 1);
            Assert.AreEqual(answer.PollId, 1);
            Assert.AreEqual(answer.User, user);

        }
    }
}
