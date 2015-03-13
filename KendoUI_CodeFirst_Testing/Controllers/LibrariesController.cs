using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KendoUI_CodeFirst_Testing.Context;
using KendoUI_CodeFirst_Testing.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace KendoUI_CodeFirst_Testing.Controllers
{
    public class LibrariesController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/Libraries
        public DataSourceResult GetLibraries([System.Web.Http.ModelBinding.ModelBinder
            (typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            return db.Libraries.ToDataSourceResult(request);
        }

        // GET: api/Libraries/5
        [ResponseType(typeof(Library))]
        public IHttpActionResult GetLibrary(int id)
        {
            Library library = db.Libraries.Find(id);
            if (library == null)
            {
                return NotFound();
            }

            return Ok(library);
        }

        // PUT: api/Libraries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLibrary(int id, Library library)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != library.LibraryId)
            {
                return BadRequest();
            }

            db.Entry(library).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Libraries
        [ResponseType(typeof(Library))]
        public HttpResponseMessage PostLibrary(Library library)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            } else {
                db.Libraries.Add(library);
                db.SaveChanges();

                DataSourceResult result = new DataSourceResult {
                    Data = new[] { library },
                    Total = 1
                };
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, result);
                //response.Headers.Location = new Uri("DefaultApi",
                //    new {
                //        id = library.LibraryId
                //    });
                return response;
            }
        }

        // DELETE: api/Libraries/5
        [ResponseType(typeof(Library))]
        public IHttpActionResult DeleteLibrary(int id)
        {
            Library library = db.Libraries.Find(id);
            if (library == null)
            {
                return NotFound();
            }

            db.Libraries.Remove(library);
            db.SaveChanges();

            return Ok(library);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LibraryExists(int id)
        {
            return db.Libraries.Count(e => e.LibraryId == id) > 0;
        }

        public IHttpActionResult Iresponse { get; set; }
    }
}