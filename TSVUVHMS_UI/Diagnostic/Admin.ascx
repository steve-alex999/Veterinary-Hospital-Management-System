<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin.ascx.cs" Inherits="EVHMS_UI_Admin_Admin" %>
<link href="../styles/main.css" rel="Stylesheet" type="text/css" media="all" />
<div style="width: 100%;">
    <nav id="topnav">
<ul class="clear">


 <li style="padding-left:2%;"><a href="DashBoard_Dia.aspx">Home</a></li>
  <li><a href="PendingDiagnostic_Test.aspx">Diagnostic Test Details </a>
  </li>
  <li><a href="DiagTest_Bill.aspx">Diagnostic Test Bill</a>
  </li>
  <li><a href="#">Reports</a>
  <ul>
  <li style="font-size: medium;"><a href="../DiagFeeCollected_Rpt.aspx">Diagnostic Fee Collected</a></li>
  <li style="font-size: medium;"><a href="Rpt_Diag_MonthlyAbstract.aspx">Diagnostics Monthly Abstract</a></li>
   </ul>
 </li>
   <li><a href="#">My Account</a>
  <ul>
     
   <li style="font-size: medium;"><a href="../Change_Pwd.aspx">Change Password</a></li>
   
  </ul>
 </li>
    <li style="float:right;padding-right:2%;"><a href="../Logout.aspx">Logout</a>
 
 </li>
</ul>
</nav>
</div>
