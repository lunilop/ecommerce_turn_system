<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AMBL_Clientes.aspx.cs" Inherits="Vistas.AMBL_Clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/ambl.css" type="text/css"/> 
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
                <br />
                <asp:Label ID="lbl_Cli_Agregar" runat="server" Text="CodEmpresa"></asp:Label>
&nbsp;<asp:TextBox ID="txt_Cli_Agregar" runat="server" Width="100px"></asp:TextBox>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                <asp:TextBox ID="txtNombre" runat="server" Width="100px"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Razon Social"></asp:Label> &nbsp;<asp:TextBox ID="txtRazonSoc" runat="server" Width="100px"></asp:TextBox>
                &nbsp;
                <br />
                <asp:Label ID="Label8" runat="server" Text="Telefono"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtTelefono" runat="server" Width="100px"></asp:TextBox>
                <br />
                <asp:Label ID="Label9" runat="server" Text="Email"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtEmail" runat="server" Width="100px"></asp:TextBox>
                <br />
                <asp:Label ID="Label10" runat="server" Text="Direccion"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDireccion" runat="server" Width="100px"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Provincia"></asp:Label>   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlProvincias" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincias_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Localidad"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlLocalidades" runat="server">
                </asp:DropDownList>
                <br />
                <br />
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
                <asp:Label ID="lbl_Cli_Eliminar" runat="server" Text="CodEmpresa"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="txt_Cli_Eliminar" runat="server" Width="100px"></asp:TextBox>
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
   
    Nombre&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:TextBox ID="txtNombre_F" runat="server" Width="50px"></asp:TextBox>
   &nbsp;&nbsp;&nbsp;
   <asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" />
    <br />
    <br />
   
   <asp:Label ID="Label14" runat="server" Text="Provincia"></asp:Label>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:DropDownList ID="ddlProvincia_F" runat="server" Height="20px">
   </asp:DropDownList>
   <br />
   <br />
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:Button ID="btnFiltrar2" runat="server" OnClick="btnFiltrar2_Click" Text="Filtrar" />
   <br />
   <asp:Label ID="lbl_Msj_Filtrar" runat="server"></asp:Label>

   </div>
            </div>

        <div class="right-panel">
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label16" runat="server" Text="Buscar por CodEmpresa"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBuscarCod" runat="server" OnClick="btnBuscarCod_Click" Text="Filtrar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnMostrar" runat="server" OnClick="btnMostrar_Click" Text="Mostrar Todos" />
            <br />
            <br />
         
            <br />
            <asp:GridView ID="grdClientes" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCancelingEdit="grdClientes_RowCancelingEdit" OnRowDataBound="grdClientes_RowDataBound" OnRowEditing="grdClientes_RowEditing" OnRowUpdating="grdClientes_RowUpdating" AllowPaging="True" OnPageIndexChanging="grdClientes_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:TemplateField HeaderText="CodEmpresa">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_CodCliente" runat="server" Text='<%# Bind("CodEmpresas_C") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCodClientes" runat="server" Text='<%# Bind("CodEmpresas_C") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Nombre" runat="server" Height="22px" Text='<%# Bind("NombreEmpresa_C") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NombreEmpresa_C") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Razon Social">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_RazonSocial" runat="server" Text='<%# Bind("RazonSocial_C") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblRazonSocial" runat="server" Text='<%# Bind("RazonSocial_C") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefono">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Telefono" runat="server" Text='<%# Bind("Telefono_C") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("Telefono_C") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Email" runat="server" Text='<%# Bind("Email_C") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email_C") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dirreccion">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Direccion" runat="server" Text='<%# Bind("Direccion_C") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("Direccion_C") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Provincia">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Provincias" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_eit_Provincias_SelectedIndexChanged">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblProvincias" runat="server" Text='<%# Bind("Nombre_P") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Localidad">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Localidades" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblLocalidad" runat="server" Text='<%# Bind("Nombre_L") %>'></asp:Label>
                        </ItemTemplate>
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
