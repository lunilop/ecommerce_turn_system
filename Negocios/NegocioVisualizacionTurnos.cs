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
    public class NegocioVisualizacionTurnos
    {
        DatosVisualizacionTurnos dvt = new DatosVisualizacionTurnos();
        Turnos tur = new Turnos();

        public DataTable getTurnosData(string CodUsuarios)     // Obtiene una tabla con todas las Rubros.
        {
            return dvt.getTablaTurnos(CodUsuarios);
        }

        public DataTable getEstadosData()     // Obtiene una tabla con todas las Rubros.
        {
            return dvt.getTablaEstados();
        }

        public DataTable FiltrarTurnosPorMes(int mes, int ano) // Filtra los turnos por mes y año
        {
            return dvt.FiltrarTurnosPorMes(mes, ano);
        }

        public bool modificarTurno(string codTurno, /*string cliente, string dia, string horario, string fecha,*/ string codEstado, string observacion)   // Agrega la sucursal a la base de datos.
        {
            int cantFilas = 0;
            tur.CodTurnos_T1 = codTurno;
            tur.CodEstados_T1 = codEstado;
            tur.Observaciones_T1 = observacion;

            cantFilas = dvt.modificarTurno(tur);

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

    }
}
