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
    public class DepartamentosController : Controller
    {
        private SistemaVentasEntities db = new SistemaVentasEntities();

        // GET: Departamentos
        public ActionResult Index()
        {
            var tbDepartamentos = db.tbDepartamentos.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbDepartamentos.ToList().Where(X => X.departamentoEstado == true));
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            if (tbDepartamentos == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartamentos);
        }

        // GET: Departamentos/Create
        public ActionResult Create()
        {
            ViewBag.departamentoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            ViewBag.departamentoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            return View();
        }

        // POST: Departamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "departamentoId,departamentoNombre,departamentoFechaCreacion,departamentoUsuarioCreacion,departamentoFechaModificacion,departamentoUsuarioModificacion,departamentoEstado")] tbDepartamentos tbDepartamentos)
        {
            
            ModelState.Remove("departamentoFechaCreacion");
            ModelState.Remove("departamentoFechaModificacion");
            ModelState.Remove("departamentoUsuarioModificacion");
            ModelState.Remove("departamentoEstado");

            if (ModelState.IsValid)
            {
                try
                {
                    string empleadoId = Session["EmpleadoID"].ToString();
                    db.UDP_InsertarDepartamentos(tbDepartamentos.departamentoId, tbDepartamentos.departamentoNombre, int.Parse(empleadoId));
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                }        
                return RedirectToAction("Index");
            }
            ViewBag.departamentoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbDepartamentos.departamentoUsuarioCreacion);
            ViewBag.departamentoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbDepartamentos.departamentoUsuarioModificacion);

            return View(tbDepartamentos);
        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            if (tbDepartamentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.departamentoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbDepartamentos.departamentoUsuarioCreacion);
            ViewBag.departamentoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbDepartamentos.departamentoUsuarioModificacion);
            return View(tbDepartamentos);
        }

        // POST: Departamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "departamentoId,departamentoNombre,departamentoFechaCreacion,departamentoUsuarioCreacion,departamentoFechaModificacion,departamentoUsuarioModificacion,departamentoEstado")] tbDepartamentos tbDepartamentos)
        {

                ModelState.Remove("departamentoFechaCreacion");
                ModelState.Remove("departamentoUsuarioCreacion");
                ModelState.Remove("departamentoFechaModificacion");
                ModelState.Remove("departamentoEstado");

                if (ModelState.IsValid)
                {
                try
                {
                    db.UDP_EditarDepartamentos(int.Parse(tbDepartamentos.departamentoId), tbDepartamentos.departamentoNombre, tbDepartamentos.departamentoUsuarioModificacion);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                }     
                    return RedirectToAction("Index");
                }
            ViewBag.departamentoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbDepartamentos.departamentoUsuarioCreacion);
            ViewBag.departamentoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbDepartamentos.departamentoUsuarioModificacion);
            return View(tbDepartamentos);

        }

        // GET: Departamentos/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
        //    if (tbDepartamentos == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbDepartamentos);
        //}

        //// POST: Departamentos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
        //    db.tbDepartamentos.Remove(tbDepartamentos);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(int id)
        {
            try
            {
                db.UDP_EliminarDepartamentos(id);
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
