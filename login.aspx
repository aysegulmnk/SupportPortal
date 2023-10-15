<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 373px">
            <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server" Width="114px"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Şifre"></asp:Label>
            <asp:TextBox ID="txtPass" runat="server" OnTextChanged="txtPass_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Giriş" OnClick="btnLogin_Click" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Sorumlu Giriş" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="lblSonuc" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
