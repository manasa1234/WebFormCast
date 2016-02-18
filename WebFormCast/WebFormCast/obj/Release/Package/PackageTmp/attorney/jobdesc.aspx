<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Inherits="attorney_jobdesc" Codebehind="jobdesc.aspx.cs" %>
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
	    elements : "txtJobDesc",
		theme : "advanced",
		plugins : "safari,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template",
		theme_advanced_buttons1 : "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,formatselect,fontselect,fontsizeselect,code,preview",
		theme_advanced_buttons2 : "cut,copy,paste,|,replace,|,bullist,numlist,|,outdent,indent,|,undo,redo,|,link,unlink,image,cleanup,|,forecolor,backcolor,|,charmap,emotions,iespell,advhr",
		theme_advanced_buttons3 : "",
		theme_advanced_toolbar_location : "top",
		theme_advanced_toolbar_align : "left",
		theme_advanced_resizing : true,
		content_css : "css/content.css"
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
  <asp:Label ID="lbNavigation" runat="server"><ul class="topNav">
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
         <div style="float:right"><a class="current" href="jobdesc.aspx?new=1"><b>Add New</b></a></div>
        <h2>Job Descriptions</h2>
        <asp:GridView ID="gvEmployees" Width="100%" CellPadding="5" CellSpacing="5"  HeaderStyle-BorderWidth="1px"      AutoGenerateColumns="false" runat="server" >
        <Columns>
        <asp:TemplateField ItemStyle-Width="30px" ItemStyle-BorderStyle="Solid"   ItemStyle-BorderWidth="1px"  HeaderText="S.No" >  <ItemTemplate>    <%# Container.DataItemIndex + 1 %>  </ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="Occupation_Code"  ItemStyle-BorderWidth="1px"  ItemStyle-BorderStyle="Solid" HeaderText="Occupation Code" />
            <asp:HyperLinkField DataNavigateUrlFields="Signature" ItemStyle-BorderWidth="1px"   ItemStyle-BorderStyle="Solid" DataNavigateUrlFormatString="jobdesc.aspx?edit=1&signature={0}" DataTextField="Job_Title" HeaderText="Job Title"/>
            <asp:BoundField DataField="NT_Job_Description"  ItemStyle-BorderWidth="1px"  ItemStyle-BorderStyle="Solid" HeaderText="Nontech Description" />
        </Columns>
        <PagerSettings   Mode="NumericFirstLast"   FirstPageText="<<" LastPageText=">>" />
        </asp:GridView>
        <br />
        <br />
        <asp:Panel ID="panNew" runat="server">
        <table width="100%"  style="border-left:1px solid #CCCCCC;border-top:1px solid #CCCCCC;"  border="0" cellspacing="0" cellpadding="5">
          <tr>
                <th  style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;">Job Title</th><td align="left"   style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;"><asp:TextBox ID="txtJobTitle" runat="server" Width="400"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ControlToValidate="txtJobTitle" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
                <th  style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;">Occupation Code</th><td align="left"   style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;"><asp:TextBox ID="txtOccupation_Code" runat="server" Width="100"></asp:TextBox></td>
          </tr>
          <tr>
                <th  style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;">Nontechnical Job Description</th><td align="left"  style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;"><asp:TextBox ID="txtNTJobDesc" TextMode="MultiLine" Rows="4" runat="server" Width="600"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNTJobDesc" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
                <th  style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;">General Job Description</th><td align="left"  style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;"><asp:TextBox ID="txtJobDesc"  TextMode="MultiLine" Rows="10" runat="server" Width="605"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtJobDesc" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
          </tr>
          <tr><td  style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;">&nbsp;</td><td  style="border-right:1px solid #CCCCCC;border-bottom:1px solid #CCCCCC;"><asp:Button ID="btnSave" runat="server" Text="Save" 
                                onclick="btnSave_Click"/>&nbsp;&nbsp;<asp:Button 
                  ID="btnCancel" CausesValidation="false" runat="server" runat="server" Text="Cancel" 
                  onclick="btnCancel_Click" /></td></tr>
        </table>
        </asp:Panel>
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
