using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turnos
    {
		private String CodTurnos_T;
		private String CodEmpresas_T;
		private String CodRubros_T;
		private String CodUsuarios_T;
		private String CodDias_T;
		private String CodHorarios_T;
		private DateTime CodFechas_T;
		private String Observaciones_T;
		private String CodEstados_T;
        private bool Estado_T;

        public Turnos() { }

        public string CodTurnos_T1 { get => CodTurnos_T; set => CodTurnos_T = value; }
        public string CodEmpresas_T1 { get => CodEmpresas_T; set => CodEmpresas_T = value; }
        public string CodRubros_T1 { get => CodRubros_T; set => CodRubros_T = value; }
        public string CodUsuarios_T1 { get => CodUsuarios_T; set => CodUsuarios_T = value; }
        public string CodDias_T1 { get => CodDias_T; set => CodDias_T = value; }
        public string CodHorarios_T1 { get => CodHorarios_T; set => CodHorarios_T = value; }
        public DateTime CodFechas_T1 { get => CodFechas_T; set => CodFechas_T = value; }
        public string Observaciones_T1 { get => Observaciones_T; set => Observaciones_T = value; }
        public string CodEstados_T1 { get => CodEstados_T; set => CodEstados_T = value; }
        public bool Estado_T1 { get => Estado_T; set => Estado_T = value; }
    }
}
