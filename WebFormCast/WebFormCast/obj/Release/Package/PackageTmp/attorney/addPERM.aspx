<%@ Page Language="C#" AutoEventWireup="true" Inherits="attorney_AddPERM" Codebehind="addPERM.aspx.cs" %>

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
                <table border="0" cellspacing="0" cellpadding="0" style="width: 99%">
                    <tr>
                        <td width="2">
                            <img src="../images/topbar_lft.gif" width="2" height="87" />
                        </td>
                        <td class="style1">
                            &nbsp;
                        </td>
                        <td width="2">
                            <img src="../images/topbar_rgt.gif" width="2" height="87" />
                        </td>
                    </tr>
                </table>
                <div class="shadow">
                </div>
                <div class="title">
                    Add New PERM Information</div>
                <div class="bcru">
                    <a href="perm.aspx">PERM</a> &raquo; Add PERM</div>
                <div id="whiteArea">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <th align="left">
                                PERM
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
                                            <asp:Label ID="lblTrackNo" runat="server" Text="PERM file already exists!" Visible="false" Style="color: #993300; font-weight: 500" ForeColor="#993300" />                                                
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
                                            PWD Track Number
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPWDTrack" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Last Updated Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLastUpdDate" runat="server" Width="100px" OnTextChanged="LastUpdDate_Changed" AutoPostBack="true"/>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="< --- Missing"
                                                ControlToValidate="txtLastUpdDate" EnableClientScript="false" ></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            PERM Category
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstPERMCat" runat="server">
                                                <asp:ListItem Selected="True">EB2 MS Only</asp:ListItem>
                                                <asp:ListItem>EB2 MS+Exp</asp:ListItem>
                                                <asp:ListItem>EB2 Bach+5/MS+3</asp:ListItem>
                                                <asp:ListItem>EB-3 Professional</asp:ListItem>
                                                <asp:ListItem>EB-3 Skilled Worker</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="< --- Missing"
                                                ControlToValidate="lstPERMCat"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Date PWD Filed
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDatePWDFiled" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Date PWD Issued
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDatePWDIss" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            PWD Expiry Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDatePWDExp" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            PWD Status
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstPWDStatus" runat="server">
                                                <asp:ListItem Selected="True">Pending</asp:ListItem>
                                                <asp:ListItem>Issued</asp:ListItem>
                                                <asp:ListItem>RFI</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Job Title
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtJobTitle" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="< --- Missing"
                                                ControlToValidate="txtJobTitle"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Salary
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSal" runat="server" Width="350px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="< --- Missing"
                                                ControlToValidate="txtSal"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Recruitment Start Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRecStartDate" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Recruitment End Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRecEndDate" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            PERM Assigned To
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstUsers" runat="server" CssClass="style8" AppendDataBoundItems="True"
                                                EnableViewState="False" OnSelectedIndexChanged="lstUsers_Changed" DataSourceID="SqlDataSource3"
                                                DataTextField="User_Display_Name" DataValueField="User_ID" Style="font-family: Verdana;
                                                font-size: small; text-align: left;" AutoPostBack="True" Height="20px" Width="350px">
                                                <asp:ListItem Selected="True" Value='0'>Select User</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="< --- Missing"
                                                ControlToValidate="lstUsers"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            PERM Filing/Priority Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPERMPriDate" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            PERM Track Number
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPERMTrack" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            PERM Status
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstPERMStatus" runat="server" OnSelectedIndexChanged="PERMStatus_SelectedIndexChanged"
                                                AutoPostBack="True">
                                                <asp:ListItem Selected="True">Not Filed</asp:ListItem>
                                                <asp:ListItem>Pending</asp:ListItem>
                                                <asp:ListItem>Audit</asp:ListItem>
                                                <asp:ListItem>Certified</asp:ListItem>
                                                <asp:ListItem>Denied</asp:ListItem>
                                                <asp:ListItem>Inactivated</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            PERM Due Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPERMDueDate" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Audit Due Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAuditDueDate" runat="server" Width="100px" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Audit Status
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstAuditStatus" runat="server" Enabled="false">
                                                <asp:ListItem Selected="True">Pending</asp:ListItem>
                                                <asp:ListItem>Denied</asp:ListItem>
                                                <asp:ListItem>Certified </asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Audit Type
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkAuditTypeTR" Enabled="false" />Travel&nbsp;Requirement
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkAuditTypeERP" Enabled="false" />Employee&nbsp;Referral&nbsp;Program
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkAuditTypeEP" Enabled="false" />Employee&nbsp;Payments
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkAuditTypeR" Enabled="false" />Resumes
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkAuditTypeRD" Enabled="false" />Recruitment&nbsp;Docs
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkAuditTypeRR" Enabled="false" />Recruitment&nbsp;Report
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkAuditTypeBN" Enabled="false" />Business&nbsp;Necessity
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkAuditTypeO" Enabled="false" OnCheckedChanged="AuditTypeO_CheckedChanged"
                                                            AutoPostBack="true" />Other
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Audit Type Other Notes
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAudTypeOtherNotes" runat="server" TextMode="MultiLine" Width="550px"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            PERM Certification Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPERMCertDate" runat="server" Width="100px" OnTextChanged="PERMCertDate_Changed"
                                                AutoPostBack="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            I-140 Due Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtI140DueDate" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Invoice No.
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtInvNo" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Payment Received?
                                        </td>
                                        <td>
                                            <asp:CheckBox runat="server" ID="chkPmnt" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            PERM Comments and Status
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPERMNotes" runat="server" TextMode="MultiLine" Width="550px"
                                                Height="48px"></asp:TextBox>
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
                                    SelectCommand="SELECT [First_Name] +' '+ [Last_Name] as Name, [Tracking_No],Employee_id FROM [Employee] WHERE ([Company_id] = @Company_id) order by [Tracking_No] ">
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
