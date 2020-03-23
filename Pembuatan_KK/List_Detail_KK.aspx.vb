Imports System.Data.SqlClient

Public Class List_Detail_KK
    Inherits System.Web.UI.Page
    '#1 Deklarasi obyek Koneksi
    Dim conn As SqlConnection = Nothing
    Dim conStr As String = ""
    '#4 Mendeklarasikan Obyek Command
    Dim cmd As SqlCommand = Nothing
    Dim status(), newStatus As String
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
    End Sub

    Protected Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        If tbKK.Text <> String.Empty Then
            Try                
                '#6 Mengeksekusi Perintah SQL
                Dim sql As String = "select Detail_KK.NIK,Nama_Penduduk,Status_Hub from Detail_KK,Penduduk where Detail_KK.NIK = Penduduk.NIK AND No_KK = '" & tbKK.Text & "' order by Status_Hub Asc"
                conn = New SqlConnection(conStr)
                conn.Open()

                '#4 deklarasikan dan buat obyek Command
                Dim cmd As SqlCommand = Nothing
                cmd = New SqlCommand(sql, conn)

                '#5 Eksekusi command
                Dim reader As SqlDataReader = Nothing
                reader = cmd.ExecuteReader()

                '#7 Menampilkan Hasil Eksekusi
                If reader.HasRows Then
                    Dim tbl As String = "<table class='list'>" & vbCrLf
                    tbl = tbl & "<tr class='list'>" & vbCrLf
                    tbl = tbl & "<th class='list'>NIK</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Nama Penduduk</th>" & vbCrLf
                    tbl = tbl & "<th class='list'>Status Hubungan Dalam Keluarga</th>" & vbCrLf
                    tbl = tbl & "<th colspan='3' class='list'>Aksi</th>" & vbCrLf
                    tbl = tbl & "</tr>"
                    Do While reader.Read
                        lbdata.Text = ""
                        status = Split(reader.GetString(2), "-")
                        newStatus = status(1)
                        tbl = tbl & "<tr class='list'>"
                        tbl = tbl & "<td class='list'>" & reader.GetInt64(0) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & reader.GetString(1) & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'>" & newStatus & "</td>" & vbCrLf
                        tbl = tbl & "<td class='list'><a href='Delete_Detail_KK.aspx?nik=" & reader.GetInt64(0) & "'><img src='delete.png' height='20' width='20'>Delete</a></td>" & vbCrLf
                        tbl = tbl & "</tr>" & vbCrLf
                    Loop
                    tbl = tbl & "</table>"
                    lbdata.Text = tbl
                    reader.Close()
                Else
                    lbdata.Text = "KK Belum Memiliki Anggota Keluarga"
                End If
                '#6 Mengeksekusi Perintah SQL
                sql = "SELECT KK.No_KK,Nama_Penduduk,KK.Alamat,Kode_Pos,Rt_Rw,Kecamatan,Kabupaten,Provinsi,Tanggal_Pembuatan,Desa_Kelurahan FROM KK,Penduduk where KK.NIK_Kepala_Keluarga = Penduduk.NIK AND KK.No_KK ='" & tbKK.Text & "'"
                conn = New SqlConnection(conStr)
                conn.Open()

                '#4 deklarasikan dan buat obyek Command
                cmd = Nothing
                cmd = New SqlCommand(sql, conn)

                '#5 Eksekusi command
                reader = Nothing
                reader = cmd.ExecuteReader()

                '#7 Menampilkan Hasil Eksekusi
                If reader.HasRows Then
                    lbdatakk.Text = ""
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
                        tbl = tbl & "<td class='list'><a href='Print_KK.aspx?nk=" & reader.GetInt64(0) & "' target='_blank'><img src='print.png' height='20' width='20'>Print</a></td></a></td>" & vbCrLf
                        tbl = tbl & "</tr>" & vbCrLf
                    Loop
                    tbl = tbl & "</table>"
                    lbdatakk.Text = tbl
                    reader.Close()
                    conn.Close()
                Else
                    lbdatakk.Text = "Data Masih Kosong"
                End If
            Catch ex As SqlException
                lbdatakk.Text = "Ada kesalahan koneksi Database (error: " & ex.ErrorCode & ")!"
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub List_Detail_KK_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Try
            '#8 Menutup Koneksi
            conn.Close()
        Catch ex As SqlException
            lbdata.Text = "Ada kesalahan koneksi Database (error: " & ex.ErrorCode & ")!"
        End Try
    End Sub
End Class