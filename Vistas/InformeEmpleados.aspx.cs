using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using System.Data;
using System.Drawing;


namespace Vistas
{
    public partial class InformesEmpleados : System.Web.UI.Page
    {
        NegocioInformeEmpleado ns = new NegocioInformeEmpleado();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                if (Session["NombreUsu"] != null)
                {
                    string nombreUsuario = Session["NombreUsu"].ToString();
                    lbl_NombreUsuario.Text = "Bienvenido " + nombreUsuario;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                CargarTipoUsuarios();
            }

        }

        private void CargarTipoUsuarios()
         {
             Inicio_ddl(ddlusuario);
             DataTable tipo = ns.getTipoUsu();
             foreach (DataRow row in tipo.Rows)
             {
                 ddlusuario.Items.Add(new ListItem(row["Descripcion_TU"].ToString(), row["CodTipoUsuario_TU"].ToString()));
             }
         }


         public void Inicio_ddl(DropDownList ddl)
         {
             ddl.Items.Clear(); // Limpiar elementos existentes
             ddl.Items.Add(new ListItem("--Seleccionar--", "")); // Agregar el item de selección
         }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string tipoUsuario = ddlusuario.SelectedValue;
            string genero = ddlGenero.SelectedValue;

            if (!string.IsNullOrEmpty(tipoUsuario) && tipoUsuario != "--Seleccionar--" &&
                !string.IsNullOrEmpty(genero) && genero != "--Seleccionar--")
            {
                gvinforme.Visible = true;
                gvinforme.DataSource = ns.getTablaEmpFiltrada(tipoUsuario, genero);
                gvinforme.DataBind();

                decimal dtPorcentaje = ns.getPorcentajePorTipoGenero(tipoUsuario, genero);
                string mensaje = ObtenerMensajePorcentaje(ddlGenero.SelectedItem.Text, ddlusuario.SelectedItem.Text, dtPorcentaje);
                lblPorcentaje.Text = mensaje;
                lblPorcentaje.ForeColor = ObtenerColorPorcentaje(ddlGenero.SelectedItem.Text, ddlusuario.SelectedItem.Text);

                Limpiar();
            }
            else
            {
                lblPorcentaje.Text = "Seleccione todos los filtros.";
                lblPorcentaje.ForeColor = Color.Red;
                gvinforme.Visible = false;
                Limpiar();
            }
        }


        private string ObtenerMensajePorcentaje(string generoDescripcion, string tipoDescripcion, decimal porcentaje)
        {
            if (generoDescripcion.ToLower().Contains("masculino") && tipoDescripcion.ToLower().Contains("gerente"))
                return $"Porcentaje de Gerentes Masculinos: {porcentaje}%";
            if (generoDescripcion.ToLower().Contains("femenino") && tipoDescripcion.ToLower().Contains("gerente"))
                return $"Porcentaje de Gerentes Femeninos: {porcentaje}%";
            if (generoDescripcion.ToLower().Contains("otros") && tipoDescripcion.ToLower().Contains("gerente"))
                return $"Porcentaje de Gerentes Otros: {porcentaje}%";
            if (generoDescripcion.ToLower().Contains("masculino") && tipoDescripcion.ToLower().Contains("empleado"))
                return $"Porcentaje Empleados Masculinos: {porcentaje}%";
            if (generoDescripcion.ToLower().Contains("femenino") && tipoDescripcion.ToLower().Contains("empleado"))
                return $"Porcentaje Empleados Femeninos: {porcentaje}%";
            if (generoDescripcion.ToLower().Contains("otros") && tipoDescripcion.ToLower().Contains("empleado"))
                return $"Porcentaje Empleados Otros: {porcentaje}%";

            return "No se encontró información para los filtros seleccionados.";
        }

        private Color ObtenerColorPorcentaje(string generoDescripcion, string tipoDescripcion)
        {
            if (generoDescripcion.ToLower().Contains("masculino") && tipoDescripcion.ToLower().Contains("gerente"))
                return Color.Green;
            if (generoDescripcion.ToLower().Contains("femenino") && tipoDescripcion.ToLower().Contains("gerente"))
                return Color.DarkViolet;
            if (generoDescripcion.ToLower().Contains("otros") && tipoDescripcion.ToLower().Contains("gerente"))
                return Color.OrangeRed;
            if (generoDescripcion.ToLower().Contains("masculino") && tipoDescripcion.ToLower().Contains("empleado"))
                return Color.ForestGreen;
            if (generoDescripcion.ToLower().Contains("femenino") && tipoDescripcion.ToLower().Contains("empleado"))
                return Color.DarkViolet;
            if (generoDescripcion.ToLower().Contains("otros") && tipoDescripcion.ToLower().Contains("empleado"))
                return Color.Orange;

            return Color.Red;
        }

        public void Limpiar()
        {
            ddlGenero.SelectedIndex = 0;
            ddlusuario.SelectedIndex = 0;
        }

    }
}