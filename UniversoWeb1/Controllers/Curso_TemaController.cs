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
    public class Curso_TemaController : Controller
    {
        //
        // GET: /Curso_Tema/
        RepositorioCurso_Tema repoCT = new RepositorioCurso_Tema();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Curso_Tema()
        {
            return View(repoCT.obtenerCurso_Temas());
        }

        public ActionResult Curso_TemaDetails(int id)
        {
            return View(repoCT.obtenerCurso_Tema(id));
        }

        public ActionResult Curso_TemaInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Curso_TemaInsert(Curso_Tema datos)
        {
            repoCT.insertarCurso_Tema(datos);
            return RedirectToAction("Curso_Tema");
        }

        public ActionResult Curso_TemaDelete(int id)
        {
            return View(repoCT.obtenerCurso_Tema(id));
        }
        [HttpPost]
        public ActionResult Curso_TemaDelete(int id, FormCollection frm)
        {
            repoCT.eliminarCurso_Tema(id);
            return RedirectToAction("Curso_Tema");
        }

        public ActionResult Curso_TemaEdit(int id)
        {
            return View(repoCT.obtenerCurso_Tema(id));
        }
        [HttpPost]
        public ActionResult Curso_TemaEdit(int id, Curso_Tema datos)
        {
            datos.IdCT = id;
            repoCT.actualizarCurso_Tema(datos);
            return RedirectToAction("Curso_Tema");
        }

    }
}

