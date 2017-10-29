<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SystemAlmacenWeb.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <!-- Bootstrap 4.0.0 -->
<link href="/Content/bootstrap.min.css" rel="stylesheet" />
<!-- Bootswatch Darkly theme-->
<link href="/Content/bootstraptheme.min.css" rel="stylesheet" />


       

      <div class="text-center">
        <h1 class="page-header text-center">INICIO <span></span></h1>
    </div>


      
          <div class="panel panel-success">
        <div class="text-center">


            <!--Texbos Buscar y descrpcion o nombre -->



            <br />
            <asp:TextBox ID="Textid" placeholder="Usuario" class="input-lg" runat="server" Height="30px" Width="134px" ></asp:TextBox>
            <br />

            <br />


            <asp:TextBox ID="TextPass" placeholder="Contraseña" class="input-lg" runat="server" Height="30px" Width="162px"></asp:TextBox>

            <br />
            <asp:Button ID="Inicio" runat="server" OnClick="Inicio_Click" Text="INICIO" />
            <br />
        </div>

        <!--Botones -->

        <div class="text-center">
        </div>
               </div>
            
    </form>
</body>
</html>
