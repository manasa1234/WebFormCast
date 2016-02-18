<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="H1-B.aspx.cs" Inherits="WebFormCast.attorney.H1_B" %>
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
    <form id="Form1" runat="server" defaultbutton="H1BSearch">
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
                                                    &nbsp;&nbsp;Status Of Petetion
                                                    <%--<br />&nbsp;&nbsp;Date Petetion Filed--%>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddstatuespetetion" runat="server" Style="width: 200px" AppendDataBoundItems="True"
                                                        EnableViewState="true" AutoPostBack="true" >
                                                        <asp:ListItem Selected="True" Value=''>--select status of petetion </asp:ListItem>
                                                        <asp:ListItem >Shipped </asp:ListItem>
                                                        <asp:ListItem>Receipted</asp:ListItem> 
                                                <asp:ListItem>Approval</asp:ListItem> 
                                <asp:ListItem>RFE</asp:ListItem> 
                                <asp:ListItem>Rejected</asp:ListItem>
                                <asp:ListItem>NOID</asp:ListItem> 
                                <asp:ListItem>NOIR</asp:ListItem>
                                                        <asp:ListItem>Withdrawn</asp:ListItem>
                                                         <asp:ListItem>Denied</asp:ListItem>
                                                    </asp:DropDownList>
                                       <%--           <br />
                                                    <br />
                                                    <asp:TextBox ID="dtpetetion" runat="server" Style="width: 200px"></asp:TextBox>--%>
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
                                                         <asp:ListItem Selected="True" Value=''>-- Select status</asp:ListItem>
                                                    <asp:ListItem Value='Final Review'>Final Review</asp:ListItem>
                                                    <asp:ListItem Value='Reduced Review'>Reduced Review</asp:ListItem>
                                                    <asp:ListItem Value='Forms'>Forms</asp:ListItem>
                                                    <asp:ListItem Value='Hold'>Hold</asp:ListItem>
                                                    <asp:ListItem Value='Drafted'>Drafted</asp:ListItem>
                                                    <asp:ListItem Value='1stReview'>1stReview</asp:ListItem>
                                                    <asp:ListItem Value='RFE'>RFE</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;<asp:Label ID="Team" runat="server" Text="Team"/>
                                                    
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddteams" runat="server" AutoPostBack="true">
                                                        <asp:ListItem Selected="True" Value=''>--Select Team---</asp:ListItem>
                                                        <asp:ListItem >Team 1 </asp:ListItem>
                                                        <asp:ListItem>Team 2</asp:ListItem> 
                                                <asp:ListItem>Team 3</asp:ListItem> 
                                <asp:ListItem>Team 4</asp:ListItem>
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
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblfedexshipped" runat="server" Text="Fedex DateShipped"  />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtfedexshipped" runat="server" Width="160px" ></asp:TextBox>
                                                </td>
                                                </tr>
                                            <tr>
                                                 <td>
                                                   RFE DueDate
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtuscisdt" runat="server" Width="160px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblstatusexpires" runat="server" Text="H1B DueDate"  />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtstatusexpires" runat="server" Width="160px" ></asp:TextBox>
                                                </td>
                                               
                                                <td>
                                                   <asp:Button ID="H1BSearch" runat="server" UseSubmitBehavior="true" Text="&nbsp;Find&nbsp;NIV&nbsp;" onclick="H1BSearch_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="reset" runat="server" UseSubmitBehavior="true" Text="&nbsp;Reset&nbsp;"
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
                                    SelectCommand="SELECT * FROM [NIVtracking] ORDER BY NIVTrackingNumber"></asp:SqlDataSource>
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
                <div class="title">H1-B</div>
                <div class="bcru">
                   NIV&raquo;<asp:Label ID="lbCompanyName" runat="server"></asp:Label>&raquo;<asp:Label
                        ID="lbStatus" runat="server"></asp:Label>&raquo;<asp:Label ID="lbTrackId" runat="server"></asp:Label>&raquo;
                 
                    <asp:Label ID="lbCount" runat="server" Style="color: #993300; font-size: x-small;
                        font-weight: 700" ForeColor="#993300"></asp:Label>
                </div>
                <div id="whiteArea">
                    <div align="right">
                        <a href="addH1-B.aspx"><b>Create New NIV</b></a>
                    </div>
                    <asp:GridView ID="gvH1B" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Style="font-size: x-small; font-family: Verdana;"
                        Width="932px" Visible="False" Font-Size="X-Small">
                        <Columns>
                       <asp:HyperLinkField DataNavigateUrlFields="Employee_ID" DataNavigateUrlFormatString="case.aspx?Attorney_Employee_Id={0}" DataTextField="RLTrackingNumber" HeaderText="Tracking ID" NavigateUrl="case.aspx" />
                        <%--    <asp:BoundField DataField="NIVTrackingNumber" HeaderText="NIVTrackingNumber" SortExpression="NIVTrackingNumber" />--%>
                            <asp:BoundField DataField="Legal_Name" HeaderText="Company" SortExpression="Legal_Name" />
                            <asp:BoundField DataField="DraftStatus" HeaderText="Status" SortExpression="DraftStatus" />
                            <asp:BoundField DataField="Last_Updated" HeaderText="Last Updated" SortExpression="Last_Updated" />
                            <asp:BoundField DataField="Premium_Processing" HeaderText="Premium Processing?" SortExpression="Premium_Processing" />
                            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="editH1-B.aspx?H1BID={0}&custMode=view"
                                DataTextFormatString="Edit" NavigateUrl="editH1-B.aspx?custMode=view" ShowHeader="False" Text="View" />
                            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="editH1-B.aspx?H1BID={0}&custMode=edit"
                                DataTextFormatString="Edit" NavigateUrl="editH1-B.aspx?custMode=edit" ShowHeader="False" Text="Edit" />
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
        //var elements = document.forms[0].elements;
        //for (var i = 0; i < elements.length; i++) {
        //if (elements[i].id == "txtDateFrom" && elements[i].type == "text") {
        Calendar.setup({
            inputField: "txtstatusexpires",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "txtstatusexpires",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });
        //}
        //if (elements[i].id == "txtDateTo" && elements[i].type == "text") {
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
        //}
        //}
    </script>
    <script src="../scripts/content.js" type="text/javascript"></script>
</body>
</html>
