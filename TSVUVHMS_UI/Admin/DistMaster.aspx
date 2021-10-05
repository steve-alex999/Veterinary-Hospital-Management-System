<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DistMaster.aspx.cs" Inherits="EVHMS_UI_Admin_Default" %>

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
<%--    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
      <script type="text/javascript">
        $(function () {
            $('[id*=GvDistricts]').footable();
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
        function chlength() {
            var str = document.getElementById("txtDistCode");
            var txtlen = str.value.length;
            if (txtlen > 5) {
                //red
                txtDistCode.style.backgroundColor = "#FF0000";
            }
            else {
                //green
                txtDistCode.style.backgroundColor = "#00FF00";
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
                                 <Menu:Menu ID="Menu" runat="server"></Menu:Menu>
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
            Logged As ::<asp:Label ID="lblUsrName" runat="server" Font-Bold="true" ForeColor="#ab7d44"
                Text=""></asp:Label>
        </div>
        <div class="col-md-4 text-right">
            <%--Institution Name : &nbsp;
            <asp:Label ID="lblInsName" runat="server" Font-Bold="True" ForeColor="#AB7D44"></asp:Label>--%>
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
                    <span class="card-title"> District Master</span></div>
                <div class="col-md-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                     <div class="form-group"></div>
                      <div class="form-group">
                            <div class="col-md-3  text-right">
                             <label for="ddlfinyear">
                                    District Code:<span style="color: Red">*</span></label>
                                       
                                    </div>
                                    <div class="col-md-3 text-center">
                                     <asp:TextBox ID="txtDistCode" runat="server" AutoPostBack="True"  CssClass="Form-control validate[required,custom[integer]]"
                                                                MaxLength="2" placeholder="District Code" OnTextChanged="txtDistCode_TextChanged"></asp:TextBox>
                                                            <ajax:FilteredTextBoxExtender ID="txtDistCode_FilteredTextBoxExtender" runat="server"
                                                                Enabled="True" FilterType="Numbers" TargetControlID="txtDistCode">
                                                            </ajax:FilteredTextBoxExtender>
                                                            <asp:Label ID="lblDcode" runat="server"></asp:Label>
                                    </div>
                            <div class="col-md-3  text-right">
                                <label for="ddlfinyear">
                                    District Name:<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                           <asp:TextBox ID="txtDistName" runat="server" placeholder="District Name" CssClass="validate[required] Form-control"
                                                            MaxLength="50"></asp:TextBox>
                                                        <ajax:FilteredTextBoxExtender ID="txtDistName_FilteredTextBoxExtender" runat="server"
                                                            Enabled="True" TargetControlID="txtDistName" FilterType="Custom,Numbers,UppercaseLetters,lowercaseLetters"
                                                            ValidChars=" .">
                                                        </ajax:FilteredTextBoxExtender>
                        </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                   Effective&nbsp;Date:&nbsp;<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                               <asp:TextBox ID="txt_Date" runat="server" AutoCompleteType="Disabled" 
                                                             CssClass="form-control"></asp:TextBox>
                            </div>
                             <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Active: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                            <asp:RadioButtonList ID="rbnSy" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Text="Yes" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="0" Text="No"></asp:ListItem>
                            </asp:RadioButtonList>
                                 <%-- <asp:RadioButton ID="rbnSy" runat="server" AutoPostBack="True" GroupName="ActiveSt"
                                                            Height="24px" Text="Yes" Width="16%" Checked="true" />
                                                        <asp:RadioButton ID="rbnSn" runat="server" AutoPostBack="true" GroupName="ActiveSt"
                                                            Text="No" Width="15%" />--%>
                                   
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-5">
                                <asp:Button runat="server" ID="btn_Save" Text="Save" OnClick="btn_Save_Click"
                                    class="btn btn-success" />
                                      
                                    &nbsp;<asp:Button runat="server" ID="btn_Update" Text="Update" OnClick="btn_Update_Click"
                                    class="btn btn-warning" />
                            &nbsp;<asp:Button ID="btnreset" runat="server" class="btn btn-danger" 
                                    onclick="btnreset_Click" Text="Reset" />
                            </div>
                        </div>
                         <div class="form-group"></div>
                          <div class="form-group"></div>
                         <div class="row">
                            <div class="col-md-12">
                            <div class="col-md-1"></div>
                             
                             <div class="col-md-10 text-center">
                             <asp:GridView ID="GvDistricts" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                               
                                                CssClass="footable" DataKeyNames="DistCode" OnPageIndexChanging="GvDistricts_PageIndexChanging"
                                                OnRowCommand="GvDistricts_RowCommand" OnRowEditing="GvDistricts_RowEditing" PageSize="10" Width="85%">
                                                 <HeaderStyle CssClass="success" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="District Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldcode" runat="server" Text='<%# Bind("DistCode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="District Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldnm" runat="server" Text='<%# Bind("DistName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Active">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Effective Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbleffdate" runat="server" Text='<%# Bind("EffectiveDt") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" OnClick="lnkEdit_Click"
                                                                Text="Edit"></asp:LinkButton>&nbsp|&nbsp
                                                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Dlt"  OnClientClick="return Confirm(this)"
                                                                Text="Delete"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                             <%--<asp:GridView ID="gvdepartment" CssClass="table table-bordered table-hover table-striped fnt" 
                                    runat="server" AutoGenerateColumns="False" >
                                    <HeaderStyle CssClass="success" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl.No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" /></ItemTemplate>
                                        </asp:TemplateField>
                                    
                                        <asp:TemplateField HeaderText="Depertment Code" Visible="false" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbldeptcode" Text='<%#Eval("Dept_code") %>' ></asp:Label>
                                               
                                            </ItemTemplate>
                                             
                                           
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Subject Name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbldeptname" Text='<%#Eval("Dept_name") %>'></asp:Label>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Unit Code"  >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblunitcode" Text='<%#Eval("Unit_code") %>' ></asp:Label>
                                               
                                            </ItemTemplate>
                                             
                                           
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Unit Desc"  >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblunitdesc" Text='<%#Eval("Unit_desc") %>' ></asp:Label>
                                               
                                            </ItemTemplate>
                                             
                                           
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="linkedit"  Text="Edit" OnClick="linklinkedit_OnClick"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="linkDelete" Text="Delete" OnClick="linkDelete_OnClick"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          
                                    </Columns>
                                    <PagerStyle CssClass="pgn" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                </asp:GridView>--%>
                          </div>
                             <div class="col-md-1"></div>
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
                      <%--  Designed, Developed and Hosted by National Informatics Centre, Hyderabad.--%>
                      <Footer:footer ID="footer" runat="server"></Footer:footer>
                    </div>
                </div>
            </div>
        </footer>
    </form>
</body>
</html>
