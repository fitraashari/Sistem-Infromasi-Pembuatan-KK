Imports System.Data.SqlClient

Public Class Edit_Penduduk
    Inherits System.Web.UI.Page
    Dim conn As SqlConnection = Nothing
    Dim constr As String = ConfigurationManager.ConnectionStrings("SQLSvrConnect").ConnectionString
    Dim jenkel, ket, tglLhr(), newTgllhr, paspor, kitap As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("login") Is Nothing Then
            'lompat ke default.aspx
            Response.Redirect("Login.aspx")
        End If
        If Not IsPostBack Then
            Dim nik As String = Request.Params("nik")
            Try
                '#2 Biat perintah sql ambil 
                Dim sql As String = "Select Nama_Penduduk,Tempat_Lahir,Tanggal_Lahir,Jenis_Kelamin,Alamat,Pekerjaan,Kewarganegaraan,Pendidikan_Terakhir,Agama,Status_Perkawinan,No_Paspor,No_Kitap,Nama_Ayah,Nama_Ibu,Ket from Penduduk where NIK='" & nik & "'"
                '#3 Buat Koneksi dan aktifkan
                conn = New SqlConnection(constr)
                conn.Open()
                '#4 deklarasikan dan buat objek command
                Dim cmd As SqlCommand = Nothing
                cmd = New SqlCommand(sql, conn)
                '#5 Eksekusi command
                Dim reader As SqlDataReader = Nothing
                reader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    tbnik.Text = nik
                    tbnama.Text = reader.GetString(0)
                    tbtemplhr.Text = reader.GetString(1)
                    tglLhr = Split(reader.GetString(2), "-")
                    tbtgllhr.Text = tglLhr(2) & "-" & tglLhr(1) & "-" & tglLhr(0)
                    If reader.GetString(3) = "L" Then
                        rbLaki.Checked = True
                    End If
                    If reader.GetString(3) = "P" Then
                        rbPerempuan.Checked = True
                    End If
                    tbAlamat.Text = reader.GetString(4)
                    ddPekerjaan.Text = reader.GetString(5)
                    ddNegara.Text = reader.GetString(6)
                    ddPendididkan.Text = reader.GetString(7)
                    ddAgama.Text = reader.GetString(8)
                    ddStatus.Text = reader.GetString(9)
                    tbPaspor.Text = reader.GetString(10)
                    tbKitap.Text = reader.GetString(11)
                    tbAyah.Text = reader.GetString(12)
                    tbIbu.Text = reader.GetString(13)
                    tbket.Text = reader.GetString(14)
                End If
                reader.Close()
                conn.Close()
            Catch ex As Exception
                Response.Write("Ada Error:" & ex.Message)
            End Try
        End If
    End Sub

    Protected Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Response.Redirect("List_Penduduk.aspx")
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click

        conn = New SqlConnection(constr)
        conn.Open()
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
        Dim sql As String = "Update Penduduk set NIK='" & tbnik.Text & "',Nama_Penduduk='" & tbnama.Text & "',Tempat_Lahir='" & tbtemplhr.Text & "',Tanggal_Lahir='" & newTgllhr & "',Jenis_Kelamin='" & jenkel & "',Alamat='" & tbAlamat.Text & "',Pekerjaan='" & ddPekerjaan.Text & "',Kewarganegaraan='" & ddNegara.Text & "',Pendidikan_Terakhir='" & ddPendididkan.Text & "',Agama='" & ddAgama.Text & "',Status_Perkawinan='" & ddStatus.Text & "',No_Paspor='" & paspor & "',No_Kitap='" & kitap & "',Nama_Ayah='" & tbAyah.Text & "',Nama_Ibu='" & tbIbu.Text & "',Ket='" & ket & "' where NIK='" & tbnik.Text & "'"
        Dim Cmd As SqlCommand = New SqlCommand(sql, conn)

        If Cmd.ExecuteNonQuery Then
            Response.Redirect("List_Penduduk.aspx?status=berhasil")
        Else
            Response.Redirect("List_Penduduk.aspx?status=gagal")
        End If

    End Sub

    Private Sub Edit_Penduduk_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        'tutup koneksi
        Try
            conn.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class