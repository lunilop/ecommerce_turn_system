using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;
using System.Drawing;

namespace Vistas
{
    public partial class Inicio : System.Web.UI.Page
    {
        NegocioUsuarios negu = new NegocioUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btn_Ingresar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Usuario.Text) && !string.IsNullOrEmpty(txt_Clave.Text))
            {
                // Obtiene la información del usuario
                Usuarios usu = negu.ExisteUsuario(txt_Usuario.Text);
                string Clave = txt_Clave.Text;;

                // Verifica si el usuario fue encontrado
                if (usu.CodTipoUsuario_u1 == "0")
                {
                    lblMessage.Text = "Usuario no encontrado";
                    lblMessage.ForeColor = Color.Red;
                    LimpiarCampos();
                }
                else
                {
                    // Verifica las credenciales del usuario
                    if (usu.Clave_U1 == Clave)
                    {
                        Session["NombreUsu"] = usu.Nombre_U1;
                        Session["CodUsu"] = usu.CodUsuarios_U1;

                        if (usu.CodTipoUsuario_u1.Trim() == "1")
                        {
                            lblMessage.Text = "Usuario Jefe";
                            Response.Redirect("AMBL_Empleados.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                        else if (usu.CodTipoUsuario_u1.Trim() == "2")
                        {
                            lblMessage.Text = "Usuario Empleado";
                            Response.Redirect("Visualizacion_Turnos.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Usuario o contraseña incorrecta";
                        lblMessage.ForeColor = Color.Red;
                        LimpiarCampos();
                    }
                }
            }
            else
            {
                lblMessage.Text = "Complete todos los campos correctamente";
                lblMessage.ForeColor = Color.Red;
                LimpiarCampos();
            }
        }

        public void LimpiarCampos()
        {
            txt_Usuario.Text = "";
            txt_Clave.Text = "";
           // lblMessage.Text = "";
        }
        
    }
}

