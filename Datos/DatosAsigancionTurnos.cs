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
    public class DatosAsigancionTurnos
    {
        AccesoDatos ds = new AccesoDatos();

        public Boolean existeTurno(Turnos tur)
        {
            String consulta = "SELECT * FROM Turnos WHERE CodUsuarios_T='" + tur.CodUsuarios_T1 + "'"+ "AND CodDias_T='"+ tur.CodDias_T1 + "'"+ "AND CodHorarios_T='" + tur.CodHorarios_T1 + "'";
            return ds.existe(consulta);
        }

        public int eliminarTurno(Turnos tur)     // Elimina la Sucursal de la Base de Datos
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTurnoEliminar(ref comando, tur);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarTurno");
        }

        public int agregarTurno(Turnos tur)    // Agrega la Sucursal a la Base de Datos
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTurnoAgregar(ref comando, tur);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarTurno");
        }

        private void ArmarParametrosTurnoEliminar(ref SqlCommand Comando, Turnos tur)  //  Configura el parametro necesario para eliminar la Sucursal
        {                                                                                   // en este caso, el Id ingresado
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@CODTURNOS", SqlDbType.Char);
            SqlParametros.Value = tur.CodTurnos_T1;
        }

        private void ArmarParametrosTurnoAgregar(ref SqlCommand Comando, Turnos tur)   // Configura el parametro necesario para agregar la Sucursal
        {                                                                                   // agrega el Nombre, Descripcion, Provincia y Direccion.
            SqlParameter SqlParametros = new SqlParameter();                               // No esta incluido el ID porque se agrega automaticamente con otra funcion 
            SqlParametros = Comando.Parameters.Add("@CODTURNOS", SqlDbType.Char);
            SqlParametros.Value = tur.CodTurnos_T1;
            SqlParametros = Comando.Parameters.Add("@CODCLIENTES", SqlDbType.Char);
            SqlParametros.Value = tur.CodEmpresas_T1;
            SqlParametros = Comando.Parameters.Add("@CODRUBROS", SqlDbType.VarChar);
            SqlParametros.Value = tur.CodRubros_T1;
            SqlParametros = Comando.Parameters.Add("@CODUSUARIOS", SqlDbType.VarChar);
            SqlParametros.Value = tur.CodUsuarios_T1;
            SqlParametros = Comando.Parameters.Add("@CODDIAS", SqlDbType.VarChar);
            SqlParametros.Value = tur.CodDias_T1;
            SqlParametros = Comando.Parameters.Add("@CODHORARIOS", SqlDbType.VarChar);
            SqlParametros.Value = tur.CodHorarios_T1;
            SqlParametros = Comando.Parameters.Add("@CODFECHAS", SqlDbType.DateTime);
            SqlParametros.Value = tur.CodFechas_T1;
        }
    }
}
