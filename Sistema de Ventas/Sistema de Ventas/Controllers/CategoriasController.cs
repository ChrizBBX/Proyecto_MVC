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
    public class CategoriasController : Controller
    {
        private SistemaVentasEntities db = new SistemaVentasEntities();

        // GET: Categorias
        public ActionResult Index()
        {
            var tbCategoria = db.tbCategoria.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Where(x => x.categoriaEstado == true);
            return View(tbCategoria.ToList());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCategoria tbCategoria = db.tbCategoria.Find(id);
            if (tbCategoria == null)
            {
                return HttpNotFound();
            }
            return View(tbCategoria);
        }

        //GET: Categorias/Create
        public ActionResult Create1( string categoriaDescripcion)
        {
            try
            {
                db.UDP_InsertarCategorias(categoriaDescripcion, 1);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

            }
         
            return RedirectToAction("Index");
            //return View();
        }

        // POST: Categorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "categoriaId,categoriaDescripcion,categoriaFechaCreacion,categoriaUsuarioCreacion,categoriaFechaModificacion,categoriaUsuarioModificacion,categoriaEstado")] tbCategoria tbCategoria)
        //{

        //    ModelState.Remove("categoriaFechaCreacion");
        //    ModelState.Remove("categoriaUsuarioCreacion");
        //    ModelState.Remove("categoriaFechaModificacion");
        //    ModelState.Remove("categoriaUsuarioModificacion");
        //    ModelState.Remove("categoriaEstado");
        //    if (ModelState.IsValid)
        //    {
        //        //db.tbCategoria.Add(tbCategoria);
        //        //db.SaveChanges();
        //        db.UDP_InsertarCategorias(tbCategoria.categoriaDescripcion, 1);
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.categoriaUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCategoria.categoriaUsuarioModificacion);
        //    ViewBag.categoriaUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCategoria.categoriaUsuarioCreacion);
        //    return View(tbCategoria);
        //}

        //public ActionResult Insert(string categoria)
        //{
        //    db.UDP_InsertarCategorias(categoria,1);
        //    return RedirectToAction("Index");
        //}






        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id, string categoriaDescripcion)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    db.UDP_EditarCategorias(id, categoriaDescripcion, 1);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    throw;
                }
            }
           return View("Index");
        }

        //POST: Categorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse.Para obtener
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoriaId,categoriaDescripcion,categoriaFechaCreacion,categoriaUsuarioCreacion,categoriaFechaModificacion,categoriaUsuarioModificacion,categoriaEstado")] tbCategoria tbCategoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.UDP_EditarCategorias(tbCategoria.categoriaId, tbCategoria.categoriaDescripcion, 1);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                }
          
                return RedirectToAction("Index");
            }
            ViewBag.categoriaUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCategoria.categoriaUsuarioModificacion);
            ViewBag.categoriaUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbCategoria.categoriaUsuarioCreacion);
            return View(tbCategoria);
        }

        //public ActionResult Edit(int id)
        //{
        //    var tbCategoria = db.tbCategoria.Where(t => t.categoriaId == id).FirstOrDefault();
        //    return PartialView("_Edit", tbCategoria);
        //}

        //[HttpPost]
        //public ActionResult Edit([Bind(Include = "categoriaId,categoriaDescripcion,categoriaFechaCreacion,categoriaUsuarioCreacion,categoriaFechaModificacion,categoriaUsuarioModificacion,categoriaEstado")] tbCategoria tbCategoria)
        //{

        //    string cat = tbCategoria.categoriaDescripcion;
        //    if (!String.IsNullOrEmpty(cat))
        //    {

        //        db.UDP_EditarCategorias(tbCategoria.categoriaId, tbCategoria.categoriaDescripcion, 1);
        //        db.SaveChanges();
        //        return RedirectToAction("Index", "Categorias");

        //    }
        //    return RedirectToAction("Index", "Categorias");

        //}


        public JsonResult CargarModal(int id)
        {
            var load = db.UDP_CargarCategoria(id).ToList();
            return Json(load, JsonRequestBehavior.AllowGet);
        }

        // GET: Categorias/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbCategoria tbCategoria = db.tbCategoria.Find(id);
        //    if (tbCategoria == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbCategoria);
        //}

        //// POST: Categorias/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tbCategoria tbCategoria = db.tbCategoria.Find(id);
        //    db.tbCategoria.Remove(tbCategoria);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult Delete(int id)
        {
            try
            {
                db.UDP_BorrarCaTegorias(id);
                return RedirectToAction("Index");
            }
            catch
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
