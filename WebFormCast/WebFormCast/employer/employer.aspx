﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="employer_employeer" Codebehind="employer.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form runat="server" defaultbutton="btnSearch">
<div id="container">
  <div id="header">
  <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
  <div id="login_info">Welcome! <strong><asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
  </div>
  <div id="contentShadows">
    <ul class="topNav">
      <li class="current"><a href="employer.aspx"><b>Home</b></a></li>
      <li><a href="employer_manage.aspx"><b> Add New Employee</b></a></li>
      <li><a href="employer_myaccount.aspx"><b>My Account</b></a></li>
    </ul>
    <div id="contentArea1">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg"><table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
              <td width="2"><img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
              <td align="right" class="topbar_sub_bg">
                Search By&nbsp;<asp:TextBox ID="txtSearch" runat="server" Width="100px"></asp:TextBox>&nbsp;<asp:Button 
                      ID="btnSearch" Text="Go" runat="server" onclick="btnSearch_Click" /><br />(Tracking ID/Emp Name/Receipt #)</td>                      
              <td width="2"><img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
            </tr>
          </table></td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">Home</div>
      <div class="bcru"><a href="employer.aspx">Home</a> &raquo; List of Employees</div>
      <div id="whiteArea">
         <asp:GridView ID="gvEmployees" Width="100%"  AutoGenerateColumns="false" AllowPaging="true" 
              PageSize="20"  runat="server" DataKeyNames="Employee_id" onpageindexchanged="gvEmployees_PageIndexChanged" 
              onpageindexchanging="gvEmployees_PageIndexChanging"  onrowcommand="gvEmployees_RowCommand">
        <Columns>
        
            <asp:TemplateField ItemStyle-Width="30px"  HeaderText="S.No" >  <ItemTemplate>    <%# Container.DataItemIndex + 1 %>  </ItemTemplate></asp:TemplateField>
            <asp:ButtonField DataTextField="Tracking_No"  HeaderText="Tracking ID" ButtonType="Link" CommandName="select" /> 
            <asp:ButtonField DataTextField="FullName"  HeaderText="Employee Name" ButtonType="Link" CommandName="select" /> 
            <asp:BoundField DataField="DateFiled" HeaderText="Date Filed" />
            <asp:BoundField DataField="ReceiptNo" HeaderText="Reciept Number" />
            <asp:BoundField DataField="Visa_Type_Name" HeaderText="Type" />
            <asp:BoundField DataField="Comments" HeaderText="Comments" />
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate >
                    <%#DataBinder.Eval(Container.DataItem, "Status")%>&nbsp;<%#DataBinder.Eval(Container.DataItem, "Status_Change_Date")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField >
                <ItemTemplate>
                    <a href="mailto:<%#DataBinder.Eval(Container.DataItem, "Email_Address")%>?Subject=Welcome%20to%20<%=strCompanyName%>%20Immigration%20Management%20System&Body=Dear%20<%#DataBinder.Eval(Container.DataItem, "FullName")%>%0D%0A%0D%0AWelcome%20to%20our%20web-based%20immigration%20management%20system.%20Please%20click%20on%20the%20link%20below%20and%20use%20the%20provided%20username%20and%20password%20to%20login.%20Please%20complete%20all%20the%20information%20in%3A%0D%0A%0D%0A1. Personal Information%0D%0A2. Education Details%0D%0A3. Experience Details%0D%0A%0D%0APlease do not finalize the form until you have entered all the information correctly. Once you finalize the application, you cannot modify your information!%0D%0A%0D%0Ahttp://webformcast.azurewebsites.net/employee/index.aspx%0D%0A%0D%0AUsername : <%#DataBinder.Eval(Container.DataItem, "Email_Address")%>%0D%0APassword : <%#DataBinder.Eval(Container.DataItem, "Access_Key")%>%0D%0A%0D%0A%0D%0A%0D%0AThank You%0D%0A%0D%0A<%=strCompanyInfo%>">Email</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerSettings   Mode="NumericFirstLast"   FirstPageText="<<" LastPageText=">>" />
        </asp:GridView>
       
      </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
</form>
</body>
</html>