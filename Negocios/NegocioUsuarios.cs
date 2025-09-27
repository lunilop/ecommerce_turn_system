using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegocioUsuarios
    {
        DatosUsuarios dao = new DatosUsuarios();

        public Usuarios ExisteUsuario(string cod)
        {
            Usuarios usu = new Usuarios { CodUsuarios_U1 = cod };
            if (dao.existeUsuario(usu))
            {
                return dao.getTablaUsuarios(usu);
            }
            else
            {
                usu.CodTipoUsuario_u1 = "0"; // User not found
                return usu;
            }
        }

        public DataTable getTablaUsuarios()
        {
            return dao.getUsuarios();
        }
    }
}


