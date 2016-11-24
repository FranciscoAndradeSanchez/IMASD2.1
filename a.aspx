<%@ Page Language="VB" AutoEventWireup="false" CodeFile="a.aspx.vb" Inherits="a" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">   
 <head>
  <title>jquery sliders</title>
  <script type="text/javascript">var _siteRoot = 'index.html', _root = 'index.html';</script>
    <script src="scripts/jquery.js" type="text/javascript"></script>
    <script src="scripts/scripts.js" type="text/javascript"></script>
    <link href="css/style.css" rel="stylesheet" type="text/css" media="screen"  />
 </head>
 <body>
 
       <!--/top-->
  <div id="header"><div class="wrap">
   <div id="slide-holder">
<div id="slide-runner">
            
            <a href=""><img id='slide-img-1' src='images/Banner%20de%20manuales.jpg' width="1200"; height="400" class="slide" alt="" /></a>
                
            <a href=""><img id='slide-img-2' src='images/Banners%20pantallas-02.jpg' width="1200"; height="400" class="slide" alt="" /></a>
                
            <a href=""><img id='slide-img-3' src='images/Banners%20pantallas-19.jpg' width="1200"; height="400"  class="slide" alt="" /></a>
                
            <a href=""><img id='slide-img-4' src='images/Banners%20pantallas-21.jpg' width="1200"; height="400" class="slide" alt="" /></a>
                
            <a href=""><img id='slide-img-5' src='images/IMAGEN%20I%20(2).JPG' width="1200"; height="400" class="slide" alt="" /></a>
                
            <a href=""><img id='slide-img-6' src='images/Imagen%20I.JPG' width="1200"; height="400"  class="slide" alt="" /></a>

            <a href=""><img id='slide-img-7' src='images/Imagen%20II.JPG' width="1200"; height="400" class="slide" alt="" /></a>
             
    
    <div id="slide-controls">
     <p id="slide-client" class="text"><strong>post: </strong><span></span></p>
     <p id="slide-desc" class="text"></p>
     <p id="slide-nav"></p>
    </div>
</div>
	
	<!--content featured gallery here -->
   </div>
       
       <script type="text/javascript">
           if (!window.slider) var slider = {};
           slider.data = [
                       { "id": "slide-img-1", "client": "nature beauty", "desc": "nature beauty photography" },
                       { "id": "slide-img-2", "client": "blue river", "desc": "fotografía bosque río azul" },
                       { "id": "slide-img-3", "client": "nature beauty", "desc": "fotografía rayo de luz" },
                       { "id": "slide-img-4", "client": "nature beauty", "desc": "fotografía paisaje maravilloso" },
                       { "id": "slide-img-5", "client": "nature beauty", "desc": "fotografía tarde nublada" },
                       { "id": "slide-img-6", "client": "montaña", "desc": "fotografía paisaje verde" },
                       { "id": "slide-img-7", "client": "catarata", "desc": "fotografía expectacular" }];
        </script>  
      
  </div></div><!--/header-->
 </body>
</html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="videos" style="margin-top:52%; margin-left:5%;">
                    <iframe width="95%" height="100%" src="https://www.youtube.com/embed/fsO8fPdCtxQ?rel=0&autoplay=1" frameborder="1" allowfullscreen></iframe>
                </div>
    </div>
    </form>
</body>
</html>
