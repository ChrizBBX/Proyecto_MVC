using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_de_Ventas.Models;

namespace SistemadeVentasAPP.Controllers
{
    public class ProveedoresController : Controller
    {
        private SistemaVentasEntities db = new SistemaVentasEntities();

        // GET: Proveedores
        public ActionResult Index()
        {
            var tbProveedores = db.tbProveedores.Include(t => t.tbMunicipios).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Where(x => x.proveedorEstado == true);
            return View(tbProveedores.ToList());
        }

        // GET: Proveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProveedores tbProveedores = db.tbProveedores.Find(id);
            if (tbProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tbProveedores);
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {
            ViewBag.departamentoId = new SelectList(db.tbDepartamentos, "departamentoId", "departamentoNombre");
            ViewBag.municipioId = new SelectList(db.tbMunicipios, "municipioId", "departamentoId");
            ViewBag.proveedorUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            ViewBag.proveedorUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            return View();
        }

        // POST: Proveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "proveedorId,proveedorNombre,municipioId,proveedorDireccionExacta,proveedorTelefono,proveedorEmail,proveedorFechaCreacion,proveedorUsuarioCreacion,proveedorFechaModificacion,proveedorUsuarioModificacion,proveedorEstado")] tbProveedores tbProveedores)
        {
            ModelState.Remove("proveedorFechaCreacion");
            ModelState.Remove("proveedorUsuarioCreacion");
            ModelState.Remove("proveedorFechaModificacion");
            ModelState.Remove("proveedorUsuarioModificacion");
            ModelState.Remove("proveedorEstado");
            string idmun = tbProveedores.municipioId;
            if (ModelState.IsValid)
            {
                try
                {
                    db.UDP_InsertarProveedores(tbProveedores.proveedorNombre, tbProveedores.municipioId, tbProveedores.proveedorDireccionExacta, tbProveedores.proveedorTelefono, tbProveedores.proveedorEmail, 1);
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }
             
                //db.tbProveedores.Add(tbProveedores);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.municipioId = new SelectList(db.tbMunicipios, "municipioId", "departamentoId", tbProveedores.municipioId);
            ViewBag.proveedorUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbProveedores.proveedorUsuarioCreacion);
            ViewBag.proveedorUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbProveedores.proveedorUsuarioModificacion);
            return View(tbProveedores);
        }

        // GET: Proveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProveedores tbProveedores = db.tbProveedores.Find(id);
            if (tbProveedores == null)
            {
                return HttpNotFound();
            }
            ViewBag.municipioId = new SelectList(db.tbMunicipios, "municipioId", "departamentoId", tbProveedores.municipioId);
            ViewBag.proveedorUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbProveedores.proveedorUsuarioCreacion);
            ViewBag.proveedorUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbProveedores.proveedorUsuarioModificacion);
            return View(tbProveedores);
        }

        // POST: Proveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "proveedorId,proveedorNombre,municipioId,proveedorDireccionExacta,proveedorTelefono,proveedorEmail,proveedorFechaCreacion,proveedorUsuarioCreacion,proveedorFechaModificacion,proveedorUsuarioModificacion,proveedorEstado")] tbProveedores tbProveedores)
        {
            ModelState.Remove("proveedorFechaCreacion");
            ModelState.Remove("proveedorUsuarioCreacion");
            ModelState.Remove("proveedorFechaModificacion");
            ModelState.Remove("proveedorUsuarioModificacion");
            ModelState.Remove("proveedorEstado");
            if (ModelState.IsValid)
            {
                try
                {
                    db.UDP_InsertarProveedores(tbProveedores.proveedorNombre, tbProveedores.municipioId, tbProveedores.proveedorDireccionExacta, tbProveedores.proveedorTelefono, tbProveedores.proveedorEmail, 1);
                    return RedirectToAction("Index");
                }
                catch(Exception)
                {

                }
                return RedirectToAction("Index");
            }
            ViewBag.municipioId = new SelectList(db.tbMunicipios, "municipioId", "departamentoId", tbProveedores.municipioId);
            ViewBag.proveedorUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbProveedores.proveedorUsuarioCreacion);
            ViewBag.proveedorUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbProveedores.proveedorUsuarioModificacion);
            return View(tbProveedores);
        }

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProveedores tbProveedores = db.tbProveedores.Find(id);
            if (tbProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tbProveedores);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbProveedores tbProveedores = db.tbProveedores.Find(id);
            try
            {
                db.UDP_EliminarProveedores(tbProveedores.proveedorId);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public JsonResult CargarMunicipio(string departamentoId)
        {
            var ddlMuni = db.UDP_CargarMunicipios(departamentoId).ToList();
            return Json(ddlMuni, JsonRequestBehavior.AllowGet);
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
