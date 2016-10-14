<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NyanCatBattleRemix.Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        Welcome to NyanCat Battle Remix.&nbsp; A rewrite of an old fun program.<br />
        <br />
        You are NyanCat and you&#39;re fighting your way to the most notorious meme of them all.&nbsp;
        <br />
        What would you like to do?<br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Train" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="fightButton" runat="server" Text="Go to the Arena" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
