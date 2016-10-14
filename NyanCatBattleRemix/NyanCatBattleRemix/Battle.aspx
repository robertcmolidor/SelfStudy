<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Battle.aspx.cs" Inherits="NyanCatBattleRemix.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <br />
        <br />
        Enemy Name:<br />
        <asp:Label ID="enemyNameLabel" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="gameOutputLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="attackButton" runat="server" OnClick="attackButton_Click" Text="Attack" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="useItemButton" runat="server" Text="Use Item" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="runButton" runat="server" Text="Run" />
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        Health: <asp:Label ID="healthLabel" runat="server"></asp:Label>
        <br />
        <br />
        Limit:
        <asp:Label ID="limitLabel" runat="server"></asp:Label>
        <br />
        <br />
        Backpack Contents:<br />
        <asp:Label ID="backpackContentsLabel" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
