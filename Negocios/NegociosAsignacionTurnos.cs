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
    public class NegociosAsignacionTurnos
    {
        DatosAsigancionTurnos dat = new DatosAsigancionTurnos();
        DatoAMBLClientes dc = new DatoAMBLClientes();
        DatosRubros rub = new DatosRubros();
        DatosUsuarios dus = new DatosUsuarios();
        DatosUsuariosXDiasXHorarios dudh = new DatosUsuariosXDiasXHorarios();

        Usuarios usu = new Usuarios();
        Turnos tur = new Turnos();
        UsuariosXDiasXHorarios udh = new UsuariosXDiasXHorarios();


        public DataTable getTablaCli()     // Obtiene una tabla con todas las Rubros.
        {
            return dc.getTablaClientes();
        }

        public DataTable getTablaRub()     // Obtiene una tabla con todas las Rubros.
        {
            return rub.getTablaRubros();
        }

        public DataTable getTablaUsuFiltradas(string CodRubros)     // Obtiene una tabla con todas las Localidades.
        {
            return dus.getTablaUsuariosFiltradas(CodRubros);
        }

        public DataTable getTablaDiaFiltradas(string CodUsuarios)     // Obtiene una tabla con todas las Localidades.
        {
            return dudh.getTablaDiasFiltradas(CodUsuarios);
        }

        public DataTable getTablaHoraFiltradas(string CodUsuarios, string CodDias)     // Obtiene una tabla con todas las Localidades.
        {
            return dudh.getTablaHorariosFiltradas(CodUsuarios, CodDias);
        }

        public bool eliminarTurno(string cod)    // Elimina la sucursal de la base de datos.
        {
            tur.CodTurnos_T1 = cod;

            int op = dat.eliminarTurno(tur);

            if (op == 1)
                return true;
            else
                return false;
        }

        public bool agregarTurno(string codTurno, string codCliente,string rubro, string codUsuario,
            string codDia, string codHora, DateTime codFecha)   // Agrega la sucursal a la base de datos.
        {
            int cantFilas = 0;
            tur.CodTurnos_T1 = codTurno;
            tur.CodEmpresas_T1 = codCliente;
            tur.CodRubros_T1 = rubro;
            tur.CodUsuarios_T1 = codUsuario;
            tur.CodDias_T1 = codDia;
            tur.CodHorarios_T1 = codHora;
            tur.CodFechas_T1 = codFecha;

            if (dat.existeTurno(tur) == false)
            {
                cantFilas = dat.agregarTurno(tur);
            }
            if (cantFilas == 1)
                return true;
            else
                return false;
        }


    }
}
