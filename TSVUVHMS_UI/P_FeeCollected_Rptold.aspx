<%@ Page Language="C#" AutoEventWireup="true" CodeFile="P_FeeCollected_Rptold.aspx.cs"
    Inherits="P_FeeCollected_Rpt" %>

<%@ Register TagPrefix="Menu" TagName="Menu" Src="~/Admin.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Language" content="en-us"/>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252"/>
    <title>Vhms</title>
    <script src="scripts/jquery.min.js" type="text/javascript"></script>
  <script src="scripts/jquery-ui.js" type="text/javascript"></script>
   <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/ui-lightness/jquery-ui.css" />
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
   
    <script type="text/javascript">
    </script>
    <style type="text/css">
        .fld
        {
            border: solid 1px #eeeeee;
            padding: 6px;
        }
        
        .highlight
        {
            text-decoration: none;
            color: black;
            background: yellow;
        }
    </style>
    <script type="text/javascript">
        function noBack() {
            window.history.forward()
        }
        noBack();
        window.onload = noBack;
        window.onpageshow = function (evt) {
            if (evt.persisted) noBack()
        }
        window.onunload = function () { void (0) }
    </script>
    <script type="text/javascript">
        function CancelReturnKey() {
            if (window.event.keyCode == 13)
                return false;
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
<body background="../images/top-rept.jpg" onkeypress="return CancelReturnKey();"
    onload="DisableBackButton(){ void (0); }">
    <script type="text/javascript">
        function validateReg() {
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate();
            }
            if (Page_IsValid) {
                var newpwd = document.getElementById('txtNpwd').value;
                if (newpwd != '') {
                    var oldpwd = document.getElementById('txtOpwd').value;
                    document.getElementById('txtOldPwdHash').value = '';
                    document.getElementById('txtNewPwdHash').value = '';
                    var keyGenrate = '<%= ViewState["keyGen"]%>';
                    var myval1 = SHA1(oldpwd);
                    var myval = SHA1(keyGenrate);
                    var myval2 = SHA1(newpwd);
                    document.getElementById('txtOpwd').value = '**********';
                    document.getElementById('txtNpwd').value = '**********';
                    document.getElementById('txtCpwd').value = '**********';
                    document.getElementById('txtOldPwdHash').value = SHA1(myval1 + myval);
                    document.getElementById('txtNewPwdHash').value = myval2;
                }
            }

        }
        function validateCustomReg(oSrc, args) {
            var psw = document.getElementById('txtNpwd').value;
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
     <script type="text/javascript">
         $(document).ready(function () {
             $('.style_txt_entry').datepicker({
                 dateFormat: 'dd-mm-yy',
                 maxDate: new Date(),
                 showOn: "button",
                 buttonImage: "Images/calendar.jpg",
                 buttonImageOnly: true,
                 buttonText: "Select date",
                 changeMonth: true,
                 changeYear: true,
                 yearRange: "-10:+0"
             });
         });

           
    </script>
    <form id="Form1" runat="server" autocomplete="off">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <table border="0" width="982px" cellspacing="0" cellpadding="0" bgcolor="#F5F5F5">
            <tr>
                <td colspan="2">
                    <img alt="" class="style63" src="images/header.PNG" />
                </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#08714A">
                    <Menu:Menu ID="Menu" runat="server"></Menu:Menu>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" bgcolor="#f0f8e6">
                    <table style="width: 100%">
                        <tr>
                            <td bgcolor="#3399FF" style="color: White;" align="left">
                                <table align="center" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" style="background-color: White; height: 30px;">
                                        </td>
                                        <td align="right" bgcolor="White">
                                            <span style="color: green;">Date ::</span> &nbsp; <span>
                                                <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center" style="background-color: #59ACAC; color: White; height: 30px;
                                            font-size: larger;">
                                            Date Wise Fee Collected Report
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#99CCFF">
                                <table cellpadding="3" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td align="center" colspan="3" bgcolor="white">
                                            <%-- <asp:UpdatePanel ID="up1" runat="server">
                                                <ContentTemplate>--%>
                                            <div align="center">
                                                <table align="center" width="80%">
                                                    <tr>
                                                        <td align="center">
                                                            <table align="center" width="100%">
                                                                <tr>
                                                                    <td width="20%" align="right">
                                                                        District :&nbsp;
                                                                    </td>
                                                                    <td width="40%" align="left">
                                                                        <asp:DropDownList ID="ddlDist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDist_OnSelectedIndexChanged"
                                                                            Width="180px" Height="33px">
                                                                            <asp:ListItem>Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlState" runat="server" Width="10px" Height="33px" Visible="false">
                                                                            <asp:ListItem>Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="right" width="20%">
                                                                        Institution :
                                                                    </td>
                                                                    <td align="left" width="40%">
                                                                        <asp:DropDownList ID="ddlInst" runat="server" Width="250px" Height="33px">
                                                                            <asp:ListItem>Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" width="20%">
                                                                        From Date:
                                                                    </td>
                                                                    <td align="left" width="40%">
                                                                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="style_txt_entry" OnTextChanged="txtFromDtChanged" AutoPostBack="true"></asp:TextBox>
                                                                    </td>
                                                                    <td align="right" width="20%">
                                                                        To Date:
                                                                    </td>
                                                                    <td align="left" width="40%">
                                                                        <asp:TextBox ID="txtToDt" runat="server" CssClass="style_txt_entry" OnTextChanged="txtFromDtChanged" AutoPostBack="true"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" align="center">
                                                                        <asp:Button ID="Button1" runat="server" Height="30px" OnClick="btnSubmit_Click" Text="Submit" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" align="center">
                                                                        <asp:Label ID="lblNoRecordFound" runat="server" Font-Bold="True" ForeColor="Red"
                                                                            Visible="False"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" align="right">
                                                                        <asp:ImageButton ID="btnImgprint" Visible="false" runat="server" Width="4%" ToolTip="Print Report"
                                                                            ImageUrl="~/images/print-button.png" OnClick="btnImgprint_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" align="center">
                                                                        <table align="center" style="width: 800px">
                                                                            <tr>
                                                                                <td>
                                                                                    <rsweb:ReportViewer ID="RptFeeCollected" Width="100%" runat="server" SizeToReportContent="true"
                                                                                        ShowPrintButton="true">
                                                                                    </rsweb:ReportViewer>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <%-- </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <Footer:footer ID="footer" runat="server"></Footer:footer>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
