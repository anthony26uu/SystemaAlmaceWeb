

<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="UsuarioReport.aspx.cs" Inherits="SystemAlmacenWeb.Ui.Reportes.Ventanas.UsuarioReport" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta lang="es-ES"/>
    <title>Reporte de usuarios</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
</head>
<body style="height: 751px">
    <form id="formulario" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewerUsuario" runat="server" Height="715px" Width="967px" style="margin-right: 57px" AsyncRendering="False" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
            <ServerReport ReportPath="" ReportServerUrl="" />
            <localreport reportpath="Ui\Reportes\PresupuestoReport.rdlc">
            </localreport>
        </rsweb:ReportViewer>

    </form>
</body>
</html>
