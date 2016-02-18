<%@ Page Language="C#" AutoEventWireup="true" Inherits="attorney_EditLCA" Codebehind="editLCA.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
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
      <li><a href="templates.aspx"><b>Templates</b></a></li>
      <li><a href="forms.aspx"><b>Forms</b></a></li>
      <li><a href="myaccount.aspx"><b>My Account</b></a></li>
      <li class="current"><a href="trackingSys.aspx"><b>Track. Sys.</b></a></li>
    </ul>
    </asp:Label>
    <div id="contentArea1">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg">&nbsp;</td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">Edit LCA</div>
      <div class="bcru"><a href="lca.aspx">LCA</a> &raquo; Edit LCA</div>
      <div id="whiteArea">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="center">
                    <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" 
                        DataSourceID="SqlDataSource1" 
                        style="text-align: left; font-family: Verdana; font-size: small;" Width="910px" 
                        CellPadding="4" ForeColor="#333333" 
                       >
                        <EditItemTemplate>
                            &nbsp;<table bgcolor="White" border="1" class="style2">
                                <tr>
                                    <td>Tracking ID</td>
                                    <td>
                                        <asp:TextBox ID="RLTrackingNumberTextBox" ReadOnly runat="server" 
                                            Text='<%# Bind("RLTrackingNumber") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Company</td>
                                    <td>
                                        <asp:TextBox ID="CompanyTextBox" runat="server"  ReadOnly Text='<%# Bind("Legal_name") %>' 
                                            Width="300px" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td>Beneficiary</td>
                                    <td>
                                        <asp:TextBox ID="BeneficiaryTextBox" runat="server" 
                                            Text='<%# Bind("Beneficiary") %>' ReadOnly Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>LCATrackNumber</td>
                                    <td>
                                        <asp:TextBox ID="LCATrackNumberTextBox"  runat="server" 
                                            Text='<%# Bind("LCATrackNumber") %>' Width="300px" />
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td>TypeofLCA</td>
                                    <td>
                                        <asp:DropDownList ID="TypeofLCATextBox" Text='<%# Bind("TypeofLCA") %>'  Width="300px" runat="server">
                                            <asp:ListItem Selected="True">New Not Subject to CAP</asp:ListItem>
                                            <asp:ListItem>New Cap Subject</asp:ListItem>
                                            <asp:ListItem>Transfer</asp:ListItem>
                                            <asp:ListItem>Amendment</asp:ListItem>                                          
                                            <asp:ListItem>Extension + Amendment</asp:ListItem>                                          
                                            <asp:ListItem>Extension</asp:ListItem>                                          
                                            <asp:ListItem>New</asp:ListItem>
                                            <asp:ListItem>Change of End Client</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Date Filed</td>
                                    <td>
                                        <asp:TextBox ID="DatefiledTextBox" runat="server" 
                                            Text='<%# Bind("Datefiled") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Date Approved</td>
                                    <td>
                                        <asp:TextBox ID="DateapprovedTextBox" runat="server" 
                                            Text='<%# Bind("Dateapproved") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Current Status</td>
                                    <td>
                                        <asp:DropDownList ID="CurrentStatusTextBox" runat="server" Text='<%# Bind("CurrentStatus") %>'>
                                         <asp:ListItem>Certified</asp:ListItem>
                                         <asp:ListItem>Denied</asp:ListItem>
                                         <asp:ListItem>Withdrawn</asp:ListItem>
                                         <asp:ListItem>Pending</asp:ListItem>
                                         <asp:ListItem>Re-filed</asp:ListItem>            
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Job Title</td>
                                    <td>
                                        <asp:TextBox ID="JobtitleTextBox" runat="server" Text='<%# Bind("Jobtitle") %>' 
                                            Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>LCA Location</td>
                                    <td>
                                        <asp:TextBox ID="LCAlocationTextBox" runat="server" 
                                            Text='<%# Bind("LCAlocation") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>County</td>
                                    <td>
                                        <asp:TextBox ID="CountyTextBox" runat="server" 
                                            Text='<%# Bind("County") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Emp.Start and End Dates</td>
                                    <td>
                                        <asp:TextBox ID="EmpStartEndTextBox" runat="server" 
                                            Text='<%# Bind("EmpStartEnd") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>SOC</td>
                                    <td>
                                        <asp:TextBox ID="SOCTextBox" runat="server" 
                                            Text='<%# Bind("SOC") %>' Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Salary</td>
                                    <td>
                                        <asp:TextBox ID="salaryandlevelTextBox" runat="server" 
                                            Text='<%# Bind("salaryandlevel") %>' Width="300px" />
                                    </td>
                                </tr>
                               <tr>
                                    <td>Level</td>
                                    <td>
                                        <asp:DropDownList ID="SalLevelDropDownList" runat="server" Text='<%# Bind("SalLevel") %>'>
                                         <asp:ListItem></asp:ListItem>
                                         <asp:ListItem>I</asp:ListItem>
                                         <asp:ListItem>II</asp:ListItem>
                                         <asp:ListItem>III</asp:ListItem>
                                         <asp:ListItem>IV</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Notes</td>
                                    <td>
                                        <asp:TextBox ID="notesTextbox" runat="server" 
                                            Text='<%# Bind("Notes") %>' Width="300px" /></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                                            CommandName="Update"  Text="Update"  OnDataBound="btnchange" />
                                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </EditItemTemplate>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <InsertItemTemplate>
                            RLTrackingNumber:
                            <asp:TextBox ID="RLTrackingNumberTextBox" runat="server" 
                                Text='<%# Bind("RLTrackingNumber") %>' />
                            <br />
                            Company:
                            <asp:TextBox ID="CompanyTextBox" runat="server" Text='<%# Bind("Legal_Name") %>' />
                            <br />
                            LCATrackNumber:
                            <asp:TextBox ID="LCATrackNumberTextBox" runat="server" 
                                Text='<%# Bind("LCATrackNumber") %>' />
                            <br />
                            Beneficiary:
                            <asp:TextBox ID="BeneficiaryTextBox" runat="server" 
                                Text='<%# Bind("Beneficiary") %>' />
                            <br />
                            TypeofLCA:
                            <asp:TextBox ID="TypeofLCATextBox" runat="server" 
                                Text='<%# Bind("TypeofLCA") %>' />
                            <br />
                            Datefiled:
                            <asp:TextBox ID="DatefiledTextBox" runat="server" 
                                Text='<%# Bind("Datefiled") %>' />
                            <br />
                            Dateapproved:
                            <asp:TextBox ID="DateapprovedTextBox" runat="server" 
                                Text='<%# Bind("Dateapproved") %>' />
                            <br />
                            CurrentStatus:
                            <asp:TextBox ID="CurrentStatusTextBox" runat="server" 
                                Text='<%# Bind("CurrentStatus") %>' />
                            <br />
                            Jobtitle:
                            <asp:TextBox ID="JobtitleTextBox" runat="server" 
                                Text='<%# Bind("Jobtitle") %>' />
                            <br />
                            LCAlocation:
                            <asp:TextBox ID="LCAlocationTextBox" runat="server" 
                                Text='<%# Bind("LCAlocation") %>' />
                            <br />
                            County:
                            <asp:TextBox ID="CountyTextBox1" runat="server" 
                                Text='<%# Bind("County") %>' />
                            <br />
                            EmpStartEnd:
                            <asp:TextBox ID="EmpStartEndTextBox" runat="server" 
                                Text='<%# Bind("EmpStartEnd") %>' />
                            <br />
                            ChangeoflocLCANo:
                            <asp:TextBox ID="ChangeoflocLCANoTextBox" runat="server" 
                                Text='<%# Bind("ChangeoflocLCANo") %>' />
                            <br />
                            location:
                            <asp:TextBox ID="locationTextBox" runat="server" 
                                Text='<%# Bind("location") %>' />
                            <br />
                            SOC:
                            <asp:TextBox ID="SOCTextBox" runat="server" 
                                Text='<%# Bind("SOC") %>' />
                            <br />
                            salary:
                            <asp:TextBox ID="salaryandlevelTextBox" runat="server" 
                                Text='<%# Bind("salaryandlevel") %>' />
                            <br />
                            Level:
                            <asp:TextBox ID="SalLevelTextBox" runat="server" 
                                Text='<%# Bind("SalLevel") %>' />
                            <br />

                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                                CommandName="Insert" Text="Insert" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <table bgcolor="White" border="1" class="style2">
                                <tr>
                                    <td class="style3">Tracking ID</td>
                                    <td>
                                        <asp:Label ID="RLTrackingNumberLabel" runat="server" 
                                            Text='<%# Bind("RLTrackingNumber") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">Company</td>
                                    <td>
                                        <asp:Label ID="CompanyLabel" runat="server" Text='<%# Bind("Legal_Name") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">LCA Track Number</td>
                                    <td>
                                        <asp:Label ID="LCATrackNumberLabel" runat="server" 
                                            Text='<%# Bind("LCATrackNumber") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">Beneficiary</td>
                                    <td align="left">
                                        <asp:Label ID="BeneficiaryLabel" runat="server" 
                                            Text='<%# Bind("Beneficiary") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">Type of LCA</td>
                                    <td>
                                        <asp:Label ID="TypeofLCALabel" runat="server" Text='<%# Bind("TypeofLCA") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">Date Filed</td>
                                    <td>
                                        <asp:Label ID="DatefiledLabel" runat="server" Text='<%# Bind("Datefiled") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">Date Approved</td>
                                    <td>
                                        <asp:Label ID="DateapprovedLabel" runat="server" 
                                            Text='<%# Bind("Dateapproved") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">Current Status</td>
                                    <td>
                                        <asp:Label ID="CurrentStatusLabel" runat="server" 
                                            Text='<%# Bind("CurrentStatus") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">Job Title</td>
                                    <td>
                                        <asp:Label ID="JobtitleLabel" runat="server" Text='<%# Bind("Jobtitle") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">LCA Location</td>
                                    <td>
                                        <asp:Label ID="LCAlocationLabel" runat="server" 
                                            Text='<%# Bind("LCAlocation") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">County</td>
                                    <td>
                                        <asp:Label ID="CountyLabel" runat="server" 
                                            Text='<%# Bind("County") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">Emp. Start Date and End Date</td>
                                    <td>
                                        <asp:Label ID="EmpStartEndLabel" runat="server" 
                                            Text='<%# Bind("EmpStartEnd") %>' />

                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">SOC</td>
                                    <td>
                                        <asp:Label ID="SOCLabel" runat="server" 
                                            Text='<%# Bind("SOC") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">Salary</td>
                                    <td>
                                        <asp:Label ID="salaryandlevelLabel" runat="server" 
                                            Text='<%# Bind("salaryandlevel") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">Level</td>
                                    <td>
                                        <asp:Label ID="salLevelLabel" runat="server" 
                                            Text='<%# Bind("SalLevel") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">Notes</td>
                                    <td>
                                        <asp:Label ID="Noteslabel" runat="server" 
                                            Text='<%# Bind("Notes") %>' /></td>
                                </tr>
                                <tr>
                                    <td class="style3">&nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                                            CommandName="Edit" Text="Edit" />
                                        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                                            CommandName="Delete" Text="Delete"  Visible=false/>
                                        &nbsp;</td>
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ connectionStrings:ACLG_DB %>" 
                        DeleteCommand="DELETE FROM [LCtracking] WHERE [ID] = @ID" 
                        InsertCommand="INSERT INTO [LCtracking] ([RLTrackingNumber], [Company], [LCATrackNumber], [Beneficiary], [TypeofLCA], [Datefiled], [Dateapproved], [CurrentStatus], [Jobtitle], [LCAlocation], [County], [EmpStartEnd], [ChangeoflocLCANo], [location], [SOC], [salaryandlevel], [SalLevel]) VALUES (@RLTrackingNumber, @Company, @LCATrackNumber, @Beneficiary, @TypeofLCA, @Datefiled, @Dateapproved, @CurrentStatus, @Jobtitle, @LCAlocation, @County, @EmpStartEnd, @ChangeoflocLCANo, @location, @SOC, @salaryandlevel, @SalLevel)" 
                        SelectCommand="SELECT * FROM [LCtracking], Company where CompanyID = Company and ([ID] = @ID)" 
                        UpdateCommand="UPDATE [LCtracking] SET  [LCATrackNumber] = @LCATrackNumber,  [TypeofLCA] = @TypeofLCA, [Datefiled] = @Datefiled, [Dateapproved] = @Dateapproved, [CurrentStatus] = @CurrentStatus, [Jobtitle] = @Jobtitle, [LCAlocation] = @LCAlocation, [County] = @County, [EmpStartEnd] = @EmpStartEnd, [ChangeoflocLCANo] = @ChangeoflocLCANo, [location] = @location, [SOC] = @SOC, [salaryandlevel] = @salaryandlevel, [SalLevel] = @SalLevel, Notes =@notes WHERE [ID] = @ID"
                        OnUpdated="OnDSUpdatedHandler">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="RLTrackingNumber" Type="String" />
                            <asp:Parameter Name="Company" Type="Int32" />
                            <asp:Parameter Name="LCATrackNumber" Type="String" />
                            <asp:Parameter Name="Beneficiary" Type="String" />
                            <asp:Parameter Name="TypeofLCA" Type="String" />
                            <asp:Parameter Name="Datefiled" Type="DateTime" />
                            <asp:Parameter Name="Dateapproved" Type="DateTime" />
                            <asp:Parameter Name="CurrentStatus" Type="String" />
                            <asp:Parameter Name="Jobtitle" Type="String" />
                            <asp:Parameter Name="LCAlocation" Type="String" />
                            <asp:Parameter Name="County" Type="String" />
                            <asp:Parameter Name="EmpStartEnd" Type="String" />
                            <asp:Parameter Name="ChangeoflocLCANo" Type="String" />
                            <asp:Parameter Name="location" Type="String" />
                            <asp:Parameter Name="SOC" Type="String" />
                            <asp:Parameter Name="salaryandlevel" Type="String" />
                            <asp:Parameter Name="SalLevel" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ID" QueryStringField="LCAID" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="LCATrackNumber" Type="String" />                           
                            <asp:Parameter Name="TypeofLCA" Type="String" />
                            <asp:Parameter Name="Datefiled" Type="DateTime" />
                            <asp:Parameter Name="Dateapproved" Type="DateTime" />
                            <asp:Parameter Name="CurrentStatus" Type="String" />
                            <asp:Parameter Name="Jobtitle" Type="String" />
                            <asp:Parameter Name="LCAlocation" Type="String" />
                            <asp:Parameter Name="County" Type="String" />
                            <asp:Parameter Name="EmpStartEnd" Type="String" />
                            <asp:Parameter Name="ChangeoflocLCANo" Type="String" />
                            <asp:Parameter Name="location" Type="String" />
                            <asp:Parameter Name="SOC" Type="String" />
                            <asp:Parameter Name="salaryandlevel" Type="String" />
                            <asp:Parameter Name="SalLevel" Type="String" />
                            <asp:Parameter Name="Notes" Type="String" />
                            <asp:Parameter Name="ID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            </table>
      </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
</form>
</body>
</html>

