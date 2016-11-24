<%@ Page Language="VB" MasterPageFile="~/mpProiectus.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" Culture="es-MX" Theme="skin"%>
<%@ OutputCache Duration="5" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" Runat="Server">
    <style type="text/css">
        .login {
            /*background-image:url(images/2014/login.png);*/
            background-color: #545454;
            width: 90%;
            height: 90%;
            margin:auto;
            display: inline-block;
            position: relative;
            border-radius:2%;          
        }

        .registro {
            background-image: url(images/2014/registro.png);
            width: 322px;
            height: 250px;
            display: inline-block;
            position: relative;
            float: right;
        }
    
        .tbUsuario {
            background-color:white; 
                    
            line-height: 22px;
            position: absolute;
            top: 8%;
            width: 70%;
            left: 20%;
            float:right;
        }
        .labusu{
            top: 8%;
            left: 1%;
            float:left;
        }

        .tbPass {
            background-color:white;                        
            line-height: 22px;
            position: absolute;
            top: 20%;
            width: 70%;
            left: 20%;
            float:right;
        }
        .labcon{
            top: 20%;
            left: 1%;
            float:left;
        }
        


        .pie > p {
            font-size: 20px;
        }


        .validacion {
            position: absolute;
            left: 50px;
            top: 193px;
        }

        .uEquis {
            position: absolute;
            left: 287px;
            top: 36px;
        }

        .pEquis {
            position: absolute;
            left: 287px;
            top: 91px;
        }

        div.botonIngresa {
            position: absolute;
            left: 17px;
            top: 137px;
            width: 124px;
            background-repeat: no-repeat;
            background-position: center center;
        }

        div.botonRegistra {
            position: absolute;
            left: 156px;
            top: 137px;
            width: 124px;
            background-repeat: no-repeat;
            background-position: center center;
        }

        div.botonIngresa > input.boton {
            left: 2px;
        }

        .olvido {
            bottom: 239px;
            left: 18px;
            position: absolute;
        }

        .ayuda {
            bottom: 239px;
            position: absolute;
            right: 59px;
        }

        .btIngresar {
            background: none repeat scroll 0 0 rgba(0, 0, 0, 0);
            bottom: 50px;
            left: 112px;
            position: absolute;
            width: 117px;
        }
    </style>
</asp:Content>


<asp:Content ID="cntDefault" ContentPlaceHolderID="cphPrincipal" Runat="Server">

<div class="row-centralcontent">

    <div class="col1">
        

        <br /><br />
         <%--<h3>Sistema de control y seguimientos de proyectos </h3>--%>
         <p>El SCS constituye una herramienta de ayuda para el manejo y gestión integral de la información relacionada 
         con los proyectos de Investigación y desarrollo Tecnológico.</p>
        <br /><br />
        <h3>Entre sus alcances se encuentra:</h3>

        <ul>
        <li>Inventario de proyectos</li>
        <li>Seguimiento administrativo</li>
        <li>Seguimiento técnico</li>
        <li>Reportes y estadísticas</li>
        <li>Productos</li>
        </ul>

    </div>

    <div class="col2">
        
            <div class="login">
                <asp:Label ID="labusu" class="labusu" runat="server" Text="Usuario:" for="txtUsuario" style="margin-top: 36px; margin-left: 5px;" ></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server" MaxLength="15" ToolTip="Ingrese Usuario" TabIndex="1" CssClass="tbUsuario"></asp:TextBox>
    
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="Usuario es requerido" ToolTip="Usuario es requerido" CssClass="uEquis">x</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvUsuario" runat="server" ControlToValidate="txtUsuario"
                                            ErrorMessage="Usuario no válido" ToolTip="Usuario no válido">x</asp:CustomValidator>
                <asp:Label ID="labcon" class="labcon" runat="server" Text="Contraseña:" for="txtContrasenia" style="margin-top: 0px; margin-left: 5px; position: absolute; left: 0px;" ></asp:Label>
               <asp:TextBox ID="txtContrasenia" runat="server" MaxLength="15" ToolTip="Ingrese Contraseña" TextMode="Password" TabIndex="2" CssClass="tbPass"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ControlToValidate="txtContrasenia"
                            ErrorMessage="Contraseña es requerida" ToolTip="Contraseña requerida, maximo 15 caracteres de longitud" CssClass="pEquis">x</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvContrasenia" runat="server" ControlToValidate="txtContrasenia"
                            ErrorMessage="Contraseña no válida" ToolTip="Contraseña no válida">x</asp:CustomValidator>

                <asp:ValidationSummary ID="vsInicioSesion" runat="server" CssClass="validacion" />
                <asp:HyperLink ID="hlnkReiniciarContra" runat="server" CssClass="olvido" NavigateUrl="~/Reiniciarcontra.aspx" >¿Olvidó su contraseña?</asp:HyperLink>&nbsp;
                <asp:HyperLink ID="hlnkAyuda" runat="server"  CssClass="ayuda" NavigateUrl="~/ayuda/ayuda.aspx" Target="_blank">Ayuda</asp:HyperLink>


        
   
                    
                    <div class="boton_container botonIngresa">
                        <asp:Button ID="ibtnIngresar" CssClass="boton" Text="Ingresar"  runat="server" PostBackUrl="~/Default.aspx" />
                    </div>
                    <div class="boton_container botonRegistra">
                        <asp:Button runat="server" ID="ibtnRegistrar" CssClass="boton"  Text="Registrarse" PostBackUrl="~/Registro.aspx" CausesValidation="False" UseSubmitBehavior="False" ValidateRequestMode="Disabled" ViewStateMode="Disabled"/>
                   
                    </div>
         

                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUsuario" ErrorMessage="Solo letras o numeros" ValidationExpression="^([a-zA-Z]|[0-9])+$">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="Solo se permiten letras y numeros" ValidationExpression="^([a-zA-Z]|[0-9])+$">*</asp:RegularExpressionValidator>
                <br /><br />
                <div class="videos" style="margin-top:52%; margin-left:5%;">
                    <iframe width="95%" height="100%" src="https://www.youtube.com/embed/fsO8fPdCtxQ?rel=0&autoplay=1" frameborder="1" allowfullscreen></iframe>
                </div>
                <br />
                <p style="text-align:center; margin-top=0; margin-bottom=0;">
                    <span  class="videos-link"><a href="https://www.youtube.com/channel/UCoWWO_lK5arImCwY6GbaeeQ?rel=0&autoplay=1" target="_blank"><strong style="color:black;">Canal CONAFOR</strong> <img src="images/2014/YOUTUBE.jpg" width="3%" height="3%" alt="CANAL CONAFOR" /></a></span>
                </p>

            </div>
            
            
       
           

    </div>

</div>

 
</asp:Content>

