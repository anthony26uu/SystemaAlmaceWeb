<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="RUsuario.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Registros.RUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <script src="../../../Scripts/popper.min.js"></script>
         <!-- Librerias para Toastr -->
    <link href="/../Content/toastr.css" rel="stylesheet" />
    <script src="../../Scripts/toastr.js"></script>
    <script src="../../Scripts/jquery-3.2.1.js"></script>


    <div class="text-center">
        <h2 class="page-header text-center text">Registro Usuario <span></span></h2>
    </div>





    <div class="text-center">

        <span class="badge badge-primary">Usuario ID</span>
        <br />


        <asp:TextBox ID="TextBoxID"  TextMode="Number"   class="input-lg" placeholder="ID a buscar " runat="server" Height="45px" Width="160px" ValidationGroup="buscar"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxID" ErrorMessage="**" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="buscar"></asp:RequiredFieldValidator>
        <asp:Button ID="BotonBuscar" CssClass=" btn btn-default"    runat="server" Text="Buscar" Height="45px" ValidationGroup="buscar" OnClick="BotonBuscar_Click" />
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBoxID" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="buscar"></asp:RegularExpressionValidator>

    <br />
    <!--Texbox -->
   
    

  
   
        <span class="badge badge-primary">Nombre</span>


        <br />
             

        <asp:TextBox ID="TextBoxNombre" placeholder="Nombre Usuario" class="input-lg" runat="server" Height="30px" Width="215px"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNombre" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>
          
        <br />

        <br />
                
        <span class="badge badge-primary">Fecha Registro</span><!--Texbox --><br />
        <asp:TextBox ID="TextFecha" runat="server" placeholder="00/00/0000 " class="input-lg" ReadOnly="True"  Height="30px" Width="215px"></asp:TextBox>


        <br />
        <br />


        <span class="badge badge-primary">Constraseña</span>&nbsp;

       
          <!--Texbox -->

        <br />

        <asp:TextBox ID="TextBoxPass" placeholder="Contraseña" class="input-lg" TextMode="Password" runat="server" Height="30px" Width="215px"></asp:TextBox>


        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPass" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>


        <br />
        <br />


        <!--Texbox -->

        <span class="badge badge-primary">Confirmar Contraseña</span><br />
        <asp:TextBox ID="TextBoxConfirm" placeholder="Confirma Pass" class="input-lg" TextMode="Password" runat="server" Height="30px" Width="215px" OnTextChanged="TextBoxConfirm_TextChanged"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxConfirm" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <br />
        <br />

        <span class="badge badge-primary">Tipo de Usuario</span><br />

        <!--Select -->

        <asp:DropDownList ID="DropTipo" runat="server"  CssClass=" btn btn-default"  Height="40px" Width="215px">
            <asp:ListItem>Administrador</asp:ListItem>
            <asp:ListItem>Empleado</asp:ListItem>
        </asp:DropDownList>

        <br />

        <br />
        <br />
    </div>
        
 

  
      
    <!--Botones -->

    <div class="text-center">
        <asp:Button ID="ButtoNuevo" CssClass="btn btn-warning" runat="server" Text="Nuevo" Height="36px" Width="88px" OnClick="Button4_Click"  />
        <asp:Button ID="ButtonGuardar" CssClass="btn btn-success" runat="server" Text="Guardar" Height="36px" Width="88px" ValidationGroup="guardar" OnClick="Button2_Click" />
        <asp:Button ID="ButtonEliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar" Height="36px" Width="88px" ValidationGroup="buscar" OnClick="Button3_Click" />
    </div>

    <br />

</asp:Content>
