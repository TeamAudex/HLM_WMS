<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DebitCreditInv.aspx.cs" Inherits="TestApplication.Reports.DebitCreditInv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:HiddenField ID="hdnReqSno" runat="server" />
   <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
 
        <div style="height: 600px;">
            <rsweb:ReportViewer ID="rptvInvoice" runat="server" Width="100%" Height="100%" ShowPrintButton="true"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
