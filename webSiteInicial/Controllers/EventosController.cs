using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webSiteInicial.Models;

namespace webSiteInicial.Controllers
{
    public class EventosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Eventos
        public ActionResult Index()
        {
            return View(db.Eventoes.ToList());
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            ViewBag.BandaPrincipal = new SelectList(db.Bandas, "idBanda", "NomeBanda");
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nome,Descricao,Data,DobroDe,Dia,LinkFacebook,Ambiente,BandaPrincipal,BandaPrincipalID,BandaAbertura,BandaAberturaID")] Evento evento)
        {

            Banda bandap = db.Bandas.Find(evento.BandaPrincipal.idBanda);
            if (bandap == null)
                return HttpNotFound();
            else
            {
                var entityType = ObjectContext.GetObjectType(bandap.GetType());
                if (entityType.BaseType != null && entityType.Namespace == "System.Data.Entity.DynamicProxies")
                {
                    entityType = entityType.BaseType;
                }
                evento.BandaPrincipal = (Banda)bandap;
                evento.BandaPrincipalID = bandap.idBanda;
            }
            Banda bandasec = db.Bandas.Find(evento.BandaAbertura.idBanda);
            if (bandap == null)
                return HttpNotFound();
            else
            {
                var entityType = ObjectContext.GetObjectType(bandasec.GetType());
                if (entityType.BaseType != null && entityType.Namespace == "System.Data.Entity.DynamicProxies")
                {
                    entityType = entityType.BaseType;
                }
                evento.BandaAbertura = (Banda)bandasec;
                evento.BandaPrincipalID = bandasec.idBanda;
            }
            if (ModelState.IsValid)
            {
                db.Eventoes.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evento);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }

            ViewBag.BandaAbertura = new SelectList(db.Bandas, "idBanda", "NomeBanda", evento.BandaAbertura.idBanda);
            ViewBag.BandaPrincipal = new SelectList(db.Bandas, "idBanda", "NomeBanda", evento.BandaPrincipal.idBanda);
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nome,Descricao,Data,DobroDe,Dia,LinkFacebook,Ambiente,BandaPrincipal,BandaAbertura,BandaPrincipalID,BandaAberturaID")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                Banda bandap = db.Bandas.Find(evento.BandaPrincipal.idBanda);
                if (bandap == null)
                    return HttpNotFound();
                else
                {
                    evento.BandaPrincipal = bandap;
                    evento.BandaPrincipalID = bandap.idBanda;
                }
                Banda bandasec = db.Bandas.Find(evento.BandaAbertura.idBanda);
                if (bandasec == null)
                    return HttpNotFound();
                else
                {
                    evento.BandaAbertura = bandasec;
                    evento.BandaAberturaID = bandasec.idBanda;
                }

                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Eventoes.Find(id);
            db.Eventoes.Remove(evento);
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
