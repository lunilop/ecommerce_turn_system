<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Visualizacion_Turnos.aspx.cs" Inherits="Vistas.Visualizacion_Turnos" %>

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
        </div>

        <div class="left-panel">            

            <div class="submenu1">
                <br />
                <asp:Label ID="lblMes" runat="server" Text="Mes:"></asp:Label>
                <asp:TextBox ID="txtMes" runat="server"></asp:TextBox>
                <br /><br />
    
                <asp:Label ID="lblAno" runat="server" Text="Año:"></asp:Label>
                <asp:TextBox ID="txtAno" runat="server"></asp:TextBox>
                <br /><br />
    
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
            </div>

        </div>

         <div class="right-panel">

            &nbsp;&nbsp;<asp:GridView ID="grdEmpleadosTurnos" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCancelingEdit="grdEmpleadosTurnos_RowCancelingEdit" OnRowDataBound="grdEmpleadosTurnos_RowDataBound" OnRowEditing="grdEmpleadosTurnos_RowEditing" OnRowUpdating="grdEmpleadosTurnos_RowUpdating">
                 <Columns>
                     <asp:TemplateField HeaderText="CodTurno">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_CodTurnos" runat="server" Text='<%# Bind("CodTurnos_T") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lblCodTurnos" runat="server" Text='<%# Bind("CodTurnos_T") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Cliente">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_Clientes" runat="server" Text='<%# Bind("NombreEmpresa_C") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lblClientes" runat="server" Text='<%# Bind("NombreEmpresa_C") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Dia">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_Dias" runat="server" Text='<%# Bind("NombreDia_D") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lblDias" runat="server" Text='<%# Bind("NombreDia_D") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Horario">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_Horarios" runat="server" Text='<%# Bind("Descripcion_H") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lblHorarios" runat="server" Text='<%# Bind("Descripcion_H") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Fecha">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_Fechas" runat="server" Text='<%# Bind("CodFechas_T") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lblFechas" runat="server" Text='<%# Bind("CodFechas_T") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Estado">
                         <EditItemTemplate>
                             <asp:DropDownList ID="ddl_eit_Estados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_eit_Estados_SelectedIndexChanged">
                             </asp:DropDownList>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lblEstados" runat="server" Text='<%# Bind("Descripcion_E") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Observaciones">
                         <EditItemTemplate>
                             <asp:TextBox ID="txt_eit_Observacion" runat="server" Text='<%# Bind("Observaciones_T") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lblObservaciones" runat="server" Text='<%# Bind("Observaciones_T") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
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
