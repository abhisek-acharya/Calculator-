<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="GreenStone_ChartCalculator.Welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>GreenStone Lobo- Vedic Astrology Chart Calculator</title>
<style type="text/css">
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
    <form id="form1" runat="server" defaultbutton="continueButton" defaultfocus="nameTextBox">
<div class="bdr">
<div class="spacert">&nbsp;</div>
<div class="pad4 greyele" style="BACKGROUND-COLOR: #b9d03d"><b>Please Enter Your Date, Time and Place of Birth</b></div>
<div class="spacer15">&nbsp;</div>

<div class="leftflow bele w3">Name</div>
<div class="leftflow bele">: <asp:TextBox ID="nameTextBox" runat="server" Width="203" TabIndex="1"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="name1RequiredFieldValidator" runat="server" ErrorMessage="Please enter Your Name" ControlToValidate="nameTextBox">*</asp:RequiredFieldValidator></div>
<div class="spacer15">&nbsp;</div>
<div class="leftflow bele w3">Date of Birth<br/>(mm/dd/yyyy)</div>
<div class="leftflow bele">: 
    <asp:DropDownList ID="monthDropDown" runat="server" Width="95px" TabIndex="2">
        <asp:ListItem value="1">January</asp:ListItem>
		<asp:ListItem value="2">February</asp:ListItem>
		<asp:ListItem value="3">March</asp:ListItem>
		<asp:ListItem value="4">April</asp:ListItem>
		<asp:ListItem value="5">May</asp:ListItem>
		<asp:ListItem value="6">June</asp:ListItem>
		<asp:ListItem value="7">July</asp:ListItem>
		<asp:ListItem value="8">August</asp:ListItem>
		<asp:ListItem value="9">September</asp:ListItem>
		<asp:ListItem value="10">October</asp:ListItem>
		<asp:ListItem value="11">November</asp:ListItem>
		<asp:ListItem value="12">December</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="dayDropDown" runat="server" Width="50px" TabIndex="3">
        <asp:ListItem>01</asp:ListItem>
        <asp:ListItem>02</asp:ListItem>
        <asp:ListItem>03</asp:ListItem>
        <asp:ListItem>04</asp:ListItem>
        <asp:ListItem>05</asp:ListItem>
        <asp:ListItem>06</asp:ListItem>
		<asp:ListItem>07</asp:ListItem>
		<asp:ListItem>08</asp:ListItem> 
		<asp:ListItem>09</asp:ListItem>
		<asp:ListItem>10</asp:ListItem>
		<asp:ListItem>11</asp:ListItem> 
		<asp:ListItem>12</asp:ListItem>
		<asp:ListItem>13</asp:ListItem>
		<asp:ListItem>14</asp:ListItem> 
		<asp:ListItem>15</asp:ListItem>
		<asp:ListItem>16</asp:ListItem>
		<asp:ListItem>17</asp:ListItem> 
		<asp:ListItem>18</asp:ListItem>
		<asp:ListItem>19</asp:ListItem>
		<asp:ListItem>20</asp:ListItem> 
		<asp:ListItem>21</asp:ListItem>
		<asp:ListItem>22</asp:ListItem>
		<asp:ListItem>23</asp:ListItem> 
		<asp:ListItem>24</asp:ListItem>
		<asp:ListItem>25</asp:ListItem>
		<asp:ListItem>26</asp:ListItem> 
		<asp:ListItem>27</asp:ListItem>
		<asp:ListItem>28</asp:ListItem>
		<asp:ListItem>29</asp:ListItem> 
		<asp:ListItem>30</asp:ListItem>
		<asp:ListItem>31</asp:ListItem>
    </asp:DropDownList>
    
    <asp:TextBox ID="yearTextBox" runat="server" Width="50" TabIndex="4"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="yearRequiredFieldValidator" runat="server" ErrorMessage="Please enter the Year of Birth" ControlToValidate="yearTextBox">*</asp:RequiredFieldValidator>
