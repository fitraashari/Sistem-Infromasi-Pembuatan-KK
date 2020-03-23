<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="List_Penduduk.aspx.vb" Inherits="Pembuatan_KK.List_Penduduk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div style="overflow-x: auto;"><div align="left"><a href="Entry_Penduduk.aspx"><img src="add.png" height="20" width="20">Entry Data</a></div>
            <div align="right" style="margin-top: -60px;">
                <asp:TextBox ID="tbNik" runat="server" placeholder="Masukkan NIK Penduduk"></asp:TextBox>
                <asp:Button ID="btnCari" runat="server" Text="Cari" class='list' />
                &nbsp;<asp:Button ID="btAlldata" runat="server" Text="Tampilkan Semua Data" class='list' />
                &nbsp;
            </div>
            <br />
            <br />
            <asp:Label ID="lbdata" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
