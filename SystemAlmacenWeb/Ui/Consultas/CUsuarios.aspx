<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="CUsuarios.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Consultas.CUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <!--Inclusión de Extras Para evitar Errores-->
     <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>   
    <script src="/Scripts/bootstrap.min.js"></script> 
    
       <header>
            <h1 class="page-header text-center">

                  Consulta Usuario <span ></span></h1>
        </header>

    

 <div class= "text-center">
     
          <span class="btn btn-danger">Selecione-</span>
          <asp:DropDownList ID="DropFiltro"  CssClass="btn-danger" runat="server" Height="45px"> 
            
              <asp:ListItem>Todo</asp:ListItem>
              <asp:ListItem>ID</asp:ListItem>
              <asp:ListItem>Fecha</asp:ListItem>
              <asp:ListItem>Nombre</asp:ListItem>
              <asp:ListItem>Tipo</asp:ListItem>
          </asp:DropDownList>
      
               

       
        
           
          <span class="btn btn-danger">ID / Nombre</span>
          <asp:TextBox ID="buscaText" runat="server"    class="input-lg" placeholder="ID a buscar" Height="45px" Width="130px" ></asp:TextBox>
         <asp:Button ID="Button1" runat="server" Text="Buscar" Height="45px" Width="88px" CssClass="btn btn-danger" OnClick="Button1_Click1"  />
 
            
  
          <br />

  
         <span class="btn btn-danger">Desde</span>
          
          
          <asp:TextBox ID="desdeFecha"  class="input-lg" TextMode="Date"  runat="server" Width="212px" Height="45px"></asp:TextBox>
          <span class="btn btn-danger">Hasta</span>
            
            <asp:TextBox ID="hastaFecha"   class="input-lg" TextMode="Date"  runat="server" Height="44px" Width="212px"></asp:TextBox>
 
        <asp:DropDownList ID="DropTipo" runat="server" class="btn btn-danger" Height="42px" Width="199px">
            <asp:ListItem>Administrador</asp:ListItem>
            <asp:ListItem>Empleado</asp:ListItem>
        </asp:DropDownList>

              <br />
            
            
  

  
          <br />    
     
             
       
     </div>

   
    <div   class="center-block" style="overflow: auto; width: 1434px; height: 315px;">

                <asp:GridView ID="UsuarioGrid" runat="server"  HorizontalAlign="Center"  CssClass="table table-striped table-hover" Width="739px" >   
                </asp:GridView>
        
   
        </div>
      <br />
        <a href="../Reportes/Ventanas/UsuarioReport.aspx" class="btn btn-danger">
          <span ></span> Imprimir
        </a> 
       
               <br />
    <br />
     

</asp:Content>
