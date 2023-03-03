using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_de_Ventas.Models;

namespace Sistema_de_Ventas.Controllers
{
    public class EstadosCivilesController : Controller
    {
        private SistemaVentasEntities db = new SistemaVentasEntities();

        // GET: EstadosCiviles
        public ActionResult Index()
        {
            var tbEstadosCiviles = db.tbEstadosCiviles.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbEstadosCiviles.ToList().Where(X => X.estadoCivilEstado == true));
        }

        // GET: EstadosCiviles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstadosCiviles tbEstadosCiviles = db.tbEstadosCiviles.Find(id);
            if (tbEstadosCiviles == null)
            {
                return HttpNotFound();
            }
            return View(tbEstadosCiviles);
        }

        // GET: EstadosCiviles/Create
        public ActionResult Create()
        {
            ViewBag.estadoCivilUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            ViewBag.estadoCivilUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            return View();
        }

        // POST: EstadosCiviles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "estadoCivilId,estadoCivilNombre,estadoCivilFechaCreacion,estadoCivilUsuarioCreacion,estadoCivilFechaModificacion,estadoCivilUsuarioModificacion,estadoCivilEstado")] tbEstadosCiviles tbEstadosCiviles)
        {
            ModelState.Remove("estadoCivilFechaCreacion");
            ModelState.Remove("estadoCivilFechaModificacion");
            ModelState.Remove("estadoCivilUsuarioModificacion");
            ModelState.Remove("estadoCivilEstado");
            if (ModelState.IsValid)
            {
                try
                {
                    db.tbEstadosCiviles.Add(tbEstadosCiviles);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                }
                return RedirectToAction("Index");
            }

            ViewBag.estadoCivilUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbEstadosCiviles.estadoCivilUsuarioModificacion);
            ViewBag.estadoCivilUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbEstadosCiviles.estadoCivilUsuarioCreacion);
            return View(tbEstadosCiviles);
        }

        // GET: EstadosCiviles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstadosCiviles tbEstadosCiviles = db.tbEstadosCiviles.Find(id);
            if (tbEstadosCiviles == null)
            {
                return HttpNotFound();
            }
            ViewBag.estadoCivilUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbEstadosCiviles.estadoCivilUsuarioModificacion);
            ViewBag.estadoCivilUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbEstadosCiviles.estadoCivilUsuarioCreacion);
            return View(tbEstadosCiviles);
        }

        // POST: EstadosCiviles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "estadoCivilId,estadoCivilNombre,estadoCivilFechaCreacion,estadoCivilUsuarioCreacion,estadoCivilFechaModificacion,estadoCivilUsuarioModificacion,estadoCivilEstado")] tbEstadosCiviles tbEstadosCiviles)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tbEstadosCiviles).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    throw;
                }
            
                return RedirectToAction("Index");
            }
            ViewBag.estadoCivilUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbEstadosCiviles.estadoCivilUsuarioModificacion);
            ViewBag.estadoCivilUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbEstadosCiviles.estadoCivilUsuarioCreacion);
            return View(tbEstadosCiviles);
        }

        // GET: EstadosCiviles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstadosCiviles tbEstadosCiviles = db.tbEstadosCiviles.Find(id);
            if (tbEstadosCiviles == null)
            {
                return HttpNotFound();
            }
            return View(tbEstadosCiviles);
        }

        // POST: EstadosCiviles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbEstadosCiviles tbEstadosCiviles = db.tbEstadosCiviles.Find(id);
            db.tbEstadosCiviles.Remove(tbEstadosCiviles);
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
