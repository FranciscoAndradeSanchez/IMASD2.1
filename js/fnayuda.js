// JScript File

function MostrarAyuda(strId){
    tempid=document.getElementById(strId);
    if(tempid.style.visibility=='visible')
        tempid.style.visibility='hidden';
    else
        tempid.style.visibility='visible';
}