<%@ Page AutoEventWireup="true" CodeFile="InventoryEntry.aspx.cs" Inherits="EVHMS_UI_Admin_Default"
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
    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });
        $(function () {
           
            $("[id*=btnreset]").click(function () {
                $("#btnreset").validationEngine('detach');
            });
        });
    </script>
     <script type="text/javascript">
         $(function () {
             $("#txt_Date").datepicker({
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
  
       
        .tbldata td
        {
            background-color: white;
            font-family: Times New Roman;
            font-size: large;
            width: 188px;
        }
        </style>
    <script type="text/javascript">
        window.history.forward(1);
        function noBack() {
            window.history.forward();
        }
        function Confirm(link) {

            if (confirm("Are you sure to confirm the recipt of drug?")) {

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
         $(document).ready(function () {
             $('.style_txt_entry').datepicker({
                 dateFormat: 'dd-mm-yy',
                 maxDate: new Date(),
                 showOn: "button",
                 buttonImage: "../Images/calendar.jpg",
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
                                                <strong></strong>
                                            </h5>
                                          
                                            <hr />
                                          
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
                    <span class="card-title">Receipt of Drugs</span></div>
                <div class="col-md-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                            <div class="col-md-10  col-sm-10 text-center">
                                <span style="color: Red">Note:Fields marked with&nbsp;* &nbsp;are Compulsory</span>
                                <asp:Label ID="lblReceiptNo1" runat="server" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3  text-right">
                                <label for="ddlfinyear">
                                    Supplier:<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                             
                                     <asp:DropDownList ID="ddl_Suply" runat="server" 
                                               CssClass="form-control">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ControlToValidate="ddl_Suply" ErrorMessage="Select Supplier" ForeColor="Red" 
                                                InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3  text-right">
                                <label for="ddlfinyear">
                                      Drug Name:<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                               <%-- <asp:DropDownList ID="ddl_mandal_code" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_mandal_code"
                                    ErrorMessage="Select Mandal" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>--%>
                                    <asp:DropDownList ID="ddl_Drug" runat="server" AutoPostBack="true" 
                                               CssClass="form-control" onselectedindexchanged="ddl_Drug_SelectedIndexChanged" 
                                              >
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="ddl_Drug" ErrorMessage="Select Drug" ForeColor="Red" 
                                                InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Unit of Measurement :&nbsp;<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                             <label>  <asp:Label ID="lblUntsMesmt" runat="server" Font-Bold="True"></asp:Label></label>
                            </div>
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Batch No: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                 <asp:TextBox ID="txtBatchNo" runat="server" CssClass="form-control validate[required]" MaxLength="20"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="txtBatchNo_FilteredTextBoxExtender" 
                                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtBatchNo">
                                            </ajax:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Dosages Per Pack:&nbsp;<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:RadioButtonList ID="rbnDosagesperpack" runat="server" AutoPostBack="True"  RepeatDirection="Horizontal"
                                                onselectedindexchanged="rbnDosagesperpack_SelectedIndexChanged">
                                            <asp:ListItem Text=" Single" Value="0"></asp:ListItem>
                                             <asp:ListItem Text=" Multiple" Value="1"></asp:ListItem>
                                            </asp:RadioButtonList>
                            </div>
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                     Quantity in each pack: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:TextBox ID="txtqtyeachpack" runat="server" MaxLength="8" OnTextChanged="txtqtyeachpack_OnTextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                                                runat="server" Enabled="True" FilterType="Custom,Numbers" ValidChars="." TargetControlID="txtqtyeachpack">
                                            </ajax:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Quantity(No.of packages) :&nbsp;<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                 <asp:TextBox ID="txtnoofpackages" runat="server" 
                                                CssClass="form-control validate[required,custom[onlyNumberSp]]" MaxLength="8" 
                                                AutoPostBack="True" ontextchanged="txtnoofpackages_TextChanged"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="txtnoofpackages_FilteredTextBoxExtender" 
                                                runat="server" Enabled="True" FilterType="Numbers,Custom" 
                                                TargetControlID="txtnoofpackages" ValidChars=".">
                                            </ajax:FilteredTextBoxExtender>
                            </div>
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Quantity: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                 <asp:TextBox ID="txtDquantity" runat="server"  ReadOnly="true"
                                                CssClass="form-control" MaxLength="9"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="txtDquantity_FilteredTextBoxExtender" 
                                                runat="server" Enabled="True" FilterType="Numbers,Custom" 
                                                TargetControlID="txtDquantity" ValidChars=".">
                                            </ajax:FilteredTextBoxExtender>
                            </div>
                        </div>
                          <div class="form-group">
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Date of Receipt:&nbsp;<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                  <asp:TextBox ID="txtReceiptDate" runat="server"   CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                   Expiry Date:<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                               <div class="col-md-6"><asp:DropDownList ID="ddl_Month"  CssClass="form-control" runat="server">
                                           
                                            </asp:DropDownList></div>
                               <div class="col-md-6"> <asp:DropDownList ID="ddl_Year"  CssClass="form-control" runat="server">
                                            </asp:DropDownList></div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Value of Drugs Received (Rs.) :&nbsp;<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                             <asp:TextBox ID="txtValue" runat="server" MaxLength="9" CssClass="form-control"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="txtValue_FilteredTextBoxExtender" 
                                                runat="server" Enabled="True" FilterType="Numbers, Custom" 
                                                TargetControlID="txtValue" ValidChars=".">
                                            </ajax:FilteredTextBoxExtender>
                            </div></div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-5">
                                <asp:Button runat="server" ID="btn_Save" Text="Save" OnClick="btn_Save_Click" class="btn btn-success" />
                                &nbsp;<asp:Button runat="server" ID="btn_Update" Text="Update" OnClick="btn_Update_Click"
                                    class="btn btn-warning" />
                                &nbsp;<asp:Button ID="btnreset" runat="server" class="btn btn-danger" OnClick="btnreset_Click"
                                    Text="Reset" />
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
                                    <asp:GridView ID="GvInventory" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CssClass="footable" OnPageIndexChanging="GvInventory_PageIndexChanging" 
                                        PageSize="10" Width="85%">
                                        <HeaderStyle CssClass="success" />
                                     <Columns>
                                                    <asp:TemplateField HeaderText="Supplier Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSupNm" runat="server" Text='<%# Bind("SupplierName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Drug Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDName" runat="server" Text='<%# Bind("DrugName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Dosage Per Pack">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDosageperpack" runat="server" Text='<%# Bind("Dosage_Perpack") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Quantity in each pack">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQtyeachpack" runat="server" Text='<%# Bind("Qty_Eachpack") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Batch No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBtno" runat="server" Text='<%# Bind("BatchNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Expiry Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblexdate" runat="server" Text='<%# Bind("ExpiryDate") %>'></asp:Label>
                                                            <asp:Label ID="lblActExpDt" runat="server" Visible="false" Text='<%# Bind("ExpOrig") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Quantity(No.of packages)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblqtynoofpackages" runat="server" Text='<%# Bind("Noof_Packages") %>'></asp:Label>
                                                          
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQty" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date of Receipt">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRcdate" runat="server" Text='<%# Bind("ReceiptDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Value of Drugs(Rs.)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVdrug" runat="server" Text='<%# Bind("ValueofDrug") %>'></asp:Label>
                                                            <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>' 
                                                                Visible="false"></asp:Label>
                                                            <asp:Label ID="lblInscd" runat="server" Text='<%# Bind("Unique_InsId") %>' 
                                                                Visible="false"></asp:Label>
                                                            <asp:Label ID="lblSuplCd" runat="server" Text='<%# Bind("SupplierCode") %>' 
                                                                Visible="false"></asp:Label>
                                                            <asp:Label ID="lblDrugCd" runat="server" Text='<%# Bind("DrugCode") %>' 
                                                                Visible="false"></asp:Label>
                                                            <asp:Label ID="lblReceiptNo" runat="server" Text='<%# Bind("ReceiptNo") %>' 
                                                                Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Status">
                                      <ItemTemplate>
                                          <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                         
                                               <asp:Label ID="lblDcode" runat="server" Text='<%# Bind("DistCode") %>' 
                                              Visible="false"></asp:Label>
                                            
                                              
                                      </ItemTemplate>
                                  </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                                        <%--<EditItemTemplate>
                                                                            <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                                                            <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                                                        </EditItemTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" runat="server" 
                                                                OnClick="lnkEdit_Click" Text="Edit"></asp:LinkButton> &nbsp|&nbsp
                                                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Dlt" 
                                                                OnClientClick="return Confirm(this)" Text="Confrim"></asp:LinkButton>
                                                        </ItemTemplate>
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
