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
    public class DatoAMBLClientes
    {
        AccesoDatos ds = new AccesoDatos();

        public Boolean existeCliente(Clientes cli)     // Verifica si la Sucursal existe en la Base de Datos
        {
            String consulta = "SELECT * from Clientes WHERE NombreEmpresa_C='" + cli.NombreEmpresa_C1 +  "' OR RazonSocial_C='" + cli.RazonSocial_C1 + "' OR Telefono_C='" + cli.Telefono_C1 + "' OR Email_C='" + cli.Email_C1 + "'";
            return ds.existe(consulta);
        }
        public bool existeCliFilNom(string Nombre)
        {
            String consulta = ("SELECT CodEmpresas_C, NombreEmpresa_C, RazonSocial_C, Telefono_C, Email_C, Direccion_C, Nombre_P, Nombre_L FROM Clientes INNER JOIN Localidades ON CodLocalidades_L = CodLocalidades_C INNER JOIN Provincias ON CodProvincias_P = CodProvincias_C WHERE Estado_C = 1 AND NombreEmpresa_C LIKE'[" + Nombre + "]%';");
            Console.WriteLine("SQL Query: " + consulta);

            // Execute the query and log the result
            bool exists = ds.existe(consulta);
            Console.WriteLine("Exists: " + exists);

            return exists;
        }
        public DataTable getTablaCliFilNom(string Nombre)
        {
            DataTable tabla = ds.ObtenerTabla("Clientes", "SELECT CodEmpresas_C, NombreEmpresa_C, RazonSocial_C, Telefono_C, Email_C, Direccion_C, Nombre_P, Nombre_L FROM Clientes INNER JOIN Localidades ON CodLocalidades_L = CodLocalidades_C INNER JOIN Provincias ON CodProvincias_P = CodProvincias_C WHERE Estado_C = 1 AND NombreEmpresa_C LIKE'[" + Nombre + "]%';");
            return tabla;
        }

        public Boolean existeCodEmpresa(Clientes cli)     // Verifica si la Sucursal existe en la Base de Datos
        {
            String consulta = "SELECT * FROM Clientes WHERE CodEmpresas_C='" + cli.CodEmpresas_C1 + "'";
            return ds.existe(consulta);
        }
        public DataTable getTablaProvFiltradas(string codProvincia)
        {
            DataTable tabla = ds.ObtenerTabla("Clientes", "SELECT CodEmpresas_C, NombreEmpresa_C, RazonSocial_C, Telefono_C, Email_C, Direccion_C, Nombre_P, Nombre_L FROM Clientes INNER JOIN Localidades ON CodLocalidades_L = CodLocalidades_C INNER JOIN Provincias ON CodProvincias_P = CodProvincias_C WHERE Estado_C = 1 and CodProvincia_C = '" + codProvincia + "'");
            return tabla;
        }
        
        public DataTable getTablaClientes()       // Trae la tabla con todas los Clientes
        {
            DataTable tabla = ds.ObtenerTabla("Clientes", "SELECT CodEmpresas_C, NombreEmpresa_C, RazonSocial_C, Telefono_C, Email_C, Direccion_C, Nombre_P, Nombre_L FROM Clientes INNER JOIN Localidades ON CodLocalidades_L = CodLocalidades_C INNER JOIN Provincias ON CodProvincias_P = CodProvincias_C WHERE Estado_C = 1");
            return tabla;
        }

        public DataTable getTablaClientesFiltradas(string consulta)       // Trae la tabla con los filtros
        {
            DataTable tabla = ds.ObtenerTabla("Clientes", consulta);
            return tabla;
        }

        public DataTable getTablaClientesFiltrados(string codProvincia_F, string codLocalidad_F)
        {
            DataTable tabla = ds.ObtenerTabla("Clientes", "SELECT CodEmpresas_C, NombreEmpresa_C, RazonSocial_C, Telefono_C, Email_C, Direccion_C, Nombre_P, Nombre_L FROM Clientes INNER JOIN Localidades ON CodLocalidades_L = CodLocalidades_C INNER JOIN Provincias ON CodProvincias_P = CodProvincias_C WHERE CodProvincias_C ='"+ codProvincia_F + "'"+ "AND CodLocalidades_C='" + codLocalidad_F + "'");
            return tabla;
        }

        public DataTable getTablaCliPorCodEmpresa(string codEmpresa)       // Trae la tabla con los filtros
        {
            DataTable tabla = ds.ObtenerTabla("Clientes", "SELECT CodEmpresas_C, NombreEmpresa_C, RazonSocial_C, Telefono_C, Email_C, Direccion_C, Nombre_P, Nombre_L FROM Clientes INNER JOIN Localidades ON CodLocalidades_L = CodLocalidades_C INNER JOIN Provincias ON CodProvincias_P = CodProvincias_C WHERE Estado_C = 1 AND CodEmpresas_C='"+ codEmpresa+"'");
            return tabla;
        }

        public int eliminarCliente(Clientes cli)     // Elimina la Sucursal de la Base de Datos
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosClienteEliminar(ref comando, cli);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarCliente");
        }

        public int agregarCliente(Clientes cli)    // Agrega la Sucursal a la Base de Datos
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosClienteAgregar(ref comando, cli);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarCliente");
        }

        public int modificarCliente(Clientes cli)    // Agrega la Sucursal a la Base de Datos
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosClienteModificar(ref comando, cli);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spActualizarCliente");
        }

        private void ArmarParametrosClienteEliminar(ref SqlCommand Comando, Clientes cli)  //  Configura el parametro necesario para eliminar la Sucursal
        {                                                                                   // en este caso, el Id ingresado
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@CODEMPRESAS", SqlDbType.Char);
            SqlParametros.Value = cli.CodEmpresas_C1;
        }

        private void ArmarParametrosClienteAgregar(ref SqlCommand Comando, Clientes cli)   // Configura el parametro necesario para agregar la Sucursal
        {                                                                                   // agrega el Nombre, Descripcion, Provincia y Direccion.
            SqlParameter SqlParametros = new SqlParameter();                               // No esta incluido el ID porque se agrega automaticamente con otra funcion 
            SqlParametros = Comando.Parameters.Add("@CODEMPRESAS_C", SqlDbType.Char);
            SqlParametros.Value = cli.CodEmpresas_C1;
            SqlParametros = Comando.Parameters.Add("@NOMBREEMPRESA_C", SqlDbType.VarChar);
            SqlParametros.Value = cli.NombreEmpresa_C1;
            SqlParametros = Comando.Parameters.Add("@RAZONSOCIAL_C", SqlDbType.VarChar);
            SqlParametros.Value = cli.RazonSocial_C1;
            SqlParametros = Comando.Parameters.Add("@TELEFONO_C", SqlDbType.VarChar);
            SqlParametros.Value = cli.Telefono_C1;
            SqlParametros = Comando.Parameters.Add("@EMAIL_C", SqlDbType.Char);
            SqlParametros.Value = cli.Email_C1;
            SqlParametros = Comando.Parameters.Add("@DIRECCION_C", SqlDbType.Char);
            SqlParametros.Value = cli.Direccion_C1;
            SqlParametros = Comando.Parameters.Add("@CODLOCALIDADES_U", SqlDbType.VarChar);
            SqlParametros.Value = cli.CodLocalidades_C1;
            SqlParametros = Comando.Parameters.Add("@CODPROVINCIAS_U", SqlDbType.VarChar);
            SqlParametros.Value = cli.CodProvincias_C1;
        }

        private void ArmarParametrosClienteModificar(ref SqlCommand Comando, Clientes cli)   // Configura el parametro necesario para agregar la Sucursal
        {                                                                                   // agrega el Nombre, Descripcion, Provincia y Direccion.
            SqlParameter SqlParametros = new SqlParameter();                               // No esta incluido el ID porque se agrega automaticamente con otra funcion 
            SqlParametros = Comando.Parameters.Add("@CODEMPRESA", SqlDbType.Char);
            SqlParametros.Value = cli.CodEmpresas_C1;
            SqlParametros = Comando.Parameters.Add("@NOMBREEMPRESA", SqlDbType.VarChar);
            SqlParametros.Value = cli.NombreEmpresa_C1;
            SqlParametros = Comando.Parameters.Add("@RAZONSOCIAL", SqlDbType.VarChar);
            SqlParametros.Value = cli.RazonSocial_C1;
            SqlParametros = Comando.Parameters.Add("@TELEFONO", SqlDbType.VarChar);
            SqlParametros.Value = cli.Telefono_C1;
            SqlParametros = Comando.Parameters.Add("@EMAIL", SqlDbType.Char);
            SqlParametros.Value = cli.Email_C1;
            SqlParametros = Comando.Parameters.Add("@DIRECCION", SqlDbType.Char);
            SqlParametros.Value = cli.Direccion_C1;
            SqlParametros = Comando.Parameters.Add("@CODLOCALIDAD", SqlDbType.VarChar);
            SqlParametros.Value = cli.CodLocalidades_C1;
            SqlParametros = Comando.Parameters.Add("@CODPROVINCIA", SqlDbType.VarChar);
            SqlParametros.Value = cli.CodProvincias_C1;
        }
    }
}
