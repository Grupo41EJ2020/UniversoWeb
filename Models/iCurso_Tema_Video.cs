using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLaboratorio.Models
{
    public interface iCurso_Tema_Video
    {
        List<Curso_Tema_Video> obtenerCurso_Tema_Videos();
        Curso_Tema_Video obtenerCurso_Tema_Video(int idCurso_Tema_Video);
        void insertarCurso_Tema_Video(Curso_Tema_Video datosCurso_Tema_Video);
        void eliminarCurso_Tema_Video(int idCurso_Tema_Video);
        void actualizarCurso_Tema_Video(Curso_Tema_Video datosCurso_Tema_Video);
    }
}