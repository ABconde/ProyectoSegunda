using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoVentas.Models;
namespace AutoVentas.Controllers
{
    public class ArchivoController : Controller
    {
        public DB_AUTOVENTAS db = new DB_AUTOVENTAS();
        //
        // GET: /Archivo/
        public ActionResult ObtenerArchivo(int id)
        {
            var imagen = db.archivo.Find(id);
            return File(imagen.contenido, imagen.ContentType);
        }
	}
}