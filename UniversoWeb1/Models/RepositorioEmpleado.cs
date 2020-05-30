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
    public class RepositorioEmpleado
    {
        public List<Empleado> obtenerEmpleados()
        {
            DataTable dtEmpleado = BaseHelper.ejecutarConsulta("sp_Empleado_ConsultarTodo", CommandType.StoredProcedure);
            List<Empleado> IstEmpleado = new List<Empleado>();

            foreach (DataRow item in dtEmpleado.Rows)
            {
                Empleado datosEmpleado = new Empleado();
                datosEmpleado.IdEmpleado = int.Parse(item["IdEmpleado"].ToString());
                datosEmpleado.Nombre = (item["Nombre"].ToString());
                datosEmpleado.Direccion = (item["Direccion"].ToString());
                IstEmpleado.Add(datosEmpleado);
            }
            return IstEmpleado;
        }

        public Empleado obtenerEmpleado(int IdEmpleado)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", IdEmpleado));

            DataTable dtEmpleado = BaseHelper.ejecutarConsulta("sp_Empleado_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Empleado datosEmpleado = new Empleado();

            if (dtEmpleado.Rows.Count > 0)
            {
                datosEmpleado.IdEmpleado = int.Parse(dtEmpleado.Rows[0]["IdEmpleado"].ToString());
                datosEmpleado.Nombre = (dtEmpleado.Rows[0]["Nombre"].ToString());
                datosEmpleado.Direccion = (dtEmpleado.Rows[0]["Direccion"].ToString());
                return datosEmpleado;
            }
            else
            {
                return null;
            }
        }

        public void insertarEmpleado(Empleado datosEmpleado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre", datosEmpleado.Nombre));
            parametros.Add(new SqlParameter("@Direccion", datosEmpleado.Direccion));
            BaseHelper.ejecutarSentencia("sp_Empleado_Insertar", CommandType.StoredProcedure, parametros);
        }

        public void eliminarEmpleado(int IdEmpleado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", IdEmpleado));

            BaseHelper.ejecutarConsulta("sp_Empleado_Eliminar", CommandType.StoredProcedure, parametros);
        }

        public void actualizarEmpleado(Empleado datosEmpleado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdEmpleado", datosEmpleado.IdEmpleado));
            parametros.Add(new SqlParameter("@Nombre", datosEmpleado.Nombre));
            parametros.Add(new SqlParameter("@Direccion", datosEmpleado.Direccion));
            BaseHelper.ejecutarConsulta("sp_Empleado_Actualizar", CommandType.StoredProcedure, parametros);
        }
    }
}
