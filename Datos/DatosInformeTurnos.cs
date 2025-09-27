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
    public class DatosInformeTurnos
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable FiltrarTurnosPorEstadoYRangoFechas(string estado, int mesInicio, int anioInicio, int mesFin, int anioFin)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@Estado", estado),
            new SqlParameter("@MesInicio", mesInicio),
            new SqlParameter("@AnioInicio", anioInicio),
            new SqlParameter("@MesFin", mesFin),
            new SqlParameter("@AnioFin", anioFin)
            };

            return ds.EjecutarProcedimientoConParametros("spFiltrarTurnosPorEstadoYRangoFechas", parametros);
        }

        public decimal ObtenerPorcentajeTurnosPorEstadoYRangoFechas(string estado, int mesInicio, int anioInicio, int mesFin, int anioFin)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@Estado", estado),
            new SqlParameter("@MesInicio", mesInicio),
            new SqlParameter("@AnioInicio", anioInicio),
            new SqlParameter("@MesFin", mesFin),
            new SqlParameter("@AnioFin", anioFin)
            };

            DataTable dt = ds.EjecutarProcedimientoConParametros("spPorcentajeTurnosPorEstadoYRangoFechas", parametros);
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
