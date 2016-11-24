<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ayuda.aspx.vb" Inherits="ayuda" StylesheetTheme="skin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ayuda</title>
    <script type="text/javascript" language="javascript">AC_FL_RunContent = 0;</script>
    <script type="text/javascript" src="AC_RunActiveContent.js" language="javascript"></script>
    <script src="scripts/jquery-1.6.1.min.js" type="text/javascript"></script>
</head>
<body>
   <script type="text/javascript" language="javascript">
        if (AC_FL_RunContent == 0) {
	        alert("Esta página requiere el archivo AC_RunActiveContent.js.");
        } else {
	        AC_FL_RunContent( 'codebase','http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0','name','ayuda','width','90%','height','800','align','middle','id','AYUDA','src','ayuda.swf?nivelAyuda=<%Response.Write(nivelAyuda()) %>','quality','high','bgcolor','#ffffff','allowscriptaccess','sameDomain','allowfullscreen','false','pluginspage','http://www.macromedia.com/go/getflashplayer','movie','ayuda?nivelAyuda=<%Response.Write(nivelAyuda()) %>'); //end AC code
        }
    </script>
</body>
</html>
