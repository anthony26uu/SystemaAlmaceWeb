<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="SaldarDeudas.aspx.cs" Inherits="SystemAlmacenWeb.Ui.SaldarDeudas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Inclusión de Extras Para evitar Errores-->
    <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>

    <div class="text-center">
        <h2 class="page-header text-center text">SALDAR DEUDAS<span></span></h2>
    </div>





    <div class="text-center">

        <span class="badge badge-primary">Usuario ID</span>
        <br />


        <asp:TextBox ID="TextBoxID" TextMode="Number" class="input-lg" placeholder="ID a buscar " runat="server" Height="45px" Width="160px" ValidationGroup="buscar"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxID" ErrorMessage="**" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="buscar"></asp:RequiredFieldValidator>
        <asp:Button ID="BotonBuscar" CssClass=" btn btn-default" runat="server" Text="Buscar" Height="45px" ValidationGroup="buscar" Width="106px" OnClick="BotonBuscar_Click" />
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBoxID" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="buscar"></asp:RegularExpressionValidator>

        <br />
        <!--Texbox -->





        <span class="badge badge-primary">Nombre Cliente</span>


        <br />


        <asp:TextBox ID="TextBoxNombre" class="input-lg" runat="server" Height="30px" Width="215px" ReadOnly="True"></asp:TextBox>

        <br />

        <br />

        <span class="badge badge-primary">Monto Deuda</span>
        <br />
        <asp:TextBox ID="TextMonto" runat="server" class="input-lg" ReadOnly="True" Height="30px" Width="221px"></asp:TextBox>


        <br />


        &nbsp;

       
          <!--Texbox -->

        <br />


        <!--Texbox -->

        <span class="badge badge-primary">Monto Abonar</span><br />
        <asp:TextBox ID="TextBoxAbono" class="input-lg" runat="server" Height="30px" Width="215px"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxAbono" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TextBoxAbono" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="guardar"></asp:RegularExpressionValidator>

        <br />
        <asp:Button ID="ButtonCalcular" CssClass="btn btn-success" runat="server" Text="Calcular" Height="36px" Width="88px" OnClick="ButtonCalcular_Click" />

        <br />
        <br />

        <span class="badge badge-primary">Devuelta o Dinero</span><br />
        <asp:TextBox ID="TextBoxDinero" class="input-lg" runat="server" Height="30px" Width="215px" ReadOnly="True"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxDinero" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <br />

        <br />
        <br />



        <br />
    </div>





    <!--Botones -->

    <div class="modal-footer">
        <div class=" text-center">
            <asp:Button ID="ButtoNuevo" CssClass="btn btn-warning" runat="server" Text="Nuevo" Height="36px" Width="88px" OnClick="ButtoNuevo_Click" />
            <asp:Button ID="ButtonGuardar" CssClass="btn btn-success" runat="server" Text="Guardar" Height="36px" Width="88px" ValidationGroup="guardar" OnClick="ButtonGuardar_Click" />
            <asp:Button ID="ButtonEliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar" Height="36px" Width="88px" ValidationGroup="buscar" OnClick="ButtonEliminar_Click" />
        </div>
    </div>


</asp:Content>
