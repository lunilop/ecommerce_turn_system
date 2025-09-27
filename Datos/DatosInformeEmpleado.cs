using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosInformeEmpleado
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable getTipoUsuarios()
        {
            DataTable tabla = ds.ObtenerTabla("TipoUsuario", "SELECT CodTipoUsuario_TU, Descripcion_TU FROM TipoUsuario");
            return tabla;
        }

        public DataTable getGeneros()
        {
            DataTable tabla = ds.ObtenerTabla("Usuarios", "SELECT CodUsuarios_U, Genero_U FROM Usuarios");
            return tabla;
        }
        public DataTable ObtenerDatosFiltrados(string tipoUsuario, string genero)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@genero", genero),
            new SqlParameter("@tipo", tipoUsuario)
            };

            return ds.EjecutarProcedimientoConParametros("FiltrarUsuariosPorGeneroYTipo", parametros);
        }

        public decimal ObtenerPorcentajePorTipoGenero(string tipoUsuario, string genero)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@tipo", tipoUsuario),
            new SqlParameter("@genero", genero)
            };

            DataTable dt = ds.EjecutarProcedimientoConParametros("ObtenerPorcentajeUsuarios", parametros);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }
    }
}
