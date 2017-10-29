<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="RCategoria.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Registros.RCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <script src="../../Scripts/popper.min.js"></script>

         <!-- Librerias para Toastr -->
    <link href="/../Content/toastr.css" rel="stylesheet" />
    <script src="../../Scripts/toastr.js"></script>
    <script src="../../Scripts/jquery-3.2.1.js"></script>

      <div class="text-center">
        <h1 class="page-header text-center">Registro Categorias <span></span></h1>
    </div>




    <!--Texbos Buscar y descrpcion o nombre -->
     <div class="text-center">

    <span class="btn btn-danger">ID Categoria</span>&nbsp;
    <asp:TextBox ID="Textid" placeholder="Id a Buscar" class="input-lg" runat="server" Height="45px" Width="165px" ValidationGroup="buscar" MaxLength="10"></asp:TextBox>
    <asp:Button ID="Button1" CssClass="btn btn-danger" runat="server" Text="Buscar" Height="45px" ValidationGroup="buscar" OnClick="Button1_Click" />


         <br />


    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Textid" ErrorMessage="Campo Id vacio" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="buscar"></asp:RequiredFieldValidator>
         <br />


         <br />
</div>

     <div class="text-center">

    <asp:TextBox ID="Textnombre" placeholder="Descripcion" class="input-lg" TextMode="MultiLine" Rows="10" runat="server" Height="101px" Width="402px" MaxLength="100"></asp:TextBox>

         <br />

    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Textnombre" ErrorMessage="Campo Vacio" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

     
    <br />
    <br />
         </div>

    <!--Botones -->

    <div class="text-center">
        <asp:Button ID="Button2" CssClass="btn btn-danger" runat="server" Text="Nuevo"  Height="36px" Width="90px" OnClick="Button2_Click" />
        <asp:Button ID="Guardar" CssClass="btn btn-danger" runat="server" Text="Guardar" Height="36px" ValidationGroup="guardar" Width="90px" OnClick="Button3_Click" />
        <asp:Button ID="Eliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar" Height="36px" ValidationGroup="buscar" Width="90px" OnClick="Eliminar_Click" />
    </div>

    </form>
   

    <p>
    </p>

</asp:Content>
