Imports System.Data.SqlClient

Public Class Entry_Status
    Inherits System.Web.UI.Page
    '#1 Deklarasi obyek Koneksi
    Dim conn As SqlConnection = Nothing
    Dim conStr As String = ""
    '#4 Mendeklarasikan Obyek Command
    Dim cmd As SqlCommand = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("login") Is Nothing Then
            'lompat ke default.aspx
            Response.Redirect("Login.aspx")
        End If
        Try
            '#2 Obyek Koneksi
            conStr = ConfigurationManager.ConnectionStrings("SQLSvrConnect").ConnectionString
            conn = New SqlConnection(conStr)

            '#3 Membuka Koneksi/Mengaktifkan Koneksi
            conn.Open()
        Catch ex As SqlException
            Response.Write("Ada kesalahan koneksi Database (error: " & ex.ErrorCode & ")!")
            Exit Sub
        End Try
        If IsPostBack = False Then
            If Request.QueryString("status") <> String.Empty Then
                If Request.QueryString("status") = "berhasil" Then
                    Response.Write("<script>alert('Simpan Data Berhasil')</script>")
                End If

            End If
        End If
    End Sub

    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            '#5 Menciptakan Obyek Command
            cmd = New SqlCommand()
            cmd.Connection = conn
            '#6 Mengeksekusi Perintah SQL
            Dim sql As String = "INSERT INTO Status_Hubungan(Kode_Status,Status_Hub_Dlm_Klrg) VALUES('" & tbKodest.Text & "','" & tbSthb.Text & "')"
            Dim jmlRecord As Integer = 0
            Response.Write(sql)
            cmd.CommandText = sql
            jmlRecord = cmd.ExecuteNonQuery

            '#7 Menampilkan Hasil Eksekusi
            If jmlRecord > 0 Then
                Response.Redirect("Entry_Status.aspx?status=berhasil")
            Else
                Response.Write("<script>alert('Simpan Data Gagal')</script>")
            End If
        Catch ex As SqlException
            Response.Write("<script>alert('Simpan Data Gagal')</script>")
            Response.Write("<script>alert('Ada kesalahan dari Database, Proses simpan dibatalkan (error: " & ex.ErrorCode & ")!')</script>")
            Exit Sub

        End Try
    End Sub

    Private Sub Entry_Status_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Try
            '#8 Menutup Koneksi
            conn.Close()
        Catch ex As SqlException
            Response.Write("Ada kesalahan koneksi Database (error: " & ex.ErrorCode & ")!")
        End Try
    End Sub
End Class