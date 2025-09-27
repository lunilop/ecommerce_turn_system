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
    public partial class Visualizacion_Turnos : System.Web.UI.Page
    {
        NegocioVisualizacionTurnos ns = new NegocioVisualizacionTurnos();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                if (Session["NombreUsu"] != null)
                {
                    string nombreUsuario = Session["NombreUsu"].ToString();
                    lbl_NombreUsuario.Text = "Bienvenido, " + nombreUsuario; // Suponiendo que tienes una etiqueta para mostrar el nombre
                }
                else
                {
                    Response.Redirect("Login.aspx");// Redirigir al login si no hay usuario en la sesión
                }
                CargarTurnos();
            }
        }

        private void CargarTurnos()
        {
            string CodUsuarios = Session["CodUsu"].ToString();
            grdEmpleadosTurnos.DataSource = ns.getTurnosData(CodUsuarios);
            grdEmpleadosTurnos.DataBind();
        }

        private void CargarEstados(DropDownList ddl)
        {
            ddl.Items.Clear(); // Limpiar elementos existentes
            ddl.Items.Add(new ListItem("--Seleccionar--", "")); // Agregar el item de selección
            DataTable estados = ns.getEstadosData();
            foreach (DataRow row in estados.Rows)
            {
                ddl.Items.Add(new ListItem(row["Descripcion_E"].ToString(), row["CodEstados_E"].ToString()));
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            int mes;
            int ano;

            // Validar y obtener mes y año
            if (int.TryParse(txtMes.Text, out mes) && int.TryParse(txtAno.Text, out ano))
            {
                DataTable turnosFiltrados = ns.FiltrarTurnosPorMes(mes, ano);
                grdEmpleadosTurnos.DataSource = turnosFiltrados;
                grdEmpleadosTurnos.DataBind();
            }
        }

        protected void grdEmpleadosTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdEmpleadosTurnos.EditIndex = e.NewEditIndex;
            CargarTurnos();
        }

        protected void grdEmpleadosTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdEmpleadosTurnos.EditIndex = -1;
            CargarTurnos();
        }

        protected void grdEmpleadosTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList ddlEstados = (DropDownList)e.Row.FindControl("ddl_eit_Estados");
            TextBox txtObservaciones = (TextBox)e.Row.FindControl("txt_eit_Observacion");

            if (ddlEstados != null && txtObservaciones != null)
            {
                txtObservaciones.Enabled = false;
                CargarEstados(ddlEstados);
            }
        }

        protected void ddl_eit_Estados_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlEstados = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlEstados.NamingContainer;
            TextBox txtObservaciones = (TextBox)row.FindControl("txt_eit_Observacion");

            if (ddlEstados.SelectedItem.Text == "Terminado")
            {
                txtObservaciones.Enabled = true;
            }
            else
            {
                txtObservaciones.Text = "";
                txtObservaciones.Enabled = false;
            }
        }

        protected void grdEmpleadosTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String codTurno = ((Label)grdEmpleadosTurnos.Rows[e.RowIndex].FindControl("lbl_eit_CodTurnos")).Text;
            String cliente = ((Label)grdEmpleadosTurnos.Rows[e.RowIndex].FindControl("lbl_eit_Clientes")).Text;
            String dia = ((Label)grdEmpleadosTurnos.Rows[e.RowIndex].FindControl("lbl_eit_Dias")).Text;
            String horario = ((Label)grdEmpleadosTurnos.Rows[e.RowIndex].FindControl("lbl_eit_Horarios")).Text;
            String fecha = ((Label)grdEmpleadosTurnos.Rows[e.RowIndex].FindControl("lbl_eit_Fechas")).Text;
            String codEstado = ((DropDownList)grdEmpleadosTurnos.Rows[e.RowIndex].FindControl("ddl_eit_Estados")).SelectedValue;
            String observacion  = ((TextBox)grdEmpleadosTurnos.Rows[e.RowIndex].FindControl("txt_eit_Observacion")).Text;

            ns.modificarTurno(codTurno, codEstado, observacion);
            grdEmpleadosTurnos.EditIndex = -1;
            CargarTurnos();
        }
    }
}