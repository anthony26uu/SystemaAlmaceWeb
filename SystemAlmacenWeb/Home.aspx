<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SystemAlmacenWeb.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


         <!-- Librerias para Toastr -->

    <script src="../../Scripts/jquery-3.2.1.js"></script>

             <!-- Librerias para Toastr -->
    <link href="/../Content/toastr.css" rel="stylesheet" />
    <script src="../../Scripts/toastr.js"></script>
    <script src="../../Scripts/jquery-3.2.1.js"></script>

     <div class="container-fluid">

      

  <label class="control-label">Input addons</label>
  <div class="input-group">
    <span class="input-group-addon">!!</span>
    <input type="text" readonly="true" placeholder="Desarrollado con fines academicos, por Anthony Santana Polanco-2014-0527" class="form-control">
    <span class="input-group-btn">
      <button class="btn btn-default" type="button">Button</button>
    </span>
  </div>

         <br />

<div class="jumbotron">
  <h1 class="display-3">Bienvenidos</h1>
   <p><a href="#ModalInformacion" data-toggle="modal" class="btn btn-primary btn-lg">Informacion</a></p>
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
        <script src="/Scripts/popper.min.js"></script>
        <script src="/Scripts/popper.js"></script>

 


    
       
</asp:Content>
