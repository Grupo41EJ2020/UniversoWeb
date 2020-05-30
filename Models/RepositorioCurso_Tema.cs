using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using MVCLaboratorio.Utilerias;
using MVCLaboratorio.Models;

namespace MVCLaboratorio.Models
{
    public class RepositorioCurso_Tema
    {
        public List<Curso_Tema> obtenerCurso_Temas()
        {
            DataTable dtCurso_Tema = BaseHelper.ejecutarConsulta("sp_Curso_Tema_ConsultarTodo", CommandType.StoredProcedure);
            List<Curso_Tema> IstCurso_Tema = new List<Curso_Tema>();

            foreach (DataRow item in dtCurso_Tema.Rows)
            {
                Curso_Tema datosCurso_Tema = new Curso_Tema();
                datosCurso_Tema.IdCT = int.Parse(item["IdCT"].ToString());
                datosCurso_Tema.IdCurso = int.Parse(item["IdCurso"].ToString());
                datosCurso_Tema.IdTema = int.Parse(item["IdTema"].ToString());
                IstCurso_Tema.Add(datosCurso_Tema);
            }
            return IstCurso_Tema;
        }

        public Curso_Tema obtenerCurso_Tema(int IdCT)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCT", IdCT));

            DataTable dtCurso_Tema = BaseHelper.ejecutarConsulta("sp_Curso_Tema_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Curso_Tema miCurso_Tema = new Curso_Tema();

            if (dtCurso_Tema.Rows.Count > 0)
            {
                miCurso_Tema.IdCT = int.Parse(dtCurso_Tema.Rows[0]["IdCT"].ToString());
                miCurso_Tema.IdCurso = int.Parse(dtCurso_Tema.Rows[0]["IdCurso"].ToString());
                miCurso_Tema.IdTema = int.Parse(dtCurso_Tema.Rows[0]["IdTema"].ToString());
                return miCurso_Tema;
            }
            else
            {
                return null;
            }
        }

        public void insertarCurso_Tema(Curso_Tema datosCurso_Tema)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", datosCurso_Tema.IdCurso));
            parametros.Add(new SqlParameter("@IdTema", datosCurso_Tema.IdTema));

            BaseHelper.ejecutarSentencia("sp_Curso_Tema_Insertar", CommandType.StoredProcedure, parametros);
        }

        public void eliminarCurso_Tema(int IdCT)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCT", IdCT));

            BaseHelper.ejecutarConsulta("sp_Curso_Tema_Eliminar", CommandType.StoredProcedure, parametros);
        }

        public void actualizarCurso_Tema(Curso_Tema datosCurso_Tema)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCT", datosCurso_Tema.IdCT));
            parametros.Add(new SqlParameter("@IdCurso", datosCurso_Tema.IdCurso));
            parametros.Add(new SqlParameter("@IdTema", datosCurso_Tema.IdTema));

            BaseHelper.ejecutarConsulta("sp_Curso_Tema_Actualizar", CommandType.StoredProcedure, parametros);
        }
    }
}