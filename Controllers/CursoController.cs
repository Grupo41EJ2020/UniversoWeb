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
    public class CursoController : Controller
    {
        //
        // GET: /Curso/
        RepositorioCurso repoCurso = new RepositorioCurso();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Curso()
        {
            return View(repoCurso.obtenerCursos());
        }
        public ActionResult CursoDetails(int id)
        {
            return View(repoCurso.obtenerCurso(id));
        }
        public ActionResult CursoInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Curso(Curso datos)
        {
            repoCurso.insertarCurso(datos);
            return RedirectToAction("Curso");
        }
        public ActionResult CursoDelete(int id)
        {
            return View(repoCurso.obtenerCurso(id));
        }
        [HttpPost]
        public ActionResult CursoDelete(int id, FormCollection frm)
        {
            repoCurso.eliminarCurso(id);
            return RedirectToAction("Curso");
        }
        public ActionResult CursoEdit(int id)
        {
            return View(repoCurso.obtenerCurso(id));
        }
        [HttpPost]
        public ActionResult CursoEdit(int id, Curso datos)
        {
            datos.IdCurso = id;
            repoCurso.actualizarCurso(datos);
            return RedirectToAction("Curso");
        }
    }
}