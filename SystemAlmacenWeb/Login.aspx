<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SystemAlmacenWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
     
        
    <link href="/Models/bootstrap-theme.css" rel="stylesheet" />
    <link href="/Models/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="/Models/bootstrap.min.css" rel="stylesheet" />
    <script src="/Models/bootstrap.min.js"></script>
    <script src="/Scripts/jquery-3.2.1.min.js"></script>
    <script src="/Content/jquery-3.2.1.min.js"></script>  
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="/Content/bootstrap3.7.min.js"></script>
 
 


             <!-- Librerias para Toastr -->
    <link href="/../Content/toastr.css" rel="stylesheet" />
    <script src="../../Scripts/toastr.js"></script>
    <script src="../../Scripts/jquery-3.2.1.js"></script>



     <div class="center-block" style="overflow: auto;">

    
     
        <h1 class="page-header text-center">INICIO <span></span></h1>
  


      
        
     

        <div class="text-center">


            <br />
    

        <span class="badge badge-primary">Nombre Usuario </span>


            <!--Texbos Buscar y descrpcion o nombre -->



            <br />
            <asp:TextBox ID="Textid" placeholder="Usuario" class="input-lg" runat="server" Height="30px" Width="134px" ></asp:TextBox>
            <br />

            <br />
    

        <span class="badge badge-primary">Contraseña </span>
            <br />


            <asp:TextBox ID="TextPass"  TextMode="Password" placeholder="Contraseña" class="input-lg" runat="server" Height="30px" Width="162px"></asp:TextBox>

            <br />

            <br />
          
            <asp:Button ID="Inicio" runat="server" CssClass="btn btn-success"  Text="INICIO" OnClick="Inicio_Click"  />
            <br />
        </div>

        <!--Botones -->

        <div class="text-center">
        </div>
               </div>
            
   
    </form>
</body>
</html>
