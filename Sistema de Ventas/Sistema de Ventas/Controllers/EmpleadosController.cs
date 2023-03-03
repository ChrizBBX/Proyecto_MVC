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
    public class EmpleadosController : Controller
    {
        private SistemaVentasEntities db = new SistemaVentasEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            var tbEmpleados = db.tbEmpleados.Include(t => t.tbCargos).Include(t => t.tbEstadosCiviles).Include(t => t.tbMunicipios).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbEmpleados.ToList().Where(X => X.empleadoEstado == true));
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            if (tbEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tbEmpleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.cargoId = new SelectList(db.tbCargos, "cargoId", "cargoNombre");
            ViewBag.estadoCivilId = new SelectList(db.tbEstadosCiviles, "estadoCivilId", "estadoCivilNombre");
            //ViewBag.municipioId = new SelectList(db.tbMunicipios, "municipioId", "municipioNombre");
            ViewBag.empleadoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            ViewBag.empleadoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empleadoId,empleadoNombre,empleadoApellido,empleadoSexo,municipioId,empleadoDireccionExacta,estadoCivilId,empleadoTelefono,empleadoCorreoElectronico,empleadoFechaNacimiento,empleadoFechaContratacion,cargoId,empleadoFechaCreacion,empleadoUsuarioCreacion,empleadoFechaModificacion,empleadoUsuarioModificacion,empleadoEstado")] tbEmpleados tbEmpleados)
        {
            ModelState.Remove("empleadoFechaModificacion");
            ModelState.Remove("empleadoUsuarioModificacion");
            ModelState.Remove("empleadoEstado");
            if (ModelState.IsValid)
            {
                try
                {
                    db.UDP_InsertarEmpleados(tbEmpleados.empleadoNombre, tbEmpleados.empleadoApellido, tbEmpleados.empleadoSexo, tbEmpleados.municipioId, tbEmpleados.empleadoDireccionExacta, tbEmpleados.estadoCivilId, tbEmpleados.empleadoTelefono, tbEmpleados.empleadoCorreoElectronico, tbEmpleados.empleadoFechaNacimiento.ToString(), tbEmpleados.empleadoFechaContratacion.ToString(), tbEmpleados.cargoId.ToString(), tbEmpleados.empleadoUsuarioCreacion);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                }

                return RedirectToAction("Index");
            }

            ViewBag.cargoId = new SelectList(db.tbCargos, "cargoId", "cargoNombre", tbEmpleados.cargoId);
            ViewBag.estadoCivilId = new SelectList(db.tbEstadosCiviles, "estadoCivilId", "estadoCivilNombre", tbEmpleados.estadoCivilId);
            //ViewBag.municipioId = new SelectList(db.tbMunicipios, "municipioNombre", "departamentoId", tbEmpleados.municipioId);
            ViewBag.empleadoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbEmpleados.empleadoUsuarioCreacion);
            ViewBag.empleadoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbEmpleados.empleadoUsuarioModificacion);
            return View(tbEmpleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            if (tbEmpleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.cargoId = new SelectList(db.tbCargos, "cargoId", "cargoNombre", tbEmpleados.cargoId);
            ViewBag.estadoCivilId = new SelectList(db.tbEstadosCiviles, "estadoCivilId", "estadoCivilNombre", tbEmpleados.estadoCivilId);
            ViewBag.municipioId = new SelectList(db.tbMunicipios, "municipioNombre", "municipioId", tbEmpleados.municipioId);
            ViewBag.empleadoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbEmpleados.empleadoUsuarioCreacion);
            ViewBag.empleadoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbEmpleados.empleadoUsuarioModificacion);
            return View(tbEmpleados);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empleadoId,empleadoNombre,empleadoApellido,empleadoSexo,municipioId,empleadoDireccionExacta,estadoCivilId,empleadoTelefono,empleadoCorreoElectronico,empleadoFechaNacimiento,empleadoFechaContratacion,cargoId,empleadoFechaCreacion,empleadoUsuarioCreacion,empleadoFechaModificacion,empleadoUsuarioModificacion,empleadoEstado")] tbEmpleados tbEmpleados)
        {
            ModelState.Remove("empleadoUsuarioCreacion");
            ModelState.Remove("empleadoFechaCreacion");
            ModelState.Remove("empleadoFechaModificacion");
            ModelState.Remove("empleadoEstado");
            if (ModelState.IsValid)
            {
                try
                {
                    db.UDP_EditarEmpleados(tbEmpleados.empleadoId, tbEmpleados.empleadoNombre, tbEmpleados.empleadoApellido, tbEmpleados.empleadoSexo, tbEmpleados.municipioId, tbEmpleados.empleadoDireccionExacta, tbEmpleados.estadoCivilId, tbEmpleados.empleadoTelefono, tbEmpleados.empleadoCorreoElectronico, tbEmpleados.empleadoFechaNacimiento.ToString(), tbEmpleados.empleadoFechaContratacion.ToString(), tbEmpleados.cargoId.ToString(), tbEmpleados.empleadoUsuarioCreacion);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                }
                
                return RedirectToAction("Index");
            }
            ViewBag.cargoId = new SelectList(db.tbCargos, "cargoId", "cargoNombre", tbEmpleados.cargoId);
            ViewBag.estadoCivilId = new SelectList(db.tbEstadosCiviles, "estadoCivilId", "estadoCivilNombre", tbEmpleados.estadoCivilId);
            //ViewBag.municipioId = new SelectList(db.tbMunicipios, "municipioNombre", "departamentoId", tbEmpleados.municipioId);
            ViewBag.empleadoUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbEmpleados.empleadoUsuarioCreacion);
            ViewBag.empleadoUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbEmpleados.empleadoUsuarioModificacion);
            return View(tbEmpleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            if (tbEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tbEmpleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);

            try
            {
                db.UDP_EliminarEmpleados(tbEmpleados.empleadoId);
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
        public JsonResult CargarMunicipioxIdMunicipio(string municipioId)
        {
            var ddlMuni = db.UDP_MUNICIPIOxMunicipioId(municipioId).ToList();
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
