Imports System.Data

Partial Class TemasRelacionados
    Inherits System.Web.UI.Page



#Region "Definiciones"
    Private Const PathProducts As String = "~/Productos/"

    Private Property CurrentCveProyecto() As String
        Get
            Dim o As Object = ViewState("CurrentCveProyecto")
            If o Is Nothing Then
                Return "-1"
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("CurrentCveProyecto") = value
        End Set
    End Property

    Private Property CurrentCveEtapa() As Integer
        Get
            Dim o As Object = ViewState("CurrentCveEtapa")
            If o Is Nothing Then
                Return -1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("CurrentCveEtapa") = value
        End Set
    End Property

    Private Property CurrentCveAsunto() As Integer
        Get
            Dim o As Object = ViewState("CurrentCveAsunto")
            If o Is Nothing Then
                Return -1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("CurrentCveAsunto") = value
        End Set
    End Property

    Private Property CurrentCveVisita() As Integer
        Get
            Dim o As Object = ViewState("CurrentCveVisita")
            If o Is Nothing Then
                Return -1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("CurrentCveVisita") = value
        End Set
    End Property


    Public ReadOnly Property ValExpTipoApoyo() As String
        Get
            Dim taTipoApoyo As New dsAppTableAdapters.CatTipoApoyoTableAdapter
            Return taTipoApoyo.expRegTipoApoyo
        End Get
    End Property

    Public ReadOnly Property ValExpRegion() As String
        Get
            Dim taRegion As New dsAppTableAdapters.CatRegionTableAdapter
            Return taRegion.ExpRegRegion
        End Get
    End Property

    Public ReadOnly Property ValExpEstado() As String
        Get
            Dim taEstado As New dsAppTableAdapters.spEstadoDDLTableAdapter
            Return taEstado.ExpresionRegularEstado
        End Get
    End Property

    Public ReadOnly Property ValExpMunicipio(ByVal CveEstado As String) As String
        Get
            Dim taMunicipio As New dsAppTableAdapters.spMunicipioDDLPorEstadoTableAdapter
            Return taMunicipio.ExpresionRegularMunicipioPorEstado(CveEstado)
        End Get
    End Property

    Private Sub EstablecerPermisos()
        If (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) IsNot Nothing _
            And grdvProyectos.Rows.Count > 0) Then

            Select Case CInt(Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNivel").ToString))
                Case clsAuthentication.AuthorizationLevelList.Administering
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEtapasEdt"), ImageButton).Visible = True
                    '**ELIMINADO** CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnProblematicasEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnParticipantesEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEspeciesEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEstadosEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).Visible = True
                Case clsAuthentication.AuthorizationLevelList.Financial
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnActualizarEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).Visible = True

                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).Visible = True

                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEtapasEdt"), ImageButton).Visible = False
                    '**ELIMINADO** CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnProblematicasEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnParticipantesEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEspeciesEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEstadosEdt"), ImageButton).Visible = False


                Case clsAuthentication.AuthorizationLevelList.LimitedUpdating
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEtapasEdt"), ImageButton).Visible = True
                    '**ELIMINADO** CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnProblematicasEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnParticipantesEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEspeciesEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEstadosEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).Visible = True
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).Visible = False
                Case clsAuthentication.AuthorizationLevelList.Consulting
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEtapasEdt"), ImageButton).Visible = False
                    '**ELIMINADO** CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnProblematicasEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnParticipantesEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEspeciesEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEstadosEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).Visible = False
                Case Else
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEtapasEdt"), ImageButton).Visible = False
                    '**ELIMINADO** CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnProblematicasEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnParticipantesEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEspeciesEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEstadosEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).Visible = False
                    CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).Visible = False
            End Select
        End If

    End Sub

#End Region

