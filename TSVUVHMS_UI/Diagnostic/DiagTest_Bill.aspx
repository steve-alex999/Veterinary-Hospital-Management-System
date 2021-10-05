<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DiagTest_Bill.aspx.cs" Inherits="Institution_Sheet" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    
    <!-- BOOTSTRAP CORE STYLE  -->
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />
    <!-- FONT AWESOME ICONS  -->
    <link href="../BS/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLE  -->
    <link href="../BS/css/style.css" rel="stylesheet" />
    <script src="../BS/js/jquery-latest.js" type="text/javascript"></script>
    <script src="../BS/js/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../BS/js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
     <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
        rel="stylesheet" type="text/css" />
  
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=GvVisitDates]').footable();
        });
    </script>
    <style type="text/css">
        .tbldata td
        {
            background-color: White;
            font-family: Times New Roman;
            font-size: large;
            width: 488px;
        }
    </style>
    <script type="text/javascript">
        window.history.forward(1);
        function noBack() {
            window.history.forward();
        }
    
    </script>
    <script type="text/javascript" language="javascript">

        function ValidateSubmit() {

            var txtRegno = document.getElementById("txtRegno").value;
            if (txtRegno == "") // true
            {

                alert("Kindly Enter Registration No");
                return false;
            }
            return true;
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
                            <font size="5px" align="center" style="font-family: Calibri, Georgia, Serif;
                                text-shadow: 1.5px 1px white;"><b>VETERINARY HOSPITAL MANAGEMENT SYSTEM</b></font>
                            <br>
                            <br>
                            <font size="5px" align="center" style="font-family: Calibri, Georgia, Serif;
                                text-shadow: 1.5px 1px white;"><b>DEPARTMENT OF ANIMAL HUSBANDRY</b></font>
                            <br>
                            <br>
                            <font size="5px" align="center" style="font-family: Calibri, Georgia, Serif;
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
    <img src="../images/14.gif"> <span style="color: green;">Logged As ::</span> &nbsp; <span>
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
            <div class="col-md-1">
            </div>
            <div class="col-md-10  col-sm-10" id="card" style="margin-top: 0">
                <div class="card-header">
                    <span class="card-title">Diagnostic Test Bill </span>
                </div>
                <div class="col-md-12 col-md-12 col-sm-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                        </div>
                        <div class="form-group">
                            <div class="col-md-3  text-right">
                                <label for="ddldistrict">
                                    Reg No: </label>
                            </div>
                            <div class="col-md-3 text-center">
                               <asp:TextBox ID="txtRegno" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                            </div>
                            <div class="col-md-3  text-left">
                               <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" class="btn-primary"
                                                            OnClientClick="return ValidateSubmit();" />   
                            </div>
                            <div class="col-md-3 text-center">
                              
                            </div>
                        </div>
                        
                        <div class="form-group">
                         <div class="col-md-1 text-center"></div>
                            <div class="col-md-10 text-center">
                                 <asp:GridView ID="GvVisitDates" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    BorderStyle="None" BorderWidth="1px"
                                                    OnPageIndexChanging="GvVisitDates_PageIndexChanging" OnRowCommand="GvVisitDates_RowCommand"
                                                     CssClass="footable" PageSize="3" Width="374px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Visit Dates">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="TestDate" CommandName="TestDate" runat="server" ForeColor="Blue"
                                                                    Text='<%#Eval("TestDate")%>'></asp:LinkButton>
                                                                <asp:Label ID="lblTestDate" runat="server" Visible="false" Text='<%#Eval("TestDate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                        
                            </div>
                             <div class="col-md-1 text-center"></div>
                        </div>
                       
                        <div class="form-group">
                            <div class="col-md-12 text-center">
                                                         
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-12 text-center">
                            <asp:Label ID="lblNoRecordFound" runat="server" Font-Bold="True" 
                                                            ForeColor="Red" Visible="False"></asp:Label>                                
                            </div>
                        </div>
                         <div class="form-group">
                            <div class="col-md-12 text-right">
                                <%--<asp:ImageButton ID="btnImgprint" Visible="false" runat="server"  ToolTip="Print Report"
                                                                            ImageUrl="~/images/print-button.png"  />--%>
                                <asp:ImageButton ID="btnImgprint" Visible="false" runat="server" Width="4%" ToolTip="Print Report"
                                    ImageUrl="~/images/print-button.png" OnClick="btnImgprint_Click" />
                            </div>
                        </div>
                        <div class="form-group">
                          <div class="col-md-1 text-center"></div>
                            <div class="col-md-10 text-center">
                               <rsweb:ReportViewer ID="RptDiagTest" Width="100%" runat="server" SizeToReportContent="true">
                                                            </rsweb:ReportViewer>
                                
                            </div>
                             <div class="col-md-1 text-center"></div>
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
                <div class="col-md-12 text-center">
                      Designed, Developed and Hosted by National Informatics Centre, Hyderabad.
                </div>
            </div>
        </div>
    </footer>


   
    </form>
</body>
</html>
