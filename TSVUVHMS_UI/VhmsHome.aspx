<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VhmsHome.aspx.cs" Inherits="VhmsHome" %>

<%@ Register TagPrefix="Menu" TagName="Menu" Src="~/DefaultMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
  
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" >
 <%--   <meta name="viewport" content="width=device-width, initial-scale=1">--%>
 
    <meta name="description" content="" />
    <meta name="author" content="" />
    <%--<script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>--%>
   <%-- <script type="text/javascript" src="/jsFile.js"></script>--%>
     <%-- <script src="BS/js/jquery-latest.js" type="text/javascript"></script>--%>
     <script    src="js/jquery-1.8.3-jquery.min.js" type="text/javascript"></script>
     <%--  <script src="Bs/js/jquery-1.11.1.js" type="text/javascript"></script>--%>
    <script src="Bs/js/bootstrap.js" type="text/javascript"></script>
   <%-- <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>

  <%--  <meta name="viewport" content="width=device-width, initial-scale=1.0" />--%>
    <title>VHMS Home</title>
    <!-- BOOTSTRAP CORE STYLE  -->
    <link href="BS/css/bootstrap.css" rel="stylesheet" />
    <!-- FONT AWESOME ICONS  -->
    <link href="BS/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLE  -->
    <link href="BS/css/style.css" rel="stylesheet" />
  
   
    <style type="text/css">
        
        
        .panel-footer
        {
            background-color: transparent !important;
            border: 1px solid #fff;
            border-radius: 4px;
        }
        

        .small-box {
    transition: all 0.3s cubic-bezier(0.25, 0.8, 0.25, 1) 0s;
    border-radius: 20px !important;
    box-shadow: 0 10px 10px rgba(0, 0, 0, 0.12), 0 10px 10px rgba(0, 0, 0, 0.24);
}

.small-box > .inner {
    padding: 10px;
}

.small-box .icon {
    position: absolute;
    top: auto;
    bottom: 8px;
    right: 5px;
    z-index: 0;
    font-size: 70px;
    color: rgba(0, 0, 0, 0.15);
}



    </style>

    <script type="text/jscript">
        $(function () {
            var nua = navigator.userAgent
            var isAndroid = (nua.indexOf('Mozilla/5.0') > -1 && nua.indexOf('Android ') > -1 && nua.indexOf('AppleWebKit') > -1 && nua.indexOf('Chrome') === -1)
            if (isAndroid) {
                $('select.form-control').removeClass('form-control').css('width', '100%')
            }
        })
