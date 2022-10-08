using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ColegioApp.Models;

namespace ColegioApp.Controllers
{
    public class ESTUDIANTEController : Controller
    {
        private ColegioEntities db = new ColegioEntities();

        // GET: ESTUDIANTE
        public ActionResult Index()
        {
            var eSTUDIANTE = db.ESTUDIANTE.Include(e => e.CURSO);
            return View(eSTUDIANTE.ToList());
        }

        // GET: ESTUDIANTE/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            if (eSTUDIANTE == null)
            {
                return HttpNotFound();
            }
            return View(eSTUDIANTE);
        }

        // GET: ESTUDIANTE/Create
        public ActionResult Create()
        {
            ViewBag.CodigoCurso = new SelectList(db.CURSO, "CodigoCurso", "NombreCurso");
            return View();
        }

        // POST: ESTUDIANTE/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dni,Nombre,Apellido,Telefono,CodigoCurso")] ESTUDIANTE eSTUDIANTE)
        {
            if (ModelState.IsValid)
            {
                db.ESTUDIANTE.Add(eSTUDIANTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoCurso = new SelectList(db.CURSO, "CodigoCurso", "NombreCurso", eSTUDIANTE.CodigoCurso);
            return View(eSTUDIANTE);
        }

        // GET: ESTUDIANTE/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            if (eSTUDIANTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoCurso = new SelectList(db.CURSO, "CodigoCurso", "NombreCurso", eSTUDIANTE.CodigoCurso);
            return View(eSTUDIANTE);
        }

        // POST: ESTUDIANTE/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dni,Nombre,Apellido,Telefono,CodigoCurso")] ESTUDIANTE eSTUDIANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTUDIANTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoCurso = new SelectList(db.CURSO, "CodigoCurso", "NombreCurso", eSTUDIANTE.CodigoCurso);
            return View(eSTUDIANTE);
        }

        // GET: ESTUDIANTE/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            if (eSTUDIANTE == null)
            {
                return HttpNotFound();
            }
            return View(eSTUDIANTE);
        }

        // POST: ESTUDIANTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            db.ESTUDIANTE.Remove(eSTUDIANTE);
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
