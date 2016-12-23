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
        public ActionResult Create([Bind(Include = "Id,Name,Description")]Category category)
        {
            if (ModelState.IsValid)
            {
                facade.GetCategoryService().Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Category/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category category = facade.GetCategoryService().Get(id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")]Category category)
        {

            facade.GetCategoryService().Update(category);
            return RedirectToAction("Index");

        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = facade.GetCategoryService().Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Category category)
        {
            facade.GetCategoryService().Delete(category);
            return RedirectToAction("Index");
        }
    }
}