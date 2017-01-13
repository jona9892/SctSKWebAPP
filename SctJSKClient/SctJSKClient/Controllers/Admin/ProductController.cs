using DTOModel;
using GatewayService;
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
        public ActionResult Create(ProductViewModel productvm)
        {
            ModelState.Remove("Product.Category.Name");
            ModelState.Remove("Product.Category.Description");
            if (ModelState.IsValid)
            {
                productvm.Product.Category = facade.GetCategoryService().Get(productvm.Product.Category.Id);

                HttpResponseMessage response = facade.GetProductService().Add(productvm.Product);
                if (response.StatusCode == HttpStatusCode.Created)
                    return Redirect("Index");
                else
                    return new HttpStatusCodeResult(response.StatusCode);
            }
            productvm.Categories = facade.GetCategoryService().GetAll().ToList();
            return View(productvm);
        }

        // GET: Aftale/Edit/5
        public ActionResult Edit(int id)
        {
            var product = facade.GetProductService().Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductViewModel pvm = new ProductViewModel()
            {
                Product = product,
                Categories = facade.GetCategoryService().GetAll().ToList()
            };
            return View(pvm);
        }

        // POST: Aftale/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel productvm)
        {
            ModelState.Remove("Product.Category.Name");
            ModelState.Remove("Product.Category.Description");
            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                productvm.Product.Category = facade.GetCategoryService().Get(productvm.Product.Category.Id);
                HttpResponseMessage response = facade.GetProductService().Update(productvm.Product);
                if (response.StatusCode == HttpStatusCode.OK)
                    return RedirectToAction("Index");
                else
                    return new HttpStatusCodeResult(response.StatusCode);
            }
            return View(productvm);

        }

        // GET: Aftale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var product = facade.GetProductService().Get(id.Value);
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

            // TODO: Add delete logic here
            HttpResponseMessage response = facade.GetProductService().Delete(product);
            if (response.StatusCode == HttpStatusCode.NoContent)
                return RedirectToAction("Index");
            else
                return new HttpStatusCodeResult(response.StatusCode);

        }
    }
}