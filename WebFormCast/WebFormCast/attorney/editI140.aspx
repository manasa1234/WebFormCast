<%@ Page Language="C#" AutoEventWireup="true" Inherits="attorney_EditI140" Codebehind="editI140.aspx.cs" %>

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
                </table>
                <div class="shadow">
                </div>
                <div class="title">
                    Edit I-140</div>
                <div class="bcru">
                    <a href="i140.aspx">I-140</a> » Edit I-140</div>
                <div id="whiteArea">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ connectionStrings:ACLG_DB %>"
                        DeleteCommand="DELETE FROM [I140Tracking] WHERE [ID] = @ID" 
                        SelectCommand="SELECT I140Tracking.*, CONVERT(VARCHAR(10),I140Tracking.I140LastUpdDate,101) c_I140LastUpdDate, Cast(ISNULL(I140AssignedTo, 0) as Int) as c_I140AssignedTo, Cast(IsNull(I140DocsReceived, 0) as bit) as c_I140DocsReceived, Cast(IsNull(I140Drafted, 0) as bit) as c_I140Drafted, Cast(IsNull(I140PERMSentSignature, 0) as bit) as c_I140PERMSentSignature, Cast(IsNull(I140Premium , 0) as bit) as c_I140Premium , Cast(IsNull(I140Filed , 0) as bit) as c_I140Filed , Cast(IsNull(I140PaymentRcvd , 0) as bit) as c_I140PaymentRcvd , Cast(IsNull(I140RFETypeAP , 0) as bit) as c_I140RFETypeAP , Cast(IsNull(I140RFETypeA , 0) as bit) as c_I140RFETypeA , Cast(IsNull(I140RFETypeE , 0) as bit) as c_I140RFETypeE , Cast(IsNull(I140RFETypeO , 0) as bit) as c_I140RFETypeO, Company.* FROM [I140Tracking], Company where CompanyID = Company and [ID] = @ID"
                        UpdateCommand="UPDATE [I140Tracking] SET [I140ReceiptNo] = @I140ReceiptNo, [I140DueDate] = @I140DueDate, [I140DocsReceived] = @c_I140DocsReceived, [I140LastUpdDate] = cast(@c_I140LastUpdDate as date), [I140AssignedTo] = @c_I140AssignedTo, [I140DocsMissing] = @I140DocsMissing, [I140Drafted] = @c_I140Drafted, [I140PERMSentSignature] = @c_I140PERMSentSignature, [I140Premium] = @c_I140Premium, [I140Filed] = @c_I140Filed, [I140FiledDate] = @I140FiledDate, [I140InvNo] = @I140InvNo, [I140PaymentRcvd] = @c_I140PaymentRcvd, [I140Status] = @I140Status, [I140RFEDueDate] = @I140RFEDueDate, [I140RFEStatus] = @I140RFEStatus, [I140RFETypeAP] = @c_I140RFETypeAP, [I140RFETypeA] = @c_I140RFETypeA, [I140RFETypeE] = @c_I140RFETypeE, [I140RFETypeO] = @c_I140RFETypeO, [I140RFETypeOtherComments] = @I140RFETypeOtherComments, [I140Notes] = @I140Notes WHERE [ID] = @ID"
                        OnUpdated="OnDSUpdatedHandler">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ID" QueryStringField="I140ID" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="I140ReceiptNo" Type="String" />
                            <asp:Parameter Name="I140DueDate" Type="DateTime" />
                            <asp:Parameter Name="c_I140DocsReceived" Type="Boolean" />
                            <asp:Parameter Name="c_I140LastUpdDate" Type="String" />
                            <asp:Parameter Name="c_I140AssignedTo" Type="Int32" />
                            <asp:Parameter Name="I140DocsMissing" Type="String" />
                            <asp:Parameter Name="c_I140Drafted" Type="Boolean" />
                            <asp:Parameter Name="c_I140PERMSentSignature" Type="Boolean" />
                            <asp:Parameter Name="c_I140Premium" Type="Boolean" />
                            <asp:Parameter Name="c_I140Filed" Type="Boolean" />
                            <asp:Parameter Name="I140FiledDate" Type="String" />
                            <asp:Parameter Name="I140InvNo" Type="String" />
                            <asp:Parameter Name="c_I140PaymentRcvd" Type="Boolean" />
                            <asp:Parameter Name="I140Status" Type="String" />
                            <asp:Parameter Name="I140RFEDueDate" Type="String" />
                            <asp:Parameter Name="I140RFEStatus" Type="String" />
                            <asp:Parameter Name="c_I140RFETypeAP" Type="Boolean" />
                            <asp:Parameter Name="c_I140RFETypeA" Type="Boolean" />
                            <asp:Parameter Name="c_I140RFETypeE" Type="Boolean" />
                            <asp:Parameter Name="c_I140RFETypeO" Type="Boolean" />
                            <asp:Parameter Name="I140RFETypeOtherComments" Type="String" />
                            <asp:Parameter Name="I140Notes" Type="String" />
                            <asp:Parameter Name="ID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
                        SelectCommand="SELECT DISTINCT [User_Display_Name], [User_ID] FROM [Users] WHERE ([User_Display_Name] <> '')">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
                        SelectCommand="SELECT DISTINCT [User_Display_Name], [User_ID] FROM [Users] WHERE ([User_Display_Name] <> '')">
                    </asp:SqlDataSource>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="center">
                                <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" DataSourceID="SqlDataSource1"
                                    OnDataBound="fv_DataBound" Style="text-align: left; font-family: Verdana; font-size: small;"
                                    Width="910px" CellPadding="4" ForeColor="#333333">
                                    <EditItemTemplate>
                                        &nbsp;<table bgcolor="White" border="1" class="style2">
                                            <tr>
                                                <th align="left" colspan="2">
                                                    I-140
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton03" runat="server" CausesValidation="True" CommandName="Update"
                                                        Text="Update" OnDataBound="btnchange" />
                                                    &nbsp;<asp:LinkButton ID="LinkButton04" runat="server" CausesValidation="False" CommandName="Cancel"
                                                        Text="Cancel" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tracking ID
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TrackingNoTextBox" ReadOnly="true" runat="server" Text='<%# Bind("TrackingNo") %>'
                                                        Width="300px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Company
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="CompanyTextBox" runat="server" ReadOnly Text='<%# Bind("Legal_name") %>'
                                                        Width="300px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Beneficiary
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="BeneficiaryTextBox" runat="server" Text='<%# Bind("Beneficiary") %>'
                                                        ReadOnly="true" Width="300px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    I-140 Receipt No
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="I140ReceiptNoTextBox" runat="server" Text='<%# Bind("I140ReceiptNo") %>'
                                                        Width="300px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Last Updated Date
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="DateLastUpdatedTextBox" runat="server" Text='<%# Bind("c_I140LastUpdDate") %>'
                                                        Width="300px" OnTextChanged="LastUpdDate_Changed" AutoPostBack="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Docs Received?
                                                </td>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkI140Docs" Checked='<%# Bind("c_I140DocsReceived") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Assigned To
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstUsersI140" Text='<%# Bind("c_I140AssignedTo") %>' runat="server"
                                                        AutoPostBack="True" AppendDataBoundItems="true" DataSourceID="SqlDataSource2"
                                                        DataTextField="User_Display_Name" DataValueField="User_ID" OnSelectedIndexChanged="lstUsersI140_Changed"
                                                        Height="20px" Width="350px">
                                                        <asp:ListItem Selected="True" Value='0'>Select User</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Missing Docs
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtI140MissingDocs" runat="server" TextMode="MultiLine" Width="550px"
                                                        Text='<%# Bind("I140DocsMissing") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Checklist
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="chkDrafted" Checked='<%# Bind("c_I140Drafted") %>' />Drafted
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="chkPermPages" Checked='<%# Bind("c_I140PERMSentSignature") %>' />PERM&nbsp;pages&nbsp;sent&nbsp;for&nbsp;signatures
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="chkPremium" Checked='<%# Bind("c_I140Premium") %>' />Premium
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="chkI140Filed" Checked='<%# Bind("c_I140Filed") %>' />I-140&nbsp;Filed
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Filed Date
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtI140FiledDate" runat="server" Width="300px" Text='<%# Bind("I140FiledDate") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    I-140 Invoice No.
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtI140InvNo" runat="server" Width="200px" Text='<%# Bind("I140InvNo") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Payment Received?
                                                </td>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkI140Payment" Checked='<%# Bind("c_I140PaymentRcvd") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    Due Date
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtI140DueDate" runat="server" Width="100px" Text='<%# Bind("I140DueDate") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Status
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstI140Status" runat="server" OnSelectedIndexChanged="I140Status_SelectedIndexChanged"
                                                        AutoPostBack="True" Text='<%# Bind("I140Status") %>'>
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
                                                <td>
                                                    RFE Due Date
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtI140RFEDueDate" runat="server" Width="100px" Enabled="false"
                                                        Text='<%# Bind("I140RFEDueDate") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    RFE Status
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstI140RFEStatus" runat="server" Enabled="false" Text='<%# Bind("I140RFEStatus") %>'>
                                                        <asp:ListItem Selected="True">Pending</asp:ListItem>
                                                        <asp:ListItem>Denied</asp:ListItem>
                                                        <asp:ListItem>Approved</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    RFE Type
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="chkPayAbility" Enabled="false" Checked='<%# Bind("c_I140RFETypeAP") %>' />Ability&nbsp;to&nbsp;pay
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="chkAcademics" Enabled="false" Checked='<%# Bind("c_I140RFETypeA") %>' />Academics
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="chkExperience" Enabled="false" Checked='<%# Bind("c_I140RFETypeE") %>' />Experience
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="chkOther" Enabled="false" Checked='<%# Bind("c_I140RFETypeO") %>'
                                                                    OnCheckedChanged="I140RFEOther_CheckedChanged" AutoPostBack="true" />Other
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    RFE Type Other Notes
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtI140RFEOtherNotes" runat="server" TextMode="MultiLine" Width="550px"
                                                        Enabled="false" Text='<%# Bind("I140RFETypeOtherComments") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    I140 Comments and Status
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtI140Comments" runat="server" TextMode="MultiLine" Width="550px"
                                                        Text='<%# Bind("I140Notes") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                                        Text="Update" OnDataBound="btnchange" />
                                                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                                                        CommandName="Cancel" Text="Cancel" />
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
                                                <th align="left" colspan="2">
                                                    I-140
                                                </th>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton01" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Text="Edit" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="LinkButtonDelete" runat="server" CausesValidation="True" 
                                                        CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');"
                                                        Text="Delete"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Tracking ID
                                                </td>
                                                <td>
                                                    <asp:Label ID="TrackingNoLabel" runat="server" Text='<%# Bind("TrackingNo") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Company
                                                </td>
                                                <td>
                                                    <asp:Label ID="CompanyLabel" runat="server" Text='<%# Bind("Legal_name") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Beneficiary
                                                </td>
                                                <td>
                                                    <asp:Label ID="BeneficiaryLabel" runat="server" Text='<%# Bind("Beneficiary") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    I-140 Receipt No
                                                </td>
                                                <td>
                                                    <asp:Label ID="I140ReceiptNoLabel" runat="server" Text='<%# Bind("I140ReceiptNo") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Last Updated Date
                                                </td>
                                                <td>
                                                    <asp:Label ID="DateLastUpdatedLabel" runat="server" Text='<%# Bind("c_I140LastUpdDate") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Docs Received?
                                                </td>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkI140Docs2" Checked='<%# Bind("c_I140DocsReceived") %>'
                                                        Enabled="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Assigned To
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstUsersI1402" runat="server" Text='<%# Bind("c_I140AssignedTo") %>'
                                                        DataSourceID="SqlDataSource2" DataTextField="User_Display_Name" DataValueField="User_ID"
                                                        AppendDataBoundItems="true" Height="20px" Width="350px" Enabled="false">
                                                        <asp:ListItem Selected="True" Value='0'>Select User</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Missing Docs
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtI140MissingDocs2" runat="server" Width="550px" Text='<%# Bind("I140DocsMissing") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Checklist
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox Enabled="false" runat="server" ID="chkDrafted2" Checked='<%# Bind("c_I140Drafted") %>' />Drafted
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox Enabled="false" runat="server" ID="chkPermPages2" Checked='<%#  Bind("c_I140PERMSentSignature") %>' />PERM&nbsp;pages&nbsp;sent&nbsp;for&nbsp;signatures
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox Enabled="false" runat="server" ID="chkPremium2" Checked='<%#  Bind("c_I140Premium") %>' />Premium
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox Enabled="false" runat="server" ID="chkI140Filed2" Checked='<%#  Bind("c_I140Filed") %>' />I-140&nbsp;Filed
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Filed Date
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtI140FiledDate2" runat="server" Width="300px" Text='<%# Bind("I140FiledDate") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    I-140 Invoice No.
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtI140InvNo2" runat="server" Width="200px" Text='<%# Bind("I140InvNo") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Payment Received?
                                                </td>
                                                <td>
                                                    <asp:CheckBox Enabled="false" runat="server" ID="chkI140Payment2" Checked='<%# Bind("c_I140PaymentRcvd") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    Due Date
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtI140DueDate2" runat="server" Width="100px" Text='<%# Bind("I140DueDate") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Status
                                                </td>
                                                <td>
                                                    <asp:Label ID="I140StatusLabel" runat="server" Text='<%# Bind("I140Status") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    RFE Due Date
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtI140RFEDueDate2" runat="server" Text='<%# Bind("I140RFEDueDate") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    RFE Status
                                                </td>
                                                <td>
                                                    <asp:Label ID="lstI140RFEStatus2" runat="server" Enabled="false" Text='<%# Bind("I140RFEStatus") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    RFE Type
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox Enabled="false" runat="server" ID="chkPayAbility2" Checked='<%#  Bind("c_I140RFETypeAP") %>' />Ability&nbsp;to&nbsp;pay
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox Enabled="false" runat="server" ID="chkAcademics2" Checked='<%#  Bind("c_I140RFETypeA") %>' />Academics
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox Enabled="false" runat="server" ID="chkExperience2" Checked='<%#  Bind("c_I140RFETypeE") %>' />Experience
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox Enabled="false" runat="server" ID="chkOther2" Checked='<%#  Bind("c_I140RFETypeO") %>' />Other
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    RFE Type Other Notes
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtI140RFEOtherNotes2" runat="server" Enabled="false" Text='<%# Bind("I140RFETypeOtherComments") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    I140 Comments and Status
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtI140Comments2" runat="server" Text='<%# Bind("I140Notes") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Text="Edit" />
                                                    &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                                                        Text="Delete" Visible="false" />
                                                    &nbsp;
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
        <div id="footer">
            <a href="http://www.raminenilaw.com/?page_id=258"></a><a href="http://www.raminenilaw.com/?page_id=258">
                Contact Us</a> | <a href="legal_notices.html">Legal Notice </a>
            <br />
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
