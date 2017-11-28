<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="CArticulos.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Consultas.CArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!--Inclusión de Extras Para evitar Errores-->
     <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>   
    <script src="/Scripts/bootstrap.min.js"></script> 
    
    
       <header>
            <h1 class="page-header text-center">

                  CONSULTA ARTICULO <span ></span></h1>
        </header>

       

 <div class= "text-center">
     
            <asp:Label For="CodigoTextBox" ID="Label1" class="col-md-3 control-label input-sm" runat="server" Text="Selecionar"></asp:Label>
                    <div class="col-lg-2 col-md-2">
          <asp:DropDownList ID="DropFiltro"   CssClass="form-control" runat="server" Height="45px"> 
            
              <asp:ListItem>Todo</asp:ListItem>
              <asp:ListItem>ID</asp:ListItem>
              <asp:ListItem>Fecha</asp:ListItem>
              <asp:ListItem>Nombre</asp:ListItem>
              <asp:ListItem>Categoria</asp:ListItem>
          </asp:DropDownList>
      </div>
               

       
        
                <span   class="col-md-3 control-label " >ID / Descripcion</span>
   <div class="col-lg-4 col-md-4">           
     
          <asp:TextBox ID="buscaText" runat="server"     placeholder="ID a buscar" Height="45px" Width="106px" ></asp:TextBox>
    
         <asp:Button ID="Button1" runat="server" Text="Buscar" Height="45px" Width="68px"   class ="btn btn-warning btn-sm" OnClick="Button1_Click1"  />
 
         </div>
        
            
  
          <br />
   <div class="col-lg-4 col-md-6">
 
          <asp:Label For="CodigoTextBox" ID="Label2" class="col-md-3 control-label input-sm" runat="server" Text="Desde"></asp:Label>
         
          <asp:TextBox ID="desdeFecha"   TextMode="Date"  runat="server" Width="212px" Height="45px"></asp:TextBox>
        </div>

     
          <div class="col-lg-4 col-md-8">
      
             <asp:Label For="CodigoTextBox" ID="Label3" class="col-md-3 control-label input-sm" runat="server" Text="Hasta"></asp:Label>
         
          <asp:TextBox ID="hastaFecha" TextMode="Date"  runat="server" Height="44px" Width="212px"></asp:TextBox>
         </div>

      <div class="col-lg-4 col-md-9">
      <asp:Label For="CodigoTextBox" ID="Label4" class="col-md-5 control-label " runat="server" Text="Categoria "></asp:Label>
         
        <asp:DropDownList ID="DropCategoria"  CssClass="form-control" runat="server"  Height="42px" Width="199px">
        </asp:DropDownList>
        </div>
        
                      
            
  
     
          <br /> 
  
          <br />    
     
               <br />    
       
     
          <div   class="container-fluid" style="overflow: auto; width: 1434px; height: 213px;">
     
                  <div class="col-lg-12">
           
                <asp:GridView ID="ArticuloGrid" runat="server"   CssClass=" table table-striped table-hover table-bordered"  CellPadding="0" ClientIDMode="Static"  HorizontalAlign="Center" Height="172px" Width="942px" >   
              <AlternatingRowStyle BackColor="gray  " />
                     <FooterStyle BackColor="#CCCC99" />
                      <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                      
                        
                    </asp:GridView>
                   </div>
       
           
 </div>
   
   
    
      <br />
        <a href="../Reportes/Ventanas/ArticuloReport.aspx" class="btn btn-danger">
          <span ></span> Imprimir
        </a> 
       
               <br />
    <br />
     

</asp:Content>
