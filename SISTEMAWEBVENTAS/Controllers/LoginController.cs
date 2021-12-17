using MAC.Models.Trax;
using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SISTEMAWEBVENTAS.Utilidades;

namespace SISTEMAWEBVENTAS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index( string correo, string clave)
        {
            Usuario ousuario = CD_Usuario.Instancia.ObtenerUsuarios().Where(u => u.Correo == correo && u.Clave == Encriptar.GetSHA256(clave)).FirstOrDefault();

            if (ousuario == null)
            {
               
                    ViewBag.Error = "Upss el correo es incorrecto";
                    return View();
                
            }
            Session["Usuario"] = ousuario;

            return RedirectToAction("Index", "Home");

        }
    }
}