<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="I-485.aspx.cs" Inherits="WebFormCast.attorney.I_485" %>
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
    <form id="Form1" runat="server" >
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
                                                        AutoPostBack="true">
                                                        <asp:ListItem Selected="True" Value='All'>All</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                              <td>
                                                    &nbsp;&nbsp;<asp:Label ID="casestatus" runat="server" Text="CaseStatus"/>
                                                    
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddcasestatus" runat="server" AutoPostBack="true">
                                                           <asp:ListItem Selected="True" Value=''>-- Select Case status---</asp:ListItem>
                                                        <asp:ListItem >Pending </asp:ListItem>
                                                        <asp:ListItem>Approved</asp:ListItem> 
                                                <asp:ListItem>RFE</asp:ListItem> 
                                                         </asp:DropDownList>
                                                </td>
     
                                            </tr>
                                            <tr>
                                                <td>
                                                    Draft Status
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="dddraftStatus" runat="server" Style="width: 200px" EnableViewState="true"
                                                      AutoPostBack="true">
                                                        <asp:ListItem Selected="True" Value=''>-- Select Drfat status---</asp:ListItem>
                                                    <asp:ListItem >Drafted</asp:ListItem>
                                                      <asp:ListItem >First Review</asp:ListItem>
                                                    <asp:ListItem >Final Review</asp:ListItem>
                                                    <asp:ListItem >WithClient</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tracking ID
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTrackingNo" runat="server" Width="160px"></asp:TextBox>
                                                </td>
                                                
                                                <td>
                                                   <asp:Button ID="I485Search" runat="server" UseSubmitBehavior="true" Text="&nbsp;Find&nbsp;I-485&nbsp;" OnClick="I485Search_Click"  />
                                                </td>
                                                <td>
                                                    <asp:Button ID="reset" runat="server" UseSubmitBehavior="true" Text="&nbsp;Reset&nbsp;" OnClick="reset_Click1"
                                                        />
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
                                    SelectCommand="SELECT * FROM [I485tracking] ORDER BY RLTrackingNumber"></asp:SqlDataSource>
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
                <div class="shadow"></div>
                <div class="title">I-485</div>
                <div class="bcru">
                   I-485&raquo;<asp:Label ID="lbCompanyName" runat="server"></asp:Label>&raquo;<asp:Label
                        ID="lbStatus" runat="server"></asp:Label>&raquo;<asp:Label ID="lbTrackId" runat="server"></asp:Label>&raquo;
                 
                    <asp:Label ID="lbCount" runat="server" Style="color: #993300; font-size: x-small;
                        font-weight: 700" ForeColor="#993300"></asp:Label>
                </div>
                <div id="whiteArea">
                    <div align="right">
                        <a href="AddI-485.aspx"><b>Create New I-485</b></a>
                    </div>
                    <asp:GridView ID="gvH1B" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Style="font-size: x-small; font-family: Verdana;"
                        Width="932px" Visible="False" Font-Size="X-Small">
                        <Columns>
                       <asp:HyperLinkField DataNavigateUrlFields="Employee_ID" DataNavigateUrlFormatString="case.aspx?Attorney_Employee_Id={0}" DataTextField="RLTrackingNumber" HeaderText="Tracking ID" NavigateUrl="case.aspx" />
                        <%--    <asp:BoundField DataField="NIVTrackingNumber" HeaderText="NIVTrackingNumber" SortExpression="NIVTrackingNumber" />--%>
                            <asp:BoundField DataField="Legal_Name" HeaderText="Company" SortExpression="Legal_Name" />
                            <asp:BoundField DataField="DraftStatus" HeaderText="DraftStatus" SortExpression="DraftStatus" />
                                          <asp:BoundField DataField="CaseStatus" HeaderText="CaseStatus" SortExpression="CaseStatus" />
                            <asp:BoundField DataField="Last_Updated" HeaderText="Last Updated" SortExpression="Last_Updated" />
              
                            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="EditI-485.aspx?I485ID={0}&custMode=view"
                                DataTextFormatString="Edit" NavigateUrl="EditI-485.aspx?custMode=view" ShowHeader="False" Text="View" />
                            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="EditI-485.aspx?I485ID={0}&custMode=edit"
                                DataTextFormatString="Edit" NavigateUrl="EditI-485.aspx?custMode=edit" ShowHeader="False" Text="Edit" />
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
   <%-- <script type="text/javascript">
     
        Calendar.setup({
            inputField: "txtstatusexpires",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "txtstatusexpires",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });
      
        Calendar.setup({
            inputField: "txtfedexshipped",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "txtfedexshipped",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });
        Calendar.setup({
            inputField: "txtuscisdt",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "txtuscisdt",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });
       
    </script>--%>
    <script src="../scripts/content.js" type="text/javascript"></script>
</body>
</html>
