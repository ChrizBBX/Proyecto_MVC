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
    public class MunicipiosController : Controller
    {
        private SistemaVentasEntities db = new SistemaVentasEntities();

        // GET: Municipios
        public ActionResult Index()
        {
            var tbMunicipios = db.tbMunicipios.Include(t => t.tbDepartamentos).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbMunicipios.ToList().Where(X => X.municipioEstado == true));
        }

        // GET: Municipios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
            if (tbMunicipios == null)
            {
                return HttpNotFound();
            }
            return View(tbMunicipios);
        }

        // GET: Municipios/Create
        public ActionResult Create()
        {
            ViewBag.departamentoId = new SelectList(db.tbDepartamentos, "departamentoId", "departamentoNombre");
            ViewBag.municipioUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            ViewBag.municipioUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            return View();
        }

        // POST: Municipios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "municipioId,departamentoId,municipioNombre,municipioFechaCreacion,municipioUsuarioCreacion,municipioFechaModificacion,municipioUsuarioModificacion,municipioEstado")] tbMunicipios tbMunicipios)
        {
            ModelState.Remove("municipioFechaCreacion");
            ModelState.Remove("municipioFechaModificacion");
            ModelState.Remove("municipioUsuarioModificacion");
            ModelState.Remove("municipioEstado");
            if (ModelState.IsValid)
            {
                //db.tbMunicipios.Add(tbMunicipios);
                //db.SaveChanges();
                //db.UDP_InsertarMunicipios(tbMunicipios.municipioId, tbMunicipios.municipioNombre,tbMunicipios.departamentoId,1);
                return RedirectToAction("Index");
            }

            ViewBag.departamentoId = new SelectList(db.tbDepartamentos, "departamentoId", "departamentoNombre", tbMunicipios.departamentoId);
            ViewBag.municipioUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbMunicipios.municipioUsuarioCreacion);
            ViewBag.municipioUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbMunicipios.municipioUsuarioModificacion);
            return View(tbMunicipios);
        }


        public ActionResult Edit(string id, string municipioNombre)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.UDP_EditarMunicipios(id, municipioNombre, 1);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                }
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        // GET: Municipios/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
        //    if (tbMunicipios == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.departamentoId = new SelectList(db.tbDepartamentos, "departamentoId", "departamentoNombre", tbMunicipios.departamentoId);
        //    ViewBag.municipioUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbMunicipios.municipioUsuarioCreacion);
        //    ViewBag.municipioUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbMunicipios.municipioUsuarioModificacion);
        //    return View(tbMunicipios);
        //}

        //// POST: Municipios/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        //// más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "municipioId,departamentoId,municipioNombre,municipioFechaCreacion,municipioUsuarioCreacion,municipioFechaModificacion,municipioUsuarioModificacion,municipioEstado")] tbMunicipios tbMunicipios)
        //{

        //    ModelState.Remove("municipioFechaCreacion");
        //    ModelState.Remove("municipioUsuarioCreacion");
        //    ModelState.Remove("municipioFechaModificacion");
        //    ModelState.Remove("municipioEstado");
        //    if (ModelState.IsValid)
        //    {
        //        //db.Entry(tbMunicipios).State = EntityState.Modified;
        //        //db.SaveChanges();
        //        //db.UDP_EditarMunicipios(int.Parse(tbMunicipios.departamentoId),int.Parse(tbMunicipios.municipioId), tbMunicipios.municipioNombre, tbMunicipios.municipioUsuarioModificacion);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.departamentoId = new SelectList(db.tbDepartamentos, "departamentoId", "departamentoNombre", tbMunicipios.departamentoId);
        //    ViewBag.municipioUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbMunicipios.municipioUsuarioCreacion);
        //    ViewBag.municipioUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbMunicipios.municipioUsuarioModificacion);
        //    return View(tbMunicipios);
        //}

        // GET: Municipios/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
        //    if (tbMunicipios == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbMunicipios);
        //}

        //// POST: Municipios/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
        //    db.tbMunicipios.Remove(tbMunicipios);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(int id)
        {
            try
            {
                db.UDP_EliminarMunicipios(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public JsonResult CargarModal(string id)
        {
            var load = db.UDP_SelectMunicipioxId(id).ToList();
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
