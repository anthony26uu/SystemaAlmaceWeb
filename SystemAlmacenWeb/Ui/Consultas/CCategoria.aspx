<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="CCategoria.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Consultas.CCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../../Scripts/popper.min.js"></script>
          <!-- Librerias para Toastr -->
    <link href="/../Content/toastr.css" rel="stylesheet" />
    <script src="../../Scripts/toastr.js"></script>
    <script src="../../Scripts/jquery-3.2.1.js"></script>

    <header>
        <h1 class="page-header text-center">Consulta Categorias <span></span></h1>
    </header>

    <div class="text-center">


        <span class="btn btn-danger">Selecione-</span>

        <asp:DropDownList class="btn btn-danger" ID="DropFiltro" runat="server" Height="45px">
            <asp:ListItem>Todo</asp:ListItem>
            <asp:ListItem>ID</asp:ListItem>
            <asp:ListItem>Nombre</asp:ListItem>
        </asp:DropDownList>






        <span class="btn btn-danger">ID / Nombre</span>

        <asp:TextBox ID="buscaText" runat="server" class="input-lg" placeholder="ID a buscar" Height="45px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Buscar" Height="45px" Width="88px" CssClass="btn btn-danger" OnClick="Button1_Click" />

        <br />
        <br />

    </div>

    </div>

                <asp:GridView ID="CategoriasGrid" CssClass="table table-striped table-hover" runat="server">
                </asp:GridView>

    <br />
    <a href="../Reportes/Ventanas/CategoriaReport.aspx" class="btn btn-info btn-lg">
        <span class=""></span>Imprimir
    </a>
    <br />
    <br />
</asp:Content>
