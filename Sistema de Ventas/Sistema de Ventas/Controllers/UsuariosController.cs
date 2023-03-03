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
    public class UsuariosController : Controller
    {
        private SistemaVentasEntities db = new SistemaVentasEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var tbUsuarios = db.tbUsuarios.Include(t => t.tbEmpleados2).Include(t => t.tbUsuarios2).Include(t => t.tbUsuarios3).Where(x => x.usuarioEstado == true);
            return View(tbUsuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
            if (tbUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuarios);
        }

        // GET: Usuarios/Create

        public ActionResult Create1(string usuarioUsuario ,int empleadoId, string usuarioContrasenia)
        {
            try
            {
                string empleadoId1 = Session["EmpleadoID"].ToString();
                db.UDP_InsertarUsuario(usuarioUsuario, usuarioContrasenia, empleadoId, int.Parse(empleadoId1));

                return RedirectToAction("Index");

                return View("Index");
            }
            catch (Exception)
            {

            }
            return View("Index");
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "usuarioId,usuarioUsuario,usuarioContrasenia,empleadoId,usuarioUsuarioCreacion,usuarioFechaCreacion,usuarioUsuarioModificacion,usuarioFechaModificacion,usuarioEstado")] tbUsuarios tbUsuarios)
        //{
        //    ModelState.Remove("usuarioUsuarioCreacion");
        //    ModelState.Remove("usuarioFechaCreacion");
        //    ModelState.Remove("usuarioUsuarioModificacion");
        //    ModelState.Remove("usuarioFechaModificacion");
        //    ModelState.Remove("usuarioEstado");
        //    if (ModelState.IsValid)
        //    {
        //        db.UDP_InsertarUsuario(tbUsuarios.usuarioUsuario, tbUsuarios.usuarioContrasenia, tbUsuarios.empleadoId, 1);
        //        //db.tbUsuarios.Add(tbUsuarios);
        //        //db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.empleadoId = new SelectList(db.tbEmpleados, "empleadoId", "empleadoNombre", tbUsuarios.empleadoId);
        //    ViewBag.usuarioUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbUsuarios.usuarioUsuarioCreacion);
        //    ViewBag.usuarioUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbUsuarios.usuarioUsuarioModificacion);
        //    return View(tbUsuarios);
        //}

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id, string usuarioUsuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.UDP_EdicionUsuario(id, usuarioUsuario);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                }
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "usuarioId,usuarioUsuario,usuarioContrasenia,empleadoId,usuarioUsuarioCreacion,usuarioFechaCreacion,usuarioUsuarioModificacion,usuarioFechaModificacion,usuarioEstado")] tbUsuarios tbUsuarios)
        //{
        //    ModelState.Remove("usuarioUsuarioCreacion");
        //    ModelState.Remove("usuarioFechaCreacion");
        //    ModelState.Remove("usuarioUsuarioModificacion");
        //    ModelState.Remove("usuarioFechaModificacion");
        //    ModelState.Remove("usuarioEstado");
        //    if (ModelState.IsValid)
        //    {
        //        //db.Entry(tbUsuarios).State = EntityState.Modified;
        //        //db.SaveChanges();
        //        db.UDP_EdicionUsuario(tbUsuarios.usuarioId,tbUsuarios.usuarioUsuario, 1,1);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.empleadoId = new SelectList(db.tbEmpleados, "empleadoId", "empleadoNombre", tbUsuarios.empleadoId);
        //    ViewBag.usuarioUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbUsuarios.usuarioUsuarioCreacion);
        //    ViewBag.usuarioUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbUsuarios.usuarioUsuarioModificacion);
        //    return View(tbUsuarios);
        //}

        // GET: Usuarios/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
        //    if (tbUsuarios == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbUsuarios);
        //}

        //// POST: Usuarios/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
        //    db.tbUsuarios.Remove(tbUsuarios);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult Delete(int id)
        {
            try
            {
                db.UDP_BorrarUsuario(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public JsonResult CargarEmpleado()
        {
            var ddlEmpleado = db.UDP_DDLEmpleados().ToList();
            return Json(ddlEmpleado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CargarModal(int id)
        {
            var load = db.UDP_CargarUsuarios(id).ToList();
            return Json(load, JsonRequestBehavior.AllowGet);
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
