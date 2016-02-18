<%@ Page Language="C#" AutoEventWireup="true" Inherits="attorney_LCA" Codebehind="lca.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 2px;
        }
    </style>
    </head>
<body>
<form id="Form1" runat="server" defaultbutton="lcaSearch">
<div id="container">
  <div id="header">
  <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
  <div id="login_info">Welcome! <strong><asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
  </div>
  <div id="contentShadows">
    <asp:Label ID="lbNavigation" runat="server"><ul class="topNav">
      <li><a href="home.aspx"><b>Home</b></a></li>  
      <li><a href="cases.aspx"><b>Cases</b></a></li>
      <li><a href="clientmanager.aspx"><b>Client Manager</b></a></li>
      <li><a href="useraccounts.aspx"><b>User Accounts</b></a></li>
      <li><a href="templates.aspx"><b>Templates</b></a></li>
      <li><a href="forms.aspx"><b>Forms</b></a></li>
      <li><a href="myaccount.aspx"><b>My Account</b></a></li>
      <li class="current"><a href="trackingSys.aspx"><b>Track. Sys.</b></a></li>
    </ul></asp:Label>
    <div id="contentArea1">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg">
            <table border="0" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <td class="auto-style1"><img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                <td align="left" class="topbar_sub_bg">
                <table border="0" align="left" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>Company Name</td>
                        <td>
                            <asp:DropDownList ID="ddCompany" style="width:200px" runat="server"  
                                DataSourceID="SqlDataSource1" DataTextField="Legal_Name"  
                                DataValueField="CompanyID"  AppendDataBoundItems="True" 
                                EnableViewState="true" OnSelectedIndexChanged="ddCompany_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Selected="True" Value='All'>All</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Status</td>
                        <td>
                            <asp:DropDownList ID="ddStatus" runat="server" 
                                style="width:200px" EnableViewState="true" OnSelectedIndexChanged="ddStatus_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Certified</asp:ListItem>
                                <asp:ListItem>Denied</asp:ListItem>
                                <asp:ListItem>Withdrawn</asp:ListItem>
                                <asp:ListItem>Pending</asp:ListItem>
                                <asp:ListItem>Re-filed</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Tracking ID</td>
                        <td>
                            <asp:TextBox ID="txtTrackingNo" runat="server" Width="160px" ></asp:TextBox>                    
                        </td>
                        <td>
                            <asp:Button ID="lcaSearch" runat="server" UseSubmitBehavior="true" Text="&nbsp;Find&nbsp;LCA&nbsp;" onclick="lcaSearch_Click" />
                        </td>
                    </tr>                                                   
                  </table>
                  </td>
                  <td width="2"><img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
              </tr>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ connectionStrings:ACLG_DB %>" 
                        SelectCommand="SELECT DISTINCT [Legal_Name], [CompanyID] FROM [Company] WHERE ([Legal_Name] <> '') ORDER BY Legal_Name">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ connectionStrings:ACLG_DB %>" 
                        SelectCommand="SELECT LCtracking.*, Employee.Employee_ID FROM [LCtracking], [Employee] where LCtracking.RLTrackingNumber = Employee.Tracking_No  ORDER BY RLTrackingNumber"
                        ProviderName="System.Data.SqlClient">
                    </asp:SqlDataSource>
            </table>
          </td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">LCA</div>
      <div class="bcru">LCA&raquo;<asp:Label ID="lbCompanyName" runat="server"></asp:Label>&raquo;<asp:Label ID="lbStatus" runat="server"></asp:Label>&raquo;<asp:Label ID="lbTrackId" runat="server"></asp:Label>&raquo;
      <asp:Label ID="lbCount" runat="server" 
                        style="color: #993300; font-size: x-small; font-weight: 700" 
                        ForeColor="#993300"></asp:Label>
                </div>
      <div id="whiteArea">
      <div align="right"><a href="addLCA.aspx"><b>Create New LCA</b></a></div>
                    <asp:GridView ID="gvLCA" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="SqlDataSource2" 
                        style="font-size: x-small; font-family: Verdana;" Width="932px" 
                        Visible="False" Font-Size="X-Small" >
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="Employee_ID" DataNavigateUrlFormatString="case.aspx?Attorney_Employee_Id={0}" DataTextField="RLTrackingNumber" HeaderText="Tracking ID" NavigateUrl="case.aspx" />
                            <asp:BoundField DataField="LCATrackNumber" HeaderText="LCA Number" 
                                SortExpression="LCATrackNumber" />
                            <asp:BoundField DataField="Legal_Name" HeaderText="Company" 
                                SortExpression="Legal_Name" />
                            <asp:BoundField DataField="Beneficiary" HeaderText="Beneficiary" 
                                SortExpression="Beneficiary" />
                            <asp:BoundField DataField="CurrentStatus" HeaderText="Status" 
                                SortExpression="CurrentStatus" />
                            <asp:BoundField DataField="EmpStartEnd" HeaderText="Start/End Date" 
                                SortExpression="EmpStartEnd" />
                            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="editLCA.aspx?LCAID={0}&custMode=view"
                                DataTextFormatString="Edit" NavigateUrl="editLCA.aspx?custMode=view" 
                                Text="View" ShowHeader="False" />
                            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="editLCA.aspx?LCAID={0}&custMode=edit"
                                DataTextFormatString="Edit" NavigateUrl="editLCA.aspx?custMode=edit" 
                                Text="Edit" ShowHeader="False" />
                        </Columns>
                    </asp:GridView>
      </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
</form>
<script src="../scripts/content.js" type="text/javascript"></script>
</body>
</html>

