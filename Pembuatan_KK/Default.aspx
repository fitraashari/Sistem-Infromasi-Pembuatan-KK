<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Pembuatan_KK._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistem Informasi Pembuatan KK</title>
    <style>
iframe{
width: 100%;
height: 700px;
border: 0px;
overflow: scroll;

}
body {
    margin: 0;
}

ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    width: 14%;
    background-color: #f1f1f1;
    position: fixed;
    height: 100%;
    overflow: auto;
    border-right: 2px solid #4CAF50;
}

li a {
    display: block;
    color: #000;
    padding: 8px 16px;
    text-decoration: none;
    font-size: 110%;
    font-family: Verdana, Geneva, sans-serif;
}

li a.active {
    background-color: #4CAF50;
    color: white;
}

li a:hover:not(.active) {
    background-color: #555;
    color: white;
}
#loader {
  position: absolute;
  left: 50%;
  top: 50%;
  z-index: 1;
  width: 150px;
  height: 150px;
  margin: -75px 0 0 -75px;
  border: 16px solid #f3f3f3;
  border-radius: 50%;
     border-top: 16px solid #4CAF50;
 border-bottom: 16px solid #4CAF50;
  width: 120px;
  height: 120px;
  -webkit-animation: spin 2s linear infinite;
  animation: spin 2s linear infinite;
}

@-webkit-keyframes spin {
  0% { -webkit-transform: rotate(0deg); }
  100% { -webkit-transform: rotate(360deg); }
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}

/* Add animation to "page content" */
.animate-bottom {
  position: relative;
  -webkit-animation-name: animatebottom;
  -webkit-animation-duration: 1s;
  animation-name: animatebottom;
  animation-duration: 1s
}

@-webkit-keyframes animatebottom {
  from { bottom:-100px; opacity:0 }
  to { bottom:0px; opacity:1 }
}

@keyframes animatebottom {
  from{ bottom:-100px; opacity:0 }
  to{ bottom:0; opacity:1 }
}

#myDiv {
  display: none;
  text-align: center;
}
</style>
</head>
<body onload="myFunction()" style="margin:0;">
    <form id="form1" runat="server">
    <div>
    <ul>
  <li><a class="active" href="Default.aspx"><img src="home.png" height="30" width="30">»Home</a></li>
  <li><a href="?page=penduduk"><img src="data.png" height="30" width="30">»Penduduk</a></li>
  <li><a href="?page=kk"><img src="data.png" height="30" width="30">»KK</a></li>
  <li><a href="?page=d_kk"><img src="data.png" height="30" width="30">»Detail KK</a></li>
        <li><a class="active" href="Logout.aspx" style="margin-top:420px"><img src="logout.png" height="30" width="30">»Logout</a></li>
</ul>

<div style="margin-left:14%;padding:1px 1px;height:700px;"> 
    <div id="loader"></div><div style="display:none;" id="myDiv" class="animate-bottom">
        <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>

<script>
    var myVar;

    function myFunction() {
        myVar = setTimeout(showPage, 100);
    }

    function showPage() {
        document.getElementById("loader").style.display = "none";
        document.getElementById("myDiv").style.display = "block";
    }
</script>
   </div>
    </div>
    </form>
</body>
</html>
