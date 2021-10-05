<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="EVHMS_UI_Admin_Admin" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../styles/main.css" rel="Stylesheet" type="text/css" media="all" />
    <link href="../styles/style.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-min.js.js" type="text/javascript"></script>
    <script src="../scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="../scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <script src="scripts/sha1.js" type="text/javascript"></script>
    <style type="text/css">
       
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
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center" >
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
                            <td align="right">
                                Date ::<asp:Label ID="lblDate" runat="server" Font-Bold="true" ForeColor="#ab7d44"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="background-color: #59ACAC; color: #FFFFFF;
                                font-family: 'Times New Roman', Times, serif; font-size: large;" width="100%">
                                District Master
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="padding-top: 10px;" align="center">
                    Welcome to Administrator</td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    &nbsp;</td>
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
