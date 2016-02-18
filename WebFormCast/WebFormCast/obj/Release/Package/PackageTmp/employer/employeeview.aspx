<%@ Page Language="C#" AutoEventWireup="true" Inherits="employer_employeeview" CodeBehind="employeeview.aspx.cs" %>

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
                <div id="headerlogo">
                    <asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>
                <div id="login_info">Welcome! <strong>
                    <asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
            </div>
            <div id="contentShadows">
                <ul class="topNav">
                    <li class="current"><a href="employer.aspx"><b>Home</b></a></li>
                    <li><a href="employer_manage.aspx"><b>Add New Employee</b></a></li>
                    <li><a href="employer_myaccount.aspx"><b>My Account</b></a></li>
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
                                        <td align="right" class="topbar_sub_bg">Tracking No.
                <input type="text" name="textfield" id="textfield" style="width: 120px" />
                                            <input type="submit" name="button" id="button" value="Search" /></td>
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
                    <div class="title">Employee:
                        <asp:Label ID="lbName" runat="server" Text="&nbsp;"></asp:Label>
                    </div>
                    <div class="bcru">&raquo; Employee</div>
                    <div id="whiteArea">
                        <div class="EmployeeStatus">Status:
                            <asp:Label ID="lbStatus" Text="Approved" runat="server"></asp:Label></div>
                        <br />
                        <div id="whiteArea0">
                            <h2>EMPLOYEE INFORMATION SHEET&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="hledit" runat="server" Text="Edit" NavigateUrl="employee.aspx"></asp:HyperLink></h2>

                            <h4>PART I - INFORMATION ABOUT YOU:</h4>

                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="right">Last Name/Surname As per passport</td>
                                    <td>
                                        <asp:Label ID="txtLast_Name" Width="150" runat="server"></asp:Label>
                                    </td>
                                    <td align="right">First Name</td>
                                    <td>
                                        <asp:Label ID="txtFirst_Name" Width="150" runat="server"></asp:Label></td>
                                    <td align="right">Middle Name</td>
                                    <td>
                                        <asp:Label ID="txtMiddle_Name" Width="150" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Other Names</td>
                                    <td>
                                        <asp:Label ID="txtOther_Name1" Width="150" runat="server"></asp:Label></td>
                                    <td align="right">Other Names</td>
                                    <td>
                                        <asp:Label ID="txtOther_Name2" Width="150" runat="server"></asp:Label></td>
                                    <td align="right">Other Names</td>
                                    <td>
                                        <asp:Label ID="txtOther_Name3" Width="150" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Tel #</td>
                                    <td>
                                        <asp:Label ID="txtTelNo" Width="150" runat="server"></asp:Label></td>
                                    <td align="right">Email id:</td>
                                    <td>
                                        <asp:Label ID="txtEmail_Address" Width="150" runat="server"></asp:Label></td>
                                    <td>Gender</td>
                                    <td>
                                        <asp:Label ID="rbGender" runat="server" /></td>
                                </tr>
                            </table>
                            <br />

                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="right">Date of Birth<br />
                                        MM / DD / YY
                                    </td>
                                    <td>
                                        <asp:Label ID="txtDateofBirth" runat="server" /></td>
                                    <td align="right">Country of Birth</td>
                                    <td>
                                        <asp:Label ID="ddCountryofBirth" runat="server" />
                                    </td>
                                    <td align="right">Province/State of Birth</td>
                                    <td>
                                        <asp:Label ID="txtStateofBirth" runat="server"></asp:Label></td>
                                </tr>
                                <tr>

                                    <td align="right">Country of Citizenship</td>
                                    <td>
                                        <asp:Label ID="ddCountryofCitixenship" runat="server"></asp:Label></td>
                                    <td align="right">Passport Number</td>
                                    <td>
                                        <asp:Label ID="txtPassportNumber" runat="server"></asp:Label></td>
                                    <td align="right">Passport Issue Date</td>
                                    <td>
                                        <asp:Label ID="txtPassportissuedate" runat="server" />&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right">Passport Country of Issuance</td>
                                    <td>
                                        <asp:Label ID="txtPassportIssueCountry" runat="server" /></td>
                                    <td align="right">Date Passport Expires</td>
                                    <td>
                                        <asp:Label ID="txtPassportExpiresDate" runat="server" /></td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="20%" align="right">Foreign address</td>
                                    <td>
                                        <asp:Label ID="txtForeignAddress" Width="600" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                            <br />
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" runat="server" id="tbPart1USInfo">
                                <tr>
                                    <td align="right">U.S. Social Security #</td>
                                    <td>
                                        <asp:Label ID="txtSocialSecurity" runat="server"></asp:Label></td>
                                    <td align="right">'A' Number</td>
                                    <td>
                                        <asp:Label ID="txtANumber" runat="server"></asp:Label></td>
                                    <td align="right">I-94 #</td>
                                    <td>
                                        <asp:Label ID="txtI94" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Date of First Entry in USA</td>
                                    <td>
                                        <asp:Label ID="txtDateofFirstEntry" runat="server" /></td>
                                    <td align="right">Date of Last Arrival in USA</td>
                                    <td>
                                        <asp:Label ID="txtDateofLastArrival" runat="server" /></td>
                                    <td align="right">Current Nonimmigrant Status</td>
                                    <td>
                                        <asp:Label ID="txtCNIStatus" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">Date Status Expires</td>
                                    <td>
                                        <asp:Label ID="txtCNIDateStatusExpires" runat="server" /></td>
                                    <td align="right">SEVIS #</td>
                                    <td>
                                        <asp:Label ID="txtSevis" runat="server"></asp:Label>
                                    </td>
                                    <td align="right">Student EAD Receipt #</td>
                                    <td>
                                        <asp:Label ID="txtStdEADNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">Consulate City/Country for Visa Stamping</td>
                                    <td valign="middle">
                                        <asp:Label ID="txtConsulateCityCountry" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="right">U.S. address</td>
                                                <td>
                                                    <asp:Label ID="txtUSAddress" Width="600" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <h4>PART II - INFORMATION REGARDING END CLIENT:</h4>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" runat="server" id="tbPart2Info">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="right">Job Title</td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="txtEC_JobTitle" runat="server"></asp:Label>
                                                </td>
                                                <td align="right" class="auto-style1">Name of End-Client</td>
                                                <td>
                                                    <asp:Label ID="txtEC_Name" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right">Address you will work from
                <br />
                                                    (End-client Address, or Remote Address),
                <br />
                                                    if more than one location state all locations</td>
                                                <td colspan="3">
                                                    <asp:Label ID="txtEC_Address" runat="server" TextMode="MultiLine" Rows="6" Columns="50" Width="678px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">Name of your manager at End-Client</td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="txtEC_MgrName" Width="150" runat="server"></asp:Label></td>
                                                <td colspan="2">
                                                    <table>
                                                        <td align="right">Email Address:</td>
                                                        <td>
                                                            <asp:Label ID="txtEC_Email" Width="150" runat="server"></asp:Label></td>
                                                        <td align="right">Phone Number</td>
                                                        <td>
                                                            <asp:Label ID="txtEC_Phone" Width="150" runat="server"></asp:Label></td>
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
                                                <th colspan="4">Specify vendors if any, please list <u>all vendors</u> in the order of succession starting with End Client</th>
                                            </tr>
                                            <tr>
                                                <th>Vendor Name</th>
                                                <th>Personnel Contact Name</th>
                                                <th>Email</th>
                                                <th>Phone Number</th>
                                            </tr>
                                            <%=strVendorRow%>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                            <h4>PART III - WHAT ARE YOUR JOB DUTIES FOR USA EMPLOYER:</h4>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="txtSkills" runat="server" Columns="120" Rows="5" TextMode="MultiLine"></asp:Label></td>
                                </tr>
                            </table>

                            <h4>PART IV - INFORMATION REGARDING YOUR STAY IN H1-B STATUS:</h4>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="20%" align="right">Were you on H-1B and/or L-1 status within past 7 yrs</td>
                                    <td>
                                        <asp:Label ID="rbH1B1" runat="server" /></td>
                                    <td align="right">Ever been denied</td>
                                    <td>
                                        <asp:Label ID="rbDenied1" runat="server" /></td>
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
                                    </tr>
                                    <%=strPRRow%>
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
                                        <asp:Label ID="txtPERMDateFiled" runat="server"></asp:Label>
                                    </td>
                                    <td align="right">Case No.</td>
                                    <td>
                                        <asp:Label ID="txtPERM_CaseNo" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtI140_ReceiptNo" runat="server"></asp:Label>
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
                                        <asp:Label ID="txtPend_App_Type" runat="server"></asp:Label></td>
                                    <td align="right">Receipt #</td>
                                    <td>
                                        <asp:Label ID="txtPend_App_ReceiptNo" runat="server"></asp:Label>
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
                                    </tr>
                                    <%=strStayRow%>
                                </table>
                            </asp:PlaceHolder>
                            <br />
                            <h4>EDUCATIONAL QUALIFICATIONS:</h4>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th>UNIVERSITY / BOARD</th>
                                    <th>FROM MM/YY</th>
                                    <th>TO MM/YY</th>
                                    <th>GRAD YR</th>
                                    <th>DEGREE / DIPLOMA</th>
                                </tr>
                                <%=strRowEducation%>
                            </table>
                            <h4>EXPERIENCE DETAILS:</h4>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th>EMPLOYER NAME</th>
                                    <th>FROM MM/YY</th>
                                    <th>TO MM/YY</th>
                                    <th>SKILLS</th>
                                    <th>DESIGNATION</th>
                                </tr>
                                <%=strRowProfesnal%>
                            </table>
                            <br />
                            <h4>DEPENDENTS DETAILS:</h4>
                            <%=strDependents%>
                        </div>
                        <br />
                        <div class="whiteArea">
                            <h4>INFORMATION ABOUT THE FILING</h4>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="25%">Job Title</td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddJobTitle" runat="server"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>Dates of intended employment (mm/dd/yyyy) </td>
                                    <td>From:
                                    <input type="text" id="txtDateIntendedFrom" maxlength="10" runat="server" />&nbsp;<a href="#" id="f_DateIntendedFrom"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a>
                                        &nbsp;&nbsp;
            <input type="text" maxlength="10" id="txtDateIntendedTo" runat="server" />&nbsp;<a href="#" id="f_DateIntendedTo"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a></td>
                                </tr>
                                <tr>
                                    <td>Is this a full time position?</td>
                                    <td>
                                        <asp:RadioButton runat="server" ID="FulltimeNo" GroupName="G1" />No - Hours per week: 
                <asp:TextBox ID="txtHoursperWeek" runat="server" Width="69px"></asp:TextBox>
                                        <br />
                                        <br />
                                        <asp:RadioButton runat="server" ID="FulltimeYes" GroupName="G1" />Yes - Wages per week or per year: 
                <asp:TextBox ID="txtWagsperYear" runat="server" Width="55px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Work Location</td>
                                    <td>
                                        <asp:TextBox ID="txtWorkLocation" Width="350px" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lbFillStatus" runat="server"></asp:Label>&nbsp;</td>
                                </tr>
                            </table>
                            <div class="divBlock" align="center">
                                <asp:Button ID="btnApprove" Text="Approve & Submit to Attorney"
                                    Width="200px" runat="server" OnClick="btnApprove_Click" />
                                &nbsp;&nbsp;
              <asp:Button ID="btnSubmit" runat="server" Text="Save"
                  OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                            </div>
                        </div>
                        <br />
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
            inputField: "txtDateIntendedFrom",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "f_DateIntendedFrom",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });

        Calendar.setup({
            inputField: "txtDateIntendedTo",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "f_DateIntendedTo",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });

    </script>
</body>
</html>
