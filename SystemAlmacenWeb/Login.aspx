<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SystemAlmacenWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  

  <!--Inclusión de Bootstrap-->
      <link href="/Content/bootstrap.min.css" rel="stylesheet" />
      <script src="/Scripts/bootstrap.min.js"></script>  
      <script src="/Content/bootstrap3.7.min.js"></script>
    <!--Inclusión de toastr-->
      <link href="/Content/toastr.min.css" rel="stylesheet" />
      <script src="/Scripts/toastr.min.js"></script>

    <!--Inclusión de jquery-->
     <script src="/Scripts/jquery-2.2.0.min.js"></script>   
     <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
      <script  src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
  

     
        <h1 class="page-header text-center">INICIO <span></span></h1>
  

        
    <div class=" container-fluid">
        <div class="text-center">
          
                <div class="row">
                    <div class="col-12 col-sm-2 col-md-3 col-lg-4">
                    </div>
                    <div class="col-12 col-sm-8 col-md-6 col-lg-4">
                        <div class="form-group">
                            <asp:Label For="CodigoTextBox" ID="Label3" class="col-md-3 control-label input-sm" runat="server" Text="Nombre Usuario"></asp:Label>
         
                         <asp:TextBox ID="Textid" AutoComplete="off" placeholder="Usuario" CssClass="form-control text-center" runat="server" ></asp:TextBox>
               </div>

                        <div class="form-group">
                              <asp:Label For="CodigoTextBox" ID="Label1" class="col-md-3 control-label " runat="server" Text="Contraseña "></asp:Label>
         
                    
            <asp:TextBox ID="TextPass"  TextMode="Password" placeholder="Contraseña"  CssClass="form-control text-center" runat="server" ></asp:TextBox>

                            </div>

                        <div class="text-center">
                             <asp:Button ID="Inicio" runat="server" CssClass="btn btn-success"  Text="INICIO" OnClick="Inicio_Click" Width="99px"  />
                        </div>
                    </div>
                </div>
       
        </div>
    </div>

      
     
   
    </form>
</body>
</html>
