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
    [CustomAuthorize(Roles = "Admin,HeadMaster")]
    public class ArrangementController : Controller
    {
        Facade facade = new Facade();
        // GET: Arrangement
        public ActionResult Index()
        {
            var arrangements = facade.GetArrangementService().GetAll();
            return View(arrangements);
        }

        public ActionResult GetEvents()
        {
            //Get the events
            var eventList = facade.GetArrangementService().GetEvents();

            //return the events in json
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            ArrangementViewModel avm = new ArrangementViewModel()
            {
                Products = facade.GetProductService().GetAll().ToList(),
                Categrories = facade.GetCategoryService().GetAll().ToList()

            };
            return View(avm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArrangementViewModel avm)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = facade.GetArrangementService().Add(avm.Arrangement);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    Arrangement arrangement = response.Content.ReadAsAsync<Arrangement>().Result;
                    foreach (var ap in avm.selected)
                    {
                        ArrangementProduct arp = new ArrangementProduct();
                        arp.ProductId = int.Parse(ap);
                        arp.ArrangementId = arrangement.Id;
                        arp.Quantity = 30;

                        facade.GetArrangementProductService().create(arp);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(response.StatusCode);
                }

            }
            return View();
        }

        // GET: Aftale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var arrangement = facade.GetArrangementService().Get(id.Value);
            if (arrangement == null)
            {
                return HttpNotFound();
            }
            return View(arrangement);
        }

        // POST: Aftale/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Arrangement arrangement)
        {

            // TODO: Add delete logic here
            HttpResponseMessage response = facade.GetArrangementService().Delete(arrangement);
            if (response.StatusCode == HttpStatusCode.NoContent)
                return RedirectToAction("Index");
            else
                return new HttpStatusCodeResult(response.StatusCode);

        }


        public ActionResult ViewArrangementDetails(int id)
        {
            ArrangementProductViewModel apvm = new ArrangementProductViewModel();
            apvm.Arrangement = facade.GetArrangementService().Get(id);
            if (apvm.Arrangement == null)
            {
                return HttpNotFound();
            }
            foreach (var item in apvm.Arrangement.Products)
            {
                ArrangementProduct arrangementProduct = new ArrangementProduct();
                arrangementProduct.Quantity = item.Quantity;
                arrangementProduct.Arrangement = apvm.Arrangement;
                arrangementProduct.Product = facade.GetProductService().Get(item.ProductId);

                apvm.ArrangementProducts.Add(arrangementProduct);
            }
            return View(apvm);
        }

    }
}