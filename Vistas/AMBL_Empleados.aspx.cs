using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using System.Data;
using System.Drawing;

namespace Vistas
{
    public partial class AMBL_Empleados : System.Web.UI.Page
    {
        NegocioAMBLEmpleados ns = new NegocioAMBLEmpleados();

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
                else { Response.Redirect("Login.aspx"); }

                Restaurar();
            }
        }

        private void CargarEmpleados()
        {
            grdEmpleados.DataSource = ns.getTablaEmp();
            grdEmpleados.DataBind();
        }

        private void CargarRubros(DropDownList ddl)
        {
            Inicio_ddl(ddl);
            DataTable rubros = ns.getTablaRub();
            foreach (DataRow row in rubros.Rows)
            {
                ddl.Items.Add(new ListItem(row["Descripcion_R"].ToString(), row["CodRubros_R"].ToString()));
            }
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
                CargarLocalidades(ddlLocalidades, CodProvincias);
                ddlLocalidades.Enabled = true;
            }
            else
            {
                Inicio_ddl(ddlLocalidades);
                ddlLocalidades.Enabled = false;
            }
        }

        private void CargarDias(CheckBoxList cbl)
        {
            cbl.Items.Clear();
            DataTable dias = ns.getTablaDia();
            foreach (DataRow row in dias.Rows)
            {
                cbl.Items.Add(new ListItem(row["NombreDia_D"].ToString(), row["CodDias_D"].ToString()));
            }
        }

        private void CargarHorarios(CheckBoxList cbl)
        {
            cbl.Items.Clear();
            DataTable hora = ns.getTablaHora();
            foreach (DataRow row in hora.Rows)
            {
                cbl.Items.Add(new ListItem(row["Descripcion_H"].ToString(), row["CodHorarios_H"].ToString()));
            }
        }
        
        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Usu_Agregar.Text) && !string.IsNullOrEmpty(ddlRubros.SelectedValue) && ddlRubros.SelectedValue != "--Seleccionar--" && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido.Text) &&
                !string.IsNullOrEmpty(txtDNI.Text) && !string.IsNullOrEmpty(ddlGenero.SelectedValue) && ddlGenero.SelectedValue != "--Seleccionar--" && !string.IsNullOrEmpty(txtTelefono.Text) && !string.IsNullOrEmpty(txtEmail.Text) &&
                !string.IsNullOrEmpty(txtDireccion.Text) && !string.IsNullOrEmpty(txtNacionalidad.Text) && !string.IsNullOrEmpty(ddlProvincias.SelectedValue) && ddlProvincias.SelectedValue != "--Seleccionar--" &&
                !string.IsNullOrEmpty(txtClave.Text) && !string.IsNullOrEmpty(txtClave2.Text) && !string.IsNullOrEmpty(cblDias.SelectedValue) && !string.IsNullOrEmpty(cblHorarios.SelectedValue))
            {
                if (txtClave2.Text == txtClave.Text)
                {
                    bool empleadoAgregado = ns.agregarEmpleado(txt_Usu_Agregar.Text, txtClave.Text,
                        ddlRubros.SelectedValue.ToString(), txtNombre.Text, txtApellido.Text,
                        txtDNI.Text, ddlGenero.SelectedValue.ToString(), txtTelefono.Text, txtEmail.Text, txtDireccion.Text,
                        txtNacionalidad.Text, ddlProvincias.SelectedValue.ToString(),
                        ddlLocalidades.SelectedValue.ToString());

                    if (empleadoAgregado)
                    {
                        lbl_Msj_Agregar.ForeColor = Color.Green;
                        lbl_Msj_Agregar.Text = "Empleado agregado con éxito";

                        foreach (ListItem dia in cblDias.Items)
                        {
                            if (dia.Selected)
                            {
                                foreach (ListItem hora in cblHorarios.Items)
                                {
                                    if (hora.Selected)
                                    {
                                        ns.agregarUsuxDiaxHora(dia.Value.ToString(), hora.Value.ToString(), txt_Usu_Agregar.Text);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        lbl_Msj_Agregar.ForeColor = Color.Red;
                        lbl_Msj_Agregar.Text = "El Empleado NO pudo agregarse. Verifique si ya existe.";
                    }
                }
                else
                {
                    lbl_Msj_Agregar.ForeColor = Color.Red;
                    lbl_Msj_Agregar.Text = "Contraseña incorrecta";
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

        public void LimpiarCampos()
        {
            txt_Usu_Agregar.Text = "";
            txtClave.Text = "";
            ddlRubros.SelectedIndex = 0;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            ddlGenero.SelectedIndex = 0;
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
            txtNacionalidad.Text = "";
            ddlProvincias.SelectedIndex = 0;
            ddlLocalidades.SelectedIndex = 0;
            cblDias.Items.Clear();
            cblHorarios.Items.Clear();
        }

        public void Restaurar()
        {
            CargarEmpleados();
            CargarRubros(ddlRubros);
            ddlLocalidades.Enabled = false;
            Deshabilitar();
            CargarProvincias(ddlProvincias);
            CargarDias(cblDias);
            CargarHorarios(cblHorarios);
            CargarProvincias(ddlProvincia_F);
        }

        public void Inicio_ddl(DropDownList ddl)
        {
            ddl.Items.Clear(); // Limpiar elementos existentes
            ddl.Items.Add(new ListItem("--Seleccionar--", "")); // Agregar el item de selección
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtApellido_F.Text))
            {
                string apellido = txtApellido_F.Text;
                if (ns.existeApellido(apellido))
                {
                    grdEmpleados.DataSource = ns.FiltrarApellido(apellido);
                    grdEmpleados.DataBind();
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
            txtApellido_F.Text="";
        }

        protected void grdEmpleado_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdEmpleados.EditIndex = e.NewEditIndex;
            CargarEmpleados();
        }

        protected void grdEmpleados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdEmpleados.EditIndex = -1;
            CargarEmpleados();
        }

        protected void grdEmpleados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlRubros = (DropDownList)e.Row.FindControl("ddl_eit_Rubros");
                if (ddlRubros!=null)
                {
                    CargarRubros(ddlRubros);
                }
                DropDownList ddlProvincias = (DropDownList)e.Row.FindControl("ddl_eit_Provincia");
                if (ddlProvincias != null)
                {
                    CargarProvincias(ddlProvincias);
                }
                CheckBoxList cblDia = (CheckBoxList)e.Row.FindControl("cbl_eit_Dia");
                if (cblDia != null)
                {
                    CargarDias(cblDia);
                }
                CheckBoxList cblHora = (CheckBoxList)e.Row.FindControl("cbl_eit_Horario");
                if (cblHora != null)
                {
                    CargarHorarios(cblHora);
                }
            }
        }

        protected void ddl_eit_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincia = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlProvincia.NamingContainer;

            DropDownList ddLocalidad = (DropDownList)row.FindControl("ddl_eit_Localidad");
            Inicio_ddl(ddLocalidad);

            string CodProvincias = ddlProvincia.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(CodProvincias) && CodProvincias != "--Seleccionar--")
            {
                CargarLocalidades(ddLocalidad, CodProvincias);
            }
        }

        protected void grdEmpleados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String codUsuario = ((Label)grdEmpleados.Rows[e.RowIndex].FindControl("lbl_eit_CodUsuarios")).Text;
            String clave = ((TextBox)grdEmpleados.Rows[e.RowIndex].FindControl("txt_eit_Clave")).Text;
            String rubro = ((DropDownList)grdEmpleados.Rows[e.RowIndex].FindControl("ddl_eit_Rubros")).SelectedValue;
            String nombre = ((TextBox)grdEmpleados.Rows[e.RowIndex].FindControl("txt_eit_Nombre")).Text;
            String apellido = ((TextBox)grdEmpleados.Rows[e.RowIndex].FindControl("txt_eit_Apellido")).Text;
            String dni = ((TextBox)grdEmpleados.Rows[e.RowIndex].FindControl("txt_eit_DNI")).Text;
            String genero = ((DropDownList)grdEmpleados.Rows[e.RowIndex].FindControl("ddl_eit_Genero")).SelectedValue;
            String telefono = ((TextBox)grdEmpleados.Rows[e.RowIndex].FindControl("txt_eit_Telefono")).Text;
            String email = ((TextBox)grdEmpleados.Rows[e.RowIndex].FindControl("txt_eit_Email")).Text;
            String direccion = ((TextBox)grdEmpleados.Rows[e.RowIndex].FindControl("txt_eit_Direccion")).Text;
            String nacionalidad = ((TextBox)grdEmpleados.Rows[e.RowIndex].FindControl("txt_eit_Nacionalidad")).Text;
            String codProvincia = ((DropDownList)grdEmpleados.Rows[e.RowIndex].FindControl("ddl_eit_Provincia")).SelectedValue;
            String codLocalidad = ((DropDownList)grdEmpleados.Rows[e.RowIndex].FindControl("ddl_eit_Localidad")).SelectedValue;

            CheckBoxList cblDias = (CheckBoxList)grdEmpleados.Rows[e.RowIndex].FindControl("cbl_eit_Dia");
            CheckBoxList cblHorarios = (CheckBoxList)grdEmpleados.Rows[e.RowIndex].FindControl("cbl_eit_Horario");

            bool empleadoModificado = ns.modificarEmpleado(codUsuario, clave,rubro, nombre, 
                                      apellido, dni, genero, telefono, email,direccion,
                                      nacionalidad, codLocalidad, codProvincia);

            if (empleadoModificado)
            {
                ns.eliminarUsuxDiaxHora(codUsuario);

                foreach (ListItem dia in cblDias.Items)
                {
                    if (dia.Selected)
                    {
                        foreach (ListItem horario in cblHorarios.Items)
                        {
                            if (horario.Selected)
                            {
                                ns.agregarUsuxDiaxHora(dia.Value, horario.Value, codUsuario);
                            }
                        }
                    }
                }
                grdEmpleados.EditIndex = -1;
                CargarEmpleados();
            }
        }

        protected void grdEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEmpleados.PageIndex = e.NewPageIndex;
            CargarEmpleados();
        } 

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Usu_Eliminar.Text))
            {
                string idsucursal = txt_Usu_Eliminar.Text;

                bool eliminado = ns.existeEmpleado(idsucursal);

                if(!eliminado)
                {
                    lbl_Msj_Eliminar.Text = "Ingrese un CodUsuario válido.";
                    lbl_Msj_Eliminar.ForeColor = Color.Red;
                    txt_Usu_Eliminar.Text = "";
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
                lbl_Msj_Eliminar.Text = "Ingrese un Cod Usuario";
                lbl_Msj_Eliminar.ForeColor = Color.Red;
            }
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Usu_Eliminar.Text))
            {
                string codUsu = txt_Usu_Eliminar.Text;

                ns.eliminarEmpleado(codUsu);
                lbl_Msj_Eliminar.Text = "El empleado se ha eliminado con éxito.";
                lbl_Msj_Eliminar.ForeColor = Color.Green;
                CargarEmpleados();
            }
            Deshabilitar();
            txt_Usu_Eliminar.Text = "";
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            Deshabilitar();
            txt_Usu_Eliminar.Text = "";
            lbl_Msj_Eliminar.Text = "";
        }

        public void Deshabilitar()
        {
            btnNo.Visible = false;
            btnSi.Visible = false;
            lbl_Msj_Eliminar.Enabled = false;
        }

        protected void btnFiltrar2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlProvincia_F.SelectedValue) && ddlProvincia_F.SelectedValue != "--Seleccionar--")
            {
                string codProvincia = ddlProvincia_F.SelectedValue;
                grdEmpleados.DataSource = ns.FiltrarProv(codProvincia);
                grdEmpleados.DataBind();
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
            CargarEmpleados();
        }

        protected void btnBuscarCod_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                string codUsu = txtBuscar.Text;
                grdEmpleados.DataSource = ns.getTablaEmpPorCodUsu(codUsu);
                grdEmpleados.DataBind();
            }
            else { CargarEmpleados(); }
            txtBuscar.Text = "";
        }
    }
}

