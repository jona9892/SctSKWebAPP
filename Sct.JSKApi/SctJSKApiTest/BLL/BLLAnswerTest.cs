using NUnit.Framework;
using Sct.JSKApi.BLL;
using Sct.JSKDAL;
using Sct.JSKDAL.Entities;
using SctJSKApiTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SctJSKApiTest.BLL
{
    [TestFixture]
    public class BLLAnswerTest
    {
        private Facade facade;
        private BLLAnswer bo;

        private User m_user1;
        private User m_user2;
        private Poll m_poll1;
        private Poll m_poll2;
        private PollOption m_pollOption;
        private Answer m_answer;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
            bo = new BLLAnswer(new DBContextSctJSKTest());
            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            m_user1 = new User
            {
                Id = -1,
                FirstName = "Jonathan",
                LastName = "Gjøl",
                Birthday = bd,
                Username = "Jona1234",
                Password = "123456",

                Adress = new Adress
                {
                    Id = -1,
                    AdressLine = "Adress1",
                    City = "by1",
                    ZipCode = 6800
                },
                Email = "EmailTest@hotmail.dk",
                Roles = role,
                Phone = 41289203
            };
            

            m_user2 = new User
            {
                Id = -1,
                FirstName = "Jonathan",
                LastName = "Gjøl",
                Birthday = bd,
                Username = "Jona1234",
                Password = "123456",

                Adress = new Adress
                {
                    Id = -1,
                    AdressLine = "Adress1",
                    City = "by1",
                    ZipCode = 6800
                },
                Email = "EmailTest@hotmail.dk",
                Roles = role,
                Phone = 41289203
            };
            

            m_poll1 = new Poll
            {
                Id = -1,
                Active = true,
                Question = "Is this good"
            };
            

            m_poll2 = new Poll
            {
                Id = -1,
                Active = true,
                Question = "Is this good"
            };
            

            m_pollOption = new PollOption
            {
                Id = -1,
                Poll = m_poll1,
                OptionText = "No"
            };
            

            m_answer = new Answer
            {
                Id = -1,
                PollOption = m_pollOption,
                PollId = m_poll1.Id,
                User = m_user1
            };
            
        }

        [Test]
        public void Get_All_UnAnswered_Polls_by_user()
        {
            //--------Tilføj til database ---------
            var user1 = facade.GetUserRepository().Add(m_user1);
            var user2 = facade.GetUserRepository().Add(m_user2);
            var poll1 = facade.GetPollRepository().Add(m_poll1);
            var poll2 = facade.GetPollRepository().Add(m_poll2);
            var pollOption = facade.GetPollOptionRepository().Add(m_pollOption);
            var answer = facade.GetAnswerRepository().Add(m_answer);
            //----------Udføre test metode ------------
            var unAnsweredPolls = bo.GetUnAnsweredPolls(user1.Id);
            Assert.IsTrue(unAnsweredPolls.Count() == 1);
            //-----------Hent undersøgelse som ikke er blevet svaret-------
            var poll = unAnsweredPolls.ElementAt(0);
            Assert.AreEqual(poll.Id, poll2.Id);
            Assert.AreEqual(poll.Question, poll2.Question);

        }
    }
}
