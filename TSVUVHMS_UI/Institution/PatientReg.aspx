<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientReg.aspx.cs" Inherits="Patient" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <script src="../scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../scripts/jquery-ui.js" type="text/javascript"></script>
    

     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!-- BOOTSTRAP CORE STYLE  -->
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />
    <!-- FONT AWESOME ICONS  -->
    <link href="../BS/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLE  -->
    <link href="../BS/css/style.css" rel="stylesheet" /> 
    
   <%-- <script src="../BS/js/jquery-latest.js" type="text/javascript"></script>--%>
    
    <script src="../Bs/js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />

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
//          $(document).ready(function () {
//              $("input[id*='txtVdate']").datepicker({
//                  dateFormat: 'dd-mm-yy',
//                  maxDate: new Date(),
//                  minDate: -2,
//                  showOn: "button",
//                  buttonImage: "../Images/calendar.jpg",
//                  buttonImageOnly: true,
//                  buttonText: "Select date",
//                  changeMonth: true,
//                  changeYear: true,
//                  yearRange: "-10:+0"
//              });
//          });
          $(function () {
              $("#txtVdate").datepicker({
                  changeMonth: true,
                  changeYear: true,
                  minDate: -2,
                  dateFormat: 'dd-mm-yy',
                  buttonImageOnly: true,
                  buttonText: "Select date",
                  maxDate: new Date(),
                  yearRange: "-10:+0"
              });
          });
           
    </script>
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
<input type="button" onClic="changebackColor">

