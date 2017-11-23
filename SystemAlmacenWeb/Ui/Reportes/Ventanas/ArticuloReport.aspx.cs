using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Reportes.Ventanas
{
    public partial class ArticuloReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            this.ReportViewer1.Reset();


            this.ReportViewer1.LocalReport.ReportPath = @"C:\Users\antho\Desktop\Aplicada II\Tareas\SystemAlmacenWeb\SystemAlmacenWeb\Ui\Reportes\ArticulosReport.rdlc";
            this.ReportViewer1.LocalReport.DataSources.Clear();



            this.ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetArticulo", Ui.Consultas.CArticulos.Lista));

            this.ReportViewer1.LocalReport.Refresh();


        }
    }
}