<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="RArticulo.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Registros.RArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script src="../../../Scripts/popper.min.js"></script>
  
    <!-- Librerias para Toastr -->
    <link href="/../Content/toastr.css" rel="stylesheet" />
    <script src="../../Scripts/toastr.js"></script>
    <script src="../../Scripts/jquery-3.2.1.js"></script>



    <div class="text-center">
        <h1 class="page-header text-center">Registro Articulo <span></span></h1>
    </div>





    <div class="text-center">
        <span class="btn btn-danger">ID </span>

        <asp:TextBox ID="TextBoxID"  TextMode="Number" class="input-lg" placeholder="ID a buscar " runat="server" Height="45px" Width="160px" ValidationGroup="buscar"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxID" ErrorMessage="**" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="Buscar"></asp:RequiredFieldValidator>
        <asp:Button ID="BotonBuscar" CssClass="btn btn-info" runat="server" Text="Buscar" Height="45px" ValidationGroup="Buscar" OnClick="BotonBuscar_Click"  />
    </div>
    <br />

    <br />
    <br />
    <!--Texbox -->
    <div class="text-center">

  
    <div class="input-group">

        <asp:TextBox ID="TextBoxNombre" placeholder="Nombre Articulo" class="input-lg" runat="server" Height="30px" Width="199px"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNombre" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <!--Texbox -->

        <asp:TextBox ID="TextFecha" runat="server" placeholder="00/00/0000 " class="input-lg" ReadOnly="True" Width="215px" Height="30px"></asp:TextBox>


        &nbsp;

       
          <!--Texbox -->

        <asp:TextBox ID="TextBoxExistencia" placeholder="Existencia" class="input-lg" TextMode="Number" runat="server" Height="30px" Width="215px" ValidationGroup="guardar"></asp:TextBox>


        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxExistencia" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>


        <!--Texbox -->

        <asp:TextBox ID="TexboCosto"  placeholder="Costo" class="input-lg"  runat="server" Height="30px" Width="199px" ValidationGroup="guardar"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TexboCosto" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <asp:TextBox ID="TexboPrecio"  placeholder="Precio" class="input-lg"  runat="server" Height="30px" Width="199px" ValidationGroup="guardar"></asp:TextBox>

        <!--Select -->

        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TexboPrecio" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <asp:TextBox ID="TexboCodigo"  placeholder="Codigo" class="input-lg"  runat="server" Height="30px" Width="199px" ValidationGroup="guardar"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TexboCodigo" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <asp:TextBox ID="TexboItbis"  placeholder="ITBS" class="input-lg"  runat="server" Height="30px" Width="199px" ValidationGroup="guardar"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TexboItbis" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <asp:DropDownList ID="DropCategoria" runat="server" class="btn btn-danger" Height="42px" Width="199px">
        </asp:DropDownList>

        <br />
        <br />
    </div>
          </div>

  
      
    <!--Botones -->

    <div class="text-center">
        <asp:Button ID="Button4" CssClass="btn btn-warning" runat="server" Text="Nuevo" Height="36px" Width="88px" ValidationGroup="guardar" OnClick="Button4_Click"/>
        <asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Guardar" Height="36px" Width="88px" ValidationGroup="guardar" OnClick="Button2_Click" />
        <asp:Button ID="Button3" CssClass="btn btn-danger" runat="server" Text="Eliminar" Height="36px" Width="88px" ValidationGroup="Buscar" OnClick="Button3_Click"  />
    </div>

    <br />
</asp:Content>