</script>
</head>
<body>
    <form id="form1" runat="server">
    <header>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                <input type="button" class="decrease" value=" A- " />
                 <input type="button" class="resetMe" value=" A= " />
                    <input type="button" class="increase" value=" A+ ">
                    
                   
                    <button onclick="document.body.style.backgroundColor = '#dff0d8';">
                        T</button>
                    <button onclick="document.body.style.backgroundColor = 'rgba(103, 58, 183, 0.28)';">
                        T</button>
                    <button onclick="document.body.style.backgroundColor = '#fff';">
                        T</button>
                </div>
            </div>
        </div>
    </header>
    <!-- HEADER END-->
    <div class="navbar navbar-inverse set-radius-zero">
        <div class="container">
            <div class="col-md-2">
                <a class="navbar-brand" href="#">
                    <asp:Image src="img/goi.png" Height="120px" runat="server" Width="120px" Style="margin-top: -23px;" />
                </a>
            </div>
            <div class="col-md-8" style="margin-top: 40px;" align="middle">
                <font size="5px" align="center" style="font-family: Calibri, Georgia, Serif;
                    text-shadow: 1.5px 1px white;"><b>VETERINARY HOSPITAL MANAGEMENT SYSTEM</b></font>
                <br>
                <br>
                <font size="5px" align="center" style="font-family: Calibri, Georgia, Serif;
                    text-shadow: 1.5px 1px white;"><b>DEPARTMENT OF ANIMAL HUSBANDRY </b></font>
                      <br>
                <br>  <br>
                
            </div>
            <div class="col-md-2" style="padding-left: 70px;">
                <a class="navbar-brand" href="#">
                    <asp:Image src="img/digital.png" Height="120px" runat="server" Width="120px" Style="margin-top: -23px;" />
                </a>
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
    <!-- LOGO HEADER END-->
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
    <!-- MENU SECTION END
    <div class="content-wrapper">-->
    <br />
    <div class="container">
        <div class="row " style="valign: Topl">
            <div class="col-md-3 col-md-offset-6 text-right">
                <h4>
                    <span style="color: #f0677c;"><b>Select State</b></span></h4>
            </div>
            <div class="col-md-3 text-right">
                <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_OnSelectedIndexChanged"
                    CssClass="form-control">
                   
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h4 class="page-head-line">
                    Dashboard</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-center">
                <b>Financial Year :</b> &nbsp;<b><asp:Label ID="lblFinYear" runat="server"></asp:Label></b>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
            </div>
        </div>
         <div class="row">
            <div class="col-md-3 col-sm-3 col-xs-3">
                <div class="dashboard-div-wrapper bk-clr-one">
                    <div class="small-box bg-teal">
                        <div class="inner">
                            <%--<center>
                                                            <p style="color: #FFFFFF">
                                                                No.of Institutions Enrolled
                                                            </p>
                                                            <h3 id="H3">
                                                                <asp:Label ID="lblTotEnrollments" ForeColor="Black" runat="server" Text=""></asp:Label></h3>
                                                        </center>--%> <center> <i class="fa fa-medkit" aria-hidden="true"></i><p style="color:
        #FFFFFF"> No.of Institutions Enrolled </p> <h3 id="H3"> <asp:Label ID="lblTotEnrollments"
        ForeColor="Black" runat="server" Text=""></asp:Label></h3> </center>
                                                        <div class="row">
                                                        <div class="col-md-3 col-md-offset-2 text-right">Day</div>
                                                        <div class="col-md-1 text-center">:</div>
                                                         <div class="col-md-5 text-left">  <asp:Label ID="lblDayIns" ForeColor="Black" runat="server" Text=""></asp:Label></div>
                                                        </div>
                                                          <div class="row">
                                                        <div class="col-md-5 text-right">Month</div>
                                                        <div class="col-md-1 text-center">:</div>
                                                         <div class="col-md-5 text-left">  <asp:Label ID="lblMnthIns" ForeColor="Black" runat="server" Text=""></asp:Label></div>
                                                        </div>
                                                          <div class="row">
                                                        <div class="col-md-5 text-right">Year</div>
                                                        <div class="col-md-1 text-center">:</div>
                                                         <div class="col-md-5 text-left"> <asp:Label ID="lblYearIns" ForeColor="Black" runat="server" Text=""></asp:Label></div>
                                                        </div>
                     
                        </div>
                        <asp:LinkButton ID="lnkInst" class="small-box-footer" runat="server" OnClick="LnkBtnMoreInfo_Click"
                            CommandArgument="I">More info</asp:LinkButton>
                        <i class="fa fa-arrow-circle-right"></i>
                    </div>
                    <%-- </div>--%>
                </div>
            </div>
            <div class="col-md-3 col-sm-3 col-xs-3">
                <div class="dashboard-div-wrapper bk-clr-two">
                    <div class="small-box bg-grass">
                        <div class="inner">
                        <%--    <center>
                                                            <p style="color: #FFFFFF">
                                                                No.of New Registrations
                                                            </p>
                                                            <h3 id="H4">
                                                                <asp:Label ID="lblNewReg" ForeColor="Black" runat="server" Text=""></asp:Label></h3>
                                                        </center>--%>
                                                         <center><i class="fa fa-hospital-o" aria-hidden="true"></i> <p style="color:
    #FFFFFF"> OP-Registrations </p> <h3 id="H4"> <asp:Label ID="lblNewReg" ForeColor="Black"
    runat="server" Text=""></asp:Label></h3> </center>
                                                           <div class="row">
                                                        <div class="col-md-3 col-md-offset-2 text-right">Day</div>
                                                        <div class="col-md-1 text-center">:</div>
                                                         <div class="col-md-5 text-left">  <asp:Label ID="lblDayNewR" ForeColor="Black" runat="server" Text=""></asp:Label></div>
                                                        </div>
                                                          <div class="row">
                                                        <div class="col-md-5 text-right">Month</div>
                                                        <div class="col-md-1 text-center">:</div>
                                                         <div class="col-md-5 text-left">   <asp:Label ID="lblMnthNewR" ForeColor="Black" runat="server" Text=""></asp:Label></div>
                                                        </div>
                                                          <div class="row">
                                                        <div class="col-md-5 text-right">Year</div>
                                                        <div class="col-md-1 text-center">:</div>
                                                         <div class="col-md-5 text-left">   <asp:Label ID="lblYearNewR" ForeColor="Black" runat="server" Text=""></asp:Label></div>
                                                        </div>
                           
                        </div>
                        <asp:LinkButton ID="lnkNewReg" class="small-box-footer" runat="server" OnClick="LnkBtnMoreInfo_Click"
                            CommandArgument="N">More info</asp:LinkButton><i class="fa fa-arrow-circle-right"></i>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-3 col-xs-3">
                <div class="dashboard-div-wrapper bk-clr-three">
                    <div class="small-box bg-aqua">
                        <div class="inner">
                           <%-- <center>
                                                            <p style="color: #FFFFFF">
                                                                No.of ReVisits
                                                            </p>
                                                            <h3 id="H1">
                                                                <asp:Label ID="lblRevist" ForeColor="Black" runat="server"></asp:Label></h3>
                                                        </center>--%>
                                                         <center> <i class="fa fa-hospital-o" aria-hidden="true"></i><p style="color: #FFFFFF">
   OP-Revisits </p> <h3 id="H1"> <asp:Label ID="lblRevist" ForeColor="Black" runat="server"></asp:Label></h3>
    </center>
                                                          <div class="row">
                                                        <div class="col-md-3 col-md-offset-2 text-right">Day</div>
                                                        <div class="col-md-1 text-center">:</div>
                                                         <div class="col-md-5 text-left">  <asp:Label ID="lblDayRV" ForeColor="Black" runat="server" Text=""></asp:Label></div>
                                                        </div>
                                                          <div class="row">
                                                        <div class="col-md-5 text-right">Month</div>
                                                        <div class="col-md-1 text-center">:</div>
                                                         <div class="col-md-5 text-left">    <asp:Label ID="lblMnthRV" ForeColor="Black" runat="server" Text=""></asp:Label></div>
                                                        </div>
                                                          <div class="row">
                                                        <div class="col-md-5 text-right">Year</div>
                                                        <div class="col-md-1 text-center">:</div>
                                                         <div class="col-md-5 text-left">   <asp:Label ID="lblYearRV" ForeColor="Black" runat="server" Text=""></asp:Label></div>
                                                        </div>
                         
                        </div>
                        <asp:LinkButton ID="lnkReVisit" class="small-box-footer" runat="server" OnClick="LnkBtnMoreInfo_Click"
                            CommandArgument="R">More info</asp:LinkButton><i class="fa fa-arrow-circle-right"></i>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-3 col-xs-3">
                <div class="dashboard-div-wrapper bk-clr-four">
                    <div class="small-box bg-wood">
                        <div class="inner">
                             <center> <i class="fa fa-inr" aria-hidden="true"></i><p style="color:
    #FFFFFF"> Value of Drugs Issued (Rs.) </p> <h3 id="H2"> <asp:Label ID="lblTotalValueofdrug"
    ForeColor="Black" runat="server"></asp:Label></h3> </center>
                                                         <div class="row">
                                                        <div class="col-md-3 col-md-offset-2 text-right">Day</div>
                                                        <div class="col-md-1 text-center">:</div>
                                                         <div class="col-md-5 text-left"> <asp:Label ID="lblDayI" ForeColor="Black" runat="server" Text=""></asp:Label></div>
                                                        </div>
                                                          <div class="row">
                                                        <div class="col-md-5 text-right">Month</div>
                                                        <div class="col-md-1 text-center">:</div>
                                                         <div class="col-md-5 text-left">    <asp:Label ID="lblMnthI" ForeColor="Black" runat="server" Text=""></asp:Label></div>
                                                        </div>
                                                          <div class="row">
                                                        <div class="col-md-5 text-right">Year</div>
                                                        <div class="col-md-1 text-center">:</div>
                                                         <div class="col-md-5 text-left">    <asp:Label ID="lblYearI" ForeColor="Black" runat="server" Text=""></asp:Label></div>
                                                        </div>
                         
                        </div>
                        <asp:LinkButton ID="lnkDrug" class="small-box-footer" runat="server" OnClick="LnkBtnMoreInfo_Click"
                            CommandArgument="D">More info</asp:LinkButton><i class="fa fa-arrow-circle-right"></i>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="notice-board">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                          <i class="fa fa-bell" aria-hidden="true">  <font  style="font-family: Calibri, Georgia, Serif;"><b>Notification</b></font> </i>  
                        
                        </div>
                        <div class="panel-body">
                       
                         <marquee id="MarqueeLeft" direction="up" height="100" onmouseout="this.start();" onmouseover="this.stop();" scrollamount="2" style="text-align: left">
                        <i class="glyphicon glyphicon-hand-right btn-btn-social"></i> <span style="text-align: center; color: maroon; font-family: &quot;segoe ui light&quot;; font-size: 15px;">
                         <strong> VHMS is Being Implemented in Eleven(11) Veterinary Hospitals in Telengana State</strong></span><br/><br/>
                        <i class="glyphicon glyphicon-hand-right"></i> <span style="text-align: center; color: maroon; font-family: &quot;segoe ui light&quot;; font-size: 15px;">
                         <strong> UttaraKhand State is Ready To Implement VHMS in 100 Veterinary Hospitals </strong></span><br/><br/>
                         <i class="glyphicon glyphicon-hand-right"></i><span style="text-align: center; color: maroon; font-family: &quot;segoe ui light&quot;; font-size: 15px;">
                         <strong> Super Speciality Veterinary Hospital,Vijayawada ,Andhara Pradesh is planning To Implement VHMS </strong></span><br></marquee>&nbsp;
                        </div>
                    </div>
                </div>
                <hr />
                <div class="table-responsive">
                  
                    <div class="row">
                        <div class="col-md-12 table-responsive">
                           
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <asp:GridView ID="gvstatus" CssClass="table table-striped table-bordered table-condensed"
                    runat="server" AutoGenerateColumns="False">
                    <HeaderStyle CssClass="success" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sl.No">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex +
    1 %>' runat="server" /></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="State
    Name">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblstatname" Text='<%#Eval("StateName")
    %>'></asp:Label>
                                <asp:Label runat="server" ID="lblstatecd" Text='<%#Eval("StateCode")
    %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Authority Name" Visible="false">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblauthname" Text='<%#Eval("Authority_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile No" Visible="false">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblmobileno" Text='<%#Eval("Mobile_No")
    %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Office
    Contact No" Visible="false">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblphoneno" Text='<%#Eval("Phone_no") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblemailid" Text='<%#Eval("Email_id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbladdress" Text='<%#Eval("address") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Requested Date">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblfullcost" Text='<%#Eval("Requested_dt") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblsubsidyamt" Text='<%#Eval("act_status1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pgn" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                </asp:GridView>
                <%-- <div class="Compose-Message"> <div
    class="panel panel-success"> <div class="panel-heading"> On - Boarding Request </div>
    <div class="panel-body"> <label> State Name : </label> <asp:DropDownList ID="ddlonboardstate"
    runat="server" CssClass="form-control" > </asp:DropDownList> <label> Authority Name
    : </label> <input type="text" class="form-control" /> <label> Mobile No : </label>
    <input type="text" class="form-control" /> <label> Office Contact No : </label>
    <input type="text" class="form-control" /> <label> Email ID : </label> <input type="text"
    class="form-control" /> <label> Head Office Address : </label> <input type="text"
    class="form-control" /> <hr /> <asp:Button runat="server" ID="btnsubmit" class="btn
    btn-success" Text="Submit" /> <asp:Button runat="server" ID="btnclear" class="btn
    btn-warning" Text="Clear" /> </div> <div class="panel-footer text-muted"> <strong>Note
    : </strong>Please note that we track all messages so don't send any spams. </div>
    </div> </div> </div>--%>
            </div>
        </div></div>
        <!-- </div> <!--SCRIPT START-->
        <script type="text/javascript">
            function myFunction1() {
                document.getElementById("container").style.backgroundColor
    = "#f5bbf3";
            } function myFunction2() {
                document.getElementById("container").style.backgroundColor
    = "#fff";
            } function myFunction3() {
                document.getElementById("container").style.backgroundColor
    = "rgb(59, 114, 183)";
            } </script>
        <script type="text/javascript">            function font()
            { document.getElementById("container").style.fontSize = "large"; } function font1()
            { document.getElementById("container").style.fontSize = "1em"; } </script>
        <script type="text/javascript"> $(document).ready(function () { var originalSize = $('div').css('font-size');
    // reset $(".resetMe").click(function () { $('div').css('font-size', originalSize);
    }); // Increase Font Size $(".increase").click(function () { var currentSize = $('div').css('font-size');
    var currentSize = parseFloat(currentSize) * 1.2; $('div').css('font-size', currentSize);
    return false; }); // Decrease Font Size $(".decrease").click(function () { var currentFontSize
    = $('div').css('font-size'); var currentSize = $('div').css('font-size'); var currentSize
    = parseFloat(currentSize) * 0.8; $('div').css('font-size', currentSize); return
    false; }); }); </script>
        <script type="text/javascript"> <input type="button" onClic="changebackColor">
    function changebackColor(){ document.body.style.backgroundColor = "black"; document.getElementByID("divID").style.backgroundColor
    = "black"; window.setTimeout("yourFunction()",10000); } </script>
        <!--SCRIPT END-->
        <!-- CONTENT-WRAPPER SECTION END-->
        <footer>
            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <h5> Designed, Developed and Hosted by National Informatics Centre, Hyderabad.</h5>
                    </div>
                </div>
            </div>
        </footer>
    </form>
</body>
</html>
