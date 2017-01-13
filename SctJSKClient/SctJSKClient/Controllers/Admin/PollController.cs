using DTOModel;
using GatewayService;
using SctJSKClient.Models;
using SctJSKClient.Security;
using SctJSKClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            if (SessionPersister.UserRole == "Admin")
            {
                var polls = facade.GetPollService().ReadAll();
                return View(polls);
            }
            else
            {
                var userid = int.Parse(SessionPersister.UserId);
                var polls = facade.GetAnswerService().GetAllUnAnsweredPolls(userid);
                return View(polls);
            }
        }

        public ActionResult GoToPoll(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var poll = facade.GetPollService().Read(id.Value);
            PollOptionViewModel povm = new PollOptionViewModel
            {
                Poll = poll
            };
            return View(povm);
        }

        [HttpPost]
        public ActionResult GoToPoll(PollOptionViewModel povm)
        {

            ModelState.Remove("PollOption");
            ModelState.Remove("Poll.Question");
            if (ModelState.IsValid)
            {
                var userid = int.Parse(SessionPersister.UserId);
                Answer answer = new Answer();
                answer.PollOptionId = int.Parse(povm.selected);
                answer.UserId = userid;
                answer.PollId = povm.Poll.Id;

                HttpResponseMessage response = facade.GetAnswerService().Add(answer);
                if (response.StatusCode == HttpStatusCode.Created)
                    return RedirectToAction("Index");
                else
                    return new HttpStatusCodeResult(response.StatusCode);
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            var poll = facade.GetPollService().Read(povm.Poll.Id);
            PollOptionViewModel povm2 = new PollOptionViewModel
            {
                Poll = poll
            };
            return View(povm2);

        }

        public ActionResult PollResult(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pollresults = facade.GetAnswerService().ReadResults(id.Value);
            if (pollresults == null)
            {
                return HttpNotFound();
            }
            List<Result> voteResults = new List<Result>();
            int totalvotes = pollresults.Sum(r => r.Votes);
            foreach (var item in pollresults)
            {
                Result result = new Result();
                result.PollOption = item.OptionText;
                double percent = (double)item.Votes / totalvotes * 100;
                result.VotePercent = Math.Round(percent, 0);
                result.totalvotes = totalvotes;
                result.votes = item.Votes;
                voteResults.Add(result);
            }

            PollResultViewModel prvm = new PollResultViewModel
            {
                Results = voteResults.ToList(),
                Poll = facade.GetPollService().Read(id.Value)
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(PollViewModel pmv)
        {
            if (ModelState.IsValid)
            {
                pmv.Poll.PollOptions = pmv.options.ToList();
                HttpResponseMessage response = facade.GetPollService().Add(pmv.Poll);
                if (response.StatusCode == HttpStatusCode.Created)
                    return Redirect("Index");
                else
                    return new HttpStatusCodeResult(response.StatusCode);
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = facade.GetPollService().Read(id.Value);
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(poll);
        }

        // POST: Aftale/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question,Active")]Poll poll)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = facade.GetPollService().Update(poll);
                if (response.StatusCode == HttpStatusCode.OK)
                    return RedirectToAction("Index");
                else
                    return new HttpStatusCodeResult(response.StatusCode);
            }
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            var poll = facade.GetPollService().Read(id);
            facade.GetPollService().Delete(poll);
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}