</div>
<div class="spacer15">&nbsp;</div>
<div class="leftflow bele w3">Time of Birth <br/>(hh:mm:ss)</div>
<div class="leftflow bele">: 
    <asp:DropDownList ID="hourDropDown" runat="server" Width="95px" TabIndex="5">
		<asp:ListItem value="0">00 [12 midn]</asp:ListItem>
		<asp:ListItem value="1">01 [am]</asp:ListItem>
		<asp:ListItem value="2">02 [am]</asp:ListItem>
		<asp:ListItem value="3">03 [am]</asp:ListItem>
		<asp:ListItem value="4">04 [am]</asp:ListItem>
		<asp:ListItem value="5">05 [am]</asp:ListItem>
		<asp:ListItem value="6">06 [am]</asp:ListItem>
		<asp:ListItem value="7">07 [am]</asp:ListItem>
		<asp:ListItem value="8">08 [am]</asp:ListItem>
		<asp:ListItem value="9">09 [am]</asp:ListItem>
		<asp:ListItem value="10">10 [am]</asp:ListItem>
		<asp:ListItem value="11">11 [am]</asp:ListItem>
		<asp:ListItem value="12">12 [noon]</asp:ListItem>
		<asp:ListItem value="13">13 [1 pm]</asp:ListItem>
		<asp:ListItem value="14">14 [2 pm]</asp:ListItem>
		<asp:ListItem value="15">15 [3 pm]</asp:ListItem>
		<asp:ListItem value="16">16 [4 pm]</asp:ListItem>
		<asp:ListItem value="17">17 [5 pm]</asp:ListItem>
		<asp:ListItem value="18">18 [6 pm]</asp:ListItem>
		<asp:ListItem value="19">19 [7 pm]</asp:ListItem>
		<asp:ListItem value="20">20 [8 pm]</asp:ListItem>
		<asp:ListItem value="21">21 [9 pm]</asp:ListItem>
		<asp:ListItem value="22">22 [10 pm]</asp:ListItem>
		<asp:ListItem value="23">23 [11 pm]</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="minuteDropDown" runat="server" Width="50px" TabIndex="6">
		<asp:ListItem>00</asp:ListItem>
		<asp:ListItem>01</asp:ListItem>
		<asp:ListItem>02</asp:ListItem> 
		<asp:ListItem>03</asp:ListItem>
		<asp:ListItem>04</asp:ListItem>
		<asp:ListItem>05</asp:ListItem> 
		<asp:ListItem>06</asp:ListItem>
		<asp:ListItem>07</asp:ListItem>
		<asp:ListItem>08</asp:ListItem> 
		<asp:ListItem>09</asp:ListItem>
		<asp:ListItem>10</asp:ListItem>
		<asp:ListItem>11</asp:ListItem> 
		<asp:ListItem>12</asp:ListItem>
		<asp:ListItem>13</asp:ListItem>
		<asp:ListItem>14</asp:ListItem> 
		<asp:ListItem>15</asp:ListItem>
		<asp:ListItem>16</asp:ListItem>
		<asp:ListItem>17</asp:ListItem> 
		<asp:ListItem>18</asp:ListItem>
		<asp:ListItem>19</asp:ListItem>
		<asp:ListItem>20</asp:ListItem> 
		<asp:ListItem>21</asp:ListItem>
		<asp:ListItem>22</asp:ListItem>
		<asp:ListItem>23</asp:ListItem> 
		<asp:ListItem>24</asp:ListItem>
		<asp:ListItem>25</asp:ListItem>
		<asp:ListItem>26</asp:ListItem> 
		<asp:ListItem>27</asp:ListItem>
		<asp:ListItem>28</asp:ListItem>
		<asp:ListItem>29</asp:ListItem> 
		<asp:ListItem>30</asp:ListItem>
		<asp:ListItem>31</asp:ListItem>
		<asp:ListItem>32</asp:ListItem> 
		<asp:ListItem>33</asp:ListItem>
		<asp:ListItem>34</asp:ListItem>
		<asp:ListItem>35</asp:ListItem> 
		<asp:ListItem>36</asp:ListItem>
		<asp:ListItem>37</asp:ListItem>
		<asp:ListItem>38</asp:ListItem> 
		<asp:ListItem>39</asp:ListItem>
		<asp:ListItem>40</asp:ListItem>
		<asp:ListItem>41</asp:ListItem> 
		<asp:ListItem>42</asp:ListItem>
		<asp:ListItem>43</asp:ListItem>
		<asp:ListItem>44</asp:ListItem> 
		<asp:ListItem>45</asp:ListItem>
		<asp:ListItem>46</asp:ListItem>
		<asp:ListItem>47</asp:ListItem> 
		<asp:ListItem>48</asp:ListItem>
		<asp:ListItem>49</asp:ListItem>
		<asp:ListItem>50</asp:ListItem> 
		<asp:ListItem>51</asp:ListItem>
		<asp:ListItem>52</asp:ListItem>
		<asp:ListItem>53</asp:ListItem> 
		<asp:ListItem>54</asp:ListItem>
		<asp:ListItem>55</asp:ListItem>
		<asp:ListItem>56</asp:ListItem> 
		<asp:ListItem>57</asp:ListItem>
		<asp:ListItem>58</asp:ListItem>
		<asp:ListItem>59</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="secondDropDown" runat="server" Width="55px" TabIndex="7">
		<asp:ListItem>00</asp:ListItem>
		<asp:ListItem>01</asp:ListItem>
		<asp:ListItem>02</asp:ListItem> 
		<asp:ListItem>03</asp:ListItem>
		<asp:ListItem>04</asp:ListItem>
		<asp:ListItem>05</asp:ListItem> 
		<asp:ListItem>06</asp:ListItem>
		<asp:ListItem>07</asp:ListItem>
		<asp:ListItem>08</asp:ListItem> 
		<asp:ListItem>09</asp:ListItem>
		<asp:ListItem>10</asp:ListItem>
		<asp:ListItem>11</asp:ListItem> 
		<asp:ListItem>12</asp:ListItem>
		<asp:ListItem>13</asp:ListItem>
		<asp:ListItem>14</asp:ListItem> 
		<asp:ListItem>15</asp:ListItem>
		<asp:ListItem>16</asp:ListItem>
		<asp:ListItem>17</asp:ListItem> 
		<asp:ListItem>18</asp:ListItem>
		<asp:ListItem>19</asp:ListItem>
		<asp:ListItem>20</asp:ListItem> 
		<asp:ListItem>21</asp:ListItem>
		<asp:ListItem>22</asp:ListItem>
		<asp:ListItem>23</asp:ListItem> 
		<asp:ListItem>24</asp:ListItem>
		<asp:ListItem>25</asp:ListItem>
		<asp:ListItem>26</asp:ListItem> 
		<asp:ListItem>27</asp:ListItem>
		<asp:ListItem>28</asp:ListItem>
		<asp:ListItem>29</asp:ListItem> 
		<asp:ListItem>30</asp:ListItem>
		<asp:ListItem>31</asp:ListItem>
		<asp:ListItem>32</asp:ListItem> 
		<asp:ListItem>33</asp:ListItem>
		<asp:ListItem>34</asp:ListItem>
		<asp:ListItem>35</asp:ListItem> 
		<asp:ListItem>36</asp:ListItem>
		<asp:ListItem>37</asp:ListItem>
		<asp:ListItem>38</asp:ListItem> 
		<asp:ListItem>39</asp:ListItem>
		<asp:ListItem>40</asp:ListItem>
		<asp:ListItem>41</asp:ListItem> 
		<asp:ListItem>42</asp:ListItem>
		<asp:ListItem>43</asp:ListItem>
		<asp:ListItem>44</asp:ListItem> 
		<asp:ListItem>45</asp:ListItem>
		<asp:ListItem>46</asp:ListItem>
		<asp:ListItem>47</asp:ListItem> 
		<asp:ListItem>48</asp:ListItem>
		<asp:ListItem>49</asp:ListItem>
		<asp:ListItem>50</asp:ListItem> 
		<asp:ListItem>51</asp:ListItem>
		<asp:ListItem>52</asp:ListItem>
		<asp:ListItem>53</asp:ListItem> 
		<asp:ListItem>54</asp:ListItem>
		<asp:ListItem>55</asp:ListItem>
		<asp:ListItem>56</asp:ListItem> 
		<asp:ListItem>57</asp:ListItem>
		<asp:ListItem>58</asp:ListItem>
		<asp:ListItem>59</asp:ListItem>
    </asp:DropDownList>
