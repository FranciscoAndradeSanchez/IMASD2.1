
window.onerror=function(desc,page,line,chr){
/* alert('JavaScript error occurred! \n'
  +'\nError description: \t'+desc
  +'\nPage address:      \t'+page
  +'\nLine number:       \t'+line
 );*/
}

$(function(){
 $('a').focus(function(){this.blur();});
 SI.Files.stylizeAll();
 slider.init();
// mc.init();

 $('input.text-default').each(function(){
  $(this).attr('default',$(this).val());
 }).focus(function(){
  if($(this).val()==$(this).attr('default'))
   $(this).val('');
 }).blur(function(){
  if($(this).val()=='')
   $(this).val($(this).attr('default'));
 });

 $('input.text,textarea.text').focus(function(){
  $(this).addClass('textfocus');
 }).blur(function(){
  $(this).removeClass('textfocus');
 });

 var popopenobj=0,popopenaobj=null;
 $('a.popup').click(function(){
  var pid=$(this).attr('rel').split('|')[0],_os=parseInt($(this).attr('rel').split('|')[1]);
  var pobj=$('#'+pid);
  if(!pobj.length)
   return false;
  if(typeof popopenobj=='object' && popopenobj.attr('id')!=pid){
   popopenobj.hide(50);
   $(popopenaobj).parent().removeClass(popopenobj.attr('id').split('-')[1]+'-open');
   popopenobj=null;
  }
  return false;
 });
 $('p.images img').click(function(){
  var newbg=$(this).attr('src').split('bg/bg')[1].split('-thumb')[0];
  $(document.body).css('backgroundImage','url('+_siteRoot+'images/bg/bg'+newbg+'.jpg)');
 
  $(this).parent().find('img').removeClass('on');
  $(this).addClass('on');
  return false;
 });
// $(window).load(function(){
//  $.each(css_ims,function(){(new Image()).src=_siteRoot+'css/images/'+this;});
//  $.each(css_cims,function(){
//   var css_im=this;
//   $.each(['blue','purple','pink','red','grey','green','yellow','orange'],function(){
//    (new Image()).src=_siteRoot+'css/'+this+'/'+css_im;
//   });
//  });
// }); 
 $('div.sc-large div.img:has(div.tml)').each(function(){
  $('div.tml',this).hide();
  $(this).append('<a href="#" class="tml_open">&nbsp;</a>').find('a').css({
   left:parseInt($(this).offset().left)+864,top:parseInt($(this).offset().top)+1
  }).click(function(){
   $(this).siblings('div.tml').slideToggle();
   return false;
  }).focus(function(){this.blur();}); 
 });
});

var slider={
 num:-1,
 cur:0,
 cr:[],
 al:null,
 at:10*1200,
 ar:true,
 init:function(){
  if(!slider.data || !slider.data.length)
   return false;

  var d=slider.data;
  slider.num=d.length;
  var pos=Math.floor(Math.random()*1);//slider.num);
  for(var i=0;i<slider.num;i++){
   $('#'+d[i].id).css({left:((i-pos)*1200)});
   $('#slide-nav').append('<a id="slide-link-'+i+'" href="#" onclick="slider.slide('+i+');return false;" onfocus="this.blur();">'+(i+1)+'</a>');
  }

  $('img,div#slide-controls',$('div#slide-holder')).fadeIn();
  slider.text(d[pos]);
  slider.on(pos);
  slider.cur=pos;
  window.setTimeout('slider.auto();',slider.at);
 },
 auto:function(){
  if(!slider.ar)
   return false;

  var next=slider.cur+1;
  if(next>=slider.num) next=0;
  slider.slide(next);
 },
 slide:function(pos){
  if(pos<0 || pos>=slider.num || pos==slider.cur)
   return;

  window.clearTimeout(slider.al);
  slider.al=window.setTimeout('slider.auto();',slider.at);

  var d=slider.data;
  for(var i=0;i<slider.num;i++)
   $('#'+d[i].id).stop().animate({left:((i-pos)*1200)},1200,'swing');
  
  slider.on(pos);
  slider.text(d[pos]);
  slider.cur=pos;
 },
 on:function(pos){
  $('#slide-nav a').removeClass('on');
  $('#slide-nav a#slide-link-'+pos).addClass('on');
 },
 text:function(di){
  slider.cr['a']=di.client;
  slider.cr['b']=di.desc;
  slider.ticker('#slide-client span',di.client,0,'a');
  slider.ticker('#slide-desc',di.desc,0,'b');
 },
 ticker:function(el,text,pos,unique){
  if(slider.cr[unique]!=text)
   return false;

  ctext=text.substring(0,pos)+(pos%2?'-':'_');
  $(el).html(ctext);

  if(pos==text.length)
   $(el).html(text);
  else
   window.setTimeout('slider.ticker("'+el+'","'+text+'",'+(pos+1)+',"'+unique+'");',30);
 }
};
// STYLING FILE INPUTS 1.0 | Shaun Inman <http://www.shauninman.com/> | 2007-09-07
if(!window.SI){var SI={};};
SI.Files={
 htmlClass:'SI-FILES-STYLIZED',
 fileClass:'file',
 wrapClass:'cabinet',
 
 fini:false,
 able:false,
 init:function(){
  this.fini=true;
 },
 stylize:function(elem){
  if(!this.fini){this.init();};
  if(!this.able){return;};
  
  elem.parentNode.file=elem;
  elem.parentNode.onmousemove=function(e){
   if(typeof e=='undefined') e=window.event;
   if(typeof e.pageY=='undefined' &&  typeof e.clientX=='number' && document.documentElement){
    e.pageX=e.clientX+document.documentElement.scrollLeft;
    e.pageY=e.clientY+document.documentElement.scrollTop;
   };
   var ox=oy=0;
   var elem=this;
   if(elem.offsetParent){
    ox=elem.offsetLeft;
    oy=elem.offsetTop;
    while(elem=elem.offsetParent){
     ox+=elem.offsetLeft;
     oy+=elem.offsetTop;
    };
   };
  };
 },
 stylizeAll:function(){
  if(!this.fini){this.init();};
  if(!this.able){return;};
 }
};

