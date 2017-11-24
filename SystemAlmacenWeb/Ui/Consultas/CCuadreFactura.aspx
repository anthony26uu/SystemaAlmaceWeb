<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="CCuadreFactura.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Consultas.CCuadreFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <header>
        <h1 class="page-header text-center">Cuadre Factura <span></span></h1>
    </header>

    <script src="../../Scripts/popper.min.js"></script>
    <!-- Librerias para Toastr -->
    <link href="/../Content/toastr.css" rel="stylesheet" />
    <script src="../../Scripts/toastr.js"></script>
    <script src="../../Scripts/jquery-3.2.1.js"></script>

    <div class="text-center">

        <span class="btn btn-danger">Selecione-</span>
        <asp:DropDownList ID="DropFiltro" CssClass="btn-success" runat="server" Height="45px">

            <asp:ListItem>Todo</asp:ListItem>
            <asp:ListItem>ID</asp:ListItem>
            <asp:ListItem>Fecha</asp:ListItem>
            <asp:ListItem>Usuario Vendio</asp:ListItem>
        </asp:DropDownList>






        <asp:DropDownList ID="DropUsuario" runat="server" class="btn-success" Height="42px" Width="199px">
        </asp:DropDownList>






        <br />






        <span class="btn btn-danger">ID/Nombre</span>
        <asp:TextBox ID="buscaText" runat="server" class="input-lg" placeholder="ID a buscar" Height="45px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Buscar" Height="45px" Width="88px" CssClass="btn btn-info" OnClick="Button1_Click" />



        <br />


        <span class="btn btn-danger">Desde</span>


        <asp:TextBox ID="desdeFecha" class="input-lg" TextMode="Date" runat="server" Width="212px" Height="45px"></asp:TextBox>
        <span class="btn btn-danger">Hasta</span>

        <asp:TextBox ID="hastaFecha" class="input-lg" TextMode="Date" runat="server" Height="44px" Width="212px"></asp:TextBox>

        <br />





        <br />



    </div>

    <div class="center-block" style="overflow: auto; width: 1434px; height: 315px;">



        <asp:GridView ID="FacturaGrid" runat="server" CssClass=" table table-striped table-hover table-bordered" HorizontalAlign="Center" Height="244px" Width="942px">
        </asp:GridView>

    </div>

    <br />
    <a href="../Reportes/Ventanas/FacturaReport.aspx" class="btn btn-info">
        <span></span>Imprimir
    </a>
    
        <asp:TextBox ID="TextBoxTotal" class="input-lg" ReadOnly="true" runat="server" Height="44px" Width="212px"></asp:TextBox>

        
    <br />
    <br />

</asp:Content>
