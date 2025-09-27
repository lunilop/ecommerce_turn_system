using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DatosUsuarios
    {
        AccesoDatos ds = new AccesoDatos();

        public Boolean existeUsuario(Usuarios usu)
        {
            String consulta = "Select * from Usuarios where CodUsuarios_U='" + usu.CodUsuarios_U1 + "'";
            return ds.existe(consulta);
        }

        public Usuarios getTablaUsuarios(Usuarios usu)
        {
            DataTable tabla = ds.ObtenerTabla("Usuarios", "Select * from Usuarios where CodUsuarios_U='" + usu.CodUsuarios_U1 + "'");
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                usu.CodUsuarios_U1 = row["CodUsuarios_U"].ToString();
                usu.CodRubros_U1 = row["CodRubros_U"].ToString();
                usu.Nombre_U1 = row["Nombre_U"].ToString();
                usu.Apellido_U1 = row["Apellido_U"].ToString();
                usu.DNI_U1 = row["DNI_U"].ToString();
                usu.Genero_U1 = row["Genero_U"].ToString();
                usu.Telefono_U1 = row["Telefono_U"].ToString();
                usu.Email_U1 = row["Email_U"].ToString();
                usu.Nacionalidad_U1 = row["Nacionalidad_U"].ToString();
                usu.Direccion_U1 = row["Direccion_U"].ToString();
                usu.CodLocalidades_U1 = row["CodLocalidades_U"].ToString();
                usu.CodProvincias_U1 = row["CodProvincias_U"].ToString();
                usu.Clave_U1 = row["Clave_U"].ToString();
                usu.CodTipoUsuario_u1 = row["CodTipoUsuario_u"].ToString();
                usu.Estado_u1 = Convert.ToBoolean(row["Estado_u"].ToString());
            }
            else
            {
                usu.CodTipoUsuario_u1 = "0"; // Usuario no encontrado
            }
            return usu;
        }

        public DataTable getUsuarios()
        {
            DataTable tabla = ds.ObtenerTabla("Usuarios","Select * from Usuarios");
            return tabla;
        }

        public DataTable getTablaUsuariosFiltradas(string CodRubros)   // Trae la tabla con todas las Localidades
        {
            DataTable tabla = ds.ObtenerTabla("Usuarios", "SELECT CodUsuarios_U, Nombre_U FROM Usuarios WHERE CodTipoUsuario_U = '2' AND CodRubros_U ='" + CodRubros + "'");
            return tabla;
        }
    }
}

