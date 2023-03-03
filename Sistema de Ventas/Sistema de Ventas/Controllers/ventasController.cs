     using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
using System.Threading;
using System.Web;
    using System.Web.Mvc;
    using Sistema_de_Ventas.Models;

    namespace Sistema_de_Ventas.Controllers
    {
        public class ventasController : Controller
        {
            private SistemaVentasEntities db = new SistemaVentasEntities();

            // GET: ventas
            public ActionResult Index()
            {
                var tbventa = db.tbventa.Include(t => t.tbClientes).Include(t => t.tbEmpleados).Include(t => t.tbMetodoPago).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
                return View(tbventa.ToList().Where(x => x.ventaEstado == true));
            }

            // GET: ventas/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbventa tbventa = db.tbventa.Find(id);
                if (tbventa == null)
                {
                    return HttpNotFound();
                }
                return View(tbventa);
            }
        
            // GET: ventas/Create
            public ActionResult Create()
            {
                ViewBag.clienteId = new SelectList(db.tbClientes, "clienteId", "clienteNombre");
                ViewBag.empleadoId = new SelectList(db.tbEmpleados, "empleadoId", "empleadoNombre");
                ViewBag.metodopagoId = new SelectList(db.tbMetodoPago, "metodopagoId", "metodopagoDescripcion");
                ViewBag.ventaUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
                ViewBag.ventaUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario");
            
                return View();
            }

            // POST: ventas/Create
            // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
            // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
   
            public ActionResult Create([Bind(Include = "ventaId,clienteId,ventaFecha,empleadoId,metodopagoId,ventaFechaCreacion,ventaUsuarioCreacion,ventaFechaModificacion,ventaUsuarioModificacion,ventaEstado")] tbventa tbventa)
            {

                ModelState.Remove("VentaId");
                ModelState.Remove("ventaFecha");
                ModelState.Remove("empleadoId");
                ModelState.Remove("ventaFechaCreacion");
                ModelState.Remove("ventaUsuarioCreacion");
                ModelState.Remove("ventaFechaModificacion");
                ModelState.Remove("ventaUsuarioModificacion");
                ModelState.Remove("ventaEstado");
                if (ModelState.IsValid)
                {
                try
                {
                    string empleadoId = Session["EmpleadoID"].ToString();
                    db.UDP_Insertarventa(tbventa.clienteId.ToString(), tbventa.metodopagoId, empleadoId, empleadoId);
                }
                catch (Exception)
                {

                  
                }
     
                }

                ViewBag.clienteId = new SelectList(db.tbClientes, "clienteId", "clienteNombre", tbventa.clienteId);
                ViewBag.empleadoId = new SelectList(db.tbEmpleados, "empleadoId", "empleadoNombre", tbventa.empleadoId);
                ViewBag.metodopagoId = new SelectList(db.tbMetodoPago, "metodopagoId", "metodopagoDescripcion", tbventa.metodopagoId);
                ViewBag.ventaUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbventa.ventaUsuarioCreacion);
                ViewBag.ventaUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbventa.ventaUsuarioModificacion);
                return View(tbventa);
            }

            // GET: ventas/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbventa tbventa = db.tbventa.Find(id);
                if (tbventa == null)
                {
                    return HttpNotFound();
                }
                ViewBag.clienteId = new SelectList(db.tbClientes, "clienteId", "clienteNombre", tbventa.clienteId);
                ViewBag.empleadoId = new SelectList(db.tbEmpleados, "empleadoId", "empleadoNombre", tbventa.empleadoId);
                ViewBag.metodopagoId = new SelectList(db.tbMetodoPago, "metodopagoId", "metodopagoDescripcion", tbventa.metodopagoId);
                ViewBag.ventaUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbventa.ventaUsuarioCreacion);
                ViewBag.ventaUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbventa.ventaUsuarioModificacion);
                return View(tbventa);
            }

   
        public ActionResult CreateVentaDetalle(string productoId, string cantidad)
            {
            try
            {
                db.UDP_InsertarventaDetalles(productoId, cantidad, "1");
            }
            catch (Exception)
            {

            }
             
            return View();
            }

            // POST: ventas/Edit/5
            // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
            // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "ventaId,clienteId,ventaFecha,empleadoId,metodopagoId,ventaFechaCreacion,ventaUsuarioCreacion,ventaFechaModificacion,ventaUsuarioModificacion,ventaEstado")] tbventa tbventa)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbventa).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.clienteId = new SelectList(db.tbClientes, "clienteId", "clienteNombre", tbventa.clienteId);
                ViewBag.empleadoId = new SelectList(db.tbEmpleados, "empleadoId", "empleadoNombre", tbventa.empleadoId);
                ViewBag.metodopagoId = new SelectList(db.tbMetodoPago, "metodopagoId", "metodopagoDescripcion", tbventa.metodopagoId);
                ViewBag.ventaUsuarioCreacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbventa.ventaUsuarioCreacion);
                ViewBag.ventaUsuarioModificacion = new SelectList(db.tbUsuarios, "usuarioId", "usuarioUsuario", tbventa.ventaUsuarioModificacion);
                return View(tbventa);
            }
  
        public JsonResult Agregar(string productoId, string cantidad)
        {

            try
            {
                if (!String.IsNullOrEmpty(cantidad) && cantidad != "0")
                {
                    db.UDP_InsertarventaDetalles(productoId, cantidad, "1");
                    var tbClientes = db.tbventa.ToList();
                    int ventaMax = tbClientes.Max(X => X.ventaId);
                    var cadena = db.UDP_DetalleEnTabla(ventaMax).ToList();
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
        public ActionResult Delete(int id)
        {
            try
            {
                db.UDP_EliminarVenta(id);
            }
            catch (Exception)
            {
            }
        
            return RedirectToAction("Index");
        }

        public ActionResult DeleteVentaDetalle(int id)
        {
            try
            {
                db.UDP_EliminarVentaDetalle(id);
            }
            catch (Exception)
            {
            }
            
            return RedirectToAction("Edit");
        }

        public JsonResult CargarMunicipios(string dep_Id)
            {
               var ddlmunicipio = db.UDP_SelectMunicipiosByDepartamentoId(dep_Id).ToList();
                return Json(ddlmunicipio, JsonRequestBehavior.AllowGet);
            }

            public JsonResult CargarProductos()
            {
                var ddlProductos = db.UDP_SelectProductos().ToList();
                return Json(ddlProductos, JsonRequestBehavior.AllowGet);
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }

        public JsonResult DetallesVenta(int ventaId)
        {
            var cadena = db.UDP_DetalleEnTabla(ventaId).ToList();
            return Json(cadena, JsonRequestBehavior.AllowGet);
        }
    }

  }
