using DTOModel;
using GatewayService;
using SctJSKClient.Models;
using SctJSKClient.Security;
using SctJSKClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SctJSKClient.Controllers
{
    [CustomAuthorize(Roles = "Admin,Student,Teacher,HeadMaster")]
    public class PollController : Controller
    {
        private readonly Facade facade = new Facade();

        public ActionResult Index()
        {

            if(SessionPersister.UserRole == "Admin")
            {
                var polls = facade.GetPollService().ReadAll();
                return View(polls);
            }else
            {
                var userid = int.Parse(SessionPersister.UserId);
                var polls = facade.GetAnswerService().GetAllUnAnsweredPolls(userid);
                return View(polls);
            }     
        }

        public ActionResult GoToPoll(int id)
        {
            var poll = facade.GetPollService().Read(id);
            PollOptionViewModel povm = new PollOptionViewModel
            {
                Poll = poll
            };
            return View(povm);
        }
        
        [HttpPost]        
        public ActionResult GoToPoll(PollOptionViewModel povm)
        {
            var userid = int.Parse(SessionPersister.UserId);
            Answer answer = new Answer();
            answer.PollOptionId = int.Parse(povm.selected);
            answer.UserId = userid;
            answer.PollId = povm.Poll.Id;

            facade.GetAnswerService().Add(answer);
            return RedirectToAction("Index");
        }

        public ActionResult PollResult(int id)
        {
            var pollresults = facade.GetAnswerService().ReadResults(id);
            List<Result> voteResults = new List<Result>();
            int totalvotes = pollresults.Sum(r => r.Votes);
            foreach(var item in pollresults)
            {
                Result result = new Result();
                result.PollOption = item.OptionText;
                double percent = (double)item.Votes / totalvotes *100;
                result.VotePercent = Math.Round(percent, 0);
                result.totalvotes = totalvotes;
                result.votes = item.Votes;
                voteResults.Add(result);
            }

            PollResultViewModel prvm = new PollResultViewModel
            {
                Results = voteResults.ToList(),
                Poll = facade.GetPollService().Read(id)
            };
            return View(prvm);
        }

        public ActionResult Create()
        {
            List<PollOption> listpo = new List<PollOption>();
            listpo.Add(new PollOption { OptionText = "" });
            PollViewModel pvm = new PollViewModel
            {
                options = listpo
            };

            return View(pvm);
        }

        public ActionResult BlankPollOptionRow()
        {
            return PartialView("PollOptionRow", new PollOption());
        }

        // POST: Aftale/Create
        [HttpPost]
        public ActionResult Create(PollViewModel pmv)
        {
            if (ModelState.IsValid)
            {
                pmv.Poll.PollOptions = pmv.options.ToList();
                facade.GetPollService().Add(pmv.Poll);
                return Redirect("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Poll poll = facade.GetPollService().Read(id);
            return View(poll);
        }

        // POST: Aftale/Edit/5
        [HttpPost]
        public ActionResult Edit(Poll poll)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {

                    facade.GetPollService().Update(poll);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var poll = facade.GetPollService().Read(id);
            facade.GetPollService().Delete(poll);
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}