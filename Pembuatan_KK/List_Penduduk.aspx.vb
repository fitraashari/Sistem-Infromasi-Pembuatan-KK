Imports System.Data.SqlClient

Public Class List_Penduduk
    Inherits System.Web.UI.Page
    '#1 Deklarasi obyek Koneksi
    Dim conn As SqlConnection = Nothing
    Dim conStr As String = ""
    '#4 Mendeklarasikan Obyek Command
    Dim cmd As SqlCommand = Nothing
    Private Sub tampilData()
        Try
            '#6 Mengeksekusi Perintah SQL
            Dim sql As String = "SELECT * FROM Penduduk order by NIK asc"

            cmd.CommandText = sql
            Dim reader As SqlDataReader = Nothing
            reader = cmd.ExecuteReader


            '#7 Menampilkan Hasil Eksekusi
            If reader.HasRows Then
                Dim tbl As String = "<table class='list'>" & vbCrLf
                tbl = tbl & "<tr class='list'>" & vbCrLf
                tbl = tbl & "<th class='list'>NIK</th>" & vbCrLf
                tbl = tbl & "<th class='list'>NAMA Penduduk</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Tempat Lahir</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Tanggal Lahir</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Jenis Kelamin</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Alamat</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Pekerjaan</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Kewarganegaraan</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Pendidikan Terakhir</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Agama</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Status Perkawinan</th>" & vbCrLf
                tbl = tbl & "<th class='list'>No Paspor</th>" & vbCrLf
                tbl = tbl & "<th class='list'>No Kitap/Kitas</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Nama Ayah</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Nama Ibu</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Keterangan</th>" & vbCrLf
                tbl = tbl & "<th colspan='2' class='list'>Aksi</th>" & vbCrLf
                tbl = tbl & "</tr>"
                Do While reader.Read
                    tbl = tbl & "<tr class='list'>"
                    tbl = tbl & "<td class='list'>" & reader.GetInt64(0) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(1) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(2) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(3) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(4) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(5) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(6) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(7) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(8) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(9) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(10) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(11) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(12) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(13) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(14) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(15) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'><a href='Edit_Penduduk.aspx?nik=" & reader.GetInt64(0) & "'><img src='edit.png' height='20' width='20'>Edit</a></td>" & vbCrLf
                    tbl = tbl & "<td class='list'><a href='Delete_Penduduk.aspx?nik=" & reader.GetInt64(0) & "'><img src='delete.png' height='20' width='20'>Delete</a></td>" & vbCrLf
                    tbl = tbl & "</tr>" & vbCrLf
                Loop
                tbl = tbl & "</table>"
                lbdata.Text = tbl
                reader.Close()
            Else
                lbdata.Text = "data masih kosong"
            End If
        Catch ex As SqlException
            lbdata.Text = "Ada kesalahan koneksi Database (error: " & ex.ErrorCode & ")!"
            Exit Sub
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("login") Is Nothing Then
            'lompat ke default.aspx
            Response.Redirect("Login.aspx")
        End If
        '#2 Obyek Koneksi
        conStr = ConfigurationManager.ConnectionStrings("SQLSvrConnect").ConnectionString
        conn = New SqlConnection(conStr)

        '#3 Membuka Koneksi/Mengaktifkan Koneksi
        conn.Open()

        '#5 Menciptakan Obyek Command
        cmd = New SqlCommand()
        cmd.Connection = conn
        tampilData()
        If IsPostBack = False Then
            If Request.QueryString("status") <> String.Empty Then
                If Request.QueryString("status") = "berhasil" Then
                    Response.Write("<script>alert('Edit Data Berhasil')</script>")
                End If
                If Request.QueryString("status") = "gagal" Then
                    Response.Write("<script>alert('Edit Data Gagal')</script>")
                End If
            End If
        End If
    End Sub

    Private Sub List_Penduduk_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Try
            '#8 Menutup Koneksi
            conn.Close()
        Catch ex As SqlException
            lbdata.Text = "Ada kesalahan koneksi Database (error: " & ex.ErrorCode & ")!"
        End Try
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        If tbNik.Text <> String.Empty Then
            Try
                '#6 Mengeksekusi Perintah SQL
                Dim sql As String = "SELECT * FROM Penduduk where NIK='" & tbNik.Text & "'"

                cmd.CommandText = sql
                Dim reader As SqlDataReader = Nothing
                reader = cmd.ExecuteReader


                '#7 Menampilkan Hasil Eksekusi
                If reader.HasRows Then
                    Dim tbl As String = "<table class='list'>" & vbCrLf
                    tbl = tbl & "<tr class='list'>" & vbCrLf
                    tbl = tbl & "<th class='list'>NIK</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>NAMA Penduduk</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Tempat Lahir</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Tanggal Lahir</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Jenis Kelamin</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Alamat</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Pekerjaan</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Kewarganegaraan</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Pendidikan Terakhir</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Agama</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Status Perkawinan</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>No Paspor</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>No Kitap/Kitas</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Nama Ayah</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Nama Ibu</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Keterangan</th>" & vbCrLf
                    tbl = tbl & "<th colspan='2' class='list'>Aksi</th>" & vbCrLf
                    tbl = tbl & "</tr>"
                    Do While reader.Read
                        tbl = tbl & "<tr class='list'>"
                        tbl = tbl & "<td class='list'>" & reader.GetInt64(0) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(1) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(2) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(3) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(4) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(5) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(6) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(7) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(8) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(9) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(10) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(11) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(12) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(13) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(14) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(15) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'><a href='Edit_Penduduk.aspx?nik=" & reader.GetInt64(0) & "'><img src='edit.png' height='20' width='20'>Edit</a></td>" & vbCrLf
                        tbl = tbl & "<td class='list'><a href='Delete_Penduduk.aspx?nik=" & reader.GetInt64(0) & "'><img src='delete.png' height='20' width='20'>Delete</a></td>" & vbCrLf
                        tbl = tbl & "</tr>" & vbCrLf
                    Loop
                    tbl = tbl & "</table>"
                    lbdata.Text = tbl
                    reader.Close()
                Else
                    lbdata.Text = "data masih kosong"
                End If
            Catch ex As SqlException
                lbdata.Text = "Ada kesalahan koneksi Database (error: " & ex.ErrorCode & ")!"
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub btAlldata_Click(sender As Object, e As EventArgs) Handles btAlldata.Click
        tampilData()
    End Sub
End Class