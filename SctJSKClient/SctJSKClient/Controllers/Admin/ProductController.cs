using DTOModel;
using GatewayService;
using SctJSKClient.Security;
using SctJSKClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SctJSKClient.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly Facade facade = new Facade();
        // GET: Product
        public ActionResult Index(string sortOrder)
        {
            //Viewbag with sorting order
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";

            var products = facade.GetProductService().GetAll();

            switch (sortOrder)
            {
                case "title_desc":
                    products = products.OrderByDescending(s => s.Title);
                    break;
                case "Price":
                    products = products.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                case "Category":
                    products = products.OrderBy(s => s.Category.Name);
                    break;
                case "category_desc":
                    products = products.OrderByDescending(s => s.Category.Name);
                    break;
                default:
                    products = products.OrderBy(s => s.Title);
                    break;
            }
            return View(products);
        }

        // GET: Aftale/Create
        public ActionResult Create()
        {
            ProductViewModel pvm = new ProductViewModel()
            {
                Categories = facade.GetCategoryService().GetAll().ToList()
            };

            return View(pvm);
        }

        // POST: Aftale/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Category = facade.GetCategoryService().Get(product.Category.Id);

                facade.GetProductService().Add(product);
                return Redirect("Index");
            }
            return View();
        }

        // GET: Aftale/Edit/5
        public ActionResult Edit(int id)
        {

            ProductViewModel pvm = new ProductViewModel()
            {
                Product = facade.GetProductService().Get(id),
                Categories = facade.GetCategoryService().GetAll().ToList()
            };
            return View(pvm);
        }

        // POST: Aftale/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    product.Category = facade.GetCategoryService().Get(product.Category.Id);
                    facade.GetProductService().Update(product);

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
            var product = facade.GetProductService().Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Aftale/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            try
            {
                // TODO: Add delete logic here
                facade.GetProductService().Delete(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}