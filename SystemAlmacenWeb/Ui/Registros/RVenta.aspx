<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="RVenta.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Registros.RVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <script src="../../Scripts/popper.min.js"></script>

         <!-- Librerias para Toastr -->
    <link href="/../Content/toastr.css" rel="stylesheet" />
    <script src="../../Scripts/toastr.js"></script>
    <script src="../../Scripts/jquery-3.2.1.js"></script>


    <div class="text-center">


        <h1 class="page-header text-center">Punto De ventas </h1>
        <p class="page-header text-center">&nbsp;</p>
    </div>

     <div class="panel panel-danger">
  <div class="panel-heading">
    <h3 class="panel-title">Datos Factura</h3>
  </div>
  <div class="panel-body">
  


      <asp:DropDownList ID="DropDownList1"  CssClass="btn btn-danger"  runat="server">
      </asp:DropDownList>
  


      <asp:TextBox ID="TextBoxBuscar"  CssClass="btn btn-danger" TextMode="Number" runat="server"></asp:TextBox>
      <asp:Button ID="Buscar" CssClass="btn btn-danger" runat="server" Text="Buscar" Height="36px" Width="88px" OnClick="Buscar_Click"  />






  </div>

</div>



    <div class="panel panel-danger">
  <div class="panel-heading">
    <h3 class="panel-title">Articulos</h3>
  </div>
  <div class="panel-body">
  


      <asp:DropDownList ID="DropArticulo"  CssClass="btn btn-danger"  runat="server">
      </asp:DropDownList>
  


      <asp:TextBox ID="TextBoxCantidad"  CssClass="btn btn-danger" TextMode="Number" runat="server"></asp:TextBox>
  


      <asp:Button ID="Agregar" runat="server" Text="Agregar" OnClick="Agregar_Click" />
  

     

      <asp:TextBox ID="TextBoxTotalITBS"  CssClass="btn btn-danger" TextMode="Number" runat="server"></asp:TextBox>
  


      <asp:TextBox ID="TextBoxSubTotal"  CssClass="btn btn-danger" TextMode="Number" runat="server"></asp:TextBox>
  


      <asp:TextBox ID="TextBoxTotal"  CssClass="btn btn-danger" TextMode="Number" runat="server"></asp:TextBox>
  



  </div>

</div>



    <asp:GridView ID="FacturaGrid" CssClass="table table-striped table-hover" runat="server">
    </asp:GridView>




   <!--Botones -->

    <div class="text-center">
        <asp:Button ID="Button4" CssClass="btn btn-danger" runat="server" Text="Nuevo" Height="36px" Width="88px"   />
        <asp:Button ID="Button2" CssClass="btn btn-danger" runat="server" Text="Guardar" Height="36px" Width="88px" OnClick="Button2_Click"  />
        <asp:Button ID="Button3" CssClass="btn btn-danger" runat="server" Text="Eliminar" Height="36px" Width="88px"  />
    </div>

    <br />






</asp:Content>
