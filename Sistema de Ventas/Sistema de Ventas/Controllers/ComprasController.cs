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
    public class ComprasController : Controller
    {
        private SistemaVentasEntities db = new SistemaVentasEntities();

        // GET: Compras
        public ActionResult Index()
        {
            var tbCompras = db.tbCompras.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbProveedores);
            return View(tbCompras.ToList());    
        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCompras tbCompras = db.tbCompras.Find(id);
            if (tbCompras == null)
            {
                return HttpNotFound();
            }
            return View(tbCompras);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            ViewBag.compraUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            ViewBag.compraUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            ViewBag.proveedorId = new SelectList(db.tbProveedores, "proveedorId", "proveedorNombre");
            return View();
        }

        // POST: Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
    
        public ActionResult Create([Bind(Include = "compraId,proveedorId,compraFecha,compraFechaCreacion,compraUsuarioCreacion,compraFechaModificacion,compraUsuarioModificacion,compraEstado")] tbCompras tbCompras)
        {
            ModelState.Remove("compraId");
            ModelState.Remove("compraFecha");
            ModelState.Remove("compraFechaCreacion");
            ModelState.Remove("compraUsuarioCreacion"); //Esta linea la tenes que reemplazar por el usuaio logeado desde el login jajaj
            ModelState.Remove("compraUsuarioModificacion");
            ModelState.Remove("compraEstado");
            if (ModelState.IsValid)
            {
                try
                {
                    string empleadoId = Session["EmpleadoID"].ToString();
                    db.UDP_ComprasInsert(tbCompras.proveedorId, int.Parse(empleadoId));
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                }
                return RedirectToAction("Index");
            }

            ViewBag.compraUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCompras.compraUsuarioCreacion);
            ViewBag.compraUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCompras.compraUsuarioModificacion);
            ViewBag.proveedorId = new SelectList(db.tbProveedores, "proveedorId", "proveedorNombre", tbCompras.proveedorId);
            return View(tbCompras);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCompras tbCompras = db.tbCompras.Find(id);
            if (tbCompras == null)
            {
                return HttpNotFound();
            }
            ViewBag.compraUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCompras.compraUsuarioCreacion);
            ViewBag.compraUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCompras.compraUsuarioModificacion);
            ViewBag.proveedorId = new SelectList(db.tbProveedores, "proveedorId", "proveedorNombre", tbCompras.proveedorId);
            return View(tbCompras);
        }

        // POST: Compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "compraId,proveedorId,compraFecha,compraFechaCreacion,compraUsuarioCreacion,compraFechaModificacion,compraUsuarioModificacion,compraEstado")] tbCompras tbCompras)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tbCompras).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                }
            
                return RedirectToAction("Index");
            }
            ViewBag.compraUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCompras.compraUsuarioCreacion);
            ViewBag.compraUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCompras.compraUsuarioModificacion);
            ViewBag.proveedorId = new SelectList(db.tbProveedores, "proveedorId", "proveedorNombre", tbCompras.proveedorId);
            return View(tbCompras);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCompras tbCompras = db.tbCompras.Find(id);
            if (tbCompras == null)
            {
                return HttpNotFound();
            }
            return View(tbCompras);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbCompras tbCompras = db.tbCompras.Find(id);
                db.tbCompras.Remove(tbCompras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public JsonResult Agregar(string productoId, string cantidad)
        {

            try
            {
                if (!String.IsNullOrEmpty(cantidad) && cantidad != "0")
                {
                    db.UDP_InsertarCompraDetalles(productoId, cantidad, "1");
                    var cadena = db.UDP_DetalleEnTablaCompra().ToList();
                    return Json(cadena, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("<tr><td>Ingrese</td><td>Valores</td><td>Correctos</td></tr>", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

            }
            return Json("<tr><td>Ingrese</td><td>Valores</td><td>Correctos</td></tr>", JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult DetallesCompra(int compraId)
        {
            var cadena = db.UDP_DetalleEnTablaCompraxId(compraId).ToList();
            return Json(cadena, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteCompraDetalle(int id)
        {
            try
            {
                db.UDP_EliminarCompraDetalle(id);
                return RedirectToAction("Edit");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Edit");
        }
    }
}
