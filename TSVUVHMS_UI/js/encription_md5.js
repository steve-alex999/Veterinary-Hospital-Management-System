
function encripte(fieldobj)
{
    
if(fieldobj.value=="")
{
return false;
}
var g=fieldobj.value;

//checkForm(g);




if(fieldobj.value!="")
{
var ck=fieldobj.value;

if(ck.length>6 )
{

var p1 =  GM(fieldobj.value);
fieldobj.value= p1;
return true;

}
else
{
fieldobj.value="";
 return true;
}

}		  
		   
       
}


function checkForm(f)
{
if(f == "") {
alert("Error: Username cannot be blank!");
//form.username.focus();
return false;
}
re = /^\w+$/;
if(!re.test(f)) {
alert("Error: Username must contain only letters, numbers and underscores!");
// form.username.focus();
return false;
}

if(form.pwd1.value != "" && form.pwd1.value == form.pwd2.value) {
if(f.length < 6) {
alert("Error: Password must contain at least six characters!");
// form.pwd1.focus();
return false;
}
if(f == form.username.value) {
alert("Error: Password must be different from Username!");
// form.pwd1.focus();
return false;
}
re = /[0-9]/;
if(!re.test(f)) {
alert("Error: password must contain at least one number (0-9)!");
// form.pwd1.focus();
return false;
}
re = /[a-z]/;
if(!re.test(f)) {
alert("Error: password must contain at least one lowercase letter (a-z)!");
//form.pwd1.focus();
return false;
}
re = /[A-Z]/;
if(!re.test(f)) {
alert("Error: password must contain at least one uppercase letter (A-Z)!");
//form.pwd1.focus();
return false;
}
} else {
alert("Error: Please check that you've entered and confirmed your password!");
// form.pwd1.focus();
return false;
}

alert("You entered a valid password: " + f);
return true;
}



function encripte1(fieldobj,salt)
{


       var p1 =  GM(fieldobj.value);
       p1=p1+salt;
       p1 =GM(p1);
       fieldobj.value= p1;
       
       return true;
}

function encripte2(fieldobj,salt)
{

var f=document.getElementById("password").value;

       var p1 =  GM(f);
       p1=p1+salt;
       p1 =GM(p1);
       document.getElementById("password").value= p1;
       
       return true;
}