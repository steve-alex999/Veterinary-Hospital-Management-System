<%@ Page AutoEventWireup="true" CodeFile="IssueofDrug.aspx.cs" Inherits="Pharmacy_IssueofDrug"
    Language="C#" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            $('[id*=GvInventory]').footable();
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
        .tbldata td
        {
            background-color: white;
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
                    <span class="card-title">Issues of Drugs </span></div>
                <div class="col-md-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                            <div class="col-md-10  col-sm-10 text-center">
                                
                                <asp:Label ID="lblReg" runat="server"></asp:Label>
                            </div>
                        </div>
                         <div class="form-group">
                            <div class="col-md-1  text-right">
                                <label >
                                    <b>Registration No</b>:</label>
                            </div>
                            <div class="col-md-2 text-center">
                             
                                     <label><asp:Label ID="lblRegistrationNo" runat="server"></asp:Label></label>
                            </div>
                            <div class="col-md-1  text-right">
                                <label >
                                     <b>Owner Name</b>:</label>
                            </div>
                            <div class="col-md-2 text-center">
                              
                                   <label> <asp:Label ID="lblOwnerNm" runat="server"></asp:Label></label>
                            </div>
                             <div class="col-md-1  text-right">
                                <label >
                                     <b>Animal</b>:</label>
                            </div>
                            <div class="col-md-2 text-center">
                              
                                   <label> <asp:Label ID="lblAnimal" runat="server"></asp:Label></label>
                            </div>
                             <div class="col-md-1  text-right">
                                <label >
                                     <b>Visit Date:</b></label>
                            </div>
                            <div class="col-md-2 text-center">
                              
                                   <label> <asp:Label ID="lblVisitDt" runat="server"></asp:Label></label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2  text-right">
                                <label for="ddlfinyear">
                                    Doctor's  observation:</label>
                            </div>
                            <div class="col-md-4 text-left">
                             
                                    <asp:TextBox ID="txtObservation" runat="server" Height="183px" Width="400px" CssClass="form-control" TextMode="MultiLine"
                                                                           ></asp:TextBox>
                            </div>
                            <div class="col-md-2  col-md-offset-1 text-right">
                                <label >
                                      Disease:<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                            <div class="row">
                            <div class="col-md-12">
                               
                               <asp:DropDownCheckBoxes ID="ddl_Dieases" runat="server" AddJQueryReference="True" CssClass="form-control"
                                                                            OnSelectedIndexChanged="ddl_Dieases_SelectedIndexChanged" Style="height: 43px;
                                                                            top: 0px; left: 110px; width: 100px;" UseButtons="True" UseSelectAllNode="True">
                                                                            <Texts SelectBoxCaption="Select Dieases" />
                                                                        </asp:DropDownCheckBoxes>
                                                                           <asp:Label ID="lblDcode" runat="server" Visible="False"></asp:Label>
                                                                        <label><asp:Label ID="lblDName" runat="server"></asp:Label></label> </div>
                            </div>
                            </div>
                        </div>
                        <div class="form-group">
                         <%--   <div class="col-md-2  text-right">
                                <label >
                                     Select Scheme :&nbsp;<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                             <asp:DropDownList ID="ddlScheme" runat="server" AutoPostBack="true" CssClass="form-control"
                                                                            OnSelectedIndexChanged="ddl_Scheme_SelectedIndexChanged" >
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlScheme"
                                                                            ErrorMessage="Select Scheme" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                            </div>--%>
                            <div class="col-md-2  text-right">
                                <label for="txtdepartment">
                                   Select Drug:</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:DropDownList ID="ddl_Drug" runat="server" AutoPostBack="true" 
                                                                            OnSelectedIndexChanged="ddl_Drug_SelectedIndexChanged" CssClass="form-control">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_Drug"
                                                                            ErrorMessage="Select Drug" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                            </div>
                             <div class="col-md-2  text-right">
                                 <asp:Button ID="btn_add" runat="server" class="btn btn-success" OnClick="btn_add_Click" Text="Add"
                                                                            ValidationGroup="g1" />
                                                                             <asp:Label ID="lblregno" runat="server" Visible="False"></asp:Label>
                                                                             <asp:Label ID="lbldrug" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                            
                           
                        </div>
                       
                    
                        <div class="form-group">
                        </div>
                        <div class="form-group">
                        </div>
                        <div class="row">
                            <div class="col-md-12 text-center">
                          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                    <asp:GridView ID="gvIssueofDrugs" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CssClass="footable" OnRowDataBound="gvIssueofDrugs_RowDataBound"
                                                                    OnRowCommand="gvIssueofDrugs_RowCommand" OnRowDeleting="gvIssueofDrugs_RowDeleting"
                                        PageSize="10" Width="85%">
                                        <HeaderStyle CssClass="success" />
                                     <Columns>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="imgBtnDelete" runat="server" CommandName="Delete" ImageUrl="~/images/hr.gif" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="SI NO" ItemStyle-Width="100">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblsno" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Drug Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDrugCode" runat="server" Text='<%# Bind("DrugCode") %>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="lbldrug" runat="server" Text='<%# Bind("DrugName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Batch No">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblbtno" runat="server" Text='<%# Bind("BatchNo") %>'></asp:Label>
                                                                                <asp:Label ID="lblReceiptNo" runat="server" Text='<%# Bind("ReceiptNo") %>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Expiry Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExpiryDt" runat="server" Text='<%# Bind("expirydate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Value of Drug(Unit Cost)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblVdrug" runat="server" Text='<%# Bind("ValueofDrug") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Available Quantity">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAQty" runat="server" Text='<%# Bind("AvailableQty") %>'></asp:Label>
                                                                                <asp:Label ID="lblMaxQtyTobeissued" runat="server" Text='<%# Bind("MaxQtyToBeIssued") %>'
                                                                                    Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Quantity Issued">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtqty" runat="server" AutoPostBack="true" OnTextChanged="txtqty_OnTextChanged"
                                                                                    Text='<%# Bind("QuantityIssued") %>'></asp:TextBox>
                                                                                <ajax:FilteredTextBoxExtender ID="txtqty_FilteredTextBoxExtender" runat="server"
                                                                                    Enabled="True" FilterType="Numbers, Custom" TargetControlID="txtqty" ValidChars=".">
                                                                                </ajax:FilteredTextBoxExtender>
                                                                                <asp:Label ID="lblQtyIssued" runat="server" Text='<%# Bind("QuantityIssued") %>'
                                                                                    Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Amount(Units(Rs.))">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnCalculate" runat="server" CommandName="Add" Text="Calculate" Height="25px" />
                                                                                <%--<asp:Button ID="btnCalculate" runat="server" OnClick="btnCalculate_Click" Text="Add" />--%>
                                                                                <%-- <asp:ImageButton ID="imgBtnAdd" runat="server" CommandName="Add" Width="40px" ImageUrl="~/Images/add.jpg" />--%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                    </asp:GridView></ContentTemplate></asp:UpdatePanel>
                                
                            </div>
                        </div>
                            <div class="form-group">
                            <div class="col-md-3 col-md-offset-5">
                                <asp:Button runat="server" ID="btn_Save" Text="Save" OnClick="btn_Save_Click" class="btn btn-success"  ValidationGroup="g1"/>
                               
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
