<%@ Page Language="C#" AutoEventWireup="true" Inherits="employee0" Codebehind="employee0.aspx.cs" %>

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
<form runat="server">
<div id="container">
  <div id="header">
  <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
  <div id="login_info">Welcome, <strong><asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
  </div>
  <div id="contentShadows">
    <ul class="topNav">
      <li class="current"><a href="employee.aspx"><b>Employee</b></a></li>
    </ul>
    <div id="contentArea1">
<table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg">&nbsp;</td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">Employee: <asp:Label ID="lbName" Text="&nbsp;" runat="server"></asp:Label></div>
      <div id="whiteArea">
        <%--<p><strong>DO NOT CAPITALZE THE WHOLE ANSWER - PLEASE FOLLOW INSTRUCTIONS</strong></p>--%>
                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="right">Are you currently in U.S.A in H-1B status or any other nonimmigrant status?</td>
            <td>
                <asp:RadioButton ID="rbUsResident1" runat="server" GroupName="UsResident" Text="Yes" AutoPostBack="true" OnCheckedChanged="radioUsResident_CheckedChanged"/>
                &nbsp;
                <asp:RadioButton ID="rbUsResident2" runat="server" GroupName="UsResident" Text="No" AutoPostBack="true" OnCheckedChanged="radioUsResident_CheckedChanged"/>
                &nbsp;
                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                <script type = "text/javascript">
                  function ValidateRadio(sender, args) {
                    args.IsValid = $("[name=UsResident]:checked").length > 0;
                  }
                </script>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="< --- Missing" ClientValidationFunction = "ValidateRadio" ForeColor="Red"></asp:CustomValidator>
            </td>
            <td align="right">Will your U.S.A Employer plcae you at a third party location?</td>
            <td>
                <asp:RadioButton ID="rbThirdParty1" runat="server" GroupName="ThirdParty" Text="Yes"/>
                &nbsp;
                <asp:RadioButton ID="rbThirdParty2" runat="server" GroupName="ThirdParty" Text="No"/>
                &nbsp;
                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                <script type = "text/javascript">
                    function ValidateRadio2(sender, args) {
    args.IsValid = $("[name=ThirdParty]:checked").length > 0;
}
                </script>
                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="< --- Missing" ClientValidationFunction = "ValidateRadio2" ForeColor="Red"></asp:CustomValidator>
            </td>
          </tr>
          <tr>
            <td align="right">Do you need to file for dependendents?</td>
            <td>
                <asp:RadioButton ID="rbFileDependents1" runat="server" GroupName="FileDependents" Text="Yes"/>
                &nbsp;
                <asp:RadioButton ID="rbFileDependents2" runat="server" GroupName="FileDependents" Text="No"/>
                &nbsp;
                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                <script type = "text/javascript">
                    function ValidateRadio5(sender, args) {
    args.IsValid = $("[name=FileDependents]:checked").length > 0;
}
                </script>
                <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="< --- Missing" ClientValidationFunction = "ValidateRadio5" ForeColor="Red"></asp:CustomValidator>
            </td>
            <td align="right">Were you previously employed?</td>
            <td>
                <asp:RadioButton ID="rbPrevEmployed1" runat="server" GroupName="PrevEmployed" Text="Yes"/>
                &nbsp;
                <asp:RadioButton ID="rbPrevEmployed2" runat="server" GroupName="PrevEmployed" Text="No"/>
                &nbsp;
                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                <script type = "text/javascript">
                    function ValidateRadio6(sender, args) {
    args.IsValid = $("[name=PrevEmployed]:checked").length > 0;
}
                </script>
                <asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="< --- Missing" ClientValidationFunction = "ValidateRadio6" ForeColor="Red"></asp:CustomValidator>
            </td>
          </tr>
          <tr>
            <td align="right">Are you related to the owner(s) of your U.S.A Employer?</td>
            <td>
                <asp:RadioButton ID="rbEmpRelated1" runat="server" GroupName="EmpRelated" Text="Yes"/>
                &nbsp;
                <asp:RadioButton ID="rbEmpRelated2" runat="server" GroupName="EmpRelated" Text="No"/>
                &nbsp;
                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                <script type = "text/javascript">
                    function ValidateRadio4(sender, args) {
                        args.IsValid = $("[name=EmpRelated]:checked").length > 0;
                    }
                </script>
                <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="< --- Missing" ClientValidationFunction = "ValidateRadio4" ForeColor="Red"></asp:CustomValidator>
            </td>
            <td align="right">Would you like to process your case in premium for an additional USCIS fee of $1225.00?</td>
            <td><asp:RadioButton ID="rbPremiumFee1" runat="server" GroupName="PremiumFee" Text="Yes"/>
                &nbsp;
                <asp:RadioButton ID="rbPremiumFee2" runat="server" GroupName="PremiumFee" Text="No"/>
                &nbsp;
                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                <script type = "text/javascript">
                    function ValidateRadio3(sender, args) {
    args.IsValid = $("[name=PremiumFee]:checked").length > 0;
}
                </script>
                <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="< --- Missing" ClientValidationFunction = "ValidateRadio3" ForeColor="Red"></asp:CustomValidator>
            </td>
          </tr>
        </table>
        <br />

        <br />
        <br />
        <div align="center" class="divBlock">
          <asp:Button ID="btnSubmit" runat="server" Text="Save & Continue" 
                onclick="btnSubmit_Click" />
          <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </div>
      </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
</form>
</body>
<%=strScript%>
</html>
