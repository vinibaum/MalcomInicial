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
    public class MusicosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Musicos
        public ActionResult Index()
        {
            return View(db.Musicoes.ToList());
        }

        // GET: Musicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musico musico = db.Musicoes.Find(id);
            if (musico == null)
            {
                return HttpNotFound();
            }
            return View(musico);
        }

        // GET: Musicos/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.BandaPrincipal = new SelectList(db.Bandas, "idBanda", "NomeBanda");
            return View();
        }

        // POST: Musicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMusico,NomeMusico,Toca,BandaPrincipal")] Musico musico)
        {
            if (ModelState.IsValid)
            {

                Banda bandap = db.Bandas.Find(musico.BandaPrincipal.idBanda);
                if (bandap == null)
                    return HttpNotFound();
                else
                {
                    musico.BandaPrincipal = bandap;
                    musico.BandaPrincipalID = bandap.idBanda;
                }

                db.Musicoes.Add(musico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musico);
        }

        // GET: Musicos/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musico musico = db.Musicoes.Find(id);
            if (musico == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.Integrantes = new SelectList(db.Bandas, "idBanda", "NomeBanda",musico.BandaPrincipal.idBanda);
            return View(musico);
        }

        // POST: Musicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMusico,NomeMusico,Toca,BandaPrincipal")] Musico musico)
        {
            if (ModelState.IsValid)
            {

                Banda bandap = db.Bandas.Find(musico.BandaPrincipal.idBanda);
                if (bandap == null)
                    return HttpNotFound();
                else
                {
                    musico.BandaPrincipal = bandap;
                    musico.BandaPrincipalID = bandap.idBanda;
                }
                db.Entry(musico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musico);
        }

        // GET: Musicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musico musico = db.Musicoes.Find(id);
            if (musico == null)
            {
                return HttpNotFound();
            }
            return View(musico);
        }

        // POST: Musicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musico musico = db.Musicoes.Find(id);
            db.Musicoes.Remove(musico);
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
