using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chhayatech.Models;

namespace Chhayatech.Controllers
{
    public class CourselistsController : Controller
    {
        private techregisEntities db = new techregisEntities();

        // GET: Courselists
        public ActionResult Index()
        {
            return View(db.clists.ToList());
        }

        public ActionResult Fcon()
        {
            return View(db.clists.ToList());
        }


        // GET: Courselists/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clist clist = db.clists.Find(id);
            if (clist == null)
            {
                return HttpNotFound();
            }
            return View(clist);
        }

        // GET: Courselists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courselists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cid,cname,cduration,cfee")] clist clist)
        {
            if (ModelState.IsValid)
            {
                db.clists.Add(clist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clist);
        }

        // GET: Courselists/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clist clist = db.clists.Find(id);
            if (clist == null)
            {
                return HttpNotFound();
            }
            return View(clist);
        }

        // POST: Courselists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cid,cname,cduration,cfee")] clist clist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clist);
        }

        // GET: Courselists/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clist clist = db.clists.Find(id);
            if (clist == null)
            {
                return HttpNotFound();
            }
            return View(clist);
        }

        // POST: Courselists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            clist clist = db.clists.Find(id);
            db.clists.Remove(clist);
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
