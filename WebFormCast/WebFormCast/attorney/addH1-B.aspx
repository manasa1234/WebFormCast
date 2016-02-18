<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addH1-B.aspx.cs" Inherits="WebFormCast.attorney.addH1_B" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>USIT</title>
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1 {
            background-image: url('../images/topbar_bg.gif');
            background-repeat: repeat-x;
            padding: 0 3px 0 3px;
            width: 966px;
        }

        .auto-style1 {
            background-image: url('../images/topbar_bg.gif');
            background-repeat: repeat-x;
            padding: 0 3px 0 3px;
            width: 363px;
            height: 26px;
        }

        .auto-style2 {
            height: 26px;
        }

        .auto-style3 {
            background-image: url('../images/topbar_bg.gif');
            background-repeat: repeat-x;
            padding: 0 3px 0 3px;
            width: 363px;
        }
        .auto-style4 {
            background-image: url('../images/topbar_bg.gif');
            background-repeat: repeat-x;
            padding: 0 3px 0 3px;
            width: 363px;
            height: 32px;
        }
        .auto-style5 {
            height: 32px;
        }
    </style>
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../css/calendar-tas.css" rel="stylesheet" type="text/css" />

    <script src="../calendar.js" type="text/javascript"></script>

    <script src="../lang/calendar-en.js" type="text/javascript"></script>

    <script src="../calendar-setup.js" type="text/javascript"></script>

   
    <script src="../scripts/content.js" type="text/javascript"></script>

            
</script>

