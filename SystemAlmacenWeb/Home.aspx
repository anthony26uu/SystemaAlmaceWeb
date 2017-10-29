<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SystemAlmacenWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Librerias para Toastr -->


     
    <script src="Scripts/popper.min.js"></script>
    <div class="jumbotron">

        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title"></h3>
            </div>
            <div class="panel-body">
                <h2>Bienvenido  </h2>
                <h4>**Usuario** </h4>
            </div>
        </div>



        <p>
            <asp:Image ID="Image1" runat="server" Height="363px" ImageUrl="~/Content/Img/warehouse.jpg" Width="874px" />
        </p>



        <div id="ModalInformacion" class="modal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Contactos</h4>
                    </div>
                    <div class="modal-body">
                        <p>Nos puede contactar via telefonica  llamando al  :829-761-1697</p>
                        <p>Tambien escribiendo al correo anthony26uu@gmail.com</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>

                    </div>
                </div>
            </div>
        </div>



        <p><a href="#ModalInformacion" data-toggle="modal" class="btn btn-primary btn-lg">Informacion</a></p>
    </div>

    
</asp:Content>
