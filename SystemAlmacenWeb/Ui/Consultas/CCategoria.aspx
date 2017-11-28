<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="CCategoria.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Consultas.CCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <!--Inclusión de Extras Para evitar Errores-->
     <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>   
    <script src="/Scripts/bootstrap.min.js"></script> 

    <header>
        <h1 class="page-header text-center">CONSULTAS CATEGORIA <span></span></h1>
    </header>

    <div class="text-center">


        <span class="btn btn-danger">Selecione-</span>

        <asp:DropDownList class="btn-danger" ID="DropFiltro" runat="server" Height="45px">
            <asp:ListItem>Todo</asp:ListItem>
            <asp:ListItem>ID</asp:ListItem>
            <asp:ListItem>Nombre</asp:ListItem>
        </asp:DropDownList>






        <span class="btn btn-danger">ID / Nombre</span>

        <asp:TextBox ID="buscaText" runat="server" class="input-lg" placeholder="ID a buscar" Height="45px" Width="94px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Buscar" Height="45px" Width="88px" CssClass="btn btn-danger" OnClick="Button1_Click" />

        <br />
        <br />

    </div>

   
         <div  class="center-block" style="overflow: auto; width: 1487px;  height: 259px;">



                <asp:GridView ID="CategoriasGrid" ClientIDMode="Static"  ShowFooter="True" PageIndex="2" PageSize="2"  CellPadding="0" CssClass="table table-striped table-hover"  HorizontalAlign="Center" runat="server" Width="971px" Height="192px">
                </asp:GridView>
              </div>

    <br />
    <a href="../Reportes/Ventanas/CategoriaReport.aspx" class="btn btn-info btn-danger">
        <span class=""></span>Imprimir
    </a>
    <br />
    <br />
</asp:Content>
