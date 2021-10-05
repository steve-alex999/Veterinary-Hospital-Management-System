<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Register TagPrefix="Menu" TagName="Menu" Src="~/DefaultMenu.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<head>

<title>VHMS</title>
<%-- <link href="styles/main.css" rel="Stylesheet" type="text/css" media="all" />
<link href="styles/style.css" rel="Stylesheet" type="text/css" />
<script src="scripts/jquery.min.js" type="text/javascript"></script>--%>
<script src="scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
<script src="scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
<link href="css/ValidationEngine.css" rel="stylesheet" type="text/css" />
<script src="scripts/sha1.js" type="text/javascript"></script>
 <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!-- BOOTSTRAP CORE STYLE  -->
    <link href="BS/css/bootstrap.css" rel="stylesheet" />
    <!-- FONT AWESOME ICONS  -->
    <link href="BS/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLE  -->
    <link href="BS/css/style.css" rel="stylesheet" />
    <script src="BS/js/jquery-latest.js" type="text/javascript"></script>
    <script src="Bs/js/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="Bs/js/bootstrap.js" type="text/javascript"></script>
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function myFunction1() {
            document.getElementById("container").style.backgroundColor = "#f5bbf3";
        }


        function myFunction2() {
            document.getElementById("container").style.backgroundColor = "#fff";
        }

        function myFunction3() {
            document.getElementById("container").style.backgroundColor = "rgb(59, 114, 183)";
        }
    </script>
    <script type="text/javascript">
        function font() {
            document.getElementById("container").style.fontSize = "large";
        }


        function font1() {
            document.getElementById("container").style.fontSize = "1em";
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var originalSize = $('div').css('font-size');
            // reset
            $(".resetMe").click(function () {
                $('div').css('font-size', originalSize);

            });

            // Increase Font Size
            $(".increase").click(function () {
                var currentSize = $('div').css('font-size');
                var currentSize = parseFloat(currentSize) * 1.2;
                $('div').css('font-size', currentSize);

                return false;
            });

            // Decrease Font Size
            $(".decrease").click(function () {
                var currentFontSize = $('div').css('font-size');
                var currentSize = $('div').css('font-size');
                var currentSize = parseFloat(currentSize) * 0.8;
                $('div').css('font-size', currentSize);

                return false;
            });
        });
    </script>
    <script type="text/javascript">
<input type="button" onClic="changebackColor">

function changebackColor(){
document.body.style.backgroundColor = "black";
document.getElementByID("divID").style.backgroundColor = "black";      
window.setTimeout("yourFunction()",10000);
}
    </script>
   <style type="text/css">
#profile_tab
{
 border-collapse: collapse;
}

#profile_tab td
{
 border:1px dotted #666666
}

#example
{
 border-collapse: collapse;
}

#example td
{
 border:1px dotted #666666
}

table
{
 color:#000;
           height: 32px;
       }
       </style>
 <script type="text/javascript">
     window.history.forward(1);
     function noBack() {
         window.history.forward();
     }
</script>

    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });

        function validateReg() {
            var userName = document.getElementById('txtUname').value;
            var pwd = document.getElementById('txtPwd').value;

            if (userName == "") {

                return false;
            }

            if (pwd == "") {

                return false;
            }
            var keyGenrate = '<%=ViewState["KeyGenerator"]%>';
            var myval = SHA1(keyGenrate);
            document.getElementById('txtPwdHash').value = '';
            var myval1 = SHA1(document.getElementById('txtPwd').value.toString());
            document.getElementById('txtPwd').value = '******';
            document.getElementById('txtPwdHash').value = SHA1(myval1 + myval);
        }
           
     
    </script>
    <script type="text/javascript" language="javascript">

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
</script>
</head>

