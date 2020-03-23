<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Pembuatan_KK.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="login.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id='wrap'>
        <div id='logo'>
</div>
<div id='banner'>
    Sistem Informasi Pembuatan KK</div>
<div id='konten'>
<div id='login'>
<div id='lingkaran'>
</div>
<table>
<tbody>
<tr>
<td><asp:TextBox ID="tbUser" runat="server" class="text" placeholder="Username" style="margin-top: 16px;" required="required"></asp:TextBox></td>
</tr>

<tr>
<td><asp:TextBox ID="tbPass" runat="server" class="text" placeholder="Password" required="required" TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
<td ><asp:Button ID="btLogin" runat="server" Text="Login"  class="submit" /></td>
</tr>
</tbody>
</table>
</center>
</div>
</div>
</div>
    </div>
    </form>
</body>
</html>
