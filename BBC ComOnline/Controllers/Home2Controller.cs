using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBC_ComOnline.Models;

namespace BBC_ComOnline.Controllers
{
    public class Home2Controller : Controller
    {
        // GET: Home2
        public ActionResult Index()
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            return View(ma.LeerTodo());
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(FormCollection collection)
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

        public ActionResult Borrar(string cod)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            ma.Borrar(cod);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(string cod)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Models.Articulo art = ma.Leer(cod);
            return View(art);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Models.Articulo art = new Models.Articulo
            {
                Codigo = collection["codigo"].ToString(),
                Descripcion = collection["descripcion"].ToString(),
                Precio = float.Parse(collection["precio"].ToString())
            };
            ma.Modificar(art);
            return RedirectToAction("Index");
        }
    }
}