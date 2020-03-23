Imports System.Data.SqlClient

Public Class List_KK
    Inherits System.Web.UI.Page
    '#1 Deklarasi obyek Koneksi
    Dim conn As SqlConnection = Nothing
    Dim conStr As String = ""
    '#4 Mendeklarasikan Obyek Command
    Dim cmd As SqlCommand = Nothing
    Private Sub tampilData()
        Try
            '#6 Mengeksekusi Perintah SQL
            Dim sql As String = "SELECT KK.No_KK,Nama_Penduduk,KK.Alamat,Kode_Pos,Rt_Rw,Kecamatan,Kabupaten,Provinsi,Tanggal_Pembuatan,Desa_Kelurahan FROM KK,Penduduk where KK.NIK_Kepala_Keluarga = Penduduk.NIK "

            cmd.CommandText = sql
            Dim reader As SqlDataReader = Nothing
            reader = cmd.ExecuteReader


            '#7 Menampilkan Hasil Eksekusi
            If reader.HasRows Then
                Dim tbl As String = "<table class='list'>" & vbCrLf
                tbl = tbl & "<tr class='list'>" & vbCrLf
                tbl = tbl & "<th class='list'>No KK</th>" & vbCrLf
                tbl = tbl & "<th class='list'>NAMA Kepala Keluarga</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Alamat KK</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Kode Pos</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Rt_Rw</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Desa/Kelurahan</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Kecamatan</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Kabupaten</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Provinsi</th>" & vbCrLf
                tbl = tbl & "<th class='list'>Tanggal Pembuatan</th>" & vbCrLf
                tbl = tbl & "<th colspan='3' class='list'>Aksi</th>" & vbCrLf
                tbl = tbl & "</tr>"
                Do While reader.Read
                    tbl = tbl & "<tr class='list'>"
                    tbl = tbl & "<td class='list'>" & reader.GetInt64(0) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(1) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(2) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(3) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(4) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(9) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(5) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(6) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(7) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'>" & reader.GetString(8) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='list'><a href='Edit_KK.aspx?nk=" & reader.GetInt64(0) & "'><img src='edit.png' height='20' width='20'>Edit</a></td>" & vbCrLf
                    tbl = tbl & "<td class='list'><a href='Delete_KK.aspx?nk=" & reader.GetInt64(0) & "'><img src='delete.png' height='20' width='20'>Delete</a></td>" & vbCrLf

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

    Protected Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        If tbKK.Text <> String.Empty Then
            Try
                '#6 Mengeksekusi Perintah SQL
                Dim sql As String = "SELECT KK.No_KK,Nama_Penduduk,KK.Alamat,Kode_Pos,Rt_Rw,Kecamatan,Kabupaten,Provinsi,Tanggal_Pembuatan,Desa_Kelurahan FROM KK,Penduduk where KK.NIK_Kepala_Keluarga = Penduduk.NIK AND KK.No_KK ='" & tbKK.Text & "'"

                cmd.CommandText = sql
                Dim reader As SqlDataReader = Nothing
                reader = cmd.ExecuteReader


                '#7 Menampilkan Hasil Eksekusi
                If reader.HasRows Then
                    Dim tbl As String = "<table class='list'>" & vbCrLf
                    tbl = tbl & "<tr class='list'>" & vbCrLf
                    tbl = tbl & "<th class='list'>No KK</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>NAMA Kepala Keluarga</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Alamat KK</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Kode Pos</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Rt_Rw</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Desa/Kelurahan</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Kecamatan</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Kabupaten</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Provinsi</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Tanggal Pembuatan</th>" & vbCrLf
                    tbl = tbl & "<th colspan='3' class='list'>Aksi</th>" & vbCrLf
                    tbl = tbl & "</tr>"
                    Do While reader.Read
                        tbl = tbl & "<tr class='list'>"
                        tbl = tbl & "<td class='list'>" & reader.GetInt64(0) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(1) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(2) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(3) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(4) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(9) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(5) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(6) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(7) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(8) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'><a href='Edit_KK.aspx?nk=" & reader.GetInt64(0) & "'><img src='edit.png' height='20' width='30'>Edit</a></td>" & vbCrLf
                        tbl = tbl & "<td class='list'><a href='Delete_KK.aspx?nk=" & reader.GetInt64(0) & "'><img src='delete.png' height='20' width='30'>Delete</a></td>" & vbCrLf
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

    Protected Sub btAlldata_Click(sender As Object, e As EventArgs) Handles btAlldata.Click
        tampilData()
    End Sub

    Private Sub List_KK_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Try
            '#8 Menutup Koneksi
            conn.Close()
        Catch ex As SqlException
            lbdata.Text = "Ada kesalahan koneksi Database (error: " & ex.ErrorCode & ")!"
        End Try
    End Sub
End Class