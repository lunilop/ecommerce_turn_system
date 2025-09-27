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
    public class NegocioAMBLClientes
    {
        DatoAMBLClientes dato = new DatoAMBLClientes();
        Clientes cli = new Clientes();
        DatosProvincias_Localidades provloc = new DatosProvincias_Localidades();

        public DataTable getTablaCli()     // Obtiene una tabla con todas las Rubros.
        {
            return dato.getTablaClientes();
        }

        public DataTable getTablaCliFiltradas(string consulta)     // Obtiene una tabla con todas las Rubros.
        {
            return dato.getTablaClientesFiltradas(consulta);
        }

        public bool existeCodEmp(string cod)
        {
            cli.CodEmpresas_C1 = cod;

            return dato.existeCodEmpresa(cli);
        }
        public bool existeNombre(string nombre)
        {
            return dato.existeCliFilNom(nombre);
        }
        public DataTable FiltrarNombre(string Nombre)     // Obtiene una tabla con todas las Localidades.
        {
            return dato.getTablaCliFilNom(Nombre);
        }

        public DataTable getTablaCliPorCodEmp(string codEmpresa)     // Obtiene una tabla con todas las Localidades.
        {
            return dato.getTablaCliPorCodEmpresa(codEmpresa);
        }

        public DataTable getTablaCliFiltrado(string codProvincia_F, string codLocalidad_F)
        {
            return dato.getTablaClientesFiltrados(codProvincia_F, codLocalidad_F);
        }

        public DataTable getTablaLocFiltradas(string CodProvincias)     // Obtiene una tabla con todas las Localidades.
        {
            return provloc.getTablaLocalidadesFiltradas(CodProvincias);
        }

        public DataTable getTablaProv()     // Obtiene una tabla con todas las provincias.
        {
            return provloc.getTablaProvincias();
        }

        public bool eliminarCliente(string cod)    // Elimina la sucursal de la base de datos.
        {
            cli.CodEmpresas_C1 = cod;
            int op = dato.eliminarCliente(cli);
            if (op == 1)
                return true;
            else
                return false;
        }

        public DataTable FiltrarProv(string CodProvincias)     // Obtiene una tabla con todas las Localidades.
        {
            return dato.getTablaProvFiltradas(CodProvincias);
        }
        
        public bool agregarCliente(string codEmpresa, string nombre, string razonSocial, string telefono, string email, string direccion, string codLocalidad, string codProvincia)   // Agrega la sucursal a la base de datos.
        {
            int cantFilas = 0;
            cli.CodEmpresas_C1 = codEmpresa;
            cli.NombreEmpresa_C1 = nombre;
            cli.RazonSocial_C1 = razonSocial;
            cli.Telefono_C1 = telefono;
            cli.Email_C1 = email;
            cli.Direccion_C1 = direccion;
            cli.CodLocalidades_C1 = codLocalidad;
            cli.CodProvincias_C1 = codProvincia;        

            if (dato.existeCliente(cli) == false)
            {
                cantFilas = dato.agregarCliente(cli);
            }
            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public bool modificarCliente(string codEmpresa, string nombre, string razonSocial, string telefono, string email, string direccion, string codLocalidad, string codProvincia)   // Agrega la sucursal a la base de datos.
        {
            int cantFilas = 0;
            cli.CodEmpresas_C1 = codEmpresa;
            cli.NombreEmpresa_C1 = nombre;
            cli.RazonSocial_C1 = razonSocial;
            cli.Telefono_C1 = telefono;
            cli.Email_C1 = email;
            cli.Direccion_C1 = direccion;
            cli.CodLocalidades_C1 = codLocalidad;
            cli.CodProvincias_C1 = codProvincia;

            cantFilas = dato.modificarCliente(cli);

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

    }
}
