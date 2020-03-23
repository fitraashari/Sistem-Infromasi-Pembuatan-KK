Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '---Tambahkan potongan script berikut pada file-file lain ---
        '---kopikan di event Page_Load() ----------------------------
        If Session("login") Is Nothing Then
            'lompat ke default.aspx
            Response.Redirect("Login.aspx")
        End If
        Dim log As New CekLogin
        log = Session("login")
        Label1.Text = "<center><h1>Selamat datang " & log.nama & " Anda Adalah " & log.lvl & "</h1><h2>Sistem Informasi Pembuatan KK</h2></center>"
        '---- sampai disini ------------------------------------------

        If IsPostBack = False Then
            If Request.QueryString("page") <> String.Empty Then
                If Request.QueryString("page") = "penduduk" Then
                    Label1.Text = "<iframe src='/List_Penduduk.aspx'><p>Your browser does not support iframes.</p></iframe>"
                End If
                If Request.QueryString("page") = "d_kk" Then
                    Label1.Text = "<iframe src='/List_Detail_KK.aspx'><p>Your browser does not support iframes.</p></iframe>"
                End If
                If Request.QueryString("page") = "kk" Then
                    Label1.Text = "<iframe src='/List_KK.aspx'><p>Your browser does not support iframes.</p></iframe>"
                End If
            End If
        End If
    End Sub

    Private Sub _Default_Unload(sender As Object, e As EventArgs) Handles Me.Unload

    End Sub
End Class