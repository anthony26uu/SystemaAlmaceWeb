<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="RUsuario.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Registros.RUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <script src="../../../Scripts/popper.min.js"></script>


    <div class="text-center">
        <h1 class="page-header text-center">Registro Usuario <span></span></h1>
    </div>





    <div class="text-center">
        <span class="btn btn-danger">ID Usuario</span>

        <asp:TextBox ID="TextBoxID" class="input-lg" placeholder="ID a buscar " runat="server" Height="45px" Width="160px" ValidationGroup="buscar"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxID" ErrorMessage="**" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="buscar"></asp:RequiredFieldValidator>
        <asp:Button ID="BotonBuscar" CssClass="btn btn-danger" runat="server" Text="Buscar" Height="45px" ValidationGroup="Buscar" OnClick="BotonBuscar_Click" />
    </div>
    <br />

    <br />
    <br />
    <!--Texbox -->
    <div class="text-center">

  
    <div class="input-group">

        <asp:TextBox ID="TextBoxNombre" placeholder="Nombre Usuario" class="input-lg" runat="server" Height="30px" Width="199px"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNombre" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <!--Texbox -->

        <asp:TextBox ID="TextFecha" runat="server" placeholder="00/00/0000 " class="input-lg" ReadOnly="True" Width="215px" Height="30px"></asp:TextBox>


        &nbsp;

       
          <!--Texbox -->

        <asp:TextBox ID="TextBoxPass" placeholder="Contraseña" class="input-lg" TextMode="Password" runat="server" Height="30px" Width="199px"></asp:TextBox>


        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPass" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>


        <!--Texbox -->

        <asp:TextBox ID="TextBoxConfirm" placeholder="Confirma Pass" class="input-lg" TextMode="Password" runat="server" Height="30px" Width="199px"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxConfirm" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <!--Select -->

        <asp:DropDownList ID="DropTipo" runat="server" class="btn btn-danger" Height="42px" Width="199px">
            <asp:ListItem>Administrador</asp:ListItem>
            <asp:ListItem>Empleado</asp:ListItem>
        </asp:DropDownList>

        <br />
        <br />
    </div>
          </div>

  
      
    <!--Botones -->

    <div class="text-center">
        <asp:Button ID="Button4" CssClass="btn btn-danger" runat="server" Text="Nuevo" Height="36px" Width="88px" ValidationGroup="guardar" OnClick="Button4_Click"  />
        <asp:Button ID="Button2" CssClass="btn btn-danger" runat="server" Text="Guardar" Height="36px" Width="88px" ValidationGroup="guardar" OnClick="Button2_Click" />
        <asp:Button ID="Button3" CssClass="btn btn-danger" runat="server" Text="Eliminar" Height="36px" Width="88px" ValidationGroup="buscar" OnClick="Button3_Click" />
    </div>

    <br />

</asp:Content>
