<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default12122017.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="Menu" TagName="Menu" Src="~/Admin.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta http-equiv="Content-Language" content="en-us">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
    <title>VHMS</title>
    <link href="styles/main.css" rel="Stylesheet" type="text/css" media="all" />
    <link href="styles/style.css" rel="Stylesheet" type="text/css" />
    <script src="scripts/JQuery-min.js.js" type="text/javascript"></script>
    <script src="scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    <link href="css/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <link href="css/Dashhover.css" rel="Stylesheet" type="text/css" />
    <script src="scripts/sha1.js" type="text/javascript"></script>
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
        
        table
        {
            color: #000;
            height: 32px;
        }
    </style>
    <script type="text/javascript">
        window.history.forward(1);
        function noBack() {
            window.history.forward();
        }
    </script>
    <li style="float: right;"><a href='#' id='time'></a></li>
    <script type="text/javascript">
        tday = new Array("Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday");
        tmonth = new Array("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December");

        function GetClock() {
            d = new Date();
            nday = d.getDay();
            nmonth = d.getMonth();
            ndate = d.getDate();
            nyear = d.getYear();
            nhour = d.getHours();
            nmin = d.getMinutes();
            nsec = d.getSeconds();

            if (nyear < 1000) nyear = nyear + 1900;

            if (nhour == 0) { ap = " AM"; nhour = 12; }
            else if (nhour <= 11) { ap = " AM"; }
            else if (nhour == 12) { ap = " PM"; }
            else if (nhour >= 13) { ap = " PM"; nhour -= 12; }

            if (nmin <= 9) { nmin = "0" + nmin; }
            if (nsec <= 9) { nsec = "0" + nsec; }


            document.getElementById('time').innerHTML = "" + tday[nday] + ", " + tmonth[nmonth] + " " + ndate + ", " + nyear + " " + nhour + ":" + nmin + ":" + nsec + ap + "";
            setTimeout("GetClock()", 1000);
        }
        window.onload = GetClock;



                    
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
<body background="">
    <form id="form1" runat="server">
    <div align="center">
        <table border="0" width="982px" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
            <tr>
                <td colspan="2">
                    <img alt="" class="style63" src="images/header.PNG" />
                </td>
            </tr>
            <tr>
                <td height="25" colspan="2">
                    <div align="center">
                        <table border="0" width="100%" cellspacing="0" cellpadding="0">
                            <tr>
                                <td bgcolor="#08714A">
                                    <Menu:Menu ID="Menu" runat="server"></Menu:Menu>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <p align="center">
                        <b><font size="2">
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div align="center">
                        <table border="0" width="100%" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" bgcolor="White" align="right">
                                    <li style="float: right;"><a id="time0" href="#"></a></li>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" bgcolor="White" align="left">
                                    <h1 style="margin: 0px 0px 10px; font-size: 1.5em; font-family: CaviarDreamsBold, Arial, Helvetica, sans-serif;
                                        font-weight: normal; line-height: normal; text-transform: capitalize; color: rgb(3, 54, 148);
                                        font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal;
                                        letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; white-space: normal;
                                        widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
                                        <font color="#800000"></font>
                                    </h1>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <b>Financial Year :</b> &nbsp;<b><asp:Label ID="lblFinYear" runat="server"></asp:Label></b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="White" align="center">
                                    <table align="center">
                                        <tr>
                                            <td style="width: 240px; height: 100px">
                                                <div class="small-box bg-teal">
                                                    <div class="inner">
                                                        <center>
                                                            <p style="color: #FFFFFF">
                                                                No.of Institutions Enrolled
                                                            </p>
                                                            <h3 id="H3">
                                                                <asp:Label ID="lblTotEnrollments" ForeColor="Black" runat="server" Text=""></asp:Label></h3>
                                                        </center>
                                                        Day&nbsp;&nbsp;&nbsp&nbsp; :
                                                        <asp:Label ID="lblDayIns" ForeColor="Black" runat="server" Text=""></asp:Label>
                                                        <br />
                                                        Month :
                                                        <asp:Label ID="lblMnthIns" ForeColor="Black" runat="server" Text=""></asp:Label>
                                                        <br />
                                                        Year&nbsp;&nbsp;&nbsp :
                                                        <asp:Label ID="lblYearIns" ForeColor="Black" runat="server" Text=""></asp:Label>
                                                        <br />
                                                    </div>
                                                    <div class="icon">
                                                        <i class="fa fa-users"></i>
                                                    </div>
                                                    <%--<a href="" class="small-box-footer"> More info <i class="fa fa-arrow-circle-right"></i> </a>--%>
                                                    <asp:LinkButton ID="lnkInst" class="small-box-footer" runat="server" OnClick="LnkBtnMoreInfo_Click"
                                                        CommandArgument="I">More info</asp:LinkButton>
                                                    <i class="fa fa-arrow-circle-right"></i>
                                                </div>
                                            </td>
                                            <td style="width: 240px; height: 100px">
                                                <div class="small-box bg-grass">
                                                    <div class="inner">
                                                        <center>
                                                            <p style="color: #FFFFFF">
                                                                No.of New Registrations
                                                            </p>
                                                            <h3 id="H4">
                                                                <asp:Label ID="lblNewReg" ForeColor="Black" runat="server" Text=""></asp:Label></h3>
                                                        </center>
                                                        Day&nbsp;&nbsp;&nbsp&nbsp; :
                                                        <asp:Label ID="lblDayNewR" ForeColor="Black" runat="server" Text=""></asp:Label>
                                                        <br />
                                                        Month :
                                                        <asp:Label ID="lblMnthNewR" ForeColor="Black" runat="server" Text=""></asp:Label>
                                                        <br />
                                                        Year&nbsp;&nbsp;&nbsp :
                                                        <asp:Label ID="lblYearNewR" ForeColor="Black" runat="server" Text=""></asp:Label>
                                                        <br />
                                                    </div>
                                                    <div class="icon">
                                                        <i class="fa fa-users"></i>
                                                    </div>
                                                    <asp:LinkButton ID="lnkNewReg" class="small-box-footer" runat="server" OnClick="LnkBtnMoreInfo_Click"
                                                        CommandArgument="N">More info</asp:LinkButton>
                                                </div>
                                            </td>
                                            <td style="width: 240px; height: 100px">
                                                <div class="small-box bg-aqua">
                                                    <div class="inner">
                                                        <center>
                                                            <p style="color: #FFFFFF">
                                                                No.of ReVisits
                                                            </p>
                                                            <h3 id="H1">
                                                                <asp:Label ID="lblRevist" ForeColor="Black" runat="server"></asp:Label></h3>
                                                        </center>
                                                        Day&nbsp;&nbsp;&nbsp&nbsp; :
                                                        <asp:Label ID="lblDayRV" ForeColor="Black" runat="server" Text=""></asp:Label>
                                                        <br />
                                                        Month :
                                                        <asp:Label ID="lblMnthRV" ForeColor="Black" runat="server" Text=""></asp:Label>
                                                        <br />
                                                        Year&nbsp;&nbsp;&nbsp :
                                                        <asp:Label ID="lblYearRV" ForeColor="Black" runat="server" Text=""></asp:Label>
                                                        <br />
                                                    </div>
                                                    <div class="icon">
                                                        <i class="fa fa-users"></i>
                                                    </div>
                                                    <asp:LinkButton ID="lnkReVisit" class="small-box-footer" runat="server" OnClick="LnkBtnMoreInfo_Click"
                                                        CommandArgument="R">More info</asp:LinkButton>
                                                </div>
                                            </td>
                                            <td style="width: 240px; height: 100px">
                                                <div class="small-box bg-wood">
                                                    <div class="inner">
                                                        <center>
                                                            <p style="color: #FFFFFF">
                                                                Value of Drugs Issued( Rs.)
                                                            </p>
                                                            <h3 id="H2">
                                                                <asp:Label ID="lblTotalValueofdrug" ForeColor="Black" runat="server"></asp:Label></h3>
                                                        </center>
                                                        Day&nbsp;&nbsp;&nbsp&nbsp; :
                                                        <asp:Label ID="lblDayI" ForeColor="Black" runat="server" Text=""></asp:Label>
                                                        <br />
                                                        Month :
                                                        <asp:Label ID="lblMnthI" ForeColor="Black" runat="server" Text=""></asp:Label>
                                                        <br />
                                                        Year&nbsp;&nbsp;&nbsp :
                                                        <asp:Label ID="lblYearI" ForeColor="Black" runat="server" Text=""></asp:Label>
                                                        <br />
                                                    </div>
                                                    <div class="icon">
                                                        <i class="fa fa-users"></i>
                                                    </div>
                                                    <%--<a href="" class="small-box-footer"> More info <i class="fa fa-arrow-circle-right"></i> </a>--%>
                                                    <asp:LinkButton ID="lnkDrug" class="small-box-footer" runat="server" OnClick="LnkBtnMoreInfo_Click"
                                                        CommandArgument="D">More info</asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" bgcolor="White" align="center">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" bgcolor="White" align="left">
                                    VHMS Provides for computerization of main functions of veterinary hospitals like
                                    Registration, Drug inventory, Drugs issue to patients, Diagnostics, Billing and
                                    MIS reports to management for effective super vision over hospital services.
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" bgcolor="White" align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="center" width="100%">
                                        <tr>
                                            <td style="width: 90%; text-align: right; vertical-align: top;">
                                                <asp:Label ID="Label1" Style="color: #20b2aa; font-size: large; font-weight:bold;" Text="Your Visit No.:"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td valign="top">
                                                <asp:Label ID="lblhitcount" Font-Size="Large" ForeColor="Red" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#08714A">
                                    <div id="copyright" class="clear">
                                        <Footer:footer ID="footer" runat="server"></Footer:footer>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
