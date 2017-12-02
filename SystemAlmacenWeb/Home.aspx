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


                <!-- Modal -->
                <div class="modal fullscreen-modal fade" id="ModalInformacion" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title" id="myModalLabel">Contactos</h4>
                            </div>
                            <div class="modal-body">
                                <div class="modal-body">
                                <p>Nos puede contactar via telefonica  llamando al  :829-761-1697</p>
                                <p>Tambien escribiendo al correo anthony26uu@gmail.com</p>
                            </div>
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
