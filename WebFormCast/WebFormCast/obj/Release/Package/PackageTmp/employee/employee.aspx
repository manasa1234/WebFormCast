<%@ Page Language="C#" AutoEventWireup="true" Inherits="employee" CodeBehind="employee.aspx.cs" %>

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
            width: 193px;
        }

        .auto-style2 {
            width: 172px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div id="container">
            <div id="header">
                <div id="headerlogo">
                    <asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />-->
                </div>
                <div id="login_info">
                    Welcome, <strong>
                        <asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a>
                </div>
            </div>
            <div id="contentShadows">
                <ul class="topNav">
                    <li class="current"><a href="employee.aspx"><b>Employee</b></a></li>
                </ul>
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
                                        <td align="right" class="topbar_sub_bg"><a href="employee.aspx">
                                            <img src="../images/ep_icon01.png" width="42" height="42" align="absmiddle" />
                                            <strong>Personal Information</strong></a></td>
                                        <td width="2">
                                            <img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
                                    </tr>
                                </table>
                                <table border="0" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="2">
                                            <img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                                        <td align="right" class="topbar_sub_bg_gry"><a href="employee2.aspx">
                                            <img src="../images/ep_icon02_dis.png" width="42" height="42" align="absmiddle" />
                                            <strong>Education Details</strong></a></td>
                                        <td width="2">
                                            <img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
                                    </tr>
                                </table>
                                <table border="0" runat="server" id="tbEmployment" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="2">
                                            <img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                                        <td align="right" class="topbar_sub_bg_gry"><a href="employee3.aspx">
                                            <img src="../images/ep_icon03_dis.png" width="42" height="42" align="absmiddle" />
                                            <strong>Experience Details</strong></a></td>
                                        <td width="2">
                                            <img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
                                    </tr>
                                </table>
                                <table border="0" runat="server" id="tbDependent" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="2">
                                            <img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                                        <td align="right" class="topbar_sub_bg_gry"><a href="employee4.aspx">
                                            <img src="../images/ep_icon04_dis.png" width="42" height="42" align="absmiddle" />
                                            <strong>Dependant's Details</strong></a></td>
                                        <td width="2">
                                            <img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
                                    </tr>
                                </table>
                                <table border="0" runat="server" id="Table1" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="2">
                                            <img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                                        <td align="right" class="topbar_sub_bg_gry"><a href="finalize.aspx">
                                            <strong>Review and Submit</strong></a></td>
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
                        Employee:
                        <asp:Label ID="lbName" Text="&nbsp;" runat="server"></asp:Label>
                    </div>
                    <div id="whiteArea">
                        <div class="EmployeeStatus">
                            Status:
                            <asp:Label ID="lbStatus" Text="Approved" runat="server"></asp:Label>
                        </div>
                        <h2>Personal Information</h2>
                        <%--<p><strong>DO NOT CAPITALZE THE WHOLE ANSWER - PLEASE FOLLOW INSTRUCTIONS</strong></p>--%>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="right">Are you currently in U.S.A in H-1B status or any other nonimmigrant status?</td>
                                <td>
                                    <asp:RadioButton ID="rbUsResident1" runat="server" GroupName="UsResident" Text="Yes" AutoPostBack="true" OnCheckedChanged="radioUsResident_CheckedChanged" />&nbsp;<asp:RadioButton ID="rbUsResident2" runat="server" GroupName="UsResident" Text="No" AutoPostBack="true" OnCheckedChanged="radioUsResident_CheckedChanged" /></td>
                                <td align="right">Will your U.S.A Employer plcae you at a third party location?</td>
                                <td>
                                    <asp:RadioButton ID="rbThirdParty1" runat="server" GroupName="ThirdParty" Text="Yes" AutoPostBack="true" OnCheckedChanged="radioThirdParty_CheckedChanged" />&nbsp;<asp:RadioButton ID="rbThirdParty2" runat="server" GroupName="ThirdParty" Text="No" AutoPostBack="true" OnCheckedChanged="radioThirdParty_CheckedChanged" /></td>
                            </tr>
                            <tr>
                                <td align="right">Do you need to file for dependendents?</td>
                                <td>
                                    <asp:RadioButton ID="rbFileDependents1" runat="server" GroupName="FileDependents" Text="Yes" AutoPostBack="true" OnCheckedChanged="radioFileDependents_CheckedChanged" />
                                    &nbsp;
                                    <asp:RadioButton ID="rbFileDependents2" runat="server" GroupName="FileDependents" Text="No" AutoPostBack="true" OnCheckedChanged="radioFileDependents_CheckedChanged" />
                                    &nbsp;
                                </td>
                                <td align="right">Were you previously employed?</td>
                                <td>
                                    <asp:RadioButton ID="rbPrevEmployed1" runat="server" GroupName="PrevEmployed" Text="Yes" AutoPostBack="true" OnCheckedChanged="radioPrevEmployed_CheckedChanged" />
                                    &nbsp;
                                    <asp:RadioButton ID="rbPrevEmployed2" runat="server" GroupName="PrevEmployed" Text="No" AutoPostBack="true" OnCheckedChanged="radioPrevEmployed_CheckedChanged" />
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Are you related to the owner(s) of your U.S.A Employer?</td>
                                <td>
                                    <asp:RadioButton ID="rbEmpRelated1" runat="server" GroupName="EmpRelated" Text="Yes" />&nbsp;<asp:RadioButton ID="rbEmpRelated2" runat="server" GroupName="EmpRelated" Text="No" /></td>
                                <td align="right">Would you like to process your case in premium for an additional USCIS fee of $1225.00?</td>
                                <td>
                                    <asp:RadioButton ID="rbPremiumFee1" runat="server" GroupName="PremiumFee" Text="Yes" />&nbsp;<asp:RadioButton ID="rbPremiumFee2" runat="server" GroupName="PremiumFee" Text="No" /></td>
                            </tr>
                        </table>

                        <h4>PART I - INFORMATION ABOUT YOU:</h4>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="right">Last Name/Surname As per passport</td>
                                <td>
                                    <asp:TextBox ID="txtLast_Name" Width="150" runat="server"></asp:TextBox>
                                </td>
                                <td align="right">First Name</td>
                                <td>
                                    <asp:TextBox ID="txtFirst_Name" Width="150" runat="server"></asp:TextBox></td>
                                <td align="right">Middle Name</td>
                                <td>
                                    <asp:TextBox ID="txtMiddle_Name" Width="150" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right">Other Names</td>
                                <td>
                                    <asp:TextBox ID="txtOther_Name1" Width="150" runat="server"></asp:TextBox></td>
                                <td align="right">Other Names</td>
                                <td>
                                    <asp:TextBox ID="txtOther_Name2" Width="150" runat="server"></asp:TextBox></td>
                                <td align="right">Other Names</td>
                                <td>
                                    <asp:TextBox ID="txtOther_Name3" Width="150" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right">Tel #</td>
                                <td>
                                    <asp:TextBox ID="txtTelNo" Width="150" runat="server"></asp:TextBox></td>
                                <td align="right">Email id:</td>
                                <td>
                                    <asp:TextBox ID="txtEmail_Address" ReadOnly="true" Width="150" runat="server"></asp:TextBox></td>
                                <td align="right">Gender</td>
                                <td>
                                    <asp:RadioButton ID="rbTitle1" runat="server" GroupName="g1" />Male&nbsp;&nbsp;<asp:RadioButton ID="rbTitle2" runat="server" GroupName="g1" />Female</td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="right">Date of Birth<br />
                                    MM / DD / YY
                                </td>
                                <td>
                                    <input type="text" id="txtDateofBirth" size="15" runat="server" />&nbsp;<a href="#" id="f_DateofBirth"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a></td>
                                <td align="right">Country of Birth</td>
                                <td>
                                    <asp:DropDownList ID="ddCountryofBirth" runat="server"></asp:DropDownList>
                                </td>
                                <td align="right">Province/State of Birth</td>
                                <td>
                                    <asp:TextBox ID="txtStateofBirth" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>

                                <td align="right">Country of Citizenship</td>
                                <td>
                                    <asp:DropDownList ID="ddCountryofCitixenship" runat="server"></asp:DropDownList></td>
                                <td align="right">Passport Number</td>
                                <td>
                                    <asp:TextBox ID="txtPassportNumber" runat="server"></asp:TextBox></td>
                                <td align="right">Passport Issue Date</td>
                                <td>
                                    <input type="text" id="txtPassportissuedate" size="15" runat="server" />&nbsp;<a href="#" id="f_Passportissuedate"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right">Passport Country of Issuance</td>
                                <td>
                                    <asp:TextBox Width="65" ID="txtPassportIssueCountry" runat="server"></asp:TextBox></td>
                                <td align="right">Date Passport Expires</td>
                                <td>
                                    <input type="text" id="txtPassportExpiresDate" size="15" runat="server" />&nbsp;<a href="#" id="f_PassportExpiresDate"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a></td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="20%" align="right">Foreign address</td>
                                <td>
                                    <table class="test" cellspacing="0" border="0" cellpadding="3">
                                        <tr>
                                            <td align="center">
                                                <asp:TextBox ID="txtForeignAddress_Street" Width="200" runat="server"></asp:TextBox><br />
                                                <asp:Label ID="Label6" Text="Street" Font-Size="Small" runat="server" ForeColor="GrayText"></asp:Label></td>
                                            <td align="center">
                                                <asp:TextBox ID="txtForeignAddress_AppNo" Width="150" runat="server"></asp:TextBox><br />
                                                <asp:Label ID="Label7" Text="Appt#" Font-Size="Small" runat="server" ForeColor="GrayText"></asp:Label></td>
                                            <td align="center">
                                                <asp:TextBox ID="txtForeignAddress_City" Width="150" runat="server"></asp:TextBox><br />
                                                <asp:Label ID="Label8" Text="City" Font-Size="Small" runat="server" ForeColor="GrayText"></asp:Label></td>
                                            <td align="center">
                                                <asp:TextBox ID="txtForeignAddress_State" Width="80" runat="server"></asp:TextBox><br />
                                                <asp:Label ID="Label9" Text="State" Font-Size="Small" runat="server" ForeColor="GrayText"></asp:Label></td>
                                            <td align="center">
                                                <asp:TextBox ID="txtForeignAddress_Country" Width="80" runat="server"></asp:TextBox><br />
                                                <asp:Label ID="Label11" Text="Country" Font-Size="Small" runat="server" ForeColor="GrayText"></asp:Label></td>
                                            <td align="center">
                                                <asp:TextBox ID="txtForeignAddress_Zip" Width="50px"
                                                    runat="server"></asp:TextBox><br />
                                                <asp:Label ID="Label10" Text="Zip" Font-Size="Small" runat="server" ForeColor="GrayText"></asp:Label></td>
                                        </tr>
                                    </table>
                                    &nbsp;&nbsp;<asp:RadioButton ID="rdCurrentAddress1" runat="server" GroupName="g2" />This is my current address</td>
                            </tr>
                        </table>
                        <br />
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" runat="server" id="tbPart1USInfo">
                            <tr>
                                <td align="right">U.S. Social Security #</td>
                                <td>
                                    <asp:TextBox ID="txtSocialSecurity" runat="server"></asp:TextBox></td>
                                <td align="right">'A' Number</td>
                                <td>
                                    <asp:TextBox ID="txtANumber" runat="server"></asp:TextBox></td>
                                <td align="right">I-94 #</td>
                                <td>
                                    <asp:TextBox ID="txtI94" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right">Date of First Entry in USA</td>
                                <td>
                                    <input type="text" id="txtDateofFirstEntry" size="15" runat="server" />&nbsp;<a href="#" id="f_DateofFirstEntry"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a></td>
                                <td align="right">Date of Last Arrival in USA</td>
                                <td>
                                    <input type="text" id="txtDateofLastArrival" size="15" runat="server" />&nbsp;<a href="#" id="f_DateofLastArrival"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a></td>
                                <td align="right">Current Nonimmigrant Status</td>
                                <td>
                                    <asp:TextBox ID="txtCNIStatus" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Date Status Expires</td>
                                <td>
                                    <input type="text" id="txtCNIDateStatusExpires" size="15" runat="server" />&nbsp;<a href="#" id="f_CNIDateStatusExpires"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a></td>
                                <td align="right">SEVIS #</td>
                                <td>
                                    <asp:TextBox ID="txtSevisNo" runat="server" MaxLength="15"></asp:TextBox>
                                </td>
                                <td align="right">Student EAD Receipt #</td>
                                <td>
                                    <asp:TextBox ID="txtStdEADNo" runat="server" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Consulate City/Country for Visa Stamping</td>
                                <td valign="middle">
                                    <asp:TextBox ID="txtConsulateCityCountry" Width="65" runat="server" />/<asp:TextBox Width="65" ID="txtConsulateCityCountry1" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="right">U.S. address</td>
                                            <td>
                                                <table class="test" cellspacing="0" border="0" cellpadding="3">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="txtUSAddress_Street" Width="200" runat="server"></asp:TextBox><br />
                                                            <asp:Label ID="Label1" Text="Street" Font-Size="Small" runat="server" ForeColor="GrayText"></asp:Label></td>
                                                        <td align="center">
                                                            <asp:TextBox ID="txtUSAddress_AppNo" Width="150" runat="server"></asp:TextBox><br />
                                                            <asp:Label ID="Label2" Text="Appt#" Font-Size="Small" runat="server" ForeColor="GrayText"></asp:Label></td>
                                                        <td align="center">
                                                            <asp:TextBox ID="txtUSAddress_City" Width="150" runat="server"></asp:TextBox><br />
                                                            <asp:Label ID="Label3" Text="City" Font-Size="Small" runat="server" ForeColor="GrayText"></asp:Label></td>
                                                        <td align="center">
                                                            <asp:TextBox ID="txtUSAddress_State" Width="50" runat="server"></asp:TextBox><br />
                                                            <asp:Label ID="Label4" Text="State" Font-Size="Small" runat="server" ForeColor="GrayText"></asp:Label></td>
                                                        <td align="center">
                                                            <asp:TextBox ID="txtUSAddress_Zip" Width="80px" runat="server"></asp:TextBox><br />
                                                            <asp:Label ID="Label5" Text="Zip" Font-Size="Small" runat="server" ForeColor="GrayText"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                &nbsp;&nbsp;<asp:RadioButton ID="rdCurrentAddress2" runat="server" GroupName="g2" />This is my current address
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>

                        <div id="divPart2Info" runat="server">
                            <h4>PART II - INFORMATION REGARDING END CLIENT:</h4>
                        </div>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" runat="server" id="tbPart2Info">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="right">Job Title</td>
                                            <td class="auto-style2">
                                                <asp:TextBox ID="txtEC_JobTitle" Width="200" runat="server"></asp:TextBox>
                                            </td>
                                            <td align="right" class="auto-style1">Name of End-Client</td>
                                            <td>
                                                <asp:TextBox ID="txtEC_Name" Width="212px" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right">Address you will work from
                <br />
                                                (End-client Address, or Remote Address),
                <br />
                                                if more than one location state all locations</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtEC_Address" runat="server" TextMode="MultiLine" Rows="6" Columns="50" Width="678px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">Name of your manager at End-Client</td>
                                            <td class="auto-style2">
                                                <asp:TextBox ID="txtEC_MgrName" Width="150" runat="server"></asp:TextBox></td>
                                            <td colspan="3">
                                                <table>
                                                    <td align="right">Email Address:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtEC_Email" Width="150" runat="server"></asp:TextBox></td>
                                                    <td align="right">Phone Number</td>
                                                    <td>
                                                        <asp:TextBox ID="txtEC_Phone" Width="150" runat="server"></asp:TextBox></td>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a name="Vendor"></a>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <th colspan="5">Specify vendors if any, please list <u>all vendors</u> in the order of succession starting with End Client</th>
                                        </tr>
                                        <tr>
                                            <th>Vendor Name</th>
                                            <th>Personnel Contact Name</th>
                                            <th>Email</th>
                                            <th>Phone Number</th>
                                            <th>Action</th>
                                        </tr>
                                        <%=strRow1%>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:Button ID="btnVendorButton" runat="server" Text="Save" OnClick="btnVendorButton_Click" /></td>
                                        </tr>
                                        <%=strRow2%>
                                    </table>


                                </td>
                            </tr>
                        </table>

                        <h4>PART III - WHAT ARE YOUR JOB DUTIES FOR USA EMPLOYER:</h4>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtSkills" runat="server" Columns="150" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>

                        <h4>PART IV - INFORMATION REGARDING YOUR STAY IN H1-B STATUS:</h4>
                        <a name="QPrevReceipt"></a>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="20%" align="right">Were you on H-1B and/or L-1 status within past 7 yrs</td>
                                <td>
                                    <asp:RadioButton ID="rbH1B1" runat="server" GroupName="H1B" AutoPostBack="true" OnCheckedChanged="rbH1B_CheckedChanged" NavigateUrl="#" Text="Yes" />&nbsp;<asp:RadioButton ID="rbH1B2" runat="server" GroupName="H1B" AutoPostBack="true" OnCheckedChanged="rbH1B_CheckedChanged" NavigateUrl="#" Text="No" /></td>
                                <td align="right">Ever been denied</td>
                                <td>
                                    <asp:RadioButton ID="rbDenied1" runat="server" GroupName="Denied" Text="Yes" />&nbsp;<asp:RadioButton ID="rbDenied2" runat="server" GroupName="Denied" Text="No" /></td>
                            </tr>
                        </table>

                        <a name="PrevReceipt"></a>
                        <asp:PlaceHolder runat="server" ID="tbPastH1BRcpt">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th colspan="5">Please list all prior H-1B Receipt Numbers in the reverse cronological order (recent first)</th>
                                </tr>
                                <tr>
                                    <th>Receipt Number</th>
                                    <th>Petitioning Employer Name</th>
                                    <th>Action</th>
                                </tr>
                                <%=strPRRow1%>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtReceiptNo" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtReceiptEmpName" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="btnPrevReceiptButton" runat="server" Text="Save" OnClick="btnPrevReceiptButton_Click" /></td>
                                </tr>
                                <%=strPRRow2%>
                            </table>
                        </asp:PlaceHolder>

                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th colspan="4">If PERM filed</th>
                                <th>I-140 Receipt Number</th>
                            </tr>
                            <tr>
                                <td align="right">Date Filed</td>
                                <td>
                                    <input type="text" id="txtPERMDateFiled" size="15" runat="server" />&nbsp;<a href="#" id="f_PERMDateFiled"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a></td>
                                <td align="right">Case No.</td>
                                <td>
                                    <asp:TextBox ID="txtPERM_CaseNo" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtI140_ReceiptNo" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th colspan="4">If there are any other petitions/applications pending with USCIS filed on your behalf</th>
                            </tr>
                            <tr>
                                <td align="right">Type of Application</td>
                                <td>
                                    <asp:TextBox ID="txtPend_App_Type" runat="server"></asp:TextBox></td>
                                <td align="right">Receipt #</td>
                                <td>
                                    <asp:TextBox ID="txtPend_App_ReceiptNo" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <a name="PrevStay"></a>
                        <asp:PlaceHolder runat="server" ID="tbPastH1BStay">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th colspan="4">List prior periods of stay in H or L status in the U.S. for the past 6 years</th>
                                </tr>
                                <tr>
                                    <th>Status</th>
                                    <th>Date In</th>
                                    <th>Date Out</th>
                                    <th>Action</th>
                                </tr>
                                <%=strStayRow1%>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtStayStatus" runat="server"></asp:TextBox></td>
                                    <td>
                                        <input type="text" id="txtStayDateIn" runat="server" />&nbsp;<a href="#" id="f_StayDateIn"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a></td>
                                    <td>
                                        <input type="text" id="txtStayDateOut" runat="server" />&nbsp;<a href="#" id="f_StayDateOut"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a></td>
                                    <td>
                                        <asp:Button ID="btnPrevStayButton" runat="server" Text="Save" OnClick="btnPrevStayButton_Click" /></td>
                                </tr>
                                <%=strStayRow2%>
                            </table>
                        </asp:PlaceHolder>
                        <br />
                        <div align="center" class="divBlock">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save & Continue"
                                OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                        </div>
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
            inputField: "txtDateofBirth",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "f_DateofBirth",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });
        Calendar.setup({
            inputField: "txtPassportExpiresDate",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "f_PassportExpiresDate",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });
        Calendar.setup({
            inputField: "txtPERMDateFiled",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "f_PERMDateFiled",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });
        if (document.getElementById("txtStayDateIn")) {
            Calendar.setup({
                inputField: "txtStayDateIn",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "f_StayDateIn",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });
        }
        if (document.getElementById("txtStayDateOut")) {
            Calendar.setup({
                inputField: "txtStayDateOut",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "f_StayDateOut",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });
        }
    </script>

    <script type="text/javascript" id="scriptQuestionUSResident">
        if (document.getElementById("txtDateofFirstEntry")) {
            Calendar.setup({
                inputField: "txtDateofFirstEntry",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "f_DateofFirstEntry",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });
        }

        if (document.getElementById("txtDateofLastArrival")) {
            Calendar.setup({
                inputField: "txtDateofLastArrival",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "f_DateofLastArrival",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });
        }

        if (document.getElementById("txtCNIDateStatusExpires")) {
            Calendar.setup({
                inputField: "txtCNIDateStatusExpires",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "f_CNIDateStatusExpires",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });
        }
    </script>

    <input id="flag" value="1" type="hidden" />
</body>
<%=strScript%>
</html>
