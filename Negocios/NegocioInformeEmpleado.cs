using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;


namespace Negocios
{
    public class NegocioInformeEmpleado
    {
        DatosInformeEmpleado dato = new DatosInformeEmpleado();

        public Decimal getPorcentajePorTipoGenero(string tipoUsuario, string genero)
        {
            return dato.ObtenerPorcentajePorTipoGenero(tipoUsuario, genero);
        }

        public DataTable getTablaEmpFiltrada(string tipoUsuario, string genero)
        {
            return dato.ObtenerDatosFiltrados(tipoUsuario, genero);
        }

        public DataTable getGeneros()
        {
            return dato.getGeneros();
        }

        public DataTable getTipoUsu()
        {
            return dato.getTipoUsuarios();
        }
    }
}
