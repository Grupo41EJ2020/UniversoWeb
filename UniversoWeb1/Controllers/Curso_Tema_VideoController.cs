using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using MVCLaboratorio.Utilerias;
using MVCLaboratorio.Models;

namespace MVCLaboratorio.Controllers
{
    public class Curso_Tema_VideoController : Controller
    {
        //
        // GET: /Curso_Tema_Video/

        //Curso Tema Video
        RepositorioCurso_Tema_Video repoCTV = new RepositorioCurso_Tema_Video();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Curso_Tema_Video()
        {
            return View(repoCTV.obtenerCurso_Tema_Videos());
        }

        public ActionResult Curso_Tema_VideoDetails(int id)
        {
            return View(repoCTV.obtenerCurso_Tema_Video(id));
        }

        public ActionResult Curso_Tema_VideoInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Curso_Tema_VideoInsert(Curso_Tema_Video datos)
        {
            repoCTV.insertarCurso_Tema_Video(datos);
            return RedirectToAction("Curso_Tema_Video");
        }

        public ActionResult Curso_Tema_VideoDelete(int id)
        {
            return View(repoCTV.obtenerCurso_Tema_Video(id));
        }
        [HttpPost]
        public ActionResult Curso_Tema_VideoDelete(int id, FormCollection frm)
        {
            repoCTV.eliminarCurso_Tema_Video(id);
            return RedirectToAction("Curso_Tema_Video");
        }

        public ActionResult Curso_Tema_VideoEdit(int id)
        {
            return View(repoCTV.obtenerCurso_Tema_Video(id));
        }
        [HttpPost]
        public ActionResult Curso_Tema_VideoEdit(int id, Curso_Tema_Video datos)
        {
            datos.IdCTV = id;
            repoCTV.actualizarCurso_Tema_Video(datos);
            return RedirectToAction("Curso_Tema_Video");
        }

    }
}

