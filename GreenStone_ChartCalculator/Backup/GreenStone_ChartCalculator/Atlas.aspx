<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Atlas.aspx.cs" Inherits="GreenStone_ChartCalculator.Atlas" %>
<%@ PreviousPageType VirtualPath="~/Welcome.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>GreenStone Lobo- Vedic Astrology Chart Calculator</title>
    <style>
.w3{width:100px }
.report{width:85%}
.bdr{width:500px; background-color:#e9eed0;}
.greyele{font:normal 11px verdana,Arial; color:#800000;}
.lightele{font:normal 11px verdana,Arial; color:#1F586D}
.bele{font:normal 11px verdana,Arial;}
div.spacert{ background-color:#b9d03d; border-top:1px solid #424b11; clear: both; line-height:5px}
div.spacerb{ background-color:#b9d03d; border-bottom:1px solid #424b11; clear: both; line-height:5px}
.textbox {FONT-SIZE: 10px; FONT-FAMILY: verdana,Arial}
div.leftflow{ float:left; margin-left:5px;}
div.spacer {clear: both; line-height:5px}
div.spacer15 {clear: both; line-height:15px}
.pad4{ padding:4px 4px 4px 4px}
</style>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="continueButton" defaultfocus="cityDropDown">
    <div class="bdr">

        <div class="spacert">&nbsp;</div>
        <div class="pad4 greyele" style="BACKGROUND-COLOR: #b9d03d"><b>Please Select Your City of Birth</b></div>
        <div class="spacer15">&nbsp;</div>
        
        <div class="leftflow bele w3">Name</div>
        <div class="leftflow bele">: <asp:Label ID="nameLabel" runat="server" TabIndex="-1"></asp:Label></div>
        <div class="spacer15">&nbsp;</div>

        <div class="leftflow bele w3">Date of Birth</div>
        <div class="leftflow bele">: 
            <asp:Label ID="monthLabel" runat="server" TabIndex="-1"></asp:Label>/<asp:Label ID="dayLabel" runat="server" TabIndex="-1"></asp:Label>/<asp:Label ID="yearLabel" runat="server" TabIndex="-1"></asp:Label> (mm/dd/yyyy)</div>
        <div class="spacer15">&nbsp;</div>

        <div class="leftflow bele w3">Time of Birth</div>
        <div class="leftflow bele">: 
            <asp:Label ID="hourLabel" runat="server" TabIndex="-1"></asp:Label>:<asp:Label ID="minuteLabel" runat="server" TabIndex="-1"></asp:Label>:<asp:Label ID="secondLabel" runat="server" TabIndex="-1"></asp:Label> (hh:mm:ss)</div>
        <div class="spacer15">&nbsp;</div>

        <div class="leftflow bele w3">Country</div>
        <div class="leftflow bele">: <asp:Label ID="countryLabel" runat="server" TabIndex="-1"></asp:Label></div>
        <div class="spacer15">&nbsp;</div>

        <div class="leftflow bele w3">City / Town</div>
        <div class="leftflow bele">: </div>
        <div class="leftflow bele w3"><asp:DropDownList ID="cityDropDown" runat="server" Width="250px" TabIndex="1"></asp:DropDownList></div>

<div class="spacer15">&nbsp;</div>
<div class="spacerb">&nbsp;</div>
<div class="spacer15">&nbsp;</div>
<div class="leftflow bele w3"></div>
<div class="leftflow bele">&nbsp;&nbsp;
    <asp:Button ID="backButton" runat="server" Text="Back" Width="70px" TabIndex="-1" />&nbsp;&nbsp;
    <asp:Button ID="continueButton" runat="server" Text="Continue" PostBackUrl="~/Chart.aspx" TabIndex="2" />
</div>

<div class="spacer15">&nbsp;</div>
<div class="pad4 greyele"><strong>PLEASE VERIFY THAT THE CITIES SELECTED ARE IN THE CORRECT STATES, REGIONS OR COUNTIES. IF NOT PLEASE SELECT THE CORRECT ONES FROM THE DROP DOWN MENUS.</strong></div>
<div class="spacer">&nbsp;</div>
<div class="spacerb">&nbsp;</div>

    </div>
    </form>
</body>
</html>
