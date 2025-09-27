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
    public class DatoAMBLEmpleados
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable getTablaEmpFilAlp(string apellido)
        {
            DataTable tabla = ds.ObtenerTabla("Usuarios", "SELECT CodUsuarios_U, Clave_U, Descripcion_R, Nombre_U, Apellido_U, DNI_U, Genero_U, Telefono_U, Email_U, Direccion_U, Nacionalidad_U, Nombre_P, Nombre_L, STUFF(( SELECT ',' + NombreDia_D FROM (SELECT DISTINCT NombreDia_D FROM Dias INNER JOIN UsuariosXDiasXHorarios ON CodDias_UXDXH = CodDias_D WHERE CodUsuarios_UXDXH = CodUsuarios_U) AS Subquery1 FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') AS NombreDia_D, STUFF((SELECT ',' + Descripcion_H  FROM (SELECT DISTINCT Descripcion_H FROM Horarios INNER JOIN UsuariosXDiasXHorarios ON CodHorarios_UXDXH = CodHorarios_H WHERE CodUsuarios_UXDXH = CodUsuarios_U) AS Subquery2 FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') AS Descripcion_H FROM Usuarios INNER JOIN UsuariosXDiasXHorarios ON CodUsuarios_UXDXH = CodUsuarios_U INNER JOIN Rubros ON CodRubros_U = CodRubros_R INNER JOIN Provincias ON CodProvincias_U = CodProvincias_P INNER JOIN Localidades ON CodProvincias_U = CodProvincias_L AND CodLocalidades_U = CodLocalidades_L WHERE CodTipoUsuario_U = 2 AND Estado_U = 1 AND Apellido_U LIKE '[" + apellido + "]%' GROUP BY CodUsuarios_U, Clave_U, Descripcion_R, Nombre_U, Apellido_U, DNI_U, Genero_U, Telefono_U, Email_U, Direccion_U, Nacionalidad_U, Nombre_P, Nombre_L ORDER BY CodUsuarios_U;");
            return tabla;
        }

        public bool existeEmpFilAlp(string apellido)
        {
            String consulta = ("SELECT CodUsuarios_U, Clave_U, Descripcion_R, Nombre_U, Apellido_U, DNI_U, Genero_U, Telefono_U, Email_U, Direccion_U, Nacionalidad_U, Nombre_P, Nombre_L, STUFF(( SELECT ',' + NombreDia_D FROM (SELECT DISTINCT NombreDia_D FROM Dias INNER JOIN UsuariosXDiasXHorarios ON CodDias_UXDXH = CodDias_D WHERE CodUsuarios_UXDXH = CodUsuarios_U) AS Subquery1 FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') AS NombreDia_D, STUFF((SELECT ',' + Descripcion_H  FROM (SELECT DISTINCT Descripcion_H FROM Horarios INNER JOIN UsuariosXDiasXHorarios ON CodHorarios_UXDXH = CodHorarios_H WHERE CodUsuarios_UXDXH = CodUsuarios_U) AS Subquery2 FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') AS Descripcion_H FROM Usuarios INNER JOIN UsuariosXDiasXHorarios ON CodUsuarios_UXDXH = CodUsuarios_U INNER JOIN Rubros ON CodRubros_U = CodRubros_R INNER JOIN Provincias ON CodProvincias_U = CodProvincias_P INNER JOIN Localidades ON CodProvincias_U = CodProvincias_L AND CodLocalidades_U = CodLocalidades_L WHERE CodTipoUsuario_U = 2 AND Estado_U = 1 AND Apellido_U LIKE '[" + apellido + "]%' GROUP BY CodUsuarios_U, Clave_U, Descripcion_R, Nombre_U, Apellido_U, DNI_U, Genero_U, Telefono_U, Email_U, Direccion_U, Nacionalidad_U, Nombre_P, Nombre_L ORDER BY CodUsuarios_U;");
            Console.WriteLine("SQL Query: " + consulta);

            // Execute the query and log the result
            bool exists = ds.existe(consulta);
            Console.WriteLine("Exists: " + exists);

            return exists;
        }

            public Boolean existeEmpleado(Usuarios usu)     // Verifica si la Sucursal existe en la Base de Datos
        {
            String consulta = "SELECT * from Usuarios WHERE CodTipoUsuario_U = 2 AND CodUsuarios_U='" + usu.CodUsuarios_U1 + "'";
            return ds.existe(consulta);
        }
        public DataTable getTablaEmpPorCodUsu(string cod)       // Trae la tabla con los filtros
        {
            DataTable tabla = ds.ObtenerTabla("Usuarios", "SELECT CodUsuarios_U, Clave_U, Descripcion_R, Nombre_U, Apellido_U, DNI_U, Genero_U, Telefono_U, Email_U, Direccion_U, Nacionalidad_U, Nombre_P, Nombre_L, STUFF((SELECT ',' + NombreDia_D FROM(SELECT DISTINCT NombreDia_D FROM Dias INNER JOIN UsuariosXDiasXHorarios ON CodDias_UXDXH = CodDias_D WHERE CodUsuarios_UXDXH = CodUsuarios_U) AS Subquery1 FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') AS NombreDia_D, STUFF((SELECT ',' + Descripcion_H  FROM(SELECT DISTINCT Descripcion_H FROM Horarios INNER JOIN UsuariosXDiasXHorarios ON CodHorarios_UXDXH = CodHorarios_H WHERE CodUsuarios_UXDXH = CodUsuarios_U) AS Subquery2 FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') AS Descripcion_H FROM Usuarios INNER JOIN UsuariosXDiasXHorarios ON CodUsuarios_UXDXH = CodUsuarios_U INNER JOIN Rubros ON CodRubros_U = CodRubros_R INNER JOIN Provincias ON CodProvincias_U = CodProvincias_P INNER JOIN Localidades ON CodProvincias_U = CodProvincias_L AND CodLocalidades_U = CodLocalidades_L WHERE CodTipoUsuario_U = 2 AND Estado_U = 1 AND CodUsuarios_U = '" + cod + "' GROUP BY CodUsuarios_U, Clave_U, Descripcion_R, Nombre_U, Apellido_U, DNI_U, Genero_U, Telefono_U, Email_U, Direccion_U, Nacionalidad_U, Nombre_P, Nombre_L ORDER BY CodUsuarios_U; ");
            return tabla;
        }

        public DataTable getTablaEmpleado()   // Trae la tabla con todas las Localidades
        {
            DataTable tabla = ds.ObtenerTabla("Usuarios", "SELECT CodUsuarios_U, Clave_U, Descripcion_R, Nombre_U, Apellido_U, DNI_U, Genero_U, Telefono_U, Email_U, Direccion_U, Nacionalidad_U, Nombre_P, Nombre_L, STUFF(( SELECT ',' + NombreDia_D FROM (SELECT DISTINCT NombreDia_D FROM Dias INNER JOIN UsuariosXDiasXHorarios ON CodDias_UXDXH = CodDias_D WHERE CodUsuarios_UXDXH = CodUsuarios_U) AS Subquery1 FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') AS NombreDia_D, STUFF((SELECT ',' + Descripcion_H  FROM (SELECT DISTINCT Descripcion_H FROM Horarios INNER JOIN UsuariosXDiasXHorarios ON CodHorarios_UXDXH = CodHorarios_H WHERE CodUsuarios_UXDXH = CodUsuarios_U) AS Subquery2 FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') AS Descripcion_H FROM Usuarios INNER JOIN UsuariosXDiasXHorarios ON CodUsuarios_UXDXH = CodUsuarios_U INNER JOIN Rubros ON CodRubros_U = CodRubros_R INNER JOIN Provincias ON CodProvincias_U = CodProvincias_P INNER JOIN Localidades ON CodProvincias_U = CodProvincias_L AND CodLocalidades_U = CodLocalidades_L WHERE CodTipoUsuario_U = 2 AND Estado_U = 1 GROUP BY CodUsuarios_U, Clave_U, Descripcion_R, Nombre_U, Apellido_U, DNI_U, Genero_U, Telefono_U, Email_U, Direccion_U, Nacionalidad_U, Nombre_P, Nombre_L ORDER BY CodUsuarios_U;");
            return tabla;
        }

        public DataTable getTablaProvFiltradas(string codProvincia)
        {
            DataTable tabla = ds.ObtenerTabla("Usuarios", "SELECT CodUsuarios_U, Clave_U, Descripcion_R, Nombre_U, Apellido_U, DNI_U, Genero_U, Telefono_U, Email_U, Direccion_U, Nacionalidad_U, Nombre_P, Nombre_L, STUFF(( SELECT ',' + NombreDia_D FROM (SELECT DISTINCT NombreDia_D FROM Dias INNER JOIN UsuariosXDiasXHorarios ON CodDias_UXDXH = CodDias_D WHERE CodUsuarios_UXDXH = CodUsuarios_U) AS Subquery1 FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') AS NombreDia_D, STUFF((SELECT ',' + Descripcion_H  FROM (SELECT DISTINCT Descripcion_H FROM Horarios INNER JOIN UsuariosXDiasXHorarios ON CodHorarios_UXDXH = CodHorarios_H WHERE CodUsuarios_UXDXH = CodUsuarios_U) AS Subquery2 FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') AS Descripcion_H FROM Usuarios INNER JOIN UsuariosXDiasXHorarios ON CodUsuarios_UXDXH = CodUsuarios_U INNER JOIN Rubros ON CodRubros_U = CodRubros_R INNER JOIN Provincias ON CodProvincias_U = CodProvincias_P INNER JOIN Localidades ON CodProvincias_U = CodProvincias_L AND CodLocalidades_U = CodLocalidades_L WHERE CodTipoUsuario_U = 2 AND Estado_U = 1 AND CodProvincias_U ='" + codProvincia + "' GROUP BY CodUsuarios_U, Clave_U, Descripcion_R, Nombre_U, Apellido_U, DNI_U, Genero_U, Telefono_U, Email_U, Direccion_U, Nacionalidad_U, Nombre_P, Nombre_L ORDER BY CodUsuarios_U;");
            return tabla;
        }

        public int eliminarEmpleado(Usuarios usu)     // Elimina la Sucursal de la Base de Datos
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEmpleadoEliminar(ref comando, usu);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarUsuario");
        }

        public int agregarEmpleado(Usuarios usu)    // Agrega la Sucursal a la Base de Datos
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEmpleadoAgregar(ref comando, usu);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarUsuario");
        }

        private void ArmarParametrosEmpleadoEliminar(ref SqlCommand Comando, Usuarios usu)  //  Configura el parametro necesario para eliminar la Sucursal
        {                                                                                   // en este caso, el Id ingresado
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@CODUSUARIOS", SqlDbType.Char);
            SqlParametros.Value = usu.CodUsuarios_U1;
        }

        private void ArmarParametrosEmpleadoAgregar(ref SqlCommand Comando, Usuarios usu)   // Configura el parametro necesario para agregar la Sucursal
        {                                                                                   // agrega el Nombre, Descripcion, Provincia y Direccion.
            SqlParameter SqlParametros = new SqlParameter();                               // No esta incluido el ID porque se agrega automaticamente con otra funcion 
            SqlParametros = Comando.Parameters.Add("@CODUSUARIOS", SqlDbType.Char);
            SqlParametros.Value = usu.CodUsuarios_U1;
            SqlParametros = Comando.Parameters.Add("@CODRUBROS", SqlDbType.Char);
            SqlParametros.Value = usu.CodRubros_U1;
            SqlParametros = Comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar);
            SqlParametros.Value = usu.Nombre_U1;
            SqlParametros = Comando.Parameters.Add("@APELLIDO", SqlDbType.VarChar);
            SqlParametros.Value = usu.Apellido_U1;
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.VarChar);
            SqlParametros.Value = usu.DNI_U1;
            SqlParametros = Comando.Parameters.Add("@GENERO", SqlDbType.VarChar);
            SqlParametros.Value = usu.Genero_U1;
            SqlParametros = Comando.Parameters.Add("@TELEFONO", SqlDbType.Char);
            SqlParametros.Value = usu.Telefono_U1;
            SqlParametros = Comando.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            SqlParametros.Value = usu.Email_U1;
            SqlParametros = Comando.Parameters.Add("@DIRECCION", SqlDbType.VarChar);
            SqlParametros.Value = usu.Direccion_U1;
            SqlParametros = Comando.Parameters.Add("@NACIONALIDAD", SqlDbType.Char);
            SqlParametros.Value = usu.Nacionalidad_U1;
            SqlParametros = Comando.Parameters.Add("@CODLOCALIDADES", SqlDbType.Char);
            SqlParametros.Value = usu.CodLocalidades_U1;
            SqlParametros = Comando.Parameters.Add("@CODPROVINCIAS", SqlDbType.VarChar);
            SqlParametros.Value = usu.CodProvincias_U1;
            SqlParametros = Comando.Parameters.Add("@CLAVE", SqlDbType.VarChar);
            SqlParametros.Value = usu.Clave_U1;
        }


        public int modificarEmpleado(Usuarios usu)    // Agrega la Sucursal a la Base de Datos
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEmpleadoModificar(ref comando, usu);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spActualizarUsuario");
        }

        private void ArmarParametrosEmpleadoModificar(ref SqlCommand Comando, Usuarios usu)   // Configura el parametro necesario para agregar la Sucursal
        {                                                                                   // agrega el Nombre, Descripcion, Provincia y Direccion.
            SqlParameter SqlParametros = new SqlParameter();                               // No esta incluido el ID porque se agrega automaticamente con otra funcion 
            SqlParametros = Comando.Parameters.Add("@CODUSUARIOS", SqlDbType.Char);
            SqlParametros.Value = usu.CodUsuarios_U1;
            SqlParametros = Comando.Parameters.Add("@CODRUBROS", SqlDbType.Char);
            SqlParametros.Value = usu.CodRubros_U1;
            SqlParametros = Comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar);
            SqlParametros.Value = usu.Nombre_U1;
            SqlParametros = Comando.Parameters.Add("@APELLIDO", SqlDbType.VarChar);
            SqlParametros.Value = usu.Apellido_U1;
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.VarChar);
            SqlParametros.Value = usu.DNI_U1;
            SqlParametros = Comando.Parameters.Add("@GENERO", SqlDbType.VarChar);
            SqlParametros.Value = usu.Genero_U1;
            SqlParametros = Comando.Parameters.Add("@TELEFONO", SqlDbType.Char);
            SqlParametros.Value = usu.Telefono_U1;
            SqlParametros = Comando.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            SqlParametros.Value = usu.Email_U1;
            SqlParametros = Comando.Parameters.Add("@DIRECCION", SqlDbType.VarChar);
            SqlParametros.Value = usu.Direccion_U1;
            SqlParametros = Comando.Parameters.Add("@NACIONALIDAD", SqlDbType.Char);
            SqlParametros.Value = usu.Nacionalidad_U1;
            SqlParametros = Comando.Parameters.Add("@CODLOCALIDAD", SqlDbType.Char);
            SqlParametros.Value = usu.CodLocalidades_U1;
            SqlParametros = Comando.Parameters.Add("@CODPROVINCIA", SqlDbType.VarChar);
            SqlParametros.Value = usu.CodProvincias_U1;
            SqlParametros = Comando.Parameters.Add("@CLAVE", SqlDbType.VarChar);
            SqlParametros.Value = usu.Clave_U1;
        }
    }
}
