<%@ Page Language="C#" AutoEventWireup="true" CodeFile="P_Rpt_DrugsAvailability.aspx.cs"
    Inherits="P_Rpt_DrugsAvailability" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="Menu" TagName="Menu" Src="~/DefaultMenu.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
   
    <script src="scripts/jquery-ui.js" type="text/javascript"></script>
    
  <link href="css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="scripts/bootstrap-multiselect.js" type="text/javascript"></script>
   
       <script type="text/javascript">
           $(function () {          
                          $('#ddl_Drug').multiselect({
                   includeSelectAllOption: true
                              });             
           });
</script>

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
        label
        {
            color: #333;
        }
        .footable a
        {
            color: #333;
        }  
        </style>
</head>
<body>
   <form id="form1" runat="server">
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
                               <%-- <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" RenderingMode="List"
                                    IncludeStyleBlock="false" StaticMenuStyle-CssClass="nav navbar-nav" DynamicMenuStyle-CssClass="dropdown-menu">
                                </asp:Menu>--%>
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
                    <span class="card-title">Drugs Availability  </span>
                </div>
                <div class="col-md-12 col-md-12 col-sm-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                        </div>
                        <div class="row">
                            <div class="col-md-2  text-right">
                                <label for="ddldistrict">
                                    District</label>
                            </div>
                            <div class="col-md-2 text-center">
                                <asp:DropDownList ID="ddlDist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDist_OnSelectedIndexChanged"   CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2  text-right">
                                <label for="ddlInst">
                                    Institution :</label>
                            </div>
                            <div class="col-md-2 text-center">
                                <asp:DropDownList ID="ddlInst" runat="server" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlIns_OnSelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                             <div class="col-md-2  text-right">
                               
                                <label for="ddl_Drug">
                                    Select Drug:</label>
                            </div>
                            <div class="col-md-2 text-center">
                             
                                    <asp:ListBox  ID="ddl_Drug"  runat="server" SelectionMode="Multiple" AutoPostBack="true" OnSelectedIndexChanged="ddl_Drug_SelectedIndexChanged"   CssClass="form-control" >  </asp:ListBox> 
                            </div>
                        </div>
                        <div class="form-group">
                           
                             <div class="col-md-3  text-right"></div>
                              <div class="col-md-3 text-center"></div>
                            
                        </div>
                          <div class="form-group">
                            <div class="col-md-1  text-right">
                                
                                 <label for="rblSortvalue">
                                    Sort:</label>
                            </div>
                            <div class="col-md-6 text-left">
                                <asp:RadioButtonList ID="rblSortvalue" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" CssClass="form-control"
                                   >
                                    <asp:ListItem Text="ExpiryDate" Value="E" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Quantity in Days" Value="Q"></asp:ListItem>
                                    <asp:ListItem Text="Quantity in Store" Value="B"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-md-1  text-right">                                
                                 <label for="rblSortorder">
                                    Order:</label>
                            </div>
                            <div class="col-md-4 text-center">
                               <asp:RadioButtonList ID="rblSortorder" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" CssClass="form-control">
                                    <asp:ListItem Text="Ascending" Value="A" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Descending" Value="D"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12 text-center">
                                <asp:Label ID="lblNoRecordFound" runat="server" Font-Bold="True" ForeColor="Red"
                                    Visible="False"></asp:Label>
                            </div>
                        </div>
                       
                        <div class="form-group">
                            <div class="col-md-12 text-center">
                                <asp:Button ID="btnSubmit" runat="server" Height="30px" 
                                    OnClick="btn_Submit_Click" class="btn-primary"
                                    Text="Submit"  />
                            </div>
                        </div>
                     
                         <div class="form-group">
                            <div class="col-md-12 text-right">
                             
                                <asp:ImageButton ID="btnImgprint" Visible="false" runat="server" Width="4%" ToolTip="Print Report"
                                    ImageUrl="~/images/print-button.png" OnClick="btnImgprint_Click" />
                            </div>
                        </div>
                        <div class="form-group">
                        <div class="col-md-2"></div>
                            <div class="col-md-10 text-center">                               
                                <rsweb:ReportViewer ID="RptDrugAvailability" Width="100%" runat="server" SizeToReportContent="true"
                                    ShowPrintButton="true">
                                </rsweb:ReportViewer>
                            </div><div class="col-md-2"></div>
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
