<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rpt_TodayPatientHistory.aspx.cs"
    Inherits="Rpt_TodayPatientHistory" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>VHMS</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <script src="../scripts/JQuery-min.js.js" type="text/javascript"></script>
    <script src="../scripts/jquery-ui.js" type="text/javascript"></script>     
    <link href="../BS/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <!-- BOOTSTRAP CORE STYLE  -->
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />
    <!-- FONT AWESOME ICONS  -->
    <link href="../BS/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLE  -->
    <link href="../BS/css/style.css" rel="stylesheet" />
 
    <script src="../BS/js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
     <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
        rel="stylesheet" type="text/css" />
  
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=GvPatientDtls]').footable();
        });
    </script>
  <script type="text/javascript">


      $(function () {
          $("#txtDate").datepicker({
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
    <style type="text/css">
        label
        {
            color: #333;
        }
        .footable a
        {
            color: #333;
        }  
        </style>
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
    <script type="text/javascript">
        window.history.forward(1);
        function noBack() {
            window.history.forward();
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
        window.history.forward(1);
        function noBack() {
            window.history.forward();
        }
        function Confirm(link) {
            if (confirm("Once clicked as seen , record will disappear from the list , Are you sure to mark record as seen?")) {
                return true;
            }
            else
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
  
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <header>
        <div class="container">
            <div class="form-group">
                <div class="col-md-12">
                    <input type="button" class="increase" value=" A+ ">
                    <input type="button" class="decrease" value=" A- " />
                    <input type="button" class="resetMe" value=" A="/>
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
                              <%--  <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" RenderingMode="List"
                                    IncludeStyleBlock="false" StaticMenuStyle-CssClass="nav navbar-nav" DynamicMenuStyle-CssClass="dropdown-menu">
                                </asp:Menu>--%>
                                  <Menu:Menu ID="Menu1" runat="server"></Menu:Menu>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <div class="form-group">
    <div class="col-md-4 text-left">
     <span style="color: green;">Logged As ::</span> &nbsp; <span>
                                                <asp:Label ID="lblUsrName" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
    </div>
     <div class="col-md-4 text-center">
     <span style="color: green;">Institution Name ::</span> &nbsp; <span>
                                                <asp:Label ID="lblInsName" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
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
            <div class="col-md-10  col-sm-10" id="card" style="margin-top: 0">
                <div class="card-header">
                    <span class="card-title">Patient History </span>
                </div>
                <div class="col-md-12 col-md-12 col-sm-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                        </div>
                          <div class="form-group">
                         <div class="col-md-2  text-right"><label>Date:</label></div>
                         <div class="col-md-3 text-left">  <asp:TextBox ID="txtDate" 
                                        runat="server" CssClass="form-control style_txt_entry" ontextchanged="txtDate_TextChanged" AutoPostBack="true"></asp:TextBox></div>
                         <div class="col-md-1  text-center"><label>(OR)</label></div>
                          <div class="col-md-2  text-right"><label> Registration No :</label></div>
                         <div class="col-md-3 text-left"> <asp:TextBox ID="txt_FregNo" runat="server" MaxLength="15" ontextchanged="txtDate_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                                        FilterType="Numbers" TargetControlID="txt_FregNo">
                                    </ajax:FilteredTextBoxExtender></div>
                         <div class="col-md-1  text-center"><asp:Button ID="btnSearch" runat="server" Height="30px" Text="Search" OnClick="btnSearch_Click" class="btn-primary" /></div>
                        </div>
                    <%--    <div class="form-group">
                         <div class="col-md-4  text-right">
                                Date:<asp:TextBox ID="txtDate" 
                                        runat="server" CssClass="form-control style_txt_entry" ontextchanged="txtDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    (OR)
                            </div>
                            <div class="col-md-4 text-left">
                              Registration Number :
                                    <asp:TextBox ID="txt_FregNo" runat="server" MaxLength="15" ontextchanged="txtDate_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                                        FilterType="Numbers" TargetControlID="txt_FregNo">
                                    </ajax:FilteredTextBoxExtender>
                            </div>     
                            <div class="col-md-4 text-left">
                                        <asp:Button ID="btnSearch" runat="server" Height="30px" Text="Search" OnClick="btnSearch_Click" class="btn-success" /> 
                            </div> 
                                                                          
                        </div>--%>
                        
                       
                        <div class="form-group">
                            <div class="col-md-12 text-center">
                                <asp:GridView ID="GvPatientDtls" runat="server" AllowPaging="True" AutoGenerateColumns="False"                                        
                                        CellPadding="3" CellSpacing="2" CssClass="footable"
                                         PageSize="5" Width="874px" OnPageIndexChanging="GvPatientDtls_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reg No">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkgetregno" runat="server" ForeColor="Blue" OnClick="lnkRegNo_Click"
                                                        Text='<%#Eval("RegistrationNo")%>'></asp:LinkButton>
                                                    <asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("RegistrationNo") %>' Visible="false"></asp:Label>
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
                                                    <asp:Label ID="lblAnimal" runat="server" Text='<%# Bind("AnimalTypeDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Breed">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBreed" runat="server" Text='<%# Bind("BreedName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Age">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAge" runat="server" Text='<%# Bind("Age") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle HorizontalAlign="Center" />
                                        <EmptyDataTemplate>
                                            No Records
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 col-md-12 col-sm-12 table-responsive">
                                <div class="col-md-1">
                                </div>
                                <div class="col-md-1">
                                </div>
                            </div>
                        </div>
                         <div class="form-group">
                            <div class="col-md-12 text-right">
                                <%--<asp:ImageButton ID="btnImgprint" Visible="false" runat="server"  ToolTip="Print Report"
                                                                            ImageUrl="~/images/print-button.png"  />--%>
                                <asp:ImageButton ID="btnImgprint" Visible="false" runat="server" Width="4%" ToolTip="Print Report"
                                    ImageUrl="~/images/print-button.png" OnClick="btnImgprint_Click" /><asp:Label ID="lblParam" runat="server" Visible="false"></asp:Label>
                            </div>
                        </div>

                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="400px" >
                          <div class="form-group">
                            <div class="col-md-12 text-center">
                                <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server">
                                </rsweb:ReportViewer>--%>
                                <rsweb:ReportViewer ID="Report_PatientHistory" Width="100%" Height="100%" runat="server" SizeToReportContent="true"
                                                 ShowPrintButton="true">
                                            </rsweb:ReportViewer>
                            </div>
                        </div>
                        </asp:Panel>  

                        <div class="form-group">
                            <div class="col-md-2  text-right">
                                <label for="ddlfinyear">
                                    Doctor's  observation:</label>
                            </div>
                            <div class="col-md-4 text-left">
                             
                                    <asp:TextBox ID="txtObservation" runat="server" Height="183px" Width="400px" CssClass="form-control" TextMode="MultiLine"
                                                                           ></asp:TextBox>
                            </div>
                            <div class="col-md-2  col-md-offset-1 text-right">
                                <label >
                                      Disease:<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                            <div class="row">
                            <div class="col-md-12">
                               
                               <asp:DropDownCheckBoxes ID="ddl_Dieases" runat="server" AddJQueryReference="True" CssClass="form-control"
                                                                            OnSelectedIndexChanged="ddl_Dieases_SelectedIndexChanged" Style="height: 43px;
                                                                            top: 0px; left: 110px; width: 100px;" UseButtons="True" UseSelectAllNode="True">
                                                                            <Texts SelectBoxCaption="Select Dieases" />
                                                                        </asp:DropDownCheckBoxes>
                                                                           <asp:Label ID="lblDcode" runat="server" Visible="False"></asp:Label>
                                                                        <label><asp:Label ID="lblDName" runat="server"></asp:Label></label> </div>
                            </div>
                            </div>
                        </div>

                         <div class="form-group">
                            <div class="col-md-12 text-center">
                               <asp:Button ID="btnSeen" runat="server" Height="30px" Text="Seen" OnClick="btnSeen_Click" class="btn-success" Visible="false" OnClientClick="return Confirm(this)" /> 
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
                 <div class="col-md-12 text-center">
                      <Footer:footer ID="footer" runat="server"></Footer:footer>
                </div>
            </div>
        </div>
    </footer>

    </form>
</body>
</html>
