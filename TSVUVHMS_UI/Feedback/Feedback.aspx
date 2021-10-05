<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/Feedback/FBMenu.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.style_txt_entry').datepicker({
                dateFormat: 'dd-mm-yy',
                maxDate: -1,
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
        function Confirm(link) {
            if (confirm("Are you sure to close feedback?")) {
                return true;
            }
            else
                return false;
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
                                Feedback
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <%-- <asp:UpdatePanel ID="up1" runat="server">
                        <contenttemplate>--%>
                    <div align="center" style="margin-bottom: 0px">
                        <table align="center" width="90%" class="tbldata">
                            <tr>
                                <td width="20%" align="right">
                                    District :&nbsp;
                                </td>
                                <td width="30%" align="left">
                                    <asp:DropDownList ID="ddlDist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDist_OnSelectedIndexChanged"
                                        Width="180px" Height="33px">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlState" runat="server" Width="10px" Height="33px" Visible="False">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right" width="20%">
                                    Institution :
                                </td>
                                <td align="left" width="30%">
                                    <asp:DropDownList ID="ddlInst" runat="server" Width="250px" Height="33px" OnSelectedIndexChanged="ddlIns_OnSelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Visit Date:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="style_txt_entry" OnTextChanged="txtDate_OnTextChnaged"
                                        AutoPostBack="true"></asp:TextBox>
                                </td>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnGetData" runat="server" Height="30px" OnClick="btnGetData_Click"
                                        Text="GetData" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="style79" align="center">
                                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:GridView ID="GvPatientDtls" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                                        CellPadding="3" CellSpacing="2" CssClass="Grid" PageSize="5" Width="874px" OnPageIndexChanging="GvPatientDtls_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reg No">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkgetregno" runat="server" ForeColor="Blue" OnClick="lnkRegNo_Click"
                                                        Text='<%#Eval("RegNo")%>'></asp:LinkButton>
                                                    <asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("RegNo") %>' Visible="false"></asp:Label>
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
                                                    <asp:Label ID="lblAnimalTypeDesc" runat="server" Text='<%# Bind("AnimalTypeDesc") %>'></asp:Label>
                                                    <asp:Label ID="lblRFP" runat="server" Text='<%# Bind("Reg_Fee") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblTFP" runat="server" Text='<%# Bind("Diag_TestFeePaid") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblDI" runat="server" Text='<%# Bind("DrugsIssued_St") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblVisitId" runat="server" Text='<%# Bind("VisitId") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle HorizontalAlign="Center" />
                                        <EmptyDataTemplate>
                                            No Records
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="style79" colspan="4">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%-- </contenttemplate>
                    </asp:UpdatePanel>--%>
                </td>
            </tr>
            <tr id="trPatientDtls" runat="server" visible="false">
                <td colspan="4" align="left">
                    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <contenttemplate>--%>
                    <table align="center" style="width: 90%">
                        <tr>
                            <td colspan="4">
                                <table border="1" align="center" style="width: 100%">
                                    <tr>
                                        <td align="center" colspan="3" style="vertical-align: top; text-align: left;">
                                            <table style="vertical-align: top">
                                                <tr>
                                                    <td colspan="2">
                                                        <b>Patient Details</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Registration No
                                                    </td>
                                                    <td>
                                                        :&nbsp;<asp:Label ID="lblRegNo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Owner Name
                                                    </td>
                                                    <td>
                                                        :&nbsp;<asp:Label ID="lblOwnerName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Owner Mobile No
                                                    </td>
                                                    <td>
                                                        :&nbsp;<asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Animal
                                                    </td>
                                                    <td>
                                                        :&nbsp;<asp:Label ID="lblAnimal" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Registration Fee Paid
                                                    </td>
                                                    <td>
                                                        :&nbsp;<asp:Label ID="lblRegFeePaid" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Test Fee Paid
                                                    </td>
                                                    <td>
                                                        :&nbsp;<asp:Label ID="lblTestFeePaid" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Drugs Issued
                                                    </td>
                                                    <td>
                                                        :&nbsp;<asp:Label ID="lblDIssued" runat="server"></asp:Label>
                                                        <asp:Label ID="lblVisitId_Save" runat="server" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="center" colspan="3">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <b>Feedback Details</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Registration Entry Service Quality
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rdRegServcQty" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="G">Good</asp:ListItem>
                                                            <asp:ListItem Value="S">Satisfactory</asp:ListItem>
                                                            <asp:ListItem Value="P">Poor</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Doctor Service Quality
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rdDocSrvcQty" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="G">Good</asp:ListItem>
                                                            <asp:ListItem Value="S">Satisfactory</asp:ListItem>
                                                            <asp:ListItem Value="P">Poor</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Pharmacy Service Quality
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rdPharSrvcQty" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="G">Good</asp:ListItem>
                                                            <asp:ListItem Value="S">Satisfactory</asp:ListItem>
                                                            <asp:ListItem Value="P">Poor</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Free Drugs Issued
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rdFreeDrugsIssued" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="N">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Drugs Purchased from outside
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rdDrugsPurFrmOutside" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="N">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Clealiness in Hospital
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rdCleanlinessInHosp" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="G">Good</asp:ListItem>
                                                            <asp:ListItem Value="S">Satisfactory</asp:ListItem>
                                                            <asp:ListItem Value="P">Poor</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Over all experience
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rdOverallExp" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="G">Good</asp:ListItem>
                                                            <asp:ListItem Value="S">Satisfactory</asp:ListItem>
                                                            <asp:ListItem Value="P">Poor</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Registration Fee Paid (Rs.) &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRegFee" runat="server" MaxLength="4"></asp:TextBox>
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                                            FilterType="Numbers" TargetControlID="txtRegFee">
                                                        </ajax:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Test/Operation/Surgery Fee Paid (Rs.)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTestFee" runat="server" MaxLength="4"></asp:TextBox>
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                                                            FilterType="Numbers" TargetControlID="txtTestFee">
                                                        </ajax:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Any Other Amount Paid (Rs.)&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAnyOthrAmt" runat="server" MaxLength="4"></asp:TextBox>
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True"
                                                            FilterType="Numbers" TargetControlID="txtAnyOthrAmt">
                                                        </ajax:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <%--</contenttemplate>
                    </asp:UpdatePanel>--%>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="btnSubmit" runat="server" Height="30px" Text="Submit Feedback" OnClick="btnSubmit_Click"
                        Visible="false" />
                    <asp:Button ID="btnCloseFb" runat="server" Height="30px" Text="Close Feedback" OnClick="btnCloseFb_Click"
                        OnClientClick="return Confirm(this)" Visible="false" />
                    <ajax:ModalPopupExtender ID="mpCloseFb" runat="server" PopupControlID="PnlCloseFb"
                        CancelControlID="imgBtnClose" TargetControlID="HiddenField_CloseFb" BackgroundCssClass="modalBackground">
                    </ajax:ModalPopupExtender>
                    <asp:HiddenField ID="HiddenField_CloseFb" runat="server" />
                    <asp:Panel ID="PnlCloseFb" Style="display: none" runat="server">
                        <div style="width: 500px; overflow: auto">
                            <table width="500px" bgcolor="White">
                                <tr>
                                    <td align="center" style="border-bottom: 1px solid green">
                                        <h3>
                                            <b>Close Feedback</b></h3>
                                    </td>
                                    <td align="right" style="border-bottom: 1px solid green">
                                        <asp:ImageButton ID="imgBtnClose" runat="server" ImageUrl="~/images/close.jpg" Width="40px"
                                            Height="40px" CausesValidation="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <table cellpadding="3" cellspacing="1" style="border: 1px solid lime;">
                                            <tr>
                                                <td>
                                                    <b>Reasons to close feedback :</b>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rdCloseFb" runat="server">
                                                        <asp:ListItem Value="Call Drop">Call Drop</asp:ListItem>
                                                        <asp:ListItem Value="Citizen not Interested">Citizen not Interested</asp:ListItem>
                                                        <asp:ListItem Value="Other person visted hospital">Other person visted hospital</asp:ListItem>
                                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    <asp:Button ID="btnCloseFb_PopUp" runat="server" CssClass="fldbtn" OnClick="btnCloseFb_PopUp_Click"
                                                        Text="Close Feedback" Height="30px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 10px;" colspan="4">
                    <Footer:footer ID="footer" runat="server"></Footer:footer>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
