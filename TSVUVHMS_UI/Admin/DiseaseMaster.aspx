<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DiseaseMaster.aspx.cs" Inherits="DiseaseMaster" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
   <script src="../scripts/JQuery-min.js.js" type="text/javascript"></script>
    <script src="../scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="../scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
  
    <link href="../BS/css/footable.min.css" rel="stylesheet" type="text/css" />
  <%--  <script src="../BS/js/jquery.min.js" type="text/javascript"></script>--%>
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
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=GridView1]').footable();
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });
        function Confirm(link) {

            if (confirm("Are you sure you want to delete the record?")) {

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

            var txtbx = document.getElementById("txtDiseaseTCode").value;
            if (txtbx.startsWith("0")) // true
            {
                document.getElementById("txtDiseaseTCode").value = "";
                alert("you can not insert zero as first character");
            }
        }
        
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
                                <menu:menu ID="Menu" runat="server"></menu:menu>
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
                    <span class="card-title">  Disease Type Master</span></div>
                <div class="col-md-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10  col-sm-10 text-center">
                        <div class="form-group">
                         <div class="col-md-10  col-sm-10 text-center">
                          <span style="color: Red">  Note:Fields marked with&nbsp;* &nbsp;are Compulsory</span>
                         </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-2  text-right">
                                <label for="ddlfinyear">
                                     Disease Type Code: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                               
                                     <asp:TextBox ID="txtDiseaseTCode" runat="server" CssClass="form-control validate[required]" MaxLength="4"
                                                            onkeypress="ChkValidChar();" placeholder="Disease Type Code"></asp:TextBox>
                                                        <ajax:FilteredTextBoxExtender ID="txtDiseaseTCode_FilteredTextBoxExtender" runat="server"
                                                            Enabled="True" FilterType="Numbers" TargetControlID="txtDiseaseTCode">
                                                        </ajax:FilteredTextBoxExtender>              
                            </div>
                           
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-2  text-right">
                                <label for="ddlfinyear">
                                     Disease Type Name: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                               <asp:TextBox ID="txtDiseaseName" runat="server" MaxLength="75" CssClass="form-control validate[required]"
                                                            placeholder="Disease Type Name"></asp:TextBox>
                                                        <ajax:FilteredTextBoxExtender ID="txtDiseaseName_FilteredTextBoxExtender" runat="server"
                                                            Enabled="True" TargetControlID="txtDiseaseName" FilterType="UppercaseLetters, LowercaseLetters, Numbers, custom"
                                                            ValidChars=" .">
                                                        </ajax:FilteredTextBoxExtender>
                            </div>
                           
                        </div>
                        
                         <div class="form-group">
                            <div class="col-md-3 col-md-offset-4  text-right">
                             <asp:Button runat="server" ID="btn_Save" Text="Save" OnClick="btn_Save_Click"
                                    class="btn btn-success" />
                                      
                                    &nbsp;<asp:Button runat="server" ID="btn_Update" Text="Update" OnClick="btn_Update_Click"
                                    class="btn btn-warning" />
                            &nbsp;<asp:Button ID="btnreset" runat="server" class="btn btn-danger" 
                                    onclick="btnreset_Click" Text="Reset" />
                            </div></div>
                    </div>
                </div>
                   <div class="row">
                            <div class="col-md-12">
                            <div class="col-md-1"></div>
                             
                             <div class="col-md-10 text-center">

                                             
                                                   <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                               
                                                CssClass="footable"  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" PageSize="10" Width="85%">
                                                 <HeaderStyle CssClass="success" />
                                                      <Columns>
                                                    <asp:TemplateField HeaderText="Disease Type Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDCode" runat="server" Text='<%# Bind("DiseaseCode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Disease Type Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDName" runat="server" Text='<%# Bind("DiseaseName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                                        <%--<EditItemTemplate>
                                                                            <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                                                            <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>OnClick="lnkEdit_Click"
                                                                        </EditItemTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edt" Text="Edit"></asp:LinkButton>&nbsp|&nbsp
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
