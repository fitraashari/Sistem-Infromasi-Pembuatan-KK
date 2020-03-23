<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Edit_KK.aspx.vb" Inherits="Pembuatan_KK.Edit_KK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css" />

    <style type="text/css">
        .auto-style1 {
            width: 176px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="entry" align="center">
            <tr>
                <td class="entry">No KK</td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbNoKK" runat="server" MaxLength="16" Width="131px" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">Kepala Keluarga</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddNIK" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="entry">Alamat</td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbAlamat" runat="server" Width="157px" MaxLength="50" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">Kode POS</td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbKodePos" runat="server" MaxLength="6" required="" Width="73px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">RT/RW</td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbRT" runat="server" Width="31px" MaxLength="2"></asp:TextBox>
&nbsp;/
                    <asp:TextBox ID="tbRW" runat="server" Width="31px" MaxLength="2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">Desa/Kelurahan</td>
                <td class="entry">
                    <asp:TextBox ID="tbDesa" runat="server" Width="141px" required MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">Kecamatan</td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbKecamatan" runat="server" Width="141px" required MaxLength="30"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="entry">Kabupaten</td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbKabupaten" runat="server" Width="141px" placeholder="Kosongkan jika tidak ada" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">Provinsi</td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbProvinsi" runat="server" Width="141px" placeholder="Kosongkan jika tidak ada" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
                       
            <tr>
                <td class="entry">Tanggal Pembuatan</td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbtglPemb" runat="server" TextMode="Date" type="date" Width="164px" required></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="entry">&nbsp;</td>
                <td class="auto-style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="entry">&nbsp;</td>
                <td class="auto-style1">
                    <asp:Button ID="btnSimpan" runat="server" Text="Simpan" class="entry"/>
&nbsp;<asp:Button ID="btnBatal" runat="server" Text="Batal" class="entry"/>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
       </body>
</html>
