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
                                        <asp:TextBox ID="txtBusqueda" runat="server" Width="250px" MaxLength="100"></asp:TextBox>
                                        <asp:RegularExpressionValidator
                                            ID="revNombreProyectoEdt" runat="server" ControlToValidate="txtBusqueda" ErrorMessage="Texto a buscar tiene caracteres no permitidos"
                                            ForeColor="" ToolTip="Texto a buscar tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:ImageButton
                                                ID="ibtnBuscarProyectos" runat="server" ImageUrl="~/images/aplicacion/btnBuscar.gif" /></td>
                                    <td style="width: 16%">
                                </tr>
                                <tr>
                                    <td align="left" colspan="3" valign="middle">
                                        <asp:Panel ID="pnlMasOpcionesBusqueda" runat="server" Visible="False" Width="100%">
                                            <table cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
                                                <tr>
                                                    <td align="left" style="width: 30%">
                                                        <%--Clave CONACYT--%>
                                                        Buscar:
                                                    </td>
                                                    <td align="left" style="width: 70%">
                                                        <div>
                                                            <asp:TextBox ID="txtCveTemasBuscar" runat="server" MaxLength="20" Visible="False" Enabled="False"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revCveCONACYTBuscar" runat="server" ControlToValidate="txtCveCONACYTBuscar"
                                                            ErrorMessage="Clave CONACYT tiene caracteres no permitidos" ForeColor="" ToolTip="Clave CONACYT tiene caracteres no permitidos"
                                                            ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator>
                                                        </div>
                                                       </td>
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
                                                                                SelectMethod="GetDataTipoApoyoBuscar" TypeName="dsAppTableAdapters.spTipoApoyoDDLTableAdapter"></asp:ObjectDataSource>
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
                                                    <td align="left" style="width: 30%">Región o Estado de seguimiento</td>
                                                    <td align="left" style="width: 70%">
                                                        <asp:DropDownList ID="ddlRegionSegBuscar" runat="server" DataSourceID="odsRegionBuscar" DataTextField="DesRegion" DataValueField="CveRegion" Width="300px">
                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsRegionBuscar" runat="server" OldValuesParameterFormatString="original_{0}"
                                                            SelectMethod="GetDataRegionBuscar" TypeName="dsAppTableAdapters.spRegionDDLTableAdapter"></asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 30%">Año de la convocatoria</td>
                                                    <td align="left" style="width: 70%">
                                                        <asp:DropDownList ID="ddlAnioProyectoBuscar" runat="server" DataSourceID="odsAnioConvocatoriaBuscar" DataTextField="AnioDesc" DataValueField="Anio" Width="100px">
                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsAnioConvocatoriaBuscar" runat="server"
                                                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dsAppTableAdapters.spAnioConvocatoriaDDLBuscarTableAdapter"></asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 30%">Institución</td>
                                                    <td align="left" style="width: 70%">
                                                        <asp:DropDownList ID="ddlInstitucionBuscar" runat="server" DataSourceID="odsInstitucionBuscar" DataTextField="DesInstitucion" DataValueField="CveInstitucion" Width="300px">
                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsInstitucionBuscar" runat="server"
                                                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataInstitucionBuscar"
                                                            TypeName="dsAppTableAdapters.spInstitucionDDLTableAdapter"></asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 30%"></td>
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
                                <asp:ControlParameter ControlID="txtBusqueda" Name="filtro" PropertyName="Text" Type="String" DefaultValue=" " />
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
                                <asp:TemplateField SortExpression="id_tema" ShowHeader="False" HeaderStyle-BorderWidth="0px" HeaderStyle-BorderStyle="None">
                                    <ItemTemplate>
                                        <table cellpadding="3" cellspacing="0" class="tablaComun" width="90%" align="right" border="0">
                                            <tr>
                                                <td colspan="2" class="thtablaComun">Datos Generales</td>
                                            </tr>
                                            <tr>
                                                <td style="width:20%">
                                                    id_tema:
                                                </td>
                                                <td style="width:80%" align="left">
                                                    <asp:Label ID="id_temaLabelgvp" runat="server" Text='<%# Eval("id_tema")%>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Nombre_Proyectos:                     
                                                </td>
                                                <td>
                                                    <asp:Label ID="Nombre_ProyectoLabelgvp" runat="server" Text='<%# Bind("Nombre_Proyecto") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Institucion:                    
                                                </td>
                                                <td>
                                                    <asp:Label ID="InstitucionLabelgvp" runat="server" Text='<%# Bind("DesInstitucion") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Titulo:                   
                                                </td>
                                                <td>
                                                    <asp:Label ID="TituloLabelgvp" runat="server" Text='<%# Bind("Titulo") %>' />
                                                </td>
                                            </tr>
                                           <%-- <tr>
                                                <td>link:                   
                                                </td>
                                                <td>
                                                    <asp:Label ID="linkLabelgvp" runat="server" Visible="false" Text='<%# Bind("link") %>' />
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtValgvp" runat="server" MaxLength="1" ReadOnly="True" Width="1px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandArgument='<%# Eval("id_tema")%>' CommandName="Edit" />
                                                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/images/aplicacion/btnEliminar.gif" CommandName="Delete" CommandArgument='<%# Eval("id_tema") %>' />
                                                </td>
                                            </tr>

                                        </table>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <table cellpadding="3" cellspacing="0" class="tablaComun" width="90%" align="center" border="0">
                                            <tr>
                                                <td colspan="2" class="thtablaComun">Datos Generales</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%">Identificador del tema:</td>
                                                <td style="width: 70%">
                                                    <asp:Label ID="id_temaLabel1" runat="server" Text='<%# Eval("id_tema") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%">Nombre_Proyecto:
                                                </td>
                                                <td style="width: 70%">
                                                    <asp:TextBox ID="Nombre_ProyectoEdit" runat="server" Text='<%# Bind("Nombre_Proyecto") %>' />
                                                    <asp:CustomValidator
                                                        ID="cuvExcepcionesEdt" runat="server" ErrorMessage="Error al intentar guardar los datos"
                                                        ForeColor="" ToolTip="Error al intentar guardar los datos" ControlToValidate="Nombre_ProyectoEdit">x</asp:CustomValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Institucion:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlInstitucionEdt" runat="server" DataSourceID="odsInstitucionDDLEdt"
                                                                DataTextField="DesInstitucion" DataValueField="CveInstitucion" SelectedValue='<%# Bind("Institucion") %>' Width="400px">
                                                            </asp:DropDownList> 
                                                    <asp:RangeValidator ID="ravInstitucionEdt" runat="server" ControlToValidate="ddlInstitucionEdt"
                                                                ErrorMessage="Indique la institución" ForeColor="" MaximumValue="1000" MinimumValue="1"
                                                                ToolTip="Indique la institución" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
                                                                    ID="odsInstitucionDDLEdt" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                    SelectMethod="GetData" TypeName="dsAppTableAdapters.spInstitucionDDLTableAdapter">
                                                                </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Titulo:
                                                </td>
                                                <td>

                                                    <asp:TextBox ID="TituloEdit" runat="server" Text='<%# Bind("Titulo") %>' />
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td>link:                       
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="linkEdit" runat="server" Visible="false" Text='<%# Bind("link") %>' />
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" />
                                                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                                                </td>
                                            </tr>
                                        </table>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="id_tema" HeaderText="id_tema" InsertVisible="False" ReadOnly="True" SortExpression="id_tema" />
                                <asp:BoundField DataField="Nombre_Proyecto" HeaderText="Nombre_Proyecto" SortExpression="Nombre_Proyecto" />
                                <asp:BoundField DataField="Institucion" HeaderText="Institucion" SortExpression="Institucion" />
                                <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
                                <asp:BoundField DataField="link" HeaderText="link" SortExpression="link" />--%>
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
                    <asp:ControlParameter ControlID="txtBusqueda" Name="filtro" PropertyName="Text" Type="String" DefaultValue=" " />
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
                DataSourceID="odsTemasRelacionados" DataKeyNames="id_tema">
                <EditItemTemplate>
                    <table cellpadding="3" cellspacing="0" class="tablaComun" width="90%" align="center" border="0">
                        <tr>
                            <td colspan="2" class="thtablaComun">Datos Generales</td>
                        </tr>
                        <tr>
                            <td style="width: 30%">Identificador del tema:</td>
                            <td style="width: 70%">
                                <asp:Label ID="id_temaLabel1" runat="server" Text='<%# Eval("id_tema") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">Nombre_Proyecto:
                            </td>
                            <td style="width: 70%">
                                <asp:TextBox ID="Nombre_ProyectoTextBox" runat="server" Text='<%# Bind("Nombre_Proyecto") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>Institucion:
                            </td>
                            <td>
                                <asp:TextBox ID="InstitucionTextBox" runat="server" Text='<%# Bind("Institucion") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>Titulo:
                            </td>
                            <td>
                                <asp:TextBox ID="TituloTextBox" runat="server" Text='<%# Bind("Titulo") %>' />
                            </td>
                        </tr>
                       <%-- <tr>
                            <td>link:                       
                            </td>
                            <td>
                                <asp:TextBox ID="linkTextBox" runat="server" Visible="false" Text='<%# Bind("link") %>' />
                            </td>
                        </tr>--%>
                        <tr>
                            <td></td>
                            <td>
                                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" />
                                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                            </td>
                        </tr>


                    </table>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <table cellpadding="3" cellspacing="0" class="tablaComun" width="90%" align="center" border="0">
                        <tr>
                            <td colspan="2" class="thtablaComun">Datos Generales</td>
                        </tr>
                        <tr>
                            <td style="width: 30%">Nombre_Proyecto:
                            </td>
                            <td style="width: 70%">
                                <asp:TextBox ID="Nombre_ProyectoTextBox" runat="server" Text='<%# Bind("Nombre_Proyecto") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">Institucion:
                            </td>
                            <td style="width: 70%">
                                <asp:TextBox ID="InstitucionTextBox" runat="server" Text='<%# Bind("Institucion") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">Titulo:
                            </td>
                            <td style="width: 70%">
                                <asp:TextBox ID="TituloTextBox" runat="server" Text='<%# Bind("Titulo") %>' />
                            </td>
                        </tr>
                        <%--<tr>
                            <td style="width: 30%">link:
                            </td>
                            <td style="width: 70%">
                                <asp:TextBox ID="linkTextBox" runat="server" Visible="false" Text='<%# Bind("link") %>' />
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insertar" />
                                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                            </td>
                        </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <table cellpadding="3" cellspacing="0" class="tablaComun" width="90%" align="center" border="0">
                        <tr>
                            <td colspan="2" class="thtablaComun">Datos Generales</td>
                        </tr>
                        <tr>
                            <td>id_tema:
                            </td>
                            <td>
                                <asp:Label ID="id_temaLabel" runat="server" Text='<%# Eval("id_tema") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>Nombre_Proyectos:                    
                            </td>
                            <td>
                                <asp:Label ID="Nombre_ProyectoLabel" runat="server" Text='<%# Bind("Nombre_Proyecto") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>Institucion:                    
                            </td>
                            <td>
                                <asp:Label ID="InstitucionLabel" runat="server" Text='<%# Bind("Institucion") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>Titulo:                   
                            </td>
                            <td>
                                <asp:Label ID="TituloLabel" runat="server" Text='<%# Bind("Titulo") %>' />
                            </td>
                        </tr>
                        <%--<tr>
                            <td>link:                   
                            </td>
                            <td>
                                <asp:Label ID="linkLabel" runat="server" Text='<%# Bind("link") %>' />
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtVal" runat="server" MaxLength="1" ReadOnly="True" Width="1px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:ImageButton runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandArgument='<%# Eval("id_tema")%>' CommandName="Edit" />
                                <asp:ImageButton runat="server" ImageUrl="~/images/aplicacion/btnEliminar.gif" CommandName="Delete" CommandArgument='<%# Eval("id_tema") %>' />
                            </td>
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
                            <%--<tr>
                                <td style="width: 30%">Link del Proyecto</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtlinkAdd" runat="server" MaxLength="300" Rows="4" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                </td>
                            </tr>--%>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td colspan="1"></td>
                                <td>
                                    <asp:ValidationSummary ID="vsValidacionAdd" runat="server" DisplayMode="List" ForeColor=""
                                        HeaderText="Se encontraron los siguientes errores:" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1"></td>
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

