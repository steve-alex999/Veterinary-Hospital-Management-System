<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Change_Pwd.aspx.cs" Inherits="UserProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head2" runat="server">
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
    <script src="BS/js/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="BS/js/bootstrap.js" type="text/javascript"></script>
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
       .labelnew
       {color: #333;}
        label
        {
            color: #333;
        }
        .footable a
        {
            color: #333;
        }  
        </style>
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
    <script type="text/javascript">
        window.history.forward(1);
        function noBack() {
            window.history.forward();
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
<body background="../images/top-rept.jpg" onkeypress="return CancelReturnKey();"
    onload="DisableBackButton(){ void (0); }">
    <script type="text/javascript">
        function validateReg() {
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate();
            }
            if (Page_IsValid) {
                var newpwd = document.getElementById('txtNpwd').value;
                if (newpwd != '') {
                    var oldpwd = document.getElementById('txtOpwd').value;
                    document.getElementById('txtOldPwdHash').value = '';
                    document.getElementById('txtNewPwdHash').value = '';
                    var keyGenrate = '<%= ViewState["keyGen"]%>';
                    var myval1 = SHA1(oldpwd);
                    var myval = SHA1(keyGenrate);
                    var myval2 = SHA1(newpwd);
                    document.getElementById('txtOpwd').value = '**********';
                    document.getElementById('txtNpwd').value = '**********';
                    document.getElementById('txtCpwd').value = '**********';
                    document.getElementById('txtOldPwdHash').value = SHA1(myval1 + myval);
                    document.getElementById('txtNewPwdHash').value = myval2;
                }
            }

        }
        function validateCustomReg(oSrc, args) {
            var psw = document.getElementById('txtNpwd').value;
            var encpsw = document.getElementById('txtNewPwdHash').value;
            if (psw == '') {
                args.IsValid = false;
            }
            else {
                if (encpsw == '') {
                    var pattern = new RegExp("^.*(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&amp;+=]).*$");
                    args.IsValid = pattern.test(psw);
                }
            }

        }
    </script>
    <form id="Form1" runat="server" autocomplete="off">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <header>
        <div class="container">
            <div class="form-group">
                <div class="col-md-12">
                    <input type="button" class="increase" value=" A+ ">
                    <input type="button" class="decrease" value=" A- " />
                    <input type="button" class="resetMe" value=" A="/>
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
                                <asp:Image ImageUrl="img/goi.png" Height="120px" runat="server" Width="120px" ID="imgstate" />
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
                              <%--  <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" RenderingMode="List"
                                    IncludeStyleBlock="false" StaticMenuStyle-CssClass="nav navbar-nav" DynamicMenuStyle-CssClass="dropdown-menu">
                                </asp:Menu>--%>
                                  <Menu:Menu ID="Menu1" runat="server"></Menu:Menu>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <div class="form-group">
    <div class="col-md-4 text-left">
     <span style="color: green;">Logged As ::</span> &nbsp; <span>
                                                <asp:Label ID="lblUsrName" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
    </div>
     <div class="col-md-4 text-center">
     <span style="color: green;">Institution Name ::</span> &nbsp; <span>
                                                <asp:Label ID="lblInsName" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
    </div>
     <div class="col-md-4 text-right">
     <span style="color: green;">Date ::</span> &nbsp; <span>
                                                <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
    </div>
    </div>
    <div class="panel-heading">
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-4  col-sm-4 text-center" id="card" style="margin-top: 0">
                <div class="card-header">
                    <span class="card-title"> Change Password </span>
                </div>
                <div class="col-md-12 col-md-12 col-sm-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                        </div>
                        
                        <div class="form-group">                        
                            <div class="col-md-6  text-right">
                                <asp:Label ID="lblfromdate" runat="server" Text="Old Password" CssClass="labelnew"></asp:Label>
                            </div>
                            <div class="col-md-6 text-center">
                             <asp:TextBox ID="txtOpwd" CssClass="form-control style_txt_entry"  runat="server"  TextMode="Password"
                                                                                                MaxLength="20"></asp:TextBox>

                                                                                                <asp:HiddenField ID="txtOldPwdHash" runat="server" />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="g1" ControlToValidate="txtOpwd"
                                                                                                runat="server" ErrorMessage="Please Enter Password" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                                                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" Enabled="True"
                                                                                                TargetControlID="RequiredFieldValidator1">
                                                                                            </asp:ValidatorCalloutExtender>
                            </div>                           
                        </div>
                        <div class="form-group">                        
                            <div class="col-md-6  text-right">
                                <asp:Label ID="Label1" runat="server" Text="New Password" CssClass="labelnew"></asp:Label>
                            </div>
                            <div class="col-md-6 text-center">
                             <asp:TextBox ID="txtNpwd" CssClass="form-control style_txt_entry"  runat="server"  TextMode="Password"
                                                                                                MaxLength="20"></asp:TextBox>
                                                                                                  <asp:HiddenField ID="txtNewPwdHash" runat="server" />
                                                                                            <asp:CustomValidator ID="CustomValidator1" runat="server" ValidationGroup="g1" Display="None"
                                                                                                ErrorMessage="Your Password Should Contain minimum 8 Characters with atleast 1 uppercase,1 lowercase, 1 numeric and 1 Special character"
                                                                                                ControlToValidate="txtNpwd" ClientValidationFunction="validateCustomReg"></asp:CustomValidator>
                                                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                                                                TargetControlID="CustomValidator1">
                                                                                            </asp:ValidatorCalloutExtender>
                            </div>                           
                        </div>
                        <div class="form-group">                        
                            <div class="col-md-6  text-right">
                                <asp:Label ID="Label2" runat="server" Text="Confirm Password" CssClass="labelnew"></asp:Label>
                            </div>
                            <div class="col-md-6 text-center">
                             <asp:TextBox ID="txtCpwd" CssClass="form-control style_txt_entry"  runat="server"  TextMode="Password"
                                                                                                MaxLength="20"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="g1" ControlToValidate="txtCpwd"
                                                                                                runat="server" ErrorMessage="Please Enter Password" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                                                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True"
                                                                                                TargetControlID="RequiredFieldValidator9">
                                                                                            </asp:ValidatorCalloutExtender>
                                                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="g1"
                                                                                                ErrorMessage="Password and Confirm Password doesnot Match" Display="None" ControlToValidate="txtCpwd"
                                                                                                ControlToCompare="txtNpwd"></asp:CompareValidator>
                                                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                                                                                TargetControlID="CompareValidator1">
                                                                                            </asp:ValidatorCalloutExtender>
                            </div>                           
                        </div>
                        
                       
                        <div class="form-group">
                            <div class="col-md-12 text-center">                            
                            <asp:Button ID="btnSubmit" runat="server"  Text="Update" OnClick="btnSubmit_Click" class="btn-success btnsubmit" ValidationGroup="g1" OnClientClick="validateReg();" />                                
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
            <div class="col-md-4">
            </div>
        </div>
    </div>
    <footer>
        <div class="container">
            <div class="row">
               <div class="col-md-12 text-center">
                      <Footer:footer ID="footer" runat="server"></Footer:footer>
                </div>
            </div>
        </div>
    </footer>
    </form>
</body>
</html>
