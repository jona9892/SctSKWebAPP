using DTOModel;
using GatewayService;
using SctJSKClient.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SctJSKClient.Controllers
{   
    [CustomAuthorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly Facade facade = new Facade();
        // GET: User
        public ActionResult Index()
        {
            var users = facade.GetUserService().GetAll();
            return View(users);
        }

        // GET: Aftale/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Aftale/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here
                facade.GetUserService().Add(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aftale/Edit/5
        public ActionResult Edit(int id)
        {
            User user = facade.GetUserService().Get(id);
            return View(user);
        }

        // POST: Aftale/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    facade.GetUserService().Update(user);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aftale/Delete/5
        public ActionResult Delete(int id)
        {
            var user = facade.GetUserService().Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Aftale/Delete/5
        [HttpPost]
        public ActionResult Delete(User user)
        {
            try
            {
                // TODO: Add delete logic here
                facade.GetUserService().Delete(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}