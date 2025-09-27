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
    public class DatosRubros
    {
        AccesoDatos ds = new AccesoDatos();

        public Boolean existeRubros(Rubros ru)     // Verifica si el Rubro existe en la Base de Datos
        {
            String consulta = "SELECT * FROM [Rubros] WHERE [CodRubros_R]='[" + ru.CodRubros_R1 + "]'";
            return ds.existe(consulta);
        }

        public DataTable getTablaRubros()       // Trae la tabla con todos los Rubros
        {
            DataTable tabla = ds.ObtenerTabla("Rubros", "SELECT * FROM [Rubros]");
            return tabla;
        }
    }
}
