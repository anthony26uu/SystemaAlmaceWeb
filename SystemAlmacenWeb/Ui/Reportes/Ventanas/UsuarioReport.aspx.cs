using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Reportes.Ventanas
{
    public partial class UsuarioReport : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            this.ReportViewerUsuario.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            this.ReportViewerUsuario.Reset();


            this.ReportViewerUsuario.LocalReport.ReportPath = @"C:\Users\antho\Desktop\Aplicada II\Tareas\SystemAlmacenWeb\SystemAlmacenWeb\Ui\Reportes\UsuariosReport.rdlc";
            this.ReportViewerUsuario.LocalReport.DataSources.Clear();



            this.ReportViewerUsuario.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetUsuario", Ui.Consultas.CUsuarios.Lista));

            this.ReportViewerUsuario.LocalReport.Refresh();

            


        }
        

    }
}