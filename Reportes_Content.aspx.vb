Imports Microsoft.Reporting.WebForms

Partial Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub SqlDataSource1_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting

    End Sub

    Private Sub Page_Init()
        If IsPostBack() = True Then

            ReportViewer1.LocalReport.ReportPath = "~/Reportes/Reporte Pruebas.rdlc"
            ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("Where nombre = 'pruebas'", SqlDataSource1()))

            ReportViewer1.LocalReport.Refresh()
        Else

        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        ReportViewer1.LocalReport.ReportPath = "~/Reportes/Reporte Pruebas.rdlc"
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("", SqlDataSource1()))

        ReportViewer1.LocalReport.Refresh()
    End Sub
End Class
