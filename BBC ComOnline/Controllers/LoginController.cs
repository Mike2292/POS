using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using BBC_ComOnline.Helper;
using BBC_ComOnline.Models;

namespace BBC_ComOnline.Controllers
{
    public class LoginController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            if (Session["Correo"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Usuario userForm)
        {
            userForm.Correo = "Mike@gmail.com";
            userForm.Clave = "12345";
            Session["Razon Social"] = "Optica";
            Session["Rut Empresa"] = "7777777-7";
            Debug.WriteLine(Session["Rut Empresa"].ToString());
            Session["Rubro"] = "Venta Articulos Opticos";
            Session["Direccion"] = "Av. Carrascal";
            Session["Telefono"] = "945903958";
            Session["Correo"] = "Mike@gmail.com";
            Session["Usuario_ID"] = "Mike";
            Session["EstadoCaja"] = "Cerrada";
            ViewBag.Alert = "Usuario Creado";

            
            MantenimientoUsuario mu = new MantenimientoUsuario();
            return RedirectToAction("index", "Home");
            /*Usuario usu = new Usuario
            {
                Correo = userForm.Correo,//collection["Correo"].ToString(),
                Clave = userForm.Clave//collection["Clave"].ToString()
            };*/

            //----------------------------------------------
            //DESCOMENTAR LUEGO
            /*
            if (userForm.Correo == null && userForm.Clave == null)
            {
                ModelState.AddModelError("Correo", "Debe ingresar Las credenciales para iniciar sesión.");
                return View(userForm);
            } 
            else if (userForm.Correo == null)
            {
                ModelState.AddModelError("Correo", "Debe ingresar un correo para iniciar sesión.");
                return View(userForm);
            }
            else if (!email_bien_escrito(userForm.Correo))
            {
                ModelState.AddModelError("Correo", "El campo no cumple con el formato necesario.." +
                    "");
                return View(userForm);
            }
            else if (userForm.Clave == null)
            {
                ModelState.AddModelError("Clave", "Debe ingresar la contraseña para iniciar sesión.");
                return View(userForm);
            }

            if (ModelState.IsValid)
            {
                userForm.Clave = AppHelper.GetMd5Hash(userForm.Clave);
                if (mu.Login(userForm))
                {
                    BBC_ComOnlineEntities1 db = new BBC_ComOnlineEntities1();
                    Usuario usu = (from s in db.Usuarios
                                   where s.Correo == userForm.Correo
                                   select s).FirstOrDefault<Usuario>();
                    Empresa emp = db.Empresas.Find(usu.EmpresaRut);
                   
                    Session["Razon Social"] = emp.RazonSocial;
                    Session["Rut Empresa"] = emp.Rut;
                    Debug.WriteLine(Session["Rut Empresa"].ToString());
                    Session["Rubro"] = emp.Rubro;
                    Session["Direccion"] = emp.Direccion;
                    Session["Telefono"] = emp.Telefono;
                    Session["Correo"] = userForm.Correo;
                    Session["Usuario_ID"] = usu.Id;
                    Session["EstadoCaja"] = "Cerrada";
                    return RedirectToAction("index", "Home");
                }
            }
            ModelState.AddModelError("Clave", "Las credenciales no corresponden.");
            return View(userForm);
            */
        }

        private bool email_bien_escrito(string correo)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(correo, expresion))
            {
                if (Regex.Replace(correo, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(Empresa Em, Usuario Us)
        {
            BBC_ComOnlineEntities1 db = new BBC_ComOnlineEntities1();
            try
            {
                Us.Estado = true;
                Us.EmpresaRut = Em.Rut;
                Us.Clave = AppHelper.GetMd5Hash(Us.Clave);
                db.Empresas.Add(Em);
                db.Usuarios.Add(Us);
                db.SaveChanges();
                ViewBag.Alert = "Cuenta creada con exito.";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Alert = "No fue posible crear el registro, intente mas tarde. " + e.ToString();
                return View();
            }

        }
    }
}