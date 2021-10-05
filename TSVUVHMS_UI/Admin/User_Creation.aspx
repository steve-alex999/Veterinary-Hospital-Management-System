<%@ Page AutoEventWireup="true" CodeFile="User_Creation.aspx.cs" Inherits="EVHMS_UI_Admin_Default"
    Language="C#" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title></title>
    <script src="../scripts/sha1.js" type="text/javascript"></script>
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
            $('[id*=GvUser]').footable();
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
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
            background-color: White;
            font-family: Times New Roman;
            font-size: large;
        }
        .Grid
        {
            width: 100%;
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
        }
        .Grid th
        {
            padding: 4px 2px;
            color: #fff;
            background: #59acac;
            border-left: solid 1px white;
            font-size: 1.0em;
            font-family: Times New Roman;
        }
    </style>
</head>
<body>
    <script type="text/javascript">
        function validateReg() {

            var userName = document.getElementById('txtUname').value;
            var pwd = document.getElementById('txtPwd').value;
            if (userName == "") {

                return false;
            }

            if (pwd == "") {

                return false;
            }

            var password = document.getElementById('txtPwd').value;
            if (password != '') {
                document.getElementById('txtPwdHash').value = '';
                var myval1 = SHA1(document.getElementById('txtPwd').value.toString());
                document.getElementById('txtPwd').value = '**********';
                document.getElementById('txtPwdHash').value = myval1;

            }
            
        }

        function validateNewPwd() {

            var newpwd = document.getElementById('txtNpwd').value;
            if (newpwd != '') {

                document.getElementById('txtNewPwdHash').value = '';

                var myval2 = SHA1(newpwd);

                document.getElementById('txtNpwd').value = '**********';
                document.getElementById('txtCpwd').value = '**********';

                document.getElementById('txtNewPwdHash').value = myval2;
                alert(myval2);
                return false;
            }


        }

        function validateCustomReg(oSrc, args) {
            var psw = document.getElementById('txtPwd').value;
            var encpsw = document.getElementById('txtPwdHash').value;
            if (psw == '') {
                args.IsValid = false;
            }
            else {
                if (encpsw == '') {
                    var pattern = new RegExp("^.*(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&amp;+=]).*$");
                    args.IsValid = pattern.test(psw);
                    return false;
                    alert("Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character");
                }
            }

        }
        function validateCustomReg_ResetPwd(oSrc, args) {
            var psw = document.getElementById('txtNPwd').value;
            var encpsw = document.getElementById('txtNewPwdHash').value;
            if (psw == '') {
                args.IsValid = false;
            }
            else {
                if (encpsw == '') {
                    var pattern = new RegExp("^.*(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&amp;+=]).*$");
                    args.IsValid = pattern.test(psw);
                }
            }

        }

      
    </script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenField1" runat="server" />
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
            Logged As ::<asp:Label ID="lblUsrName" runat="server" Font-Bold="true" ForeColor="#ab7d44"
                Text=""></asp:Label>
        </div>
        <div class="col-md-4 text-right">
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
                    <span class="card-title">User Creation</span></div>
                <div class="col-md-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                            <div class="col-md-12  col-sm-12 text-center">
                                <span style="color: Red">Note:Fields marked with&nbsp;* &nbsp;are Compulsory</span>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3  text-right">
                                <label for="ddlfinyear">
                                    User Type:<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:DropDownList ID="ddl_Role" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddl_Role"
                                    ErrorMessage="Select User Type" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3  text-right">
                            </div>
                            <div class="col-md-3 text-center">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3  text-right">
                                <label for="ddlfinyear">
                                    District:<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                             <asp:DropDownList ID="ddl_State" runat="server" CssClass="form-control" 
                                    Visible="false" >
                                                </asp:DropDownList>
                                <asp:DropDownList ID="ddl_dist_code" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_dist_code_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_dist_code"
                                    ErrorMessage="Select District" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3  text-right">
                                <label for="ddlfinyear">
                                    Mandal:<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:DropDownList ID="ddl_mandal_code" runat="server" CssClass="form-control" AutoPostBack="true"
                                    onselectedindexchanged="ddl_mandal_code_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_mandal_code"
                                    ErrorMessage="Select Mandal" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Institution Type:&nbsp;<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:DropDownList ID="ddl_InsType" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_InsType_SelectedIndexChanged"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_InsType"
                                    ErrorMessage="Select Institution Type" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Institution Name: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:DropDownList ID="ddl_Inst" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_Inst_SelectedIndexChanged"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddl_Inst"
                                    ErrorMessage="Select Institution" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    User Name:&nbsp;<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:TextBox ID="txtUname" runat="server" CssClass="form-control validate[required]"
                                    MaxLength="50" placeholder="User Name"></asp:TextBox>
                            </div>
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Password: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control validate[required]"
                                    MaxLength="50" placeholder="Password" TextMode="Password"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" ValidationGroup="g1" Display="None"
                                    ErrorMessage="Your Password Should Contain minimum 8 Characters with atleast 1 uppercase,1 lowercase, 1 numeric and 1 Special character"
                                    ControlToValidate="txtPwd" ClientValidationFunction="validateCustomReg"></asp:CustomValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                    TargetControlID="CustomValidator2">
                                </asp:ValidatorCalloutExtender>
                                <asp:HiddenField ID="txtPwdHash" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-5">
                                <asp:Button runat="server" ID="btn_Save" Text="Save" OnClick="btn_Save_Click" class="btn btn-success" OnClientClick="return validateReg()"/>
                                &nbsp;&nbsp;<asp:Button ID="btnreset" runat="server" class="btn btn-danger" OnClick="btnreset_Click"
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
                                    <asp:GridView ID="GvUser" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CssClass="footable" OnPageIndexChanging="GvUser_PageIndexChanging" OnRowCommand="GvUser_RowCommand"
                                        PageSize="10" Width="85%">
                                        <HeaderStyle CssClass="success" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="User Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUname" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRole" runat="server" Text='<%# Bind("Role_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="col-md-1">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-1">
                                </div>
                                <div class="col-md-10 text-center">
                                    <div class="row">
                                        <div class="col-md-12 text-center">
                                            <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
                                            <asp:ModalPopupExtender ID="mp1" runat="server" DropShadow="false" PopupControlID="pnlAddEdit"
                                                TargetControlID="HiddenField2" BackgroundCssClass="modalBackground" CancelControlID="btnLogClose">
                                            </asp:ModalPopupExtender>
                                            <asp:HiddenField ID="HiddenField2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 text-center">
                                            <asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup" align="left" Style="display: none;
                                                overflow: auto" Height="300px">
                                                <div style="text-align: right">
                                                    <div class="form-group">
                                                        <div class="col-md-12 text-right">
                                                            <asp:ImageButton ID="btnLogClose" runat="server" ImageUrl="~/images/close.jpg" Width="40px"
                                                                Height="40px" CausesValidation="false" /></div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-md-12 text-center">
                                                        <b>Reset Password</b><asp:Label ID="lblName" runat="server" Font-Bold="true" ForeColor="#ab7d44"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-md-6 text-right">
                                                    <strong>New Password</strong>
                                                    <asp:Label ID="test" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-6 text-left">
                                                     <asp:TextBox ID="txtNpwd" CssClass="style_txt_entry" runat="server" TextMode="Password"
                                                        MaxLength="20"> </asp:TextBox>
                                                         <asp:HiddenField ID="txtNewPwdHash" runat="server" />
                                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ValidationGroup="g1" Display="None"
                                                        ErrorMessage="Your Password Should Contain minimum 8 Characters with atleast 1 uppercase,1 lowercase, 1 numeric and 1 Special character"
                                                        ControlToValidate="txtNpwd" ClientValidationFunction="validateCustomReg_ResetPwd"></asp:CustomValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                        TargetControlID="CustomValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-md-6 text-right">
                                                    <strong>Confirm Password</strong>
                                                    </div>
                                                    <div class="col-md-6 text-left">
                                                    <asp:TextBox ID="txtCpwd" runat="server" CssClass="style_txt_entry" TextMode="Password"
                                                        MaxLength="20"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="g1" ControlToValidate="txtCpwd"
                                                        runat="server" ErrorMessage="Please Enter Password" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True"
                                                        TargetControlID="RequiredFieldValidator9">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="g1"
                                                        ErrorMessage="Password and Confirm Password doesnot Match" Display="None" ControlToValidate="txtCpwd"
                                                        ControlToCompare="txtNpwd"></asp:CompareValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                                        TargetControlID="CompareValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                                    </div>
                                                </div>
                                                 <div class="form-group">
                                                    <div class="col-md-12 text-center">
                                                     <asp:Button ID="btnUpdatePwd" runat="server" ValidationGroup="g1" Text="Update" OnClick="btnUpdatePwd_Click"
                                                        OnClientClick="validateNewPwd();" CssClass="btnsubmit" Width="10%" Height="20px" /><br />
                                                    </div>
                                                   <%-- <div class="col-md-6 text-left">
                                                    </div>--%>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
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
                    <Footer:footer ID="footer" runat="server"></Footer:footer>
                </div>
            </div>
        </div>
    </footer>
    </form>
</body>
</html>
