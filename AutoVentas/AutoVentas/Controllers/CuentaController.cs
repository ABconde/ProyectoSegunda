using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoVentas.Models;
namespace AutoVentas.Controllers
{
    public class CuentaController : Controller
    {
        public DB_AUTOVENTAS db = new DB_AUTOVENTAS();
        //
        // GET: /Cuenta/
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            var usr = db.usuario.FirstOrDefault(u => u.nick == usuario.nick && u.contrasenia == usuario.contrasenia);
            if (usr != null)
            {
                Session["nombreUsuario"] = usr.nombre;
                Session["idUsuario"] = usr.idUsuario;
                return VerificarSesion();
            }
            else {
                ModelState.AddModelError("","Verifique sus Credenciales! Usuario o Contraseña son incorrectos!");
            }
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            if(ModelState.IsValid){
                var rol = db.rol.FirstOrDefault(r=>r.idRol==2);
                usuario.rol = rol;
                db.usuario.Add(usuario);
                db.SaveChanges();
                ViewBag.mensaje = "Usuario  " + usuario.nick + "  ha sido registrado";

            }

            return View();
        }

        public ActionResult VerificarSesion(){
        
            if (Session["idUsuario"] != null)
            {
              return  RedirectToAction("../Home/Index");
            }
            else {
                return RedirectToAction("Login");
            }
            
        }

        public ActionResult Logout() {
            Session.Remove("idUsuario");
            Session.Remove("nombreUsuario");
            return RedirectToAction("Login");
        }


	}
}