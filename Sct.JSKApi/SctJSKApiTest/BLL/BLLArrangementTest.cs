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
    public class BLLArrangementTest
    {
        private Facade facade;
        private BLLArrangement bo;
        private Arrangement arrangement1;
        private Arrangement arrangement2;

        [SetUp]
        public void SetUp()
        {
            facade = new Facade(new DBContextSctJSKTest());
            bo = new BLLArrangement(new DBContextSctJSKTest());
            DateTime bd = DateTime.Now.AddDays(2).Date;

            arrangement1 = new Arrangement
            {
                Id = -1,
                Title = "Julefrokost",
                Description = "En julefrokost for 52 personer",
                Date = bd
            };

            arrangement2 = new Arrangement
            {
                Id = -1,
                Title = "Julefrokost",
                Description = "En julefrokost for 52 personer",
                Date = bd
            };
        }

        [Test]
        public void Convert_Arrangement_data_To_Event_test()
        {
            var arr1 = facade.GetArrangementRepository().Add(arrangement1);
            var arr2 = facade.GetArrangementRepository().Add(arrangement2);

            var events = bo.convertArrangementDataToEvents();
            Assert.IsTrue(events.Count() == 2);
            var m_event = events.ElementAt(0);
            Assert.AreEqual(m_event.title, arr1.Title);
            Assert.AreEqual(m_event.start, arr1.Date);
            Assert.AreEqual(m_event.end, arr1.Date);
            var m_event2 = events.ElementAt(1);
            Assert.AreEqual(m_event.title, arr2.Title);
            Assert.AreEqual(m_event.start, arr2.Date);
            Assert.AreEqual(m_event.end, arr2.Date);

        }
    }
}
