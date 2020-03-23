<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Delete_Penduduk.aspx.vb" Inherits="Pembuatan_KK.Delete_Penduduk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="delete.css" />
</head>
<body onload="myFunction()" style="margin:0;">
    <form id="form1" runat="server">
          
        
       <div>
        <div style="display:none;" id="myDiv" class="animate-bottom">
            <div class="modal-dialog">
                <div class="modal-header">
                    <h2>Yakin ini menghapus data?</h2>
                   
                </div>
                <div class="modal-body">
                    <p>Data yang telah di hapus tidak dapat dikembalikan lagi</p>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnYa" runat="server" Text="Ya" class="btn"/>
                &nbsp;&nbsp;<asp:Button ID="btnTidak" runat="server" Text="Tidak" class="btn"/>
<script>$(document).ready(function () {
    $('.modal').addClass('loaded');
});</script>
                </div>
            </div></div>
        </div>
    <script>
        var myVar;

        function myFunction() {
            myVar = setTimeout(showPage, 0);
        }

        function showPage() {

            document.getElementById("myDiv").style.display = "block";
        }
</script>
    </form>
</body>
</html>
