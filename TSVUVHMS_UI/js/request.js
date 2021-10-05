


$(document).ready(function()
{


$("#agreed1").change(function()
{
var val =  ($(this).val()).trim();

if(val==1)
{
document.getElementById("agreed_tab_no").style.display="none";
document.getElementById("agreed_tab_yes").style.display="block";
}
else
{
document.getElementById("agreed_tab_yes").style.display="block";
}

});


$("#agreed0").change(function()
{
var val =  ($(this).val()).trim();

if(val==0)
{
document.getElementById("agreed_tab_yes").style.display="none";
document.getElementById("agreed_tab_no").style.display="block";
}
else
{
document.getElementById("agreed_tab_no").style.display="block";
}

});

});