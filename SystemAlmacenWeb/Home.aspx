<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SystemAlmacenWeb.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!--Inclusión de Extras Para evitar Errores-->
    <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>

    <div class="container-fluid">





        <br />
        <div class="col-sm-6">
            <div class="panel panel-success">
                <div class="panel-heading">Bienvenido</div>
                <div class="jumbotron">
                    <div class="panel-body">
                        <div class="panel panel-info">
                           
                            <asp:Label ID="UsuarioLabel" runat="server" Text='<%# Eval("Usuario") %>'></asp:Label>&nbsp&nbsp

                        </div>

                    </div>
                    <p><a href="#ModalInformacion" data-toggle="modal" class="btn btn-primary btn-lg">Informacion</a></p>
                </div>
            </div>

            <div class="col-sm-6">
            </div>



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
        </div>
    </div>
    <script src="/Scripts/popper.min.js"></script>
    <script src="/Scripts/popper.js"></script>






</asp:Content>
