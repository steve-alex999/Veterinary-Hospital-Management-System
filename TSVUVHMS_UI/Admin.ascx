<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin.ascx.cs" Inherits="EVHMS_UI_Admin_Admin" %>
<link href="styles/main.css" rel="Stylesheet" type="text/css" media="all" />
<div style="width:100%;" >
 <nav id="topnav">
<ul class="clear">


 <%--<a href="index.htm"><img src="styles/home4.png" style="float:left;padding:7px; 20px; 5px; 20px;" ></a>--%>

<li style="padding-left:2%;"><a href="Default.aspx">Home</a></li>


  <li><a href="#">ABOUT VHMS</a>
  
 </li>
 <li><a href="#">Registration</a>
  <ul>
 <li style="font-size: medium;"><a href="P_FeeCollected_Rpt.aspx">Fee Collected</a></li>
 <li style="font-size: medium;"><a href="P_Visit_RevistCnt_Rpt.aspx">Paitent Registration Statistics</a></li> 
 <li style="font-size: medium;"><a href="P_Rpt_DA_PatientVisits.aspx">Data Analysis</a></li> 
 </ul>
 </li>
 <li><a href="#">Pharmacy</a>
  <ul>
  <li style="font-size: medium;"><a href="P_Rpt_DrugsAvailability.aspx">Drugs Availability</a></li>
 <li style="font-size: medium;"><a href="P_Rpt_PH_DailyStocksRcvd.aspx">Daily Stocks Received</a></li>
 <li style="font-size: medium;"><a href="P_Rpt_PH_DailyStocksIssued.aspx">Daily Stocks Issued</a></li>
 </ul>
 </li>
 <li><a href="#">Diagnostics</a>
  <ul>
 <li style="font-size: medium;"><a href="P_DiagFeeCollected_Rpt.aspx">Diagnostic Test Fee</a></li>
 <li style="font-size: medium;"><a href="P_Rpt_Diag_MonthlyAbstract.aspx">Diagnostics Monthly Abstract</a></li>
 </ul>
 </li>
 <li><a href="#">Feedback</a>
  <ul>
 <li style="font-size: medium;"><a href="P_Rpt_FeedbackAnalysis.aspx">Feedback Analysis</a></li> 
 </ul>
 </li>
 <li style="float:right;padding-right:2%;""><a href="login.aspx">Dept. Login</a></li>
<%-- <li><a href="#">User Management</a>
  <ul>
     
   <li><a href="../User_Creation.aspx">User Creation</a></li>
   
  </ul>
 </li>--%>

 
 
 
</ul>
</nav>

</div>
  