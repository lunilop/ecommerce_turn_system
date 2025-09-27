using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Vistas
{
    public partial class AMBL_Clientes : System.Web.UI.Page
    {
        NegocioAMBLClientes ns= new NegocioAMBLClientes();

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
            grdClientes.DataSource = ns.getTablaCli();
            grdClientes.DataBind();
        }

        private void CargarLocalidades(DropDownList ddl, string CodProvincias)
        {
            Inicio_ddl(ddl);
            DataTable localidades = ns.getTablaLocFiltradas(CodProvincias);
            foreach (DataRow row in localidades.Rows)
            {
                ddl.Items.Add(new ListItem(row["Nombre_L"].ToString(), row["CodLocalidades_L"].ToString()));
            }
        }

        private void CargarProvincias(DropDownList ddl)
        {
            Inicio_ddl(ddl);         
            DataTable provincias = ns.getTablaProv();
            foreach (DataRow row in provincias.Rows)
            {
                ddl.Items.Add(new ListItem(row["Nombre_P"].ToString(), row["CodProvincias_P"].ToString()));
            }
        }

        protected void ddlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CodProvincias = ddlProvincias.SelectedValue;
            if (!string.IsNullOrEmpty(CodProvincias) && CodProvincias != "--Seleccionar--")
            {
                CargarLocalidades(ddlLocalidades ,CodProvincias);
                ddlLocalidades.Enabled = true;
            }
            else
            {
                Inicio_ddl(ddlLocalidades);
                ddlLocalidades.Enabled = false;
            }
        }

        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Cli_Agregar.Text) && !string.IsNullOrEmpty(txtNombre.Text) &&!string.IsNullOrEmpty(txtRazonSoc.Text) &&
                !string.IsNullOrEmpty(txtTelefono.Text) &&!string.IsNullOrEmpty(txtEmail.Text) &&  !string.IsNullOrEmpty(txtDireccion.Text) &&
                !string.IsNullOrEmpty(ddlProvincias.SelectedValue) && ddlProvincias.SelectedValue != "--Seleccionar--" )
            {
                bool clienteAgregado = ns.agregarCliente(txt_Cli_Agregar.Text, txtNombre.Text, txtRazonSoc.Text,
                txtTelefono.Text, txtEmail.Text, txtDireccion.Text,
                ddlLocalidades.SelectedValue.ToString(), ddlProvincias.SelectedValue.ToString());

                if (clienteAgregado)
                {
                    lbl_Msj_Agregar.Text = "Cliente agregado con éxito";
                    lbl_Msj_Agregar.ForeColor = Color.Green;
                    ddlLocalidades.SelectedIndex = 0;
                }
                else
                {
                    lbl_Msj_Agregar.Text = "No se pudo agregar el Cliente. Verifique si ya existe.";
                    lbl_Msj_Agregar.ForeColor = Color.Red;
                }
            }
            else
            {
                lbl_Msj_Agregar.Text = "Complete todos los campos correctamente";
                lbl_Msj_Agregar.ForeColor = Color.Red;
            }
            LimpiarCampos();
            Restaurar();
        }

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Cli_Eliminar.Text))
            {
                string codEmpresa = txt_Cli_Eliminar.Text;

                bool eliminado = ns.existeCodEmp(codEmpresa);

                if (!eliminado)
                {
                    lbl_Msj_Eliminar.Text = "Ingrese un CodUsuario válido.";
                    lbl_Msj_Eliminar.ForeColor = Color.Red;
                    txt_Cli_Eliminar.Text = "";
                }
                else
                {
                    btnNo.Visible = true;
                    btnSi.Visible = true;
                    lbl_Msj_Eliminar.Enabled = true;
                    lbl_Msj_Eliminar.Text = "¿Esta seguro que desea eliminar el registro?";
                }
            }
            else
            {
                lbl_Msj_Eliminar.Text = "Ingrese un Cod Empresa";
                lbl_Msj_Eliminar.ForeColor = Color.Red;
            }
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Cli_Eliminar.Text))
            {
                string codCliente = txt_Cli_Eliminar.Text;

                ns.eliminarCliente(codCliente);
                lbl_Msj_Eliminar.Text = "El cliente se ha eliminado con éxito.";
                lbl_Msj_Eliminar.ForeColor = Color.Green;
                CargarClientes();
            }
            Deshabilitar();
            txt_Cli_Eliminar.Text = "";
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            Deshabilitar();
            txt_Cli_Eliminar.Text = "";
            lbl_Msj_Eliminar.Text = "";
        }

        public void Deshabilitar()
        {
            btnNo.Visible = false;
            btnSi.Visible = false;
            lbl_Msj_Eliminar.Enabled = false;
        }
    
        public void LimpiarCampos()
        {
            txt_Cli_Agregar.Text = "";
            txtNombre.Text = "";
            txtRazonSoc.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
            ddlProvincias.SelectedIndex = 0;
            txt_Cli_Eliminar.Text = "";
        }

        public void Restaurar()
        {
            CargarClientes();
            ddlLocalidades.Enabled = false;
            CargarProvincias(ddlProvincias);
 
            CargarProvincias(ddlProvincia_F);
            Deshabilitar();
        }

        public void Inicio_ddl(DropDownList ddl)
        {
            ddl.Items.Clear(); // Limpiar elementos existentes
            ddl.Items.Add(new ListItem("--Seleccionar--", "")); // Agregar el item de selección
        }

        protected void grdClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdClientes.EditIndex = e.NewEditIndex;
            CargarClientes();
        }

        protected void grdClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdClientes.EditIndex = -1;
            CargarClientes();
        }

        protected void grdClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList ddlProvincias = (DropDownList)e.Row.FindControl("ddl_eit_Provincias");              
            if(ddlProvincias!=null)
            {
                CargarProvincias(ddlProvincias);
            }
        }

        protected void ddl_eit_Provincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincia = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlProvincia.NamingContainer;

            DropDownList ddLocalidad = (DropDownList)row.FindControl("ddl_eit_Localidades");
            Inicio_ddl(ddLocalidad);

            string CodProvincias = ddlProvincia.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(CodProvincias) && CodProvincias != "--Seleccionar--")
            {
                CargarLocalidades(ddLocalidad, CodProvincias);
            }
        }

        protected void grdClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String codEmpresa = ((Label)grdClientes.Rows[e.RowIndex].FindControl("lbl_eit_CodCliente")).Text;
            String nombre = ((TextBox)grdClientes.Rows[e.RowIndex].FindControl("txt_eit_Nombre")).Text;
            String razonSocial = ((TextBox)grdClientes.Rows[e.RowIndex].FindControl("txt_eit_RazonSocial")).Text;
            String telefono = ((TextBox)grdClientes.Rows[e.RowIndex].FindControl("txt_eit_Telefono")).Text;
            String email = ((TextBox)grdClientes.Rows[e.RowIndex].FindControl("txt_eit_Email")).Text;
            String direccion = ((TextBox)grdClientes.Rows[e.RowIndex].FindControl("txt_eit_Direccion")).Text;
            String codProvincia = ((DropDownList)grdClientes.Rows[e.RowIndex].FindControl("ddl_eit_Provincias")).SelectedValue;
            String codLocalidad = ((DropDownList)grdClientes.Rows[e.RowIndex].FindControl("ddl_eit_Localidades")).SelectedValue;

            ns.modificarCliente(codEmpresa, nombre, razonSocial, telefono, email,
                                 direccion, codLocalidad, codProvincia);
            grdClientes.EditIndex = -1;
            CargarClientes();
        }

        protected void grdClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClientes.PageIndex = e.NewPageIndex;
            CargarClientes();
        }


        protected void btnBuscarCod_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                string codEmpresa = txtBuscar.Text;
                grdClientes.DataSource = ns.getTablaCliPorCodEmp(codEmpresa);
                grdClientes.DataBind();
            }
            else { CargarClientes(); }
            txtBuscar.Text = "";
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre_F.Text))
            {
                string Nombre = txtNombre_F.Text;
                if (ns.existeNombre(Nombre))
                {
                    grdClientes.DataSource = ns.FiltrarNombre(Nombre);
                    grdClientes.DataBind();
                    lbl_Msj_Filtrar.Text = "Apellidos con esa inicial";
                }
                else
                {
                    lbl_Msj_Filtrar.Text = "No hay Apellidos con esa inicial";
                    lbl_Msj_Filtrar.ForeColor = Color.Red;
                }
            }
            else
            {
                lbl_Msj_Filtrar.Text = "Ingrese una Inicial";
                lbl_Msj_Filtrar.ForeColor = Color.Red;
            }
            txtNombre_F.Text = "";
        }
        protected void btnFiltrar2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlProvincia_F.SelectedValue) && ddlProvincia_F.SelectedValue != "--Seleccionar--")
            {
                string codProvincia = ddlProvincia_F.SelectedValue;
                grdClientes.DataSource = ns.FiltrarProv(codProvincia);
                grdClientes.DataBind();
            }
            else
            {
                lbl_Msj_Filtrar.Text = "Seleccione una Provincia";
                lbl_Msj_Filtrar.ForeColor = Color.Red;
            }
            ddlProvincia_F.SelectedIndex = 0;
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            CargarClientes();
        }

    }
}