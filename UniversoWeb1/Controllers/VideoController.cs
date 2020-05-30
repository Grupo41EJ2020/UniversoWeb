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
    public class VideoController : Controller
    {
        //
        // GET: /Video/
        RepositorioVideo repoVideo = new RepositorioVideo();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Video()
        {
            return View(repoVideo.obtenerVideos());
        }

        public ActionResult VideoDetails(int id)
        {
            return View(repoVideo.obtenerVideo(id));
        }

        public ActionResult VideoInsert()
        {
            return View(repoVideo.obtenerVideos());
        }
        [HttpPost]
        public ActionResult VideoInsert(int id, Video datos)
        {
            datos.IdVideo = id;
            repoVideo.insertarVideo(datos);
            return RedirectToAction("Video");
        }

        public ActionResult VideoDelete(int id)
        {
            return View(repoVideo.obtenerVideo(id));
        }
        [HttpPost]
        public ActionResult VideoDelete(int id, FormCollection frm)
        {
            repoVideo.eliminarVideo(id);
            return RedirectToAction("Video");
        }

        public ActionResult VideoEdit(int id)
        {
            return View(repoVideo.obtenerVideo(id));
        }
        [HttpPost]
        public ActionResult VideoEdit(int id, Video datos)
        {
            datos.IdVideo = id;
            repoVideo.actualizarVideo(datos);
            return RedirectToAction("Video");
        }
    }
}

