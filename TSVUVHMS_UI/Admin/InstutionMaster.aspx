<%@ Page AutoEventWireup="true" CodeFile="InstutionMaster.aspx.cs" Inherits="EVHMS_UI_Admin_Default"
    Language="C#" %>

<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title></title>
    <script src="../scripts/JQuery-min.js.js" type="text/javascript"></script>
    <script src="../scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="../scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <link href="../BS/css/footable.min.css" rel="stylesheet" type="text/css" />
    <%--<script src="../BS/js/jquery.min.js" type="text/javascript"></script>--%>
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
            $('[id*=GridView1]').footable();
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
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
        label
        {
            color: #333;
        }
        .footable a
        {
            color: #333;
        }
        .tbldata td
        {
            background-color: White;
            font-family: Times New Roman;
            font-size: large;
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
                    <span class="card-title">Institution Master</span></div>
                <div class="col-md-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                            <div class="col-md-10  col-sm-10 text-center">
                                <span style="color: Red">Note:Fields marked with&nbsp;* &nbsp;are Compulsory</span>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3  text-right">
                                <label for="ddlfinyear">
                                    District:<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:DropDownList ID="ddl_dist_code" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_dist_code_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_dist_code"
                                    ErrorMessage="Select District" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3  text-right">
                                <label for="ddlfinyear">
                                    Mandal:<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:DropDownList ID="ddl_mandal_code" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_mandal_code"
                                    ErrorMessage="Select Mandal" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Institution Type:&nbsp;<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:DropDownList ID="ddl_Institution" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_Institution"
                                    ErrorMessage="Select Institution" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    City/Village: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:TextBox ID="txtVillage" runat="server" MaxLength="75" CssClass="form-control validate[required]"
                                    placeholder="Village"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="txtVillage_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" TargetControlID="txtVillage" FilterType="Custom,Numbers,UppercaseLetters,lowercaseLetters"
                                    ValidChars=" .">
                                </ajax:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Institution Code:&nbsp;<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:TextBox ID="txtInstutionCode" runat="server" MaxLength="4" CssClass="form-control validate[required]"
                                    placeholder="Institution Code" OnTextChanged="txtInstutionCode_TextChanged"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="txtInstutionCode_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" TargetControlID="txtInstutionCode" FilterType="Numbers">
                                </ajax:FilteredTextBoxExtender>
                            </div>
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Institution Name: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:TextBox ID="txtInstutionName" runat="server" CssClass="form-control validate[required]"
                                    MaxLength="75" placeholder="Institution Name"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="txtInstutionName_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" TargetControlID="txtInstutionName" FilterType="Custom,Numbers,UppercaseLetters,lowercaseLetters"
                                    ValidChars=" .">
                                </ajax:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3  text-right">
                                <label for="txtdepartment">
                                    Effective&nbsp;Date:&nbsp;<span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:TextBox ID="txt_Date" runat="server" CssClass="form-control style_txt_entry"></asp:TextBox>
                            </div>
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
                                <asp:Button runat="server" ID="btn_Save" Text="Save" OnClick="btn_Save_Click" class="btn btn-success" />
                                &nbsp;<asp:Button runat="server" ID="btn_Update" Text="Update" OnClick="btn_Update_Click"
                                    class="btn btn-warning" />
                                &nbsp;<asp:Button ID="btnreset" runat="server" class="btn btn-danger" OnClick="btnreset_Click"
                                    Text="Reset" />
                            </div>
                        </div>
                        <div class="form-group">
                        </div>
                        <div class="form-group">
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-1">
                                </div>
                                <div class="col-md-10 text-center">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CssClass="footable" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing"
                                        PageSize="10" Width="85%">
                                        <HeaderStyle CssClass="success" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Institution Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInstCode" runat="server" Text='<%# Bind("InstitutionCode") %>'></asp:Label>
                                                    <asp:Label ID="lblUniqueInstId" runat="server" Visible="false" Text='<%# Bind("Unique_InstId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Institution Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInstName" runat="server" Text='<%# Bind("InstitutionName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Institution Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInstType" runat="server" Text='<%# Bind("InstitutionTypeDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mandal">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMandal" runat="server" Text='<%# Bind("Mandal") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="City/Village">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblvillageName" runat="server" Text='<%# Bind("City_Village") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Effective Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEffectiveDt" runat="server" Text='<%# Bind("EffectiveDt") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Active">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                                    <asp:Label ID="lblDcode" runat="server" Text='<%# Bind("DistCode") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblMcode" runat="server" Text='<%# Bind("MandCode") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblInscode" runat="server" Text='<%# Bind("InstitutionType") %>' Visible="false"></header>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Update" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" OnClick="lnkEdit_Click"
                                                        Text="Edit"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="col-md-1">
                                </div>
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
