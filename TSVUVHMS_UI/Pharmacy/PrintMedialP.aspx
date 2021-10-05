<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintMedialP.aspx.cs" Inherits="Institution_Sheet" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script src="../scripts/JQuery-min.js.js" type="text/javascript"></script>
    <script src="../scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="../scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <link href="../BS/css/footable.min.css" rel="stylesheet" type="text/css" />
    <%--<script src="../BS/js/jquery.min.js" type="text/javascript"></script>--%>
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
    <%--  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=gvIssueofDrugs]').footable();
        });
    </script>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
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
        .style2
        {
            width: 205px;
        }
        .myGridStyle
        {
            width: 95%;
            height: 80%;
        }
        
        .myGridStyle
        {
            border-collapse: collapse;
            font-size: 19px;
        }
        .Grid
        {
            width: 100%;
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
        }
        
        .style64
        {
            height: 23px;
        }
        .style65
        {
            width: 205px;
            height: 23px;
        }
        .style66
        {
            width: 1200px;
            height: 40px;
            text-decoration: underline;
        }
        .style67
        {
            width: 1200px;
            height: 39px;
            text-decoration: underline;
        }
        .style68
        {
            width: 1200px;
            height: 32px;
            text-decoration: underline;
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
            <label>
                Logged As ::
            </label>
            <asp:Label ID="lblUsrName" runat="server" Font-Bold="true" ForeColor="#ab7d44" Text=""></asp:Label>
        </div>
        <div class="col-md-4 text-right">
            <label>
                Institution Name : &nbsp;</label>
            <asp:Label ID="lblInsName" runat="server" Font-Bold="True" ForeColor="#AB7D44"></asp:Label>
        </div>
        <div class="col-md-4 text-right">
            <span style="color: green;">Date ::</span> &nbsp; <span>
                <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
        </div>
    </div>
    <asp:Panel ID="pnlContents" runat="server">
    <div class="panel-heading">
        <div class="row">
            <div class="col-md-1">
            </div>
            <div class="col-md-10" id="card" style="margin-top: 0">
                <div class="card-header">
                    <span class="card-title">Issue Of Drugs </span>
                </div>
                <div class="col-md-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                            <div class="col-md-10  col-sm-10 text-center">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3  text-right">
                                <label>
                                    Reg.No:</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <label>
                                    <asp:Label ID="lblRegNo" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                            <div class="col-md-3  text-right">
                                <label>
                                    Date:</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <label>
                                    <asp:Label ID="Label1" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3  text-right">
                                <label>
                                    Owner Name:
                                </label>
                            </div>
                            <div class="col-md-3 text-center">
                                <label>
                                    <asp:Label ID="lblOwner" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                            <div class="col-md-3  text-right">
                                <label>
                                    Address:</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <label>
                                    <asp:Label ID="lblAddress" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3  text-right">
                                <label>
                                    Mobile No:</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <label>
                                    <asp:Label ID="lblMbno" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                            <div class="col-md-3  text-right">
                                <label>
                                    Animal:</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <label>
                                    <asp:Label ID="lblAnimal" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3  text-right">
                                <label>
                                    Gender:</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <label>
                                    <asp:Label ID="lblGender" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                            <div class="col-md-3  text-right">
                                <label>
                                    Age:</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <label>
                                    <asp:Label ID="lblAge" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3  text-right">
                                <label>
                                    Name of the Instution:</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <label>
                                    <asp:Label ID="lblIns" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                            <div class="col-md-3  text-right">
                                <label>
                                    Disease:</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <label>
                                    <asp:Label ID="lblDisease" runat="server" CssClass="form-control"></asp:Label></label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12  text-center">
                                <label>
                                    <b>Drugs Issued </b>
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                        </div>
                        <div class="form-group">
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-1">
                                </div>
                                <div class="col-md-10 text-center">
                                    <asp:GridView ID="gvIssueofDrugs" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CssClass="footable" OnRowDataBound="gvIssueofDrugs_RowDataBound"
                                        PageSize="10" Width="85%">
                                        <HeaderStyle CssClass="success" />
                                     <Columns>
                                    <asp:TemplateField HeaderText="Drug Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldrug" runat="server" Text='<%# Bind("DrugName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity Issued">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQtyIssued" runat="server" Text='<%# Bind("QuantityIssued") %>'></asp:Label>
                                        </ItemTemplate>
                                          <FooterTemplate>
                                         <table width="100%" border="1">
                                        <tr>
                                        <td>
                                            <asp:Label ID="lblGtotal" runat="server" Text=" a).Total:" Font-Bold="true" />
                                            </td>
                                            </tr>
                                            <tr>
                                            <td>
                                            <asp:Label ID="lblGovttotal" runat="server" Text=" b).To Govt A/C:" Font-Bold ="true"/>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td>
                                            <asp:Label ID="lblNotPay" runat="server" Text=" c).Net Payable(a-b):" Font-Bold ="true"/>
                                            </td>
                                            </tr>
                                            </table>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Amount(Units(Rs.))">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" ForeColor="Blue" Text='<%#Eval("Amount")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        <table width="100%" border="1">
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
                                    </asp:GridView>
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
    </div></asp:Panel>
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
