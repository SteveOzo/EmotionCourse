using EmotionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmotionWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Welcome = "Bienvenido";
            ViewBag.Numero = 1;
            return View();
        }

        public ActionResult OtroIndex()
        {
            var modelo = new Home();
            modelo.WelcomeMessage = "Hola bebe";
            return View(modelo);
        }
    }
}