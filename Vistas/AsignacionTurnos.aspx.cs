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
    public partial class AsignacionTurnos : System.Web.UI.Page
    {
        NegociosAsignacionTurnos ns = new NegociosAsignacionTurnos();

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
                Restaurar();
            }
        }

        private void CargarClientes()
        {
            ddlClientes.Items.Clear(); // Limpiar elementos existentes
            ddlClientes.Items.Add(new ListItem("--Seleccionar--", "")); // Agregar el item de selección

            DataTable clientes = ns.getTablaCli();
            foreach (DataRow row in clientes.Rows)
            {
                ddlClientes.Items.Add(new ListItem(row["NombreEmpresa_C"].ToString(), row["CodEmpresas_C"].ToString()));
            }
        }

        private void CargarRubros()
        {
            ddlRubros.Items.Clear(); // Limpiar elementos existentes
            ddlRubros.Items.Add(new ListItem("--Seleccionar--", "")); // Agregar el item de selección

            DataTable rubros = ns.getTablaRub();
            foreach (DataRow row in rubros.Rows)
            {
                ddlRubros.Items.Add(new ListItem(row["Descripcion_R"].ToString(), row["CodRubros_R"].ToString()));
            }
        }
        private void CargarEmpleados(string CodRubros)
        {
            ddlEmpleados.Items.Clear(); // Limpiar elementos existentes
            ddlEmpleados.Items.Add(new ListItem("--Seleccionar--", "")); // Agregar el item de selección

            DataTable empleados = ns.getTablaUsuFiltradas(CodRubros);
            foreach (DataRow row in empleados.Rows)
            {
                ddlEmpleados.Items.Add(new ListItem(row["Nombre_U"].ToString(), row["CodUsuarios_U"].ToString()));
            }
        }

        private void CargarDias(string CodUsuarios)
        {
            ddlDias.Items.Clear(); // Limpiar elementos existentes
            ddlDias.Items.Add(new ListItem("--Seleccionar--", "")); // Agregar el item de selección

            DataTable dias = ns.getTablaDiaFiltradas(CodUsuarios);
            foreach (DataRow row in dias.Rows)
            {
                ddlDias.Items.Add(new ListItem(row["NombreDia_D"].ToString(), row["CodDias_UXDXH"].ToString()));
            }
        }

        private void CargarHorarios(string CodUsuarios, string CodDias)
        {
            ddlHorarios.Items.Clear(); // Limpiar elementos existentes
            ddlHorarios.Items.Add(new ListItem("--Seleccionar--", "")); // Agregar el item de selección

            DataTable horas = ns.getTablaHoraFiltradas(CodUsuarios, CodDias);
            foreach (DataRow row in horas.Rows)
            {
                ddlHorarios.Items.Add(new ListItem(row["Descripcion_H"].ToString(), row["CodHorarios_UXDXH"].ToString()));
            }
        }

        protected void ddlRubros_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CodRubros = ddlRubros.SelectedValue;

            if (!string.IsNullOrEmpty(CodRubros) && CodRubros != "--Seleccionar--")
            {
                CargarEmpleados(CodRubros);
                ddlEmpleados.Enabled = true;
            }
            else
            {
                ddlEmpleados.Items.Clear();
                ddlEmpleados.Items.Add(new ListItem("--Seleccionar--", ""));
                ddlEmpleados.Enabled = false;
            }
        }

        protected void ddlEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CodUsuarios = ddlEmpleados.SelectedValue;
            if (!string.IsNullOrEmpty(CodUsuarios) && CodUsuarios != "--Seleccionar--")
            {
                CargarDias(CodUsuarios);
                ddlDias.Enabled = true;
            }
            else
            {
                ddlDias.Items.Clear();
                ddlDias.Items.Add(new ListItem("--Seleccionar--", ""));
                ddlDias.Enabled = false;
            }
        }

        protected void ddlDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CodUsuarios = ddlEmpleados.SelectedValue;
            string CodDias = ddlDias.SelectedValue;

            if (!string.IsNullOrEmpty(CodUsuarios) && CodUsuarios != "--Seleccionar--" &&
                !string.IsNullOrEmpty(CodDias) && CodDias != "--Seleccionar--"
                )
            {
                CargarHorarios(CodUsuarios, CodDias);
                ddlHorarios.Enabled = true;
            }
            else
            {
                ddlHorarios.Items.Clear();
                ddlHorarios.Items.Add(new ListItem("--Seleccionar--", ""));
                ddlHorarios.Enabled = false;
            }
        }

        protected void btn_Agregar_Turno_Click(object sender, EventArgs e)
        {
            DateTime fecha = calendarFechas.SelectedDate;

            if (fecha.DayOfWeek == DayOfWeek.Sunday)
            {
                lbl_Msj_Agregar.Text = "No se pueden asignar turnos los domingos.";
                Restaurar();
                return;
            }

            if (ddlDias.SelectedIndex > 0)
            {
                string diaSeleccionado = ddlDias.SelectedItem.Text;
                string diaFecha = fecha.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));

                if (!string.Equals(diaSeleccionado, diaFecha, StringComparison.OrdinalIgnoreCase))
                {
                    lbl_Msj_Agregar.Text = $"El día seleccionado ({diaSeleccionado}) no coincide con el día de la fecha ({diaFecha}).";
                    Restaurar();
                    return;
                }
            }

            bool turnoAgregado = ns.agregarTurno(txt_Turnos_Agregar.Text,
                ddlClientes.SelectedValue.ToString(), ddlRubros.SelectedValue.ToString(),
                ddlEmpleados.SelectedValue.ToString(), ddlDias.SelectedValue.ToString(),
                ddlHorarios.SelectedValue.ToString(), fecha);

            if (turnoAgregado)
            {
                lbl_Msj_Agregar.ForeColor = Color.Green;
                lbl_Msj_Agregar.Text = "Turno agregado con éxito";
                Restaurar();
            }
            else
            {
                lbl_Msj_Agregar.ForeColor = Color.Red;
                lbl_Msj_Agregar.Text = "El Turno NO pudo agregarse. Verifique si ya existe.";
                Restaurar();
            }
        }

        private void LimpiarCampos()
        {
            txt_Turnos_Agregar.Text = "";
            ddlClientes.SelectedIndex = 0;
            ddlRubros.SelectedIndex = 0;
            ddlEmpleados.SelectedIndex = 0;
            ddlDias.SelectedIndex = 0;
            ddlHorarios.SelectedIndex = 0;
            calendarFechas.SelectedDate = DateTime.Now;
        }

        private void Restaurar()
        {
            LimpiarCampos();
            CargarClientes();
            CargarRubros();
            ddlEmpleados.Enabled = false;
            ddlDias.Enabled = false;
            ddlHorarios.Enabled = false;
        }
    }
}