<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditI-485.aspx.cs" Inherits="WebFormCast.attorney.EditI_485" %>
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
                                                    <asp:DropDownList ID="ddCompany" runat="server" DataSourceID="SqlDataSource8" DataTextField="Legal_Name"
                                                        DataValueField="CompanyID" Style="width: 200px" AppendDataBoundItems="True" EnableViewState="true"
                                                        AutoPostBack="true" OnSelectedIndexChanged="ddCompany_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value='All'>All</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                              <td>
                                                    &nbsp;&nbsp;<asp:Label ID="casestatus" runat="server" Text="CaseStatus"/>
                                                    
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstcasestatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstcasestatus_SelectedIndexChanged">
                                                           <asp:ListItem Selected="True" Value=''>-- Select Case status---</asp:ListItem>
                                                        <asp:ListItem >Pending </asp:ListItem>
                                                        <asp:ListItem>Approved</asp:ListItem> 
                                                <asp:ListItem>RFE</asp:ListItem> 
                                                         </asp:DropDownList>
                                                </td>
     
                                            </tr>
                                            <tr>
                                                <td>
                                                    Draft Status
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="lstdraftstatus" runat="server" Style="width: 200px" EnableViewState="true"
                                                      AutoPostBack="true" OnSelectedIndexChanged="lstdraftstatus_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value=''>-- Select Drfat status---</asp:ListItem>
                                                    <asp:ListItem >Drafted</asp:ListItem>
                                                      <asp:ListItem >First Review</asp:ListItem>
                                                    <asp:ListItem >Final Review</asp:ListItem>
                                                    <asp:ListItem >WithClient</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tracking ID
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTrackingNo" runat="server" Width="160px"></asp:TextBox>
                                                </td>
                                                
                                                <td>
                                                   <asp:Button ID="I485Search" runat="server" CausesValidation="false" Text="&nbsp;Find&nbsp;I-485&nbsp;" OnClick="I485Search_Click"  />
                                                </td>
                                                <td>
                                                    <asp:Button ID="reset" runat="server" CausesValidation="false" Text="&nbsp;Reset&nbsp;" OnClick="reset_Click1"
                                                        />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="2">
                                        <img src="../images/topbar_sub_rgt.gif" width="2" height="78" />
                                    </td>
                                </tr>
                                <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ connectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [Legal_Name], [CompanyID] FROM [Company] WHERE ([Legal_Name] <> '') ORDER BY Legal_Name">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB%>"
                                    SelectCommand="SELECT * FROM [I485tracking] ORDER BY RLTrackingNumber"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB %>"
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
                    Edit NIV</div>
                <div class="bcru">
                    <a href="I-485.aspx">I-485</a> » Edit</div>
                <div id="whiteArea">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ connectionStrings:ACLG_DB %>"
                        DeleteCommand="DELETE FROM [I485tracking] WHERE [ID] = @ID" 
                        SelectCommand="SELECT I485tracking.*, Company.* FROM [I485tracking], Company where CompanyID = Company and [ID] =@ID"
                          UpdateCommand="UPDATE [dbo].[I485tracking] SET[DateInitiated] = @DateInitiated,[PriorityDate] = @PriorityDate,[CountryofBirth] = @CountryofBirth,[InternalDueDate] = @InternalDueDate,[DraftStatus] = @DraftStatus,[Draftsent] = @Draftsent,[SigPagesReceived] = @SigPagesReceived,[BioAppointment] = @BioAppointment,[CaseStatus] = @CaseStatus,[CaseFiled] = @CaseFiled,[Invoice] = @Invoice,[Last_Updated] = @Last_Updated,[Paid] = @Paid,[RFE_Type] = @RFE_Type,[RFEDateReceive] = @RFEDateReceive,[Date_R4D_Sent] = @Date_R4D_Sent,[RFE_Internal_Due_Date] = @RFE_Internal_Due_Date,[RFE_LastShip_Date] = @RFE_LastShip_Date,[RFE_Uscis_DueDate] = @RFE_Uscis_DueDate,[RFE_Missing_Docs] = @RFE_Missing_Docs,[RFE_Drafted] = @RFE_Drafted,[RFE_Status] = @RFE_Status,[RFE_LastUpdated] = @RFE_LastUpdated,[Notes] = @Notes,[DependentTrackno] = @DependentTrackno WHERE [ID] = @ID"
                        OnUpdated="OnDSUpdatedHandler">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ID" QueryStringField="I485ID" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="DateInitiated" Type="DateTime" />
                            <asp:Parameter Name="PriorityDate" Type="DateTime" />
                               <asp:Parameter Name="CountryofBirth" Type="String" />
                            <asp:Parameter Name="InternalDueDate" Type="DateTime" />
                            <asp:Parameter Name="DraftStatus" Type="String" />
                            <asp:Parameter Name="Draftsent" Type="String" />
                            <asp:Parameter Name="SigPagesReceived" Type="String" />
                            <asp:Parameter Name="BioAppointment" Type="String" />
                            <asp:Parameter Name="CaseStatus" Type="String" />
                            <asp:Parameter Name="CaseFiled" Type="DateTime" />
                            <asp:Parameter Name="Invoice" Type="String" />
                            <asp:Parameter Name="Last_Updated" Type="DateTime" />
                            <asp:Parameter Name="Paid" Type="String" />
                            <asp:Parameter Name="RFE_Type" Type="String" />
                            <asp:Parameter Name="RFEDateReceive" Type="DateTime" />
                            <asp:Parameter Name="Date_R4D_Sent" Type="DateTime" />
                            <asp:Parameter Name="RFE_Internal_Due_Date" Type="DateTime" />
                            <asp:Parameter Name="RFE_LastShip_Date" Type="DateTime" />
                            <asp:Parameter Name="RFE_Uscis_DueDate" Type="DateTime" />
                            <asp:Parameter Name="RFE_Missing_Docs" Type="String" />
                            <asp:Parameter Name="RFE_Drafted" Type="String" />
                            <asp:Parameter Name="RFE_Status" Type="String" />
                            <asp:Parameter Name="RFE_LastUpdated" Type="DateTime" />
                            <asp:Parameter Name="Notes" Type="String" />
                            <asp:Parameter Name="DependentTrackno" Type="String" />
                            <asp:Parameter Name="ID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                  
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ connectionStrings:ACLG_DB %>"
                                    SelectCommand="SELECT DISTINCT [Legal_Name], [CompanyID] FROM [Company] WHERE ([Legal_Name] <> '') ORDER BY Legal_Name">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:ACLG_DB%>"
                                    SelectCommand="SELECT * FROM [I485tracking] ORDER BY NIVTrackingNumber"></asp:SqlDataSource>
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
                                                   I-485
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
                                                    <asp:TextBox ID="DateinitiatedTextBox" runat="server"  width ="300px" Text='<%# Bind("DateInitiated") %>'
                                                        ReadOnly="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Priority Date
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="PrioritydateTextBox" runat="server"  width ="300px"  Text='<%# Bind("PriorityDate") %>'  OnTextChanged="ltxtpripritydt_Leave" AutoPostBack="true"
                                                        />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Country Of Birth
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="countryofbirthTextBox" runat="server"   width ="300px" Text='<%# Bind("CountryofBirth") %>'
                                                         />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Internal Due Date
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="internalduedtTextBox" runat="server"  width ="300px"  Text='<%# Bind("InternalDueDate") %>'  ReadOnly="true"  />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   Draft Status
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="draftstatustext" Text='<%# Bind("DraftStatus") %>' runat="server"  AutoPostBack="true"
                                                      Height="20px"  width ="300px" 
                                                        >
                                                     <%-- <asp:ListItem >Select Draft status</asp:ListItem>--%>
                                                    <asp:ListItem >Drafted</asp:ListItem>
                                                      <asp:ListItem >First Review</asp:ListItem>
                                                    <asp:ListItem >Final Review</asp:ListItem>
                                                    <asp:ListItem >WithClient</asp:ListItem>
                                                </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Draft Sent To Client
                                                </td>
                                               <td>
                                                     <asp:TextBox ID="draftsentTextBox" runat="server"  width ="300px"  Text='<%# Bind("Draftsent") %>'  />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    Sig Pages
                                                </td>
                                                 <td>
                                                    <asp:DropDownList ID="lstsigpages" runat="server" Text='<%# Bind("SigPagesReceived") %>'
                                                        AppendDataBoundItems="true" Height="20px"  width ="300px" AutoPostBack="true" >
                                                         <asp:ListItem Selected="True" Value='Yes'>Yes</asp:ListItem>
                                                    <asp:ListItem Value='NO'>NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    Dependent Tracking Number
                                                </td>
                                               <td>
                                                     <asp:TextBox ID="dependenttracknoTextBox" runat="server"  width ="300px"  Text='<%# Bind("DependentTrackno") %>'  />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    Received Biometric Appointment
                                                </td>
                                                 <td>
                                                    <asp:DropDownList ID="lstbipappointment" runat="server" Text='<%# Bind("BioAppointment") %>'
                                                        AppendDataBoundItems="true" Height="20px"  width ="300px" AutoPostBack="true" >
                                                        <asp:ListItem Selected="True" Value='Yes'>Yes</asp:ListItem>
                                                    <asp:ListItem Value='NO'>NO</asp:ListItem>
                                                     <asp:ListItem Value='N/A'>N/A</asp:ListItem>
                                                        </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Case Status
                                                </td>
                                                 <td>
                                                    <asp:DropDownList ID="casestatustext" runat="server" Text='<%# Bind("CaseStatus") %>'
                                                      Height="20px"  width ="300px" AutoPostBack="true"  OnSelectedIndexChanged="casestatustext_SelectedIndexChanged" >
                                                       <%--<asp:ListItem Selected="True" Value='0'>Select Case status</asp:ListItem>--%>
                                                    <asp:ListItem Value='Pending '>Pending</asp:ListItem>
                                                    <asp:ListItem Value='Approved'>Approved</asp:ListItem>
                                                    <asp:ListItem Value='RFE'>RFE</asp:ListItem>
                                                        </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <asp:Panel id="rfehidden1" runat="server"  width ="300px"  Visible="false">
                                            <tr>
                                                <td>
                                                    RFE Type
                                                </td>
                                                <td>
                                                               <asp:DropDownList ID="lstrfetype" runat="server" Text='<%# Bind("RFE_Type") %>' 
                                                     Height="20px"  width ="300px"  AutoPostBack="true">
                                                               <%--<asp:ListItem Selected="True" Value='0'>Select Case status</asp:ListItem>--%>
                                                    <asp:ListItem>Mainteance of Status</asp:ListItem>
                                                    <asp:ListItem>Medicals</asp:ListItem>
                                                    <asp:ListItem >Employment Letter</asp:ListItem>
                                                    <asp:ListItem >Other</asp:ListItem>
                                                   
                                                               </asp:DropDownList>
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
                                                    <asp:TextBox ID="txtrfeuscisdt" runat="server"  width ="300px"  AutoPostBack="true" Text='<%# Bind("RFE_Uscis_DueDate") %>'  OnTextChanged="txtrfeuscisdt__Leave" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    Internal DueDate
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtinternalduedt" runat="server"  width ="300px"  Text='<%# Bind("RFE_Internal_Due_Date") %>' ReadOnly="true" ></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="style1">
                                                    LastShip Date
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtlastshipdt" runat="server"  width ="300px"   Text='<%# Bind("RFE_LastShip_Date") %>' ></asp:TextBox>
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
                                                    <asp:DropDownList ID="lstrfedrafted" runat="server"  Text='<%# Bind("RFE_Drafted") %>'  width ="300px" AppendDataBoundItems="true">
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
                                                  <asp:DropDownList ID="ddrfestatus" runat="server"  Height="16px" Text='<%# Bind("RFE_Status") %>' AutoPostBack="true" >
                                                  <%-- <asp:ListItem Selected="True" Value='0'>Select Draft status</asp:ListItem>--%>
                                                                                                      <asp:ListItem >Drafted</asp:ListItem>
                                                      <asp:ListItem >First Review</asp:ListItem>
                                                    <asp:ListItem >Final Review</asp:ListItem>
                                                    <asp:ListItem >WithClient</asp:ListItem>
                                               
                                                </asp:DropDownList>
                                                         
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
                                             CaseFiled
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="txtdtcasefiled" runat="server"  width ="300px" 
                                                        Text='<%# Bind("CaseFiled") %>' />
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
                                                    I-485
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
                                                    <asp:Label ID="dtinitiatedLabel" runat="server"  width ="300px" Text='<%# Bind("DateInitiated") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                   Priority Date
                                                </td>
                                                <td>
                                                    <asp:Label ID="prioritydtLabel" runat="server"  width ="300px" Text='<%# Bind("PriorityDate") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                    Country of Birth
                                                </td>
                                                <td>
                                                    <asp:Label ID="countryofbirthLabel" runat="server"  width ="300px" Text='<%# Bind("CountryofBirth") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">
                                                   Internal Due Date
                                                </td>
                                               <td>
                                                    <asp:Label ID="internalduedtLabel" runat="server"  width ="300px" Text='<%# Bind("InternalDueDate") %>' />
                                                </td>
                                            </tr>
                                            <td class="style3">
                                                   Draft Status
                                                </td>
                                                <td>
                                                    <asp:Label ID="draftstatusLabel" runat="server"  width ="300px" Text='<%# Bind("DraftStatus") %>' />
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
                                             Drafts Sent To Clinet
                                                </td>
                                                 <td>
                                                      <asp:Label ID="draftssentlbl" runat="server" Text='<%# Bind("Draftsent") %>' />
                                                   <%-- <asp:DropDownList ID="lstCasetypelbl" runat="server"  width ="300px" Text='<%# Bind("Case_Type") %>' 
                                                        DataSourceID="SqlDataSource4" DataTextField="Visa_Type_Name" DataValueField="Visa_Type_Id"
                                                        AppendDataBoundItems="true"  Enabled="false">
                                                   <%--     <%--<asp:ListItem Selected="True" Value='0'>Select CaseType</asp:ListItem>--%>
                                                    <%--</asp:DropDownList>--%>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="style3">
                                                    SigPages
                                                </td>
                                                 <td>
                                                      <asp:Label ID="sigpagesLabel" runat="server"  width ="300px" Text='<%# Bind("SigPagesReceived") %>' />
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
                                            <tr>
                                                <td class="style3">
                                                    Dependent Tracking Number
                                                </td>
                                                <td>
                                                    <asp:Label ID="dependenttrackLabel" runat="server"  width ="300px" Text='<%# Bind("DependentTrackno") %>' />
                                                </td>
                                            </tr>
                                              <tr>
                                                <td class="style3">Received Biometric Appointment
                                                </td>
                                                <td>
                                                    <asp:Label ID="bioappointmentLabel" runat="server"  width ="300px" Text='<%# Bind("BioAppointment") %>' />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="style3">
                                                   Case Status
                                                </td>
                                                <td>
                                                    <asp:Label ID="casestatusLabel" runat="server"  width ="300px" Text='<%# Bind("CaseStatus") %>' />
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
                                                    <asp:Label ID="rfeinternalduedtLabel" runat="server"   width ="300px" Text='<%# Bind("RFE_Internal_Due_Date") %>'></asp:Label>
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
                                                 Date CaseFiled
                                                </td>
                                                <td>
                                                      <asp:Label ID="dtcasefiledLabel" runat="server"   width ="300px" Text='<%# Bind("CaseFiled") %>' />
                                                   <%-- <asp:DropDownList ID="lstsigpageslbl" runat="server" Enabled="false" Text='<%# Bind("SigPages") %>'>
                                                             <asp:ListItem Selected="True" Value='Received'>Received</asp:ListItem>
                                                <asp:ListItem Value='sent'>sent</asp:ListItem>
                                                    </asp:DropDownList>--%>
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
                    inputField: FormView1_DateinitiatedTextBox,     // id of the input field
                    ifFormat: "%m/%d/%Y",      // format of the input field
                    button: FormView1_DateinitiatedTextBox,  // trigger for the calendar (button ID)
                    align: "Br",           // alignment (defaults to "Bl")
                    singleClick: true
                });
                Calendar.setup({
                    inputField: FormView1_txtdtcasefiled,     // id of the input field
                    ifFormat: "%m/%d/%Y",      // format of the input field
                    button: FormView1_txtdtcasefiled,  // trigger for the calendar (button ID)
                    align: "Br",           // alignment (defaults to "Bl")
                    singleClick: true
                });
                Calendar.setup({
                    inputField: FormView1_PrioritydateTextBox,     // id of the input field
                    ifFormat: "%m/%d/%Y",      // format of the input field
                    button: FormView1_PrioritydateTextBox,  // trigger for the calendar (button ID)
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

