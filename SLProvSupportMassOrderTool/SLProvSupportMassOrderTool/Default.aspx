<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SLProvSupportMassOrderTool.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        SL Mass Order Tool&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        Select a DC&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select a Config&nbsp;&nbsp;&nbsp;&nbsp; Select an OS<br />
        <asp:DropDownList ID="locationDropDown" runat="server">
            <asp:ListItem Value="3">Dal01</asp:ListItem>
            <asp:ListItem Value="138124">Dal05</asp:ListItem>
            <asp:ListItem Value="154820">Dal06</asp:ListItem>
            <asp:ListItem Value="142776">Dal07</asp:ListItem>
            <asp:ListItem Value="449494">Dal09</asp:ListItem>
            <asp:ListItem Value="449506">Fra02</asp:ListItem>
            <asp:ListItem Value="352494">Hkg02</asp:ListItem>
            <asp:ListItem Value="142775">Hou02</asp:ListItem>
            <asp:ListItem Value="358694">Lon02</asp:ListItem>
            <asp:ListItem Value="449596">Mel01</asp:ListItem>
            <asp:ListItem Value="449600">Mex01</asp:ListItem>
            <asp:ListItem Value="815394">Mil01</asp:ListItem>
            <asp:ListItem Value="449610">Mon01</asp:ListItem>
            <asp:ListItem Value="449596">Par01</asp:ListItem>
            <asp:ListItem Value="168642">Sjc01</asp:ListItem>
            <asp:ListItem Value="1004995">Sjc03</asp:ListItem>
            <asp:ListItem Value="983497">Sao01</asp:ListItem>
            <asp:ListItem Value="18171">Sea01</asp:ListItem>
            <asp:ListItem Value="224092">Sng01</asp:ListItem>
            <asp:ListItem Value="449612">Syd01</asp:ListItem>
            <asp:ListItem Value="449604">Tok02</asp:ListItem>
            <asp:ListItem Value="448994">Tor01</asp:ListItem>
            <asp:ListItem Value="37473">Wdc01</asp:ListItem>
            <asp:ListItem Value="957095">wdc04</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="configDropDown" runat="server">
            <asp:ListItem Value="0">Config 0</asp:ListItem>
            <asp:ListItem Value="1">Config 1</asp:ListItem>
            <asp:ListItem Value="2">Config 2</asp:ListItem>
            <asp:ListItem Value="3">Config 3</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="osDropDown" runat="server">
            <asp:ListItem Value="0">RedHat</asp:ListItem>
            <asp:ListItem Value="1">CentOS</asp:ListItem>
            <asp:ListItem Value="2">Ubu</asp:ListItem>
            <asp:ListItem Value="3">Win</asp:ListItem>
            <asp:ListItem Value="142185">Debian</asp:ListItem>
        </asp:DropDownList>
        <br />
        Quantity<br />
        <asp:TextBox ID="quantityTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="verifyOrderButton" runat="server" OnClick="verifyOrderButton_Click" Text="Verify Order" />
        <br />
        <br />
        <asp:Label ID="verifyLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="submitOrderButton" runat="server" OnClick="Button1_Click" Text="Submit Order" />
        <br />
        <br />
        Ordered Devices:<br />
        <asp:Label ID="orderedLabel" runat="server"></asp:Label>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
