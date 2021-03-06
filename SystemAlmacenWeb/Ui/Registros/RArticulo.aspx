﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="RArticulo.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Registros.RArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Inclusión de Extras Para evitar Errores-->
    <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>



    <div class="text-center">

        <h3 class="page-header text-center">REGISTRO ARTICULO <span></span></h3>


        <span class="badge badge-primary">ID </span>
        <br />

        <asp:TextBox ID="TextBoxID" TextMode="Number" class="input-lg" placeholder="ID a buscar " runat="server" Height="45px" Width="160px" ValidationGroup="buscar" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxID" ErrorMessage="**" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="Buscar"></asp:RequiredFieldValidator>
        <asp:Button ID="BotonBuscar" CssClass=" btn btn-default" runat="server" Text="Buscar" Height="45px" ValidationGroup="Buscar" OnClick="BotonBuscar_Click" Width="93px" />
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxID" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="Buscar"></asp:RegularExpressionValidator>
    </div>
    <br />


    <!--Texbox -->
    <div class="text-center">



        <span class="badge badge-primary">Nombre Articulo</span><br />

        <asp:TextBox ID="TextBoxNombre" placeholder="Nombre Articulo" class="input-lg" runat="server" Height="30px" Width="215px" MaxLength="100"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNombre" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <br />
        <br />
        <span class="badge badge-primary">Fecha Ingreso</span><br />

        <!--Texbox -->

        <asp:TextBox ID="TextFecha" runat="server" placeholder="00/00/0000 " class="input-lg" ReadOnly="True" Width="215px" Height="30px"></asp:TextBox>


        <br />
        <br />
        <span class="badge badge-primary">Existencia</span><br />


        &nbsp;

       
          <!--Texbox -->

        <asp:TextBox ID="TextBoxExistencia" placeholder="Existencia" class="input-lg" TextMode="Number" runat="server" Height="30px" Width="215px" ValidationGroup="guardar" MaxLength="10"></asp:TextBox>


        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxExistencia" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>


        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBoxExistencia" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="guardar"></asp:RegularExpressionValidator>

        <br />
        <span class="badge badge-primary">Costo</span><br />


        <!--Texbox -->

        <asp:TextBox ID="TexboCosto" placeholder="Costo" class="input-lg" runat="server" Height="30px" Width="215px" ValidationGroup="guardar" MaxLength="10"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TexboCosto" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TexboCosto" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="guardar"></asp:RegularExpressionValidator>

        <br />
        <span class="badge badge-primary">Precio</span><br />

        <asp:TextBox ID="TexboPrecio" placeholder="Precio" class="input-lg" runat="server" Height="30px" Width="215px" ValidationGroup="guardar" MaxLength="10"></asp:TextBox>

        <!--Select -->

        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TexboPrecio" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TexboPrecio" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="guardar"></asp:RegularExpressionValidator>

        <br />
        <span class="badge badge-primary">Codigo</span><br />

        <asp:TextBox ID="TexboCodigo" placeholder="Codigo" class="input-lg" runat="server" Height="30px" Width="215px" ValidationGroup="guardar" MaxLength="12"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TexboCodigo" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <br />
        <br />
        <span class="badge badge-primary">ITBIS</span><br />

        <asp:TextBox ID="TexboItbis" placeholder="ITBS" TextMode="Number" class="input-lg" runat="server" Height="30px" Width="215px" ValidationGroup="guardar" Rows="3"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TexboItbis" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="TexboItbis" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="guardar"></asp:RegularExpressionValidator>

        <br />
        <span class="badge badge-primary">Categoria Articulo</span><br />

        <asp:DropDownList ID="DropCategoria" runat="server" CssClass="btn btn-default" Height="42px" Width="199px">
        </asp:DropDownList>

        <br />
        <br />
    </div>



    <!--Botones -->
    <div class="modal-footer">
        <div class=" text-center">
            <asp:Button ID="Button4" CssClass="btn btn-warning" runat="server" Text="Nuevo" Height="36px" Width="88px" ValidationGroup="guardar" OnClick="Button4_Click" />
            <asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Guardar" Height="36px" Width="88px" ValidationGroup="guardar" OnClick="Button2_Click" />
            <asp:Button ID="Button3" CssClass="btn btn-danger" runat="server" Text="Eliminar" Height="36px" Width="88px" ValidationGroup="Buscar" OnClick="Button3_Click" />

        </div>
    </div>

</asp:Content>
