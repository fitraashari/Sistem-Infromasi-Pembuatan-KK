<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Detail_KK.aspx.vb" Inherits="Pembuatan_KK.Detail_KK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css" />

    <style type="text/css">
        .auto-style1 {
            width: 325px;
        }
        .auto-style2 {
            height: 38px;
        }
        .auto-style3 {
            width: 325px;
            height: 38px;
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
                    <asp:DropDownList ID="ddKK" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                     
                </td>
            </tr>
            <tr>
                <td class="entry">&nbsp;</td>
                <td class="auto-style1">
                    <asp:Label ID="anggotaKK" runat="server"></asp:Label>
                     
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Status Hubungan Dalam Keluarga</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddStatus" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="01-Istri">Istri</asp:ListItem>
                        <asp:ListItem Value="02-Anak">Anak</asp:ListItem>
                        <asp:ListItem Value="03-Menantu">Menantu</asp:ListItem>
                        <asp:ListItem Value="04-Cucu">Cucu</asp:ListItem>
                        <asp:ListItem Value="05-Orangtua">Orangtua</asp:ListItem>
                        <asp:ListItem Value="06-Mertua">Mertua</asp:ListItem>
                        <asp:ListItem Value="07-Famili Lain">Famili Lain</asp:ListItem>
                        <asp:ListItem Value="08-Pembantu">Pembantu</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="entry">NIK </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddNik" runat="server">
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="btAdd" runat="server" Text="+" class="list" Height="47px" Width="37px"/>
                </td>
            </tr>
            
            <tr>
                <td class="entry" colspan="2">
                    <asp:Table ID="tbPenduduk" runat="server" Width="369px">
                    </asp:Table>
                </td>
                
            </tr>
            
            <tr>
                <td class="entry">&nbsp;</td>
                <td class="auto-style1">
                    <asp:Button ID="btnSimpan" runat="server" Text="Simpan" class="entry"/>
&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
       </body>
</html>
