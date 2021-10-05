<%@ Page AutoEventWireup="true" CodeFile="PendingDiagnostic_Test.aspx.cs" Inherits="PendingDiagnostic_Test"
    Language="C#" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Vhms</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <script src="../scripts/JQuery-min.js.js" type="text/javascript"></script>
    <script src="../scripts/jquery-ui.js" type="text/javascript"></script>     
    <link href="../BS/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <!-- BOOTSTRAP CORE STYLE  -->
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />
    <!-- FONT AWESOME ICONS  -->
    <link href="../BS/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLE  -->
    <link href="../BS/css/style.css" rel="stylesheet" />
 
    <script src="../BS/js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
     <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
        rel="stylesheet" type="text/css" />
  
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=GvPatientDtls]').footable();
        });
    </script>
  <script type="text/javascript">


      $(function () {
          $("#txtDate").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd-mm-yy',
              buttonImageOnly: true,
              buttonText: "Select date",
              changeMonth: true,
              changeYear: true,
              yearRange: "-10:+0"
          });
      });
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
    <style type="text/css">
        .tbldata td
        {
            background-color: White;
            font-family: Times New Roman;
            font-size: large;
        }
        
        input[type=text], input[type=password]
        {
            margin: 5px;
            padding: 0 10px;
            height: 30px;
            color: #404040;
            background: white;
            border: 1px solid;
            border-color: #c4c4c4 #d1d1d1 #d4d4d4;
            border-radius: 2px;
            -moz-outline-radius: 3px;
            -webkit-box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.12);
            box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.12);
        }
        
        input
        {
            font-family: 'Lucida Grande' , Tahoma, Verdana, sans-serif;
            font-size: 12px;
        }
    </style>
    <script type="text/javascript">
        window.history.forward(1);
        function noBack() {
            window.history.forward();
        }
        function Confirm(link) {

            if (confirm("Are you sure to delete the selected district?")) {

                return true;
            }
            else
                return false;


        }
    </script>

    <script type="text/javascript" language="javascript">
        String.prototype.startsWith = function (str) {
            return (this.indexOf(str) === 0);
        }
        function ChkValidChar() {

            var txtbx = document.getElementById("txtDistCode").value;

            if (txtbx.startsWith("0")) // true
            {
                document.getElementById("txtDistCode").value = "";
                alert("you can not insert zero as first character");
            }
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
                             
                                  <Menu:Menu ID="menu" runat="server"></Menu:Menu>
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
                    <span class="card-title">Diagnostic Tests and Procedures </span>
                </div>
                <div class="col-md-12 col-md-12 col-sm-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                        </div>
                          <div class="form-group">
                         <div class="col-md-2  text-right"><label>Date:</label></div>
                         <div class="col-md-3 text-left">  <asp:TextBox ID="txtDate" 
                                        runat="server" CssClass="form-control style_txt_entry" ontextchanged="txtDate_TextChanged" AutoPostBack="true"></asp:TextBox></div>
                         <div class="col-md-1  text-center"><label>(OR)</label></div>
                          <div class="col-md-2  text-right"><label> Registration No :</label></div>
                         <div class="col-md-3 text-left"> <asp:TextBox ID="txt_FregNo" runat="server" MaxLength="15" ontextchanged="txtDate_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                                        FilterType="Numbers" TargetControlID="txt_FregNo">
                                    </ajax:FilteredTextBoxExtender></div>
                         <div class="col-md-1  text-center"><asp:Button ID="btnSearch" runat="server" Height="30px" Text="Search" OnClick="btnSearch_Click" class="btn-primary" /></div>
                        </div>
                    <%--    <div class="form-group">
                         <div class="col-md-4  text-right">
                                Date:<asp:TextBox ID="txtDate" 
                                        runat="server" CssClass="form-control style_txt_entry" ontextchanged="txtDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    (OR)
                            </div>
                            <div class="col-md-4 text-left">
                              Registration Number :
                                    <asp:TextBox ID="txt_FregNo" runat="server" MaxLength="15" ontextchanged="txtDate_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                                        FilterType="Numbers" TargetControlID="txt_FregNo">
                                    </ajax:FilteredTextBoxExtender>
                            </div>     
                            <div class="col-md-4 text-left">
                                        <asp:Button ID="btnSearch" runat="server" Height="30px" Text="Search" OnClick="btnSearch_Click" class="btn-success" /> 
                            </div> 
                                                                          
                        </div>--%>
                        
                       
                        <div class="form-group">
                            <div class="col-md-12 text-center">
                                <asp:GridView ID="GvPatientDtls" runat="server" AllowPaging="True" AutoGenerateColumns="False"                                        
                                        CellPadding="3" CellSpacing="2" CssClass="footable"
                                         PageSize="5" Width="874px" OnPageIndexChanging="GvPatientDtls_PageIndexChanging">
                                        <Columns>
                                        <asp:TemplateField HeaderText="SI NO" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reg No">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkgetregno" runat="server" ForeColor="Blue" OnClick="lnkRegNo_Click"
                                                    Text='<%#Eval("RegistrationNo")%>'></asp:LinkButton>
                                                <asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("RegistrationNo") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="Owner Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOwner" runat="server" Text='<%# Bind("Owner_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Mobile No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMbNo" runat="server" Text='<%# Bind("Owner_MobileNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Animal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAnimal" runat="server" Text='<%# Bind("AnimalTypeDesc") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                    </Columns>
                                    <EmptyDataRowStyle HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        No Records
                                    </EmptyDataTemplate>
                                    </asp:GridView>
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
                 <div class="col-md-12 text-center">
                      <Footer:footer ID="footer" runat="server"></Footer:footer>
                </div>
            </div>
        </div>
    </footer>

    </form>
</body>
</html>
