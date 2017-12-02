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
            <asp:DropDownList ID="DropFiltro" AutoPostBack="true" CssClass="form-control" runat="server" Height="45px" Width="305px" OnSelectedIndexChanged="DropFiltro_SelectedIndexChanged">
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
            <asp:TextBox ID="buscaText" runat="server" class="form-control" placeholder="ID  Buscar" Height="45px" Width="276px" ValidationGroup="Buscar"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="buscaText" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="Buscar"></asp:RegularExpressionValidator>
        </div>

        <div class="col-lg-2 col-md-4">
            <asp:Button ID="Button1" runat="server" Text="Buscar" Height="45px" Width="88px" class="btn btn-warning btn-sm" OnClick="Button1_Click" ValidationGroup="Buscar" />
        </div>
    </div>
    <br />


   <br />

    <br />
     <br />

    <br />

    <div class="container">
        <div class="col-12 col-sm-20  ">
            <div class="row">
              <div class="center-block" style="overflow: auto;">
                     <asp:GridView ID="DeudasGrid" runat="server" CssClass="  table-responsive" HorizontalAlign="Center" Height="16px" Width="742px">
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
            <span>TOTAL POR COBRAR</span><asp:TextBox ID="TextBoxTotal" class="input-lg" ReadOnly="true" runat="server" Height="25px" Width="212px"></asp:TextBox>
            <a href="../Reportes/Ventanas/DeudasReport.aspx" class="btn-default">
                <span></span>Imprimir
            </a>
        </div>
    </div>



</asp:Content>
