<%@ Page Language="C#" AutoEventWireup="true" Inherits="attorney_AddLCA" Codebehind="addLCA.aspx.cs" %>

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
                    Add New LCA Information</div>
                <div class="bcru">
                    <a href="lca.aspx">LCA</a> &raquo; Add LCA</div>
                <div id="whiteArea">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="center">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="style1">
                                            Company:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstcompany" runat="server" CssClass="style8" AppendDataBoundItems="True"
                                                EnableViewState="False" DataSourceID="SqlDataSource1" DataTextField="Legal_Name"
                                                DataValueField="CompanyID" Style="font-family: Verdana; font-size: small; text-align: left;"
                                                AutoPostBack="True" Height="20px" Width="350px" OnSelectedIndexChanged="lstcompany_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Value=''>-- Select Company Name</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Tracking ID:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="RlTrack" runat="server" AutoPostBack="True" Style="font-family: Verdana;
                                                font-size: small" DataSourceID="SqlDataSource2" DataTextField="Tracking_No" DataValueField="Employee_Id"
                                                Height="20px" Width="350px" AppendDataBoundItems="True" EnableViewState="False"
                                                OnSelectedIndexChanged="RlTrack_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Value=''>-- Select Case Number</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Beneficiary:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="lstname" runat="server" BorderStyle="None" ReadOnly="True" Width="347px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="-- Missing"
                                                ControlToValidate="lstname"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            LCA Track Number:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLCTrack" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Type of LCA:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstType" runat="server">
                                                <asp:ListItem Selected="True">New Not Subject to CAP</asp:ListItem>
                                                <asp:ListItem>New Cap Subject</asp:ListItem>
                                                <asp:ListItem>Transfer</asp:ListItem>
                                                <asp:ListItem>Amendment</asp:ListItem>                                          
                                                <asp:ListItem>Extension + Amendment</asp:ListItem>                                          
                                                <asp:ListItem>Extension</asp:ListItem>                                          
                                                <asp:ListItem>New</asp:ListItem>
                                                <asp:ListItem>Change of End Client</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Date Filed:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdatefiled" runat="server" Width="100px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                ControlToValidate="txtdatefiled" EnableClientScript="false" ErrorMessage="< --- Missing"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Employment Start Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="EmpStartdate" runat="server" Width="100px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                ControlToValidate="EmpStartdate" EnableClientScript="false" ErrorMessage="< --- Missing"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Employment End&nbsp; Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="EmpEnddate" runat="server" Width="100px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                ControlToValidate="EmpEnddate" EnableClientScript="false" ErrorMessage="< --- Missing"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Job Title
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txttitle" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                                ControlToValidate="txttitle" ErrorMessage="< --- Missing"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            LCA Location
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtloc" runat="server" Width="350px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                                ControlToValidate="txtloc" ErrorMessage="< --- Missing"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            County
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCounty" runat="server" Width="350px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                ControlToValidate="txtCounty" ErrorMessage="< --- Missing"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            SOC
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSOC" runat="server" Width="350px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Salary
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtsal" runat="server" Width="350px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                                                ControlToValidate="txtsal" ErrorMessage="< --- Missing"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Level
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstSalLevel" runat="server">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>I</asp:ListItem>
                                                <asp:ListItem>II</asp:ListItem>
                                                <asp:ListItem>III</asp:ListItem>
                                                <asp:ListItem>IV</asp:ListItem>                                          
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Date of Action
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtdateaprd" runat="server" Width="100px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
                                                ControlToValidate="txtdateaprd" EnableClientScript="false" ErrorMessage="< --- Missing"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Current Status
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lststatus" runat="server">
                                                <asp:ListItem>Pending</asp:ListItem>
                                                <asp:ListItem>Certified</asp:ListItem>
                                                <asp:ListItem>Withdrawn</asp:ListItem>
                                                <asp:ListItem>Re-filed</asp:ListItem>
                                                <asp:ListItem>Denied</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Notes
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtnotes" runat="server" TextMode="MultiLine" Width="550px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                                            <asp:Label ID="Label1" runat="server" Style="color: #336600; font-weight: 700; font-family: Verdana;
                                                font-size: small"></asp:Label>
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
            inputField: "txtdatefiled",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "txtdatefiled",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });

        Calendar.setup({
            inputField: "EmpStartdate",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "EmpStartdate",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });

        Calendar.setup({
            inputField: "EmpEnddate",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "EmpEnddate",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });

        Calendar.setup({
            inputField: "txtdateaprd",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "txtdateaprd",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });
    </script>

    <script src="../scripts/content.js" type="text/javascript"></script>

</body>
</html>
