<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="RArticulo.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Registros.RArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script src="../../../Scripts/popper.min.js"></script>
  
    <!-- Librerias para Toastr -->
    <link href="/../Content/toastr.css" rel="stylesheet" />
    <script src="../../Scripts/toastr.js"></script>
    <script src="../../Scripts/jquery-3.2.1.js"></script>



    



    <div class="text-center">
        
        <h2 class="page-header text-center">Registro Articulo <span></span></h2>
    

        <span class="badge badge-primary">ID </span>
        <br />

        <asp:TextBox ID="TextBoxID"  TextMode="Number" class="input-lg" placeholder="ID a buscar " runat="server" Height="45px" Width="160px" ValidationGroup="buscar"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxID" ErrorMessage="**" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="Buscar"></asp:RequiredFieldValidator>
        <asp:Button ID="BotonBuscar" CssClass="col-md-3 col-sm-3 btn btn-default" runat="server" Text="Buscar" Height="45px" ValidationGroup="Buscar" OnClick="BotonBuscar_Click"  />
    </div>
    <br />


    <!--Texbox -->
    <div class="text-center">

  
    
        <span class="badge badge-primary">Nombre Articulo</span><br />

        <asp:TextBox ID="TextBoxNombre" placeholder="Nombre Articulo" class="input-lg" runat="server" Height="30px" Width="215px"></asp:TextBox>

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

        <asp:TextBox ID="TextBoxExistencia" placeholder="Existencia" class="input-lg" TextMode="Number" runat="server" Height="30px" Width="215px" ValidationGroup="guardar"></asp:TextBox>


        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxExistencia" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>


        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBoxExistencia" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="guardar"></asp:RegularExpressionValidator>

        <br />
        <span class="badge badge-primary">Costo</span><br />


        <!--Texbox -->

        <asp:TextBox ID="TexboCosto"  placeholder="Costo" class="input-lg"  runat="server" Height="30px" Width="215px" ValidationGroup="guardar"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TexboCosto" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TexboCosto" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="guardar"></asp:RegularExpressionValidator>

        <br />
        <span class="badge badge-primary">Precio</span><br />

        <asp:TextBox ID="TexboPrecio"  placeholder="Precio" class="input-lg"  runat="server" Height="30px" Width="215px" ValidationGroup="guardar"></asp:TextBox>

        <!--Select -->

        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TexboPrecio" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TexboPrecio" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="guardar"></asp:RegularExpressionValidator>

        <br />
        <span class="badge badge-primary">Codigo</span><br />

        <asp:TextBox ID="TexboCodigo"  placeholder="Codigo" class="input-lg"  runat="server" Height="30px" Width="199px" ValidationGroup="guardar"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TexboCodigo" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <br />
        <br />
        <span class="badge badge-primary">ITBIS</span><br />

        <asp:TextBox ID="TexboItbis"  placeholder="ITBS" class="input-lg"  runat="server" Height="30px" Width="199px" ValidationGroup="guardar"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TexboItbis" ErrorMessage="**" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="TexboItbis" ErrorMessage="Solo Numeros y Numeros positivos" ForeColor="Red" ValidationExpression="\d+" ValidationGroup="guardar"></asp:RegularExpressionValidator>

        <br />
        <span class="badge badge-primary">Categoria Articulo</span><br />

        <asp:DropDownList ID="DropCategoria" runat="server" CssClass="col-md-3 col-sm-3 btn btn-default" Height="42px" Width="199px">
        </asp:DropDownList>

        <br />
        <br />
    </div>
          </div>

  
      
    <!--Botones -->

    <div class="text-center">
        <asp:Button ID="Button4" CssClass="btn btn-warning" runat="server" Text="Nuevo" Height="36px" Width="88px" ValidationGroup="guardar" OnClick="Button4_Click"/>
        <asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Guardar" Height="36px" Width="88px" ValidationGroup="guardar" OnClick="Button2_Click" />
        <asp:Button ID="Button3" CssClass="btn btn-danger" runat="server" Text="Eliminar" Height="36px" Width="88px" ValidationGroup="Buscar" OnClick="Button3_Click"  />
    </div>

    <br />
</asp:Content>