//var mc = { flag: 0, auto_open: true, auto_play: true, pulse_go: false, hov_html: '<div id="mcdivhover"></div>', init: function() { if (!$('#media-centre').length) return; if (mc.auto_open && !get_cookie('id_visited')) { $(window).load(function() { setTimeout(function() { mc.toggle(0); }, 500); }); } set_cookie('id_visited', 'true', 365, '/'); if (!get_cookie('id_pclicked')) { mc.pulse_go = true; mc.pulse(1); } $('#media-centre').css({ top: -419 }); $('#media-centre-holder').css({ height: 0 }).show(); $('#media-centre-tabs a:first').addClass('on'); $('#' + $('#media-centre-tabs a:first').attr('rel')).show(); $('#media-centre-tabs a').click(function() { $('#media-centre-tabs a').removeClass('on'); $(this).addClass('on'); $('div#media-centre-videos div').hide(); $('#' + $(this).attr('rel')).show(); }); $('div#media-centre-videos div p.video').hover(function() { $(this).append(mc.hov_html); var o = $(this).find('img').offset(); $('#mcdivhover').show(); }, function() { $('#mcdivhover').remove(); }).click(function() { $('div#media-centre-videos div p.video').removeClass('playing'); $(this).addClass('playing'); mc.play($(this).find('span.file').html()); if ($(this).is('.ontwerp')) $('#ontwerp-tag').fadeIn(); else $('#ontwerp-tag').fadeOut(); }); $('div#media-centre-videos div p.news').hover(function() { $(this).addClass('hover'); }, function() { $(this).removeClass('hover'); }).click(function() { location.href = $(this).find('span.url').html(); }); }, toggle: function(pulse_set) { if (mc.flag) mc.pause(); if (pulse_set && !get_cookie('id_pclicked')) { mc.pulse_go = false; set_cookie('id_pclicked', 'true', 365, '/'); } $('.mca').toggleClass('t'); $('#media-centre-holder').stop().animate({ height: mc.flag ? 0 : 419 }, 1000, 'swing'); $('#media-centre').stop().animate({ top: mc.flag ? -419 : 0 }, 1000, 'swing', function() { try { if (mc.flag && mc.auto_play) { var f = $('div#media-centre-videos div p.video:first'); $('div#media-centre-videos div p.video').removeClass('playing'); f.addClass('playing'); mc.play($(this).find('span.file').html()); if (f.is('.ontwerp')) $('#ontwerp-tag').fadeIn(); else $('#ontwerp-tag').fadeOut(); mc.auto_play = false; } } catch (e) { } }); if ($('#pusher').length) { $('.tml_open').hide(); $('#pusher div').stop().animate({ height: mc.flag ? 0 : 419 }, 1000, 'swing', function() { $('.tml_open').each(function() { $(this).show().css({ top: $(this).offset().top + ((mc.flag ? 1 : -1) * 120) }); }); }); } set_cookie('id_mc', mc.flag ? 'closed' : 'open', 30, '/'); mc.flag = !mc.flag; }, play: function(src) { if (!document.getElementById || !document.getElementById('objectmc')) return false; document.getElementById('objectmc').playVideo(_siteRoot + src); }, pause: function() { if (!document.getElementById || !document.getElementById('objectmc')) return false; document.getElementById('objectmc').pauseVideo(); }, pulse: function(s) { if (!mc.pulse_go) $('#mc-pulse').fadeOut(750); else if (s) $('#mc-pulse').fadeIn(750, function() { mc.pulse(0); }); else $('#mc-pulse').fadeOut(750, function() { mc.pulse(1); }); }, checkHash: function() { if (!document.getElementById || !document.getElementById('objectvp')) return false; var id = location.hash.replace(/[^0-9]/, ''); if (id != '') { setTimeout(function() { document.getElementById('objectvp').moveId(id); load_comments(id); }, 750); } }, live: function() { mc.toggle(0); if (mc.flag) { window.setTimeout(function() { mc.play($('p.video:first').attr('rel')); }, 1100); window.setTimeout('mc.live();', 42 * 1000); } else window.setTimeout('mc.live();', 2.5 * 60 * 1000); } }; 


