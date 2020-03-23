<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Edit_Penduduk.aspx.vb" Inherits="Pembuatan_KK.Edit_Penduduk" %>

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
                <td class="entry">NIK</td>
                <td class="entry">
                    <asp:TextBox ID="tbnik" runat="server" MaxLength="16" Width="131px" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">Nama</td>
                <td class="entry">
                    <asp:TextBox ID="tbnama" runat="server" Width="258px" MaxLength="50" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">Tempat Lahir</td>
                <td class="entry">
                    <asp:TextBox ID="tbtemplhr" runat="server" Width="157px" MaxLength="25" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">Tanggal Lahir</td>
                <td class="entry">
                    <asp:TextBox ID="tbtgllhr" runat="server" TextMode="Date" type="date" Width="164px" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">Jenis Kelamin</td>
                <td class="entry">
                    <asp:RadioButton ID="rbLaki" runat="server" Text="Laki Laki" GroupName="gender" />
&nbsp;<asp:RadioButton ID="rbPerempuan" runat="server" Text="Perempuan" GroupName="gender" />
                </td>
            </tr>
            <tr>
                <td class="entry">Alamat</td>
                <td class="entry">
                    <asp:TextBox ID="tbAlamat" runat="server" MaxLength="50" required=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">Pekerjaan</td>
                <td class="entry">
                    <asp:DropDownList ID="ddPekerjaan" runat="server" required>
                        <asp:ListItem>Belum / Tidak Bekerja</asp:ListItem>
                        <asp:ListItem>TNI</asp:ListItem>
                        <asp:ListItem>Mengurus Rumah Tangga</asp:ListItem>
                        <asp:ListItem>Pelajar / Mahasiswa</asp:ListItem>
                        <asp:ListItem>PNS</asp:ListItem>
                        <asp:ListItem>POLRI</asp:ListItem>
                        <asp:ListItem>Pensiunan</asp:ListItem>
                        <asp:ListItem>Perdagangan</asp:ListItem>
                        <asp:ListItem>Petani/Pekebun</asp:ListItem>
                        <asp:ListItem>Peternak</asp:ListItem>
                        <asp:ListItem>Nelayan/Perikanan</asp:ListItem>
                        <asp:ListItem>Industri</asp:ListItem>
                        <asp:ListItem>Konstruksi</asp:ListItem>
                        <asp:ListItem>Transportasi</asp:ListItem>
                        <asp:ListItem>Karyawan Swasta</asp:ListItem>
                        <asp:ListItem>Karyawan BUMN</asp:ListItem>
                        <asp:ListItem>Karyawan BUMD</asp:ListItem>
                        <asp:ListItem>Karyawan Honorer</asp:ListItem>
                        <asp:ListItem>Buruh Harian Lepas</asp:ListItem>
                        <asp:ListItem>Buruh Tani/Perkebunan</asp:ListItem>
                        <asp:ListItem>Buruh Nelayan/Perikanan</asp:ListItem>
                        <asp:ListItem>Buruh Peternakan</asp:ListItem>
                        <asp:ListItem>Pembantu Rumah Tangga</asp:ListItem>
                        <asp:ListItem>Tukang Cukur</asp:ListItem>
                        <asp:ListItem>Tukang Listrik</asp:ListItem>
                        <asp:ListItem>Tukang Batu</asp:ListItem>
                        <asp:ListItem>Tukang Kayu</asp:ListItem>
                        <asp:ListItem>Tukang Sol Sepatu</asp:ListItem>
                        <asp:ListItem>Tukang Las/Pandai Besi</asp:ListItem>
                        <asp:ListItem>Tukang Jahit</asp:ListItem>
                        <asp:ListItem>Tukang Gigi</asp:ListItem>
                        <asp:ListItem>Penata Rias</asp:ListItem>
                        <asp:ListItem>Penata Busana</asp:ListItem>
                        <asp:ListItem>Penata Rambut</asp:ListItem>
                        <asp:ListItem>Mekanik</asp:ListItem>
                        <asp:ListItem>Seniman</asp:ListItem>
                        <asp:ListItem>Tabib</asp:ListItem>
                        <asp:ListItem>Paraji</asp:ListItem>
                        <asp:ListItem>Perancang Busana</asp:ListItem>
                        <asp:ListItem>Penterjemah</asp:ListItem>
                        <asp:ListItem>Imam Mesjid</asp:ListItem>
                        <asp:ListItem>Pendeta</asp:ListItem>
                        <asp:ListItem>Pastor</asp:ListItem>
                        <asp:ListItem>Wartawan</asp:ListItem>
                        <asp:ListItem>Ustad/Mubaligh</asp:ListItem>
                        <asp:ListItem>Juru Masak</asp:ListItem>
                        <asp:ListItem>Promotor Acara</asp:ListItem>
                        <asp:ListItem>Anggota DPR RI</asp:ListItem>
                        <asp:ListItem>Anggota DPD RI</asp:ListItem>
                        <asp:ListItem>Anggota BPK</asp:ListItem>
                        <asp:ListItem>Anggota Mahkamah Konstitusi</asp:ListItem>
                        <asp:ListItem>Anggota Kabinet</asp:ListItem>
                        <asp:ListItem>Duta Besar</asp:ListItem>
                        <asp:ListItem>Gubernur</asp:ListItem>
                        <asp:ListItem>Wakil Gubernur</asp:ListItem>
                        <asp:ListItem>Bupati</asp:ListItem>
                        <asp:ListItem>Wakil Bupati</asp:ListItem>
                        <asp:ListItem>Walikota</asp:ListItem>
                        <asp:ListItem>Wakil Walikota</asp:ListItem>
                        <asp:ListItem>Anggota DPRD PROV</asp:ListItem>
                        <asp:ListItem>Anggota DPRD Kab/Kota</asp:ListItem>
                        <asp:ListItem>Dosen</asp:ListItem>
                        <asp:ListItem>Guru</asp:ListItem>
                        <asp:ListItem>Pilot</asp:ListItem>
                        <asp:ListItem>Pengacara</asp:ListItem>
                        <asp:ListItem>Notaris</asp:ListItem>
                        <asp:ListItem>Arsitek</asp:ListItem>
                        <asp:ListItem>Akuntan</asp:ListItem>
                        <asp:ListItem>Konsultan</asp:ListItem>
                        <asp:ListItem>Dokter</asp:ListItem>
                        <asp:ListItem>Perawat</asp:ListItem>
                        <asp:ListItem>Apoteker</asp:ListItem>
                        <asp:ListItem>Psikiater/psikolog</asp:ListItem>
                        <asp:ListItem>Penyiar Televisi</asp:ListItem>
                        <asp:ListItem>Penyiar Radio</asp:ListItem>
                        <asp:ListItem>Pelaut</asp:ListItem>
                        <asp:ListItem>Peneliti</asp:ListItem>
                        <asp:ListItem>Sopir</asp:ListItem>
                        <asp:ListItem>Pialang</asp:ListItem>
                        <asp:ListItem>Paranormal</asp:ListItem>
                        <asp:ListItem>Pedagang</asp:ListItem>
                        <asp:ListItem>Perangkat Desa</asp:ListItem>
                        <asp:ListItem>Kepala Desa</asp:ListItem>
                        <asp:ListItem>Biarawan/Biarawati</asp:ListItem>
                        <asp:ListItem>Wiraswasta</asp:ListItem>
                        <asp:ListItem>Pekerjaan Lainnya</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="entry">Kewarganegaraan</td>
                <td class="entry">
                    <asp:DropDownList ID="ddNegara" runat="server" required>
                        <asp:ListItem>WNI</asp:ListItem>
                        <asp:ListItem>WNA</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="entry">Pendidikan Terakhir</td>
                <td class="entry">
                    <asp:DropDownList ID="ddPendididkan" runat="server">
                        <asp:ListItem>Tidak/Belum Sekolah</asp:ListItem>
                        <asp:ListItem>Belum Tamat SD/Sederajat</asp:ListItem>
                        <asp:ListItem>Tamat SD/Sederajat</asp:ListItem>
                        <asp:ListItem>SLTP/Sederajat</asp:ListItem>
                        <asp:ListItem>SLTA/Sederajat</asp:ListItem>
                        <asp:ListItem>Diploma I/II</asp:ListItem>
                        <asp:ListItem>Akademi/Diploma II/Sarjana Muda</asp:ListItem>
                        <asp:ListItem>Diploma IV/Sastra I</asp:ListItem>
                        <asp:ListItem>Sastra II</asp:ListItem>
                        <asp:ListItem>Sastra III</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="entry">Agama</td>
                <td class="entry">
                    <asp:DropDownList ID="ddAgama" runat="server" Height="26px" Width="142px" required>
                        <asp:ListItem>Islam</asp:ListItem>
                        <asp:ListItem>Kristen</asp:ListItem>
                        <asp:ListItem>Katholik</asp:ListItem>
                        <asp:ListItem>Hindu</asp:ListItem>
                        <asp:ListItem>Budha</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="entry">Status</td>
                <td class="entry">
                    <asp:DropDownList ID="ddStatus" runat="server" required>
                        <asp:ListItem>Kawin</asp:ListItem>
                        <asp:ListItem>Belum Kawin</asp:ListItem>
                        <asp:ListItem>Cerai Hidup</asp:ListItem>
                        <asp:ListItem>Cerai Mati</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="entry">No Paspor</td>
                <td class="entry">
                    <asp:TextBox ID="tbPaspor" runat="server" Width="213px" placeholder="Kosongkan jika tidak ada"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">No Kitap/Kitas</td>
                <td class="entry">
                    <asp:TextBox ID="tbKitap" runat="server" Width="215px" placeholder="Kosongkan jika tidak ada"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">Nama Ayah</td>
                <td class="entry">
                    <asp:TextBox ID="tbAyah" runat="server" Width="258px" MaxLength="50" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">Nama Ibu</td>
                <td class="entry">
                    <asp:TextBox ID="tbIbu" runat="server" Width="258px" MaxLength="50" required></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="entry">Keterangan</td>
                <td class="entry">
                    <asp:TextBox ID="tbket" runat="server" TextMode="MultiLine" Height="90px" Width="276px" placeholder="Kosongkan jika tidak ingin mengisi" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="entry">&nbsp;</td>
                <td class="entry">
                    <asp:Button ID="btnSimpan" runat="server" Text="Simpan" class="entry"/>
&nbsp;<asp:Button ID="btnBatal" runat="server" Text="Batal" class="entry"/>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
       </body>
</html>
