<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editH1-B.aspx.cs" Inherits="WebFormCast.attorney.editH1_B" %>
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
    <form id="form1" runat="server">
    <div id="container">
        <div id="header">
            <div id="headerlogo">
                <asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif"  width ="160" height="45" />--></div>
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
                <table border="0" cellspacing="0" cellpadding="0"  width ="100%">
                    <tr>
                        <td  width ="2">
                            <img src="../images/topbar_lft.gif"  width ="2" height="87" />
                        </td>
                        <td class="topbar_bg">
                            <table border="0" align="left" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td  width ="2">
                                        <img src="../images/topbar_sub_lft.gif"  width ="2" height="78" />
                                    </td>
                                    <td align="left" class="topbar_sub_bg">
                                        <table border="0" align="left" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    Company Name
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddCompany" runat="server" DataSourceID="SqlDataSource8" DataTextField="Legal_Name"
                                                        DataValueField="CompanyID" Style=" width : 200px" AppendDataBoundItems="True" EnableViewState="true"
                                                        OnSelectedIndexChanged="ddCompany_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Selected="True" Value='All'>All</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;Status Of Petition
                                                    <%--<br />&nbsp;&nbsp;Date Petetion Filed--%>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddstatuespetetion" runat="server" Style=" width : 200px" AppendDataBoundItems="True"
                                                        EnableViewState="true" AutoPostBack="true" >
                                                        <asp:ListItem Selected="True" Value=''>--select status of petition </asp:ListItem>
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
                                                    <asp:TextBox ID="dtpetetion" runat="server" Style=" width : 200px"></asp:TextBox>--%>
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
                                                    <asp:DropDownList ID="ddStatus" runat="server" Style=" width : 200px" EnableViewState="true"
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
                                                    <asp:TextBox ID="TrackingNotxt" runat="server"  width ="160px" ></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblfedexshipped" runat="server" Text="Fedex DateShipped"  />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="fedexshippedtxt" runat="server"  width ="160px" ></asp:TextBox>
                                                </td>
                                                </tr>
                                            <tr>
                                                 <td>
                                                   RFE DueDate
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="uscisdttxt" runat="server"  width ="160px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblstatusexpires" runat="server" Text="H1B DueDate"  />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="statusexptxt" runat="server"  width ="160px" ></asp:TextBox>
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
                                    <td  width ="2">
                                        <img src="../images/topbar_sub_rgt.gif"  width ="2" height="78" />
                                    </td>
                                </tr>
                                <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ connectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [Legal_Name], [CompanyID] FROM [Company] WHERE ([Legal_Name] <> '') ORDER BY Legal_Name">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB%>"
                                    SelectCommand="SELECT * FROM [NIVtracking] ORDER BY NIVTrackingNumber"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [User_Display_Name], [User_ID] FROM [Users] WHERE ([User_Display_Name] <> '')">
                                </asp:SqlDataSource>
                            </table>
                        </td>
                        <td  width ="2">
                            <img src="../images/topbar_rgt.gif"  width ="2" height="87" />
                        </td>
                    </tr>
                </table>
                <div class="shadow">
                </div>
                <div class="title">
                    Edit NIV</div>
                <div class="bcru">
                    <a href="H1-B.aspx">NIV</a> » Edit</div>
                <div id="whiteArea">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ connectionStrings:ACLG_DB %>"
                        DeleteCommand="DELETE FROM [NIVTracking] WHERE [ID] = @ID" 
                        SelectCommand="SELECT NIVTracking.*, Company.* FROM [NIVTracking], Company where CompanyID = Company and [ID] =@ID"
                          UpdateCommand="UPDATE [dbo].[NIVtracking]SET[LCATrackNumber] = @LCATrackNumber,[LCAfiled] = @LCAfiled,[DueDate] = @DueDate,[DraftStatus] = @DraftStatus,[SigPages] = @SigPages,[Check] = @Check,[Premium_Processing] = @Premium_Processing,[Case_Type] = @Case_Type,[Status_Expires] =@Status_Expires,[location] = @location,[H4TrackNumber] = @H4TrackNumber,[H4_SigPages] = @H4_SigPages,[Invoice] = @Invoice,[Last_Updated] = @Last_Updated,[Paid] = @Paid,[User_Id] = @User_Id,[RFE_Type] = @RFE_Type,[RFEDateReceive] = @RFEDateReceive,[Date_R4D_Sent] = @Date_R4D_Sent,[RFE_Internal_Due_Date] = @RFE_Internal_Due_Date,[RFE_LastShip_Date] = @RFE_LastShip_Date,[RFE_Uscis_DueDate] = @RFE_Uscis_DueDate,[RFE_Evaluation_Filed] = @RFE_Evaluation_Filed,[RFE_Missing_Docs] = @RFE_Missing_Docs,[RFE_Drafted] = @RFE_Drafted,[RFE_Status] = @RFE_Status,[RFE_LastUpdated] = @RFE_LastUpdated,[Notes] = @Notes,[Date_Initiated] = @Date_Initiated,[Current_Status] = @Current_Status,[FedexTracking] = @FedexTracking,[Fedex_ShippedBy] = @Fedex_ShippedBy,[Fedex_DateShipped] = @Fedex_DateShipped,[PetetionStatus] = @PetetionStatus,[Team] = @Team WHERE [ID] = @ID"
                        OnUpdated="OnDSUpdatedHandler">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ID" QueryStringField="H1BID" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="LCATrackNumber" Type="String" />
                            <asp:Parameter Name="LCAfiled" Type="DateTime" />
                               <asp:Parameter Name="DueDate" Type="DateTime" />
                            <asp:Parameter Name="DraftStatus" Type="String" />
                            <asp:Parameter Name="SigPages" Type="String" />
                            <asp:Parameter Name="Check" Type="String" />
                            <asp:Parameter Name="Premium_Processing" Type="String" />
                            <asp:Parameter Name="Case_Type" Type="String" />
                            <asp:Parameter Name="Status_Expires" Type="DateTime" />
                            <asp:Parameter Name="location" Type="Int32" />
                            <asp:Parameter Name="H4TrackNumber" Type="String" />
                            <asp:Parameter Name="H4_SigPages" Type="String" />
                            <asp:Parameter Name="Invoice" Type="String" />
                            <asp:Parameter Name="Last_Updated" Type="DateTime" />
                            <asp:Parameter Name="Paid" Type="String" />
                            <asp:Parameter Name="User_Id" Type="Int32" />
                            <asp:Parameter Name="RFE_Type" Type="String" />
                            <asp:Parameter Name="RFEDateReceive" Type="DateTime" />
                            <asp:Parameter Name="Date_R4D_Sent" Type="DateTime" />
                            <asp:Parameter Name="RFE_Internal_Due_Date" Type="DateTime" />
                            <asp:Parameter Name="RFE_LastShip_Date" Type="DateTime" />
                            <asp:Parameter Name="RFE_Uscis_DueDate" Type="DateTime" />
                            <asp:Parameter Name="RFE_Evaluation_Filed" Type="String" />
                            <asp:Parameter Name="RFE_Missing_Docs" Type="String" />
                            <asp:Parameter Name="RFE_Drafted" Type="String" />
                            <asp:Parameter Name="RFE_Status" Type="String" />
                            <asp:Parameter Name="RFE_LastUpdated" Type="DateTime" />
                           
                            <asp:Parameter Name="Notes" Type="String" />
                            <asp:Parameter Name="Date_Initiated" Type="DateTime" />
                           
                            <asp:Parameter Name="Current_Status" Type="String" />
                            <asp:Parameter Name="FedexTracking" Type="String" />
                            <asp:Parameter Name="Fedex_ShippedBy" Type="Int32" />
                            <asp:Parameter Name="Fedex_DateShipped" Type="DateTime" />
                            <asp:Parameter Name="PetetionStatus" Type="String" />
                            <asp:Parameter Name="Team" Type="String" />
                            <asp:Parameter Name="ID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
                        SelectCommand="SELECT DISTINCT [User_Display_Name], [User_ID] FROM [Users] WHERE ([User_Display_Name] <> '')">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
                        SelectCommand="SELECT DISTINCT [User_Display_Name], [User_ID] FROM [Users] WHERE ([User_Display_Name] <> '')">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
                        SelectCommand="select Visa_Type_Id,Visa_Type_Name from Visa_Type where Visa_Type.Category_Id=1">
                    </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ connectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [Legal_Name], [CompanyID] FROM [Company] WHERE ([Legal_Name] <> '') ORDER BY Legal_Name">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB%>"
                                    SelectCommand="SELECT * FROM [NIVtracking] ORDER BY NIVTrackingNumber"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [User_Display_Name], [User_ID] FROM [Users] WHERE ([User_Display_Name] <> '')">
                                </asp:SqlDataSource>
                    <table  width ="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="center">
                                <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" DataSourceID="SqlDataSource1"
                                    OnDataBound="fv_DataBound" Style="text-align: left; font-family: Verdana; font-size: small;"
                                     width ="910px" CellPadding="4" ForeColor="#333333">
                                    <EditItemTemplate >
                                        &nbsp;<table bgcolor="White" border="1" class="style2">
                                            <tr>
                                                <th align="left" colspan="2">
                                                   NIV
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton03" runat="server" CausesValidation="True" CommandName="Update"
                                                        Text="Update" OnDataBound="btnchange" />
                                                    &nbsp;<asp:LinkButton ID="LinkButton04" runat="server" CausesValidation="False" CommandName="Cancel"
                                                        Text="Cancel" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tracking ID
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TrackingNoTextBox" ReadOnly="true" runat="server"  width ="300px"  Text='<%# Bind("RLTrackingNumber") %>'
                                                         />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Company
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="CompanyTextBox" runat="server" ReadOnly="false"  width ="300px"  Text='<%# Bind("Legal_name") %>'
                                                        />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   DateInitiated
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="DateinitiatedTextBox" runat="server"  width ="300px" Text='<%# Bind("Date_Initiated") %>'
                                                        ReadOnly="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    LCA Tracking No
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="LCAtrackNoTextBox" runat="server"  width ="300px"  Text='<%# Bind("LCATrackNumber") %>' ReadOnly="true"
                                                        />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    LCA Filed
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="LCAfiledTextBox" runat="server"   width ="300px" Text='<%# Bind("LCAfiled") %>' ReadOnly="true"
                                                         />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    DueDate
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="DuedateTextBox" runat="server"  width ="300px"  Text='<%# Bind("DueDate") %>'  readonly="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   Current Status
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstcurrentstatus" Text='<%# Bind("Current_Status") %>' runat="server"
                                                        AutoPostBack="True" Height="20px"  width ="300px" 
                                                        >
                                                       
                                                    <asp:ListItem Selected="True" Value='H-1B '>H-1B </asp:ListItem>
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
                                                <td>
                                                    Case Type
                                                </td>
                                                 <td>
                                                    <asp:DropDownList ID="lstCasetype" runat="server" Text='<%# Bind("Case_Type") %>'
                                                        DataSourceID="SqlDataSource4" DataTextField="Visa_Type_Name" DataValueField="Visa_Type_Id"
                                                        AppendDataBoundItems="true" Height="20px"  width ="300px"  >
                                                      <%--  <asp:ListItem Selected="True" Value='0'>Select CaseType</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    Draft Status
                                                </td>
                                                 <td>
                                                    <asp:DropDownList ID="lstDraftstatus" runat="server" Text='<%# Bind("DraftStatus") %>'
                                                        AppendDataBoundItems="true" Height="20px"  width ="300px" AutoPostBack="true" OnSelectedIndexChanged="lstDraftstatus_SelectedIndexChanged">
                                                       <%-- <asp:ListItem Selected="True" Value='0'>-- Select Case status</asp:ListItem>--%>
                                                    <asp:ListItem  Selected="True" Value='Final Review'>Final Review</asp:ListItem>
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
                                             <asp:Panel id="rfehidden1" runat="server"  width ="300px"  Visible="false">
                                            <tr>
                                                <td>
                                                    RFE Type
                                                </td>
                                                <td>
                                                  <asp:TextBox ID="rfetypeTextBox"  width ="300px" runat="server" Text='<%# Bind("RFE_Type") %>'  />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   Date Received
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtrfedtreceived" runat="server"  Text='<%# Bind("RFEDateReceive") %>'  />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Date R4D sent
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtr4dsent" runat="server"  width ="300px"  Text='<%# Bind("Date_R4D_Sent") %>'  />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    USCIS Due Date
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtrfeuscisdt" runat="server"  width ="300px"  AutoPostBack="true" Text='<%# Bind("RFE_Uscis_DueDate","{0:MM/dd/yyyy}") %>'  OnTextChanged="txtrfeuscisdt__Leave" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    Internal DueDate
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtinternalduedt" runat="server"  width ="300px"  Text='<%# Bind("RFE_Internal_Due_Date","{0:MM/dd/yyyy}") %>' ReadOnly="true" ></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="style1">
                                                    LastShip Date
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtlastshipdt" runat="server"  width ="300px"   Text='<%# Bind("RFE_LastShip_Date") %>' ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td>
                                                    Eval Filed
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstevalfiled" runat="server"  width ="300px" 
                                                        AutoPostBack="True" Text='<%# Bind("RFE_Evaluation_Filed") %>'>
                                                            <asp:ListItem Selected="True"></asp:ListItem>
                                                        <asp:ListItem >Standard Evaluation </asp:ListItem>
                                                        <asp:ListItem>Academic & Experience Evaluation </asp:ListItem> 
                                                <asp:ListItem>Expert Opinion Letter </asp:ListItem> 
                                <asp:ListItem>On File</asp:ListItem> 
                                <asp:ListItem>N/A</asp:ListItem> 
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   Missing Docs
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtrfemissidngdocs" runat="server" textmode="MultiLine"  width ="300px" 
                                                        Text='<%# Bind("RFE_Missing_Docs") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   Drafted
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstrfedrafted" runat="server"  Text='<%# Bind("RFE_Drafted") %>'  width ="300px" >
                                                         <asp:ListItem Selected="True"></asp:ListItem>
                                                        <asp:ListItem >yes</asp:ListItem>
                                                        <asp:ListItem>no</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                  Status
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="lstrfestatus1" runat="server" textmode="MultiLine"  width ="300px" 
                                                        Text='<%# Bind("RFE_Status") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                  Last Updated
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="txtrfelastupdated" runat="server"   width ="300px" 
                                                        Text='<%# Bind("RFE_LastUpdated") %>' />
                                                </td>
                                            </tr>
                                                 </asp:Panel>
                                           <tr>
                                                <td>
                                                   Sig Pages
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstsigpages" runat="server"   width ="300px" Text='<%# Bind("SigPages") %>'>
                                                             <asp:ListItem Selected="True" Value='Received'>Received</asp:ListItem>
                                                <asp:ListItem Value='sent'>sent</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                  Checks
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstchecks" runat="server"  width ="300px"  Text='<%# Bind("Check") %>'>
                                                              <asp:ListItem Selected="True" Value='Received'>Received</asp:ListItem>
                                                <asp:ListItem Value='sent'>sent</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                               <tr>
                                                <td>
                                                  Premium Processing?
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstpremiumprocess" runat="server"  width ="300px"  Text='<%# Bind("Premium_Processing") %>'>
                                                                 <asp:ListItem Selected="True">yes</asp:ListItem>
                                                        <asp:ListItem>no</asp:ListItem> 
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                  Status Expires
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="txtstatusexpires" runat="server"  width ="300px" 
                                                        Text='<%# Bind("Status_Expires") %>' />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                 H4 Tracking No
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="txth4trackno" runat="server"  width ="300px" 
                                                        Text='<%# Bind("H4TrackNumber") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                 H4 SigPages Sent?
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="txtH4sigpagessent" runat="server"  width ="300px" 
                                                        Text='<%# Bind("H4_SigPages") %>' />
                                                  
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                 Location of Case
                                                </td>
                                                <td>
                                                   <asp:DropDownList ID="txtlocation" runat="server"  width ="300px" 
                                                        Text='<%# Bind("location") %>' DataSourceID="SqlDataSource2" DataTextField="User_Display_Name" DataValueField="User_ID"
                                                        AppendDataBoundItems="true" >
                                                      <%-- <asp:ListItem Selected="True" Value='0'>Select User</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                           
                                             <tr>
                                                <td>
                                                   Assigned To
                                                </td>
                                                 <td>
                                                    <asp:DropDownList ID="lstassigned" runat="server"  width ="300px" Text='<%# Bind("User_Id") %>'
                                                        DataSourceID="SqlDataSource2" DataTextField="User_Display_Name" DataValueField="User_ID"
                                                        AppendDataBoundItems="true"  >
                                                      <%--  <asp:ListItem Selected="True" Value='0'>Select User</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                Invoice
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="txtinvoice" runat="server"  width ="300px" 
                                                        Text='<%# Bind("Invoice") %>' />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    Status Of Petition
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstpetetion" runat="server"  width ="300px" 
                                                        AutoPostBack="True" Text='<%# Bind("PetetionStatus") %>'>
                                                         <asp:ListItem Selected="True">Shipped </asp:ListItem>
                                                        <asp:ListItem>Receipted</asp:ListItem> 
                                                <asp:ListItem>Approval</asp:ListItem> 
                                <asp:ListItem>RFE</asp:ListItem> 
                                <asp:ListItem>Rejected</asp:ListItem>
                                <asp:ListItem>NOID</asp:ListItem> 
                                <asp:ListItem>NOIR</asp:ListItem>
                                                        <asp:ListItem>Withdrawn</asp:ListItem>
                                                        <asp:ListItem>Denied</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    Team #
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstteam" runat="server"  width ="300px" 
                                                        AutoPostBack="True" Text='<%# Bind("Team") %>'>
                                                        <asp:ListItem Selected="True">Team 1 </asp:ListItem>
                                                        <asp:ListItem>Team 2</asp:ListItem> 
                                                <asp:ListItem>Team 3</asp:ListItem> 
                                <asp:ListItem>Team 4</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                              <tr>
                                                <td>
                                                Contractual Session
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="txtcontractualsession" runat="server"  width ="300px" 
                                                        Text='<%# Bind("Contractualseesion") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                H1-B Pending Documents
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="txth1pendingdocs" runat="server" textmode="Multiline" width ="300px" 
                                                        Text='<%# Bind("Pending_documents") %>' />
                                                </td>
                                            </tr>
                                                <tr>
                                                <td>
                                               Fedex Tracking#
                                                <td>
                                                   <asp:TextBox ID="txtfedextrack" runat="server"  width ="300px" 
                                                        Text='<%# Bind("FedexTracking") %>' />
                                                </td>
                                            </tr>
                                               <tr>
                                                <td>
                                               Fedex Date Shipped
                                                <td>
                                                   <asp:TextBox ID="txtfedexdtshipped" runat="server"  width ="300px" 
                                                        Text='<%# Bind("Fedex_DateShipped") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                               Fedex ShippedBy
                                                <td>
                                                  
                                                    <asp:DropDownList ID="ddfedexshippedby" runat="server" Text='<%# Bind("Fedex_ShippedBy") %>'  width ="300px" 
                                                        DataSourceID="SqlDataSource2" DataTextField="User_Display_Name" DataValueField="User_ID" AutoPostBack="true"
                                                        AppendDataBoundItems="true"  >
                                                      <%-- <asp:ListItem Selected="True" Value='0'>Select User</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                              Last Updated
                                                <td>
                                                   <asp:TextBox ID="txtlstupdated" runat="server"  width ="300px" 
                                                        Text='<%# Bind("Last_Updated") %>' ForeColor="Black" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                         Paid
                                                <td>
                                                  
                                                    <asp:RadioButtonList ID="rlstpaid" runat="server" RepeatDirection="Horizontal"  width ="300px"  Text='<%# Bind("Paid") %>' >
                
                <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                        Notes
                                                <td>
                                                   <asp:TextBox ID="txtnotes" runat="server"  width ="300px"  textmode="MultiLine"
                                                        Text='<%# Bind("Notes") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                                        Text="Update" OnDataBound="btnchange" />
                                                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                                                        CommandName="Cancel" Text="Cancel" />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </EditItemTemplate>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <ItemTemplate>
                                        <table bgcolor="White" border="1" class="style2">
                                            <tr>
                                                <th align="left" colspan="2">
                                                    NIV
                                                </th>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton01" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Text="Edit" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="LinkButtonDelete" runat="server" CausesValidation="True" 
                                                        CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');"
                                                        Text="Delete"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Tracking ID
                                                </td>
                                                <td>
                                                    <asp:Label ID="TrackingNoLabel" runat="server"  width ="300px"  Text='<%# Bind("RLTrackingNumber") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Company
                                                </td>
                                                <td>
                                                    <asp:Label ID="CompanyLabel" runat="server"   width ="300px" Text='<%# Bind("Legal_name") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                   Date Initiated
                                                </td>
                                                <td>
                                                    <asp:Label ID="dtinitiatedLabel" runat="server"  width ="300px" Text='<%# Bind("Date_Initiated") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    LCA Tracking No
                                                </td>
                                                <td>
                                                    <asp:Label ID="lcatracknoLabel" runat="server"  width ="300px" Text='<%# Bind("LCATrackNumber") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    LCA Filed
                                                </td>
                                                <td>
                                                    <asp:Label ID="lcafiledLabel" runat="server"  width ="300px" Text='<%# Bind("LCAfiled") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Due Date
                                                </td>
                                               <td>
                                                    <asp:Label ID="duedtLabel" runat="server"  width ="300px" Text='<%# Bind("DueDate") %>' />
                                                </td>
                                            </tr>
                                            <td class="style3">
                                                   Current Status
                                                </td>
                                                <td>
                                                    <asp:Label ID="currentstatusLabel" runat="server"  width ="300px" Text='<%# Bind("Current_Status") %>' />
                                                    <%--<asp:DropDownList ID="lstcurrentstatuslbl" Text='<%# Bind("Current_Status") %>' runat="server"
                                                        AutoPostBack="True" AppendDataBoundItems="true" 
                                                        Height="20px"  width ="350px">
                                                        <asp:ListItem Selected="True" Value=''>-- Select Current status</asp:ListItem>
                                                    <asp:ListItem Value='H-1B '>H-1B </asp:ListItem>
                                                    <asp:ListItem Value='H-4 '>H-4 </asp:ListItem>
                                                    <asp:ListItem Value='L-1'>L-1</asp:ListItem>
                                                    <asp:ListItem Value='TN'>TN</asp:ListItem>
                                                    <asp:ListItem Value='E-3'>E-3</asp:ListItem>
                                                    <asp:ListItem Value='F-1'>F-1</asp:ListItem>
                                                    <asp:ListItem Value='B-1/B-2'>B-1/B-2</asp:ListItem>
                                                     <asp:ListItem Value='Out of the Country'>Out of the Country</asp:ListItem>
                                                    <asp:ListItem Value='Other'>Other</asp:ListItem>
                                                    </asp:DropDownList>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Case Type
                                                </td>
                                                 <td>
                                                      <%--<asp:Label ID="lstCasetypelbl" runat="server" Text='<%# Bind("Case_Type") %>' />--%>
                                                    <asp:DropDownList ID="lstCasetypelbl" runat="server"  width ="300px" Text='<%# Bind("Case_Type") %>' 
                                                        DataSourceID="SqlDataSource4" DataTextField="Visa_Type_Name" DataValueField="Visa_Type_Id"
                                                        AppendDataBoundItems="true"  Enabled="false">
                                                  
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="style3">
                                                    Draft Status
                                                </td>
                                                 <td>
                                                      <asp:Label ID="draftstatusLabel" runat="server"  width ="300px" Text='<%# Bind("DraftStatus") %>' />
                                                  <%--  <asp:DropDownList ID="lstDraftstatuslbl" runat="server" Text='<%# Bind("DraftStatus") %>'
                                                        AppendDataBoundItems="true" Height="20px"  width ="350px" Enabled="false">
                                                        <asp:ListItem Selected="True" Value=''>-- Select Case status</asp:ListItem>
                                                    <asp:ListItem Value='Final Review'>Final Review</asp:ListItem>
                                                    <asp:ListItem Value='Reduced Review'>Reduced Review</asp:ListItem>
                                                    <asp:ListItem Value='Forms'>Forms</asp:ListItem>
                                                    <asp:ListItem Value='Hold'>Hold</asp:ListItem>
                                                    <asp:ListItem Value='Drafted'>Drafted</asp:ListItem>
                                                    <asp:ListItem Value='1stReview'>1stReview</asp:ListItem>
                                                    <asp:ListItem Value='RFE'>RFE</asp:ListItem>
                                                    </asp:DropDownList>--%>
                                                </td>
                                            </tr>
                                            <asp:Panel id="rfehidden"  width ="300px" runat="server">
                                            <tr>
                                                <td class="style3">
                                                    RFE Type
                                                </td>
                                                <td>
                                                  <asp:Label ID="rfetypeLabel" runat="server"   width ="300px" Text='<%# Bind("RFE_Type") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                   Date Received
                                                </td>
                                                <td>
                                                    <asp:Label ID="rfedtreceivedLabel" runat="server"  width ="300px" Text='<%# Bind("RFEDateReceive") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Date R4D sent
                                                </td>
                                                <td>
                                                    <asp:Label ID="r4dsentlabel" runat="server"   width ="300px" Text='<%# Bind("Date_R4D_Sent") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    USCIS Due Date
                                                </td>
                                                <td>
                                                    <asp:Label ID="rfeuscisdtLabel" runat="server"   width ="300px" Text='<%# Bind("RFE_Uscis_DueDate") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Internal DueDate
                                                </td>
                                                <td>
                                                    <asp:Label ID="internalduedtLabel" runat="server"   width ="300px" Text='<%# Bind("RFE_Internal_Due_Date") %>'></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="style3">
                                                    LastShip Date
                                                </td>
                                                <td>
                                                    <asp:Label ID="lastshipdtLabel" runat="server"   width ="300px" Text='<%# Bind("RFE_LastShip_Date") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <%-- <tr>
                                                <td class="style3" >
                                                    Type of RFE
                                                </td>
                                                <td>
                                                    <asp:Label ID="typeofrfeLabel" runat="server"  width ="100px" Text='<%# Bind("Type_Of_RFE") %>'></asp:Label>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td class="style3">
                                                    Eval Filed
                                                </td>
                                                <td>
                                                     <asp:Label ID="evalLabel" runat="server"   width ="300px" Text='<%# Bind("RFE_Evaluation_Filed") %>'></asp:Label>
                                                    <%--<asp:DropDownList ID="lstevalfiledlbl" runat="server" 
                                                        AutoPostBack="True" Text='<%# Bind("RFE_Evaluation_Filed") %>'>
                                                        <asp:ListItem Selected="True">Standard Evaluation </asp:ListItem>
                                                        <asp:ListItem>Academic & Experience Evaluation </asp:ListItem> 
                                                <asp:ListItem>Expert Opinion Letter </asp:ListItem> 
                                <asp:ListItem>On File</asp:ListItem> 
                                <asp:ListItem>N/A</asp:ListItem> 
                                                    </asp:DropDownList>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                   Missing Docs
                                                </td>
                                                <td>
                                                    <asp:Label ID="rfemissidngdocsLabel" runat="server"   width ="300px" Enabled="false" 
                                                        Text='<%# Bind("RFE_Missing_Docs") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                   Drafted
                                                </td>
                                                <td>
                                                     <asp:Label ID="rfedraftedLabel" runat="server"  width ="300px"  Text='<%# Bind("RFE_Drafted") %>' />
                                                  <%--  <asp:DropDownList ID="lstrfedraftedlbl" runat="server" Enabled="false" Text='<%# Bind("RFE_Drafted") %>'>
                                                        <asp:ListItem Selected="True">yes</asp:ListItem>
                                                        <asp:ListItem>no</asp:ListItem>
                                                    </asp:DropDownList>--%>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="style3">
                                                  Status
                                                </td>
                                                <td>
                                                    <asp:Label ID="lstrfestatusLabel" runat="server"   width ="300px" Enabled="false"
                                                        Text='<%# Bind("RFE_Status") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                  Last Updated
                                                </td>
                                                <td>
                                                   <asp:Label ID="rfelastupdatedLabel" runat="server"   width ="300px" Enabled="false"
                                                        Text='<%# Bind("RFE_LastUpdated") %>' />
                                                </td>
                                            </tr>
                                                </asp:Panel >
                                           <tr>
                                                <td class="style3">
                                                   Sig Pages
                                                </td>
                                                <td>
                                                      <asp:Label ID="sigpagesLabel" runat="server"   width ="300px" Text='<%# Bind("SigPages") %>' />
                                                   <%-- <asp:DropDownList ID="lstsigpageslbl" runat="server" Enabled="false" Text='<%# Bind("SigPages") %>'>
                                                             <asp:ListItem Selected="True" Value='Received'>Received</asp:ListItem>
                                                <asp:ListItem Value='sent'>sent</asp:ListItem>
                                                    </asp:DropDownList>--%>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="style3">
                                                  Checks
                                                </td>
                                                <td>
                                                     <asp:Label ID="checkLabel" runat="server"   width ="300px" Text='<%# Bind("Check") %>' />
                                                   <%-- <asp:DropDownList ID="lstcheckslbl" runat="server" Enabled="false" Text='<%# Bind("Check") %>'>
                                                              <asp:ListItem Selected="True" Value='Received'>Received</asp:ListItem>
                                                <asp:ListItem Value='sent'>sent</asp:ListItem>
                                                    </asp:DropDownList>--%>
                                                </td>
                                            </tr>
                                               <tr>
                                                <td class="style3">
                                                  Premium Processing?
                                                </td>
                                                <td>
                                                    <asp:Label ID="premiumprocessLabel" runat="server"  width ="300px"  Text='<%# Bind("Premium_Processing") %>' />
                                                    <%--<asp:DropDownList ID="lstpremiumprocesslbl" runat="server" Enabled="false" Text='<%# Bind("Premium_Processing") %>'>
                                                                 <asp:ListItem Selected="True">yes</asp:ListItem>
                                                        <asp:ListItem>no</asp:ListItem> 
                                                    </asp:DropDownList>--%>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="style3">
                                                  Status Expires
                                                </td>
                                                <td>
                                                   <asp:Label ID="statusexpiresLabel" runat="server"  width ="300px"  Enabled="false"
                                                        Text='<%# Bind("Status_Expires") %>' />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="style3">
                                                 H4 Tracking No
                                                </td>
                                                <td>
                                                   <asp:Label ID="h4tracknoLabel" runat="server"   width ="300px" Enabled="false"
                                                        Text='<%# Bind("H4TrackNumber") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                 H4 SigPages Sent?
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="H4sigpagessentLabel" runat="server"   width ="300px" Enabled="false"
                                                        Text='<%# Bind("H4_SigPages") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                 Location of Case
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="locationLabel" runat="server" Text='<%# Bind("location") %>'
                                                        DataSourceID="SqlDataSource2" DataTextField="User_Display_Name" DataValueField="User_ID"
                                                        AppendDataBoundItems="true" Height="20px"  width ="300px"  Enabled="false">
                                                       
                                                    </asp:DropDownList>
                                                   
                                                </td>
                                            </tr>
                                           
                                             <tr>
                                                <td class="style3">
                                                   Assigned To
                                                </td>
                                                 <td>
                                                    <asp:DropDownList ID="lstassignedlbl" runat="server" Text='<%# Bind("User_Id") %>'
                                                        DataSourceID="SqlDataSource2" DataTextField="User_Display_Name" DataValueField="User_ID"
                                                        AppendDataBoundItems="true" Height="20px"  width ="300px"  Enabled="false">
                                                        <asp:ListItem Selected="True" Value='0'>Select User</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                Invoice
                                                </td>
                                                <td>
                                                   <asp:Label ID="invoiceLabel" runat="server"  Enabled="false"  width ="300px" 
                                                        Text='<%# Bind("Invoice") %>' />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="style3">
                                                    Status Of Petetion
                                                </td>
                                                <td>
                                                    <asp:Label ID="statuspetetionLabel" runat="server"  Enabled="false"  width ="300px" 
                                                        Text='<%# Bind("PetetionStatus") %>' />
                                                   <%-- <asp:DropDownList ID="lstpetetionlbl" runat="server" 
                                                        AutoPostBack="True" Text='<%# Bind("PetetionStatus") %>'>
                                                         <asp:ListItem Selected="True">Shipped </asp:ListItem>
                                                        <asp:ListItem>Receipted</asp:ListItem> 
                                                <asp:ListItem>Approval</asp:ListItem> 
                                <asp:ListItem>RFE</asp:ListItem> 
                                <asp:ListItem>Rejected</asp:ListItem>
                                <asp:ListItem>NOID</asp:ListItem> 
                                <asp:ListItem>NOIR</asp:ListItem>
                                                        <asp:ListItem>Withdrawn</asp:ListItem>
                                                    </asp:DropDownList>--%>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="style3">
                                                    Team #
                                                </td>
                                                <td>
                                                    <asp:Label ID="teamLabel" runat="server"  Enabled="false"  width ="300px" 
                                                        Text='<%# Bind("Team") %>' />
                                                   <%-- <asp:DropDownList ID="lstteamlbl" runat="server" 
                                                        AutoPostBack="True" Text='<%# Bind("Team") %>'>
                                                        <asp:ListItem Selected="True">Team 1 </asp:ListItem>
                                                        <asp:ListItem>Team 2</asp:ListItem> 
                                                <asp:ListItem>Team 3</asp:ListItem> 
                                <asp:ListItem>Team 4</asp:ListItem>
                                                    </asp:DropDownList>--%>
                                                </td>
                                            </tr>
                                              <tr>
                                                <td class="style3">
                                                Contractual Session
                                                </td>
                                                <td>
                                                   <asp:Label ID="contractualsessionLabel" runat="server"  Enabled="false"  width ="300px" 
                                                        Text='<%# Bind("Contractualseesion") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                H1-B Pending Documents
                                                </td>
                                                <td>
                                                   <asp:Label ID="h1pendingdocsLabel" runat="server"  Enabled="false"  width ="300px" 
                                                        Text='<%# Bind("Pending_documents") %>' />
                                                </td>
                                            </tr>
                                                <tr>
                                                <td class="style3">
                                               Fedex Tracking#
                                                <td>
                                                   <asp:Label ID="fedextrackLabel" runat="server"  Enabled="false"  width ="300px" 
                                                        Text='<%# Bind("FedexTracking") %>' />
                                                </td>
                                            </tr>
                                               <tr>
                                                <td class="style3">
                                               Fedex Date Shipped
                                                <td>
                                                      
                                                   <asp:Label ID="fedexdtshippedLabel" runat="server"  Enabled="false"  width ="300px" 
                                                        Text='<%# Bind("Fedex_DateShipped") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                               Fedex ShippedBy
                                                <td>
                                                     <asp:DropDownList ID="fedexshippedbyLabel" runat="server"  width ="300px"  Text='<%# Bind("Fedex_ShippedBy") %>'
                                                        DataSourceID="SqlDataSource2" DataTextField="User_Display_Name" DataValueField="User_ID"
                                                        AppendDataBoundItems="true" Height="20px" Enabled="false">
                                                       
                                                    </asp:DropDownList>
                                                   <%-- <asp:Label ID="fedexshippedbyLabel" runat="server"  width ="100px" Enabled="false"
                                                        Text='<%# Bind("Fedex_ShippedBy") %>' />--%>
                                                  
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                              Last Updated
                                                <td>
                                                   <asp:Label ID="lstupdatedLabel" runat="server"  Enabled="false"   width ="300px" 
                                                        Text='<%#  Bind("Last_Updated") %>' ForeColor="Black" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                         Paid
                                                <td>
                                                   <asp:Label ID="paidLabel" runat="server"  Enabled="false"  width ="300px" 
                                                        Text='<%# Bind("Paid") %>' />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="style3">
                                        Notes
                                                <td>
                                                   <asp:Label ID="notesLabel" runat="server"  Enabled="false"  width ="300px" 
                                                        Text='<%# Bind("Notes") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Text="Edit" />
                                                    &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                                                        Text="Delete" Visible="false" />
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </ItemTemplate>
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                </asp:FormView>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="footer">
            <a href="http://www.raminenilaw.com/?page_id=258"></a><a href="http://www.raminenilaw.com/?page_id=258">
                Contact Us</a> | <a href="legal_notices.html">Legal Notice </a>
            <br />
            &copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
    </div>
    </form>
    <script type="text/javascript">
   
                Calendar.setup({
                    inputField: FormView1_txtlstupdated,     // id of the input field
                    ifFormat: "%m/%d/%Y",      // format of the input field
                    button: FormView1_txtlstupdated,  // trigger for the calendar (button ID)
                    align: "Br",           // alignment (defaults to "Bl")
                    singleClick: true
                });
  </script>
      <script type="text/javascript">
                Calendar.setup({
                    inputField:FormView1_txtfedexdtshipped,     // id of the input field
                    ifFormat: "%m/%d/%Y",      // format of the input field
                    button: FormView1_txtfedexdtshipped,  // trigger for the calendar (button ID)
                    align: "Br",           // alignment (defaults to "Bl")
                    singleClick: true
                });
          
                if (document.getElementById("FormView1_rfehidden1").style.visibility != "hidden") {
             
                    Calendar.setup({
                        inputField: FormView1_txtrfedtreceived,     // id of the input field
                        ifFormat: "%m/%d/%Y",      // format of the input field
                        button: FormView1_txtrfedtreceived,  // trigger for the calendar (button ID)
                        align: "Br",           // alignment (defaults to "Bl")
                        singleClick: true
                    });
                }
                if (document.getElementById("FormView1_rfehidden1").style.visibility != "hidden") {
                    Calendar.setup({
                        inputField: FormView1_txtr4dsent,     // id of the input field
                        ifFormat: "%m/%d/%Y",      // format of the input field
                        button: FormView1_txtr4dsent,  // trigger for the calendar (button ID)
                        align: "Br",           // alignment (defaults to "Bl")
                        singleClick: true
                    });
                }
                if (document.getElementById("FormView1_rfehidden1").style.visibility != "hidden") {
                    Calendar.setup({
                        inputField: FormView1_txtrfeuscisdt,     // id of the input field
                        ifFormat: "%m/%d/%Y",      // format of the input field
                        button: FormView1_txtrfeuscisdt,  // trigger for the calendar (button ID)
                        align: "Br",           // alignment (defaults to "Bl")
                        singleClick: true
                    });
                }

                        if (document.getElementById("FormView1_rfehidden1").style.visibility != "hidden") {
                            Calendar.setup({
                                inputField: FormView1_txtrfelastupdated,     // id of the input field
                                ifFormat: "%m/%d/%Y",      // format of the input field
                                button: FormView1_txtrfelastupdated,  // trigger for the calendar (button ID)
                                align: "Br",           // alignment (defaults to "Bl")
                                singleClick: true
                            });

            }
            
</script>
    <script src="../scripts/content.js" type="text/javascript"></script>
</body>
</html>

