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
    public class DatosUsuariosXDiasXHorarios
    {
        AccesoDatos ds = new AccesoDatos();

        public Boolean existeUsuXDiaXHora(UsuariosXDiasXHorarios udh)
        {
            String consulta = "Select * from UsuariosXDiasXHorarios where CodUsuarios_UXDXH='" + udh.CodUsuarios_UXDXH1 + "'";
            return ds.existe(consulta);
        }

        public DataTable getTablaDiasFiltradas(string CodUsuarios)   // Trae la tabla con todas las Localidades
        {
            DataTable tabla = ds.ObtenerTabla("UsuariosXDiasXHorarios", "SELECT DISTINCT CodDias_UXDXH, NombreDia_D FROM UsuariosXDiasXHorarios INNER JOIN Dias ON CodDias_D = CodDias_UXDXH WHERE CodUsuarios_UXDXH= '" + CodUsuarios + "'");
            return tabla;
        }

        public DataTable getTablaHorariosFiltradas(string CodUsuarios, string CodDias )   // Trae la tabla con todas las Localidades
        {
            DataTable tabla = ds.ObtenerTabla("UsuariosXDiasXHorarios", "SELECT DISTINCT CodHorarios_UXDXH, Descripcion_H FROM UsuariosXDiasXHorarios INNER JOIN Horarios ON CodHorarios_H = CodHorarios_UXDXH WHERE CodUsuarios_UXDXH= '" + CodUsuarios + "'"+ "AND CodDias_UXDXH= '" + CodDias + "'");
            return tabla;
        }


        public int eliminarUsuXDiaXHora(UsuariosXDiasXHorarios udh)     // Elimina la Sucursal de la Base de Datos
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUDHEliminar(ref comando, udh);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarUsuarioXDiaXHorario");
        }

        public int agregarUsuXDiaXHora(UsuariosXDiasXHorarios udh)    // Agrega la Sucursal a la Base de Datos
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUDHAgregar(ref comando, udh);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarUsuarioXDiaXHorario");
        }

        public int eliminarDUsuXDiaXHora(UsuariosXDiasXHorarios udh)     // Elimina la Sucursal de la Base de Datos
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUDHEliminarD(ref comando, udh);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarUsuarioXDiaXHorarioD");
        }
        private void ArmarParametrosUDHEliminarD(ref SqlCommand Comando, UsuariosXDiasXHorarios udh)  //  Configura el parametro necesario para eliminar la Sucursal
        {                                                                                   // en este caso, el Id ingresado
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@CODUSUARIOS", SqlDbType.Char);
            SqlParametros.Value = udh.CodUsuarios_UXDXH1;
        }

        private void ArmarParametrosUDHEliminar(ref SqlCommand Comando, UsuariosXDiasXHorarios udh)  //  Configura el parametro necesario para eliminar la Sucursal
        {                                                                                   // en este caso, el Id ingresado
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@CODUSUARIOS", SqlDbType.Char);
            SqlParametros.Value = udh.CodUsuarios_UXDXH1;
        }

        private void ArmarParametrosUDHAgregar(ref SqlCommand Comando, UsuariosXDiasXHorarios udh)   // Configura el parametro necesario para agregar la Sucursal
        {                                                                                   // agrega el Nombre, Descripcion, Provincia y Direccion.
            SqlParameter SqlParametros = new SqlParameter();                               // No esta incluido el ID porque se agrega automaticamente con otra funcion 
            SqlParametros = Comando.Parameters.Add("@CODUSUARIOS", SqlDbType.Char);
            SqlParametros.Value = udh.CodUsuarios_UXDXH1;
            SqlParametros = Comando.Parameters.Add("@CODDIAS", SqlDbType.Char);
            SqlParametros.Value = udh.CodDias_UXDXH1;
            SqlParametros = Comando.Parameters.Add("@CODHORARIOS", SqlDbType.Char);
            SqlParametros.Value = udh.CodHorarios_UXDXH1;
        }

        public int modificarUsuXDiaXHora(UsuariosXDiasXHorarios udh)    // Agrega la Sucursal a la Base de Datos
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUDHModificar(ref comando, udh);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spActualizarUsuarioXDiaXHorario");
        }

        private void ArmarParametrosUDHModificar(ref SqlCommand Comando, UsuariosXDiasXHorarios udh)   // Configura el parametro necesario para agregar la Sucursal
        {                                                                                   // agrega el Nombre, Descripcion, Provincia y Direccion.
            SqlParameter SqlParametros = new SqlParameter();                               // No esta incluido el ID porque se agrega automaticamente con otra funcion 
            SqlParametros = Comando.Parameters.Add("@CODUSUARIOS", SqlDbType.Char);
            SqlParametros.Value = udh.CodUsuarios_UXDXH1;
            SqlParametros = Comando.Parameters.Add("@CODDIAS", SqlDbType.Char);
            SqlParametros.Value = udh.CodDias_UXDXH1;
            SqlParametros = Comando.Parameters.Add("@CODHORARIOS", SqlDbType.Char);
            SqlParametros.Value = udh.CodHorarios_UXDXH1;
        }

    }
}
