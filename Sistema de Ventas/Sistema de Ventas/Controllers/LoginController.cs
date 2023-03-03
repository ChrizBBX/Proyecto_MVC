using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_de_Ventas.Models;

namespace Tarea_LoginyTablaUsuario.Controllers
{
   
    public class LoginController : Controller
    {
        SistemaVentasEntities db = new SistemaVentasEntities();
        // GET: Login
        public ActionResult Index()
        {
            Session["Usuario"] = null;
            return View();   
        }
      
        [HttpPost]
        public ActionResult Index(string txtusuario, string txtpassword)
        {
            Session["Usuario"] = null;
            var login = db.UDP_Login(txtusuario, txtpassword).ToList();
        if (login.Count() > 0)
            {
                foreach (var item in login)
                {
                    Session["EmpleadoID"] = item.empleadoId.ToString();
                }
                Session["Usuario"] = txtusuario;
                return RedirectToAction("Index", "Home","Home");
            }
            else
            {
                ModelState.AddModelError("Validador", "El Usuario/Contraseña son incorrectos.");
            }
            return View();
        }

        public ActionResult RecuperarContrasena()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CambioContrasena(string txtusuario, string txtpassword)
        {
            var usuario = db.UDP_SelectUsuario(txtusuario).ToList();
            string cadena = "";
            if (usuario.Count() > 0)
            {
                db.UDP_CambiarContrasenia(txtusuario, txtpassword);
                cadena = "Index";
            }
            else
            {
                ModelState.AddModelError("Validador", "El Usuario es Incorrecto.");
                cadena = "RecuperarContrasena";
            }
                return View(cadena);
        }

    }


   
}