</div>
<div class="spacer15">&nbsp;</div>
<div class="leftflow bele w3">Country</div>
<div class="leftflow bele">: 
    <asp:DropDownList ID="countryDropDown" runat="server" Width="208px" TabIndex="8">
			<asp:ListItem>Afghanistan</asp:ListItem>
			<asp:ListItem>Albania</asp:ListItem>
			<asp:ListItem>Algeria</asp:ListItem>
			<asp:ListItem>Andorra</asp:ListItem>
			<asp:ListItem>Angola</asp:ListItem>
			<asp:ListItem>Anguilla</asp:ListItem>
			<asp:ListItem>Antigua and Barbuda</asp:ListItem>
			<asp:ListItem>Argentina</asp:ListItem>
			<asp:ListItem>Armenia</asp:ListItem>
			<asp:ListItem>Aruba</asp:ListItem>
			<asp:ListItem>Australia</asp:ListItem>
			<asp:ListItem>Austria</asp:ListItem>
			<asp:ListItem>Azerbaijan</asp:ListItem>
			<asp:ListItem>Bahamas</asp:ListItem>
			<asp:ListItem>Bahrain</asp:ListItem>
			<asp:ListItem>Bangladesh</asp:ListItem>
			<asp:ListItem>Barbados</asp:ListItem>
			<asp:ListItem>Belarus</asp:ListItem>
			<asp:ListItem>Belgium</asp:ListItem>
			<asp:ListItem>Belize</asp:ListItem>
			<asp:ListItem>Benin</asp:ListItem>
			<asp:ListItem>Bermuda</asp:ListItem>
			<asp:ListItem>Bhutan</asp:ListItem>
			<asp:ListItem>Bolivia</asp:ListItem>
			<asp:ListItem>Bosnia</asp:ListItem>
			<asp:ListItem>Botswana</asp:ListItem>
			<asp:ListItem>Brazil</asp:ListItem>
			<asp:ListItem>Brunei</asp:ListItem>
			<asp:ListItem>Bulgaria</asp:ListItem>
			<asp:ListItem>Burkina</asp:ListItem>
			<asp:ListItem>Burundi</asp:ListItem>
			<asp:ListItem>Cambodia</asp:ListItem>
			<asp:ListItem>Cameroon</asp:ListItem>
			<asp:ListItem>Canada</asp:ListItem>
			<asp:ListItem>Chad</asp:ListItem>
			<asp:ListItem>Chile</asp:ListItem>
			<asp:ListItem>China</asp:ListItem>
			<asp:ListItem>Colombia</asp:ListItem>
			<asp:ListItem>Comoros</asp:ListItem>
			<asp:ListItem>Congo, Democratic Republic of</asp:ListItem>
			<asp:ListItem>Congo</asp:ListItem>
			<asp:ListItem>Cook Islands</asp:ListItem>
			<asp:ListItem>Costa Rica</asp:ListItem>
			<asp:ListItem>Croatia</asp:ListItem>
			<asp:ListItem>Cuba</asp:ListItem>
			<asp:ListItem>Cyprus</asp:ListItem>
			<asp:ListItem>Czech Republic</asp:ListItem>
			<asp:ListItem>Denmark</asp:ListItem>
			<asp:ListItem>Djibouti</asp:ListItem>
			<asp:ListItem>Dominican Republic</asp:ListItem>
			<asp:ListItem>Ecuador</asp:ListItem>
			<asp:ListItem>Egypt</asp:ListItem>
			<asp:ListItem>El Salvador</asp:ListItem>
			<asp:ListItem>Equatorial Guinea</asp:ListItem>
			<asp:ListItem>Eritrea</asp:ListItem>
			<asp:ListItem>Estonia</asp:ListItem>
			<asp:ListItem>Ethiopia</asp:ListItem>
			<asp:ListItem>Faeroe Islands</asp:ListItem>
			<asp:ListItem>Falkland Islands</asp:ListItem>
			<asp:ListItem>Fiji</asp:ListItem>
			<asp:ListItem>Finland</asp:ListItem>
			<asp:ListItem>France</asp:ListItem>
			<asp:ListItem>French Guiana</asp:ListItem>
			<asp:ListItem>French Polynesia</asp:ListItem>
			<asp:ListItem>Gabon</asp:ListItem>
			<asp:ListItem>Gambia</asp:ListItem>
			<asp:ListItem>Gaza Strip</asp:ListItem>
			<asp:ListItem>Georgia</asp:ListItem>
			<asp:ListItem>Germany</asp:ListItem>
			<asp:ListItem>Ghana</asp:ListItem>
			<asp:ListItem>Gibraltar</asp:ListItem>
			<asp:ListItem>Greece</asp:ListItem>
			<asp:ListItem>Greenland</asp:ListItem>
			<asp:ListItem>Grenada</asp:ListItem>
			<asp:ListItem>Guadalupe</asp:ListItem>
			<asp:ListItem>Guam</asp:ListItem>
			<asp:ListItem>Guatemala</asp:ListItem>
			<asp:ListItem>Guernsey</asp:ListItem>
			<asp:ListItem>Guinea</asp:ListItem>
			<asp:ListItem>Guinea-Bissau</asp:ListItem>
			<asp:ListItem>Guyana</asp:ListItem>
			<asp:ListItem>Haiti</asp:ListItem>
			<asp:ListItem>Honduras</asp:ListItem>
			<asp:ListItem>Hong Kong</asp:ListItem>
			<asp:ListItem>Hungary</asp:ListItem>
			<asp:ListItem>Iceland</asp:ListItem>
			<asp:ListItem Selected="True">India</asp:ListItem>
			<asp:ListItem>Indonesia</asp:ListItem>
			<asp:ListItem>Iran</asp:ListItem>
			<asp:ListItem>Iraq</asp:ListItem>
			<asp:ListItem>Ireland</asp:ListItem>
			<asp:ListItem>Isle of Man</asp:ListItem>
			<asp:ListItem>Israel</asp:ListItem>
			<asp:ListItem>Italy</asp:ListItem>
			<asp:ListItem>Ivory Coast</asp:ListItem>
			<asp:ListItem>Jamaica</asp:ListItem>
			<asp:ListItem>Japan</asp:ListItem>
			<asp:ListItem>Jersey</asp:ListItem>
			<asp:ListItem>Jordan</asp:ListItem>
			<asp:ListItem>Kazakhstan</asp:ListItem>
			<asp:ListItem>Kenya</asp:ListItem>
			<asp:ListItem>Kiribati</asp:ListItem>
			<asp:ListItem>Korea_North</asp:ListItem>
			<asp:ListItem>Korea_South</asp:ListItem>
			<asp:ListItem>Kuwait</asp:ListItem>
			<asp:ListItem>Kyrgyzstan</asp:ListItem>
			<asp:ListItem>Laos</asp:ListItem>
			<asp:ListItem>Latvia</asp:ListItem>
			<asp:ListItem>Lebanon</asp:ListItem>
			<asp:ListItem>Lesotho</asp:ListItem>
			<asp:ListItem>Liberia</asp:ListItem>
			<asp:ListItem>Libya</asp:ListItem>
			<asp:ListItem>Liechtenstein</asp:ListItem>
			<asp:ListItem>Lithuania</asp:ListItem>
			<asp:ListItem>Luxembourg</asp:ListItem>
			<asp:ListItem>Macau</asp:ListItem>
			<asp:ListItem>Macedonia</asp:ListItem>
			<asp:ListItem>Madagascar</asp:ListItem>
			<asp:ListItem>Magyarorsz&#225;g</asp:ListItem>
			<asp:ListItem>Malawi</asp:ListItem>
			<asp:ListItem>Malaysia</asp:ListItem>
			<asp:ListItem>Maldives</asp:ListItem>
			<asp:ListItem>Mali</asp:ListItem>
			<asp:ListItem>Malta</asp:ListItem>
			<asp:ListItem>Marshall Islands</asp:ListItem>
			<asp:ListItem>Martinique</asp:ListItem>
			<asp:ListItem>Mauritania</asp:ListItem>
			<asp:ListItem>Mauritius</asp:ListItem>
			<asp:ListItem>Mayotte</asp:ListItem>
			<asp:ListItem>Mexico</asp:ListItem>
			<asp:ListItem>Micronesia, Federated States of</asp:ListItem>
			<asp:ListItem>Midway Islands</asp:ListItem>
			<asp:ListItem>Moldova</asp:ListItem>
			<asp:ListItem>Monaco</asp:ListItem>
			<asp:ListItem>Mongolia</asp:ListItem>
			<asp:ListItem>Montserrat</asp:ListItem>
			<asp:ListItem>Morocco</asp:ListItem>
			<asp:ListItem>Mozambique</asp:ListItem>
			<asp:ListItem>Myanmar</asp:ListItem>
			<asp:ListItem>Namibia</asp:ListItem>
			<asp:ListItem>Nauru</asp:ListItem>
			<asp:ListItem>Nepal</asp:ListItem>
			<asp:ListItem>Netherlands Antilles</asp:ListItem>
			<asp:ListItem>Netherlands</asp:ListItem>
			<asp:ListItem>New Zealand</asp:ListItem>
			<asp:ListItem>Nicaragua</asp:ListItem>
			<asp:ListItem>Niger</asp:ListItem>
			<asp:ListItem>Nigeria</asp:ListItem>
			<asp:ListItem>Niue</asp:ListItem>
			<asp:ListItem>Norfolk Island</asp:ListItem>
			<asp:ListItem>Norway</asp:ListItem>
			<asp:ListItem>Oman</asp:ListItem>
			<asp:ListItem>Pakistan</asp:ListItem>
			<asp:ListItem>Palau Islands</asp:ListItem>
			<asp:ListItem>Panama</asp:ListItem>
			<asp:ListItem>Papua New Guinea</asp:ListItem>
			<asp:ListItem>Paraguay</asp:ListItem>
			<asp:ListItem>Peru</asp:ListItem>
			<asp:ListItem>Philippines</asp:ListItem>
			<asp:ListItem>Pitcairn</asp:ListItem>
			<asp:ListItem>Poland</asp:ListItem>
			<asp:ListItem>Portugal</asp:ListItem>
			<asp:ListItem>Puerto Rico</asp:ListItem>
			<asp:ListItem>Qatar</asp:ListItem>
			<asp:ListItem>Reunion</asp:ListItem>
			<asp:ListItem>Romania</asp:ListItem>
			<asp:ListItem>Russia</asp:ListItem>
			<asp:ListItem>Rwanda</asp:ListItem>
			<asp:ListItem>Saint Helena</asp:ListItem>
			<asp:ListItem>Saint Kitts and Nevis</asp:ListItem>
			<asp:ListItem>Saint Lucia</asp:ListItem>
			<asp:ListItem>Saint Pierre and Miquelon</asp:ListItem>
			<asp:ListItem>Saint Vincent and Grenadines</asp:ListItem>
			<asp:ListItem>Samoa (American)</asp:ListItem>
			<asp:ListItem>Samoa (Western)</asp:ListItem>
			<asp:ListItem>San Marino</asp:ListItem>
			<asp:ListItem>Sao Tome and Principe</asp:ListItem>
			<asp:ListItem>Saudi Arabia</asp:ListItem>
			<asp:ListItem>Senegal</asp:ListItem>
			<asp:ListItem>Serbia and Montenegro</asp:ListItem>
			<asp:ListItem>Seychelles</asp:ListItem>
			<asp:ListItem>Sierra Leone</asp:ListItem>
			<asp:ListItem>Singapore</asp:ListItem>
			<asp:ListItem>Slovakia</asp:ListItem>
			<asp:ListItem>Slovenia</asp:ListItem>
			<asp:ListItem>Solomon Islands</asp:ListItem>
			<asp:ListItem>Somalia</asp:ListItem>
			<asp:ListItem>South Africa</asp:ListItem>
			<asp:ListItem>South Georgia and South Sandwich Islands</asp:ListItem>
			<asp:ListItem>Spain</asp:ListItem>
			<asp:ListItem>Sri Lanka</asp:ListItem>
			<asp:ListItem>Sudan</asp:ListItem>
			<asp:ListItem>Suriname</asp:ListItem>
			<asp:ListItem>Swaziland</asp:ListItem>
			<asp:ListItem>Sweden</asp:ListItem>
			<asp:ListItem>Switzerland</asp:ListItem>
			<asp:ListItem>Syria</asp:ListItem>
			<asp:ListItem>Taiwan</asp:ListItem>
			<asp:ListItem>Tajikistan</asp:ListItem>
			<asp:ListItem>Tanzania</asp:ListItem>
			<asp:ListItem>Thailand</asp:ListItem>
			<asp:ListItem>Togo</asp:ListItem>
			<asp:ListItem>Tokelau</asp:ListItem>
			<asp:ListItem>Tonga</asp:ListItem>
			<asp:ListItem>Trinidad and Tobago</asp:ListItem>
			<asp:ListItem>Tunisia</asp:ListItem>
			<asp:ListItem>Turkey</asp:ListItem>
			<asp:ListItem>Turkmenistan</asp:ListItem>
			<asp:ListItem>Turks and Caicos Islands</asp:ListItem>
			<asp:ListItem>Tuvalu Islands</asp:ListItem>
			<asp:ListItem>Uganda</asp:ListItem>
			<asp:ListItem>Ukraine</asp:ListItem>
			<asp:ListItem>United Arab Emirates</asp:ListItem>
			<asp:ListItem>United Kingdom</asp:ListItem>
			<asp:ListItem>Uruguay</asp:ListItem>
			<asp:ListItem>USA</asp:ListItem>
			<asp:ListItem>Uzbekistan</asp:ListItem>
			<asp:ListItem>Vanuatu</asp:ListItem>
			<asp:ListItem>Venezuela</asp:ListItem>
			<asp:ListItem>Vietnam</asp:ListItem>
			<asp:ListItem>Virgin Islands</asp:ListItem>
			<asp:ListItem>Wake Island</asp:ListItem>
			<asp:ListItem>Wallis and Futuna</asp:ListItem>
			<asp:ListItem>West Bank</asp:ListItem>
			<asp:ListItem>Yemen</asp:ListItem>
			<asp:ListItem>Zambia</asp:ListItem>
			<asp:ListItem>Zimbabwe</asp:ListItem>
    </asp:DropDownList>
