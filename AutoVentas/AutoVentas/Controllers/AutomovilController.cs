using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoVentas.Models;

namespace AutoVentas.Controllers
{
    public class AutomovilController : Controller
    {
        private DB_AUTOVENTAS db = new DB_AUTOVENTAS();

        // GET: /Automovil/
        public ActionResult Index()
        {
            var automovil = db.autoMovil.Include(a => a.estado).Include(a => a.marca);
            return View(automovil.ToList());
        }

        // GET: /Automovil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.autoMovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // GET: /Automovil/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.estado, "idEstado", "nombre");
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre");
            return View();
        }

        // POST: /Automovil/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAutomovil,idMarca,Modelo,idEstado,Comentario,idUsuario")] Automovil automovil, HttpPostedFileBase archivo)
        {
            if (ModelState.IsValid)
            {
                
                if (archivo != null && archivo.ContentLength > 0)
                {
                    var imagen = new Archivo
                    {
                        nombre = System.IO.Path.GetFileName(archivo.FileName),
                        tipo = FileType.Imagen,
                        ContentType = archivo.ContentType

                    };
                    using (var reader = new System.IO.BinaryReader(archivo.InputStream))
                    {
                        imagen.contenido = reader.ReadBytes(archivo.ContentLength);
                    };
                    automovil.archivos = new List<Archivo> { imagen };
                }

                db.autoMovil.Add(automovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.estado, "idEstado", "nombre", automovil.idEstado);
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre", automovil.idMarca);
            return View(automovil);
        }

        // GET: /Automovil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.autoMovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.estado, "idEstado", "nombre", automovil.idEstado);
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre", automovil.idMarca);
            return View(automovil);
        }

        // POST: /Automovil/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idAutomovil,idMarca,Modelo,idEstado,Comentario,idUsuario")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.estado, "idEstado", "nombre", automovil.idEstado);
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre", automovil.idMarca);
            return View(automovil);
        }

        // GET: /Automovil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.autoMovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // POST: /Automovil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automovil automovil = db.autoMovil.Find(id);
            db.autoMovil.Remove(automovil);
            db.SaveChanges();
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
