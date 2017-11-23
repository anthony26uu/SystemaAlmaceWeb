using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Reportes.Ventanas
{
    public partial class Clientereport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.ReportViewerCliente.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            this.ReportViewerCliente.Reset();


            this.ReportViewerCliente.LocalReport.ReportPath = @"C:\Users\antho\Desktop\Aplicada II\Tareas\SystemAlmacenWeb\SystemAlmacenWeb\Ui\Reportes\ClienteReport.rdlc";
            this.ReportViewerCliente.LocalReport.DataSources.Clear();



            this.ReportViewerCliente.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCliente", Ui.Consultas.CClientes.Lista));

            this.ReportViewerCliente.LocalReport.Refresh();


        }
    }
}