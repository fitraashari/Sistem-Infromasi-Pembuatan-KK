<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Entry_Status.aspx.vb" Inherits="Pembuatan_KK.Entry_Status" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="entry" align="center">
            <tr>
                <td class="entry">Kode Status Hubungan</td>
                <td class="entry">
                    <asp:TextBox ID="tbKodest" runat="server" MaxLength="6" Width="131px" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">Status Hubungan Dalam Keluarga</td>
                <td class="entry">
                    <asp:TextBox ID="tbSthb" runat="server" MaxLength="30" Width="252px" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">&nbsp;</td>
                <td class="entry">
                    <asp:Button ID="btnSimpan" runat="server" Text="Simpan" class="entry"/>
&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
