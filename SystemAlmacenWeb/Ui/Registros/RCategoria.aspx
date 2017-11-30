<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="RCategoria.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Registros.RCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Inclusión de Extras Para evitar Errores-->
    <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>

    <div class="text-center">
        <h3 class="page-header text-center">REGISTRO CATEGORIA <span></span></h3>
    </div>


    <div class="text-center">
        <span class="badge badge-primary">ID Categoria</span><br />
        <br />
        <asp:TextBox ID="Textid" placeholder="Id a Buscar" class="input-lg" TextMode="Number" runat="server" Height="45px" Width="165px" ValidationGroup="buscar" MaxLength="10"></asp:TextBox>
        <asp:Button ID="Button1" CssClass=" btn btn-default" runat="server" Text="Buscar" Height="45px" ValidationGroup="buscar" OnClick="Button1_Click" Width="97px" />
        <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Textid" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="buscar"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Textid" ErrorMessage="Campo Id vacio" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="buscar"></asp:RequiredFieldValidator>
        <br />
        <br />
    </div>


    <div class="text-center">
        <span class="badge badge-primary">Descripcion</span><br />
        <asp:TextBox ID="Textnombre" placeholder="Descripcion" class="input-lg" TextMode="MultiLine" Rows="10" runat="server" Height="101px" Width="402px" MaxLength="100"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Textnombre" ErrorMessage="Campo Vacio" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>
        <br />
        <br />
    </div>

    <!--Botones -->

    <div class="modal-footer">
        <div class=" text-center">
            <asp:Button ID="Button2" CssClass="btn btn-warning" runat="server" Text="Nuevo" Height="36px" Width="90px" OnClick="Button2_Click" />
            <asp:Button ID="Guardar" CssClass="btn btn-success" runat="server" Text="Guardar" Height="36px" ValidationGroup="guardar" Width="90px" OnClick="Button3_Click" />
            <asp:Button ID="Eliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar" Height="36px" ValidationGroup="buscar" Width="90px" OnClick="Eliminar_Click" />
        </div>
    </div>


</asp:Content>
