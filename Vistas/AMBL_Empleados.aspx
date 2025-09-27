<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AMBL_Empleados.aspx.cs" Inherits="Vistas.AMBL_Empleados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/ambl.css" type="text/css"/> 
    <style type="text/css">
        .auto-style3 {
            margin-left: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header1">
            <asp:Label ID="lbl_Sistema" runat="server" Text="Sistema eCommerce" Font-Bold="True" Font-Size="X-Large" ForeColor="#000099"></asp:Label>
            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_NombreUsuario" runat="server" EnableTheming="True" Text="Nombre del Usuario" CssClass="usuario" Font-Bold="True" Font-Italic="False" ForeColor="#0066CC"></asp:Label>
        </div>

        <div class="header2">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hpempleados" runat="server" ForeColor="White" NavigateUrl="~/AMBL_Empleados.aspx">Empleados</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hpemresas" runat="server" ForeColor="White" NavigateUrl="~/AMBL_Clientes.aspx">Clientes</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hpturnos" runat="server" ForeColor="White" NavigateUrl="~/AsignacionTurnos.aspx">Turnos</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hpinformeT" runat="server" ForeColor="White" NavigateUrl="~/InformeTurnos.aspx">Informe Turnos</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hpinformeE" runat="server" ForeColor="White" NavigateUrl="~/InformeEmpleados.aspx">Informe Empleados</asp:HyperLink>
        </div>

        <div class="left-panel">
            <div class="submenu1">           
                <asp:Label ID="lblTituloAgregar" runat="server" Text="Agregar Empleado"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lbl_Usu_Agregar" runat="server" Text="CodUsuario"></asp:Label>&nbsp;
                <asp:TextBox ID="txt_Usu_Agregar" runat="server" Width="100px"></asp:TextBox>
                <br />
                <asp:Label ID="lbl_Rubro" runat="server" Text="Rubro"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlRubros" runat="server">
                </asp:DropDownList>
                <br />
                <asp:Label ID="lbl_Nombre" runat="server" Text="Nombre"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtNombre" runat="server" Width="100px"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Apellido"></asp:Label> 
                <asp:TextBox ID="txtApellido" runat="server" Width="100px" CssClass="auto-style3"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="DNI"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDNI" runat="server" Width="100px"></asp:TextBox>
                <br />
                <asp:Label ID="Label7" runat="server" Text="Genero"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlGenero" runat="server">
                    <asp:ListItem>--Seleccionar--</asp:ListItem>
                    <asp:ListItem>Masculino</asp:ListItem>
                    <asp:ListItem>Femenino</asp:ListItem>
                    <asp:ListItem>Otros</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Telefono"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTelefono" runat="server" Width="100px"></asp:TextBox>
                <br />
                <asp:Label ID="Label9" runat="server" Text="Email"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtEmail" runat="server" Width="100px"></asp:TextBox>
                <br />
                <asp:Label ID="Label10" runat="server" Text="Direccion"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDireccion" runat="server" Width="100px"></asp:TextBox>
                <br />
                Nacionalidad&nbsp; <asp:TextBox ID="txtNacionalidad" runat="server" Width="100px"></asp:TextBox>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Provincia"></asp:Label>   &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:DropDownList ID="ddlProvincias" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincias_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Localidad"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlLocalidades" runat="server">
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label6" runat="server" Text="Clave"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtClave" runat="server" Width="100px" TextMode="Password"></asp:TextBox>
                <br />
                <asp:Label ID="Label17" runat="server" Text="Verificar Clave"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="txtClave2" runat="server" TextMode="Password" Width="100px"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Label ID="Label11" runat="server" Text="Dias y Horarios de Atencion"></asp:Label>
&nbsp;&nbsp;&nbsp;<br />
                &nbsp;
                <asp:CheckBoxList ID="cblDias" runat="server">
                </asp:CheckBoxList>
&nbsp;&nbsp;
                <asp:CheckBoxList ID="cblHorarios" runat="server">
                </asp:CheckBoxList>
                <br />
                <asp:Button ID="btn_Agregar" runat="server" Text="Agregar" CssClass="auto-style1" Width="118px" OnClick="btn_Agregar_Click" />  
                <br />
                <br />
                <asp:Label ID="lbl_Msj_Agregar" runat="server"></asp:Label>
                <br />
                <br />
            </div>
            <div class="submenu2">
                <br />
                <br />
                <asp:Label ID="lbl_Usu_Eliminar" runat="server" Text="CodUsuario"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="txt_Usu_Eliminar" runat="server" Width="100px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <asp:Button ID="btn_Eliminar" runat="server" Text="Eliminar" CssClass="auto-style1" Width="118px" OnClick="btn_Eliminar_Click" />
                <br />
                <br />                
                <asp:Label ID="lbl_Msj_Eliminar" runat="server"></asp:Label>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Si" Width="50px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Width="50px" />
                <br />
            </div>
            <div class="submenu3">
                <br />
                <br />
&nbsp;<asp:Label ID="Label13" runat="server" Text="Apellido"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="txtApellido_F" runat="server" Width="50px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" />
                <br />
                <br />
                &nbsp;<asp:Label ID="Label15" runat="server" Text="Provincia"></asp:Label>
                &nbsp;&nbsp;
               <asp:DropDownList ID="ddlProvincia_F" runat="server">
               </asp:DropDownList>            
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnFiltrar2" runat="server" Text="Filtrar" OnClick="btnFiltrar2_Click" />
                <br />
                <asp:Label ID="lbl_Msj_Filtrar" runat="server"></asp:Label>

            </div>
            
        </div>


        <div class="right-panel">
            &nbsp;&nbsp;<br />
            <asp:Label ID="Label16" runat="server" Text="Buscar por CodUsuario"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBuscarCod" runat="server" OnClick="btnBuscarCod_Click" Text="Filtrar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnMostrar" runat="server" OnClick="btnMostrar_Click" Text="Mostrar Todos" />
            <br />
            <br />
            <asp:GridView ID="grdEmpleados" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowEditing="grdEmpleado_RowEditing" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="grdEmpleados_PageIndexChanging" OnRowCancelingEdit="grdEmpleados_RowCancelingEdit" OnRowDataBound="grdEmpleados_RowDataBound" OnRowUpdating="grdEmpleados_RowUpdating" AllowPaging="True" PageSize="5">
                <Columns>
                    <asp:TemplateField HeaderText="Usuario">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_CodUsuarios" runat="server" Text='<%# Bind("CodUsuarios_U") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCodUsuarios" runat="server" Text='<%# Bind("CodUsuarios_U") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rubro">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Rubros" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblRubros" runat="server" Text='<%# Bind("Descripcion_R") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Nombre" runat="server" Text='<%# Bind("Nombre_U") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblNombres" runat="server" Text='<%# Bind("Nombre_U") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="150px" />
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Apellido" runat="server" Text='<%# Bind("Apellido_U") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblApellidos" runat="server" Text='<%# Bind("Apellido_U") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DNI">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_DNI" runat="server" Text='<%# Bind("DNI_U") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDNI" runat="server" Text='<%# Bind("DNI_U") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Genero">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Genero" runat="server">
                                <asp:ListItem>--Seleccionar--</asp:ListItem>
                                <asp:ListItem>Masculino</asp:ListItem>
                                <asp:ListItem>Femenino</asp:ListItem>
                                <asp:ListItem>Otros</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGeneros" runat="server" Text='<%# Bind("Genero_U") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefono">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Telefono" runat="server" Text='<%# Bind("Telefono_U") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTelefonos" runat="server" Text='<%# Bind("Telefono_U") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Email" runat="server" Text='<%# Bind("Email_U") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email_U") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Direccion">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Direccion" runat="server" Text='<%# Bind("Direccion_U") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDirecciones" runat="server" Text='<%# Bind("Direccion_U") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nacionalidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Nacionalidad" runat="server" Text='<%# Bind("Nacionalidad_U") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblNacionalidades" runat="server" Text='<%# Bind("Nacionalidad_U") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Provincia">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Provincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_eit_Provincia_SelectedIndexChanged">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblProvincias" runat="server" Text='<%# Bind("Nombre_P") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Localidad">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Localidad" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblLocalidades" runat="server" Text='<%# Bind("Nombre_L") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Clave">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Clave" runat="server" Text='<%# Bind("Clave_U") %>' TextMode="Password" Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_Clave" runat="server" Text="****"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dia">
                        <EditItemTemplate>
                            <asp:CheckBoxList ID="cbl_eit_Dia" runat="server">
                            </asp:CheckBoxList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDias" runat="server" Text='<%# Eval("NombreDia_D").ToString().Replace(",", "<br />")  %>' ></asp:Label>
                        </ItemTemplate>
                    <HeaderStyle Width="150px" />
                    <ItemStyle Width="150px" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Horario">
                        <EditItemTemplate>
                            <asp:CheckBoxList ID="cbl_eit_Horario" runat="server">
                            </asp:CheckBoxList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblHorarios" runat="server"  Text='<%# Eval("Descripcion_H").ToString().Replace(",", "<br />") %>'></asp:Label>
                        </ItemTemplate>
                         <HeaderStyle Width="150px" />
                         <ItemStyle Width="150px" Wrap="False" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="center" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>

        </div>
    </form>
</body>
</html>
