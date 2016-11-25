<%@ Page Title="" Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="v_acumproy.aspx.vb" Inherits="viewersReports_v_acumproy" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sqlcnxProiectus %>" SelectCommand="SELECT * FROM [VwMontoProyectoAnio]"></asp:SqlDataSource>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="600px" Width="100%">
        <LocalReport ReportPath="Reportes\repAcumProy.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataMonto" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
   
</asp:Content>

