using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webSiteInicial.Models;

namespace webSiteInicial.Controllers
{
    public class BandasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bandas
        public ActionResult Index()
        {
            return View(db.Bandas.ToList());
        }

        // GET: Bandas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banda banda = db.Bandas.Find(id);
            if (banda == null)
            {
                return HttpNotFound();
            }
            return View(banda);
        }

        // GET: Bandas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bandas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBanda,NomeBanda")] Banda banda)
        {
            if (ModelState.IsValid)
            {
                db.Bandas.Add(banda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banda);
        }

        // GET: Bandas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banda banda = db.Bandas.Find(id);
            if (banda == null)
            {
                return HttpNotFound();
            }
            return View(banda);
        }

        // POST: Bandas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBanda,NomeBanda")] Banda banda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banda);
        }

        // GET: Bandas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banda banda = db.Bandas.Find(id);
            if (banda == null)
            {
                return HttpNotFound();
            }
            return View(banda);
        }

        // POST: Bandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banda banda = db.Bandas.Find(id);
            db.Bandas.Remove(banda);
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