function changebackColor(){
document.body.style.backgroundColor = "black";
document.getElementByID("divID").style.backgroundColor = "black";      
window.setTimeout("yourFunction()",10000);
}
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
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
    <div class="row">
        <div class="col-md-4 text-left">
            <img src="../images/14.gif">
            Logged As ::<asp:Label ID="lblUsrName" runat="server" Font-Bold="true" ForeColor="#ab7d44"
                Text=""></asp:Label>
        </div>
        <div class="col-md-4 text-right">
            Institution Name : &nbsp;
            <asp:Label ID="lblInsName" runat="server" Font-Bold="True" ForeColor="#AB7D44"></asp:Label>
        </div>
        <div class="col-md-4 text-right">
            <span style="color: green;">Date ::</span> &nbsp; <span>
                <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
        </div>
    </div>
    <div class="row">
        <div class="col-md-1">
        </div>
        <div class="col-md-10 text-center">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-12  col-sm-12" id="card" style="margin-top: 0">
                        <div class="card-header">
                            <span class="card-title">Patient Registration</span>
                        </div>
                        <div class="form-group">
                        </div>
                        <div class="row">
                            <div class="col-md-3 text-right" style="font-weight:bold;font-size: 12pt;">
                               <label >Visit Date&nbsp;:&nbsp;</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:TextBox ID="txtVdate" runat="server" CssClass="form-control"></asp:TextBox></div>
                            <div class="col-md-5 text-left">
                                <asp:RadioButtonList ID="rblvisttype" runat="server"  AutoPostBack="true"
                                    RepeatDirection="Horizontal" OnSelectedIndexChanged="rblvisttype_SelectedIndexChanged">
                                    <asp:ListItem Text="New Registration" Value="New" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Re-visit" Value="Rev"></asp:ListItem>
                                </asp:RadioButtonList>
                               </div>
                            <%--<div class="col-md-3 text-left">
                               
                            </div>--%>
                        </div><div class="form-group"></div>
                        <div class="row">
                            <asp:Panel ID="Panel2" runat="server" CssClass="form-control">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="col-md-2 text-center">
                                        Registration No</div>
                                    <div class="col-md-2 text-center">
                                        <asp:TextBox ID="txt_FregNo" runat="server" MaxLength="15"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="txt_FregNo_FilteredTextBoxExtender" runat="server"
                                            Enabled="True" TargetControlID="txt_FregNo" FilterType="Numbers">
                                        </ajax:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-md-2 text-center">
                                        (OR)</div>
                                    <div class="col-md-2 text-center">
                                        Mobile No</div>
                                    <div class="col-md-2 text-center">
                                        <asp:TextBox ID="txtRMbno" runat="server" AutoPostBack="True" MaxLength="10"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="txtRMbno_FilteredTextBoxExtender" runat="server"
                                            Enabled="True" TargetControlID="txtRMbno" FilterType="Numbers">
                                        </ajax:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-md-2 text-center">
                                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                                            CssClass="btn-primary" />
                                        <asp:Label ID="lblregno" runat="server" Visible="False"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-1">
                                    </div>
                                    <div class="col-md-10">
                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                    </div>
                                    <div class="col-md-1">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12 text-center">
                                        <asp:GridView ID="GvPatientDtlsMbno" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            OnRowCommand="GvPatientDtlsMbno_RowCommand" OnPageIndexChanging="GvPatientDtlsMbno_PageIndexChanging"
                                            BorderWidth="1px" CellPadding="3" CellSpacing="2" CssClass="table table-bordered table-hover table-striped fnt"
                                            DataKeyNames="RegistrationNo" PageSize="10">
                                            <HeaderStyle CssClass="success text-center" />
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
                                    </div>
                                </div></div>
                            </asp:Panel>
                         
                        </div>
                    <div class="form-group">
                    <div class="col-md-12">
                       <asp:Panel ID="Panel1" runat="server" CssClass="form-control" Height="390px">
                                <div class="form-group">
                                    <div class="col-md-12 text-center">
                                        <b><strong style="color: Red"><span style="color: Red">Animal Details </span></strong>
                                        </b>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12 text-center">
                                        <asp:Label ID="lblRegistrationNo" runat="server" ForeColor="Red" Visible="False"></asp:Label></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 text-right">
                                        Animal Type :
                                    </div>
                                    <div class="col-md-2 text-center">
                                        <asp:DropDownList ID="ddl_AnimalType" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlAnimalType_OnSelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddl_AnimalType"
                                            ErrorMessage="Select Animal Type" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-2 text-right">
                                        Breed :
                                    </div>
                                    <div class="col-md-2 text-center">
                                        <asp:DropDownList ID="ddlBreed" runat="server" CssClass="form-control">
                                            <asp:ListItem>Select Breed</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorBreed" runat="server" ControlToValidate="ddlBreed"
                                            ErrorMessage="Select Breed" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-2 text-right">
                                        Gender :
                                    </div>
                                    <div class="col-md-2 text-center">
                                        <asp:RadioButton ID="rbnMale" runat="server" GroupName="Gender" Text="Male" Checked="True" />
                                        <asp:RadioButton ID="rbnFemale" runat="server" GroupName="Gender" Text="Female" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 text-right">
                                        Age :
                                    </div>
                                    <div class="col-md-2 text-left">
                                        <div class="row">
                                            <div class="col-md-3">
                                                Year</div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="txtAnimalAge" runat="server" MaxLength="2" Width="40px" CssClass="form-control"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="txtAnimalAge_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" FilterType="Numbers" TargetControlID="txtAnimalAge">
                                                </ajax:FilteredTextBoxExtender>
                                            </div>
                                            <div class="col-md-3">
                                                Months</div>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="ddl_AgeMonth" Width="60px" runat="server" CssClass="form-control">
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
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2 text-right">
                                        Last Visit Date:
                                    </div>
                                    <div class="col-md-2 text-center">
                                        <asp:Label ID="lblLastVstDt" runat="server" Text=" - "></asp:Label>
                                    </div>
                                    <div class="col-md-2 text-center">
                                    </div>
                                    <div class="col-md-2 text-center">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12 text-center">
                                        <b><strong style="color: Red"><span style="color: Red">Owner Details </span></strong>
                                        </b>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-2 text-right"> Owner Name :
                                    </div>
                                    <div class="col-md-2 text-center">
                                     <asp:TextBox ID="txtAnimalOwner" runat="server" MaxLength="75" CssClass="form-control"></asp:TextBox>
                                                                        <ajax:FilteredTextBoxExtender ID="txtAnimalOwner_FilteredTextBoxExtender" runat="server"
                                                                            Enabled="True" FilterType="Custom,Numbers,UppercaseLetters,lowercaseLetters"
                                                                            ValidChars=" ." TargetControlID="txtAnimalOwner">
                                                                        </ajax:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-md-2 text-right">&nbsp;State:
                                    </div>
                                    <div class="col-md-2 text-center">
                                      <asp:DropDownList ID="ddl_State" runat="server" AutoPostBack="true" CssClass="form-control"
                                                                            OnSelectedIndexChanged="ddl_State_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 text-right">District :
                                    </div>
                                    <div class="col-md-2 text-center">
                                    <asp:DropDownList ID="ddl_dist_code" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_dist_code_SelectedIndexChanged"
                                                                            CssClass="form-control">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_dist_code"
                                                                            ErrorMessage="Select District" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-2 text-right">
                                     Mandal:
                                    </div>
                                    <div class="col-md-2 text-center">
                                    <asp:DropDownList ID="ddl_mandal_code" runat="server" AutoPostBack="true" CssClass="form-control">
                                                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 text-right">
                                     City/Village:
                                    </div>
                                    <div class="col-md-2 text-center">
                                     <asp:TextBox ID="txtvillage" runat="server" MaxLength="75" CssClass="form-control"></asp:TextBox>
                                                                        <ajax:FilteredTextBoxExtender ID="txtvillage_FilteredTextBoxExtender" runat="server"
                                                                            Enabled="True" TargetControlID="txtvillage" FilterType="Custom,Numbers,UppercaseLetters,lowercaseLetters"
                                                                            ValidChars=" .">
                                                                        </ajax:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-md-2 text-right">
                                     Mobile No :
                                    </div>
                                    <div class="col-md-2 text-center">
                                    <asp:TextBox ID="txtmbno" runat="server" MaxLength="10" onkeypress="return validateMobile(event)" CssClass="form-control"></asp:TextBox>
                                                                        <ajax:FilteredTextBoxExtender ID="txtmbno_FilteredTextBoxExtender" runat="server"
                                                                            Enabled="True" TargetControlID="txtmbno" FilterType="Numbers">
                                                                        </ajax:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                
                                <div class="form-group">
                                    <div class="col-md-2 text-right"> Exempted Category:</div>
                                    <div class="col-md-2 text-left"><asp:RadioButtonList ID="rdExempted" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdExempted_OnSelectedChanged" AutoPostBack="true">
                                                                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                                                                        </asp:RadioButtonList></div>
                                      <div class="col-md-2 text-right"> Registration Fee :</div>
                                    <div class="col-md-2 text-left"><asp:Label ID="lblRegFee" runat="server"></asp:Label></div>
                                      <div class="col-md-2 text-right"><asp:Label ID="Regno" runat="server" Visible="False"></asp:Label></div>
                                    <div class="col-md-2 text-left"></div>
                                </div>
                                <div class="form-group">
                                <div class="col-md-12 text-center">
                                  <asp:Button ID="btn_Save" runat="server"  OnClick="btn_Save_Click" Text="Save"
                                                                            ValidationGroup="g1" CssClass="btn-primary" />
                                                                        <script type="text/javascript">

                                                                            function preventMultipleSubmissions() {
                                                                                $('#<%=btn_Save.ClientID %>').prop('disabled', true);
                                                                            }

                                                                            window.onbeforeunload = preventMultipleSubmissions;
 
                                                                        </script>
                                                                        <asp:Button ID="btn_Update" runat="server"  OnClick="btn_Update_Click"
                                                                            Text="Update" ValidationGroup="g1" CssClass="btn-danger"/>
                                                                        <script type="text/javascript">

                                                                            function preventMultipleSubmissions() {
                                                                                $('#<%=btn_Update.ClientID %>').prop('disabled', true);
                                                                            }

                                                                            window.onbeforeunload = preventMultipleSubmissions;
 
                                                                        </script>
                                </div>
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
