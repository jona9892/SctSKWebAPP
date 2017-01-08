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
    public class AnswerRepositoryTest
    {

        private Facade facade;
        private User user;
        private Answer answer;
        private Answer answer2;
        private Answer answer3;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
            
        }

        [Test]
        public void Answer_is_in_db_after_add_test()
        {
            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            user = new User
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
            facade.GetUserRepository().Add(user);
            var poll = new Poll
            {
                Id = -1,
                Active = true,
                Question = "Yes"
            };
            facade.GetPollRepository().Add(poll);

            var pollOption = new PollOption
            {
                Id = -1,
                Poll = poll,
                OptionText = "No"
            };
            facade.GetPollOptionRepository().Add(pollOption);


            answer = new Answer
            {
                Id = -1,
                PollOption = pollOption,
                PollId = 1,
                User = user
            };
            answer2 = facade.GetAnswerRepository().Add(answer);

            Assert.IsTrue(answer2.Id > 0);            
            Assert.AreEqual(answer, answer2);
        }

        [Test]
        public void Read_all_answers_by_user()
        {
            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            user = new User
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
            facade.GetUserRepository().Add(user);
            var role2 = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd2 = new DateTime(1995, 10, 9, 0, 0, 0);

            var user2 = new User
            {
                Id = -1,
                FirstName = "Jonathan",
                LastName = "Gjøl",
                Birthday = bd2,
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
                Roles = role2,
                Phone = 41289203
            };
            facade.GetUserRepository().Add(user2);
            var poll = new Poll
            {
                Id = -1,
                Active = true,
                Question = "Yes"
            };
            facade.GetPollRepository().Add(poll);

            var pollOption = new PollOption
            {
                Id = -1,
                Poll = poll,
                OptionText = "No"
            };
            facade.GetPollOptionRepository().Add(pollOption);


            answer = new Answer
            {
                Id = -1,
                PollOption = pollOption,
                PollId = 1,
                User = user
            };
            answer2 = facade.GetAnswerRepository().Add(answer);
            answer3 = new Answer
            {
                Id = -1,
                PollOption = pollOption,
                PollId = 1,
                User = user2
            };
            var answer4 = facade.GetAnswerRepository().Add(answer3);

            var answers = facade.GetAnswerRepository().ReadAllByUser(user.Id);
            Assert.IsTrue(answers.Count() == 1);
        }

        [Test]
        public void Read_results_from_poll()
        {
            var role = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd = new DateTime(1995, 10, 9, 0, 0, 0);

            user = new User
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
            facade.GetUserRepository().Add(user);
            var role2 = new Role
            {
                Id = 1,
                Title = "Admin",
                Description = "An administrator"
            };

            DateTime bd2 = new DateTime(1995, 10, 9, 0, 0, 0);

            var user2 = new User
            {
                Id = -1,
                FirstName = "Jonathan",
                LastName = "Gjøl",
                Birthday = bd2,
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
                Roles = role2,
                Phone = 41289203
            };
            facade.GetUserRepository().Add(user2);
            var poll = new Poll
            {
                Id = -1,
                Active = true,
                Question = "Yes"
            };
            facade.GetPollRepository().Add(poll);

            var pollOption = new PollOption
            {
                Id = -1,
                Poll = poll,
                OptionText = "No"
            };
            facade.GetPollOptionRepository().Add(pollOption);

            answer = new Answer
            {
                Id = -1,
                PollOption = pollOption,
                PollId = poll.Id,
                User = user
            };
            answer2 = facade.GetAnswerRepository().Add(answer);
            
            var result = facade.GetAnswerRepository().ReadResults(1);

            var pollResult = new PollResult
            {
                OptionText = "No",
                Votes = 2
            };

            Assert.IsTrue(result.Count() >= 1);
        }

    }
}
