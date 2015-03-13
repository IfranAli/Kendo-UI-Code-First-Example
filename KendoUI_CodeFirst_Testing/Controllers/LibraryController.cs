using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KendoUI_CodeFirst_Testing.Models;
using KendoUI_CodeFirst_Testing.Context;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;


namespace KendoUI_CodeFirst_Testing.Controllers
{
    public class LibraryController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // Get: /TestDataPopulate
        public ActionResult TestDataPopulate() {
            String[,] dataArray = new String[,] {
            {"Alexandria Library", "USA"},
            {"Alice Springs public library", "Australia"},
            {"American Memorial Library", "USA"},
            {"Australian National Library", "Australia"},
            {"Bayerische Library","Germany"},
            {"Berlin Art Library", "Germany"}
            };

            for (int i = 0; i < dataArray.Length /2; i++) {
                db.Libraries.Add(new Library {
                    Name = dataArray[i, 0],
                    Location = dataArray[i, 1]
                });
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: /Library/
        public ActionResult Index()
        {
            return View(db.Libraries.ToList());
        }

        // GET: /Library/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = db.Libraries.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // GET: /Library/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Library/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="LibraryId,Name")] Library library)
        {
            if (ModelState.IsValid)
            {
                db.Libraries.Add(library);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(library);
        }

        // GET: /Library/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = db.Libraries.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: /Library/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="LibraryId,Name")] Library library)
        {
            if (ModelState.IsValid)
            {
                db.Entry(library).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(library);
        }

        // GET: /Library/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = db.Libraries.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: /Library/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Library library = db.Libraries.Find(id);
            db.Libraries.Remove(library);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
