<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 46px; width: 1660px">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Talep Destek Formu" Font-Size=50px></asp:Label>
            <br />
        </div>
        <p>
            &nbsp;</p>
        <asp:Label ID="Label2" runat="server" Text="Talep Katagorisi"></asp:Label>
        &nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Talep Önceliği"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Talep Sorumlusu"></asp:Label>
        &nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList3" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Talep"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="148px" Width="368px"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Talep Gönder" OnClick="Button1_Click" />
        <br />
        <br />
        <p>
            &nbsp;</p>
        <asp:Label ID="Label6" runat="server" Text="Taleplerim" Font-Size=50px></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
