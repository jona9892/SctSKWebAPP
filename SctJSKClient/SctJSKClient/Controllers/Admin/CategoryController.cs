using DTOModel;
using GatewayService;
using SctJSKClient.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SctJSKClient.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private Facade facade = new Facade();

        // GET: Category
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var categories = facade.GetCategoryService().GetAll();

            switch (sortOrder)
            {
                case "name_desc":
                    categories = categories.OrderByDescending(s => s.Name);
                    break;
                default:
                    categories = categories.OrderBy(s => s.Name);
                    break;
            }

            return View(categories);
        }

        // GET: Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = facade.GetCategoryService().Add(category);
                if (response.StatusCode == HttpStatusCode.Created)
                    return RedirectToAction("Index");
                else
                    return new HttpStatusCodeResult(response.StatusCode);
            }
            return View(category);
        }

        // GET: Category/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = facade.GetCategoryService().Get(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")]Category category)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = facade.GetCategoryService().Update(category);
                if (response.StatusCode == HttpStatusCode.OK)
                    return RedirectToAction("Index");
                else
                    return new HttpStatusCodeResult(response.StatusCode);
            }
            return View(category);

        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = facade.GetCategoryService().Get(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Name,Description")]Category category)
        {
            HttpResponseMessage response = facade.GetCategoryService().Delete(category);
            if (response.StatusCode == HttpStatusCode.NoContent)
                return RedirectToAction("Index");
            else
                return new HttpStatusCodeResult(response.StatusCode);
        }
    }
}