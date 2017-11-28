<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="CDeudas.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Consultas.CDeudas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Inclusión de Extras Para evitar Errores-->
    <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>

    <header>
        <h1 class="page-header text-center">CONSULTA DEUDAS <span></span></h1>
    </header>


    <div class="text-center">
        <span class="col-md-2 control-label input-sm">SELECIONE LA OPCION DESEADA</span>
        <div class="col-lg-2 col-md-2">
            <asp:DropDownList ID="DropFiltro" CssClass="form-control" runat="server" Height="45px" Width="305px">
                <asp:ListItem>Todo</asp:ListItem>
                <asp:ListItem>ID</asp:ListItem>
                <asp:ListItem>Cliente</asp:ListItem>
            </asp:DropDownList>
        </div>

        <span class="col-md-2 control-label ">CLIENTE</span>
        <div class="col-lg-2 col-md-4">
            <asp:DropDownList ID="DropUsuario" runat="server" class="form-control" Height="42px" Width="229px">
            </asp:DropDownList>
        </div>


        <div class="col-lg-2 col-md-2">
            <asp:TextBox ID="buscaText" runat="server" class="form-control" placeholder="ID  Buscar" Height="45px" Width="276px"></asp:TextBox>
        </div>

        <div class="col-lg-2 col-md-4">
            <asp:Button ID="Button1" runat="server" Text="Buscar" Height="45px" Width="88px" class="btn btn-warning btn-sm" OnClick="Button1_Click"  />
        </div>

    </div>

    <br />

    <div class="center-block" style="overflow: auto; width: 1434px; height: 209px;">
        <asp:GridView ID="FacturaGrid" runat="server" CssClass=" table table-striped table-hover table-bordered" HorizontalAlign="Center" Height="16px" Width="742px">
            <AlternatingRowStyle BackColor="gray  " />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>



    <br />

    <div class="modal-footer">
        <div class="text-center">
            <span>TOTAL POR COBRAR</span><asp:TextBox ID="TextBoxTotal" class="input-lg" ReadOnly="true" runat="server" Height="25px" Width="212px"></asp:TextBox>
            <a href="../Reportes/Ventanas/DeudasReport.aspx" class="btn-default">
                <span></span>Imprimir
            </a>
        </div>
    </div>



</asp:Content>