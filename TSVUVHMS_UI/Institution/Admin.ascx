  <%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin.ascx.cs" Inherits="EVHMS_UI_Admin_Admin" %>
<link href="../styles/main.css" rel="Stylesheet" type="text/css" media="all" />
<div style="width:100%;" >
 <nav id="topnav">
<ul class="clear">


 <li style="padding-left:2%;"><a href="DashBoard_Ins.aspx">Home</a></li>
   <li><a href="PatientReg1.aspx">Patient Registration</a>
 
 </li>
 <li><a href="Casesheet.aspx">Print CaseSheet</a>

 </li>
  <li><a href="#">Reports</a>
  <ul>
 <li style="font-size: medium;"><a href="Rpt_PatientDtlsByAnimalType.aspx">Patient Details Report</a></li>
 <li style="font-size: medium;"><a href="../FeeCollected_Rpt.aspx">Fee Collected</a></li>
 <li style="font-size: medium;"><a href="../Visit_RevistCnt_Rpt.aspx">Paitent Registration Statistics</a></li>
 <li style="font-size: medium;"><a href="../Rpt_DA_PatientVisits.aspx">Data Analysis</a></li>
 
 </ul>
 </li>
  <li><a href="#">My Account</a>
  <ul>
     
   <li><a href="../Change_Pwd.aspx">Change Password</a></li>
   
  </ul>
 </li>

  <li style="float:right;padding-right:2%;"><a href="../Logout.aspx">Logout</a>
 
 </li>
</ul>
</nav>

</div>
  