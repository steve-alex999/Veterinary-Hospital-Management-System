<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin.ascx.cs" Inherits="EVHMS_UI_Admin_Admin" %>
<link href="../styles/main.css" rel="Stylesheet" type="text/css" media="all" />
<div style="width:100%;" >
 <nav id="topnav">
<ul class="clear">


 <li style="padding-left:2%;"><a href="DashBoard_Phar.aspx">Home</a></li>
  <li><a href="InventoryEntry.aspx">Receipt of Drugs </a>
  </li>
 <li><a href="PendingPatients_IssueofDrugs.aspx">Issue of Drugs</a>
  </li>
 
  <%--<li><a href="DrugConsumption.aspx">Drug Average Consumption Per Day</a></li>--%>
  <li><a href="#">Reports</a>
  <ul>
   <li style="font-size: medium;"><a href="DrugsAvailability.aspx">Drugs Availability </a></li>
   <li style="font-size: medium;"><a href="../Rpt_PH_DailyStocksRcvd.aspx">Daily Stocks Received</a></li>
 <li style="font-size: medium;"><a href="../Rpt_PH_DailyStocksIssued.aspx">Daily Stocks Issued</a></li>
 <li style="font-size: medium;"><a href="Rpt_PH_DrugsIssuedByRegNo.aspx">Drugs Issued</a></li>
    </ul>
  </li> 
   <li><a href="#">My Account</a>
  <ul>
     
   <li style="font-size: medium;"><a href="../Change_Pwd.aspx">Change Password</a></li>
   
  </ul>
 </li>
    <li style="float:right;padding-right:2%"><a href="../Logout.aspx">Logout</a>
 
 </li>
</ul>
</nav>

</div>
  