<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chart.aspx.cs" Inherits="GreenStone_ChartCalculator.Chart" %>
<%@ PreviousPageType VirtualPath="~/Atlas.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>GreenStone Lobo- Vedic Astrology Chart Calculator</title>
    <style>
.w3{width:100px }
.report{width:650px}
.bdr{width:650px;}
.centered{text-align: center;}
.greyele{font:normal 11px verdana,Arial; color:#800000}
.lightele{font:normal 11px verdana,Arial; color:#1F586D}
.bele{font:normal 11px verdana,Arial;}
div.spacert{ background-color:#ffe5cc; border-top:1px solid #ffc891; clear: both; line-height:5px}
div.spacerb{ background-color:#ffe5cc; border-bottom:1px solid #ffc891; clear: both; line-height:5px}
.textbox {FONT-SIZE: 10px; FONT-FAMILY: verdana,Arial}
div.leftflow{ float:left; margin-left:5px;}
div.spacer {clear: both; line-height:5px}
div.spacer15 {clear: both; line-height:15px}
.pad4{ padding:4px 4px 4px 4px}
</style>
</head>
<body>
    <div class="report centered">
    <div>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
    </div>
</body>
</html>
