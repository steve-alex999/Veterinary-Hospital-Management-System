<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientReg1old.aspx.cs" Inherits="Patient" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/Institution/Admin.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../scripts/jquery-ui.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/ui-lightness/jquery-ui.css" />
    <link href="../styles/style.css" rel="Stylesheet" type="text/css" />
   
    <script src="../scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="../scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #profile_tab
        {
            border-collapse: collapse;
        }
        
        #profile_tab td
        {
            border: 1px dotted #666666;
        }
        
        #example
        {
            border-collapse: collapse;
        }
        
        #example td
        {
            border: 1px dotted #666666;
        }
        .tbldata td
        {
            background-color: white;
            font-family: Times New Roman;
            font-size: large;
        }
        
        
        .styleheader
        {
            width: 1200px;
            height: 100px;
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
     <script type="text/javascript">
         $(document).ready(function () {
             $('.style_txt_entry').datepicker({
                 dateFormat: 'dd-mm-yy',
                 maxDate: new Date(),
                 minDate: -2,
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
    <script type="text/javascript" language="javascript">
        String.prototype.startsWith = function (str) {
            return (this.indexOf(str) === 0);
        }
        function ChkValidChar() {

            var txtbx = document.getElementById("txtmbno").value;
            if (txtbx.startsWith("0") || txtbx.startsWith("1") || txtbx.startsWith("2") || txtbx.startsWith("3") || txtbx.startsWith("4") || txtbx.startsWith("5") || txtbx.startsWith("6")) // true
            {
                document.getElementById("txtmbno").value = "";
                alert("Enter Valid Mobile Number");
            }
        }

        function validateMobile(key) {

            var keycode = (key.which) ? key.which : key.keyCode;
            if ($("#txtmbno").val().length < 1) {

                if ((keycode > 47 && keycode < 55) || (keycode > 96 && keycode < 103)) {

                    return false;
                }
                else {
                    return true;

                }

            }
            var i;
            for (i = 0; i <= 6; i++) {
                if ($("#txtmbno").val() == i) {
                    alert("hai"); F
                    return false;

                }
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
    <div align="center">
        <table border="0" width="982px" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
            <tr>
                <td>
                    <img alt="" class="style63" src="../images/header.PNG" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <menu:menu ID="menu" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td align="left" class="loggedUser">
                                <img src="../images/14.gif">
                                Logged As ::<asp:Label ID="lblUsrName" runat="server" Font-Bold="true" ForeColor="#ab7d44"
                                    Text=""></asp:Label>
                            </td>
                            <td align="center" class="loggedUser">
                                Institution Name : &nbsp;
                                <asp:Label ID="lblInsName" runat="server" Font-Bold="True" ForeColor="#AB7D44"></asp:Label>
                            </td>
                            <td align="right">
                                Date ::<asp:Label ID="lblDate" runat="server" Font-Bold="true" ForeColor="#ab7d44"></asp:Label>
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" style="background-color: #59ACAC; color: #FFFFFF;
                                font-family: 'Times New Roman', Times, serif; font-size: large;" width="100%">
                                Patient Registration
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                   <%-- <asp:UpdatePanel ID="up1" runat="server">
                        <ContentTemplate>--%>
                            <div align="center">
                                <table align="center" width="100%">
                                    <tr align="center">
                                        <td>
                                            <table class="tbldata" align="center" width="100%">
                                                <tr>
                                                    <td align="left" width="50%">
                                                        <b>Visit Date&nbsp;:&nbsp;<asp:TextBox ID="txtVdate" runat="server" CssClass="style_txt_entry"></asp:TextBox>
                                                        </b>
                                                    </td>
                                                    <td width="50%">
                                                        <asp:RadioButton ID="rbnSy" runat="server" AutoPostBack="True" GroupName="Newreg"
                                                            OnCheckedChanged="rbnSy_CheckedChanged" Text="New Registration" Checked="True" />
                                                        <asp:RadioButton ID="rbnSn" runat="server" AutoPostBack="true" GroupName="Newreg"
                                                            OnCheckedChanged="rbnSn_CheckedChanged" Text="Re-visit" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2" width="100%">
                                                        <asp:Panel ID="Panel2" runat="server" Width="100%">
                                                            <table align="center" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        Registration No
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txt_FregNo" runat="server" MaxLength="15"></asp:TextBox>
                                                                        <ajax:FilteredTextBoxExtender ID="txt_FregNo_FilteredTextBoxExtender" runat="server"
                                                                            Enabled="True" TargetControlID="txt_FregNo" FilterType="Numbers">
                                                                        </ajax:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td>
                                                                        (OR)
                                                                    </td>
                                                                    <td>
                                                                        Mobile No
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtRMbno" runat="server" AutoPostBack="True" MaxLength="10"></asp:TextBox>
                                                                        <ajax:FilteredTextBoxExtender ID="txtRMbno_FilteredTextBoxExtender" runat="server"
                                                                            Enabled="True" TargetControlID="txtRMbno" FilterType="Numbers">
                                                                        </ajax:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                                                                            Height="24px" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblregno" runat="server" Visible="False"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="7" align="center" style="color: #FF3300">
                                                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <asp:GridView ID="GvPatientDtlsMbno" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                            BackColor="#DEBA84" BorderColor="#DEBA84" OnRowCommand="GvPatientDtlsMbno_RowCommand" OnPageIndexChanging="GvPatientDtlsMbno_PageIndexChanging"
                                                                            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" CssClass="Grid"
                                                                            DataKeyNames="RegistrationNo" PageSize="10" Width="874px">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="SI NO" ItemStyle-Width="100">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Registartion No">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="linkgetregno" CommandName="ShowPaitentdetails" runat="server"
                                                                                            ForeColor="Blue" Text='<%# Bind("RegistrationNo") %>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Owner Name">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblOwner0" runat="server" Text='<%# Bind("Owner_Name") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Animal">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAnimal0" runat="server" Text='<%# Bind("AnimalTypeDesc") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                                                            <table class="tbldata" width="100%">
                                                                <tr>
                                                                    <td colspan="6" align="center" style="background-color: lightgray; color: #FFFFFF;
                                                                        font-size: large;">
                                                                        <strong style="color: #339933">Animal Details</strong>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="6">
                                                                        <asp:Label ID="lblRegistrationNo" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="15%" align="left">
                                                                        Animal Type :
                                                                    </td>
                                                                    <td align="left" width="25%">
                                                                        <asp:DropDownList ID="ddl_AnimalType" runat="server" Height="33px" Width="160px"
                                                                            OnSelectedIndexChanged="ddlAnimalType_OnSelectedIndexChanged" AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddl_AnimalType"
                                                                            ErrorMessage="Select Animal Type" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td align="left" width="10%">
                                                                        Breed :
                                                                    </td>
                                                                    <td align="left" width="25%">
                                                                        <asp:DropDownList ID="ddlBreed" runat="server" Width="160px" Height="33px">
                                                                            <asp:ListItem>Select Breed</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorBreed" runat="server" ControlToValidate="ddlBreed"
                                                                            ErrorMessage="Select Breed" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td align="left" width="10%">
                                                                        Gender :
                                                                    </td>
                                                                    <td align="left" width="15%">
                                                                        <asp:RadioButton ID="rbnMale" runat="server" GroupName="Gender" Text="Male" Checked="True" />
                                                                        <asp:RadioButton ID="rbnFemale" runat="server" GroupName="Gender" Text="Female" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="15%" align="left">
                                                                        Age :
                                                                    </td>
                                                                    <td width="25%" align="left">
                                                                        Year<asp:TextBox ID="txtAnimalAge" runat="server" MaxLength="2" Width="45px"></asp:TextBox>
                                                                        <ajax:FilteredTextBoxExtender ID="txtAnimalAge_FilteredTextBoxExtender" runat="server"
                                                                            Enabled="True" FilterType="Numbers" TargetControlID="txtAnimalAge">
                                                                        </ajax:FilteredTextBoxExtender>
                                                                        Months
                                                                        <asp:DropDownList ID="ddl_AgeMonth" runat="server" Height="33px" Width="60px">
                                                                            <asp:ListItem Value="0">0</asp:ListItem>
                                                                            <asp:ListItem Value="1">1</asp:ListItem>
                                                                            <asp:ListItem Value="2">2</asp:ListItem>
                                                                            <asp:ListItem Value="3">3</asp:ListItem>
                                                                            <asp:ListItem Value="4">4</asp:ListItem>
                                                                            <asp:ListItem Value="5">5</asp:ListItem>
                                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                                            <asp:ListItem Value="8">8</asp:ListItem>
                                                                            <asp:ListItem Value="9">9</asp:ListItem>
                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                            <asp:ListItem Value="11">11</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" width="10%">
                                                                        Last Visit Date:
                                                                    </td>
                                                                    <td colspan="3" align="left">
                                                                        <asp:Label ID="lblLastVstDt" runat="server" Text=" - "></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center" style="background-color: lightgray; color: #FFFFFF;
                                                                        font-size: large;">
                                                                        <strong style="color: #339933">Owner Details</strong>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="15%" align="left">
                                                                        Owner Name :
                                                                    </td>
                                                                    <td width="25%" align="left">
                                                                        <asp:TextBox ID="txtAnimalOwner" runat="server" MaxLength="75"></asp:TextBox>
                                                                        <ajax:FilteredTextBoxExtender ID="txtAnimalOwner_FilteredTextBoxExtender" runat="server"
                                                                            Enabled="True" FilterType="Custom,Numbers,UppercaseLetters,lowercaseLetters"
                                                                            ValidChars=" ." TargetControlID="txtAnimalOwner">
                                                                        </ajax:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td width="10%" align="left">
                                                                        &nbsp;State:
                                                                    </td>
                                                                    <td colspan="3" align="left">
                                                                        <asp:DropDownList ID="ddl_State" runat="server" AutoPostBack="true" Height="33px"
                                                                            OnSelectedIndexChanged="ddl_State_SelectedIndexChanged" Width="150px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%" align="left">
                                                                        District :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="ddl_dist_code" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_dist_code_SelectedIndexChanged"
                                                                            Height="33px" Width="160px">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_dist_code"
                                                                            ErrorMessage="Select District" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td align="left">
                                                                        Mandal:
                                                                    </td>
                                                                    <td colspan="3" align="left">
                                                                        <asp:DropDownList ID="ddl_mandal_code" runat="server" AutoPostBack="true" Height="33px"
                                                                            Width="160px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="15%" align="left">
                                                                        City/Village:
                                                                    </td>
                                                                    <td width="25%" align="left">
                                                                        <asp:TextBox ID="txtvillage" runat="server" MaxLength="75"></asp:TextBox>
                                                                        <ajax:FilteredTextBoxExtender ID="txtvillage_FilteredTextBoxExtender" runat="server"
                                                                            Enabled="True" TargetControlID="txtvillage" FilterType="Custom,Numbers,UppercaseLetters,lowercaseLetters"
                                                                            ValidChars=" .">
                                                                        </ajax:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Mobile No :
                                                                    </td>
                                                                    <td colspan="3" align="left">
                                                                        <asp:TextBox ID="txtmbno" runat="server" MaxLength="10" onkeypress="return validateMobile(event)"></asp:TextBox>
                                                                        <ajax:FilteredTextBoxExtender ID="txtmbno_FilteredTextBoxExtender" runat="server"
                                                                            Enabled="True" TargetControlID="txtmbno" FilterType="Numbers">
                                                                        </ajax:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="15%" align="left">
                                                                        Exempted Category:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:RadioButtonList ID="rdExempted" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdExempted_OnSelectedChanged" AutoPostBack="true">
                                                                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td>
                                                                    Registration Fee :
                                                                        <asp:Label ID="Regno" runat="server" Visible="False"></asp:Label>
                                                                    </td>
                                                                    <td colspan="3">
                                                                        <asp:Label ID="lblRegFee" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" align="center">
                                                                        <asp:Button ID="btn_Save" runat="server" Height="27px" OnClick="btn_Save_Click" Text="Save"
                                                                            ValidationGroup="g1" />
                                                                        <script type="text/javascript">

                                                                            function preventMultipleSubmissions() {
                                                                                $('#<%=btn_Save.ClientID %>').prop('disabled', true);
                                                                            }

                                                                            window.onbeforeunload = preventMultipleSubmissions;
 
                                                                        </script>
                                                                        <asp:Button ID="btn_Update" runat="server" Height="27px" OnClick="btn_Update_Click"
                                                                            Text="Update" ValidationGroup="g1" />
                                                                        <script type="text/javascript">

                                                                            function preventMultipleSubmissions() {
                                                                                $('#<%=btn_Update.ClientID %>').prop('disabled', true);
                                                                            }

                                                                            window.onbeforeunload = preventMultipleSubmissions;
 
                                                                        </script>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                      <%--  </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    <Footer:footer ID="footer" runat="server"></Footer:footer>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
