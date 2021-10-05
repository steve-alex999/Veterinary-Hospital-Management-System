<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MandalMaster.aspx.cs" Inherits="EVHMS_UI_Admin_MandalMaster" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <script src="../scripts/JQuery-min.js.js" type="text/javascript"></script>
    <script src="../scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="../scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
  
    <link href="../BS/css/footable.min.css" rel="stylesheet" type="text/css" />
  
    <script src="../BS/js/footable.min.js" type="text/javascript"></script>
    <script src="../scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Bs/js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <link href="../BS/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />
    <link href="../BS/css/style.css" rel="stylesheet" />
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
      <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
        rel="stylesheet" type="text/css" />
  <%--  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    
    <script type="text/javascript">
        $(function () {
            $('[id*=GvMandal]').footable();
        });
    </script>
 
  <script type="text/javascript">
      $(function () {
          $("#txt_Date").datepicker({
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
       label { color: #333;}
         .footable a
        {
             color: #333;
            }
        .tbldata td
        {
            background-color: White;
            font-family: Times New Roman;
            font-size: large;
            width: 488px;
        }
       
    </style>
    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });

        function Confirm(link) {

            if (confirm("Are you sure to delete the selected mandal?")) {

                return true;
            }
            else
                return false;


        }
       
    </script>
    <script type="text/javascript" >
        String.prototype.startsWith = function (str) {
            return (this.indexOf(str) === 0);
        }
        function ChkValidChar() {

            var txtbx = document.getElementById("txtMandalCode").value;
            if (txtbx.startsWith("0")) // true
            {
                document.getElementById("txtMandalCode").value = "";
                alert("you can not insert zero as first character");
            }
        }
        
    </script>
  <%-- <script type="text/javascript">
       $(document).ready(function () {
           $('.style_txt_entry').datepicker({
               dateFormat: 'dd-mm-yy',
               maxDate: new Date(),
               showOn: "button",
               buttonImage: "../Images/calendar.jpg",
               buttonImageOnly: true,
               buttonText: "Select date",
               changeMonth: true,
               changeYear: true,
               yearRange: "-10:+0"
           });
       });

           
    </script>--%>
   
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
            <div class="col-md-10" id="card" style="margin-top: 0">
                <div class="card-header">
                    <span class="card-title"> Mandal Master</span></div>
                <div class="col-md-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                     <div class="form-group"></div>
                      <div class="form-group">
                            <div class="col-md-3  text-right">
                             <label for="ddlfinyear">
                                   District Name: <span style="color: Red">*</span></label>
                                       
                                    </div>
                                    <div class="col-md-3 text-center">
                                      <asp:DropDownList ID="ddl_dist_code" runat="server" AutoPostBack="true"  CssClass="form-control"
                                                    OnSelectedIndexChanged="ddl_dist_code_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                                <asp:Label ID="lblMcode" runat="server"></asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_dist_code"
                                                    ErrorMessage="Select District" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                    </div>
                            <div class="col-md-3  text-right">
                                <label for="ddlfinyear">
                                     Mandal Code: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                          <asp:TextBox ID="txtMandalCode" runat="server" placeholder="Mandal Code" CssClass="form-control validate[required]"
                                                    MaxLength="3" OnTextChanged="txtMandalCode_TextChanged"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="txtMandalCode_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" FilterType="Numbers" TargetControlID="txtMandalCode">
                                                </ajax:FilteredTextBoxExtender>
                        </div>
                        </div>
                        <div class="form-group">
                         <div class="col-md-3  text-right">
                                <label for="ddlfinyear">
                                     Mandal Name: <span style="color: Red">*</span></label>
                            </div><div class="col-md-3 text-center">
                            <asp:TextBox ID="txtMandalName" runat="server" placeholder="Mandal Name" CssClass="validate[required] form-control"
                                                    MaxLength="75"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="txtMandalName_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" TargetControlID="txtMandalName" FilterType="Custom,Numbers,UppercaseLetters,lowercaseLetters"
                                                    ValidChars=" .">
                                                </ajax:FilteredTextBoxExtender>
                            </div>
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                   Effective&nbsp;Date:&nbsp;<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                          
                                                             <asp:TextBox ID="txt_Date" runat="server" AutoCompleteType="Disabled" 
                                                            CssClass="form-control"></asp:TextBox>
                            </div>
                             
                        </div>
                        <div class="form-group">
                        <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Active: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                            <asp:RadioButtonList ID="rbnSy" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Text="Yes" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="0" Text="No"></asp:ListItem>
                            </asp:RadioButtonList>
                               
                                   
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-5">
                                <asp:Button runat="server" ID="btn_Save" Text="Save" OnClick="btn_Save_Click"
                                    class="btn btn-success" />
                                      
                                    &nbsp;<asp:Button runat="server" ID="btn_Update" Text="Update" OnClick="btn_Update_Click"
                                    class="btn btn-warning" />
                            &nbsp;<asp:Button ID="btnreset" runat="server" class="btn btn-danger" 
                                    onclick="btnreset_Click" Text="Reset" />
                            </div>
                        </div>
                         <div class="form-group"></div>
                          <div class="form-group"></div>
                         <div class="row">
                            <div class="col-md-12">
                            <div class="col-md-1"></div>
                             
                             <div class="col-md-10 text-center">

                                             
                                                   <asp:GridView ID="GvMandal" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                               
                                                CssClass="footable" DataKeyNames="DistCode" OnPageIndexChanging="GvMandal_PageIndexChanging"
                                                OnRowCommand="GvMandal_RowCommand" OnRowEditing="GvMandal_RowEditing" PageSize="10" Width="85%">
                                                 <HeaderStyle CssClass="success" />
                                                    <Columns>
                            <asp:TemplateField HeaderText="Mandal Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblMCode" runat="server" Text='<%# Bind("MandCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mandal Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblMName" runat="server" Text='<%# Bind("MandName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Effective Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbleffdate" runat="server" Text='<%# Bind("EffectiveDt") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                    <asp:HiddenField ID="hdndistcode" Value='<%# Bind("DistCode") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" OnClick="lnkEdit_Click"></asp:LinkButton>&nbsp|&nbsp
                                    <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return Confirm(this)"
                                        CommandName="Dlt" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                                            </asp:GridView>
                           
                          </div>
                             <div class="col-md-1"></div>
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
                    <div class="col-md-12">
                    
                      <Footer:footer ID="footer" runat="server"></Footer:footer>
                    </div>
                </div>
            </div>
        </footer>
    </form>
</body>
</html>
