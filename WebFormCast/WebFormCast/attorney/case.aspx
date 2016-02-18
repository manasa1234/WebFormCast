<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="case.aspx.cs" Inherits="WebFormCast.attorney.case1" %>

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
    <style type="text/css">
        .auto-style1 {
            width: 865px;
        }

        .auto-style2 {
            width: 868px;
        }

        .auto-style3 {
            width: 196px;
        }

        .auto-style4 {
            width: 61px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
        <div id="container">
            <div id="header">
                <div id="headerlogo">
                    <asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>
                <div id="login_info">Welcome! <strong>
                    <asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
            </div>
            <div id="contentShadows">
                <asp:Label ID="lbNavigation" runat="server">
    <ul class="topNav">
      <li><a href="home.aspx"><b>Home</b></a></li>  
      <li class="current"><a href="cases.aspx"><b>Cases</b></a></li>
      <li><a href="clientmanager.aspx"><b>Client Manager</b></a></li>
      <li><a href="useraccounts.aspx"><b>User Accounts</b></a></li>
      <li><a href="templates.aspx"><b>Templates</b></a></li>
      <li><a href="forms.aspx"><b>Forms</b></a></li>
      <li><a href="myaccount.aspx"><b>My Account</b></a></li>
    </ul></asp:Label>
                <div id="contentArea1">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td width="2">
                                <img src="../images/topbar_lft.gif" width="2" height="87" /></td>
                            <td class="topbar_bg">
                                <table border="0" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="2">
                                            <img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                                        <td align="right" class="topbar_sub_bg">Clients
                                            <asp:DropDownList
                                                AutoPostBack="true" ID="ddEmployer" Style="width: 200px" runat="server"
                                                EnableViewState="true" OnSelectedIndexChanged="ddEmployer_SelectedIndexChanged">
                                            </asp:DropDownList><br />
                                            <br />
                                            Search.
                                            <asp:TextBox ID="txtTrackingNo" runat="server" Width="160px" OnTextChanged="txtTrackingNo_TextChanged"></asp:TextBox>&nbsp;<asp:Button
                                                ID="txtSearch" runat="server" PostBackUrl="~/attorney/cases.aspx" CausesValidation="false" Text="&nbsp;GO&nbsp;" OnClick="txtSearch_Click" />
                                            <td width="2">
                                                <img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
                                    </tr>
                                </table>
                                <table border="0" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="2">
                                            <img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                                        <td align="left" class="topbar_sub_bg">
                                            <asp:Label ID="lbFormLinks" runat="server"></asp:Label>
                                        </td>
                                        <td width="2">
                                            <img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="2">
                                <img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
                        </tr>
                    </table>
                    <div class="shadow"></div>
                    <div class="title">
                        <asp:Label ID="lbClientName" runat="server"></asp:Label></div>
                    <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; <a href="#">
                        <asp:Label ID="lbCompanyName1" runat="server"></asp:Label></a> Create New Case</div>
                    <div id="whiteArea">
                        <center>
                            <table border="1">
                                <tr>
                                    <th align="left" colspan="2" class="auto-style2">Last updated by :<asp:Label ID="lbUpdatdBy" runat="server"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td colspan="2" class="auto-style2">
                                        <table border="1">
                                            <tr>
                                                <td align="right">Client</td>
                                                <td align="left" colspan="2">
                                                    <asp:DropDownList AutoPostBack="true" ID="dlClient" runat="server" OnSelectedIndexChanged="dlClient_SelectedIndexChanged"></asp:DropDownList></td>
                                                <td align="right">Tracking No</td>
                                                <td align="left" colspan="2">&nbsp;<asp:Label Font-Bold="true" ReadOnly="true" ID="txtTrackingId" runat="server" /></td>

                                            </tr>
                                            <tr>
                                                <td align="right">Last Name</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtLastName" Width="200" TabIndex="0" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtLastName" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator></td>
                                                <td align="right">First Name</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtFirstName" Width="200" TabIndex="0" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtFirstName" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator></td>
                                                <td align="right">Middle Name</td>
                                                <td align="left" class="auto-style3">
                                                    <asp:TextBox ID="txtMiddleName" TabIndex="0" runat="server"></asp:TextBox><asp:HiddenField ID="hfFName" runat="server" />
                                                    <asp:HiddenField ID="hfLname" runat="server" />
                                                    <asp:HiddenField ID="hfMname" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">Email Id</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtEmail" Width="200" runat="server"></asp:TextBox><asp:HiddenField ID="hfEmail" runat="server" />
                                                </td>
                                                <td align="right">Ph. No.</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtPhone" Width="200" TabIndex="0" runat="server"></asp:TextBox><asp:HiddenField ID="hfPhone" runat="server" />
                                                </td>


                                            </tr>
                                            <a name="Type"></a>
                                            <table id="tb1" class="auto-style1" border="1">
                                                <tr>
                                                    <th>Case Type</th>
                                                    <th>Inv.No</th>
                                                    <th>Due Date</th>
                                                    <th>Status </th>
                                                    <th>Assigned To</th>
                                                    <th>Date Filed</th>
                                                    <th>Receipt No</th>
                                                    <th style="<% = HiddenClassName %>" class="auto-style4">Action</th>
                                                </tr>
                                                <%=strRow1%>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddCasetype" runat="server" OnSelectedIndexChanged="ddCasetype_SelectedIndexChanged" AutoPostBack="True">
                                                            <%--<asp:ListItem Selected="True" Value=''>-- Select Case Category</asp:ListItem> --%>
                                                        </asp:DropDownList>

                                                        <br />
                                                        <asp:DropDownList ID="ddCasevalues" runat="server" OnSelectedIndexChanged="ddCasevalues_SelectedIndexChanged" AutoPostBack="True" Visible="false">
                                                        </asp:DropDownList>
                                                        <br />
                                                        <asp:TextBox ID="txtCaseother" Visible="false" runat="server"></asp:TextBox></td>


                                                    <td>
                                                        <asp:TextBox ID="txtInvno" runat="server" Width="87px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txtDueDate" runat="server" Width="97px"></asp:TextBox>

                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddStatus" runat="server">
                                                            <asp:ListItem Text="InProcess" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Completed" Value="7"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddUsers" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddUsers_SelectedIndexChanged">
                                                        </asp:DropDownList></td>


                                                    <td>
                                                        <asp:TextBox ID="txtDateFiled" runat="server" Width="90px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtReceiptno" runat="server" Width="88px"></asp:TextBox>


                                                    </td>
                                                    <div id="hide" runat="server">
                                                        <td class="auto-style4">
                                                            <asp:Button ID="btncaseButton" runat="server" Text="Save" OnClick="btncaseButton_Click" />
                                                            <br />
                                                        </td>
                                                    </div>
                    </div>
                    </tr>
                                            <%=strRow2%>

                            </table>

    </table>
    </td>
    </tr>
    <tr>
        <br />
        <td colspan="2" align="center">
            <asp:Button ID="btnCancel" CausesValidation="false" runat="server" Text="Cancel" OnClick="btnCancel_Click" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" /></td>
    </tr>
                    <tr>
                        <br />
                       
                        <td colspan="2">
                            <asp:Panel ID="panComments" runat="server">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                   
                                    <tr>
                                        <td>Comment</td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddtxtheading" runat="server" OnSelectedIndexChanged="ddtxtheading_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><br />
                                            <asp:DropDownList ID="ddtext" runat="server" OnSelectedIndexChanged="ddtext_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

                                            <br />

                                            <asp:TextBox Width="400" Rows="4" ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            &nbsp;<asp:Button ID="btnAddComment" CausesValidation="false" runat="server" Text="Add Comment" OnClick="btnAddComment_Click" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <th width="150">Date & User</th>
                                        <th>Comment</th>
                                    </tr>
                                    <%=strComments%>
                                </table>
                            </asp:Panel>
                        </td>
                        
                    </tr>
                    </table>
    </center>
      
      
                </div>
            </div>
        </div>
        <div id="footer">
            <a href="http://www.raminenilaw.com/?page_id=258"></a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a>
            <br />
            &copy; 2009 Ramineni Law Associated, LLC. All rights reserved.
        </div>
        </div>

    </form>
    <script type="text/javascript">
        Calendar.setup({
            inputField: "txtDateFiled",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "txtDateFiled",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });

        Calendar.setup({
            inputField: "txtDueDate",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "txtDueDate",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });
    </script>
    <script src="../scripts/content.js" type="text/javascript"></script>
</body>
</html>
