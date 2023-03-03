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
    public class ProductosController : Controller
    {
        private SistemaVentasEntities db = new SistemaVentasEntities();

        // GET: Productos
        public ActionResult Index()
        {
            var tbProductos = db.tbProductos.Include(t => t.tbCategoria).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbProveedores);
            return View(tbProductos.ToList().Where(X => X.productoEstado == true));
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProductos tbProductos = db.tbProductos.Find(id);
            if (tbProductos == null)
            {
                return HttpNotFound();
            }
            return View(tbProductos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.categoriaId = new SelectList(db.tbCategoria, "categoriaId", "categoriaDescripcion");
            ViewBag.productoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            ViewBag.productoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            ViewBag.proveedorid = new SelectList(db.tbProveedores, "proveedorId", "proveedorNombre");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productoId,productoNombre,productoPrecio,categoriaId,proveedorid,productoStock,productoFechaCreacion,productoUsuarioCreacion,productoFechaModificacion,productoUsuarioModificacion,productoEstado")] tbProductos tbProductos)
        {
            ModelState.Remove("productoId");
            ModelState.Remove("productoFechaCreacion");
            ModelState.Remove("productoFechaModificacion");
            ModelState.Remove("productoUsuarioModificacion");
            ModelState.Remove("productoEstado");
            if (ModelState.IsValid)
            {
                try
                {
                    db.UDP_InsertarProductos(tbProductos.productoNombre, tbProductos.productoPrecio, tbProductos.categoriaId, tbProductos.proveedorid, tbProductos.productoStock, tbProductos.productoUsuarioCreacion);

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                }
                return RedirectToAction("Index");
            }

            ViewBag.categoriaId = new SelectList(db.tbCategoria, "categoriaId", "categoriaDescripcion", tbProductos.categoriaId);
            ViewBag.productoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbProductos.productoUsuarioCreacion);
            ViewBag.productoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbProductos.productoUsuarioModificacion);
            ViewBag.proveedorid = new SelectList(db.tbProveedores, "proveedorId", "proveedorNombre", tbProductos.proveedorid);
            return View(tbProductos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProductos tbProductos = db.tbProductos.Find(id);
            if (tbProductos == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoriaId = new SelectList(db.tbCategoria, "categoriaId", "categoriaDescripcion", tbProductos.categoriaId);
            ViewBag.productoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbProductos.productoUsuarioCreacion);
            ViewBag.productoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbProductos.productoUsuarioModificacion);
            ViewBag.proveedorid = new SelectList(db.tbProveedores, "proveedorId", "proveedorNombre", tbProductos.proveedorid);
            return View(tbProductos);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productoId,productoNombre,productoPrecio,categoriaId,proveedorid,productoStock,productoFechaCreacion,productoUsuarioCreacion,productoFechaModificacion,productoUsuarioModificacion,productoEstado")] tbProductos tbProductos)
        {
            ModelState.Remove("productoUsuarioCreacion");
            ModelState.Remove("productoFechaCreacion");
            ModelState.Remove("productoEstado");
            if (ModelState.IsValid)
            {
                try
                {
                    db.UDP_EditarProducto(tbProductos.productoId, tbProductos.productoNombre, tbProductos.productoPrecio, tbProductos.categoriaId, tbProductos.proveedorid, tbProductos.productoStock, tbProductos.productoUsuarioModificacion);
                    return RedirectToAction("Index");
                }
                catch(Exception)
                {

                }
                
                return RedirectToAction("Index");
            }
            ViewBag.categoriaId = new SelectList(db.tbCategoria, "categoriaId", "categoriaDescripcion", tbProductos.categoriaId);
            ViewBag.productoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbProductos.productoUsuarioCreacion);
            ViewBag.productoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbProductos.productoUsuarioModificacion);
            ViewBag.proveedorid = new SelectList(db.tbProveedores, "proveedorId", "proveedorNombre", tbProductos.proveedorid);
            return View(tbProductos);
        }

        // GET: Productos/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbProductos tbProductos = db.tbProductos.Find(id);
        //    if (tbProductos == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbProductos);
        //}

        //// POST: Productos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tbProductos tbProductos = db.tbProductos.Find(id);
        //    //db.tbProductos.Remove(tbProductos);
        //    //db.SaveChanges()
        //    db.UDP_EliminarProducto(tbProductos.productoId);
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(int id)
        {
            try
            {
                db.UDP_EliminarProducto(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
            }
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
