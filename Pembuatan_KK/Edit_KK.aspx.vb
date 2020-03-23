Imports System.Data.SqlClient

Public Class Edit_KK
    Inherits System.Web.UI.Page
    Dim conn As SqlConnection = Nothing
    Dim constr As String = ConfigurationManager.ConnectionStrings("SQLSvrConnect").ConnectionString
    Dim tglPemb(), newtglPemb, RtRw(), NewRtRw As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("login") Is Nothing Then
            'lompat ke default.aspx
            Response.Redirect("Login.aspx")
        End If
        If Not IsPostBack Then
            Dim nk As String = Request.Params("nk")
            Try
                Dim sql As String = "SELECT NIK,Nama_Penduduk FROM Penduduk except SELECT Penduduk.NIK,Nama_Penduduk FROM Penduduk,KK,Detail_KK where Penduduk.NIK = Detail_KK.NIK"
                conn = New SqlConnection(constr)
                conn.Open()
                Dim cmd As SqlCommand = Nothing
                cmd = New SqlCommand(sql, conn)
                '#5 Eksekusi command
                Dim reader As SqlDataReader = Nothing
                reader = cmd.ExecuteReader()
                If reader.HasRows Then

                    Do While reader.Read()
                        ddNIK.Items.Add(New ListItem(reader.GetInt64(0) & " | " & reader.GetString(1), reader.GetInt64(0)))
                    Loop
                End If
                reader.Close()
                '#2 Biat perintah sql ambil 
                sql = "Select * from KK where No_KK='" & nk & "'"
                '#3 Buat Koneksi dan aktifkan
                conn = New SqlConnection(constr)
                conn.Open()
                '#4 deklarasikan dan buat objek command
                cmd = Nothing
                cmd = New SqlCommand(sql, conn)
                '#5 Eksekusi command
                reader = Nothing
                reader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    tbNoKK.Text = reader.GetInt64(0)
                    ddNIK.Text = reader.GetInt64(1)
                    tbAlamat.Text = reader.GetString(2)
                    tbKodePos.Text = reader.GetString(3)
                    RtRw = Split(reader.GetString(4), "/")
                    tbRT.Text = RtRw(0)
                    tbRW.Text = RtRw(1)
                    tbDesa.Text = reader.GetString(5)
                    tbKecamatan.Text = reader.GetString(6)
                    tbKabupaten.Text = reader.GetString(7)
                    tbProvinsi.Text = reader.GetString(8)
                    tglPemb = Split(reader.GetString(9), "-")
                    tbtglPemb.Text = tglPemb(2) & "-" & tglPemb(1) & "-" & tglPemb(0)
                End If
                reader.Close()
                conn.Close()
            Catch ex As Exception
                Response.Write("Ada Error:" & ex.Message)
            End Try
        End If
    End Sub

    Protected Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Response.Redirect("List_KK.aspx")
    End Sub

    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click

        conn = New SqlConnection(constr)
        conn.Open()
        tglPemb = Split(tbtglPemb.Text, "-")
        newtglPemb = tglPemb(2) & "-" & tglPemb(1) & "-" & tglPemb(0)
        NewRtRw = tbRT.Text & "/" & tbRW.Text
        Dim sql As String = "Update KK set No_KK='" & tbNoKK.Text & "',NIK_Kepala_Keluarga='" & ddNIK.Text & "',Alamat='" & tbAlamat.Text & "',Kode_Pos='" & tbKodePos.Text & "',Rt_Rw='" & NewRtRw & "',Desa_Kelurahan='" & tbDesa.Text & "',Kecamatan='" & tbKecamatan.Text & "',Kabupaten='" & tbKabupaten.Text & "',Provinsi='" & tbProvinsi.Text & "',Tanggal_Pembuatan='" & newtglPemb & "' where No_KK='" & Request.Params("nk") & "'"
        Dim Cmd As SqlCommand = New SqlCommand(sql, conn)

        If Cmd.ExecuteNonQuery Then
            Response.Redirect("List_KK.aspx?status=berhasil")
        Else
            Response.Redirect("List_KK.aspx?status=gagal")
        End If
    End Sub
End Class