#Region "EventosPagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Correo As New clsEnviarCorreo()
        ' Correo.EnivioAviso()
        If Not IsPostBack() Then
            If (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) IsNot Nothing) Then
                Select Case CInt(Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNivel").ToString))
                    Case clsAuthentication.AuthorizationLevelList.Administering
                        ibtnNuevoDw.Visible = True
                        ibtnNuevoUp.Visible = True
                    Case clsAuthentication.AuthorizationLevelList.Financial
                        ibtnNuevoDw.Visible = False
                        ibtnNuevoUp.Visible = False
                    Case clsAuthentication.AuthorizationLevelList.LimitedUpdating
                        ibtnNuevoDw.Visible = True
                        ibtnNuevoUp.Visible = True
                    Case clsAuthentication.AuthorizationLevelList.Consulting
                        ibtnNuevoDw.Visible = False
                        ibtnNuevoUp.Visible = False
                    Case Else
                        ibtnNuevoDw.Visible = False
                        ibtnNuevoUp.Visible = False
                End Select
            End If
            StartRowIndex = 1
            Me.mviewProyectos.SetActiveView(Me.viewLista)
            'Me.mviewProyectos.SetActiveView(Me.viewDetalle)
            'revTipoApoyoAdd.ValidationExpression = ValExpTipoApoyo
            'revRegionSegAdd.ValidationExpression = ValExpRegion
        End If
    End Sub

#End Region

#Region "Paginacion"

    Protected Sub grdvProyectos_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdvProyectos.PageIndexChanged
        'PageIndex = grdvProyectos.PageIndex
        EnableNavigation()
    End Sub

    Private Sub EnableNavigation()
        Dim totalrow As Integer
        totalrow = TotalRowCount()
        PageIndex = grdvProyectos.PageIndex + 1
        lblTotalProyectosUP.Text = String.Format("{0} proyectos encontrados", totalrow)
        lblTotalProyectosDW.Text = String.Format("{0} proyectos encontrados", totalrow)
        If totalrow > 10 Then
            lblPaginaActualUP.Text = String.Format("Página {0} de {1}", PageIndex, (totalrow \ MaximumRows) + 1)
            lblPaginaActualDW.Text = String.Format("Página {0} de {1}", PageIndex, (totalrow \ grdvProyectos.PageSize) + 1)
        Else
            lblPaginaActualUP.Text = "Página 1 de 1"
            lblPaginaActualDW.Text = "Página 1 de 1"
        End If
    End Sub

    Private ReadOnly Property TotalRowCount() As Integer
        Get
            Dim tatemas As New dsAppTableAdapters.Temas_RelacionadosTableAdapter
            Dim Estatus As Integer
            Dim Anio As Integer
            Dim filtro As String
            Dim CveInstitucion As Integer
            If (txtBusqueda.Text <> String.Empty) Then filtro = txtBusqueda.Text Else filtro = ""
            'If (ddlAnioProyectoBuscar.SelectedValue <> String.Empty) Then Anio = CInt(ddlAnioProyectoBuscar.SelectedValue) Else Anio = 0
            'If (ddlInstitucionBuscar.SelectedValue <> String.Empty) Then CveInstitucion = CInt(ddlInstitucionBuscar.SelectedValue) Else CveInstitucion = 0

            Return tatemas.spTemasRelacionados_CuentaTotalFiltro(filtro)
        End Get
    End Property

    Private Property StartRowIndex() As Integer
        Get
            Dim o As Object = ViewState("StartRowIndex")
            If o Is Nothing Then
                Return 1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("StartRowIndex") = value
        End Set
    End Property

    Private Property MaximumRows() As Integer
        Get
            Dim o As Object = ViewState("MaximumRows")
            If o Is Nothing Then
                Return 10
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("MaximumRows") = value
        End Set
    End Property

    Private Property PageIndex() As Integer
        Get
            Dim o As Object = ViewState("PageIndex")
            If o Is Nothing Then
                Return 1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("PageIndex") = value
        End Set
    End Property

    Private Property PagesPerGroup() As Integer
        Get
            Dim o As Object = ViewState("PagesPerGroup")
            If o Is Nothing Then
                Return 15
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("PagesPerGroup") = value
        End Set
    End Property
#End Region

#Region "Busqueda"


    Protected Sub lnkbMasOpciones_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'pnlMasOpcionesBusqueda.Visible = Not pnlMasOpcionesBusqueda.Visible
        'ibtnBuscarProyectos.Visible = Not pnlMasOpcionesBusqueda.Visible
        'If pnlMasOpcionesBusqueda.Visible Then
        '    lnkbMasOpciones.Text = "- ocultar opciones"
        'Else
        '    lnkbMasOpciones.Text = "+ mas opciones ..."
        'End If

        grdvProyectos.DataBind()
    End Sub

    Protected Sub ibtnBuscarProyectos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnBuscarProyectos.Click
        'StartRowIndex = 1
        'MaximumRows = 10
        'textoBusqueda = txtBusqueda.Text
        'If Me.pnlMasOpcionesBusqueda.Visible Then
        'CveProyectoBuscar = txtCveCONACYTBuscar.Text
        'CveTipoApoyoBuscar = ddlTipoApoyoBuscar.SelectedValue
        'CveEstatusBuscar = ddlEstatusBuscar.SelectedValue
        'CveRegionBuscar = ddlRegionSegBuscar.SelectedValue
        'AnioConvBuscar = ddlAnioProyectoBuscar.SelectedValue
        'CveInstitucionBuscar = ddlInstitucionBuscar.SelectedValue
        grdvProyectos.SelectedIndex = -1
        grdvProyectos.EditIndex = -1
        'Else
        '    CveProyectoBuscar = String.Empty
        '    CveTipoApoyoBuscar = "--"
        '    CveEstatusBuscar = -1
        '    CveRegionBuscar = "---"
        '    AnioConvBuscar = 1900
        '    CveInstitucionBuscar = -1

        'End If
        grdvProyectos.DataBind()

    End Sub

#End Region

#Region "Proyectos"



    Protected Sub grdvProyectos_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdvProyectos.RowEditing
        CurrentCveProyecto = grdvProyectos.DataKeys(e.NewEditIndex).Value
        pnlBusqueda.Visible = False
        pnlNavegacionUp.Visible = True
        pnlNavegacionDw.Visible = True
        odsTemas.FilterExpression = grdvProyectos.DataKeyNames(0) & " = '" & CurrentCveProyecto & "'"
        grdvProyectos.DataBind()
        e.NewEditIndex = 0
    End Sub

    Protected Sub grdvProyectos_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdvProyectos.RowCancelingEdit
        CurrentCveProyecto = "-1"
        pnlBusqueda.Visible = True
        pnlNavegacionUp.Visible = True
        pnlNavegacionDw.Visible = True
        odsTemas.FilterExpression = String.Empty
        grdvProyectos.SelectedIndex = -1
        grdvProyectos.EditIndex = -1
        grdvProyectos.DataBind()
    End Sub
    Protected Sub grdvProyectos_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdvProyectos.RowUpdating
        'Dim taProyecto As New dsAppTableAdapters.ProyectoTableAdapter
        Dim taObjeto As New dsAppTableAdapters.CatObjetoTableAdapter
        Dim dtFehcaCaptura As Date

        Try

            'If (IsDBNull(CType(grdvProyectos.Rows(e.RowIndex).FindControl("hdnfFechaCapturaEdt"), HiddenField).Value)) Or _
            '    (CType(grdvProyectos.Rows(e.RowIndex).FindControl("hdnfFechaCapturaEdt"), HiddenField).Value = String.Empty) Then
            '    dtFehcaCaptura = Date.Now
            'Else
            '    dtFehcaCaptura = CDate(CType(grdvProyectos.Rows(e.RowIndex).FindControl("hdnfFechaCapturaEdt"), HiddenField).Value)
            'End If
            'Los valores que hay que poner correctamente
            'e.NewValues("Original_id_tema") = CType(grdvProyectos.Rows(e.RowIndex).FindControl("id_temaLabel1"), Label).Text
            'e.NewValues("Nombre_Proyecto") = CType(grdvProyectos.Rows(e.RowIndex).FindControl("Nombre_ProyectoEdit"), TextBox).Text
            'e.NewValues("Titulo") = CType(grdvProyectos.Rows(e.RowIndex).FindControl("TituloEdit"), TextBox).Text
            'e.NewValues("Institucion") = CInt(taObjeto.GetCveObjetoByCveTipoApoyo(CType(grdvProyectos.Rows(e.RowIndex).FindControl("ddlInstitucionEdt"), DropDownList).SelectedValue))
            'e.NewValues("link") = CType(grdvProyectos.Rows(e.RowIndex).FindControl("linkEdit"), TextBox).Text

            'Dim a As String = CType(grdvProyectos.Rows(e.RowIndex).FindControl("id_temaLabel1"), Label).Text
            'Dim b As String = CType(grdvProyectos.Rows(e.RowIndex).FindControl("Nombre_ProyectoEdit"), TextBox).Text
            'Dim c As String = CType(grdvProyectos.Rows(e.RowIndex).FindControl("TituloEdit"), TextBox).Text
            'Dim d As String = CInt(taObjeto.GetCveObjetoByCveTipoApoyo(CType(grdvProyectos.Rows(e.RowIndex).FindControl("ddlInstitucionEdt"), DropDownList).SelectedValue))
            'Dim f As String = CType(grdvProyectos.Rows(e.RowIndex).FindControl("linkEdit"), TextBox).Text
            'If f = String.Empty Then
            '    e.NewValues("link") = "N/A"
            'End If


            grdvProyectos.EditIndex = -1
            grdvProyectos.DataBind()
            pnlBusqueda.Visible = True
            pnlNavegacionUp.Visible = True
            pnlNavegacionDw.Visible = True

        Catch ex As Exception
            e.Cancel = True
            CType(grdvProyectos.Rows(e.RowIndex).FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar"
            CType(grdvProyectos.Rows(e.RowIndex).FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(grdvProyectos.Rows(e.RowIndex).FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Finally
            'taProyecto.Dispose()
            taObjeto.Dispose()
        End Try
    End Sub

    Protected Sub ibtnNuevoUp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnNuevoUp.Click
        mviewProyectos.SetActiveView(viewAgregar)
    End Sub

    Protected Sub ibtnNuevoDw_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnNuevoDw.Click
        mviewProyectos.SetActiveView(viewAgregar)
    End Sub

    Protected Sub ibtnCancelarAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnCancelarAdd.Click
        grdvProyectos.EditIndex = -1
        grdvProyectos.DataBind()
        ClearFieldAdding()
        mviewProyectos.SetActiveView(viewLista)
    End Sub


    Protected Sub grdvProyectos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvProyectos.RowDataBound
        'NORMAL SIN EDICION 
        If e.Row.RowType = DataControlRowType.DataRow And (e.Row.RowState = DataControlRowState.Normal Or e.Row.RowState = DataControlRowState.Alternate) Then
            Dim DataField As DataControlFieldCell = CType(e.Row.Controls(0), DataControlFieldCell)
            Dim producto As dsApp.Temas_RelacionadosRow = _
                CType(CType(e.Row.DataItem, DataRowView).Row, dsApp.Temas_RelacionadosRow)
            'Dim product As dsApp.ProyectoRow = _
            '    CType(CType(e.Row.DataItem, DataRowView).Row, dsApp.ProyectoRow)

            Dim db As ImageButton = CType(DataField.FindControl("btnEliminar"), ImageButton)
            Dim ibtnEditar As ImageButton = CType(DataField.FindControl("btnEditar"), ImageButton)
            'Dim txtValidar As TextBox = CType(DataField.FindControl("txtVal"), TextBox)

            If (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) IsNot Nothing) Then
                Select Case CInt(Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNivel").ToString))
                    Case clsAuthentication.AuthorizationLevelList.Administering
                        ibtnEditar.Visible = True
                        db.Visible = True
                        'txtValidar.Visible = True
                    Case clsAuthentication.AuthorizationLevelList.Financial
                        ibtnEditar.Visible = True
                        db.Visible = False
                        'txtValidar.Visible = False
                    Case clsAuthentication.AuthorizationLevelList.LimitedUpdating
                        ibtnEditar.Visible = True
                        db.Visible = False
                        'txtValidar.Visible = False
                    Case clsAuthentication.AuthorizationLevelList.Consulting
                        ibtnEditar.Visible = False
                        db.Visible = False
                        ' txtValidar.Visible = False
                    Case Else
                        ibtnEditar.Visible = False
                        db.Visible = False
                        'txtValidar.Visible = False
                End Select
            End If

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar el proyecto {0}?');", _
                producto.id_tema)
            ' product.CveProyecto.Replace("'", "\'"))
        End If
        'FILA QUE SE ESTA EDITANDO
        If e.Row.RowState = DataControlRowState.Edit And e.Row.RowType = DataControlRowType.DataRow Then
            EstablecerPermisos()
        End If
    End Sub

    Protected Sub ibtnActualizarAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnActualizarAdd.Click
        'Dim taProyecto As New dsAppTableAdapters.ProyectoTableAdapter
        Dim taObjeto As New dsAppTableAdapters.CatObjetoTableAdapter

        Dim taTemas As New dsAppTableAdapters.Temas_RelacionadosTableAdapter


        Try
            'If txtlinkAdd.Text = String.Empty Then
            '    txtlinkAdd.Text = "N/A"
            'End If
            taTemas.spTemasRelacionados_Insert(txtNombreAdd.Text, ddlInstitucionAdd.SelectedValue, txtTituloAdd.Text, txtlinkAdd.Text)

            lblEstatusAdd.Text = "Proyecto ' " & txtCveTemasBuscar.Text & " ' insertado con éxito"
            lblEstatusAdd.Visible = True
            txtBusqueda.Text = txtCveTemasBuscar.Text
            odsTemas.DataBind()
            grdvProyectos.DataBind()
            mviewProyectos.SetActiveView(viewLista)
            ClearFieldAdding()

        Catch concurrencyEx As DBConcurrencyException
            cuvExcepcionesAdd.ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            cuvExcepcionesAdd.ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            cuvExcepcionesAdd.IsValid = False
        Catch constraintEx As ConstraintException
            cuvExcepcionesAdd.ErrorMessage = "Error de llaves duplicadas"
            cuvExcepcionesAdd.ToolTip = "Error de llaves duplicadas"
            cuvExcepcionesAdd.IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            cuvExcepcionesAdd.ErrorMessage = "Fila no accesible"
            cuvExcepcionesAdd.ToolTip = "Fila no accesible"
            cuvExcepcionesAdd.IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            cuvExcepcionesAdd.ErrorMessage = "Nombre duplicado"
            cuvExcepcionesAdd.ToolTip = "Nombre duplicado"
            cuvExcepcionesAdd.IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            cuvExcepcionesAdd.ErrorMessage = "Fila esta siendo modificada"
            cuvExcepcionesAdd.ToolTip = "Fila esta siendo modificada"
            cuvExcepcionesAdd.IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            cuvExcepcionesAdd.ErrorMessage = "Restricción no válida"
            cuvExcepcionesAdd.ToolTip = "Restricción no válida"
            cuvExcepcionesAdd.IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            cuvExcepcionesAdd.ErrorMessage = "Expresión no válida"
            cuvExcepcionesAdd.ToolTip = "Expresión no válida"
            cuvExcepcionesAdd.IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            cuvExcepcionesAdd.ErrorMessage = "No se encontró una llave principal"
            cuvExcepcionesAdd.ToolTip = "No se encontró una llave principal"
            cuvExcepcionesAdd.IsValid = False
        Catch noNullEx As NoNullAllowedException
            cuvExcepcionesAdd.ErrorMessage = "Valor nulo no permitido"
            cuvExcepcionesAdd.ToolTip = "Valor nulo no permitido"
            cuvExcepcionesAdd.IsValid = False
        Catch readOnlyEx As ReadOnlyException
            cuvExcepcionesAdd.ErrorMessage = "La base de datos es de solo lectura"
            cuvExcepcionesAdd.ToolTip = "La base de datos es de solo lectura"
            cuvExcepcionesAdd.IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            cuvExcepcionesAdd.ErrorMessage = "La fila solicitada no esta en la base de datos"
            cuvExcepcionesAdd.ToolTip = "La fila solicitada no esta en la base de datos"
            cuvExcepcionesAdd.IsValid = False
        Catch strongTypingEx As StrongTypingException
            cuvExcepcionesAdd.ErrorMessage = "Error en tipos de datos"
            cuvExcepcionesAdd.ToolTip = "Error en tipos de datos"
            cuvExcepcionesAdd.IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            cuvExcepcionesAdd.ErrorMessage = "No fue posible generar el conjunto de datos"
            cuvExcepcionesAdd.ToolTip = "No fue posible generar el conjunto de datos"
            cuvExcepcionesAdd.IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            cuvExcepcionesAdd.ErrorMessage = "Versión no encontrada"
            cuvExcepcionesAdd.ToolTip = "Versión no encontrada"
            cuvExcepcionesAdd.IsValid = False
        Catch dataEx As DataException
            cuvExcepcionesAdd.ErrorMessage = "Error de datos"
            cuvExcepcionesAdd.ToolTip = "Error de datos"
            cuvExcepcionesAdd.IsValid = False
        Catch ex As Exception
            cuvExcepcionesAdd.ErrorMessage = "Ocurrió un error al intentar guardar " & ex.Message
            cuvExcepcionesAdd.ToolTip = "Ocurrió un error al intentar guardar"
            cuvExcepcionesAdd.IsValid = False
        End Try
    End Sub

    Protected Sub grdvProyectos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdvProyectos.SelectedIndexChanged
        'Indicar cual se va ha ver el detalle
        hdCveProyecto_Detalle.Value = grdvProyectos.DataKeys(grdvProyectos.SelectedIndex).Value
        frmvProyecto_Detalle.DataBind()
        mviewProyectos.SetActiveView(viewDetalle)
        grdvProyectos.SelectedIndex = -1
        pnlBusqueda.Visible = False
        pnlNavegacionUp.Visible = True
        pnlNavegacionDw.Visible = False
        SelPestaniaProgramaPago()
    End Sub
    'alberto
    Protected Sub frmvProyecto_Detalle_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmvProyecto_Detalle.DataBound
        'CType(frmvProyecto_Detalle.FindControl("id_temaLabel1"), Label).Text = CType(frmvProyecto_Detalle.FindControl("id_temaLabel1"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        'CType(frmvProyecto_Detalle.FindControl("Nombre_ProyectoTextBox"), Label).Text = CType(frmvProyecto_Detalle.FindControl("Nombre_ProyectoTextBox"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        'CType(frmvProyecto_Detalle.FindControl("InstitucionTextBox"), Label).Text = CType(frmvProyecto_Detalle.FindControl("InstitucionTextBox"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        'CType(frmvProyecto_Detalle.FindControl("TituloTextBox"), Label).Text = CType(frmvProyecto_Detalle.FindControl("TituloTextBox"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        'CType(frmvProyecto_Detalle.FindControl("lbllink"), Label).Text = CType(frmvProyecto_Detalle.FindControl("lbllink"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        'CType(frmvProyecto_Detalle.FindControl("lblImpactosEsperadosST"), Label).Text = CType(frmvProyecto_Detalle.FindControl("lblImpactosEsperadosST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        'CType(frmvProyecto_Detalle.FindControl("lblUsuarioTTST"), Label).Text = CType(frmvProyecto_Detalle.FindControl("lblUsuarioTTST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        'CType(frmvProyecto_Detalle.FindControl("lblMaterialesTTST"), Label).Text = CType(frmvProyecto_Detalle.FindControl("lblMaterialesTTST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        'CType(frmvProyecto_Detalle.FindControl("lblRequisitosTTST"), Label).Text = CType(frmvProyecto_Detalle.FindControl("lblRequisitosTTST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        'CType(frmvProyecto_Detalle.FindControl("lblActividadesTTST"), Label).Text = CType(frmvProyecto_Detalle.FindControl("lblActividadesTTST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
    End Sub
    Protected Sub ibtnRegresar_Detalle_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnRegresar_Detalle.Click
        mviewProyectos.SetActiveView(viewLista)
        pnlBusqueda.Visible = True
        pnlNavegacionUp.Visible = True
        pnlNavegacionDw.Visible = True
    End Sub

    Protected Sub ibtnExpandirTT_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'pnlExpandirTT.Visible = Not pnlExpandirTT.Visible
        'lblMasInfoTTST.Visible = Not lblMasInfoTTST.Visible
        'If pnlExpandirTT.Visible Then
        '    ibtnExpandirTTST.ImageUrl = "~/images/aplicacion/contraer.gif"
        'Else
        '    ibtnExpandirTTST.ImageUrl = "~/images/aplicacion/expandir.gif"
        'End If
    End Sub

    Protected Sub ibtnExpandirObjetivosST_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'pnlExpandirObjetivosST.Visible = Not pnlExpandirObjetivosST.Visible
        'lblMasInfoObjetivosST.Visible = Not lblMasInfoObjetivosST.Visible
        'If pnlExpandirObjetivosST.Visible Then
        '    ibtnExpandirObjetivosST.ImageUrl = "~/images/aplicacion/contraer.gif"
        'Else
        '    ibtnExpandirObjetivosST.ImageUrl = "~/images/aplicacion/expandir.gif"
        'End If
    End Sub

    Protected Sub ibtnMasInfoGralST_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'pnlMasInfoGralST.Visible = Not pnlMasInfoGralST.Visible
        'lblMasInfoGralST.Visible = Not lblMasInfoGralST.Visible
        'If pnlMasInfoGralST.Visible Then
        '    ibtnMasInfoGralST.ImageUrl = "~/images/aplicacion/contraer.gif"
        'Else
        '    ibtnMasInfoGralST.ImageUrl = "~/images/aplicacion/expandir.gif"
        'End If
    End Sub

    Private Sub SelPestaniaDatosGenerales()
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_sel.gif"
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
        '**ELIMINADO** CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_rep.gif"
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_rep.gif"
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_rep.gif"
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_rep.gif"
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_rep.gif"
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_rep.gif"
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_rep.gif"
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_rep.gif"
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_in_rep.gif"
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("viewInfraestructuraEdt"), View))
    End Sub
    Protected Sub ibtnDatosGeneralesEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaDatosGenerales()
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("viewDatosGeneralesEdt"), View))
        'odsProyecto.FilterExpression = grdvProyectos.DataKeyNames(0) & " = '" + grdvProyectos.DataKeys(grdvProyectos.EditIndex).Value + "'"
        'grdvProyectos.DataBind()
        EstablecerPermisos()
    End Sub

    Protected Sub odsProyecto_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsTemas.Selecting
        'e.InputParameters("Busqueda") = textoBusqueda
        'e.InputParameters("CveTipoApoyo") = CveTipoApoyoBuscar
        'e.InputParameters("CveEstatus") = CveEstatusBuscar
        'e.InputParameters("CveRegion") = CveRegionBuscar
        'e.InputParameters("AnioConvocatoria") = AnioConvBuscar
        'e.InputParameters("CveInstitucion") = CveInstitucionBuscar
        EnableNavigation()
    End Sub

#End Region




    Private Sub ClearFieldAdding()
        txtNombreAdd.Text = String.Empty
        'txtlinkAdd.Text = String.Empty
        txtTituloAdd.Text = String.Empty
        ddlInstitucionAdd.SelectedValue = -1
    End Sub



    Protected Sub ibtnNuevoPG_Click(sender As Object, e As ImageClickEventArgs)
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible = Not CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible
    End Sub

    Private Sub LimpiarProgramaPago()
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("txtMontoPGAdd"), TextBox).Text = String.Empty
        'CType(CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("updpGastoPGAdd"), UpdatePanel).FindControl("ddlTipoGastoPGAdd"), DropDownList).SelectedIndex = -1
        'CType(CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("updpGastoPGAdd"), UpdatePanel).FindControl("ddlGastoPGAdd"), DropDownList).SelectedIndex = -1
        'CType(CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("updpFechaProgPGAdd"), UpdatePanel).FindControl("dtpkFechaProgPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        'CType(CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("updpFechaRealPGAdd"), UpdatePanel).FindControl("dtpkFechaRealPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        'CType(CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("updpFechaSolPGAdd"), UpdatePanel).FindControl("dtpkFechaSolPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("txtClabePGAdd"), TextBox).Text = String.Empty
        'CType(CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("updpEdoMpioPGAdd"), UpdatePanel).FindControl("ddlEstadoPGAdd"), DropDownList).SelectedIndex = -1
        'CType(CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("updpEdoMpioPGAdd"), UpdatePanel).FindControl("ddlMpioPGAdd"), DropDownList).SelectedIndex = -1
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("txtNumFacturaPGAdd"), TextBox).Text = String.Empty
        'CType(CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("updpFechaEntPGAdd"), UpdatePanel).FindControl("dtpkFechaEntPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        'CType(CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("updpFechaConPGAdd"), UpdatePanel).FindControl("dtpkFechaConPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("txtObservacionesPGAdd"), TextBox).Text = String.Empty
    End Sub

    Protected Sub ibtnAdministrativoCancelar_Click(sender As Object, e As ImageClickEventArgs)
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible = False
        LimpiarProgramaPago()
    End Sub

    Protected Sub ibtnGuardarPGAdd_Click(sender As Object, e As ImageClickEventArgs)
        Dim taAdmPago As New dsAppTableAdapters.Temas_Relacionados_ProductosTableAdapter
        Dim boolAgregarRegistro As Boolean = True
        Dim NewNameArchivo As String = String.Empty
        'Obtener los datos para agregar
        Dim id_tema As String = CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("hdCveProyectoAdmEdt"), HiddenField).Value
        'Dim CveEtapa As Integer = Convert.ToInt32(CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ddlCveEtapaAdd"), DropDownList).SelectedValue)
        Dim txtTitulo As String = CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("txtTituloAdd"), TextBox).Text
        Dim objChorizoFile_FileUpload As FileUpload = CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("flupPagosAdd"), FileUpload)

        If objChorizoFile_FileUpload.HasFile Then
            'El nombre formado de Proyecto+Etapa+FechaActual
            NewNameArchivo = "Adm_" & id_tema & "_" & Now().ToString("yyyy-MM-dd_hhmmss")
            'Extencion de archivo
            NewNameArchivo = NewNameArchivo & objChorizoFile_FileUpload.FileName.Substring(objChorizoFile_FileUpload.FileName.LastIndexOfAny("."))

            'Verificar que no sobrepase el tamaño del archivo permitido
            If objChorizoFile_FileUpload.FileBytes.Length <= CInt(System.Web.Configuration.WebConfigurationManager.AppSettings("MaxBytesArchivo").ToString) Then
                Try
                    objChorizoFile_FileUpload.SaveAs(Server.MapPath(PathProducts) & NewNameArchivo)
                Catch ex As Exception
                    Response.Write("error al intentar guardar el archivo: " & ex.Message)
                End Try
            End If
        End If
        Try
            taAdmPago.Insert(id_tema, txtTitulo, Now, PathProducts & NewNameArchivo)
            Response.Redirect("~/TemasRelacionados.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dtlProyectoProgPagoPG_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible = False
        LimpiarProgramaPago()
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).SelectedIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyectoProgPagoPG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible = False
        LimpiarProgramaPago()
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("odsPoryectoProgPagoPG"), ObjectDataSource).FilterExpression = grdvProyectos.DataKeyNames(0) & " = '" & grdvProyectos.DataKeys(grdvProyectos.EditIndex).Value & "' AND " & CType(sender, DataList).DataKeyField.ToString & " = " & CType(sender, DataList).DataKeys(CType(sender, DataList).SelectedIndex)
        'CType(sender, DataList).SelectedIndex = 0
        CType(sender, DataList).DataBind()
        'CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblObservacionesPGSel"), Label).Text = CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblObservacionesPGSel"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        'SelPestaniaProgramaPago()
    End Sub

    Protected Sub dtlProyectoProgPagoPG_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible = False
        LimpiarProgramaPago()
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("odsPoryectoProgPagoPG"), ObjectDataSource).FilterExpression = grdvProyectos.DataKeyNames(0) & " = '" & grdvProyectos.DataKeys(grdvProyectos.EditIndex).Value & "' AND " & CType(source, DataList).DataKeyField.ToString & " = " & CType(source, DataList).DataKeys(e.Item.ItemIndex)
        'CType(source, DataList).EditItemIndex = 0
        CType(source, DataList).EditItemIndex = e.Item.ItemIndex
        CType(source, DataList).DataBind()
    End Sub

    Private Sub SelPestaniaProgramaPago()
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_rep.gif"
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
        ''**ELIMINADO** CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_rep.gif"
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_rep.gif"
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_rep.gif"
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_rep.gif"
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_rep.gif"
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_rep.gif"
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_rep.gif"
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_sel.gif"
        ''CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_in_rep.gif"
        'CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(grdvProyectos.Rows(grdvProyectos.EditIndex).FindControl("viewAdministrativoEdt"), View))
    End Sub

    Protected Sub dtlProductosST_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Select Case e.CommandName
            Case "Download"
                Dim strArchivo() As String = e.CommandArgument.ToString.Split("|")
                Dim taEtapaProducto As New dsAppTableAdapters.Temas_Relacionados_ProductosTableAdapter

                Dim CveProyecto As String = strArchivo(0)
                Dim Titulo As String = strArchivo(2)
                Dim NumeroFile As Integer = 0
                Try
                    '********* LUIS RANGEL ************
                    'Obtener los datos de la DB
                    Dim rowProducto As dsApp.Temas_Relacionados_ProductosRow = taEtapaProducto.GetTemaTituloCat(Integer.Parse(CveProyecto), Titulo)(0)
                    Dim arrArchivo() As String = rowProducto.Ruta.Split("|")
                    'Entra el Polo
                    'Esta instrucción da un problema si el nombre del archivo contiene espacios (LVC)
                    'Response.AddHeader("content-disposition", "attachment; filename=" & strArchivo(3).Substring(strArchivo(3).LastIndexOf("/") + 1))
                    'No es la mejor solución, pero es cómoda (LVC)
                    Response.AddHeader("content-disposition", "attachment; filename=" & arrArchivo(NumeroFile).Replace(" ", "_"))
                    'Sale el Polo
                    'Encontrar el archivo

                    'PathProducts
                    Response.TransmitFile(Server.MapPath(arrArchivo(NumeroFile)))

                    Response.End()
                    '********* FIN LUIS RANGEL *********
                Catch concurrencyEx As DBConcurrencyException
                Catch constraintEx As ConstraintException
                Catch deletedRowEx As DeletedRowInaccessibleException
                Catch duplicateNameEx As DuplicateNameException
                Catch inRowChangingEx As InRowChangingEventException
                Catch invalidConstraintEx As InvalidConstraintException
                Catch invalidExpressionEx As InvalidExpressionException
                Catch missingPrimaryEx As MissingPrimaryKeyException
                Catch noNullEx As NoNullAllowedException
                Catch readOnlyEx As ReadOnlyException
                Catch rowNotInTableEx As RowNotInTableException
                Catch strongTypingEx As StrongTypingException
                Catch typedDataSetEx As TypedDataSetGeneratorException
                Catch versionNotFoundEx As VersionNotFoundException
                Catch dataEx As DataException
                Catch ex As Exception
                Finally
                    taEtapaProducto.Dispose()
                End Try


            Case Else
                Exit Select
        End Select
    End Sub


    '***** Luis RANGEL 2008/02/09 ****
    Protected Sub dtlProductosST_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)

        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then

            Dim rowProducto As dsApp.Temas_Relacionados_ProductosRow
            'obtiene los datos
            rowProducto = CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, dsApp.Temas_Relacionados_ProductosRow)
            Try
                'Mostrar el control por cada archivo
                Dim contador As Integer = 0
                For Each strArchivo As String In rowProducto.Ruta.Split("|")
                    Dim tmpbtn As ImageButton = CType(e.Item.FindControl("imgbArch" & contador.ToString), ImageButton)
                    tmpbtn.CommandName = "Download"
                    tmpbtn.CommandArgument = rowProducto.id_tema & "|" & _
                                           rowProducto.Titulo.ToString() & "|" & _
                                           rowProducto.Fecha.ToString() & "|" & _
                                           contador.ToString()
                    tmpbtn.Visible = True
                    tmpbtn.ToolTip = strArchivo
                    contador = contador + 1
                Next strArchivo
                'Ocultar los que falten
                If (contador < 9) Then
                    For i As Integer = contador To 9
                        Dim tmpbtn As ImageButton = CType(e.Item.FindControl("imgbArch" & i.ToString), ImageButton)
                        tmpbtn.Visible = False
                    Next i
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    '**** FIN LUIS RANGEL ******

    Protected Sub linkLabel_Click(sender As Object, e As EventArgs)
        
    End Sub
End Class
