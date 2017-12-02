<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="CUsuarios.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Consultas.CUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Inclusión de Extras Para evitar Errores-->
    <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>

    <header>
        <h1 class="page-header text-center">CONSULTA USUARIO <span></span></h1>
    </header>



    <div class="text-center">

        <span>SELECIONE LA OPCION DESEADA</span>
        <asp:DropDownList ID="DropFiltro" CssClass="btn-default" runat="server" Height="45px">
            <asp:ListItem>Todo</asp:ListItem>
            <asp:ListItem>ID</asp:ListItem>
            <asp:ListItem>Fecha</asp:ListItem>
            <asp:ListItem>Nombre</asp:ListItem>
            <asp:ListItem>Tipo</asp:ListItem>
        </asp:DropDownList>


        <span>ID / NOMBRE</span>
        <asp:TextBox ID="buscaText" runat="server" class="input-lg" placeholder="ID a buscar" Height="45px" Width="189px" ValidationGroup="Buscar"></asp:TextBox>
        &nbsp;
        <asp:Button ID="Button1" runat="server" CssClass="btn-warning" Text="Buscar" Height="45px" Width="96px" OnClick="Button1_Click1" ValidationGroup="Buscar" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="buscaText" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="Buscar"></asp:RegularExpressionValidator>

        <br />


        <span>DESDE</span>
        <asp:TextBox ID="desdeFecha" class="input-lg" TextMode="Date" runat="server" Width="212px" Height="45px"></asp:TextBox>
        <span>HASTA</span>
        <asp:TextBox ID="hastaFecha" class="input-lg" TextMode="Date" runat="server" Height="44px" Width="212px"></asp:TextBox>

        <asp:DropDownList ID="DropTipo" AutoPostBack="true" runat="server" Height="42px" Width="199px" OnSelectedIndexChanged="DropTipo_SelectedIndexChanged">
            <asp:ListItem>Administrador</asp:ListItem>
            <asp:ListItem>Empleado</asp:ListItem>
        </asp:DropDownList>

        <br />
        <br />

    </div>

    <div class="container">
        <div class="col-12 col-sm-20  ">
            <div class="row">
                <div class="center-block" style="overflow: auto;">
                    <asp:GridView ID="UsuarioGrid" runat="server" CssClass="  table-responsive" HorizontalAlign="Center" Height="16px" Width="742px">
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
            <a href="../Reportes/Ventanas/UsuarioReport.aspx" class="btn-default">
                <span></span>Imprimir
            </a>
        </div>
    </div>





</asp:Content>
