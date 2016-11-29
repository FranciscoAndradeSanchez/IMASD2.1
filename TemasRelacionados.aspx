<%@ Page Title="" Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="TemasRelacionados.aspx.vb" Inherits="TemasRelacionados" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="EclipseWebSolutions.DatePicker" Namespace="EclipseWebSolutions.DatePicker"
    TagPrefix="ews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipalInterna" runat="Server">
    <asp:ScriptManager ID="scrmInfoGeneral" runat="server"></asp:ScriptManager>
    <asp:MultiView ID="mviewProyectos" runat="server">
        <asp:View ID="viewLista" runat="server">
            <table width="100%" align="center">
                <tr>
                    <td>
                        <asp:Panel ID="pnlBusqueda" runat="server" Visible="True" Width="100%">
                            <table width="90%" align="center" class="tablaComun">
                                <tr>
                                    <td style="width: 30%"></td>
                                    <td align="left" valign="middle" style="width: 54%">
                                        <asp:TextBox ID="txtBusqueda" runat="server" Width="250px" MaxLength="100"></asp:TextBox> <asp:RegularExpressionValidator
                                            ID="revNombreProyectoEdt" runat="server" ControlToValidate="txtBusqueda" ErrorMessage="Texto a buscar tiene caracteres no permitidos"
                                            ForeColor="" ToolTip="Texto a buscar tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:ImageButton
                                                ID="ibtnBuscarProyectos" runat="server" ImageUrl="~/images/aplicacion/btnBuscar.gif" /></td>
                                    <td style="width: 16%">
                                        <asp:LinkButton ID="lnkbMasOpciones" runat="server" OnClick="lnkbMasOpciones_Click">+ más opciones ...</asp:LinkButton></td>
                                </tr> 
                                   <tr>
                                <td align="left" colspan="3" valign="middle">
                                    <asp:Panel ID="pnlMasOpcionesBusqueda" runat="server" Visible="False" Width="100%">
                                        <table cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
                                            <tr>
                                                <td align="left" style="width: 30%">
                                                    <%--Clave CONACYT--%></td>
                                                <td align="left" style="width: 70%">
                                                    <asp:TextBox ID="txtCveTemasBuscar" runat="server" MaxLength="20" Visible="False" Enabled="False"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="revCveCONACYTBuscar" runat="server" ControlToValidate="txtCveCONACYTBuscar"
                                                        ErrorMessage="Clave CONACYT tiene caracteres no permitidos" ForeColor="" ToolTip="Clave CONACYT tiene caracteres no permitidos"
                                                        ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    <asp:UpdatePanel ID="updpTipoApoyoEstatus" runat="server">
                                                        <ContentTemplate>
                                                        
                                                            <table width="100%" border="0" cellpadding="3" cellspacing="0">
                                                                <tr>
                                                                    <td style="width: 30%">Tipo de apoyo</td>
                                                                    <td style="width: 70%">
                                                                        <asp:DropDownList ID="ddlTipoApoyoBuscar" runat="server" AutoPostBack="True" DataSourceID="odsTipoApoyoBuscar" DataTextField="DesTipoApoyo" DataValueField="CveTipoApoyo" Width="300px">
                                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsTipoApoyoBuscar" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                            SelectMethod="GetDataTipoApoyoBuscar" TypeName="dsAppTableAdapters.spTipoApoyoDDLTableAdapter">
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%">Estatus</td>
                                                                    <td style="width: 70%">
                                                                        <asp:DropDownList ID="ddlEstatusBuscar" runat="server" DataSourceID="odsEstatusBuscar" DataTextField="DesEstatus" DataValueField="CveEstatus" Width="300px">
                                                                        </asp:DropDownList>&nbsp;(elegir <i>Tipo de Apoyo</i> primero)
                                                                        
                                                                        <asp:ObjectDataSource ID="odsEstatusBuscar" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                            SelectMethod="GetDataByTipoApoyoBuscar" TypeName="dsAppTableAdapters.spEstatusDDLTableAdapter">
                                                                            <SelectParameters>
                                                                                <asp:ControlParameter ControlID="ddlTipoApoyoBuscar" Name="CveTipoApoyo" PropertyName="SelectedValue"
                                                                                    Type="String" />
                                                                            </SelectParameters>                                                                            
                                                                        </asp:ObjectDataSource>
                                                                        <%--Entra el Polo--%>
                                                                        <%--<asp:ObjectDataSource ID="odsEstatusBuscar" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spEstatusLVCTableAdapter" />--%>
                                                                        <%--Sale el Polo--%>                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 30%">
                                                    Región o Estado de seguimiento</td>
                                                <td align="left" style="width: 70%">
                                                    <asp:DropDownList ID="ddlRegionSegBuscar" runat="server" DataSourceID="odsRegionBuscar" DataTextField="DesRegion" DataValueField="CveRegion" Width="300px">
                                                    </asp:DropDownList><asp:ObjectDataSource ID="odsRegionBuscar" runat="server" OldValuesParameterFormatString="original_{0}"
                                                        SelectMethod="GetDataRegionBuscar" TypeName="dsAppTableAdapters.spRegionDDLTableAdapter">
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 30%">
                                                    Año de la convocatoria</td>
                                                <td align="left" style="width: 70%">
                                                    <asp:DropDownList ID="ddlAnioProyectoBuscar" runat="server" DataSourceID="odsAnioConvocatoriaBuscar" DataTextField="AnioDesc" DataValueField="Anio" Width="100px">
                                                    </asp:DropDownList><asp:ObjectDataSource ID="odsAnioConvocatoriaBuscar" runat="server"
                                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dsAppTableAdapters.spAnioConvocatoriaDDLBuscarTableAdapter">
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 30%">
                                                    Institución</td>
                                                <td align="left" style="width: 70%">
                                                    <asp:DropDownList ID="ddlInstitucionBuscar" runat="server" DataSourceID="odsInstitucionBuscar" DataTextField="DesInstitucion" DataValueField="CveInstitucion" Width="300px">
                                                    </asp:DropDownList><asp:ObjectDataSource ID="odsInstitucionBuscar" runat="server"
                                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataInstitucionBuscar"
                                                        TypeName="dsAppTableAdapters.spInstitucionDDLTableAdapter"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 30%">
                                                </td>
                                                <td align="left" style="width: 70%">
                                                    <asp:ImageButton
                                        ID="ibtnBuscarProyectosMas" runat="server" ImageUrl="~/images/aplicacion/btnBuscar.gif" /></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>                             
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlNavegacionUp" runat="server" Visible="true" Width="100%">
                            <table width="90%" align="center" class="tablaComun">
                                <tr>
                                    <td style="width: 25%;">
                                        <asp:ImageButton ID="ibtnNuevoUp" runat="server" CssClass="boton" ImageUrl="~/images/aplicacion/btnNuevo.gif" CommandName="New" /></td>
                                    <td style="width: 25%;"></td>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lblTotalProyectosUP" runat="server" Text="0 proyectos encontrados"></asp:Label></td>
                                    <td style="width: 25%; text-align: right;">
                                        <asp:Label ID="lblPaginaActualUP" runat="server" Text="Página 0 de 0"></asp:Label>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--<asp:ObjectDataSource ID="odsProyecto" runat="server" DeleteMethod="Delete" 
