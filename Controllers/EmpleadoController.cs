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
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/
        RepositorioEmpleado repoEmpleado = new RepositorioEmpleado();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Empleado()
        {
            return View(repoEmpleado.obtenerEmpleados());
        }

        public ActionResult EmpleadoDetails(int id)
        {
            return View(repoEmpleado.obtenerEmpleado(id));
        }

        public ActionResult EmpleadoInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmpleadoInsert(Empleado datos)
        {
            repoEmpleado.insertarEmpleado(datos);
            return RedirectToAction("Empleado");
        }

        public ActionResult EmpleadoDelete(int id)
        {
            return View(repoEmpleado.obtenerEmpleado(id));
        }
        [HttpPost]
        public ActionResult EmpleadoDelete(int id, FormCollection frm)
        {
            repoEmpleado.eliminarEmpleado(id);
            return RedirectToAction("Empleado");
        }

        public ActionResult EmpleadoEdit(int id)
        {
            return View(repoEmpleado.obtenerEmpleado(id));
        }
        [HttpPost]
        public ActionResult EmpleadoEdit(int id, Empleado datos)
        {
            datos.IdEmpleado = id;
            repoEmpleado.actualizarEmpleado(datos);
            return RedirectToAction("Empleado");
        }


    }
}

