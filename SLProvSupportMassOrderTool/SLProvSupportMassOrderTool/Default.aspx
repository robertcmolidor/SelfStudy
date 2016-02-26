<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SLProvSupportMassOrderTool.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        SoftLayer API Testing<br />
        <br />
        Select a DC<br />
        <asp:DropDownList ID="locationDropDown" runat="server">
            <asp:ListItem Value="0">Dal01</asp:ListItem>
            <asp:ListItem Value="1">Dal05</asp:ListItem>
            <asp:ListItem Value="2">Dal06</asp:ListItem>
            <asp:ListItem Value="3">Dal07</asp:ListItem>
            <asp:ListItem Value="4">Dal09</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Select a Config<br />
        <asp:DropDownList ID="configDropDown" runat="server">
            <asp:ListItem Value="0">Config 0</asp:ListItem>
            <asp:ListItem Value="1">Config 1</asp:ListItem>
            <asp:ListItem Value="2">Config 2</asp:ListItem>
            <asp:ListItem Value="3">Config 3</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Select an OS<br />
        <asp:DropDownList ID="osDropDown" runat="server">
            <asp:ListItem Value="0">RedHat</asp:ListItem>
            <asp:ListItem Value="1">CentOS</asp:ListItem>
            <asp:ListItem Value="2">Ubu</asp:ListItem>
            <asp:ListItem Value="3">Win</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Quantity<br />
        <asp:TextBox ID="quantityTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="okButton" runat="server" OnClick="Button1_Click" Text="DoShit" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
