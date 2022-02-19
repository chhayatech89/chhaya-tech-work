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
    public class TechController : Controller
    {
        private techregisEntities db = new techregisEntities();

        // GET: Tech
        public ActionResult Index()
        {
            return View(db.regs.ToList());
        }

        // GET: Tech/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reg reg = db.regs.Find(id);
            if (reg == null)
            {
                return HttpNotFound();
            }
            return View(reg);
        }

        // GET: Tech/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tech/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mobileno,emailid,name")] reg reg)
        {
            if (ModelState.IsValid)
            {
                db.regs.Add(reg);
                db.SaveChanges();
                return RedirectToAction("About", "Home");
            }

            return View(reg);
        }

        // GET: Tech/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reg reg = db.regs.Find(id);
            if (reg == null)
            {
                return HttpNotFound();
            }
            return View(reg);
        }

        // POST: Tech/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mobileno,emailid,name")] reg reg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reg);
        }

        // GET: Tech/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reg reg = db.regs.Find(id);
            if (reg == null)
            {
                return HttpNotFound();
            }
            return View(reg);
        }

        // POST: Tech/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            reg reg = db.regs.Find(id);
            db.regs.Remove(reg);
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
