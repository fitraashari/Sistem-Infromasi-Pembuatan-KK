<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="List_Detail_KK.aspx.vb" Inherits="Pembuatan_KK.List_Detail_KK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="overflow-x:auto;">
    <div align="left"><a href="Detail_KK.aspx"><img src="add.png" height="20" width="20">Entry Data</a></div>
            <div align="center" style="margin-top: -60px;">
                <asp:TextBox ID="tbKK" runat="server" placeholder="Masukkan No KK"></asp:TextBox>
                <asp:Button ID="btnCari" runat="server" Text="Cari" class='list' />
                &nbsp;&nbsp;
            </div>
        <br />
            <asp:Label ID="lbdatakk" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lbdata" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