OldValuesParameterFormatString="original_{0}" 
SelectMethod="GetProyectoFiltrado" 
TypeName="dsAppTableAdapters.ProyectoTableAdapter" UpdateMethod="Update">
<DeleteParameters>
<asp:Parameter Name="Original_CveProyecto" Type="String" />
</DeleteParameters>
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
<asp:Parameter Name="CveObjeto" Type="Int32" DefaultValue="1" />
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
<SelectParameters>
<asp:ControlParameter ControlID="txtBusqueda" DefaultValue="" Name="Busqueda" 
PropertyName="Text" Type="String" />
<asp:ControlParameter ControlID="ddlTipoApoyoBuscar" Name="CveTipoApoyo" 
PropertyName="SelectedValue" Type="String" />
<asp:ControlParameter ControlID="ddlEstatusBuscar" Name="CveEstatus" 
PropertyName="SelectedValue" Type="Int32" />
<asp:ControlParameter ControlID="ddlRegionSegBuscar" Name="CveRegion" 
PropertyName="SelectedValue" Type="String" />
<asp:ControlParameter ControlID="ddlAnioProyectoBuscar" Name="AnioConvocatoria" 
PropertyName="SelectedValue" Type="Int32" />
<asp:ControlParameter ControlID="ddlInstitucionBuscar" Name="CveInstitucion" 
PropertyName="SelectedValue" Type="Int32" />
</SelectParameters>
                    
