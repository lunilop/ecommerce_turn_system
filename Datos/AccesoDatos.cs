using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class AccesoDatos
    {
        String rutaBDeCommerce = "Data Source=localhost\\sqlexpress;Initial Catalog=eCommerce;Integrated Security=True";

        public AccesoDatos() { }

        private SqlConnection ObtenerConexion()    // Crea y abre una conexion a la Base de Datos
        {
            SqlConnection cn = new SqlConnection(rutaBDeCommerce);
            try
            {
                cn.Open();                      // Devuelve la Conexion
                return cn;
            }
            catch (Exception ex) { return null; }
        }

        private SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)   // Crea un adaptador de datos para ejecutar la consulta SQL proporcionada    
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;                     //Devuelve la Intancia del Adaptador
            }
            catch (Exception ex) { return null; }
        }

        public DataTable ObtenerTabla(String NombreTabla, String Sql)   // Ejecuta una consulta SQL y devuelve los resultados en un DataTable.
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)   //  Ejecuta un procedimiento almacenado con los parámetros proporcionados.
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        public Boolean existe(String consulta)      //  Verifica si existen datos en la base de datos que cumplen con la consulta proporcionada.
        {
            Boolean estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }

        public DataTable EjecutarProcedimientoConParametros(string nombreSP, SqlParameter[] parametros)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(nombreSP, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parametros);
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }
            return tabla;
        }

        /*public DataTable EjecutarProcedimientoConParametros(string procedimiento, SqlParameter[] parametros)
        {
            using (SqlConnection Conexion = ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand(procedimiento, Conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(parametros);
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);
                        return dt;
                    }
                }
            }
        }*/
    }
}

