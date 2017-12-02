<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="CClientes.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Consultas.CClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Inclusión de Extras Para evitar Errores-->
    <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>

    <header>
        <h1 class="page-header text-center">CONSULTA CLIENTE <span></span></h1>
    </header>


    <div class="text-center">
        <span class="col-md-2 control-label input-sm">SELECIONE LA OPCION DESEADA</span>
        <div class="col-lg-2 col-md-2">
            <asp:DropDownList ID="DropFiltro" AutoPostBack="true" CssClass="form-control" runat="server" Height="45px" Width="272px" OnSelectedIndexChanged="DropFiltro_SelectedIndexChanged1">
                <asp:ListItem>Todo</asp:ListItem>
                <asp:ListItem>ID</asp:ListItem>
                <asp:ListItem>Fecha</asp:ListItem>
                <asp:ListItem>Nombre</asp:ListItem>
            </asp:DropDownList>
        </div>




        <div class="col-lg-2 col-md-2">
            <asp:TextBox ID="buscaText" runat="server" class="form-control" placeholder="ID  Buscar" Height="45px" Width="234px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="buscaText" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="Buscar"></asp:RegularExpressionValidator>
        </div>

        <div class="col-lg-2 col-md-4">
            <asp:Button ID="Button1" runat="server" Text="Buscar" Height="45px" Width="88px" class="btn btn-warning btn-sm" OnClick="Button1_Click" ValidationGroup="Buscar" />
        </div>

        <span>Desde</span>
        <asp:TextBox ID="desdeFecha" class="input-lg" TextMode="Date" runat="server" Width="212px" Height="45px"></asp:TextBox>
        <span>Hasta</span>
        <asp:TextBox ID="hastaFecha" class="input-lg" TextMode="Date" runat="server" Height="44px" Width="212px"></asp:TextBox>
    </div>
    <br />

   

    <div class="container">
        <div class="col-12 col-sm-20  ">
            <div class="row">
                <div class="center-block" style="overflow: auto;">
                    <asp:GridView ID="ClienteGrid" runat="server" CssClass="  table-responsive" HorizontalAlign="Center" Height="16px" Width="742px">
                        <AlternatingRowStyle BackColor="gray  " />
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>


    <br />

    <div class="modal-footer">
        <div class="text-center">
            <a a href="../Reportes/Ventanas/Clientereport.aspx" class="btn-default">
                <span></span>Imprimir
            </a>
        </div>
    </div>



</asp:Content>
