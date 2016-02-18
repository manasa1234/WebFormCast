<%@ Page Language="C#" AutoEventWireup="true"  ValidateRequest="false" Inherits="attorney_templatedit" Codebehind="templatedit.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styless.css" rel="stylesheet" type="text/css" />
<script src="../jscripts/tiny_mce/tiny_mce.js" type="text/javascript"></script>
<script type="text/javascript">
	tinyMCE.init({
		mode : "exact",
	    elements : "txtTemplateBody",
		theme : "advanced",
		plugins : "safari,spellchecker,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,imagemanager,filemanager", 
        theme_advanced_buttons1 : "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,formatselect,fontselect,fontsizeselect", 
        theme_advanced_buttons2 : "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,code,|,preview,|,forecolor,backcolor", 
        theme_advanced_buttons3 : "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,iespell,advhr,|,print,|,ltr,rtl,|,fullscreen", 
        theme_advanced_buttons4 : "insertlayer,moveforward,movebackward,absolute,|,styleprops,spellchecker,|,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage", 
		theme_advanced_toolbar_location : "top",
		theme_advanced_toolbar_align : "left",
		theme_advanced_resizing : true

	});
</script>
</head>
<body>
<form id="Form1" runat="server">
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
      <li class="current"><a href="templates.aspx"><b>Templates</b></a></li>
      <li><a href="forms.aspx"><b>Forms</b></a></li>
      <li><a href="myaccount.aspx"><b>My Account</b></a></li>
    </ul>
    </asp:Label>
    <div id="contentArea1">
<table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg"><table border="0" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <td width="2"><img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                <td align="right" class="topbar_sub_bg">Clients
                  <asp:DropDownList 
                        AutoPostBack="true" ID="ddEmployer" style="width:200px" runat="server" 
                        onselectedindexchanged="ddEmployer_SelectedIndexChanged" EnableViewState="true" ></asp:DropDownList>
                  <br />
                  <br />
                  Tracking No.
                  <input type="text" name="textfield2" id="textfield2" style="width:194px" /></td>
                <td width="2"><img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
              </tr>
            </table>
            <table border="0" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <td width="2"><img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                <td align="left" class="topbar_sub_bg">
                <asp:Label ID="lbFormLinks" runat="server"></asp:Label></td>
                <td width="2"><img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
              </tr>
            </table></td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">Employee</div>
      <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; <a href="home.aspx"><asp:Label ID="lbCompanyName" runat="server"></asp:Label></a> &raquo; <a href="employeeview.aspx"><asp:Label ID="lbtrackingno" runat="server"></asp:Label></a> &raquo; Form - G28</div>
       <div id="whiteArea">
      <table width="100%"   style="border:0px" cellspacing="0" cellpadding="0">
        <tr><td width="50%" style="border:0px"><h2><asp:Label ID="lbTemplate" runat="server"></asp:Label></h2></td>
        
        <td style="border:0px" align="right" valign="top" width="50%">
                               <%-- <asp:HyperLink id="hlEdit" Text="Edit" Font-Bold="true" NavigateUrl="templatedit.aspx" runat="server"></asp:HyperLink>
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink Target="_blank" ID="hlDownloadPdf" runat="server" 
                                    Font-Bold="True" Text="Download PDF"></asp:HyperLink>--%> </td></tr>
      </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr><td><asp:TextBox ID="txtTemplateBody"  TextMode="MultiLine" Rows="40" Columns="178" runat="server"></asp:TextBox> </td></tr>
        </table>
        <asp:HiddenField ID="hfIsCustom" runat="server" />
        <asp:HiddenField ID="hfTemplateID" runat="server" />
        <div align="center" class="divBlock">
            <asp:Button ID="btnSave" runat="server" Text="&nbsp;Save&nbsp;" 
                onclick="btnSave_Click" />
          <asp:Button ID="btnCancel" runat="server" Text="Back" />
        </div>
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
