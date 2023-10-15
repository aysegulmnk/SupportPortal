<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Sorumlu Giriş Sayfası" Font-Size=50px></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <p>
        <asp:Label ID="Label2" runat="server" Text="Tc No:"></asp:Label>
    &nbsp;&nbsp;
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Şifre: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btnLogin" runat="server" Text="Giriş" OnClick="Button1_Click" />
        </p>
        <p>
            <asp:Label ID="lblSonuc" runat="server" Text=""></asp:Label>
        </p>
    </form>
</body>
</html>