</asp:ObjectDataSource>--%>
                        <asp:ObjectDataSource ID="odsTemas" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTemasRelacionados_Detalle" TypeName="dsAppTableAdapters.Temas_RelacionadosTableAdapter" DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
                            <DeleteParameters>
                                <asp:Parameter Name="Original_id_tema" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Nombre_Proyecto" Type="String" />
                                <asp:Parameter Name="Institucion" Type="String" />
                                <asp:Parameter Name="Titulo" Type="String" />
                                <asp:Parameter Name="link" Type="String" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtBusqueda" Name="filtro" PropertyName="Text" Type="String" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Nombre_Proyecto" Type="String" />
                                <asp:Parameter Name="Institucion" Type="String" />
                                <asp:Parameter Name="Titulo" Type="String" />
                                <asp:Parameter Name="link" Type="String" />
                                <asp:Parameter Name="Original_id_tema" Type="Int32" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>


                        <asp:GridView ID="grdvProyectos" runat="server" AllowPaging="True" Width="100%"
                            DataKeyNames="id_tema" DataSourceID="odsTemas"
                            AutoGenerateColumns="False" PagerSettings-Mode="NumericFirstLast"
                            PagerSettings-Position="TopAndBottom" PagerStyle-BorderStyle="None" PagerSettings-FirstPageText="&lt;&lt; Primer Página" PagerSettings-LastPageText="Última Página &gt;&gt;" PagerSettings-PageButtonCount="20">
                            <PagerStyle CssClass="tablaAlternatigTemplate" HorizontalAlign="Center" />
                            <AlternatingRowStyle CssClass="tablaAlternatigTemplate" />
                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                            <RowStyle CssClass="tablaItemTemplate" />
                            <Columns>
                                <asp:TemplateField SortExpression="CveProyecto" ShowHeader="False" HeaderStyle-BorderWidth="0px" HeaderStyle-BorderStyle="None">
                                    <ItemTemplate>
                                        <table width="90%" align="center" border="0" cellpadding="3" cellspacing="0">
                                            <tr>
                                                <th style="width: 25%">Clave CONACYT</th>
                                                <th style="width: 75%">
                                                    <asp:LinkButton ID="lnkbCveProyecto" runat="server" CommandName="Select" Text='<%# Eval("id_tema")%>'></asp:LinkButton></th>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%">Nombre del proyecto:
                                                </td>
                                                <td style="width: 75%">
                                                    <asp:Label ID="lblNombreProyecto" runat="server" Text='<%# Eval("Nombre_Proyecto")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%">Año de la convocatoria:
                                                </td>
                                                <td style="width: 75%">
                                                    <asp:Label ID="lblinstitucion" runat="server" Text='<%# Eval("Institucion")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%">Región o Estado de seguimiento:
                                                </td>
                                                <td style="width: 75%">
                                                    <asp:Label ID="lbltitulo" runat="server" Text='<%# Eval("Titulo")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%">Institución:
                                                </td>
                                                <td style="width: 75%">
                                                    <asp:Label ID="lbllink" runat="server" Text='<%# Eval("link")%>' ></asp:Label></td>
                                            </tr>
                                            <tr class="xxxs" style="display: none;">
                                                <td style="width: 25%">
                                                    <asp:TextBox ID="txtVal" runat="server" MaxLength="1" ReadOnly="True" Width="1px"></asp:TextBox>
                                                </td>
                                                <td style="width: 75%">&nbsp;<asp:CustomValidator ID="cuvEliminar" runat="server" ControlToValidate="txtVal" ForeColor=""></asp:CustomValidator></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%">&nbsp;
                                                </td>
                                                <td style="width: 75%">
                                                    <asp:ImageButton ID="ibtnEditarIT" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandArgument='<%# Eval("id_tema")%>' CommandName="Edit" />
                                                    <asp:ImageButton ID="ibtnEliminarIT" runat="server" ImageUrl="~/images/aplicacion/btnEliminar.gif" CommandName="Delete" CommandArgument='<%# Eval("id_tema")%>' /></td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <table align="center" border="0" cellpadding="0" cellspacing="0" class="tablaComun" width="100%">
                                            <tr>
                                                <td style="border-top-style: double; border-top-color: white; height: 30px;">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div>
                                                        <asp:ImageButton ID="ibtnDatosGeneralesEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_dg_sel.gif" OnClick="ibtnDatosGeneralesEdt_Click" CssClass="pestana" />
                                                        <asp:ImageButton ID="ibtnInfraestructuraEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_in_rep.gif" OnClick="ibtnInfraestructuraEdt_Click" CssClass="pestana" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div>
                                                        <asp:ImageButton ID="ibtnDetalleMontoEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_dm_rep.gif" OnClick="ibtnDetalleMontoEdt_Click" CssClass="pestana" />
                                                        <asp:ImageButton ID="ibtnDifusionDivulgaEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_dd_rep.gif" OnClick="ibtnDifusionDivulgaEdt_Click" CssClass="pestana" />
                                                        <asp:ImageButton ID="ibtnVisitasTecnicasEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_vt_rep.gif" OnClick="ibtnVisitasTecnicasEdt_Click" CssClass="pestana" />
                                                        <asp:ImageButton ID="ibtnSeguimientoEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_sg_rep.gif" OnClick="ibtnSeguimientoEdt_Click" CssClass="pestana" />
                                                        <asp:ImageButton ID="ibtnAdministrativoEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_ad_rep.gif" OnClick="ibtnAdministrativoEdt_Click" CssClass="pestana" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div>
                                                        <asp:ImageButton ID="ibtnEtapasEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_et_rep.gif" OnClick="ibtnEtapasEdt_Click" CssClass="pestana" />
                                                        <%-- ELIMINADO ***<asp:ImageButton ID="ibtnProblematicasEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_pr_rep.gif" OnClick="ibtnProblematicasEdt_Click" CssClass="pestana"/>--%>
                                                        <asp:ImageButton ID="ibtnParticipantesEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_pa_rep.gif" OnClick="ibtnParticipantesEdt_Click" CssClass="pestana" />
                                                        <asp:ImageButton ID="ibtnEspeciesEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_es_rep.gif" OnClick="ibtnEspeciesEdt_Click" CssClass="pestana" />
                                                        <asp:ImageButton ID="ibtnEstadosEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_st_rep.gif" OnClick="ibtnEstadosEdt_Click" CssClass="pestana" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:MultiView ID="mviewProyectosEdt" runat="server" ActiveViewIndex="0">
                                                        <asp:View ID="viewDatosGeneralesEdt" runat="server">
                                                            <table align="center" border="0" cellpadding="3" cellspacing="0" width="90%">
                                                                <tr>
                                                                    <td colspan="2">&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="thtablaComun" colspan="2">Datos Generales del proyecto</th>                       
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%; height: 15px">&nbsp;
                                                                    </td>
                                                                    <td style="width: 70%; height: 15px">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%">Clave Tema Relacionado</td>
                                                                    <td style="width: 70%">
                                                                        <asp:Label ID="lblCvetema" runat="server" Text='<%# Eval("id_tema")%>'></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%">Nombre del proyecto</td>
                                                                    <td style="width: 70%">
                                                                        <asp:TextBox ID="txtNombreEdt" runat="server" MaxLength="300" Rows="4" Text='<%# Bind("Nombre_Proyecto")%>'
                                                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvNombreProyectoEdt"
                                                                                runat="server" ControlToValidate="txtNombreEdt" ErrorMessage="Nombre del proyecto es un valor requerido"
                                                                                ForeColor="" ToolTip="Nombre del proyecto es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                                                    ID="revNombreProyectoEdt" runat="server" ControlToValidate="txtNombreEdt" ErrorMessage="Nombre del proyecto tiene caracteres no permitidos"
                                                                                    ForeColor="" ToolTip="Nombre del proyecto tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:CustomValidator
                                                                                        ID="cuvExcepcionesEdt" runat="server" ErrorMessage="Error al intentar guardar los datos"
                                                                                        ForeColor="" ToolTip="Error al intentar guardar los datos" ControlToValidate="txtNombreEdt">x</asp:CustomValidator></td>
                                                            </tr>
                                                             <tr>
                                                                    <td style="width: 30%">Institución</td>
                                                                    <td style="width: 70%">
                                                                        <asp:DropDownList ID="ddlInstitucionEdt" runat="server" DataSourceID="odsInstitucionDDLEdt"
                                                                            DataTextField="DesInstitucion" DataValueField="CveInstitucion" SelectedValue='<%# Bind("Institucion")%>' Width="400px">
                                                                        </asp:DropDownList><asp:RangeValidator ID="ravInstitucionEdt" runat="server" ControlToValidate="ddlInstitucionEdt"
                                                                            ErrorMessage="Indique la institución" ForeColor="" MaximumValue="1000" MinimumValue="1"
                                                                            ToolTip="Indique la institución" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
                                                                                ID="odsInstitucionDDLEdt" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                                SelectMethod="GetData" TypeName="dsAppTableAdapters.spInstitucionDDLTableAdapter"></asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%">Resumen</td>
                                                                    <td style="width: 70%">
                                                                        <asp:TextBox ID="txtTituloTema" runat="server" MaxLength="1073741823" Rows="4" Text='<%# Bind("Titulo")%>'
                                                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvResumenEdt"
                                                                                runat="server" ControlToValidate="txtTituloTema" ErrorMessage="El titulo del proyecto es un valor requerido"
                                                                                ForeColor="" ToolTip="El titulo del proyecto es un valor requerido">x</asp:RequiredFieldValidator>
                                           <asp:RegularExpressionValidator ID="revResumenEdt" runat="server" ControlToValidate="txtResumenEdt" ErrorMessage="Titulo del proyecto tiene caracteres no permitidos"
                                                                                    ForeColor="" ToolTip="Titulo del proyecto tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%">Objetivo general</td>
                                                                    <td style="width: 70%">
                                                                        <asp:TextBox ID="txtObjetivoGralEdt" runat="server" MaxLength="1000" Rows="4" Text='<%# Bind("link")%>'
                                                                            TextMode="MultiLine" Width="400px"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td colspan="2"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="1"></td>
                                                                    <td>
                                                                        <asp:ValidationSummary ID="vsValidacionEdt" runat="server" DisplayMode="List" ForeColor=""
                                                                            HeaderText="Se encontraron los siguientes errores:" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="1"></td>
                                                                    <td>
                                                                        <asp:ImageButton ID="ibtnActualizarEdt" runat="server" CommandName="Update" ImageUrl="~/images/aplicacion/btnGuardar.gif" />
                                                                        <asp:ImageButton ID="ibtnCancelarEdt" runat="server" CommandName="Cancel" ImageUrl="~/images/aplicacion/btnCancelar.gif" CausesValidation="False" /></td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                    </asp:MultiView></td>
                                            </tr>
                                            <tr>
                                                <td style="border-top-style: double; border-top-color: white; height: 30px; width: 720px;">&nbsp;
            		                    
                                                </td>
                                            </tr>
                                        </table>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Panel ID="pnlNavegacionDw" runat="server" Visible="true" Width="100%">
                            <table width="90%" align="center" class="tablaComun">
                                <tr>
                                    <td style="width: 25%">
                                        <asp:ImageButton ID="ibtnNuevoDw" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" />

                                    </td>
                                    <td style="width: 25%; text-align: left"></td>
                                    <td style="width: 25%; text-align: right"></td>
                                    <td style="width: 25%" align="right">
                                        <asp:Label ID="lblPaginaActualDW" runat="server" Text="Página 0 de 0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="4">
                                        <asp:Label ID="lblTotalProyectosDW" runat="server" Text="0 proyectos encontrados"></asp:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>

            </table>
        </asp:View>


        <asp:View ID="viewDetalle" runat="server">
            <asp:HiddenField ID="hdCveProyecto_Detalle" runat="server" Value="" />
            <asp:ObjectDataSource ID="odsTemasRelacionados" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTemasRelacionados_Detalle" TypeName="dsAppTableAdapters.Temas_RelacionadosTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_id_tema" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Nombre_Proyecto" Type="String" />
                    <asp:Parameter Name="Institucion" Type="String" />
                    <asp:Parameter Name="Titulo" Type="String" />
                    <asp:Parameter Name="link" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtBusqueda" Name="filtro" PropertyName="Text" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Nombre_Proyecto" Type="String" />
                    <asp:Parameter Name="Institucion" Type="String" />
                    <asp:Parameter Name="Titulo" Type="String" />
                    <asp:Parameter Name="link" Type="String" />
                    <asp:Parameter Name="Original_id_tema" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>


            <asp:FormView ID="frmvProyecto_Detalle" runat="server"
                DataSourceID="odsTemasRelacionados">
                <ItemTemplate>
                    <table cellpadding="3" cellspacing="0" class="tablaComun" width="90%" align="center" border="0">
                        <tr>
                            <td colspan="2" class="thtablaComun">Datos Generales</td>
                        </tr>
                        <tr>
                            <td style="width: 30%">Clave CONACYT&nbsp;</td>
                            <td style="width: 70%">
                                <asp:Label ID="lblCveProyectoST" runat="server" Text='<%# Eval("id_tema")%>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 30%">Nombre del proyecto</td>
                            <td style="width: 70%">
                                <asp:Label ID="lblNombreProyectoST" runat="server" Text='<%# Bind("Nombre_Proyecto")%>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Responsable Técnico</td>
                            <td>
                                <asp:Label ID="lbResponsableTecnicoST" runat="server" Text='<%# Bind("Institucion")%>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 30%">Año de la convocatoria
                            </td>
                            <td style="width: 70%">
                                <asp:Label ID="lblAnioConvocatoriaST" runat="server" Text='<%# Bind("Titulo")%>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 30%">Institución</td>
                            <td style="width: 70%">
                                <asp:Label ID="lblInstitucionST" runat="server" Text='<%# Bind("link")%>'></asp:Label></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:FormView>
            <br />
            <div style="text-align: center">
                <asp:ImageButton ID="ibtnRegresar_Detalle" runat="server" ImageUrl="~/images/aplicacion/btnRegresar.gif" />
            </div>
        </asp:View>

        <asp:View ID="viewAgregar" runat="server">
            <table border="0" cellpadding="0" cellspacing="0" class="tablaComun" width="100%">
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <table align="center" border="0" cellpadding="3" cellspacing="0" width="90%">
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <th class="thtablaComun" colspan="2">Datos Generales de los Temas Relacionados</th>
                            </tr>
                            <tr>
                                <td style="width: 30%; height: 15px">&nbsp;
                                </td>
                                <td style="width: 70%; height: 15px">
                                    <asp:Label ID="lblEstatusAdd" runat="server" Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">Nombre del Proyecto</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtNombreAdd" runat="server" MaxLength="300" Rows="4" TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvNombreTemaAdd"
                                        runat="server" ControlToValidate="txtNombreAdd" ErrorMessage="Nombre del tema relacionado es un valor requerido"
                                        ForeColor="" ToolTip="Nombre del tema relacionado es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ID="revNombreTemaAdd" runat="server" ControlToValidate="txtNombreAdd" ErrorMessage="Nombre del tema relacionado tiene caracteres no permitidos"
                                            ForeColor="" ToolTip="Nombre del tema relacionado tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator>
                                    <asp:CustomValidator ID="cuvExcepcionesAdd" runat="server" ErrorMessage="Error al intentar guardar los datos"
                                                ForeColor="" ToolTip="Error al intentar guardar los datos" ControlToValidate="txtNombreAdd">x</asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">Institución</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlInstitucionAdd" runat="server" DataSourceID="odsInstitucionDDLAdd"
                                        DataTextField="DesInstitucion" DataValueField="CveInstitucion" Width="400px">
                                    </asp:DropDownList><asp:RangeValidator ID="ravInstitucionAdd" runat="server" ControlToValidate="ddlInstitucionAdd"
                                        ErrorMessage="Indique la institución" ForeColor="" MaximumValue="1000" MinimumValue="1"
                                        ToolTip="Indique la institución" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
                                            ID="odsInstitucionDDLAdd" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spInstitucionDDLTableAdapter"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">Titulo del Proyecto</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtTituloAdd" runat="server" MaxLength="300" Rows="4" TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvTituloTemaAdd"
                                        runat="server" ControlToValidate="txtTituloAdd" ErrorMessage="Titulo del tema relacionado es un valor requerido"
                                        ForeColor="" ToolTip="Nombre del tema relacionado es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ID="revTituloTemaAdd" runat="server" ControlToValidate="txtTituloAdd" ErrorMessage="Titulo del tema relacionado tiene caracteres no permitidos"
                                            ForeColor="" ToolTip="Titulo del tema relacionado tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">Link del Proyecto</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtlinkAdd" runat="server" MaxLength="300" Rows="4" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1">
                                </td>
                                <td>
                                    <asp:ValidationSummary ID="vsValidacionAdd" runat="server" DisplayMode="List" ForeColor=""
                                        HeaderText="Se encontraron los siguientes errores:" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1">
                                </td>
                                <td>
                                    <asp:ImageButton ID="ibtnActualizarAdd" runat="server" CommandName="Update" ImageUrl="~/images/aplicacion/btnGuardar.gif" />
                                    <asp:ImageButton ID="ibtnCancelarAdd" runat="server" ImageUrl="~/images/aplicacion/btnCancelar.gif" CausesValidation="False" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>

