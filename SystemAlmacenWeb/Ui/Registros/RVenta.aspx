<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="RVenta.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Registros.RVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <!--Inclusión de Extras Para evitar Errores-->
     <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>   
    <script src="/Scripts/bootstrap.min.js"></script> 


    <div class="text-center">


        <h4 class=" text-center">Punto De ventas 
        </h4>



    </div>

      <div class="panel panel-primary">
        <div class="panel-heading">

            <h2 class="panel-title">Datos Factura</h2>
        </div>
        <div class="panel-body">

            <asp:TextBox ID="TextBoxBuscar" CssClass=" input-lg" TextMode="Number" runat="server" Height="16px" Width="114px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxBuscar" ErrorMessage="**" Font-Bold="True" Font-Italic="True" ForeColor="White" ValidationGroup="Buscar"></asp:RequiredFieldValidator>
            <asp:Button ID="Buscar" CssClass="btn btn-danger" runat="server" Text="Buscar" Height="36px" Width="88px" OnClick="Buscar_Click" ValidationGroup="Buscar" />

            <asp:DropDownList ID="DropDownTipoVenta" CssClass="btn btn-danger" runat="server" OnSelectedIndexChanged="DropDownTipoVenta_SelectedIndexChanged">
               
                <asp:ListItem>Contado</asp:ListItem>
                 <asp:ListItem>Credito</asp:ListItem>
            </asp:DropDownList>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="badge badge-primary">%Descuento</span>
            <asp:TextBox ID="DescuentoTextBox" CssClass=" input" TextMode="Number" runat="server" Height="16px" Width="38px"></asp:TextBox>
            &nbsp;

        <span class="badge badge-primary">Cliente a Comprar </span>
            <asp:DropDownList ID="DropDownCliente" CssClass="btn btn-danger" runat="server" ValidationGroup="guardar">
            </asp:DropDownList>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DropDownCliente" ErrorMessage="**" Font-Bold="True" Font-Italic="True" ForeColor="White" ValidationGroup="guardar"></asp:RequiredFieldValidator>

            <asp:Button ID="ButtonNuevoCliente" CssClass="btn btn-danger" runat="server" Text="Nuevo" Height="36px" Width="79px" />

            &nbsp;<span class="badge badge-primary">Vendedor</span>
            <asp:TextBox ID="TextBoxVendedor" placeholder="Usuario " disabled="true" CssClass="  input-lg  " Height="16px" Width="160px" runat="server"></asp:TextBox>

            <span class="badge badge-primary">Fecha</span>
            <asp:TextBox ID="TextFecha" placeholder="Fecha " disabled="true" CssClass="  input-lg  " Height="16px" Width="160px" runat="server"></asp:TextBox>





            &nbsp;&nbsp;
  
      <span class="badge badge-primary">Cliente</span><asp:TextBox ID="TexboxClienteCompro" placeholder="Compro" disabled="true" CssClass="  input-lg  " Height="16px" Width="160px" runat="server"></asp:TextBox>





        </div>

    </div>



    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4 class="panel-title">Articulos</h4>
        </div>
        <div class="panel-body">


            <asp:DropDownList ID="DropArticulo" CssClass="btn btn-danger" runat="server" ValidationGroup="agregar" OnSelectedIndexChanged="DropArticulo_SelectedIndexChanged">
            </asp:DropDownList>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DropArticulo" ErrorMessage="**" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="agregar"></asp:RequiredFieldValidator>

            <asp:TextBox ID="TextBoxCantidad" Height="16px" Width="114px" CssClass=" input-lg " TextMode="Number" runat="server" ValidationGroup="agregar"></asp:TextBox>



        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxCantidad" ErrorMessage="**" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="agregar"></asp:RequiredFieldValidator>



            <asp:Button ID="Agregar" CssClass="btn btn-danger" runat="server" Text="Agregar" OnClick="Agregar_Click" ValidationGroup="agregar" Width="113px" />



            &nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DropArticulo" ErrorMessage="Registre Articulo" Font-Bold="True" Font-Italic="True" ForeColor="White" ValidationGroup="agregar"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;
     
      <span class="badge badge-primary">Articulos Vendidos</span><asp:TextBox ID="TexboxCantidad" placeholder="Cantidad " disabled="true" CssClass="  input-lg  " Height="16px" Width="160px" runat="server"></asp:TextBox>



        </div>

    </div>


    <div class="center-block" style="overflow: auto; width: 1100px; height: 260px;">




        <asp:GridView ID="FacturaGrid" HorizontalAlign="Center" ShowFooter="True" CssClass="table table-striped  table-info " runat="server" Width="767px">
        </asp:GridView>


    </div>

    <!--Botones -->

       <div class="text-left">
 

        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
       
         <span class="label-default">Total ITBS</span>
        <asp:TextBox ID="TextBoxTotalITBS" placeholder="TOTAL ITBS " disabled="true" CssClass="  input-lg  " Height="16px" Width="160px" runat="server"></asp:TextBox>

        <span class="label-default">SUB-TOTAL</span>
        <asp:TextBox ID="TextBoxSubTotal" CssClass=" input-lg " placeholder="Sub-Total " disabled="true" runat="server" Width="160px" Height="16px"></asp:TextBox>


        <span class="label-default">TOTAL</span>
        <asp:TextBox ID="TextBoxTotal" CssClass="  input-lg " placeholder="Total " disabled="true" Height="16px" runat="server" Width="160px"></asp:TextBox>


        <span class="label-default">Monto</span>
        <asp:TextBox ID="TextMontoRecibido" CssClass=" input-lg  " DefaultButton="BotonCalcularDevuelta" placeholder="Monto " Height="16px" Width="160px" runat="server" OnTextChanged="TextMontoRecibido_TextChanged"></asp:TextBox>
         <asp:ImageButton ID="BotonCalcularDevuelta" runat="server" Height="46px" ImageUrl="~/Content/Img/if_MetroUI_Calculator_176505.png" Width="46px" OnClick="BotonCalcularDevuelta_Click" />


        <span class=" label-default">DEVUELTA</span>
        <asp:TextBox ID="TexboxDevuelta" CssClass=" input-lg  " placeholder="Devuelta " disabled="true" Height="16px" Width="160px" runat="server"></asp:TextBox>
    </div>

   
    <br />

    <div class="text-center">
        <asp:Button ID="Button4" CssClass="btn btn-warning" runat="server" Text="Limpiar" Height="36px" Width="88px" OnClick="Button4_Click" />
        <asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Guardar" Height="36px" Width="88px" OnClick="Button2_Click" ValidationGroup="guardar" />
        <asp:Button ID="Button3" CssClass="btn btn-danger" runat="server" Text="Eliminar" Height="36px" Width="88px" OnClick="Button3_Click" />



    </div>
          <br />




</asp:Content>


