<%@ Page AutoEventWireup="true" CodeFile="PendingPatients_IssueofDrugs.aspx.cs" Inherits="Pharmacy_IssueofDrug"
    Language="C#" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
 <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!-- BOOTSTRAP CORE STYLE  -->
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
      <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
        rel="stylesheet" type="text/css" />
 
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
        rel="stylesheet" type="text/css" />
  <%--  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=grdDrugCons]').footable();
        });
    </script>
    <style type="text/css">
        label { color: #333;}
         .footable a
        {
             color: #333;
            }
        .tbldata td
        {
            background-color: White;
            font-family: Times New Roman;
            font-size: large;
            width: 488px;
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
</head>
<body>
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
                                <asp:Image ImageUrl="../img/goi.png" Height="120px" runat="server" Width="120px" ID="imgstate" />
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
            <div class="col-md-1">
            </div>
            <div class="col-md-10  col-sm-10" id="card" style="margin-top: 0">
                <div class="card-header">
                    <span class="card-title"> Issues Of Drugs  </span>
                </div>
                <div class="col-md-12 col-md-12 col-sm-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                        </div>
                        
                        <div class="form-group">                        
                            <div class="col-md-3  text-right">
                                <Label>Date</Label>
                            </div>
                            <div class="col-md-3 text-center">
                                    <asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" ontextchanged="txtDate_TextChanged"
                                                                            CssClass="form-control" ></asp:TextBox>
                            </div>
                         <%--   <div class="col-md-3  text-right">
                                <Label >Registration No :</Label>
                            </div>
                            <div class="col-md-3 text-center">
                             <asp:DropDownList ID="ddlRegNo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlRegNo_OnSelectedIndexChanged">
                                                                            <asp:ListItem>Select</asp:ListItem>
                                                                        </asp:DropDownList>
                            </div>--%>
                          
                            </div>
                       
                       
                        <div class="form-group">
                            <div class="col-md-12 text-center">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12 text-center">
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="True" 
                                                            ForeColor="Red" Visible="False"></asp:Label>                                
                            </div>
                        </div>
                        
                        <div class="form-group">
                          <div class="col-md-1 text-right"></div>
                            <div class="col-md-10 text-center">
                               <asp:GridView ID="GvPatientDtls" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                               
                                                CssClass="footable" OnPageIndexChanging="GvPatientDtls_PageIndexChanging"
                                                PageSize="10" Width="85%">
                                                 <HeaderStyle CssClass="success" />
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
                                                            <asp:Label ID="lblVisitId" runat="server" Text='<%# Bind("VisitId") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Owner Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOwner" runat="server" Text='<%# Bind("Owner_Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Animal">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAnimal" runat="server" Text='<%# Bind("AnimalTypeDesc") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Status">
                                      <ItemTemplate>
                                          <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                         
                                               <asp:Label ID="lblDcode" runat="server" Text='<%# Bind("DistCode") %>' 
                                              Visible="false"></asp:Label>
                                            
                                              
                                      </ItemTemplate>
                                  </asp:TemplateField>--%>
                                                </Columns>
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                                <EmptyDataTemplate>
                                                    No Records
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                            </div>  <div class="col-md-1 text-right"></div>
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
