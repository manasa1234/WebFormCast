<%@ Page Language="C#" AutoEventWireup="true" Inherits="attorney_PERM" Codebehind="perm.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>USIT</title>
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../css/calendar-tas.css" rel="stylesheet" type="text/css" />
    <script src="../calendar.js" type="text/javascript"></script>
    <script src="../lang/calendar-en.js" type="text/javascript"></script>
    <script src="../calendar-setup.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server" defaultbutton="permSearch">
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
            <asp:Label ID="lbNavigation" runat="server"><ul class="topNav">
      <li><a href="home.aspx"><b>Home</b></a></li><li><a href="cases.aspx"><b>Cases</b></a></li><li><a href="clientmanager.aspx"><b>Client Manager</b></a></li><li><a href="useraccounts.aspx"><b>User Accounts</b></a></li><li><a href="templates.aspx"><b>Templates</b></a></li><li><a href="forms.aspx"><b>Forms</b></a></li><li><a href="myaccount.aspx"><b>My Account</b></a></li><li class="current"><a href="trackingSys.aspx"><b>Track. Sys.</b></a></li></ul></asp:Label>
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
                                                        <asp:ListItem Value='I-140 - All'>I-140 - All</asp:ListItem>
                                                        <asp:ListItem Value='PERM - ALL'>PERM - ALL</asp:ListItem>
                                                        <asp:ListItem Value='PERM - Assigned To'>PERM - Assigned To</asp:ListItem>
                                                        <asp:ListItem Value='PERM - Audit'>PERM - Audit</asp:ListItem>
                                                        <asp:ListItem Value='PERM - Certified'>PERM - Certified</asp:ListItem>
                                                        <asp:ListItem Value='PERM - Last Updated'>PERM - Last Updated</asp:ListItem>
                                                        <asp:ListItem Value='PERM - Not Filed'>PERM - Not Filed</asp:ListItem>
                                                        <asp:ListItem Value='PERM - Pending'>PERM - Pending</asp:ListItem>
                                                        <asp:ListItem Value='PERM - Due Date Range'>PERM - Due Date Range</asp:ListItem>
                                                        <asp:ListItem Value='PERM - Audit Due Date Range'>PERM - Audit Due Date Range</asp:ListItem>
                                                        <asp:ListItem Value='PERM Track Number'>PERM Track Number</asp:ListItem>
                                                        <asp:ListItem Value='PWD - Pending'>PWD - Pending</asp:ListItem>
                                                        <asp:ListItem Value='PWD - Issued'>PWD - Issued</asp:ListItem>
                                                        <asp:ListItem Value='PWD Track Number'>PWD Track Number</asp:ListItem>
                                                        <asp:ListItem Value='Recruitment - Expired'>Recruitment - Expired</asp:ListItem>
                                                        <asp:ListItem Value='Recruitment - Not Initiated'>Recruitment - Not Initiated</asp:ListItem>
                                                        <asp:ListItem Value='Recruitment - Unexpired'>Recruitment - Unexpired</asp:ListItem>
                                                        <asp:ListItem Value='Recruitment -Initiated'>Recruitment -Initiated</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblInfo" runat="server" Text="Choose Select or Hit Reset to activate all fields." Visible="false" Style="color: #993300; font-size: x-small; font-weight: 500" ForeColor="#993300" />
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
                                                        <asp:ListItem>Audit</asp:ListItem>
                                                        <asp:ListItem>Certified</asp:ListItem>
                                                        <asp:ListItem>Denied</asp:ListItem>
                                                        <asp:ListItem>Inactivated</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lbAssignedTo" runat="server" Text="Assigned To" Visible="false" />
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
                                                    <asp:TextBox ID="txtPWDTrackNo" runat="server" Width="193px" Visible="false"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPWDTrackNoInfo" runat="server" Text="Enter % before or after for wild card search." Visible="false" Style="color: #993300; font-size: x-small; font-weight: 500" ForeColor="#993300" />
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
                                                    <asp:Button ID="permSearch" runat="server" UseSubmitBehavior="true" Text="&nbsp;Find&nbsp;Case&nbsp;"
                                                        OnClick="permSearch_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="reset" runat="server" UseSubmitBehavior="true" Text="&nbsp;Reset&nbsp;"
                                                        OnClick="reset_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="2">
                                        <img src="../images/topbar_sub_rgt.gif" width="2" height="78" />
                                    </td>
                                </tr>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ connectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [Legal_Name], [CompanyID] FROM [Company] WHERE ([Legal_Name] <> '') ORDER BY Legal_Name">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB%>"
                                    SelectCommand="SELECT PERMTracking.*, Employee.Employee_ID FROM [PERMTracking], [Employee] where PERMTracking.TrackingNo = Employee.Tracking_No  ORDER BY TrackingNo">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [User_Display_Name], [User_ID] FROM [Users] WHERE ([User_Display_Name] <> '')">
                                </asp:SqlDataSource>
                            </table>
                        </td>
                        <td width="2">
                            <img src="../images/topbar_rgt.gif" width="2" height="87" />
                        </td>
                    </tr>
                </table>
                <div class="shadow">
                </div>
                <div class="title">
                    PERM</div>
                <div class="bcru">
                    PERM&raquo;<asp:Label ID="lbCompanyName" runat="server"></asp:Label>&raquo;<asp:Label
                        ID="lbStatus" runat="server"></asp:Label>&raquo;<asp:Label ID="lbTrackId" runat="server"></asp:Label>&raquo;<asp:Label
                            ID="lbReport" runat="server"></asp:Label>&raquo;
                    <asp:Label ID="lbCount" runat="server" Style="color: #993300; font-size: x-small;
                        font-weight: 700" ForeColor="#993300"></asp:Label>
                </div>
                <div id="whiteArea">
                    <div align="right">
                        <a href="addPERM.aspx"><b>Create New PERM</b></a></div>
                    <asp:GridView ID="gvPERM" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2"
                        OnRowDataBound="gvPERM_RowDataBound" Style="font-size: x-small; font-family: Verdana;"
                        Width="932px" Visible="False" Font-Size="X-Small" DataKeyNames="ID">
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="Employee_Id" DataNavigateUrlFormatString="case.aspx?Attorney_Employee_Id={0}"
                                NavigateUrl="case.aspx" HeaderText="Tracking ID" DataTextField="TrackingNo" />
                            <asp:BoundField DataField="PERMTrackingNo" HeaderText="PERM Track Number" SortExpression="PERMTrackingNo" />
                            <asp:BoundField DataField="Legal_Name" HeaderText="Company" SortExpression="Legal_Name" />
                            <asp:BoundField DataField="Beneficiary" HeaderText="Beneficiary" SortExpression="Beneficiary" />
                            <asp:BoundField DataField="PERMStatus" HeaderText="Status" SortExpression="PERMStatus" />
                            <asp:BoundField DataField="DateLastUpdated_NoTime" HeaderText="Last Updated Date"
                                SortExpression="DateLastUpdated" />
                            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="editPERM.aspx?PERMID={0}&custMode=view"
                                DataTextFormatString="Edit" NavigateUrl="editPERM.aspx?&custMode=view" ShowHeader="False" Text="View" />
                            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="editPERM.aspx?PERMID={0}&custMode=edit"
                                DataTextFormatString="Edit" NavigateUrl="editPERM.aspx?&custMode=edit" ShowHeader="False" Text="Edit" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div id="footer">
            <a href="http://www.raminenilaw.com/?page_id=258"></a><a href="http://www.raminenilaw.com/?page_id=258">
                Contact Usm"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a>
            | <a href="legal_notices.html">Legal Notice </a>
            <br />
            &copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
    </div>
    </form>
    <script type="text/javascript">
        var elements = document.forms[0].elements;
        for (var i = 0; i < elements.length; i++) {
            if (elements[i].id == "txtDateFrom" && elements[i].type == "text") {
                Calendar.setup({
                    inputField: elements[i].id,     // id of the input field
                    ifFormat: "%m/%d/%Y",      // format of the input field
                    button: elements[i].id,  // trigger for the calendar (button ID)
                    align: "Br",           // alignment (defaults to "Bl")
                    singleClick: true
                });
            }
            if (elements[i].id == "txtDateTo" && elements[i].type == "text") {
                Calendar.setup({
                    inputField: elements[i].id,     // id of the input field
                    ifFormat: "%m/%d/%Y",      // format of the input field
                    button: elements[i].id,  // trigger for the calendar (button ID)
                    align: "Br",           // alignment (defaults to "Bl")
                    singleClick: true
                });
            }
        }
    </script>
    <script src="../scripts/content.js" type="text/javascript"></script>
</body>
</html>
