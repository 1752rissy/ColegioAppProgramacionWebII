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
    public class CURSOController : Controller
    {
        private ColegioEntities db = new ColegioEntities();

        // GET: CURSO
        public ActionResult Index()
        {
            return View(db.CURSO.ToList());
        }

        // GET: CURSO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CURSO cURSO = db.CURSO.Find(id);
            if (cURSO == null)
            {
                return HttpNotFound();
            }
            return View(cURSO);
        }

        // GET: CURSO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CURSO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoCurso,NombreCurso")] CURSO cURSO)
        {
            if (ModelState.IsValid)
            {
                db.CURSO.Add(cURSO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cURSO);
        }

        // GET: CURSO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CURSO cURSO = db.CURSO.Find(id);
            if (cURSO == null)
            {
                return HttpNotFound();
            }
            return View(cURSO);
        }

        // POST: CURSO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoCurso,NombreCurso")] CURSO Curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Curso);
        }

        // GET: CURSO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CURSO cURSO = db.CURSO.Find(id);
            if (cURSO == null)
            {
                return HttpNotFound();
            }
            return View(cURSO);
        }

        // POST: CURSO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CURSO cURSO = db.CURSO.Find(id);
            db.CURSO.Remove(cURSO);
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
