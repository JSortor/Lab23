using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab23.Models;

namespace Lab23.Controllers
{
    public class AwesomenessesController : Controller
    {
        private AwesomenessDBContext db = new AwesomenessDBContext();

        // GET: Awesomenesses
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Awesomenesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Awesomeness awesomeness = db.Users.Find(id);
            if (awesomeness == null)
            {
                return HttpNotFound();
            }
            return View(awesomeness);
        }

        // GET: Awesomenesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Awesomenesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Position,Average")] Awesomeness awesomeness)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(awesomeness);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(awesomeness);
        }

        // GET: Awesomenesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Awesomeness awesomeness = db.Users.Find(id);
            if (awesomeness == null)
            {
                return HttpNotFound();
            }
            return View(awesomeness);
        }

        // POST: Awesomenesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Position,Average")] Awesomeness awesomeness)
        {
            if (ModelState.IsValid)
            {
                db.Entry(awesomeness).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(awesomeness);
        }

        // GET: Awesomenesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Awesomeness awesomeness = db.Users.Find(id);
            if (awesomeness == null)
            {
                return HttpNotFound();
            }
            return View(awesomeness);
        }

        // POST: Awesomenesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Awesomeness awesomeness = db.Users.Find(id);
            db.Users.Remove(awesomeness);
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
