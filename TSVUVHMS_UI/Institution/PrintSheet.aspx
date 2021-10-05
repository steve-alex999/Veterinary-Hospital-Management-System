<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintSheet.aspx.cs" Inherits="Institution_Sheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
    <style type="text/css">
        .style1
        {
            text-decoration: underline;
        }
        .style2
        {
            width: 205px;
        }
        .myGridStyle
        {
          width:95%;
          height:80%;
            
        }
        
.myGridStyle
        {
            border-collapse:collapse;
            font-size:19px;
            
        }
        .style3
        {
            width: 573px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <asp:Panel id="pnlContents" runat = "server">
    <table border="1" align="center" width="90%">
   <tr align="center">
   <td>
       Government.of Tealngana<br /> Institution Name:<asp:Label ID="lblInsName" 
           runat="server"></asp:Label>
       <br />
       <asp:Label ID="lblMandal" runat="server"></asp:Label>
       Mandal,<asp:Label ID="lblDist" runat="server"></asp:Label>
       &nbsp;District<br /> <span class="style1"><strong>CASE SHEET</strong></span></td>
   </tr>
   </table>
 
   <table border="1" align="center" width="90%">
       <tr>
           <td>
               Reg.No. :</td>
           <td>
               <asp:Label ID="lblRegNo" runat="server"></asp:Label>
           </td>
           <td class="style2">
               Date:</td>
           <td>
               <asp:Label ID="lblDate" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td>
               Owner Name:</td>
           <td>
               <asp:Label ID="lblOwner" runat="server"></asp:Label>
           </td>
           <td class="style2">
               Address:</td>
           <td>
               <asp:Label ID="lblAddress" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td>
               Mobile No:</td>
           <td>
               <asp:Label ID="lblMbno" runat="server"></asp:Label>
           </td>
           <td class="style2">
               Mandal &amp; District</td>
           <td>
               <asp:Label ID="lblMandalA" runat="server"></asp:Label>
               ,<asp:Label ID="lblDistA" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td>
               Animal :</td>
           <td>
               <asp:Label ID="lblAnimal" runat="server"></asp:Label>
           </td>
           <td class="style2">
               Gender:</td>
           <td>
               <asp:Label ID="lblGender" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td>
               Age:</td>
           <td>
               <asp:Label ID="lblAge" runat="server"></asp:Label>
               &nbsp;Years</td>
           <td class="style2">
               Fee Collected (Rs.)</td>
           <td>
               &nbsp;</td>
       </tr>
       </table>
       <table align="center" style="border-style: double; width: 90%; height:85%" 
           class="myGridStyle">
       <tr>
           <td align="center" style="border-style: double">
               <strong>Date</strong></td>
           <td align="center" class="style3" style="border-style: double">
               <strong>History &amp; Clinical observation</strong></td>
           <td align="center" style="border-style: double">
               <strong>Treament</strong></td>
       </tr>
       <tr>
           <td>
               &nbsp;</td>
           <td class="style3">
               &nbsp;</td>
           <td>
               &nbsp;</td>
       </tr>
       <tr align="center">
           <td colspan="3">
              
           </td>
       </tr>
           <tr align="center">
               <td colspan="3">
                   &nbsp;</td>
           </tr>
           <tr align="center">
               <td colspan="3">
                   &nbsp;</td>
           </tr>
           <tr align="center">
               <td colspan="3">
                   &nbsp;</td>
           </tr>
           <tr align="center">
               <td colspan="3">
                   &nbsp;</td>
           </tr>
           <tr align="center">
               <td colspan="3">
                   &nbsp;</td>
           </tr>
           <tr align="center">
               <td colspan="3">
                   &nbsp;</td>
           </tr>
           <tr align="center">
               <td colspan="3">
                   &nbsp;</td>
           </tr>
           <tr align="center">
               <td colspan="3">
                   &nbsp;</td>
           </tr>
           <tr align="center">
               <td colspan="3">
                   &nbsp;</td>
           </tr>
           <tr align="center">
               <td colspan="3">
                   &nbsp;</td>
           </tr>
           <tr align="center">
               <td colspan="3">
                   &nbsp;</td>
           </tr>
           <tr align="center">
               <td colspan="3">
                   &nbsp;</td>
           </tr>
   </table>
     </asp:Panel>
     <table><tr align="center"><td>
      <asp:Button ID="btnPrint" runat="server" Height="25px" 
                   OnClientClick="return PrintPanel();" Text="Print" /></table>
    </div>
    </form>
</body>
</html>
