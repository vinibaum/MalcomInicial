using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using webSiteInicial.Models;

namespace webSiteInicial.Controllers
{
    public class ArtesEventosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArtesEventos
        public ActionResult Index()
        {
            var arteEventoes = db.ArteEventoes.Include(a => a.Evento);
            return View(arteEventoes.ToList());
        }

        // GET: ArtesEventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArteEvento arteEvento = db.ArteEventoes.Find(id);
            if (arteEvento == null)
            {
                return HttpNotFound();
            }
            return View(arteEvento);
        }

        // GET: ArtesEventos/Create
        public ActionResult Create()
        {
            ViewBag.EventoID = new SelectList(db.Eventoes, "id", "Nome");
            return View();
        }

        // POST: ArtesEventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Adm")]
        public ActionResult Create([Bind(Include = "ID,Descricao,isArtePrincipal,Ativa,DataExpira,CaminhoArquivo,Arquivo,Evento,EventoID")] ArteEvento arteEvento, HttpPostedFileBase arquivo)
        {
            Evento ev = db.Eventoes.Find(arteEvento.EventoID);
            if (ev == null)
                return HttpNotFound();
            else
            {
                arteEvento.Evento = ev;
            }
            arteEvento.CaminhoArquivo = arquivo.FileName;
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            // Thumbnails
            //if (productpicture.File.ContentLength > 0)
            //{
            //    ImageResizer.ImageJob i = new ImageResizer.ImageJob(productpicture.File,
            //        imagesDirectory + "/Thumbnails/<guid>.<ext>", new ImageResizer.ResizeSettings(
            //                                "width=250;height=250;format=jpg;mode=pad"));
            //    i.CreateParentDirectory = true; //Auto-create the uploads directory.
            //    i.Build();
            //    productpicture.Thumbnail = i.FinalPath.Split('\\').Last();
            //}

            var imagesDirectory = Server.MapPath(WebConfigurationManager.AppSettings["DiretorioArtesEventos"]);
            var fileName = Path.GetFileName(arquivo.FileName);
            var path = Path.Combine(imagesDirectory, fileName);

            if (ModelState.IsValid)
            {
                db.ArteEventoes.Add(arteEvento);
                db.SaveChanges();
                if (arquivo != null)
                {
                    if (arteEvento.CaminhoArquivo != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~/" + arteEvento.CaminhoArquivo)))
                        {
                            System.IO.File.Delete(Server.MapPath("~/" + arteEvento.CaminhoArquivo));
                        }
                    }
                    String[] strName = arquivo.FileName.Split('.');
                    string strExt = strName[strName.Count() - 1];
                    string pathSave = String.Format("{0}{1}.{2}", imagesDirectory, fileName+arteEvento.ID.ToString(), strExt);
                    string pathBase = String.Format("{0}{1}.{2}", WebConfigurationManager.AppSettings["DiretorioArtesEventos"], fileName + arteEvento.ID.ToString(), strExt); ;
                    arquivo.SaveAs(pathSave);
                    arteEvento.CaminhoArquivo = pathBase;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            //else
            //{
            //    throw new Exception(errors.FirstOrDefault().ErrorMessage);
            //}

            ViewBag.EventoID = new SelectList(db.Eventoes, "id", "Nome", arteEvento.EventoID);
            return View(arteEvento);
        }

        // GET: ArtesEventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArteEvento arteEvento = db.ArteEventoes.Find(id);
            if (arteEvento == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoID = new SelectList(db.Eventoes, "id", "Nome", arteEvento.EventoID);
            return View(arteEvento);
        }

        // POST: ArtesEventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descricao,isArtePrincipal,Ativa,DataExpira,CaminhoArquivo,EventoID")] ArteEvento arteEvento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arteEvento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoID = new SelectList(db.Eventoes, "id", "Nome", arteEvento.EventoID);
            return View(arteEvento);
        }

        // GET: ArtesEventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArteEvento arteEvento = db.ArteEventoes.Find(id);
            if (arteEvento == null)
            {
                return HttpNotFound();
            }
            return View(arteEvento);
        }

        // POST: ArtesEventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArteEvento arteEvento = db.ArteEventoes.Find(id);
            db.ArteEventoes.Remove(arteEvento);
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
