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
    public partial class Informes : System.Web.UI.Page
    {
        NegocioInformeTurno ns = new NegocioInformeTurno();
        NegocioVisualizacionTurnos nv = new NegocioVisualizacionTurnos();

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
                CargarEstados();
            }
        }
        private void CargarEstados()
        {
            ddlEstados.Items.Clear(); // Limpiar elementos existentes
            ddlEstados.Items.Add(new ListItem("--Seleccionar--", "")); // Agregar el item de selección
            DataTable tipo = nv.getEstadosData();
            foreach (DataRow row in tipo.Rows)
            {
                ddlEstados.Items.Add(new ListItem(row["Descripcion_E"].ToString(), row["CodEstados_E"].ToString()));
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ddlEstados.SelectedIndex > 0 &&
                 int.TryParse(txtanioinicio.Text, out int anioInicio) &&
                 int.TryParse(txtaniofin.Text, out int anioFin) &&
                 int.TryParse(txtmesinicio.Text, out int mesInicio) &&
                 int.TryParse(txtmesfin.Text, out int mesFin))
            {
                string estado = ddlEstados.SelectedValue;
                string estadoDescripcion = ddlEstados.SelectedItem.Text;

                // Obtener y mostrar los turnos filtrados
                DataTable turnosFiltrados = ns.FiltrarTurnosPorEstadoYRangoFechas(estado, mesInicio, anioInicio, mesFin, anioFin);
                grdEstadoTurno.DataSource = turnosFiltrados;
                grdEstadoTurno.DataBind();

                // Obtener y mostrar el porcentaje de turnos
                decimal porcentajeTurnos = ns.ObtenerPorcentajeTurnosPorEstadoYRangoFechas(estado, mesInicio, anioInicio, mesFin, anioFin);

                if (estadoDescripcion.ToLower().Contains("pendiente"))
                {
                    lbl_Msj_Filtrado.Text = "Turnos Pendientes: " + porcentajeTurnos.ToString("")+ "%";
                    lbl_Msj_Filtrado.ForeColor = Color.OrangeRed;
                }
                else if (estadoDescripcion.ToLower().Contains("terminado"))
                {
                    lbl_Msj_Filtrado.Text = "Turnos Terminados: " + porcentajeTurnos.ToString("")+ "%";
                    lbl_Msj_Filtrado.ForeColor = Color.Green;
                }
                else
                {
                    lbl_Msj_Filtrado.Text = "Seleccione un estado válido.";
                    lbl_Msj_Filtrado.ForeColor = Color.Red;
                }
            }
            else
            {
                lbl_Msj_Filtrado.Text = "Complete todos los campos correctamente.";
                lbl_Msj_Filtrado.ForeColor = Color.Red;
            }
        }


    }
}