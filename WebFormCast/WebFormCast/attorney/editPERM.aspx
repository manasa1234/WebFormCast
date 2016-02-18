<%@ Page Language="C#" AutoEventWireup="true" Inherits="attorney_EditPERM" Codebehind="editPERM.aspx.cs" %>
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
    <form id="form1" runat="server">
        <div id="container">
            <div id="header">
                <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
                <div id="login_info">Welcome! <strong><asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
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
                                                    <asp:DropDownList ID="ddCompany" runat="server" DataSourceID="SqlDataSource4" DataTextField="Legal_Name"
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
                                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="style8" AppendDataBoundItems="True"
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
                                                    <asp:Button ID="permSearch" runat="server"  CausesValidation="false" Text="&nbsp;Find&nbsp;Case&nbsp;" 
                                                        OnClick="permSearch_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="reset" runat="server" CausesValidation="false" Text="&nbsp;Reset&nbsp;"
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
                                    SelectCommand="SELECT PERMTracking.*, Employee.Employee_ID FROM [PERMTracking], [Employee] where PERMTracking.TrackingNo = Employee.Tracking_No  ORDER BY TrackingNo">
                                </asp:SqlDataSource>
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
                <div class="shadow"></div>
                <div class="title">Edit PERM</div>
                <div class="bcru"><a href="perm.aspx">PERM</a> » Edit PERM</div>
                <div id="whiteArea">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ connectionStrings:ACLG_DB %>" 
                        DeleteCommand="DELETE FROM [PERMTracking] WHERE [ID] = @ID" 
                        SelectCommand="SELECT PERMTracking.*, CONVERT(VARCHAR(10),PERMTracking.DateLastUpdated,101) c_DateLastUpdated, Company.* FROM [PERMTracking], Company where CompanyID = Company and [ID] = @ID" 
                        UpdateCommand="UPDATE [PERMTracking] SET  [PWDTrackingNo] = @PWDTrackingNo, [DateLastUpdated] = cast(@c_DateLastUpdated as date), [PERMCategory] = @PERMCategory, [DatePWDFiled] = @DatePWDFiled, [DatePWDIssued] = @DatePWDIssued, [DatePWDExpiry] = @DatePWDExpiry, [PWDStatus] = @PWDStatus, [JobTitle] = @JobTitle, [Salary] = @Salary, [DateRecruitmentStart] = @DateRecruitmentStart, [DateRecruitmentEnd] = @DateRecruitmentEnd, [PERMAssignedTo] = @PERMAssignedTo, [PERMFilingDate] = @PERMFilingDate, [PERMTrackingNo] = @PERMTrackingNo, [PERMStatus] = @PERMStatus, [PERMDueDate] = @PERMDueDate, [AuditDueDate] = @AuditDueDate, [AuditStatus] = @AuditStatus, [AuditTypeTR] = @AuditTypeTR, [AuditTypeERP] = @AuditTypeERP, [AuditTypeEP] = @AuditTypeEP, [AuditTypeR] = @AuditTypeR, [AuditTypeRD] = @AuditTypeRD, [AuditTypeRR] = @AuditTypeRR, [AuditTypeBN] = @AuditTypeBN, [AuditTypeO] = @AuditTypeO, [AuditTypeOtherComments] = @AuditTypeOtherComments, [PERMCertDate] = @PERMCertDate, [PERMI140DueDate] = @PERMI140DueDate, [InvNo] = @InvNo, [PaymentReceived] = @PaymentReceived, [PERMNotes] = @PERMNotes WHERE [ID] = @ID "  
                        OnUpdated="OnDSUpdatedHandler" OnDeleted="OnRecordDeleted">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>                        
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ID" QueryStringField="PERMID" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="TrackingNo" Type="String" />
                            <asp:Parameter Name="Company" Type="Int32" />
                            <asp:Parameter Name="PWDTrackingNo" Type="String" />
                            <asp:Parameter Name="Beneficiary" Type="String" />
                            <asp:Parameter Name="c_DateLastUpdated" Type="String" />
                            <asp:Parameter Name="PERMCategory" Type="String" />
                            <asp:Parameter Name="DatePWDFiled" Type="DateTime" />
                            <asp:Parameter Name="DatePWDIssued" Type="DateTime" />
                            <asp:Parameter Name="DatePWDExpiry" Type="DateTime" />
                            <asp:Parameter Name="PWDStatus" Type="String" />
                            <asp:Parameter Name="JobTitle" Type="String" />
                            <asp:Parameter Name="Salary" Type="String" />
                            <asp:Parameter Name="DateRecruitmentStart" Type="DateTime" />
                            <asp:Parameter Name="DateRecruitmentEnd" Type="DateTime" />
                            <asp:Parameter Name="PERMAssignedTo" Type="Int32" />
                            <asp:Parameter Name="PERMFilingDate" Type="DateTime" />
                            <asp:Parameter Name="PERMTrackingNo" Type="String" />
                            <asp:Parameter Name="PERMStatus" Type="String" />
                            <asp:Parameter Name="PERMDueDate" Type="DateTime" />
                            <asp:Parameter Name="AuditDueDate" Type="DateTime" />
                            <asp:Parameter Name="AuditStatus" Type="String" />
                            <asp:Parameter Name="AuditTypeTR" Type="Boolean" />
                            <asp:Parameter Name="AuditTypeERP" Type="Boolean" />
                            <asp:Parameter Name="AuditTypeEP" Type="Boolean" />
                            <asp:Parameter Name="AuditTypeR" Type="Boolean" />
                            <asp:Parameter Name="AuditTypeRD" Type="Boolean" />
                            <asp:Parameter Name="AuditTypeRR" Type="Boolean" />
                            <asp:Parameter Name="AuditTypeBN" Type="Boolean" />
                            <asp:Parameter Name="AuditTypeO" Type="Boolean" />
                            <asp:Parameter Name="AuditTypeOtherComments" Type="String" />
                            <asp:Parameter Name="PERMCertDate" Type="DateTime" />
                            <asp:Parameter Name="PERMI140DueDate" Type="DateTime" />
                            <asp:Parameter Name="InvNo" Type="String" />
                            <asp:Parameter Name="PaymentReceived" Type="Boolean" />
                            <asp:Parameter Name="PERMNotes" Type="String" />

                            <asp:Parameter Name="ID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ACLG_DB %>" 
                        SelectCommand="SELECT DISTINCT [User_Display_Name], [User_ID] FROM [Users] WHERE ([User_Display_Name] <> '')">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ACLG_DB %>" 
                        SelectCommand="SELECT DISTINCT [User_Display_Name], [User_ID] FROM [Users] WHERE ([User_Display_Name] <> '')">
                    </asp:SqlDataSource>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <asp:Label id="DeleteLabel" runat="server" Text=""/>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" 
                                    DataSourceID="SqlDataSource1" OnDataBound="fv_DataBound"
                                    style="text-align: left; font-family: Verdana; font-size: small;" Width="910px" 
                                    CellPadding="4" ForeColor="#333333"
                                    >
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        <EditItemTemplate>
                            &nbsp;<table bgcolor="White" border="1" class="style2">
                                <tr>
                                    <th align="left" colspan=2>PERM</th>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="LinkButton03" runat="server" CausesValidation="True" 
                                            CommandName="Update"  Text="Update"  OnDataBound="btnchange" />
                                            &nbsp;&nbsp;
                                            <asp:LinkButton ID="LinkButton04" runat="server" 
                                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tracking ID</td>
                                    <td>
                                        <asp:TextBox ID="TrackingNoTextBox" ReadOnly="true" runat="server" 
                                            Text='<%# Bind("TrackingNo") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Company</td>
                                    <td>
                                        <asp:TextBox ID="CompanyTextBox" runat="server"  ReadOnly Text='<%# Bind("Legal_name") %>' 
                                            Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>PWD Track Number</td>
                                    <td>
                                        <asp:TextBox ID="PWDTrackingNoTextBox"  runat="server" 
                                            Text='<%# Bind("PWDTrackingNo") %>' Width="300px" />
                                    </td>
                                </tr>
                                    <tr>
                                    <td>Beneficiary</td>
                                    <td>
                                        <asp:TextBox ID="BeneficiaryTextBox" runat="server" 
                                            Text='<%# Bind("Beneficiary") %>' ReadOnly="true" Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Last Updated Date</td>
                                    <td>
                                        <asp:TextBox ID="DateLastUpdatedTextBox"  runat="server" 
                                            Text='<%# Bind("c_DateLastUpdated") %>' Width="300px"  OnTextChanged="LastUpdDate_Changed" AutoPostBack="true"/>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td>PERM Category</td>
                                    <td>
                                        <asp:DropDownList ID="PERMCategoryTextBox" Text='<%# Bind("PERMCategory") %>'  Width="300px" runat="server">
                                            <asp:ListItem Selected="True">EB2 MS Only</asp:ListItem>
                                            <asp:ListItem>EB2 MS+Exp</asp:ListItem>
                                            <asp:ListItem>EB2 Bach+5/MS+3</asp:ListItem>
                                            <asp:ListItem>EB-3 Professional</asp:ListItem>
                                            <asp:ListItem>EB-3 Skilled Worker</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Date PWD Filed</td>
                                    <td>
                                        <asp:TextBox ID="DatePWDFiledTextBox" runat="server" 
                                            Text='<%# Bind("DatePWDFiled") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Date PWD Issued</td>
                                    <td>
                                        <asp:TextBox ID="DatePWDIssuedTextBox" runat="server" 
                                            Text='<%# Bind("DatePWDIssued") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>PWD Expiry Date</td>
                                    <td>
                                        <asp:TextBox ID="DatePWDExpiryTextBox" runat="server" 
                                            Text='<%# Bind("DatePWDExpiry") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>PWD Status</td>
                                    <td>
                                        <asp:DropDownList ID="PWDStatusTextBox" runat="server" Text='<%# Bind("PWDStatus") %>'>
                                            <asp:ListItem Selected="True">Pending</asp:ListItem>
                                            <asp:ListItem>Issued</asp:ListItem>
                                            <asp:ListItem>RFI</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Job Title</td>
                                    <td>
                                        <asp:TextBox ID="JobtitleTextBox" runat="server" Text='<%# Bind("Jobtitle") %>' 
                                            Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Salary</td>
                                    <td>
                                        <asp:TextBox ID="SalaryTextBox" runat="server" 
                                            Text='<%# Bind("Salary") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Recruitment Start Date</td>
                                    <td>
                                        <asp:TextBox ID="DateRecruitmentStartTextBox" runat="server" 
                                            Text='<%# Bind("DateRecruitmentStart") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Recruitment End Date</td>
                                    <td>
                                        <asp:TextBox ID="DateRecruitmentEndTextBox" runat="server" 
                                            Text='<%# Bind("DateRecruitmentEnd") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>PERM Assigned To</td>
                                    <td>
                                        <asp:DropDownList ID="PERMAssignedToTextBox" Text='<%# Bind("PERMAssignedTo") %>' runat="server" AutoPostBack="True"
                                                            DataSourceID="SqlDataSource2" DataTextField="User_Display_Name" 
                                                            DataValueField="User_ID" OnSelectedIndexChanged="PERMAssignedTo_Changed"
                                                            Height="20px" Width="350px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>PERM Filing/Priority Date</td>
                                    <td>
                                        <asp:TextBox ID="txtPERMPriDate" runat="server" Width="100px" Text='<%# Bind("PERMFilingDate") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>PERM Track No</td>
                                    <td>
                                        <asp:TextBox ID="PERMTrackingNoTextbox" runat="server" 
                                            Text='<%# Bind("PERMTrackingNo") %>' Width="300px" /></td>
                                </tr>
                                <tr>
                                    <td>PERM Status</td>
                                    <td>
                                        <asp:DropDownList ID="PERMStatusTextBox" runat="server" Text='<%# Bind("PERMStatus") %>' OnSelectedIndexChanged="PERMStatus_SelectedIndexChanged" AutoPostBack="True">
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
                                    <td>PERM Due Date</td>
                                    <td>
                                        <asp:TextBox ID="PERMDueDateTextBox" runat="server" 
                                            Text='<%# Bind("PERMDueDate") %>' Width="300px"/></td>
                                </tr>
                                <tr>
                                    <td>Audit Due Date</td>
                                    <td>
                                        <asp:TextBox ID="AuditDueDateTextBox" runat="server" 
                                            Text='<%# Bind("AuditDueDate") %>' Width="300px" Enabled="false" /></td>
                                </tr>
                                <tr>
                                    <td class="style1">Audit Status</td>
                                    <td >
                                        <asp:DropDownList ID="lstAuditStatus" runat="server" Text='<%# Bind("AuditStatus") %>'>
                                            <asp:ListItem Selected="True">Pending</asp:ListItem>
                                            <asp:ListItem>Denied</asp:ListItem>
                                            <asp:ListItem>Certified </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">Audit Type</td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td><asp:CheckBox runat="server" ID="chkAuditTypeTR" Checked='<%# Bind("AuditTypeTR") %>'/>Travel&nbsp;Requirement</td>
                                                <td><asp:CheckBox runat="server" ID="chkAuditTypeERP" Checked='<%# Bind("AuditTypeERP") %>'/>Employee&nbsp;Referral&nbsp;Program</td>
                                                <td><asp:CheckBox runat="server" ID="chkAuditTypeEP" Checked='<%# Bind("AuditTypeEP") %>'/>Employee&nbsp;Payments</td>
                                                <td><asp:CheckBox runat="server" ID="chkAuditTypeR" Checked='<%# Bind("AuditTypeR") %>'/>Resumes</td>
                                            </tr>
                                            <tr>
                                                <td><asp:CheckBox runat="server" ID="chkAuditTypeRD" Checked='<%# Bind("AuditTypeRD") %>'/>Recruitment&nbsp;Docs</td>
                                                <td><asp:CheckBox runat="server" ID="chkAuditTypeRR" Checked='<%# Bind("AuditTypeRR") %>'/>Recruitment&nbsp;Report</td>
                                                <td><asp:CheckBox runat="server" ID="chkAuditTypeBN" Checked='<%# Bind("AuditTypeBN") %>'/>Business&nbsp;Necessity</td>
                                                <td><asp:CheckBox runat="server" ID="chkAuditTypeO" Checked='<%# Bind("AuditTypeO") %>' OnCheckedChanged="AuditTypeO_CheckedChanged" AutoPostBack="True"/>Other</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">Audit Type Other Notes</td>
                                    <td >
                                        <asp:TextBox ID="txtAudTypeOtherNotes" runat="server" TextMode="MultiLine" Width="550px"  Text='<%# Bind("AuditTypeOtherComments") %>' Enabled="false" />                                                
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">PERM Certification Date</td>
                                    <td >
                                        <asp:TextBox ID="txtPERMCertDate" runat="server" Width="100px" Text='<%# Bind("PERMCertDate") %>' OnTextChanged="PERMCertDate_Changed" AutoPostBack="True"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">I140 Due Date</td>
                                    <td >
                                        <asp:TextBox ID="txtI140DueDate" runat="server" Width="100px" Text='<%# Bind("PERMI140DueDate") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">Invoice No.</td>
                                    <td >
                                        <asp:TextBox ID="txtInvNo" runat="server" Width="200px" Text='<%# Bind("InvNo") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">Payment Received?</td>
                                    <td >
                                        <asp:CheckBox runat="server" ID="chkPmnt" Checked='<%# Bind("PaymentReceived") %>'/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">PERM Comments and Status</td>
                                    <td >
                                        <asp:TextBox ID="txtPERMNotes" runat="server" TextMode="MultiLine" Width="550px" Text='<%# Bind("PERMNotes") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True" 
                                            CommandName="Update"  Text="Update"  OnDataBound="btnchange" />
                                            &nbsp;&nbsp;
                                            <asp:LinkButton ID="LinkButton5" runat="server" 
                                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </EditItemTemplate>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />                       
                                    <ItemTemplate>
                                        <table bgcolor="White" border="1" class="style2">
                                            <tr>
                                                <th align="left" colspan=2>PERM</th>
                                            </tr>
                                            <tr>
                                                <td class="style3">&nbsp;</td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton01" runat="server" CausesValidation="False" 
                                                        CommandName="Edit" Text="Edit" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="LinkButtonDelete" runat="server" CausesValidation="True" 
                                                        CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');"
                                                        Text="Delete"/>
                                            </tr>
                                            <tr>
                                                <td class="style3">Tracking ID</td>
                                                <td>
                                                <asp:Label ID="TrackingNoLabel" runat="server" 
                                                    Text='<%# Bind("TrackingNo") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">Company</td>
                                                <td>
                                                <asp:Label ID="CompanyLabel" runat="server" Text='<%# Bind("Legal_name") %>' 
                                                    />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">PWD Track Number</td>
                                                <td>
                                                <asp:Label ID="PWDTrackingNoLabel" runat="server" 
                                                    Text='<%# Bind("PWDTrackingNo") %>' />
                                                </td>
                                            </tr>
                                                <tr>
                                                <td class="style3">Beneficiary</td>
                                                <td>
                                                <asp:Label ID="BeneficiaryLabel" runat="server" 
                                                    Text='<%# Bind("Beneficiary") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">Last Updated Date</td>
                                                <td>
                                                <asp:Label ID="DateLastUpdatedLabel" runat="server" 
                                                    Text='<%# Bind("c_DateLastUpdated") %>' />
                                                </td>
                                            </tr>
                
                                            <tr>
                                                <td class="style3">PERM Category</td>
                                                <td>
                                                <asp:Label ID="PERMCategoryLabel" Text='<%# Bind("PERMCategory") %>'  runat="server" />
                                            </tr>
                                            <tr>
                                                <td class="style3">Date PWD Filed</td>
                                                <td>
                                                <asp:Label ID="DatePWDFiledLabel" runat="server" 
                                                    Text='<%# Bind("DatePWDFiled") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">Date PWD Issued</td>
                                                <td>
                                                <asp:Label ID="DatePWDIssuedLabel" runat="server" 
                                                    Text='<%# Bind("DatePWDIssued") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">PWD Expiry Date</td>
                                                <td>
                                                <asp:Label ID="DatePWDExpiryLabel" runat="server" 
                                                    Text='<%# Bind("DatePWDExpiry") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">PWD Status</td>
                                                <td>
                                                <asp:Label ID="PWDStatusLabel" runat="server" Text='<%# Bind("PWDStatus") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">Job Title</td>
                                                <td>
                                                <asp:Label ID="JobtitleLabel" runat="server" Text='<%# Bind("Jobtitle") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">Salary</td>
                                                <td>
                                                <asp:Label ID="SalaryLabel" runat="server" 
                                                    Text='<%# Bind("Salary") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">Recruitment Start Date</td>
                                                <td>
                                                <asp:Label ID="DateRecruitmentStartLabel" runat="server" 
                                                    Text='<%# Bind("DateRecruitmentStart") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">Recruitment End Date</td>
                                                <td>
                                                <asp:Label ID="DateRecruitmentEndLabel" runat="server" Text='<%# Bind("DateRecruitmentEnd") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">PERM Assigned To</td>
                                                <td>
                                                <asp:DropDownList ID="PERMAssignedToLabel" Text='<%# Bind("PERMAssignedTo") %>' runat="server"
                                                                    DataSourceID="SqlDataSource2" DataTextField="User_Display_Name" 
                                                                    DataValueField="User_ID"  
                                                                    Height="20px" Width="350px" Enabled="false">
                                                </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">PERM Filing/Priority Date</td>
                                                <td >
                                                    <asp:Label ID="txtPERMPriDate2" runat="server" Text='<%# Bind("PERMFilingDate") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">PERM Track No</td>
                                                <td>
                                                <asp:Label ID="PERMTrackingNoLabel" runat="server" 
                                                    Text='<%# Bind("PERMTrackingNo") %>' /></td>
                                            </tr>
                                            <tr>
                                                <td class="style3">PERM Status</td>
                                                <td>
                                                <asp:Label ID="PERMStatusLabel" runat="server" Text='<%# Bind("PERMStatus") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">PERM Due Date</td>
                                                <td>
                                                <asp:Label ID="PERMDueDateLabel" runat="server" 
                                                    Text='<%# Bind("PERMDueDate") %>' /></td>
                                            </tr>
                                            <tr>
                                                <td class="style3">Audit Due Date</td>
                                                <td>
                                                <asp:Label ID="AuditDueDateLabel" runat="server" 
                                                    Text='<%# Bind("AuditDueDate") %>' /></td>
                                            </tr>
                                            <tr>
                                                <td class="style1">Audit Status</td>
                                                <td >
                                                <asp:Label ID="lstAuditStatus" runat="server" Text='<%# Bind("AuditStatus") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">Audit Type</td>
                                                <td>
                                                <table>
                                                    <tr>
                                                    <td class="style3"><asp:CheckBox runat="server" ID="chkAuditTypeTR" Checked='<%# Bind("AuditTypeTR") %>' Enabled="false"/>Travel&nbsp;Requirement</td>
                                                    <td class="style3"><asp:CheckBox runat="server" ID="chkAuditTypeERP" Checked='<%# Bind("AuditTypeERP") %>' Enabled="false"/>Employee&nbsp;Referral&nbsp;Program</td>
                                                    <td class="style3"><asp:CheckBox runat="server" ID="chkAuditTypeEP" Checked='<%# Bind("AuditTypeEP") %>' Enabled="false"/>Employee&nbsp;Payments</td>
                                                    <td class="style3"><asp:CheckBox runat="server" ID="chkAuditTypeR" Checked='<%# Bind("AuditTypeR") %>' Enabled="false"/>Resumes</td>
                                                    </tr>
                                                    <tr>
                                                    <td class="style3"><asp:CheckBox runat="server" ID="chkAuditTypeRD" Checked='<%# Bind("AuditTypeRD") %>' Enabled="false"/>Recruitment&nbsp;Docs</td>
                                                    <td class="style3"><asp:CheckBox runat="server" ID="chkAuditTypeRR" Checked='<%# Bind("AuditTypeRR") %>' Enabled="false"/>Recruitment&nbsp;Report</td>
                                                    <td class="style3"><asp:CheckBox runat="server" ID="chkAuditTypeBN" Checked='<%# Bind("AuditTypeBN") %>' Enabled="false"/>Business&nbsp;Necessity</td>
                                                    <td class="style3"><asp:CheckBox runat="server" ID="chkAuditTypeO2" Checked='<%# Bind("AuditTypeO") %>' Enabled="false"/>Other</td>
                                                    </tr>
                                                </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">Audit Type Other Notes</td>
                                                <td >
                                                <asp:Label ID="txtAudTypeOtherNotes2" runat="server" TextMode="MultiLine" Width="550px" Text='<%# Bind("AuditTypeOtherComments") %>' />                      
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">PERM Certification Date</td>
                                                <td >
                                                <asp:Label ID="txtPERMCertDate2" runat="server" Width="100px" Text='<%# Bind("PERMCertDate") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">I140 Due Date</td>
                                                <td >
                                                <asp:Label ID="txtI140DueDate2" runat="server" Width="100px" Text='<%# Bind("PERMI140DueDate") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">Invoice No.</td>
                                                <td >
                                                <asp:Label ID="txtInvNo" runat="server" Width="200px" Text='<%# Bind("InvNo") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">Payment Received?</td>
                                                <td >
                                                <asp:CheckBox runat="server" ID="chkPmnt" Checked='<%# Bind("PaymentReceived") %>' Enabled="false"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">PERM Comments and Status</td>
                                                <td >
                                                <asp:Label ID="txtPERMNotes" runat="server" TextMode="MultiLine" Width="550px" Text='<%# Bind("PERMNotes") %>' />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </ItemTemplate>
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                </asp:FormView>
                                </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
        &copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
        </div>
    </form>
    <script type="text/javascript">
        var elements = document.forms[0].elements;
        for (var i = 0; i < elements.length; i++) {
            if (elements[i].id == "FormView1_DateLastUpdatedTextBox" && elements[i].type == "text") {
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

