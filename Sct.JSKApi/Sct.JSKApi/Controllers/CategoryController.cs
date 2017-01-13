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
    public class CategoryController : ApiController
    {
        private IRepository<Category> cr;

        public CategoryController()
        {
            cr = new Facade(new DBContextSctJSK()).GetCategoryRepository();
        }

        // GET: api/Category
        /// <summary>
        /// this returns an IEnumerable, which contains all Categories.
        /// </summary>
        /// <returns>an IEnumerable with Categories</returns>
        public IEnumerable<Category> GetCategories()
        {
            var category = cr.ReadAll();
            //var response = Request.CreateResponse(HttpStatusCode.OK, category);
            return category;
        }

        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            var category = cr.Read(id);
            /*
            if (category != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, category);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }*/            
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);

        }

        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category c)
        {            
            /*
            if (category != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created, category);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }*/

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = cr.Add(c);
            return Content(HttpStatusCode.Created, category);
            //return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        [ResponseType(typeof(Category))]
        public IHttpActionResult PutCategory(int id, Category c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = cr.Update(c);
            if(category == null)
            {
                return InternalServerError();
            }
            return Ok(category);

            /*
            var category = facade.GetCategoryRepository().Update(c);

            if (category != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created, category);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }*/

            /*
            if (c == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            c.Id = id;
            facade.GetCategoryRepository().Update(c);*/
        }


        public void DeleteCategory(int id)
        {
            var category = cr.Read(id);
            if (category == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            cr.Delete(category);
        }
    }
}
