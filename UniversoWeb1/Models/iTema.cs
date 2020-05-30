using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLaboratorio.Models
{
    public interface iTema
    {
        List<Tema> obtenerTemas();
        Tema obtenerTema(int IdTema);
        void insertarTema(Tema datosTema);
        void eliminarTema(int idTema);
        void actualizarTema(Tema datosTema);
    }
}
