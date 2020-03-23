Imports System.Data.SqlClient

Public Class Entry_Penduduk
    Inherits System.Web.UI.Page
    Dim conn As SqlConnection = Nothing
    Dim conStr As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                If Request.QueryString("status") = "gagal" Then
                    Response.Write("<script>alert('Simpan Data Gagal')</script>")
                End If
            End If
        End If
    End Sub
    Dim jenkel, ket, tglLhr(), newTgllhr, paspor, kitap As String
    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If rbLaki.Checked = True Then
            jenkel = "L"
        End If
        If rbPerempuan.Checked = True Then
            jenkel = "P"
        End If
        If tbket.Text = String.Empty Then
            ket = "-"
        Else
            ket = tbket.Text
        End If
        If tbPaspor.Text = String.Empty Then
            paspor = "-"
        Else
            paspor = tbPaspor.Text
        End If
        If tbKitap.Text = String.Empty Then
            kitap = "-"
        Else
            kitap = tbKitap.Text
        End If
        tglLhr = Split(tbtgllhr.Text, "-")
        newTgllhr = tglLhr(2) & "-" & tglLhr(1) & "-" & tglLhr(0)

        '#4 Mendeklarasikan Obyek Command
        Dim cmd As SqlCommand = Nothing
        If jenkel = String.Empty Then
            Response.Write("<script>alert('Data Belum Lengkap')</script>")
        Else
            Try
                '#5 Menciptakan Obyek Command
                cmd = New SqlCommand()
                cmd.Connection = conn

                '#6 Mengeksekusi Perintah SQL
                Dim sql As String = "INSERT INTO Penduduk(NIK,Nama_Penduduk,Tempat_Lahir,Tanggal_Lahir,Jenis_Kelamin,Alamat,Pekerjaan,Kewarganegaraan,Pendidikan_Terakhir,Agama,Status_Perkawinan,No_Paspor,No_Kitap,Nama_Ayah,Nama_Ibu,Ket) VALUES('" & _
                 tbnik.Text & "','" & tbnama.Text & "','" & tbtemplhr.Text & "','" & newTgllhr & "','" & jenkel & "','" & tbAlamat.Text & "','" & ddPekerjaan.Text & "','" & ddNegara.Text & "','" & ddPendididkan.Text & "','" & ddAgama.Text & "','" & ddStatus.Text & "','" & paspor & "','" & kitap & "','" & tbAyah.Text & "','" & tbIbu.Text & "','" & ket & "')"
                Dim jmlRecord As Integer = 0
                cmd.CommandText = sql
                jmlRecord = cmd.ExecuteNonQuery
                Response.Write(sql)
                '#7 Menampilkan Hasil Eksekusi
                If jmlRecord > 0 Then
                    Response.Redirect("Entry_Penduduk.aspx?status=berhasil")
                Else

                    Response.Redirect("Entry_Penduduk.aspx?status=gagal")
                End If
            Catch ex As SqlException

                Response.Write("Ada kesalahan dari Database, Proses simpan dibatalkan (error: " & ex.ErrorCode & ")!")
                Exit Sub

            End Try
        End If
    End Sub

    Private Sub Entry_Penduduk_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Try
            '#8 Menutup Koneksi
            conn.Close()
        Catch ex As SqlException
            Response.Write("Ada kesalahan koneksi Database (error: " & ex.ErrorCode & ")!")
        End Try
    End Sub
End Class