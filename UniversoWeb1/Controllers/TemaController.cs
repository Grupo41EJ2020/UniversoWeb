using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLaboratorio.Models;

namespace MVCLaboratorio.Controllers
{
    public class TemaController : Controller
    {
        //
        // GET: /Tema/
        RepositorioTema repoTema = new RepositorioTema();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Tema()
        {
            return View(repoTema.obtenerTemas());
        }

        public ActionResult TemaDetails(int id)
        {
            return View(repoTema.obtenerTema(id));
        }

        public ActionResult TemaCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TemaCreate(Tema datos)
        {
            repoTema.insertarTema(datos);
            return RedirectToAction("Tema");
        }

        public ActionResult TemaDelete(int id)
        {
            return View(repoTema.obtenerTema(id));
        }
        [HttpPost]
        public ActionResult TemaDelete(int id, FormCollection frm)
        {
            repoTema.eliminarTema(id);
            return RedirectToAction("Tema");
        }

        public ActionResult TemaEdit(int id)
        {
            return View(repoTema.obtenerTema(id));
        }
        [HttpPost]
        public ActionResult TemaEdit(int id, Tema datos)
        {
            datos.IdTema = id;
            repoTema.actualizarTema(datos);
            return RedirectToAction("Tema");
        }






    }
}

