<%@ Page AutoEventWireup="true" CodeFile="DrugConsumption.aspx.cs" Inherits="EVHMS_UI_Pharmacy_DrugConsumption"
    Language="C#" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/DefaultMenu.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
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
 
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
        rel="stylesheet" type="text/css" />
  <%--  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=grdDrugCons]').footable();
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });
    </script>
    <script type="text/javascript">
        String.prototype.startsWith = function (str) {
            return (this.indexOf(str) === 0);
        }
        function ChkValidChar() {

            var txtbx = document.getElementById("txtAvgConsumption").value;
            if (txtbx.startsWith("0")) // true
            {
                document.getElementById("txtAvgConsumption").value = "";
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
        
        
        .tbldata td
        {
            background-color: white;
            font-family: Times New Roman;
            font-size: large;
            width: 488px;
        }
        .style1
        {
            width: 1200px;
            height: 100px;
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
              <label >
                                     Logged As :: </label><asp:Label ID="lblUsrName" runat="server" Font-Bold="true" ForeColor="#ab7d44"
                Text=""></asp:Label>
        </div>
        <div class="col-md-4 text-right">
              <label >Institution Name : &nbsp;</label>
            <asp:Label ID="lblInsName" runat="server" Font-Bold="True" ForeColor="#AB7D44"></asp:Label>
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
                    <span class="card-title">Drug Consumption</span></div>
                <div class="col-md-12">
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="col-md-10 col-md-10 col-sm-10 text-center">
                        <div class="form-group">
                           
                        </div>
                        <div class="row">
                            <div class="col-md-3 col-md-offset-3  text-right">
                                <label >
                                     Drug: : <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                               
                                                            <asp:DropDownList ID="ddl_drug" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddl_drug_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_drug"
                                                ErrorMessage="Select Drug" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                            </div>
                           
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-3  text-right">
                                <label for="ddlfinyear">
                                     Unit of Measurement: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
  <label ><asp:Label ID="lblUnitMsrmt" Font-Bold="true" runat="server"></asp:Label></label>
                            </div>
                           
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-3  text-right">
                                <label >
                                    Average Consumption Per Month: <span style="color: Red">*</span></label>
                            </div>
                            <div class="col-md-3 text-center">
                                 <asp:TextBox ID="txtAvgConsumption" runat="server" MaxLength="6" CssClass="form-control validate[required]"
                                               onkeypress="ChkValidChar();"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="txtAvgConsumption_FilteredTextBoxExtender" runat="server"
                                                Enabled="True" TargetControlID="txtAvgConsumption" FilterType="Numbers">
                                            </ajax:FilteredTextBoxExtender>
                            </div>
                           
                        </div>
                         <div class="form-group">
                            <div class="col-md-4 col-md-offset-4  text-center">
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

                                             
                                                   <asp:GridView ID="grdDrugCons" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                               
                                                CssClass="footable" DataKeyNames="AnimalTypeCode" OnPageIndexChanging="grdDrugCons_PageIndexChanging"
                                                PageSize="10" Width="85%">
                                                 <HeaderStyle CssClass="success" />
                                                   <Columns>
                                        <asp:TemplateField HeaderText="SNO" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Drug Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldrugname" runat="server" Text='<%# Bind("DrugName") %>'></asp:Label>
                                                <asp:Label ID="lblDrugCode" Visible="false" runat="server" Text='<%# Bind("DrugCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit Measurement">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitMsrmt" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Average Consumption Per Month">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAvgConsumptionPerDay" runat="server" Text='<%# Bind("AvgConsumptionPerMonth") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Update" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" OnClick="lnkEdit_Click" Text="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                                <EmptyDataTemplate>
                                                    No Records
                                                </EmptyDataTemplate>
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
                    <div class="col-md-12 text-center">
                    
                      <Footer:footer ID="footer" runat="server"></Footer:footer>
                    </div>
                </div>
            </div>
        </footer>
    </form>
</body>
</html>
