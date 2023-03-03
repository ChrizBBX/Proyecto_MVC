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
    public class ClientesController : Controller
    {
        private SistemaVentasEntities db = new SistemaVentasEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            var tbClientes = db.tbClientes.Include(t => t.tbMunicipios).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Where(x => x.clienteEstado == true); ;
            return View(tbClientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbClientes tbClientes = db.tbClientes.Find(id);
            if (tbClientes == null)
            {
                return HttpNotFound();
            }
            return View(tbClientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.departamentoId = new SelectList(db.tbDepartamentos, "departamentoId", "departamentoNombre");
            //ViewBag.municipioId = new SelectList(db.tbMunicipios, "municipioId", "departamentoId");
            ViewBag.clienteUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            ViewBag.clienteUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clienteId,clienteNombre,clienteApellido,municipioId,clienteDireccionExacta,clienteTelefono,clienteCorreoElectronico,clienteFechaCreacion,clienteUsuarioCreacion,clienteFechaModificacion,clienteUsuarioModificacion,clienteEstado")] tbClientes tbClientes)
        {
            ModelState.Remove("clienteFechaCreacion");
            ModelState.Remove("clienteUsuarioCreacion");
            ModelState.Remove("clienteFechaModificacion");
            ModelState.Remove("clienteUsuarioModificacion");
            ModelState.Remove("clienteEstado");
            if (ModelState.IsValid)
            {
                try
                {
                    db.UDP_InsertarClientes(tbClientes.clienteNombre, tbClientes.clienteApellido, tbClientes.municipioId, tbClientes.clienteDireccionExacta, tbClientes.clienteTelefono, tbClientes.clienteCorreoElectronico, 1);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                }
                //db.tbClientes.Add(tbClientes);
                //db.SaveChanges();
             
                return RedirectToAction("Index");
            }

            //ViewBag.municipioId = new SelectList(db.tbMunicipios, "municipioId", "departamentoId", tbClientes.municipioId);
            ViewBag.clienteUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbClientes.clienteUsuarioCreacion);
            ViewBag.clienteUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbClientes.clienteUsuarioModificacion);
            return View(tbClientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbClientes tbClientes = db.tbClientes.Find(id);
            if (tbClientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.municipioId = new SelectList(db.tbMunicipios, "municipioId", "departamentoId", tbClientes.municipioId);
            ViewBag.clienteUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbClientes.clienteUsuarioCreacion);
            ViewBag.clienteUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbClientes.clienteUsuarioModificacion);
            return View(tbClientes);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clienteId,clienteNombre,clienteApellido,municipioId,clienteDireccionExacta,clienteTelefono,clienteCorreoElectronico,clienteFechaCreacion,clienteUsuarioCreacion,clienteFechaModificacion,clienteUsuarioModificacion,clienteEstado")] tbClientes tbClientes)
        {
            ModelState.Remove("clienteFechaCreacion");
            ModelState.Remove("clienteUsuarioCreacion");
            ModelState.Remove("clienteFechaModificacion");
            ModelState.Remove("clienteUsuarioModificacion");
            ModelState.Remove("clienteEstado");

            if (ModelState.IsValid)
            {
                try
                {
                    db.UDP_EditarClientes(tbClientes.clienteId, tbClientes.clienteNombre, tbClientes.clienteApellido, tbClientes.municipioId, tbClientes.clienteDireccionExacta, tbClientes.clienteTelefono, tbClientes.clienteCorreoElectronico, 1);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                }
               
                return RedirectToAction("Index");
            }
            ViewBag.municipioId = new SelectList(db.tbMunicipios, "municipioId", "departamentoId", tbClientes.municipioId);
            ViewBag.clienteUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbClientes.clienteUsuarioCreacion);
            ViewBag.clienteUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbClientes.clienteUsuarioModificacion);
            return View(tbClientes);
        }

        // GET: Clientes/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbClientes tbClientes = db.tbClientes.Find(id);
        //    if (tbClientes == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbClientes);
        //}

        //// POST: Clientes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tbClientes tbClientes = db.tbClientes.Find(id);
        //    db.UDP_EliminarClientes(tbClientes.clienteId);
        //    //db.tbClientes.Remove(tbClientes);
        //    //db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult Delete(int id)
        {
            try
            {
                db.UDP_EliminarClientes(id);
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
