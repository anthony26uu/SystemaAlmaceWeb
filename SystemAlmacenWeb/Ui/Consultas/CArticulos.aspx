<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="CArticulos.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Consultas.CArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    
       <header>
            <h1 class="page-header text-center">

                  Consulta Articulo <span ></span></h1>
        </header>

          <script src="../../Scripts/popper.min.js"></script>
     <!-- Librerias para Toastr -->
    <link href="/../Content/toastr.css" rel="stylesheet" />
    <script src="../../Scripts/toastr.js"></script>
    <script src="../../Scripts/jquery-3.2.1.js"></script>

 <div class= "text-center">
     
          <span class="btn btn-danger">Selecione-</span>
          <asp:DropDownList ID="DropFiltro" CssClass="btn btn-danger" runat="server" Height="45px"> 
            
              <asp:ListItem>Todo</asp:ListItem>
              <asp:ListItem>ID</asp:ListItem>
              <asp:ListItem>Fecha</asp:ListItem>
              <asp:ListItem>Nombre</asp:ListItem>
              <asp:ListItem>Categoria</asp:ListItem>
          </asp:DropDownList>
      
               

       
        
           
          <span class="btn btn-danger">ID / Descripcion</span>
          <asp:TextBox ID="buscaText" runat="server"    class="input-lg" placeholder="ID a buscar" Height="45px" ></asp:TextBox>
         <asp:Button ID="Button1" runat="server" Text="Buscar" Height="45px" Width="88px" CssClass="btn btn-info" OnClick="Button1_Click1"  />
 
            
  
          <br />

  
         <span class="btn btn-danger">Desde</span>
          
          
          <asp:TextBox ID="desdeFecha"  class="input-lg" TextMode="Date"  runat="server" Width="212px" Height="45px"></asp:TextBox>
          <span class="btn btn-danger">Hasta</span>
            
            <asp:TextBox ID="hastaFecha"   class="input-lg" TextMode="Date"  runat="server" Height="44px" Width="212px"></asp:TextBox>
 
        <asp:DropDownList ID="DropCategoria" runat="server" class="btn-success" Height="42px" Width="199px">
        </asp:DropDownList>

              <br />
            
            
  

  
          <br />    
     
             
       
     </div>

          <div   class="center-block"style="overflow: auto; width: 1434px; height: 315px;">



                <asp:GridView ID="ArticuloGrid" runat="server"   CssClass=" table table-striped table-hover table-bordered"  CellPadding="0" ClientIDMode="Static"  HorizontalAlign="Center" Height="244px" Width="942px" >   
                </asp:GridView>
        
    </div>
    
      <br />
        <a href="../Reportes/Ventanas/ArticuloReport.aspx" class="btn btn-info">
          <span ></span> Imprimir
        </a> 
       
               <br />
    <br />
     

</asp:Content>
