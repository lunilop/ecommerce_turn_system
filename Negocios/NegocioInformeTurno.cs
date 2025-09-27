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
    public class NegocioInformeTurno
    {
        DatosInformeTurnos dit = new DatosInformeTurnos();

        public DataTable FiltrarTurnosPorEstadoYRangoFechas(string estado, int mesInicio, int anioInicio, int mesFin, int anioFin)
        {
            return dit.FiltrarTurnosPorEstadoYRangoFechas(estado, mesInicio, anioInicio, mesFin, anioFin);
        }

        public decimal ObtenerPorcentajeTurnosPorEstadoYRangoFechas(string estado, int mesInicio, int anioInicio, int mesFin, int anioFin)
        {
            return dit.ObtenerPorcentajeTurnosPorEstadoYRangoFechas(estado, mesInicio, anioInicio, mesFin, anioFin);
        }
    }
}
