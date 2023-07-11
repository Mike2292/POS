using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBC_ComOnline.Models;

namespace BBC_ComOnline.Controllers
{
    public class Home3Controller : Controller
    {
        // GET: Home3
        public ActionResult Index()
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            return View(ma.LeerTodo());
        }

        // GET: Home3/Details/5
        public ActionResult Details(string id)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Models.Articulo art = ma.Leer(id);
            return View(art);
        }

        // GET: Home3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home3/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Models.Articulo art = new Models.Articulo
            {
                Codigo = collection["codigo"],
                Descripcion = collection["descripcion"],
                Precio = float.Parse(collection["precio"].ToString())
            };
            ma.Crear(art);
            return RedirectToAction("Index");
        }

        // GET: Home3/Edit/5
        public ActionResult Edit(string id)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Models.Articulo art = ma.Leer(id);
            return View(art);
        }

        // POST: Home3/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Models.Articulo art = new Models.Articulo
            {
                Codigo = id,
                Descripcion = collection["descripcion"].ToString(),
                Precio = float.Parse(collection["precio"].ToString())
            };
            ma.Modificar(art);
            return RedirectToAction("Index");
        }

        // GET: Home3/Delete/5
        public ActionResult Delete(string id)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Models.Articulo art = ma.Leer(id);
            return View(art);
        }

        // POST: Home3/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            ma.Borrar(id);
            return RedirectToAction("Index");
        }
    }
}
