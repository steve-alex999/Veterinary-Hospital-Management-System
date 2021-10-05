<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrugsAvailability.aspx.cs"
    Inherits="Pharmacy_DrugsAvailability" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../scripts/JQuery-min.js.js" type="text/javascript"></script>
    <script src="../scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="../scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
  
    <link href="../BS/css/footable.min.css" rel="stylesheet" type="text/css" />
  
    <script src="../BS/js/footable.min.js" type="text/javascript"></script>
    <script src="../scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Bs/js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <link href="../BS/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />
    <link href="../BS/css/style.css" rel="stylesheet" />
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tbldata td
        {
            background-color: #eee;
            font-family: Times New Roman;
            font-size: large;
            }
      
      
        label { color: #333;}
         .footable a
        {
             color: #333;
            }
        
        .style65
        {
            width: 92px;
        }
      
      
        </style>
    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });
    </script>
</head>
<body>
 

    <form id="form1" runat="server">
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
                                <menu:menu ID="Menu" runat="server"></menu:menu>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
 <div class="row">
        <div class="col-md-4 text-left">
            <img src="../images/14.gif">
              <label >
                                     Logged As :: </label><asp:Label ID="lblUsrName" runat="server" Font-Bold="true" ForeColor="#ab7d44"
                Text=""></asp:Label>
        </div>
        <div class="col-md-4 text-right">
              <label >Institution Name : &nbsp;</label>
            <asp:Label ID="lblInsName" runat="server" Font-Bold="True" ForeColor="#AB7D44"></asp:Label>
        </div>
        <div class="col-md-4 text-right">
            <span style="color: green;">Date ::</span> &nbsp; <span>
                <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
        </div>
    </div>
    <div class="panel-heading">
        <div class="row">
            <div class="col-md-1">
            </div>
            <div class="col-md-10" id="card" style="margin-top: 0">
                <div class="card-header">
                    <span class="card-title"> Drugs Availability</span></div>
                <div class="col-md-12">
                    
                     <%-- <div class="col-md-10 col-sm-10 text-center">
                      <div class="col-md-10 col-sm-10 text-center">--%>
                        <div class="form-group">
                           
                        </div>
                       <div class="row">
                            <div class="col-md-3 col-md-offset-3  text-right">
                                <label >
                                     Select Drug: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:DropDownCheckBoxes ID="ddl_Drug"  runat="server" AddJQueryReference="True" CssClass="form-control"
                                                UseButtons="True" UseSelectAllNode="True" 
                                                OnSelectedIndexChanged="ddl_Drug_SelectedIndexChanged" 
                                                style="top: 0px; left: 0px">
                                                <Style SelectBoxWidth="200" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="200" />
                                                <Texts  SelectBoxCaption="Select Drugs" />
                                            
                                            </asp:DropDownCheckBoxes>
                            </div>
                           
                        </div>
                        <div class="form-group">
                            <div class="col-md-1   text-right">
                                <label for="ddlfinyear">
                                    Sort: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-5 text-center">
  <asp:RadioButtonList ID="rblSortvalue" runat="server" AutoPostBack="true" CssClass="form-control"
                                                RepeatDirection="Horizontal">
                                                                                                           <asp:ListItem Text="ExpiryDate" Value="E" Selected="True"></asp:ListItem>
                                                                                                           <asp:ListItem Text="Quantity in Days" Value="Q"></asp:ListItem>
                                                                                                            <asp:ListItem Text="Quantity in Store" Value="B"></asp:ListItem>
                                                                                                       </asp:RadioButtonList>
                            </div>
                             <div class="col-md-1   text-right">
                                <label for="ddlfinyear">
                                    Order: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-5 text-center">
                            <asp:RadioButtonList ID="rblSortorder" 
                                                runat="server" AutoPostBack="true" RepeatDirection="Horizontal" CssClass="form-control">
                                                                                                           <asp:ListItem Text="Ascending" Value="A"  Selected="True"></asp:ListItem>
                                                                                                           <asp:ListItem Text="Descending" Value="D"></asp:ListItem>
                                                                                                            
                                                                                                       </asp:RadioButtonList>
                            </div>
                           
                        </div>
                    <div class="form-group">
                            <div class="col-md-4 col-md-offset-4  text-center">
                             <asp:Button runat="server" ID="btn_Submit" Text="Submit" OnClick="btn_Submit_Click"
                                    class="btn btn-success" />
                                      
                                   
                            </div></div>
                        
               
               <%-- </div></div>--%>
                 <div class="form-group">
                            <div class="col-md-12 text-right">
                               
                                <asp:ImageButton ID="btnImgprint" Visible="false" runat="server" Width="4%" ToolTip="Print Report"
                                    ImageUrl="~/images/print-button.png" OnClick="btnImgprint_Click" />
                            </div>
                        </div>
                   <div class="row">
                            <div class="col-md-12">
                            <div class="col-md-2"></div>
                             
                             <div class="col-md-8 text-center">

                                             
                                                  <rsweb:ReportViewer ID="RptDrugAvailability" Width="100%" runat="server">
                                </rsweb:ReportViewer>
                           
                          </div>
                             <div class="col-md-2"></div>
                            </div>
                        </div> 
            </div>
             
        </div>
    </div></div>
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
