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
    public class NegocioAMBLEmpleados
    {
        DatoAMBLEmpleados dato = new DatoAMBLEmpleados();
        DatosRubros rub = new DatosRubros();
        DatosProvincias_Localidades provloc = new DatosProvincias_Localidades();
        DatosDias_Horarios diahora = new DatosDias_Horarios();

        DatosUsuarios dus = new DatosUsuarios();
        DatosUsuariosXDiasXHorarios dudh = new DatosUsuariosXDiasXHorarios();

        Usuarios usu = new Usuarios();
        UsuariosXDiasXHorarios udh = new UsuariosXDiasXHorarios();

        public DataTable getTablaEmp()     // Obtiene una tabla con todas las Rubros.
        {
            return dato.getTablaEmpleado();
        }

        public DataTable getTablaRub()     // Obtiene una tabla con todas las Rubros.
        {
            return rub.getTablaRubros();
        }

        public DataTable getTablaLocFiltradas(string CodProvincias)     // Obtiene una tabla con todas las Localidades.
        {
            return provloc.getTablaLocalidadesFiltradas(CodProvincias);
        }

        public DataTable getTablaProv()     // Obtiene una tabla con todas las provincias.
        {
            return provloc.getTablaProvincias();
        }

        public DataTable getTablaDia()     // Obtiene una tabla con todas las provincias.
        {
            return diahora.getTablaDias();
        }

        public DataTable getTablaHora()     // Obtiene una tabla con todas las provincias.
        {
            return diahora.getTablaHorarios();
        }
        public bool existeApellido(string apellido)
        {
            return dato.existeEmpFilAlp(apellido);
        }
        public DataTable getTablaEmpPorCodUsu(string cod)     // Obtiene una tabla con todas las Localidades.
        {
            return dato.getTablaEmpPorCodUsu(cod);
        }
        public DataTable FiltrarApellido(string apellido)     // Obtiene una tabla con todas las Localidades.
        {
            return dato.getTablaEmpFilAlp(apellido);
        }

        public DataTable FiltrarProv(string CodProvincias)     // Obtiene una tabla con todas las Localidades.
        {
            return dato.getTablaProvFiltradas(CodProvincias);
        }

        public bool existeEmpleado(string cod)
        {
            usu.CodUsuarios_U1 = cod;

            return dato.existeEmpleado(usu);
        }
 

        public bool eliminarEmpleado(string cod)    // Elimina la sucursal de la base de datos.
        {
            usu.CodUsuarios_U1 = cod;
            udh.CodUsuarios_UXDXH1 = cod;

            int op = dato.eliminarEmpleado(usu);
            int op1 = dudh.eliminarUsuXDiaXHora(udh);

            if (op == 1 && op1 == 1)
                return true;
            else
                return false;
        }

        public bool eliminarUsuxDiaxHora(string cod)
        {
            udh.CodUsuarios_UXDXH1 = cod;

            int op1 = dudh.eliminarDUsuXDiaXHora(udh);

            if (op1 == 1)
                return true;
            else
                return false;
        }

        public bool agregarEmpleado(string codUsuario, string clave, string rubro, string nombre, 
            string apellido, string dni, string genero, string telefono, string email, 
            string direccion, string nacionalidad, string codProvincia, string codLocalidad)   // Agrega la sucursal a la base de datos.
        {
            int cantFilas = 0;
            usu.CodUsuarios_U1 = codUsuario;
            usu.Clave_U1 = clave;
            usu.CodRubros_U1 = rubro;
            usu.Nombre_U1 = nombre;
            usu.Apellido_U1 = apellido;
            usu.DNI_U1 = dni;
            usu.Genero_U1 = genero;
            usu.Telefono_U1 = telefono;
            usu.Email_U1 = email;
            usu.Direccion_U1 = direccion;
            usu.Nacionalidad_U1 = nacionalidad;
            usu.CodProvincias_U1 = codProvincia;
            usu.CodLocalidades_U1 = codLocalidad;
            
            if (dus.existeUsuario(usu) == false)
            {
                cantFilas = dato.agregarEmpleado(usu);
            }
            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public bool agregarUsuxDiaxHora(string codDias, string codHorarios, string codUsuarios)
        {
            int cantFilas = 0;
            udh.CodDias_UXDXH1 = codDias;
            udh.CodHorarios_UXDXH1 = codHorarios;
            udh.CodUsuarios_UXDXH1 = codUsuarios;

            cantFilas = dudh.agregarUsuXDiaXHora(udh);
            
            if (cantFilas == 1)
                return true;
            else
                return false;
        }



        public bool modificarEmpleado(string codUsuario, string clave, string rubro,string nombre,
                                      string apellido, string dni, string genero, string telefono,
                                      string email, string direccion,string nacionalidad,
                                      string codLocalidad, string codProvincia)
        {
            int cantFilas = 0;
            usu.CodUsuarios_U1 = codUsuario;
            usu.Clave_U1 = clave;
            usu.CodRubros_U1 = rubro;
            usu.Nombre_U1 = nombre;
            usu.Apellido_U1 = apellido;
            usu.DNI_U1 = dni;
            usu.Genero_U1 = genero;
            usu.Telefono_U1 = telefono;
            usu.Email_U1 = email;
            usu.Direccion_U1 = direccion;
            usu.Nacionalidad_U1 = nacionalidad;
            usu.CodLocalidades_U1 = codLocalidad;
            usu.CodProvincias_U1 = codProvincia;

            cantFilas = dato.modificarEmpleado(usu);

            if (cantFilas == 1)
                return true;
            else
                return false;
        }


        public bool modificarUsuxDiaxHora(string codDias, string codHorarios, string codUsuarios)
        {
            int cantFilas = 0;
            udh.CodDias_UXDXH1 = codDias;
            udh.CodHorarios_UXDXH1 = codHorarios;
            udh.CodUsuarios_UXDXH1 = codUsuarios;

            cantFilas = dudh.modificarUsuXDiaXHora(udh);

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

    }
}

