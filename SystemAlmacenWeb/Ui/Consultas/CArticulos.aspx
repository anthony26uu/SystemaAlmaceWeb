<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="CArticulos.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Consultas.CArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    
       <header>
            <h1 class="page-header text-center">

                  Consulta Articulo <span ></span></h1>
        </header>

          <script src="../../Scripts/popper.min.js"></script>
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
         <asp:Button ID="Button1" runat="server" Text="Buscar" Height="45px" Width="88px" CssClass="btn btn-danger" OnClick="Button1_Click1"  />
 
            
  
          <br />

  
         <span class="btn btn-danger">Desde</span>
          
          
          <asp:TextBox ID="desdeFecha"  class="input-lg" TextMode="Date"  runat="server" Width="212px" Height="45px"></asp:TextBox>
          <span class="btn btn-danger">Hasta</span>
            
            <asp:TextBox ID="hastaFecha"   class="input-lg" TextMode="Date"  runat="server" Height="44px" Width="212px"></asp:TextBox>
 
        <asp:DropDownList ID="DropCategoria" runat="server" class="btn btn-danger" Height="42px" Width="199px">
        </asp:DropDownList>

              <br />
            
            
  

  
          <br />    
     
             
       
     </div>

       </div>

                <asp:GridView ID="ArticuloGrid" runat="server"   CssClass="table table-striped table-hover" >   
                </asp:GridView>
        
   
    
      <br />
        <a href="../Reportes/Ventanas/UsuarioReport.aspx" class="btn btn-danger">
          <span ></span> Imprimir
        </a> 
       
               <br />
    <br />
     

</asp:Content>
