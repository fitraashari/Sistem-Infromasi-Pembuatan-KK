Imports System.Data.SqlClient

Public Class KK
    Inherits System.Web.UI.Page
    Dim conn As SqlConnection = Nothing
    Dim conStr As String = ""
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
            Dim sql As String = "SELECT NIK,Nama_Penduduk FROM Penduduk except SELECT Penduduk.NIK,Nama_Penduduk FROM Penduduk,KK,Detail_KK where Penduduk.NIK = kk.NIK_Kepala_Keluarga OR Penduduk.NIK = Detail_KK.NIK"
            conn = New SqlConnection(conStr)
            conn.Open()
            Dim cmd As SqlCommand = Nothing
            cmd = New SqlCommand(sql, conn)
            '#5 Eksekusi command
            Dim reader As SqlDataReader = Nothing
            reader = cmd.ExecuteReader()
            ddNIK.Items.Clear()                 ' <=== #1
            If reader.HasRows Then

                Do While reader.Read()
                    ddNIK.Items.Add(New ListItem(reader.GetInt64(0) & " | " & reader.GetString(1), reader.GetInt64(0)))
                Loop
            End If
            reader.Close()
        Catch ex As SqlException
            Response.Write("Ada kesalahan koneksi Database (error: " & ex.ErrorCode & ")!")
            Exit Sub
        End Try
        If IsPostBack = False Then
            If Request.QueryString("status") <> String.Empty Then
                If Request.QueryString("status") = "berhasil" Then
                    Response.Write("<script>alert('Simpan Data Berhasil')</script>")
                End If
                If Request.QueryString("status") = "gagal" Then
                    Response.Write("<script>alert('Simpan Data Gagal')</script>")
                End If
            End If
        End If
    End Sub
    Dim tglPemb(), newtglPemb, RtRw As String
    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        tglPemb = Split(tbtglPemb.Text, "-")
        newtglPemb = tglPemb(2) & "-" & tglPemb(1) & "-" & tglPemb(0)
        Try
            Dim cmd As SqlCommand = Nothing
            '#5 Menciptakan Obyek Command
            cmd = New SqlCommand()
            cmd.Connection = conn
            RtRw = tbRT.Text & "/" & tbRW.Text
            '#6 Mengeksekusi Perintah SQL
            Dim sql As String = "INSERT INTO KK(No_KK,NIK_Kepala_Keluarga,Alamat,Kode_Pos,Rt_Rw,Desa_Kelurahan,Kecamatan,Kabupaten,Provinsi,Tanggal_Pembuatan) VALUES('" & _
             tbNoKK.Text & "','" & ddNIK.Text & "','" & tbAlamat.Text & "','" & tbKodePos.Text & "','" & RtRw & "','" & tbDesa.Text & "','" & tbKecamatan.Text & "','" & tbKabupaten.Text & "','" & tbProvinsi.Text & "','" & newtglPemb & "')"
            Dim jmlRecord As Integer = 0
            cmd.CommandText = sql
            jmlRecord = cmd.ExecuteNonQuery

            '#7 Menampilkan Hasil Eksekusi
            If jmlRecord > 0 Then
                Response.Redirect("Entry_KK.aspx?status=berhasil")
            Else
                Response.Redirect("Entry_KK.aspx?status=gagal")

            End If
        Catch ex As SqlException
            Response.Redirect("Entry_KK.aspx?status=gagal")
            Response.Write("Ada kesalahan dari Database, Proses simpan dibatalkan (error: " & ex.ErrorCode & ")!")
            Exit Sub

        End Try
    End Sub
End Class