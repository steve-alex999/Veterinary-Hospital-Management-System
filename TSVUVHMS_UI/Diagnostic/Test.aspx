<%@ Page AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Diag_Test" Language="C#" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
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
            $('[id*=GvTestDtls]').footable();
        });
    </script>
    <script type="text/javascript">

        function preventMultipleSubmissions() {
            $('#<%=btn_Save.ClientID %>').prop('disabled', true);
        }

        window.onbeforeunload = preventMultipleSubmissions;
 
                                                </script>
    <style type="text/css">
        .tbldata td
        {
            background-color: white;
            font-family: Times New Roman;
            font-size: large;
        }
        .block
        {
            height: 150px;
            width: 200px;
            border: 1px solid aliceblue;
            overflow-y: scroll;
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
                            <font size="5px" align="center" style="font-family: Calibri, Georgia, Serif; text-shadow: 1.5px 1px white;"><b>VETERINARY HOSPITAL MANAGEMENT SYSTEM</b></font>
                            <br>
                            <br>
                            <font size="5px" align="center" style="font-family: Calibri, Georgia, Serif; text-shadow: 1.5px 1px white;"><b>DEPARTMENT OF ANIMAL HUSBANDRY</b></font>
                            <br>
                            <br>
                            <font size="5px" align="center" style="font-family: Calibri, Georgia, Serif; text-shadow: 1.5px 1px white;"><b>
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
                                <menu:menu ID="Menu1" runat="server"></menu:menu>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="form-group">
        <div class="col-md-4 text-left">
            <img src="../images/14.gif">
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
                    <span class="card-title">Test Parameters</span>
                </div>
                <div class="col-md-12 col-md-12 col-sm-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                        </div>
                        <div class="form-group">
                            <div class="col-md-1  text-right">
                                <label >
                                    Reg No:
                                </label>
                            </div>
                            <div class="col-md-2 text-center">
                                <label>
                                    <asp:Label ID="lblRegistrationNo" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                            <div class="col-md-1  text-right">
                                <label >
                                    Owner Name:
                                </label>
                            </div>
                            <div class="col-md-2 text-center">
                                <label>
                                    <asp:Label ID="lblOwnerNm" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                            <div class="col-md-1  text-right">
                                <label >
                                    Animal:
                                </label>
                            </div>
                            <div class="col-md-2 text-center">
                                <label>
                                    <asp:Label ID="lblAnimal" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                            <div class="col-md-1  text-right">
                                <label >
                                    Visit Date:
                                </label>
                            </div>
                            <div class="col-md-2 text-center">
                                <label>
                                    <asp:Label ID="lblVisitDt" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 text-right">
                             <label >
                                    Exempted Category:
                                </label>
                            </div>
                            <div class="col-md-3 text-left">
                             <asp:RadioButtonList ID="rdExempted" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdExempted_OnSelectedIndexChanged" CssClass="form-control" AutoPostBack="true">
                                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <asp:Label ID="lblReg" runat="server"></asp:Label>

                            </div>
                         
                        </div>
                          <div class="form-group">
                            <div class="col-md-3 text-right">
                             <label >
                                    Select Test:
                                </label>
                            </div>
                            <div class="col-md-3 text-left">
                              <asp:CheckBoxList ID="chktest" runat="server" CellSpacing="1"  Font-Bold="true" CssClass="form-control cb"
                                                                        OnSelectedIndexChanged="chktest_SelectedIndexChanged" RepeatDirection="Vertical"
                                                                        AutoPostBack="True">
                                                                    </asp:CheckBoxList>
                                                                     <asp:Label ID="lblTestcode" runat="server" Visible="False"></asp:Label>
                                                                <asp:Label ID="lblDName" runat="server"></asp:Label>
                                                                <asp:Label ID="lblVisitId" runat="server" Visible="False"></asp:Label>
                            </div></div>
                        <div class="form-group">
                            <div class="col-md-1 text-center">
                            </div>
                            <div class="col-md-10 text-center">
                                <asp:GridView ID="GvTestDtls" runat="server" ShowFooter="true"  
                                    BorderStyle="None" BorderWidth="1px" OnRowDataBound="GvTestDtls_RowDataBound" OnRowDeleting="GvTestDtls_RowDeleting" CssClass="footable"  Width="800px" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"  PagerStyle-CssClass="pgr">
                                   <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgBtnDelete" runat="server" CommandName="Delete" ImageUrl="~/images/hr.gif" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SI NO" ItemStyle-Width="100">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Test/Procedure Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTcode" runat="server" Text='<%# Bind("TestCode") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblTname" runat="server" Text='<%# Bind("TestName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Total Test Fee (Rs.)">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAmount" runat="server" ForeColor="Blue" Text='<%#Eval("TotalTestFee")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblToatal" runat="server" Text="Total Test Fee"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblGovPaid" runat="server" Text="To Government Account "></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lbltotpay" runat="server" Text="Net Payable"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Fee Paid By Govt">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPaidBygovt" runat="server" ForeColor="Blue" Text='<%#Eval("FeePaidByGovt")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblAmounttotal" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblGovtotal" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblNotPaytotal" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataRowStyle HorizontalAlign="Center" />
                                                        <EmptyDataTemplate>
                                                            No Records
                                                        </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                            <div class="col-md-1 text-center">
                            </div>
                        </div>
                         <div class="form-group">
                            <div class="col-md-2 col-md-offset-3">
                                <asp:Button runat="server" ID="btn_Save" Text="Save" OnClick="btn_Save_Click" class="btn btn-success" ValidationGroup="g1"/>
                              
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
        Designed, Developed and Hosted by National Informatics Centre, Hyderabad. </div></div></div>
    </footer>
    </form>
</body>
</html>
