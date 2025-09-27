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
    public class DatosDias_Horarios
    {
        AccesoDatos ds = new AccesoDatos();

        public Boolean existeDias(Dias di)
        {
            String consulta = "SELECT * FROM [Dias] WHERE [CodDias_D]='[" + di.CodDias_D1 + "]'";
            return ds.existe(consulta);
        }

        public DataTable getTablaDias()
        {
            DataTable tabla = ds.ObtenerTabla("Dias", "SELECT [CodDias_D], [NombreDia_D] FROM [Dias]");
            return tabla;
        }


        public Boolean existeHorarios(Horarios hora)
        {
            String consulta = "SELECT * FROM [Horarios] WHERE [CodHorarios_H]='[" + hora.CodHorarios_H1 + "]'";
            return ds.existe(consulta);
        }

        public DataTable getTablaHorarios()
        {
            DataTable tabla = ds.ObtenerTabla("Horarios", "SELECT [CodHorarios_H], [Descripcion_H] FROM [Horarios]");
            return tabla;
        }
    }
}
