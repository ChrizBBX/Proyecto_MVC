using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sistema_de_Ventas.Models
{
    public class ventaDetallesController : Controller
    {
        private SistemaVentasEntities db = new SistemaVentasEntities();

        // GET: ventaDetalles
        public ActionResult Index()
        {
            var tbventaDetalles = db.tbventaDetalles.Include(t => t.tbProductos).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbventa);
            return View(tbventaDetalles.ToList());
        }

        // GET: ventaDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbventaDetalles tbventaDetalles = db.tbventaDetalles.Find(id);
            if (tbventaDetalles == null)
            {
                return HttpNotFound();
            }
            return View(tbventaDetalles);
        }

        // GET: ventaDetalles/Create
        public ActionResult Create()
        {
            ViewBag.productoId = new SelectList(db.tbProductos, "productoId", "productoNombre");
            ViewBag.ventaDetalle_UsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            ViewBag.ventaDetalle_UsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            ViewBag.ventaId = new SelectList(db.tbventa, "ventaId", "metodopagoId");
            return View();
        }

        // POST: ventaDetalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ventaDetalle_Id,ventaId,productoId,ventaDetalle_catidad,ventaDetalle_Precio,ventaDetalle_FechaCreacion,ventaDetalle_UsuarioCreacion,ventaDetalle_FechaModificacion,ventaDetalle_UsuarioModificacion,ventaDetalle_Estado")] tbventaDetalles tbventaDetalles)
        {
            if (ModelState.IsValid)
            {
                db.tbventaDetalles.Add(tbventaDetalles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productoId = new SelectList(db.tbProductos, "productoId", "productoNombre", tbventaDetalles.productoId);
            ViewBag.ventaDetalle_UsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbventaDetalles.ventaDetalle_UsuarioCreacion);
            ViewBag.ventaDetalle_UsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbventaDetalles.ventaDetalle_UsuarioModificacion);
            ViewBag.ventaId = new SelectList(db.tbventa, "ventaId", "metodopagoId", tbventaDetalles.ventaId);
            return View(tbventaDetalles);
        }

        // GET: ventaDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbventaDetalles tbventaDetalles = db.tbventaDetalles.Find(id);
            if (tbventaDetalles == null)
            {
                return HttpNotFound();
            }
            ViewBag.productoId = new SelectList(db.tbProductos, "productoId", "productoNombre", tbventaDetalles.productoId);
            ViewBag.ventaDetalle_UsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbventaDetalles.ventaDetalle_UsuarioCreacion);
            ViewBag.ventaDetalle_UsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbventaDetalles.ventaDetalle_UsuarioModificacion);
            ViewBag.ventaId = new SelectList(db.tbventa, "ventaId", "metodopagoId", tbventaDetalles.ventaId);
            return View(tbventaDetalles);
        }

        // POST: ventaDetalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ventaDetalle_Id,ventaId,productoId,ventaDetalle_catidad,ventaDetalle_Precio,ventaDetalle_FechaCreacion,ventaDetalle_UsuarioCreacion,ventaDetalle_FechaModificacion,ventaDetalle_UsuarioModificacion,ventaDetalle_Estado")] tbventaDetalles tbventaDetalles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbventaDetalles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productoId = new SelectList(db.tbProductos, "productoId", "productoNombre", tbventaDetalles.productoId);
            ViewBag.ventaDetalle_UsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbventaDetalles.ventaDetalle_UsuarioCreacion);
            ViewBag.ventaDetalle_UsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbventaDetalles.ventaDetalle_UsuarioModificacion);
            ViewBag.ventaId = new SelectList(db.tbventa, "ventaId", "metodopagoId", tbventaDetalles.ventaId);
            return View(tbventaDetalles);
        }

        // GET: ventaDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbventaDetalles tbventaDetalles = db.tbventaDetalles.Find(id);
            if (tbventaDetalles == null)
            {
                return HttpNotFound();
            }
            return View(tbventaDetalles);
        }

        // POST: ventaDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbventaDetalles tbventaDetalles = db.tbventaDetalles.Find(id);
            db.tbventaDetalles.Remove(tbventaDetalles);
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
