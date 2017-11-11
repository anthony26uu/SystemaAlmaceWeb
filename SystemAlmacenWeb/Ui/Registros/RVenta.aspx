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


        <h4 class=" text-center">Punto De ventas 
            </h4>


     
    </div>

     <div class="panel panel-danger">
  <div class="panel-heading">
    <h2 class="panel-title">Datos Factura</h2>
  </div>
  <div class="panel-body">
  
            <asp:TextBox ID="TextBoxBuscar"  CssClass="btn btn-danger" TextMode="Number" runat="server"></asp:TextBox>
      <asp:Button ID="Buscar" CssClass="btn btn-danger" runat="server" Text="Buscar" Height="36px" Width="88px" OnClick="Buscar_Click"  />

       <span class="badge badge-primary">Articulos Vendidos</span>
        <asp:TextBox ID="TexboxCantidad"  placeholder="Cantidad "   disabled="true" CssClass="  input-lg  "  Height="16px"   Width="160px" runat="server"></asp:TextBox>
  

      <span class="badge badge-primary">Cliente </span>
        <asp:TextBox ID="TexCliente"  placeholder="Cliente "   disabled="true" CssClass="  input-lg  "  Height="16px"   Width="160px" runat="server"></asp:TextBox>
  
      <span class="badge badge-primary">Vendedor</span>
        <asp:TextBox ID="TextBoxVendedor"  placeholder="Usuario "   disabled="true" CssClass="  input-lg  "  Height="16px"   Width="160px" runat="server"></asp:TextBox>
  
      <span class="badge badge-primary">Fecha Venta</span>
        <asp:TextBox ID="TextFecha"  placeholder="Fecha "   disabled="true" CssClass="  input-lg  "  Height="16px"   Width="160px" runat="server"></asp:TextBox>
  


  

  </div>

</div>



    <div class="panel panel-danger">
  <div class="panel-heading">
    <h4 class="panel-title">Articulos</h4>
  </div>
  <div class="panel-body">
   

       <asp:DropDownList ID="DropArticulo"  CssClass="btn btn-danger"  runat="server">
      </asp:DropDownList>
  
      <asp:TextBox ID="TextBoxCantidad"  CssClass="btn btn-danger " TextMode="Number" runat="server"></asp:TextBox>



      <asp:Button ID="Agregar" runat="server" Text="Agregar" OnClick="Agregar_Click" />



  </div>

</div>



    <asp:GridView ID="FacturaGrid" CssClass="table table-striped table-hover" runat="server">
    </asp:GridView>




   <!--Botones -->


    <div class="text-left">
        <asp:Button ID="Button4" CssClass="btn btn-danger" runat="server" Text="Nuevo" Height="36px" Width="88px" OnClick="Button4_Click"   />
        <asp:Button ID="Button2" CssClass="btn btn-danger" runat="server" Text="Guardar" Height="36px" Width="88px" OnClick="Button2_Click"  />
        <asp:Button ID="Button3" CssClass="btn btn-danger" runat="server" Text="Eliminar" Height="36px" Width="88px"  />

 



       &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
         <span class="badge badge-primary">Total ITBS</span>
        <asp:TextBox ID="TextBoxTotalITBS"  placeholder="TOTAL ITBS "   disabled="true" CssClass="  input-lg  "  Height="16px"   Width="160px" runat="server"></asp:TextBox>
  
        <span class="badge badge-primary">SUB-TOTAL</span>
      <asp:TextBox ID="TextBoxSubTotal"  CssClass=" input-lg "  placeholder="Sub-Total "  disabled="true"   runat="server"   Width="160px" Height="16px"></asp:TextBox>
  

        <span class="badge badge-primary">TOTAL</span>
      <asp:TextBox ID="TextBoxTotal"  CssClass="  input-lg "  placeholder="Total "   disabled="true" Height="16px"  runat="server" Width="160px"></asp:TextBox>
         
        <span class="badge badge-primary">DEVUELTA</span>
       <asp:TextBox ID="TexboxDevuelta"  CssClass=" input-lg  "  placeholder="Devuelta "   disabled="true"   Height="16px"  Width="160px"  runat="server"></asp:TextBox>
   
           </div>

    <br />






</asp:Content>
