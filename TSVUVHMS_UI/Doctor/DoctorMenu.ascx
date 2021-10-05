  <%@ Control Language="C#" AutoEventWireup="true" CodeFile="DoctorMenu.ascx.cs" Inherits="EVHMS_DoctorMenu" %>
<link href="../styles/main.css" rel="Stylesheet" type="text/css" media="all" />
<div style="width:100%;" >
 <nav id="topnav">
<ul class="clear">


 <li style="padding-left:2%;"><a href="Rpt_TodayPatientHistory.aspx">View Patient History</a></li>
   
  <li><a href="#">Pharmacy</a>
  <ul>
   <li style="font-size: medium;"><a href="../Pharmacy/DrugsAvailability.aspx">Drugs Availability </a></li>   
    </ul>
  </li> 

  <li><a href="#">Reports</a>
  <ul>
   <li style="font-size: medium;"><a href="Rpt_PatientHistory.aspx">Patient History </a></li>   
    </ul>
  </li> 

  <li><a href="../Pharmacy/PendingPatients_IssueofDrugs.aspx">Issue of Drugs</a></li>

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
  