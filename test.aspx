<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <asp:Button ID="btnLoadData" runat="server" OnClick="btnLoadData_Click" Text="Load" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsTalepKategori">
                <Columns>
                    <asp:BoundField DataField="TALEP_KATEGORI_KOD" HeaderText="TALEP_KATEGORI_KOD" SortExpression="TALEP_KATEGORI_KOD" />
                    <asp:BoundField DataField="TALEP_KATEGORI_AD" HeaderText="TALEP_KATEGORI_AD" SortExpression="TALEP_KATEGORI_AD" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="dsTalepKategori" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>" ProviderName="<%$ ConnectionStrings:MyConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;TALEP_KATEGORILERI&quot;"></asp:SqlDataSource>
            <asp:DropDownList ID="drpKategori" runat="server" DataSourceID="dsTalepOncelik" DataTextField="TALEP_ONCELIGI_AD" DataValueField="TALEP_ONCELIGI_KOD">
            </asp:DropDownList>
            <asp:SqlDataSource ID="dsTalepOncelik" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>" ProviderName="<%$ ConnectionStrings:MyConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;TALEP_ONCELIGI&quot;"></asp:SqlDataSource>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Talp İçerik"></asp:Label>
            <asp:TextBox ID="txtIcerik" runat="server"></asp:TextBox>
            <asp:Button ID="btnYaz" runat="server" OnClick="btnYaz_Click" Text="Yaz" />
            <asp:Label ID="lblSonuc" runat="server"></asp:Label>
            <br />
            <br />
            <br />



        </div>
    </form>
</body>
</html>
