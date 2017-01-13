using Sct.JSKDAL;
using Sct.JSKDAL.Context;
using Sct.JSKDAL.Entities;
using Sct.JSKDAL.Repository.Absttraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Sct.JSKApi.Controllers
{
    public class ProductController : ApiController
    {
        private IProductRepository pr;
        public ProductController()
        {
            pr = new Facade(new DBContextSctJSK()).GetProductRepository();
        }

        // GET: api/Product
        /// <summary>
        /// this returns an IEnumerable, which contains all products.
        /// </summary>
        /// <returns>an IEnumerable with products</returns>
        /// 
        public IEnumerable<Product> GetProducts()
        {
            var products = pr.ReadAll();
            //var response = Request.CreateResponse(HttpStatusCode.OK, products);
            return products;

        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            var product = pr.Read(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

            /*if (product != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, product);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }*/

        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product p)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = pr.Add(p);
            return Content(HttpStatusCode.Created, product);
        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult PutProduct(int id, Product p)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = pr.Update(p);
            if (product == null)
            {                
                return InternalServerError();
            }
            return Ok(product);

            /*if (product != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created, product);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }*/

        }

        public void DeleteProduct(int id)
        {
            var product = pr.Read(id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            pr.Delete(product);
        }


        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            var products = pr.GetProductsByCategory(category);

            //var response = Request.CreateResponse(HttpStatusCode.OK, product);
            return products;
        }
    }
}
