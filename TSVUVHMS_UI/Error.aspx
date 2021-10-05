<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="ErrPage" EnableSessionState="False" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>

<%--<html>

<head>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<title>VHMS</title>
 <link href="css/style.css" rel="stylesheet" type="text/css">
    <style type="text/css">
       
    </style>
</head>

<body background="">

<div align="center" >
        <table border="0" width="982px" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
            <tr>
                <td colspan="2">
                    <img alt="" class="style63" src="images/header.PNG" />
                </td>
            </tr>
	<tr>
		<td height="25" colspan="2">
		<div align="center">
			<table border="0" width="100%" cellspacing="0" cellpadding="0">
				<tr>
					<td bgcolor="#08714A">

					<p align="center"><b>
					<a href="Default.aspx" style="color: #FFFFFF">Home</a></b></p></td>
				</tr>
			</table>
		</div>
		</td>
	</tr>

	<tr>
		<td colspan="2">
		&nbsp;</td>
	</tr>
	<tr>
		<td colspan="2">
		<div align="center">
			<table border="0" width="100%" cellspacing="0" cellpadding="0">
				
				<tr>
					<td valign="top" bgcolor="White" align="center">
                        <img src="images/pagenotfound.jpg" />
					</td>
				</tr>
				
				<tr>
					 <td style="padding-top: 10px;">
                    <Footer:footer ID="footer" runat="server"></Footer:footer>
                </td>
				</tr>
			</table>
		</div>
		</td>
	</tr>
	</table>

</div>

					</body>

</html>--%>
<title>VHMS</title>
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
<body >
    <form id="form1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <header>
        <div class="container">
            <div class="form-group">
                <div class="col-md-12">
                    <input type="button" class="increase" value=" A+ ">
                    <input type="button" class="decrease" value=" A- " />
                    <input type="button" class="resetMe" value="" a="">
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
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>
    </section>       
    
      <div class="form-group"></div>
       <div class="form-group"></div>
        <div class="form-group"></div>
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
                    <span class="card-title"><img alt="" src="images/44.gif" /><p align="center"><b>
					<a href="VhmsHome.aspx" style="color: #FFFFFF">Home</a></b></p><img alt="" src="images/44.gif" /></span>
                </div>
                <div class="col-md-12 col-md-12 col-sm-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                           <asp:Label ID="statecd" runat="server" Text="Label" Visible="false"></asp:Label>
                            <asp:Label ID="statename" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="statec" runat="server" Visible="false"></asp:Label>
                            
                        </div>
                     
                      
                        <div class="form-group">
                            <div class="col-md-12  text-center">
                                
                            </div>
                          
                        </div>
                         
                      
                        <div class="form-group">
                            <div class="col-md-12  text-center">
                               <p>
          
            Click Here for 
                                   <asp:LinkButton
                ID="LinkButton1" runat="server" CssClass="btn-success" onclick="LinkButton1_Click">Home</asp:LinkButton></p>
                            </div>
                          
                        </div>
                        <div class="form-group">
                            <div class="col-md-12 text-center">
                            
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
          <div class="form-group"></div>
     <div class="form-group"></div>
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