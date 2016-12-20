<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="ayuda2.aspx.vb" Inherits="Inicio" title="Sistema de Control y Seguimiento de " %>



<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">
    
     

          <br /><br />
    <div class="encabezado_ayuda">
        <h1>Bienvenidos a la ayuda de CONAFOR</h1>
    </div>
   <div class="row-centralcontent2">
        <div class="columna1">
             <h2><strong>Visitante</strong></h2>
             <div class="c1">
                  <ul>
                      <li><a href="Registro.aspx">Registrate</a></li>
                     
                      <li><a href="modo_ingreso.aspx">Modo de Ingresar</a></li>
                      <li><a href="contacto_gerencia.aspx">Contactanos.aspx</a></li>
                      <li><a href="RegistroProyectos.aspx">Busqueda de proyectos</a></li>
                      <li><a href="lectura_proyectos.aspx">Lectura de proyectos</a></li>
                      <li><a href="descarga_productos.aspx">Descarga de productos</a></li>                      
                 </ul>
             </div>
        </div>
        <div class="columna2">
             <h2><strong>Enlace CONAFOR</strong></h2>
             <div class="c2">
                 <ul>
                     <li><a href="editar_proyectos.aspx">Editar proyectos</a></li>
                     <li><a href="agregar_proyecto.aspx">Agregar un proyecto nuevo</a></li>                     
                 </ul>
             </div>
        </div>
        <div class="columna3">
             <h2><strong>Administrador del Sistema</strong></h2>
             <div class="c3">
                  <ul>
                      <li><a href="eliminar_proyecto.aspx">Eliminar proyecto</a></li>
                      <li><a href="editar_catalogo.aspx">Editar informacion de un catalogo</a></li>
                      <li><a href="agregar_catalogo.aspx">Agregar informacion de un catalogo</a></li>
                      <li><a href="eliminar_catalogo.aspx">Eliminar informacion de un catalogo</a></li>
                      <li><a href="generar_reportes.aspx">Generador de reportes</a></li>
                      <li><a href="usuarios_ayuda.aspx">Usuarios</a></li>                     
                 </ul>
             </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphCabecera" Runat="Server"></asp:Content>

