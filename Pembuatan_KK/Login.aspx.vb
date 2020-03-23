Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btLogin_Click(sender As Object, e As EventArgs) Handles btLogin.Click
        If tbUser.Text <> "" And tbPass.Text <> "" Then
            Dim log As New CekLogin
            log.userid = tbUser.Text
            log.password = tbPass.Text
            If log.auth() = True Then
                'membuat session utk variabel objek login
                Session("login") = log
                'lompat ke menu utama
                Response.Redirect("Default.aspx")
            Else
                Response.Write("<script>alert('UserID dan Password tidak valid!')</script>")
            End If
        Else
            Response.Write("<script>alert('UserID dan Password tidak boleh kosong!')</script>")
        End If
    End Sub
End Class