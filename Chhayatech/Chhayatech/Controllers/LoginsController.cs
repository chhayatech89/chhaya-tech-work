using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Chhayatech.Models;

namespace Chhayatech.Controllers
{
    public class LoginsController : Controller
    {
        private techregisEntities db = new techregisEntities();

        // GET: Logins
        public ActionResult Index()
        {
            return View(db.ulogins.ToList());
        }

        // GET: Logins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ulogin ulogin = db.ulogins.Find(id);
            if (ulogin == null)
            {
                return HttpNotFound();
            }
            return View(ulogin);
        }




        // GET: Logins/Create
        /* 
                public ActionResult Create()
                {
                    return View();
                }

                // POST: Logins/Create
                // To protect from overposting attacks, enable the specific properties you want to bind to, for 
                // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Create([Bind(Include = "Uid,Uname,Upass,Urole")] ulogin ulogin)
                {
                    if (ModelState.IsValid)
                    {
                        db.ulogins.Add(ulogin);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(ulogin);
                }


        */


        public ActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Uid,Uname,Upass,Urole")] ulogin ulogin)
        {
            if (ModelState.IsValid)
            {

                using (techregisEntities db = new techregisEntities())
                {

//                    bool obj = db.ulogins.Where(a => a.Uname.Equals(ulogin.Uname) && a.Upass.Equals(ulogin.Upass));


                    bool obj = db.ulogins.Any(a => a.Uname.Equals(ulogin.Uname) && a.Upass.Equals(ulogin.Upass));


                    if (obj)
                    {
                        FormsAuthentication.SetAuthCookie(ulogin.Uname, false);
                        return RedirectToAction("Fcon", "Courselists");

                    }

                    else
                    {
                        return RedirectToAction("Index", "Home");

                    }


/*

                    if (obj != null)
                    {

                        Session["Uid"] = obj.Uname.ToString();
                        Session["Upass"] = obj.Upass.ToString();
                        Session["Urole"] = obj.Urole.ToString();

                        if (Session["Urole"].ToString() == "admin")
                        {

                            return RedirectToAction("Fcon", "Courselists");

                        }

                        else
                        {
                            return RedirectToAction("Index", "Home");

                        }
                            
                        }
*/

                    
                    }
                }
            return View(ulogin);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Create", "Logins");
        }


        // GET: Logins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ulogin ulogin = db.ulogins.Find(id);
            if (ulogin == null)
            {
                return HttpNotFound();
            }
            return View(ulogin);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Uid,Uname,Upass,Urole")] ulogin ulogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ulogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ulogin);
        }

        // GET: Logins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ulogin ulogin = db.ulogins.Find(id);
            if (ulogin == null)
            {
                return HttpNotFound();
            }
            return View(ulogin);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ulogin ulogin = db.ulogins.Find(id);
            db.ulogins.Remove(ulogin);
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
