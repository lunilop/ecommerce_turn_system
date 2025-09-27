<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Vistas.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/styles.css" type="text/css"/> 
</head>
<body>
    <main class="main-form">
        <form id="form1" runat="server">
            <h1>Inicio de sesión</h1>
            <div">
                <asp:Label ID="lbl_ID" runat="server" Text="Codigo de Usuario *" CssClass="form-label"></asp:Label>
                <br />
                <asp:TextBox ID="txt_Usuario" runat="server" CssClass="form-control"></asp:TextBox>
                 <br />       
            </div>
       
            <div>
                <br />
                <asp:Label ID="lbl_Contraseña" runat="server" Text="Contraseña *" CssClass="form-label"></asp:Label>
                <br />
                <asp:TextBox ID="txt_Clave" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <br /> 
            </div>
            
            <div>
                <br />
                <asp:Button ID="btn_Ingresar" runat="server" Text="Ingresar" OnClick="btn_Ingresar_Click" CausesValidation="false" CssClass="form-button" />
                <br />
                <br />  
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <br />
            </div>
        </form>
    </main>

    <footer>
        <asp:Label ID="lbl_Sistema" runat="server" Text="Sistema eCommerce" Font-Bold="True" Font-Size="X-Large" ForeColor="#000099"></asp:Label>
    </footer>

</body>
</html>
