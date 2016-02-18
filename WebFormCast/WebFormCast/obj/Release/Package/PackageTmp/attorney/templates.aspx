﻿<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Inherits="attorneytemplatesnew" Codebehind="templates.aspx.cs" %>

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
	
		tinyMCE.init({
		mode : "exact",
	    elements : "txtTemplateHeader",
		theme : "advanced",
		//plugins : "safari,spellchecker,pagebreak,style,layer,table,save,advhr,advimage,advlink,contextmenu,paste,fullscreen,noneditable,,xhtmlxtras,template,imagemanager,filemanager", 
        //theme_advanced_buttons1 : "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,formatselect,fontselect,fontsizeselect", 
        //theme_advanced_buttons2 : "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,code,|,preview,|,forecolor,backcolor", 
        //theme_advanced_buttons3 : "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,iespell,advhr,|,print,|,ltr,rtl,|,fullscreen", 
        //theme_advanced_buttons4 : "insertlayer,moveforward,movebackward,absolute,|,styleprops,spellchecker,|,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage", 
		theme_advanced_toolbar_location : "top",
		theme_advanced_toolbar_align : "left",
		theme_advanced_resizing : true

	});
		tinyMCE.init({
		mode : "exact",
	    elements : "txtTemplateFooter",
		theme : "advanced",
		//plugins : "safari,spellchecker,pagebreak,style,layer,table,save,advhr,advimage,advlink,contextmenu,paste,fullscreen,noneditable,,xhtmlxtras,template,imagemanager,filemanager", 
        //theme_advanced_buttons1 : "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,formatselect,fontselect,fontsizeselect", 
        //theme_advanced_buttons2 : "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,code,|,preview,|,forecolor,backcolor", 
        //theme_advanced_buttons3 : "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,iespell,advhr,|,print,|,ltr,rtl,|,fullscreen", 
        //theme_advanced_buttons4 : "insertlayer,moveforward,movebackward,absolute,|,styleprops,spellchecker,|,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage", 
		theme_advanced_toolbar_location : "top",
		theme_advanced_toolbar_align : "left",
		theme_advanced_resizing : true

	});
</script>
</head>
<body>
<form runat="server">
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
    <div id="contentArea4">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg"><table border="0" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <td width="2"><img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                <td align="left" class="topbar_sub_bg">
                    <table border="0" cellspacing="0" cellpadding="5">
                    <tr>
                      <td>&raquo; <a href="templates.aspx">Letters</a></td>
                      <td>&raquo; <a href="jobdesc.aspx">Job Description</a></td>
                    </tr>
                  </table>
                </td>
                <td width="2"><img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
              </tr>
            </table></td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">Templates</div>
      <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; <a href="templates.aspx">Templates</a> &raquo; Create New Template</div>
      <div id="whiteArea">
        <table width="100%" style="border-left:1px solid #CCCCCC;border-top:1px solid #CCCCCC;" border="0" cellspacing="0" cellpadding="5">
          <tr><td colspan="3" align="center" style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;"><asp:Label ID="lbmsg" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label></td></tr>
           <tr>
            <td style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;" valign="middle"><asp:DropDownList ID="ddCompany" runat="server" onselectedindexchanged="ddCompany_SelectedIndexChanged" AutoPostBack="true" CssClass="input_edit"></asp:DropDownList></td>
            <td style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;" valign="middle">Visa Type:<asp:DropDownList ID="ddVisaType" runat="server" AutoPostBack="true" CssClass="input_edit" onselectedindexchanged="ddVisaType_SelectedIndexChanged"></asp:DropDownList></td>
            <td style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;" valign="middle">Template Name:<asp:DropDownList ID="ddTemplates" runat="server"  AutoPostBack="true" onselectedindexchanged="ddTemplates_SelectedIndexChanged"  CssClass="input_edit"><asp:ListItem Text="Select" Value="0"></asp:ListItem><asp:ListItem Text="Offer of Employment" Value="1"></asp:ListItem><asp:ListItem Text="Support Letter" Value="2"></asp:ListItem><asp:ListItem Text="Itinerary" Value="3"></asp:ListItem></asp:DropDownList></td>
           </tr>
          <tr>
            <td style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;" colspan="3">
            <asp:TextBox ID="txtTemplateHeader" runat="server" TextMode="MultiLine" Height="100px" Width="904px"></asp:TextBox><br />
            <asp:TextBox ID="txtTemplateBody" runat="server" TextMode="MultiLine" Height="366px" Width="904px"></asp:TextBox><br />
            <asp:TextBox ID="txtTemplateFooter" runat="server" TextMode="MultiLine" Height="100px" Width="904px"></asp:TextBox><br />
            Header Height :<asp:TextBox ID="txtHHeight" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;Footer Height:<asp:TextBox ID="txtFHeight" runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr><td style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;" colspan="3"><asp:Button ID="btnSave" runat="server" Text="Save" 
                  onclick="btnSave_Click"/>&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" runat="server" Text="Cancel" /></td></tr>
        </table>
      </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
</form>
<script type="text/javascript">
function clrMsg()
{
    document.getElementById('lbmsg').innerHTML="&nbsp;";
}
setTimeout("clrMsg()",10000*1);

</script>
<script src="../scripts/content.js" type="text/javascript"></script>
</body>
</html>