<body background="">

    <form id="form1" runat="server" autocomplete="off">

     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <header>
        <div class="container">
            <div class="form-group">
                <div class="col-md-12">
                    <input type="button" class="increase" value=" A+ ">
                    <input type="button" class="decrease" value=" A- " />
                    <input type="button" class="resetMe" value=" A=">
                    <button onclick="document.body.style.backgroundColor = '#dff0d8';">
                        T</button>
                    <button onclick="document.body.style.backgroundColor = 'rgba(103, 58, 183, 0.28)';">
                        T</button>
                    <button onclick="document.body.style.backgroundColor = '#fff';">
                        T</button>
                </div>
            </div>
        </div>
    </header>
    <div class="navbar navbar-inverse set-radius-zero">
        <div class="wrap-header">
            <div class="main-header">
                <div class="zerogrid">
                    <div class="row">
                        <div class="col-md-2 text-center">
                            <span>
                                <asp:Image ImageUrl="~/img/goi.png" Height="120px" runat="server" Width="120px" ID="imgstate" />
                            </span>
                        </div>
                        <div class="col-md-8 text-center" style="margin-top: 10px;" align="middle">
                            <font size="5px" align="center" style="font-family: Bookman OldStyle, Georgia, Serif;
                                text-shadow: 1.5px 1px white;"><b>VETERINARY HOSPITAL MANAGEMENT SYSTEM</b></font>
                            <br>
                            <br>
                            <font size="5px" align="center" style="font-family: Times New Roman, Georgia, Serif;
                                text-shadow: 1.5px 1px white;"><b>DEPARTMENT OF ANIMAL HUSBANDRY</b></font>
                            <br>
                            <br>
                            <font size="5px" align="center" style="font-family: Times New Roman, Georgia, Serif;
                                text-shadow: 1.5px 1px white;"><b>
                                    <asp:Label ID="lblstatename" runat="server" Text="Label"></asp:Label></b></font>
                        </div>
                        <div class="col-md-2 text-center">
                            <span>
                                <asp:Image ID="Image1" src="img/digital.png" Height="120px" runat="server" Width="120px" />
                            </span>
                        </div>
                        <div class="left-div">
                            <div class="user-settings-wrapper">
                                <ul class="nav">
                                    <li class="dropdown">
                                        <div class="dropdown-menu dropdown-settings">
                                            <h5>
                                                <strong>Personal Bio : </strong>
                                            </h5>
                                            Anim pariatur cliche reprehen derit.
                                            <hr />
                                            <a href="#" class="btn btn-info btn-sm">Full Profile</a>&nbsp; <a href="#" class="btn btn-danger btn-sm">
                                                Logout</a>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <section class="menu-section">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="navbar-collapse collapse ">
                        <div class="container-fluid">
                          
                            <div class="collapse navbar-collapse" id="myNavbar">
                                 <Menu:Menu ID="Menu" runat="server"></Menu:Menu>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>
    </section>       
   
    <div class="row">
            <div class="col-md-3">
                   
            </div>
             <div class="col-md-5 text-center">

       <div class="panel-heading">
        <div class="row">
            <div class="col-md-1">
            </div>
            <div class="col-md-10  col-sm-10" id="card" style="margin-top: 0">
                <div class="card-header">
                    <span class="card-title"><img alt="" src="images/44.gif" />Login<img alt="" src="images/44.gif" /></span>
                </div>
                <div class="col-md-12 col-md-12 col-sm-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                        </div>
                     
                      
                        <div class="form-group">
                            <div class="col-md-12  text-center">
                                 <asp:TextBox ID="txtUname" runat="server" placeholder="User Name"  autocompelte="off"
                CssClass="validate[required] form-control" MaxLength="255" Autocomplete="off"></asp:TextBox>
                            </div>
                          
                        </div>
                         
                      
                        <div class="form-group">
                            <div class="col-md-12  text-center">
                               <asp:TextBox ID="txtPwd" placeholder="Password" TextMode="Password" CssClass="validate[required] form-control" autocompelte="off"
                runat="server" MaxLength="50"></asp:TextBox> <asp:HiddenField ID="txtPwdHash"  runat="server" />
                            </div>
                          
                        </div>
                        <div class="form-group">
                        <div class="col-md-12 text-center">
                         <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red" Text=""></asp:Label>
                            <asp:TextBox ID="txtimgcode" autocomplete="off" runat="server"  CssClass="validate[required] form-control" placeholder="Enter code(Case Sensitive) shown in the image"></asp:TextBox>
                            <br />
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Cimage.aspx"  Height="50PX"/>
                        </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12 text-center">
                             <asp:Button ID="btnLogin" runat="server" Text="Login"   OnClientClick="return validateReg();"
                onclick="btnLogin_Click" CssClass="form-control btn-primary" />
                            </div>
                        </div>
                       
                    
                        <div class="row">
                            <div class="col-md-12 col-md-12 col-sm-12 table-responsive">
                                <div class="col-md-1">
                                </div>
                                <div class="col-md-1">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-1">
                    </div>
                    <br />
                </div>
            </div>
            <div class="col-md-1">
            </div>
        </div>
    </div>
           
            </div>
             <div class="col-md-4">
         
           
            </div>
       </div>         
   
      <div class="form-group"></div>
       <div class="form-group"></div>
    <footer>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                      Designed, Developed and Hosted by National Informatics Centre, Hyderabad.
                </div>
            </div>
        </div>
    </footer>

					</form>

					</body>

</html>
