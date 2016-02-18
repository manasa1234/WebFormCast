<%@ Page Language="C#" AutoEventWireup="true" Inherits="attorney_AddI140" Codebehind="addI140.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>USIT</title>
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            background-image: url('../images/topbar_bg.gif');
            background-repeat: repeat-x;
            padding: 0 3px 0 3px;
            width: 966px;
        }
    </style>
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../css/calendar-tas.css" rel="stylesheet" type="text/css" />
    <script src="../calendar.js" type="text/javascript"></script>
    <script src="../lang/calendar-en.js" type="text/javascript"></script>
    <script src="../calendar-setup.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <div id="header">
            <div id="headerlogo">
                <asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>
            <div id="login_info">
                Welcome! <strong>
                    <asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">
                        Logout</a></div>
        </div>
        <div id="contentShadows">
            <asp:Label ID="lbNavigation" runat="server">
                        <ul class="topNav">
                            <li><a href="home.aspx"><b>Home</b></a></li>  
                            <li><a href="cases.aspx"><b>Cases</b></a></li>
                            <li><a href="clientmanager.aspx"><b>Client Manager</b></a></li>
                            <li><a href="useraccounts.aspx"><b>User Accounts</b></a></li>
                            <li><a href="templates.aspx"><b>Templates</b></a></li>
                            <li><a href="forms.aspx"><b>Forms</b></a></li>
                            <li><a href="myaccount.aspx"><b>My Account</b></a></li>
                            <li class="current"><a href="trackingSys.aspx"><b>Track. Sys.</b></a></li>
                        </ul>
            </asp:Label>
            <div id="contentArea1">
                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td width="2">
                            <img src="../images/topbar_lft.gif" width="2" height="87" />
                        </td>
                        <td class="topbar_bg">
                            <table border="0" align="left" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="2">
                                        <img src="../images/topbar_sub_lft.gif" width="2" height="78" />
                                    </td>
                                    <td align="left" class="topbar_sub_bg">
                                        <table border="0" align="left" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    Company Name
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddCompany" runat="server" DataSourceID="SqlDataSource1" DataTextField="Legal_Name"
                                                        DataValueField="CompanyID" Style="width: 200px" AppendDataBoundItems="True" EnableViewState="true"
                                                        OnSelectedIndexChanged="ddCompany_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Selected="True" Value='All'>All</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;Reports By Company
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddReport" runat="server" Style="width: 200px" AppendDataBoundItems="True"
                                                        EnableViewState="true" AutoPostBack="true" OnSelectedIndexChanged="ddReport_Changed">
                                                        <asp:ListItem Value=''>Select</asp:ListItem>
                                                        <asp:ListItem Value='I-140 - Approved'>I-140 - Approved</asp:ListItem>
                                                        <asp:ListItem Value='I-140 - Assigned To'>I-140 - Assigned To</asp:ListItem>
                                                        <asp:ListItem Value='I-140 - Drafted'>I-140 - Drafted</asp:ListItem>
                                                        <asp:ListItem Value='I-140 - Not Filed'>I-140 - Not Filed</asp:ListItem>
                                                        <asp:ListItem Value='I-140 - RFE Issued'>I-140 - RFE Issued</asp:ListItem>
                                                        <asp:ListItem Value='I-140 - Due Date Range'>I-140 - Due Date Range</asp:ListItem>
                                                        <asp:ListItem Value='I-140 - RFE Due Date Range'>I-140 - RFE Due Date Range</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblInfo" runat="server" Text="Choose Select or Hit Reset to activate all fields" Visible="false" Style="color: #993300; font-size: x-small; font-weight: 500" ForeColor="#993300" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Status
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddStatus" runat="server" Style="width: 200px" EnableViewState="true"
                                                        OnSelectedIndexChanged="ddStatus_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem>All</asp:ListItem>
                                                        <asp:ListItem>Not Filed</asp:ListItem>
                                                        <asp:ListItem>Pending</asp:ListItem>
                                                        <asp:ListItem>RFE</asp:ListItem>
                                                        <asp:ListItem>Approved</asp:ListItem>
                                                        <asp:ListItem>Denied</asp:ListItem>
                                                        <asp:ListItem>Inactivated</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;<asp:Label ID="lbAssignedTo" runat="server" Text="Assigned To" Visible="false" />
                                                    <asp:Label ID="lblDateFrom" runat="server" Text="From" Visible="false" />
                                                    <asp:Label ID="lblPWDTrackNo" runat="server" Text="PWD Track Number" Visible="false" />
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstUsers" runat="server" CssClass="style8" AppendDataBoundItems="True"
                                                        EnableViewState="False" Visible="false" DataSourceID="SqlDataSource3" DataTextField="User_Display_Name"
                                                        DataValueField="User_ID" Height="20px" Width="200px">
                                                        <asp:ListItem Selected="True" Value='0'>Select User</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtDateFrom" runat="server" Width="160px" Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="txtPWDTrackNo" runat="server" Width="160px" Visible="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tracking ID / Beneficiary
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTrackingNo" runat="server" Width="160px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblDateTo" runat="server" Text="To" Visible="false" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDateTo" runat="server" Width="160px" Visible="false"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="i140Search" runat="server" CausesValidation="false" Text="&nbsp;Find&nbsp;Case&nbsp;"
                                                        OnClick="i140Search_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="reset" runat="server" Text="&nbsp;Reset&nbsp;" CausesValidation="false"
                                                        OnClick="reset_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="2">
                                        <img src="../images/topbar_sub_rgt.gif" width="2" height="78" />
                                    </td>
                                </tr>
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ connectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [Legal_Name], [CompanyID] FROM [Company] WHERE ([Legal_Name] <> '') ORDER BY Legal_Name">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB%>"
                                    SelectCommand="SELECT * FROM [I140Tracking] ORDER BY TrackingNo"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [User_Display_Name], [User_ID] FROM [Users] WHERE ([User_Display_Name] <> '')">
                                </asp:SqlDataSource>
                            </table>
                        </td>
                        <td width="2">
                            <img src="../images/topbar_rgt.gif" width="2" height="87" />
                        </td>
                    </tr>
                </table>
                </table>
                <div class="shadow">
                </div>
                <div class="title">
                    Add New I-140 Information</div>
                <div class="bcru">
                    <a href="i140.aspx">I-140</a> &raquo; Add I-140</div>
                <div id="whiteArea">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <th align="left">
                                I-140
                            </th>
                        </tr>
                        <tr>
                            <td align="center">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="style1">
                                            Company
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstCompany" runat="server" CssClass="style8" AppendDataBoundItems="True"
                                                EnableViewState="False" DataSourceID="SqlDataSource1" DataTextField="Legal_Name"
                                                DataValueField="CompanyID" Style="font-family: Verdana; font-size: small; text-align: left;"
                                                AutoPostBack="True" Height="20px" Width="350px" OnSelectedIndexChanged="lstCompany_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Value=''>-- Select Company Name</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="< --- Missing"
                                                ControlToValidate="lstCompany"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Tracking ID
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstTrackNo" runat="server" AutoPostBack="True" Style="font-family: Verdana;
                                                font-size: small" DataSourceID="SqlDataSource2" DataTextField="Tracking_No" DataValueField="Name"
                                                Height="20px" Width="350px" AppendDataBoundItems="True" EnableViewState="False"
                                                OnSelectedIndexChanged="lstTrackNo_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Value=''>-- Select Case Number</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="< --- Missing" 
                                                ControlToValidate="lstTrackNo"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblTrackNo" runat="server" Text="I-140 file already exists!" Visible="false" Style="color: #993300; font-weight: 500" ForeColor="#993300" />                                                
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Beneficiary
                                        </td>
                                        <td>
                                            <asp:TextBox ID="lstName" runat="server" BorderStyle="None" ReadOnly="True" Width="347px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="< --- Missing"
                                                ControlToValidate="lstName"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            I-140 Receipt No
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtReceiptNo" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Last Updated Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLastUpdDate" runat="server" Width="100px" OnTextChanged="LastUpdDate_Changed"
                                                AutoPostBack="true" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="< --- Missing"
                                                ControlToValidate="txtLastUpdDate" EnableClientScript="false" ></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Docs Received?
                                        </td>
                                        <td>
                                            <asp:CheckBox runat="server" ID="chkI140Docs" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Assigned To
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstUsersI140" runat="server" CssClass="style8" AppendDataBoundItems="True"
                                                EnableViewState="False" OnSelectedIndexChanged="lstUsersI140_Changed" DataSourceID="SqlDataSource3"
                                                DataTextField="User_Display_Name" DataValueField="User_ID" Style="font-family: Verdana;
                                                font-size: small; text-align: left;" AutoPostBack="True" Height="20px" Width="350px">
                                                <asp:ListItem Selected="True" Value='0'>Select User</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Missing Docs
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtI140MissingDocs" runat="server" TextMode="MultiLine" Width="550px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Checklist
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkDrafted" />Drafted
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkPermPages" />PERM&nbsp;pages&nbsp;sent&nbsp;for&nbsp;signatures
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkPremium" />Premium
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkI140Filed" />I-140&nbsp;Filed
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Filed Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtI140FiledDate" runat="server" Width="100px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            I-140 Invoice No.
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtI140InvNo" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Payment Received?
                                        </td>
                                        <td>
                                            <asp:CheckBox runat="server" ID="chkI140Payment" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Due Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtI140DueDate" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Status
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstI140Status" runat="server" OnSelectedIndexChanged="I140Status_SelectedIndexChanged"
                                                AutoPostBack="True">
                                                <asp:ListItem Selected="True">Not Filed</asp:ListItem>
                                                <asp:ListItem>Pending</asp:ListItem>
                                                <asp:ListItem>RFE</asp:ListItem>
                                                <asp:ListItem>Approved</asp:ListItem>
                                                <asp:ListItem>Denied</asp:ListItem>
                                                <asp:ListItem>Inactivated</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            RFE Due Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtI140RFEDueDate" runat="server" Width="100px" Enabled="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            RFE Status
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstI140RFEStatus" runat="server" Enabled="false">
                                                <asp:ListItem Selected="True">Pending</asp:ListItem>
                                                <asp:ListItem>Denied</asp:ListItem>
                                                <asp:ListItem>Approved</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            RFE Type
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkPayAbility" Enabled="false" />Ability&nbsp;to&nbsp;pay
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkAcademics" Enabled="false" />Academics
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkExperience" Enabled="false" />Experience
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkOther" Enabled="false" OnCheckedChanged="I140RFEOther_CheckedChanged"
                                                            AutoPostBack="true" />Other
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            RFE Type Other Notes
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtI140RFEOtherNotes" runat="server" TextMode="MultiLine" Width="550px"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            I140 Comments and Status
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtI140Comments" runat="server" TextMode="MultiLine" 
                                                Width="550px" Height="47px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                        </td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [Legal_Name], [CompanyID] FROM [Company] WHERE ([Legal_Name] <> '') ORDER BY Legal_Name">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ connectionStrings:ACLG_DB%>"
                                    SelectCommand="SELECT distinct [First_Name] +' '+ [Last_Name] as Name, [Tracking_No],Employee_id FROM [Employee] WHERE ([Company_id] = @Company_id) order by [Tracking_No] ">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lstcompany" Name="Company_id" PropertyName="SelectedValue"
                                            Type="Decimal" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [User_Display_Name], [User_ID] FROM [Users] WHERE ([User_Display_Name] <> '')">
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="footer">
            <a href="http://www.raminenilaw.com/?page_id=258"></a><a href="http://www.raminenilaw.com/?page_id=258">
                Contact Us</a> | <a href="legal_notices.html">Legal Notice </a>
            <br />
            &copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
    </div>
    </form>
    <script type="text/javascript">
        Calendar.setup({
            inputField: "txtLastUpdDate",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "txtLastUpdDate",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });
    </script>
    <script src="../scripts/content.js" type="text/javascript"></script>
</body>
</html>
