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
    public class DatosProvincias_Localidades
    {
        AccesoDatos ds = new AccesoDatos();

        public Boolean existeProvincias(Provincias pro)
        {
            String consulta = "SELECT * FROM [Provincias] WHERE [CodProvincias_P]='[" + pro.CodProvincias_P1 + "]'";
            return ds.existe(consulta);
        }

        public DataTable getTablaProvincias()
        {
            DataTable tabla = ds.ObtenerTabla("Provincias", "SELECT [CodProvincias_P], [Nombre_P] FROM [Provincias]");
            return tabla;
        }



        public Boolean existeLocalidades(Localidades loc)
        {
            String consulta = "SELECT * FROM [Localidades] WHERE [CodLocalidades_L]='[" + loc.CodLocalidades_L1 + "]'";
            return ds.existe(consulta);
        }

        public DataTable getTablaLocalidadesFiltradas(string CodProvincias)   // Trae la tabla con todas las Localidades
        {
            DataTable tabla = ds.ObtenerTabla("Localidades", "SELECT CodLocalidades_L, Nombre_L FROM Localidades WHERE CodProvincias_L= '" + CodProvincias + "'");
            return tabla;
        }
    }
}
