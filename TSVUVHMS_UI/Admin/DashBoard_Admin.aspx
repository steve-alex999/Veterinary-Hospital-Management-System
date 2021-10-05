<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashBoard_Admin.aspx.cs"
    Inherits="DashBoard_Admin" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
   
    <title>VHMS Home</title>
    <!-- BOOTSTRAP CORE STYLE  -->
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />
    <!-- FONT AWESOME ICONS  -->
    <link href="../BS/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLE  -->
    <link href="../BS/css/style.css" rel="stylesheet" />
    <script src="../BS/js/jquery-latest.js" type="text/javascript"></script>
    <script src="../Bs/js/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../Bs/js/bootstrap.js" type="text/javascript"></script>
    <style type="text/css">
        #card:hover{
    box-shadow: 0 3px 10px #777;
    transition:all 100ms ease;
    
}

    #card .card-header 
    {
      
         background-color:#b6c67c;
      /* background-color: #1b98d4;
      background-color:#b6c67c;*/
        text-align: center;
          margin-top: 0px;
       
    }

    #card .card-title {
        font-size: 20px;
        color: #fff;
        line-height: 2;
         margin-top: 0px;
    }
 .form-group
        {
            overflow: auto !important;
        }
        
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
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
        <div class="form-group">
    <div class="col-md-6 text-left">
     <span style="color: green;">Logged As ::</span> &nbsp; <span>
                                                <asp:Label ID="lblUsrName" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
    </div>
     <div class="col-md-6 text-right">
     <span style="color: green;">Date ::</span> &nbsp; <span>
                                                <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
    </div>
    </div>
    <!-- MENU SECTION END
    <div class="content-wrapper">-->
    <br />
      <div class="panel-heading">
        <div class="row">
            
            <div class="col-md-12" id="card" style="margin-top: 0">
                <div class="card-header">
                    <span class="card-title"> Dashboard </span>
                </div>                
           
    <div class="container">
      
       <%-- <div class="row">
            <div class="col-md-12">
                <h4 class="page-head-line">
                    Dashboard</h4>
            </div>
        </div>--%>
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
            <div class="col-md-3 col-sm-3 col-xs-6">
                <div class="dashboard-div-wrapper
        bk-clr-one">
                    <div class="small-box bg-teal">
                        <div class="inner">
                            <center> <i class="fa fa-medkit" aria-hidden="true"></i><p style="color:
        #FFFFFF"> No.of Institutions Enrolled </p> <h3 id="H3"> <asp:Label ID="lblTotEnrollments"
        ForeColor="Black" runat="server" Text=""></asp:Label></h3> </center>
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
                       <%-- <div class="panel-footer text-muted">--%>
                            <asp:LinkButton ID="lnkInst" class="small-box-footer" runat="server" OnClick="LnkBtnMoreInfo_Click"
                                CommandArgument="I">More info&nbsp;</asp:LinkButton>
                            <i class="fa fa-arrow-circle-right"></i>
                      <%--  </div>--%>
                    </div>
                    <%-- </div>--%>
                </div>
            </div>
            <div class="col-md-3 col-sm-3 col-xs-6">
                <div class="dashboard-div-wrapper
    bk-clr-two">
                    <div class="small-box bg-grass">
                        <div class="inner">
                            <center><i class="fa fa-hospital-o" aria-hidden="true"></i> <p style="color:
    #FFFFFF"> OP-Registrations </p> <h3 id="H4"> <asp:Label ID="lblNewReg" ForeColor="Black"
    runat="server" Text=""></asp:Label></h3> </center>
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

                        <asp:LinkButton ID="lnkNewReg" class="small-box-footer" runat="server" OnClick="LnkBtnMoreInfo_Click"
                            CommandArgument="N">More info&nbsp;
                        </asp:LinkButton><i class="fa fa-arrow-circle-right"></i>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-3 col-xs-6">
                <div class="dashboard-div-wrapper bk-clr-three">
                    <div class="small-box bg-aqua">
                        <div class="inner">
                            <center> <i class="fa fa-hospital-o" aria-hidden="true"></i><p style="color: #FFFFFF">
   OP-Revisits </p> <h3 id="H1"> <asp:Label ID="lblRevist" ForeColor="Black" runat="server"></asp:Label></h3>
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
                        <asp:LinkButton ID="lnkReVisit" class="small-box-footer" runat="server" OnClick="LnkBtnMoreInfo_Click"
                            CommandArgument="R">More info &nbsp;</asp:LinkButton><i class="fa fa-arrow-circle-right"></i>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-3 col-xs-6">
                <div class="dashboard-div-wrapper
    bk-clr-four">
                    <div class="small-box bg-wood">
                        <div class="inner">
                            <center> <i class="fa fa-inr" aria-hidden="true"></i><p style="color:
    #FFFFFF"> Value of Drugs Issued (Rs.) </p> <h3 id="H2"> <asp:Label ID="lblTotalValueofdrug"
    ForeColor="Black" runat="server"></asp:Label></h3> </center>
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
                        <asp:LinkButton ID="lnkDrug" class="small-box-footer" runat="server" OnClick="LnkBtnMoreInfo_Click"
                            CommandArgument="D">More info &nbsp;</asp:LinkButton><i class="fa fa-arrow-circle-right"></i>
                    </div>
                </div>
            </div>
        </div>
     </div></div> </div>
            
        </div>
    
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
                    <div class="col-md-12">
                        Designed, Developed and Hosted by National Informatics Centre, Hyderabad.
                    </div>
                </div>
            </div>
        </footer>
    </form>
</body>
</html>
