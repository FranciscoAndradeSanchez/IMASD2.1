<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="Reportes_Content.aspx.vb" Inherits="Inicio" title="Sistema de Control y Seguimiento de " %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphCabecera" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">
      <br />

      <asp:ScriptManager ID="ScriptManager1" runat="server">
      </asp:ScriptManager>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
      <br />
    <div class="row-centralcontent">
     
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sqlcnxProiectus %>" SelectCommand="SELECT * FROM [CatUsuario] ORDER BY [APaterno] DESC, [Amaterno] DESC, [Nombre] DESC"></asp:SqlDataSource>
          <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProyecto" TypeName="dsAppTableAdapters.ProyectoTableAdapter" UpdateMethod="Update">
              <DeleteParameters>
                  <asp:Parameter Name="Original_CveProyecto" Type="String" />
              </DeleteParameters>
              <InsertParameters>
                  <asp:Parameter Name="CveProyecto" Type="String" />
                  <asp:Parameter Name="CveTipoApoyo" Type="String" />
                  <asp:Parameter Name="FechaUltAct" Type="DateTime" />
                  <asp:Parameter Name="FechaCaptura" Type="DateTime" />
                  <asp:Parameter Name="NombreProyecto" Type="String" />
                  <asp:Parameter Name="AnioConvocatoria" Type="Int32" />
                  <asp:Parameter Name="CveInstitucion" Type="Int32" />
                  <asp:Parameter Name="CveTipoProy" Type="Int32" />
                  <asp:Parameter Name="Resumen" Type="String" />
                  <asp:Parameter Name="CveRegion" Type="String" />
                  <asp:Parameter Name="CveEscala" Type="Int32" />
                  <asp:Parameter Name="CveVegetacion" Type="Int32" />
                  <asp:Parameter Name="Metodologia" Type="String" />
                  <asp:Parameter Name="CveEstatus" Type="Int32" />
                  <asp:Parameter Name="CveObjeto" Type="Int32" />
                  <asp:Parameter Name="Demanda" Type="String" />
                  <asp:Parameter Name="FechaConvAcue" Type="DateTime" />
                  <asp:Parameter Name="CveEcosistema" Type="Int32" />
                  <asp:Parameter Name="ResultadosEsp" Type="String" />
                  <asp:Parameter Name="Demandante" Type="String" />
                  <asp:Parameter Name="IdentProblema" Type="String" />
                  <asp:Parameter Name="CveAreaTematica" Type="Int32" />
                  <asp:Parameter Name="CoberturaOperativa" Type="String" />
                  <asp:Parameter Name="ImpactosEsperados" Type="String" />
                  <asp:Parameter Name="CveSectorUsuario" Type="Int32" />
                  <asp:Parameter Name="Materiales" Type="String" />
                  <asp:Parameter Name="Usuario" Type="String" />
                  <asp:Parameter Name="RequisitosTT" Type="String" />
                  <asp:Parameter Name="ActividadesTT" Type="String" />
                  <asp:Parameter Name="ObjetivoGeneral" Type="String" />
                  <asp:Parameter Name="ObjetivosEspecificos" Type="String" />
                  <asp:Parameter Name="CveResponsableTecnico" Type="Int32" />
                  <asp:Parameter Name="CostoTotalProyecto" Type="Decimal" />
                  <asp:Parameter Name="AportacionApoyoInstitucional" Type="Decimal" />
                  <asp:Parameter Name="AportacionInstitucionEjecutora" Type="Decimal" />
                  <asp:Parameter Name="AportacionesOtras" Type="Decimal" />
              </InsertParameters>
              <UpdateParameters>
                  <asp:Parameter Name="CveTipoApoyo" Type="String" />
                  <asp:Parameter Name="FechaUltAct" Type="DateTime" />
                  <asp:Parameter Name="FechaCaptura" Type="DateTime" />
                  <asp:Parameter Name="NombreProyecto" Type="String" />
                  <asp:Parameter Name="AnioConvocatoria" Type="Int32" />
                  <asp:Parameter Name="CveInstitucion" Type="Int32" />
                  <asp:Parameter Name="CveTipoProy" Type="Int32" />
                  <asp:Parameter Name="Resumen" Type="String" />
                  <asp:Parameter Name="CveRegion" Type="String" />
                  <asp:Parameter Name="CveEscala" Type="Int32" />
                  <asp:Parameter Name="CveVegetacion" Type="Int32" />
                  <asp:Parameter Name="Metodologia" Type="String" />
                  <asp:Parameter Name="CveEstatus" Type="Int32" />
                  <asp:Parameter Name="CveObjeto" Type="Int32" />
                  <asp:Parameter Name="Demanda" Type="String" />
                  <asp:Parameter Name="FechaConvAcue" Type="DateTime" />
                  <asp:Parameter Name="CveEcosistema" Type="Int32" />
                  <asp:Parameter Name="ResultadosEsp" Type="String" />
                  <asp:Parameter Name="Demandante" Type="String" />
                  <asp:Parameter Name="IdentProblema" Type="String" />
                  <asp:Parameter Name="CveAreaTematica" Type="Int32" />
                  <asp:Parameter Name="CoberturaOperativa" Type="String" />
                  <asp:Parameter Name="ImpactosEsperados" Type="String" />
                  <asp:Parameter Name="CveSectorUsuario" Type="Int32" />
                  <asp:Parameter Name="Materiales" Type="String" />
                  <asp:Parameter Name="Usuario" Type="String" />
                  <asp:Parameter Name="RequisitosTT" Type="String" />
                  <asp:Parameter Name="ActividadesTT" Type="String" />
                  <asp:Parameter Name="ObjetivoGeneral" Type="String" />
                  <asp:Parameter Name="ObjetivosEspecificos" Type="String" />
                  <asp:Parameter Name="CveResponsableTecnico" Type="Int32" />
                  <asp:Parameter Name="CostoTotalProyecto" Type="Decimal" />
                  <asp:Parameter Name="AportacionApoyoInstitucional" Type="Decimal" />
                  <asp:Parameter Name="AportacionInstitucionEjecutora" Type="Decimal" />
                  <asp:Parameter Name="AportacionesOtras" Type="Decimal" />
                  <asp:Parameter Name="Original_CveProyecto" Type="String" />
              </UpdateParameters>
          </asp:ObjectDataSource>
     
          <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="938px">
              <LocalReport ReportPath="Reportes\Reporte Prueba.rdlc">
                  <DataSources>
                      <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataUsuarios" />
                  </DataSources>
              </LocalReport>
          </rsweb:ReportViewer>
    </div>
</asp:Content>


