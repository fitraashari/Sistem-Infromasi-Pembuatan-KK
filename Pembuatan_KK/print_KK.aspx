<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="print_KK.aspx.vb" Inherits="Pembuatan_KK.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Out KK</title>
    
<style>
#warp{
width: 100%;
height: 800px;
font-family: Calibri;
}
#form1{
    margin-top: -40px;
}
h1 {
    font-size: 400%;
padding-top: 50px;
z-index:2;
	margin-left: -100px;
}

h2 {
    font-size: 200%;
	margin-top: -50px;
		margin-left: -100px;
}
img {
float: left;
z-index:1;
position: absolute;
padding-left: 70px
}
#kiri{
padding-left: 120px;
float: left;
}
#kanan{
float: left;
margin-left: 600px;
}
th{
 text-align: center;
}
#atas{

}
.datap{
    border-collapse: collapse;

width: 95%;
border: 2px solid black;
}
.no{
 text-align: center;
 background: grey;
}
td.upercase{
        text-transform: uppercase;
}
#ftengah{
float: left;

}
#fkiri{
float: left;
padding-left: 100px;
}
#ftengah td{
padding-top:22px;
text-align: center;
padding-left: 250px;
}
#fkanan td{
padding-top:22px;
text-align: center;
padding-left: 150px;
}
.nover{
    text-align: center;
}
</style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    
        <div id="warp">

<div id="head">
<img src="logo.jpg" width="150px" height="150px"/>
<center><h1>KARTU KELUARGA</h1>
                                        <h2>No. 
                                            <asp:Label ID="lbNoKK" runat="server"></asp:Label>
                    </h2> 
                                        </center>
</div>
<div id="detail">
<div id="kiri">
<table >
<tr>
<td>Nama Kepala Keluarga</td>
<td>:</td>
<td>
    <asp:Label ID="lbNamakk" runat="server"></asp:Label>
    </td>
</tr>
<tr>
<td>Alamat</td>
<td>:</td>
<td>
    <asp:Label ID="lbAlamat" runat="server"></asp:Label>
    </td>
</tr>
<tr>
<td>RT/RW</td>
<td>:</td>
<td>
    <asp:Label ID="lbRtRw" runat="server"></asp:Label>
    </td>
</tr>
<tr>
<td>Desa/Kelurahan</td>
<td>:</td>
<td>
    <asp:Label ID="lbDesa" runat="server"></asp:Label>
    </td>
</tr>
</table>
</div>
<div id="kanan">
<table >
<tr>
<td>Kecamatan</td>
<td>:</td>
<td>
    <asp:Label ID="lbKecamatan" runat="server"></asp:Label>
    </td>
</tr>
<tr>
<td>Kabupaten/Kota</td>
<td>:</td>
<td>
    <asp:Label ID="lbKabupaten" runat="server"></asp:Label>
    </td>
</tr>
<tr>
<td>Kode Pos</td>
<td>:</td>
<td>
    <asp:Label ID="lbKodePos" runat="server"></asp:Label>
    </td>
</tr>
<tr>
<td>Provinsi</td>
<td>:</td>
<td>
    <asp:Label ID="lbProvinsi" runat="server"></asp:Label>
    </td>
</tr>
</table>
</div>

</div>
<div id="isi">
<div id="atas">
<table align="center" class="datap" border="1">
<tr>
<th>No</th>
<th>Nama Lengkap</th>
<th>NIK</th>
<th>Jenis Kelamin</th>
<th>Tempat Lahir</th>
<th>Tanggal Lahir</th>
<th>Agama</th>
<th>Pendidikan</th>
<th>Jenis Pekerjaan</th>
</tr>
<tr>
<td class='no'></td>
<td class='no'>(1)</td>
<td class='no'>(2)</td>
<td class='no'>(3)</td>
<td class='no'>(4)</td>
<td class='no'>(5)</td>
<td class='no'>(6)</td>
<td class='no'>(7)</td>
<td class='no'>(8)</td>
</tr>
    <tr>
        <asp:Label ID="dKepalaKK" runat="server" Text=""></asp:Label>
        </tr>

        <asp:Label ID="dPddk" runat="server" Text=""></asp:Label>

</table>
    </br>
    <table align="center" class="datap" border="1">
<tr>
<th rowspan='2'>No.</th>
<th rowspan='2'>Status Perkawinan</th>
<th rowspan='2'>Status Hubungan Dalam Keluarga</th>
<th rowspan='2'>Kewarganegaraan</th>
<th colspan='2'>Dokumen Imigrasi</th>
<th colspan='2'>Nama Orangtua</th>

</tr>
  <tr>
<th>No. Paspor</th>
<th>No. KITAS/KITAP</th>
<th>Ayah</th>
<th>Ibu</th>
</tr>
<tr>
<td class='no'></td>
<td class='no'>(9)</td>
<td class='no'>(10)</td>
<td class='no'>(11)</td>
<td class='no'>(12)</td>
<td class='no'>(13)</td>
<td class='no'>(14)</td>
<td class='no'>(15)</td>
</tr>
        
        <asp:Label ID="dHubKK" runat="server" Text=""></asp:Label>
        
        <asp:Label ID="dHubPd" runat="server" Text=""></asp:Label>
</table>
</div>
</div>
<div id="footer">
    <div id="fkiri">
<table>
<tr>
<td>Dikeluarkan Tanggal</td>
<td>:</td>
<td> 
    <asp:Label ID="lbTglPemb" runat="server"></asp:Label>
    </td>
</tr>
<tr >
<td valign="top">LEMBAR</td>
<td valign="top">:</td>
<td valign="bottom">I. Kepala Keluarga</br>
	II. RT</br>
	III. Desa/Kelurahan</br>
	IV. Kecamatan</td>
</tr>
</table>
</div>
<div id="ftengah">
<table>
<tr>
<td>KEPALA KELUARGA</td>
</tr>
<tr style="height:50px">
<td> </td>
</tr>
<tr>
<td><u><b>
    <asp:Label ID="lbnewKK" runat="server"></asp:Label></b></u></br>TandaTangan/Cap Jempol</td>
</tr>
</table>
</div>
<div id="fkanan">
<table>
<tr>
<td>KEPALA DINAS KEPENDUDUKAN DAN</br>PENCATATAN SIPIL</td>
</tr>
<tr style="height:35px">
<td> </td>
</tr>
<tr>
<td><u><b>Mohammad Fitra Ashari S.Kom</b></u></br>NIP. 12412420021996</td>
</tr>
</table>
</div>
</div>
</div>
    

    
    </div>
    </form>
       </body>
</html>
