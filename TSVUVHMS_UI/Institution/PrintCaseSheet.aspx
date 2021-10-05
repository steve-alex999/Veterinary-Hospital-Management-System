<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintCaseSheet.aspx.cs" Inherits="Patient"
    EnableEventValidation="false" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Namespace="Microsoft.Reporting.WebForms" TagPrefix="WebForms" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   
      <meta http-equiv="Content-Language" content="en-us"/>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252"/>
    <title>Vhms</title>
  
   <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!-- BOOTSTRAP CORE STYLE  -->
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />
    <!-- FONT AWESOME ICONS  -->
    <link href="../BS/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLE  -->
    <link href="../BS/css/style.css" rel="stylesheet" />
    <script src="../BS/js/jquery-latest.js" type="text/javascript"></script>
    <script src="../Bs/js/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../Bs/js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="../css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/bootstrap-multiselect.js" type="text/javascript"></script>
    
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
    </script>
    <style type="text/css">
        .fld
        {
            border: solid 1px #eeeeee;
            padding: 6px;
        }
        
        .highlight
        {
            text-decoration: none;
            color: black;
            background: yellow;
        }
    </style>
    <script type="text/javascript">
        function noBack() {
            window.history.forward()
        }
        noBack();
        window.onload = noBack;
        window.onpageshow = function (evt) {
            if (evt.persisted) noBack()
        }
        window.onunload = function () { void (0) }
    </script>
    <script type="text/javascript">
        function CancelReturnKey() {
            if (window.event.keyCode == 13)
                return false;
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
     <script type="text/javascript">
         $(document).ready(function () {
             $('.style_txt_entry').datepicker({
                 dateFormat: 'dd-mm-yy',
                 maxDate: new Date(),
                 showOn: "button",
                 buttonImage: "Images/calendar.jpg",
                 buttonImageOnly: true,
                 buttonText: "Select date",
                 changeMonth: true,
                 changeYear: true,
                 yearRange: "-10:+0"
             });
         });

           
    </script>
    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });
    </script>
    <style type="text/css">
        #profile_tab
        {
            border-collapse: collapse;
        }
        
        #profile_tab td
        {
            border: 1px dotted #666666;
        }
        
        #example
        {
            border-collapse: collapse;
        }
        
        #example td
        {
            border: 1px dotted #666666;
        }
        
        
        .tbldata td
        {
            padding: 1px;
            border: solid 1px #c1c1c1;
            color: black;
            background: lightgrey;
            font-size: 1.0em;
            height: 35px;
        }
    </style>
</head>
<body background="../images/top-rept.jpg" onkeypress="return CancelReturnKey();"
    onload="DisableBackButton(){ void (0); }">
    

<%--<body>
    <div class="wrapper row1">
        <header id="header" class="full_width clear">
<img alt="" class="style64" src="../images/header.png" width="980" height="87"/>

<!-- content -->
<div class="wrapper row3">

 <menu:menu ID="menu" runat="server" />
<div id="container">

<div id="sidebar_1" class="sidebar one_quarter first">

<div align="center" style="widt:50%">
  
    <table style="display:none";>
    <tr>
    <td>
    </td>
    </tr>
    </table>

   </div>

</div>

<div class="three_quarter">
    <form id="form1" runat="server">
    <div id="embedid" runat="server">
    </div>
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       
  
    <div align="center">
      <table align="center" width="80%" >
                                     <tr>
                            <td align="right">
                                <asp:ImageButton ID="btnImgprint" runat="server" Width="3%" ToolTip="Print Report"
                                    ImageUrl="~/images/print-button.png" OnClick="btnImgprint_Click" />
                            </td>
                        </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblNoRecordFound" runat="server" Font-Bold="True" 
                                                ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td  >
                                            <rsweb:ReportViewer ID="RptCasesheet" runat="server" Width="100%" SizeToReportContent="true"></rsweb:ReportViewer>
                                             
                                            &nbsp;</td>

                                    </tr>
                                   
                                    <tr align="center">
                                        <td style="background-color"  >
    
   
                                            &nbsp;</td>

</tr>
</table>
    </div>
   
    </form>
    </div>

<div class="clear"></div>



<div class="wrapper row4">

<div id="copyright" class="clear">
 <tr>
                <td style="padding-top: 10px;">
                    <Footer:footer ID="footer" runat="server"></Footer:footer>
                </td>
            </tr>
</div>


</div>
</div>
</div>
</body>--%>

<form id="Form1" runat="server" autocomplete="off">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
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
                                <asp:Image ID="Image1" src="../img/digital.png" Height="120px" runat="server" Width="120px" />
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
    <div class="form-group">
        <div class="col-md-12 text-right">
            <span style="color: green;">Date ::</span> &nbsp; <span>
                <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
        </div>
    </div>
    <div class="panel-heading">
        <div class="row">
            <div class="col-md-1">
            </div>
            <div class="col-md-10  col-sm-10" id="card" style="margin-top: 0">
                <div class="card-header">
                    <span class="card-title">Case Sheet</span>
                </div>
                <div class="col-md-12 col-md-12 col-sm-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                        </div>
                        
                     <%--   <div class="form-group">
                            <div class="col-md-12 text-center">
                                <asp:Label ID="lblNoRecordFound" runat="server" Font-Bold="True" ForeColor="Red"
                                    Visible="False"></asp:Label>
                            </div>
                        </div>--%>
                        <div class="form-group">
                            <div class="col-md-12 text-right">
                                <asp:ImageButton ID="btnImgprint" Visible="false" runat="server" Width="4%" ToolTip="Print Report"
                                    ImageUrl="~/images/print-button.png" OnClick="btnImgprint_Click" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-1">
                            </div>
                            <div class="col-md-10 text-center">
                                <rsweb:ReportViewer ID="RptCasesheet"   Width="100%" runat="server" SizeToReportContent="true"
                                    ShowPrintButton="true">
                                </rsweb:ReportViewer>
                            </div>
                            <div class="col-md-1">
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
