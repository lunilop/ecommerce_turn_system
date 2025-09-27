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
    public class DatosVisualizacionTurnos
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable getTablaTurnos(string CodUsuarios)   // Trae la tabla con todas las Localidades
        {
            DataTable tabla = ds.ObtenerTabla("Turnos", "SELECT CodTurnos_T, NombreEmpresa_C, NombreDia_D, Descripcion_H, CodFechas_T, Descripcion_E, Observaciones_T FROM Turnos INNER JOIN Clientes ON CodEmpresas_C = CodEmpresas_T INNER JOIN Dias ON CodDias_D = CodDias_T INNER JOIN Horarios ON CodHorarios_H = CodHorarios_T INNER JOIN Estados ON CodEstados_E = CodEstados_T WHERE Estado_T = 1 AND CodUsuarios_T='" + CodUsuarios + "'");
            return tabla;
        }

        public DataTable getTablaEstados()
        {
            DataTable tabla = ds.ObtenerTabla("Estados", "SELECT CodEstados_E,Descripcion_E FROM Estados");
            return tabla;
        }

        public int modificarTurno(Turnos tur)    // Agrega la Sucursal a la Base de Datos
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosModificarTurno(ref comando, tur);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spActualizarTurno");
        }

        private void ArmarParametrosModificarTurno(ref SqlCommand Comando, Turnos tur)   // Configura el parametro necesario para agregar la Sucursal
        {                                                                                   // agrega el Nombre, Descripcion, Provincia y Direccion.
            SqlParameter SqlParametros = new SqlParameter();                               // No esta incluido el ID porque se agrega automaticamente con otra funcion 
            SqlParametros = Comando.Parameters.Add("@CODTURNO", SqlDbType.Char);
            SqlParametros.Value = tur.CodTurnos_T1;
            SqlParametros = Comando.Parameters.Add("@CODESTADO", SqlDbType.Char);
            SqlParametros.Value = tur.CodEstados_T1;
            SqlParametros = Comando.Parameters.Add("@OBSERVACIONES", SqlDbType.VarChar);
            SqlParametros.Value = tur.Observaciones_T1;
        }


        public DataTable FiltrarTurnosPorMes(int mes, int ano)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
             new SqlParameter("@Mes", mes),
             new SqlParameter("@Ano", ano)
            };
            DataTable tabla = ds.EjecutarProcedimientoConParametros("spFiltrarTurnosPorMes", parametros);
            return tabla;
        }    

    }
}
