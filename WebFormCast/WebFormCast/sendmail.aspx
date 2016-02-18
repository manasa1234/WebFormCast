<%@ Page Language="C#" AutoEventWireup="true" Inherits="sendmail" Codebehind="sendmail.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        To Email
        <asp:TextBox ID="TextBox1" runat="server" Height="26px" Width="248px"></asp:TextBox>
    
    </div>
    <p>
        Subject&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Width="261px"></asp:TextBox>
    </p>
    <p>
        Message
        <asp:TextBox ID="TextBox3" runat="server" Height="114px" Width="304px"></asp:TextBox>
    </p>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" 
        Width="277px" />
    <p>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" 
            Width="165px" />
    </p>
    </form>
</body>
</html>
