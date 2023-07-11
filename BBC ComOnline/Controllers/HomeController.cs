using BBC_ComOnline.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using System.Dynamic;
using Newtonsoft.Json;

namespace BBC_ComOnline.Controllers
{
    public class HomeController : Controller
    {
        static public decimal total;
        static public decimal cantidadProductos;

        public List<int> prueba = new List<int>();
        // GET: Home

        //[FiltroAutorizacion]
        public ActionResult Index()
        {
            if (Session["Correo"] != null)
            {
                return View(prueba);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Index(int i)
        {
            Debug.WriteLine("Numero: "+i);
            prueba.Add(i);
            return View(prueba);
        }

        public ActionResult AdministrarCaja()
        {
            if (Session["Correo"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AperturaCaja(Caja ca)
        {
            try
            {
                Debug.WriteLine("Apertura Caja 1");
                BBC_ComOnlineEntities1 db = new BBC_ComOnlineEntities1();
                Caja newCaja = new Caja();
                newCaja.Id = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Hour.ToString() + "-" + Session["Usuario_ID"].ToString();
                newCaja.Estado = true;
                newCaja.FechaApertura = DateTime.Now;
                newCaja.FechaCierre = newCaja.FechaApertura;
                newCaja.MontoInicial = ca.MontoInicial;
                Debug.WriteLine("Apertura Caja 2");
                newCaja.Total = ca.MontoInicial;
                newCaja.UsuarioId = int.Parse(Session["Usuario_ID"].ToString());
                db.CajaSet.Add(newCaja);
                db.SaveChanges();
                Debug.WriteLine("Apertura Caja 3");

                return RedirectToAction("AdministrarCaja", "Home");
            }
            catch (Exception)
            {
                Debug.WriteLine("Apertura Caja Error");
                ViewBag.Alert = "No fue posible abrir la caja.";
                return RedirectToAction("AdministrarCaja", "Home");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CierreCaja(Caja ca)
        {

            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Productos()
        {
            if (Session["Correo"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            //@Html.DropDownList("Unidad_MedidaId", null, htmlAttributes: new { @class = "form-control" })
            //@Html.DropDownList("CategoriaId", null, htmlAttributes: new { @class = "form-control" })
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Productos(Articulo Art, Empresa_Articulo EArt)
        {
            BBC_ComOnlineEntities1 db = new BBC_ComOnlineEntities1();
            try
            {
                Art.Estado = true;
                if (EArt.EAN_ID == null)
                {
                    Art.EAN = EArt.Codigo_Interno;
                }
                else
                {
                    Art.EAN = EArt.EAN_ID;
                }
                if (EArt.Fecha_Compra == null)
                {
                    EArt.Fecha_Compra = DateTime.Now;
                }
                //Debug.WriteLine(EArt.);
                EArt.EmpresaRut = Session["Rut Empresa"].ToString();
                db.Empresa_Articulo.Add(EArt);
                db.Articuloes.Add(Art);
                db.SaveChanges();
                ViewBag.Alert = "Producto creado con exito.";
                return View();
            }
            catch (Exception)
            {
                ViewBag.Alert = "No fue posible crear el producto.";
                return View();
            }
        }

        [HttpGet]
        public JsonResult ObtenerTodosProductos()
        {
            BBC_ComOnlineEntities1 db = new BBC_ComOnlineEntities1();
            //var dataList = db.Articuloes.Where(x => x.Estado == true).ToList();
            var dataList = db.Empresa_Articulo.Include(c => c.Articulo).ToList();
            var modefiedData = dataList.Select(x => new
            {
                CodigoBarra = x.EAN_ID,
                Descripcion = x.Articulo.Descripcion,
                Estado = x.Articulo.Estado,
                PrecioPublico = x.Precio_Publico,
                PreccioCosto = x.Precio_Costo,
                Cantidad = x.Cantidad
            }).ToList();
            return Json(modefiedData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerCarro()
        {
            BBC_ComOnlineEntities1 db = new BBC_ComOnlineEntities1();
            var dataList = db.Detalle_CarroSet.Include(c => c.Carro_Compra).ToList();
            var modefiedData = dataList.Select(x => new
            {
                CodigoBarra = x.ArticuloEAN,
                Descripcion = x.Descripcion_Producto,
                Precio = x.Precio,
                Cantidad = x.Cantidad,
                Subtotal = x.Precio * x.Cantidad
            }).ToList();
            return Json(modefiedData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ConsultarCaja()
        {
            Debug.WriteLine("Consultar Caja");
            BBC_ComOnlineEntities1 db = new BBC_ComOnlineEntities1();
            var cajaId = db.CajaSet.AsEnumerable()
                            .Where(x => x.UsuarioId == int.Parse(Session["Usuario_ID"].ToString()) && x.FechaApertura.Day.ToString() + "-" + x.FechaApertura.Month.ToString() + "-" + x.FechaApertura.Year.ToString() == DateTime.Now.Day.ToString()+"-"+ DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString())
                            .Select(x => x.Id).FirstOrDefault();
            var ca = (from a in db.CajaSet
                       where a.Id == cajaId
                       select a).FirstOrDefault();
            Debug.WriteLine(ca.Estado);
            return Json(new { id = ca.Id,
                              FechaApertura = ca.FechaApertura,
                              MontoInicial = ca.MontoInicial,
                              Estado = ca.Estado,
                              Total = ca.Total
            });
        }

        [HttpGet]
        public JsonResult AgregarProducto(string EAN, string Descripcion, decimal Precio, decimal Cantidad)
        {
            /*dynamic myObject = new ExpandoObject();
            total += Precio * Cantidad;
            List<Decimal> tot = new List<decimal>();
            tot.Add(total);
            myObject.total = tot;
            string json = JsonConvert.SerializeObject(myObject);*/

            BBC_ComOnlineEntities1 db = new BBC_ComOnlineEntities1();
            cantidadProductos += 1;
            try
            {
                Carro_Compra cc = new Carro_Compra();
                Detalle_Carro dc = new Detalle_Carro();
                if (Session["Carro_ID"] == null)
                {
                    Debug.WriteLine(Session["Rut Empresa"].ToString());
                    Debug.WriteLine(DateTime.Now.Day.ToString());
                    Debug.WriteLine(DateTime.Now.Minute.ToString());
                    cc.Id = Session["Rut Empresa"].ToString().Substring(0, 5) + "-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Minute.ToString();
                    cc.UsuarioId = int.Parse(Session["Usuario_ID"].ToString());
                    cc.Total = 1;
                    db.Carro_CompraSet.Add(cc);
                    Session["Carro_ID"] = cc.Id;
                }
                dc.ID = Session["Carro_ID"].ToString() + "-" + cantidadProductos;
                dc.Carro_CompraId = Session["Carro_ID"].ToString();
                dc.ArticuloEAN = EAN;
                dc.Descripcion_Producto = Descripcion;
                dc.Precio = Precio;
                dc.Cantidad = Cantidad;
                dc.SubTotal = Precio * Cantidad;

                db.Detalle_CarroSet.Add(dc);
                Debug.WriteLine(dc.Carro_CompraId + "-" + dc.ArticuloEAN + "-" + dc.Descripcion_Producto + "-" + dc.Precio + "-" + dc.Cantidad + "-" + dc.SubTotal);
                db.SaveChanges();
                Debug.WriteLine("Guarda los datos");
                var lista = ObtenerCarro();

                //------------------------------------------------------------------------------

                var dataList = db.Detalle_CarroSet.Include(c => c.Carro_Compra).ToList();
                var modefiedData = dataList.Select(x => new
                {
                    CodigoBarra = x.ArticuloEAN,
                    Descripcion = x.Descripcion_Producto,
                    Precio = x.Precio,
                    Cantidad = x.Cantidad,
                    Subtotal = x.Precio * x.Cantidad
                }).ToList();

                return Json(modefiedData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                for (int i = 0; i < cantidadProductos; i++)
                {
                    db.Detalle_CarroSet.Remove(db.Detalle_CarroSet.Single(a => a.ID == Session["Carro_ID"].ToString() + "-" + i.ToString()));
                }
                db.Carro_CompraSet.Remove(db.Carro_CompraSet.Single(a => a.Id == Session["Carro_ID"].ToString()));
                db.SaveChanges();
                Session["Carro_ID"] = null;
                total = 0;
                cantidadProductos = 0;
                return Json("ObtenerCarro", "Home");
            }
            //return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cuentas()
        {
            if (Session["Correo"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Logout()
        {
            try
            {
                BBC_ComOnlineEntities1 db = new BBC_ComOnlineEntities1();
                for (int i = 0; i < cantidadProductos; i++)
                {
                    db.Detalle_CarroSet.Remove(db.Detalle_CarroSet.Single(a => a.ID == Session["Carro_ID"].ToString() + "-" + i.ToString()));
                }
                db.Carro_CompraSet.Remove(db.Carro_CompraSet.Single(a => a.Id == Session["Carro_ID"].ToString()));
                db.SaveChanges();
                
                return RedirectToAction("Index", "Login");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Session["Correo"] = null;
                Session["Razon Social"] = null;
                Session["Rut Empresa"] = null;
                Session["Rubro"] = null;
                Session["Direccion"] = null;
                Session["Telefono"] = null;
                Session["Carro_ID"] = null;
                total = 0;
                cantidadProductos = 0;
            }
        }

    }
}