</div>
<div class="spacer15">&nbsp;</div>
<div class="leftflow bele w3">City / Town</div>
<div class="leftflow bele">: <asp:TextBox ID="cityTextBox" runat="server" Width="203px" TabIndex="9"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="city1RequiredFieldValidator" runat="server" ErrorMessage="Please enter Your City of Birth" ControlToValidate="cityTextBox">*</asp:RequiredFieldValidator></div>
<div class="spacer15">&nbsp;</div>
<div class="spacerb">&nbsp;</div>
<div class="spacer15">&nbsp;</div>
<div class="leftflow bele w3"></div>
<div class="leftflow bele">&nbsp;&nbsp;
    <asp:Button ID="reset" runat="server" Text="Reset" Width="60px" OnClick="reset_Click" TabIndex="-1"/>&nbsp;&nbsp;
    <asp:Button ID="continueButton" runat="server" Text="Continue" Width="70px" PostBackUrl="~/Atlas.aspx" TabIndex="10"/>
</div>

<div class="spacer15">&nbsp;</div>
<div class="pad4 greyele"><b>Note:</b> if the place you were born is too small 
	for our atlas, you may need to go back and re-submit a nearby larger city.</div>
<div class="spacer">&nbsp;</div>
<div class="spacerb">&nbsp;</div>


</div>
       
        <asp:ValidationSummary ID="ValidationSummary" runat="server" />
    </form>
</body>
</html>
