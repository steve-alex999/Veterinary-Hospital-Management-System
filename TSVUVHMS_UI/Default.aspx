<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="VhmsHome" %>
<%@ Register TagPrefix="Menu" TagName="Menu" Src="~/DefaultMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
   
    <title>VHMS Home</title>
    <!-- BOOTSTRAP CORE STYLE  -->
    <link href="BS/css/bootstrap.css" rel="stylesheet" />
    <!-- FONT AWESOME ICONS  -->
    <link href="BS/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLE  -->
    <link href="BS/css/style.css" rel="stylesheet" />
    <script src="BS/js/jquery-latest.js" type="text/javascript"></script>
    <script src="Bs/js/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="Bs/js/bootstrap.js" type="text/javascript"></script>
</head>
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
<body>
    <form id="form1" runat="server">
    <header>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <input type="button" class="increase" value=" A+ ">
                    <input type="button" class="decrease" value=" A- " />
                    <input type="button" class="resetMe" value=" A=">
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
            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2">
                <a class="navbar-brand" href="#">
                    <asp:Image ImageUrl="~/img/goi.png" Height="120px" runat="server" Width="120px" Style="margin-top: -23px;"
                        ID="imgstate" />
                </a>
            </div>
            <div class="col-md-8 col-lg-8 col-sm-8 col-xs-8" style="margin-top: 40px;" align="middle">
                <font size="5px" align="center" style="font-family: Calibri, Georgia, Serif;
                    text-shadow: 1.5px 1px white;"><b>VETERINARY HOSPITAL MANAGEMENT SYSTEM</b></font>
                <br>
                <br>
                <font size="5px" align="center" style="font-family: Calibri, Georgia, Serif;
                    text-shadow: 1.5px 1px white;"><b>DEPARTMENT OF ANIMAL HUSBANDRY </b></font>
                <br><br />
                <font size="5px" align="center" style="font-family: Calibri, Georgia, Serif;
                    text-shadow: 1.5px 1px white;"><b><asp:Label ID="lblstatename" runat="server" Text="Label"></asp:Label> <%--DEPARTMENT OF ANIMAL HUSBANDRY --%></b></font>
            </div>
            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2" style="padding-left: 70px;">
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
                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
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
    
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                <h4 class="page-head-line">
                    Dashboard</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 text-center">
                <b>Financial Year :</b> &nbsp;<b><asp:Label ID="lblFinYear" runat="server"></asp:Label></b>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3 col-sm-3 col-xs-6">
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
            <div class="col-md-3 col-sm-3 col-xs-6">
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
            <div class="col-md-3 col-sm-3 col-xs-6">
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
            <div class="col-md-3 col-sm-3 col-xs-6">
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
            <div class="col-md-12">
                <h4 class="arrow">
                    Veterinary Hospital Management System</h4>
                <br />
                <p>
                    VHMS Provides for computerization of main functions of veterinary hospitals like
                    Registration, Drug inventory, Drugs issue to patients, Diagnostics, Billing and
                    MIS reports to management for effective super vision over hospital services.</p>
            </div>
        </div>
    </div>
    <!-- </div>
    <!--SCRIPT START-->
    <script type="text/javascript">
        function myFunction1() {
            document.getElementById("container").style.backgroundColor = "#f5bbf3";
        }


        function myFunction2() {
            document.getElementById("container").style.backgroundColor = "#fff";
        }

        function myFunction3() {
            document.getElementById("container").style.backgroundColor = "rgb(59, 114, 183)";
        }
    </script>
    <script type="text/javascript">
        function font() {
            document.getElementById("container").style.fontSize = "large";
        }


        function font1() {
            document.getElementById("container").style.fontSize = "1em";
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var originalSize = $('div').css('font-size');
            // reset
            $(".resetMe").click(function () {
                $('div').css('font-size', originalSize);

            });

            // Increase Font Size
            $(".increase").click(function () {
                var currentSize = $('div').css('font-size');
                var currentSize = parseFloat(currentSize) * 1.2;
                $('div').css('font-size', currentSize);

                return false;
            });

            // Decrease Font Size
            $(".decrease").click(function () {
                var currentFontSize = $('div').css('font-size');
                var currentSize = $('div').css('font-size');
                var currentSize = parseFloat(currentSize) * 0.8;
                $('div').css('font-size', currentSize);

                return false;
            });
        });
    </script>
    <script type="text/javascript">
<input type="button" onClic="changebackColor">

function changebackColor(){
document.body.style.backgroundColor = "black";
document.getElementByID("divID").style.backgroundColor = "black";      
window.setTimeout("yourFunction()",10000);
}
    </script>
    <!--SCRIPT END-->
    <!-- CONTENT-WRAPPER SECTION END-->
    <footer>
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    Designed, Developed and Hosted by National Informatics Centre, Hyderabad.
                </div>
            </div>
        </div>
    </footer>
    </form>
</body>
</html>
