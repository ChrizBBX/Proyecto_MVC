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
    public class CargosController : Controller
    {
        private SistemaVentasEntities db = new SistemaVentasEntities();

        // GET: Cargos
        public ActionResult Index()
        {
            var tbCargos = db.tbCargos.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbCargos.ToList().Where(X => X.cargoEstado == true));
        }

        // GET: Cargos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCargos tbCargos = db.tbCargos.Find(id);
            if (tbCargos == null)
            {
                return HttpNotFound();
            }
            return View(tbCargos);
        }

        public ActionResult Create1(string cargoNombre, int usuarioCreacion)
        {
            try
            {
                db.UDP_InsertarCargos(cargoNombre, 1);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");

        }

        // GET: Cargos/Create
        //public ActionResult Create()
        //{
        //    ViewBag.cargoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
        //    ViewBag.cargoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
        //    return View();
        //}

        //// POST: Cargos/Create
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        //// más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "cargoId,cargoNombre,cargoFechaCreacion,cargoUsuarioCreacion,cargoFechaModificacion,cargoUsuarioModificacion,cargoEstado")] tbCargos tbCargos)
        //{
        //    ModelState.Remove("cargoId");
        //    ModelState.Remove("cargoFechaModificacion");
        //    ModelState.Remove("cargoUsuarioModificacion");
        //    ModelState.Remove("cargoEstado");
        //    if (ModelState.IsValid)
        //    {
        //        //db.tbCargos.Add(tbCargos);
        //        //db.SaveChanges();
        //        db.UDP_InsertarCargos(tbCargos.cargoNombre, tbCargos.cargoUsuarioCreacion);
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.cargoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCargos.cargoUsuarioCreacion);
        //    ViewBag.cargoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCargos.cargoUsuarioModificacion);
        //    return View(tbCargos);
        //}

        // GET: Cargos/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbCargos tbCargos = db.tbCargos.Find(id);
        //    if (tbCargos == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.cargoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCargos.cargoUsuarioCreacion);
        //    ViewBag.cargoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCargos.cargoUsuarioModificacion);
        //    return View(tbCargos);
        //}

        //// POST: Cargos/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        //// más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "cargoId,cargoNombre,cargoFechaCreacion,cargoUsuarioCreacion,cargoFechaModificacion,cargoUsuarioModificacion,cargoEstado")] tbCargos tbCargos)
        //{
        //    ModelState.Remove("cargoId");
        //    ModelState.Remove("cargoFechaCreacion");
        //    ModelState.Remove("cargoUsuarioCreacion");
        //    ModelState.Remove("cargoFechaModificacion");
        //    ModelState.Remove("cargoEstado");
        //    if (ModelState.IsValid)
        //    {
        //        //db.Entry(tbCargos).State = EntityState.Modified;
        //        //db.SaveChanges();
        //        db.UDP_EditarCargo(tbCargos.cargoId, tbCargos.cargoNombre, tbCargos.cargoUsuarioModificacion);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.cargoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCargos.cargoUsuarioCreacion);
        //    ViewBag.cargoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCargos.cargoUsuarioModificacion);
        //    return View(tbCargos);
        //}


        public ActionResult Edit(int id, string cargoNombre)
        {
            try
            {
                db.UDP_EditarCargo(id, cargoNombre, 1);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

            }

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Edit([Bind(Include = "cargoId,cargoNombre,cargoFechaCreacion,cargoUsuarioCreacion,cargoFechaModificacion,cargoUsuarioModificacion,cargoEstado")] tbCargos tbCargos)
        //{

        //    string cat = tbCargos.cargoNombre;
        //    if (!String.IsNullOrEmpty(cat))
        //    {

        //        db.UDP_EditarCargo(tbCargos.cargoId, tbCargos.cargoNombre, 1);
        //        db.SaveChanges();
        //        return RedirectToAction("Index", "Cargos");

        //    }
        //    return RedirectToAction("Index", "Cargos");

        //}



        // GET: Cargos/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbCargos tbCargos = db.tbCargos.Find(id);
        //    if (tbCargos == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbCargos);
        //}

        // //POST: Cargos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tbCargos tbCargos = db.tbCargos.Find(id);
        //    db.tbCargos.Remove(tbCargos);
        //    db.SaveChanges();
        //    db.UDP_BorrarCargo(tbCargos.cargoId);
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(int id)
        {
            try
            {
                db.UDP_BorrarCargo(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
            }
     
            return RedirectToAction("Index");
        }

        public JsonResult CargarModal(int id)
        {
            var load = db.UDP_SelectCargoxId(id).ToList();
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