</head>
<body>
    <form id="form2" runat="server">
        <div id="container">
            <div id="header">
                <div id="headerlogo">
                    <asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />-->
                </div>
                <div id="login_info">
                    Welcome! <strong>
                        <asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a>
                </div>
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
                                                    <asp:DropDownList ID="ddteam" runat="server" AutoPostBack="true" >
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
                                                    <asp:TextBox ID="TrackingNotxt" runat="server" Width="160px" ></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblfedexshipped" runat="server" Text="Fedex DateShipped"  />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="fedexshippedtxt" runat="server" Width="160px" ></asp:TextBox>
                                                </td>
                                                </tr>
                                            <tr>
                                                 <td>
                                                   RFE DueDate
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="uscisdttxt" runat="server" Width="160px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblstatusexpires" runat="server" Text="H1B DueDate"  />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="statusexptxt" runat="server" Width="160px" ></asp:TextBox>
                                                </td>
                                               
                                                <td>
                                                   <asp:Button ID="H1BSearch" runat="server" CausesValidation="false" Text="&nbsp;Find&nbsp;NIV&nbsp;" onclick="H1BSearch_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="reset" runat="server" CausesValidation="false" Text="&nbsp;Reset&nbsp;"
                                                        OnClick="reset_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="2">
                                        <img src="../images/topbar_sub_rgt.gif" width="2" height="78" />
                                    </td>
                                </tr>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ connectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [Legal_Name], [CompanyID] FROM [Company] WHERE ([Legal_Name] <> '') ORDER BY Legal_Name">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB%>"
                                    SelectCommand="SELECT * FROM [NIVtracking] ORDER BY NIVTrackingNumber"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [User_Display_Name], [User_ID] FROM [Users] WHERE ([User_Display_Name] <> '')">
                                </asp:SqlDataSource>
                            </table>
                        </td>
                        <td width="2">
                            <img src="../images/topbar_rgt.gif" width="2" height="87" />
                        </td>
                    </tr>
                </table>
                    <div class="shadow">
                    </div>
                    <div class="title">
                        Add New H1-B Information
                    </div>
                    <div class="bcru">
                        <a href="H1-B.aspx">NIV</a> &raquo; Add NIV
                    </div>
                    <div id="whiteArea">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="center">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="auto-style3">Company:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="lstcompany" runat="server" CssClass="style8" AppendDataBoundItems="True"
                                                    EnableViewState="False" DataSourceID="SqlDataSource1" DataTextField="Legal_Name"
                                                    DataValueField="CompanyID" Style="font-family: Verdana; font-size: small; text-align: left;"
                                                    AutoPostBack="True" Height="20px" Width="350px"   >
                                                    <asp:ListItem Selected="True" Value=''>-- Select Company Name</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3">Tracking ID:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RlTrack" runat="server" AutoPostBack="True" Style="font-family: Verdana;
                                                font-size: small" DataSourceID="SqlDataSource2" DataTextField="Tracking_No" DataValueField="Name" AppendDataBoundItems="true"
                                                Height="20px" Width="350px"  EnableViewState="False" OnSelectedIndexChanged="RlTrack_SelectedIndexChanged" 
                                               >
                                                <asp:ListItem Selected="True" Value=''>-- Select Case Number</asp:ListItem>
                                            </asp:DropDownList>
                                            </td>
                                        </tr>
                                            <%--<tr>
                                            <td class="auto-style3">NIVTracking Number:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNIVtrack" runat="server" Width="339px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtNIVtrack" EnableClientScript="false" ErrorMessage="< --- Missing"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td class="auto-style3">Date Initiated:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdateinitiated" runat="server" Width="339px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtdateinitiated" EnableClientScript="false" ErrorMessage="< --- Missing"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">LCA Tracking No:
                                            </td>
                                            <td class="auto-style2">
                                                <asp:TextBox ID="lsttrackno" runat="server" BorderStyle="None" ReadOnly="True" Width="347px"></asp:TextBox>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="auto-style3">LCA Filed:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="lstlcafiles" runat="server" BorderStyle="None" ReadOnly="True" Width="347px"></asp:TextBox>
                                        </tr>

                                        <tr>
                                            <td class="auto-style3">Due Date:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtduedate" runat="server" BorderStyle="None" ReadOnly="True" Width="347px" Height="16px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style4">Current Status:
                                            </td>
                                            <td class="auto-style5">
                                                <asp:DropDownList ID="ddcstatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddcasestatus_SelectedIndexChanged">
                                                   <%-- <asp:ListItem Selected="True" Value='0'>-- Select Current status---</asp:ListItem>--%>
                                                    <asp:ListItem selected="true" Value='H-1B '>H-1B </asp:ListItem>
                                                    <asp:ListItem Value='H-4 '>H-4 </asp:ListItem>
                                                    <asp:ListItem Value='L-1'>L-1</asp:ListItem>
                                                    <asp:ListItem Value='TN'>TN</asp:ListItem>
                                                    <asp:ListItem Value='E-3'>E-3</asp:ListItem>
                                                    <asp:ListItem Value='F-1'>F-1</asp:ListItem>
                                                    <asp:ListItem Value='B-1/B-2'>B-1/B-2</asp:ListItem>
                                                     <asp:ListItem Value='Out of the Country'>Out of the Country</asp:ListItem>
                                                    <asp:ListItem Value='Other'>Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                <td class="auto-style3">Case Type
                                </td>
                                <td>
                                      <asp:DropDownList ID="ddcasetype" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddcasetype_SelectedIndexChanged">
                                         
                                   
                                           </asp:DropDownList>
                                                
                                </td>
                            </tr>

                                        <tr>
                                            <td class="auto-style4">Draft Status:
                                            </td>
                                            <td class="auto-style5">
                                                <asp:DropDownList ID="ddcasestatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddcasestatus_SelectedIndexChanged" Height="16px">
                                                 <%--   <asp:ListItem Selected="True" Value='0'>-- Select Case status---</asp:ListItem>--%>
                                                    <asp:ListItem Selected="True" Value='Final Review'>Final Review</asp:ListItem>
                                                    <asp:ListItem Value='Reduced Review'>Reduced Review</asp:ListItem>
                                                    <asp:ListItem Value='Forms'>Forms</asp:ListItem>
                                                    <asp:ListItem Value='Hold'>Hold</asp:ListItem>
                                                    <asp:ListItem Value='Drafted'>Drafted</asp:ListItem>
                                                    <asp:ListItem Value='1stReview'>1stReview</asp:ListItem>
                                                    <asp:ListItem Value='RFE'>RFE</asp:ListItem>
                                                    <asp:ListItem Value='Denial'>Denial</asp:ListItem>
                                                    <asp:ListItem Value='NOIR'>NOIR</asp:ListItem>
                                                    <asp:ListItem Value='NOID'>NOID</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <div id="RFEhidden" runat="server" visible="false">
                                            <tr>
                                                <td class="auto-style3">RFE Type
                                                </td>
                                               <td>
                                                    <asp:TextBox ID="txtrfetype" runat="server" Width="347px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td t class="auto-style3">Date received
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtdatereceived" runat="server" Width="347px" ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">Date R4D sent
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtr4dsent" runat="server" Width="347px" ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">USCIS DueDate
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtuscisdate" runat="server" Width="347px" OnTextChanged="txtuscisdate__Leave" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">Internal DueDate
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtinternalduedt" BorderStyle="None" runat="server" ReadOnly="True" Width="347px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">Last Ship Date
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtlastshipdt" BorderStyle="None" runat="server" ReadOnly="True" Width="347px"></asp:TextBox>
                                                </td>
                                            </tr>
                                           <%-- <tr>
                                                <td class="auto-style3">Type of RFE
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txttypeofRFE" runat="server" Width="347px"></asp:TextBox>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td class="auto-style3">Eval Filed
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddevalfiled" runat="server">
                                                        <asp:ListItem Selected="True">Standard Evaluation </asp:ListItem>
                                                        <asp:ListItem>Academic & Experience Evaluation </asp:ListItem> 
                                                <asp:ListItem>Expert Opinion Letter </asp:ListItem> 
                                <asp:ListItem>On File</asp:ListItem> 
                                <asp:ListItem>N/A</asp:ListItem> </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">Missing Docs,If applicable
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtdocs" TextMode="MultiLine" runat="server" Width="347px"></asp:TextBox>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">Drafted?
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="dddrafted" runat="server">
                                                        <asp:ListItem Selected="True">yes</asp:ListItem>
                                                        <asp:ListItem>no</asp:ListItem></asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">Status:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtrfestatus" TextMode="MultiLine" runat="server" Width="347px"></asp:TextBox>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">LastUpdated:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtrfelstupdated" runat="server" Width="346px"></asp:TextBox>
                                            </tr>
                                        </div>
                                        <tr>
                                            <td class="auto-style3">Sig Pages:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddsigpages" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Selected="True" Value='Received'>Received</asp:ListItem>
                                                    <asp:ListItem Value='sent'>sent</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <td class="auto-style3">Checks:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddchecks" runat="server" AutoPostBack="true">
                                                <asp:ListItem Selected="True" Value='Received'>Received</asp:ListItem>
                                                <asp:ListItem Value='sent'>sent</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                            </tr>
                            <tr>
                                                <td class="auto-style3">Premium Processing?
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddpremiumprocessing" runat="server">
                                                        <asp:ListItem Selected="True">yes</asp:ListItem>
                                                        <asp:ListItem>no</asp:ListItem> </asp:DropDownList></td>
                                            </tr>
                            
                            <tr>
                                <td class="auto-style3">Status Expires:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtstatusexpires" runat="server" Width="337px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                        ControlToValidate="txtstatusexpires"  ErrorMessage="< --- Missing"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">H-4 Tracking No:
                                </td>
                                <td>
                                    <asp:TextBox ID="txth4trkno" runat="server" Width="337px"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">H-4 sigpages sent?
                                </td>
                                <td>
                                    <asp:TextBox ID="Txth4sigpagessent" runat="server" Width="337px"></asp:TextBox>

                                </td>
                            </tr>
                          <%--  <tr>
                                <td class="auto-style3">Last Action on Case:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtlastcaseactn" runat="server" Width="347px" TextMode="MultiLine"></asp:TextBox>

                                </td>
                            </tr>--%>
                            <tr>
                                <td class="auto-style3">Location of Case:
                                </td>

                                <td>
                                    <asp:DropDownList ID="ddlstates" runat="server"  Style="font-family: Verdana;
                                                font-size: small; text-align: left;" AutoPostBack="True" Height="20px" Width="350px">
                                   
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                        ControlToValidate="ddlstates" ErrorMessage="< --- Missing"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                        <td class="auto-style3">
                                            Assigned To
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lstUsers" runat="server"  AppendDataBoundItems="True"
                                                 Style="font-family: Verdana;
                                                font-size: small; text-align: left;" AutoPostBack="True" Height="20px" Width="350px" >
                                             <%--  <asp:ListItem Selected="True" Value='0'>Select User</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                            <tr>
                                <td class="auto-style3">Invoice:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtinvoice" runat="server" Width="337px"></asp:TextBox>
                                </td>
                            </tr>
                             <tr>
                                                <td class="auto-style3">Status Of Petition
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddpetetionstatus" runat="server">
                                                        <asp:ListItem Selected="True">Shipped </asp:ListItem>
                                                        <asp:ListItem>Receipted</asp:ListItem> 
                                                <asp:ListItem>Approval</asp:ListItem> 
                                <asp:ListItem>RFE</asp:ListItem> 
                                <asp:ListItem>Rejected</asp:ListItem>
                                <asp:ListItem>NOID</asp:ListItem> 
                                <asp:ListItem>NOIR</asp:ListItem>
                                                        <asp:ListItem>Withdrawn</asp:ListItem>
                                                         <asp:ListItem>Denied</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                             <td class="auto-style3">Team#
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddteams" runat="server">
                                                        <asp:ListItem Selected="True">Team 1 </asp:ListItem>
                                                        <asp:ListItem>Team 2</asp:ListItem> 
                                                <asp:ListItem>Team 3</asp:ListItem> 
                                <asp:ListItem>Team 4</asp:ListItem>
                                                         </asp:DropDownList></td>
                                            </tr> 
                             <tr>
                                <td class="auto-style3">Contractual Succession:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcontract" runat="server" Width="337px"></asp:TextBox>
                                </td>
                            </tr>
                             <tr>
                                <td class="auto-style3">H1-B Pending Documents:
                                </td>
                                <td>
                                    <asp:TextBox ID="txth1pending" runat="server" Width="337px"></asp:TextBox>
                                </td>
                            </tr>
                              <tr>
                                <td class="auto-style3">FedEx Tracking#:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfedextrck" runat="server" Width="337px"></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                <td class="auto-style3">FedEx Date Shipped:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfeddtshipped" runat="server" Width="337px" Display="Dynamic"></asp:TextBox>
                                  
                                </td>
                            </tr>
                              <tr>
                                <td class="auto-style3">FedEx Shipped By:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddfedexshipped" runat="server"  AppendDataBoundItems="True"
                                                 Style="font-family: Verdana;
                                                font-size: small; text-align: left;" AutoPostBack="True"   Height="20px" Width="350px" >
                                        <%--     <asp:ListItem Selected="True" Value='0'>Select User</asp:ListItem>--%>
                                            </asp:DropDownList>
                                  
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">Last Updated:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtlstupdated" runat="server" Width="337px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
                                        ControlToValidate="txtlstupdated" EnableClientScript="false" ErrorMessage="< --- Missing"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">Paid:
                                </td>
                                <td>
                                      <asp:RadioButtonList ID="rlstpaid" runat="server" RepeatDirection="Horizontal"  AutoPostBack="false">
                
                <asp:ListItem Text="YES" Selected="true" Value="YES"></asp:ListItem>
                <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                    </asp:RadioButtonList>
                                </td>
                            </tr>

                           <tr>
                                        <td class="auto-style3">
                                            Notes
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtnotes" runat="server" TextMode="MultiLine" Width="550px"></asp:TextBox>
                                        </td>
                                    </tr>
                                <<td >&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click1" />
                                    <asp:Label ID="Label1" runat="server" Style="color: #336600; font-weight: 700; font-family: Verdana; font-size: small"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
                            SelectCommand="SELECT DISTINCT [Legal_Name], [CompanyID] FROM [Company] WHERE ([Legal_Name] <> '') ORDER BY Legal_Name"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ connectionStrings:ACLG_DB%>"
                            SelectCommand="SELECT  [First_Name] +' '+ [Last_Name] as Name, [Tracking_No],Employee_id FROM [Employee] WHERE ([Company_id] = @Company_id) order by [Tracking_No] ">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lstcompany" Name="Company_id" PropertyName="SelectedValue"
                                    Type="Decimal" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        </td>
                        </tr>
                    </table>
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

    <script type="text/javascript" >
        //Calendar.setup({
        //    inputField: "txtdateinitiated",     // id of the input field
        //    ifFormat: "%m/%d/%Y",      // format of the input field
        //    button: "txtdateinitiated",  // trigger for the calendar (button ID)
        //    align: "Br",           // alignment (defaults to "Bl")
        //    singleClick: true
        //});

        Calendar.setup({
            inputField: "txtstatusexpires",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "txtstatusexpires",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });

        Calendar.setup({
            inputField: "txtlstupdated",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "txtlstupdated",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });
        Calendar.setup({
            inputField: "txtfeddtshipped",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "txtfeddtshipped",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });
        Calendar.setup({
            inputField: "txtstatusexpires",     // id of the input field
            ifFormat: "%m/%d/%Y",      // format of the input field
            button: "txtstatusexpires",  // trigger for the calendar (button ID)
            align: "Br",           // alignment (defaults to "Bl")
            singleClick: true
        });
        //codes to change hideDiv
       
        if (document.getElementById("RFEhidden").style.visibility != "hidden") {
            Calendar.setup({
                inputField: "txtdatereceived",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "txtdatereceived",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });
            Calendar.setup({
                inputField: "txtr4dsent",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "txtr4dsent",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });
            Calendar.setup({
                inputField: "txtuscisdate",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "txtuscisdate",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });
            Calendar.setup({
                inputField: "txtrfelstupdated",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "txtrfelstupdated",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });
        }
        
        //}
       
    </script>

    <script src="../scripts/content.js" type="text/javascript"></script>

</body>
</html>
