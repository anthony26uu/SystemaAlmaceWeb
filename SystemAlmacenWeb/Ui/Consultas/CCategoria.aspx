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


        <span class="col-md-3 control-label input-sm">SELECIONE LA OPCION DESEADA</span>
        <div class="col-lg-2 col-md-2">
            <asp:DropDownList CssClass="form-control" ID="DropFiltro" runat="server" Height="45px">
                <asp:ListItem>Todo</asp:ListItem>
                <asp:ListItem>ID</asp:ListItem>
                <asp:ListItem>Nombre</asp:ListItem>
            </asp:DropDownList>
        </div>





        <span class="col-md-2 control-label ">ID / NOMBRE</span>
        <div class="col-lg-2 col-md-4">

            <asp:TextBox ID="buscaText" runat="server" class="form-control" placeholder="ID a buscar"></asp:TextBox>
        </div>
        <div class="col-lg-2 col-md-6">
            <asp:Button ID="Button1" runat="server" CssClass="btn-warning" Text="Buscar" Height="45px" Width="88px" OnClick="Button1_Click" />
        </div>
        <br />
        <br />

    </div>


    <div class="center-block" style="overflow: auto; width: 1487px; height: 259px;">
        <asp:GridView ID="CategoriasGrid" runat="server" CssClass=" table table-striped table-hover table-bordered" HorizontalAlign="Center" Height="16px" Width="742px">
            <AlternatingRowStyle BackColor="gray  " />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>

  

    <br />

    <div class="modal-footer">
        <div class="text-center">
            <a href="../Reportes/Ventanas/CategoriaReport.aspx" class="btn-default">
                <span></span>Imprimir
            </a>
        </div>
    </div>

    <br />
</asp:Content>
