Imports System.Data.SqlClient

Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim conn As SqlConnection = Nothing
    Dim constr As String = ConfigurationManager.ConnectionStrings("SQLSvrConnect").ConnectionString
    Dim nikKK As String
    Dim jenkel As String
    Dim status(), newStatus As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("login") Is Nothing Then
            'lompat ke default.aspx
            Response.Redirect("Login.aspx")
        End If
        Dim nk As String = Request.Params("nk")
        Try
            Dim sql As String = "select No_KK,NIK_Kepala_Keluarga,Alamat,Kode_Pos,Rt_Rw,Kecamatan,Kabupaten,Provinsi,Tanggal_Pembuatan,Desa_Kelurahan from KK where No_KK='" & nk & "'"
            conn = New SqlConnection(constr)
            conn.Open()
            Dim cmd As SqlCommand = Nothing
            cmd = New SqlCommand(sql, conn)
            '#5 Eksekusi command
            Dim reader As SqlDataReader = Nothing
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                lbNoKK.Text = reader.GetInt64(0)
                nikKK = CStr(reader.GetInt64(1))
                lbAlamat.Text = reader.GetString(2)
                lbKodePos.Text = reader.GetString(3)
                lbRtRw.Text = reader.GetString(4)
                lbKecamatan.Text = reader.GetString(5)
                lbKabupaten.Text = reader.GetString(6)
                lbProvinsi.Text = reader.GetString(7)
                lbTglPemb.Text = reader.GetString(8)
                lbDesa.Text = reader.GetString(9)

            End If
            reader.Close()

            sql = "select * from penduduk where NIK='" & nikKK & "'"
            conn = New SqlConnection(constr)
            conn.Open()
            cmd = Nothing
            cmd = New SqlCommand(sql, conn)
            '#5 Eksekusi command
            reader = Nothing
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If reader.GetString(4) = "L" Then
                    jenkel = "Laki-Laki"
                End If
                If reader.GetString(4) = "P" Then
                    jenkel = "Perempuan"
                End If
                lbNamakk.Text = reader.GetString(1)
                lbnewKK.Text = reader.GetString(1)
                dKepalaKK.Text = "<td class='nover'>1</td><td class='upercase'>" & reader.GetString(1) & "</td><td class='upercase'>" & nikKK & "</td><td class='upercase'>" & jenkel & "</td><td class='upercase'>" & reader.GetString(2) & "</td><td class='upercase'>" & reader.GetString(3) & "</td><td class='upercase'>" & reader.GetString(9) & "</td><td class='upercase'>" & reader.GetString(8) & "</td><td class='upercase'>" & reader.GetString(6) & "</td>"
                dHubKK.Text = "<td class='nover'>1</td><td class='upercase'>" & reader.GetString(10) & "</td><td class='upercase'>Kepala Keluarga</td><td class='upercase'>" & reader.GetString(7) & "</td><td class='upercase'>" & reader.GetString(11) & "</td><td class='upercase'>" & reader.GetString(12) & "</td><td class='upercase'>" & reader.GetString(13) & "</td><td class='upercase'>" & reader.GetString(14) & "</td>"
            End If
            reader.Close()
            sql = "Select Detail_KK.NIK,Penduduk.NIK,Nama_Penduduk,Tempat_Lahir,Tanggal_Lahir,Jenis_Kelamin,Alamat,Pekerjaan,Kewarganegaraan,Pendidikan_Terakhir,Agama,Status_Perkawinan,No_Paspor,No_Kitap,Nama_Ayah,Nama_Ibu,Ket,Status_Hub from Detail_KK,Penduduk where No_KK = '" & nk & "'  AND Penduduk.NIK = Detail_KK.NIK order by Status_Hub asc"
            conn = New SqlConnection(constr)
            conn.Open()
            cmd = Nothing
            cmd = New SqlCommand(sql, conn)
            '#5 Eksekusi command
            reader = Nothing
            reader = cmd.ExecuteReader()
            Dim index As Integer = 1
            Dim s As Integer
            If reader.HasRows Then

                Dim tbl As String = "<tbody>" & vbCrLf
                Dim tblHub As String = "<tbody>" & vbCrLf
                Do While reader.Read()
                    If reader.GetString(5) = "L" Then
                        jenkel = "Laki-Laki"
                    End If
                    If reader.GetString(5) = "P" Then
                        jenkel = "Perempuan"
                    End If
                    index += 1
                    tbl = tbl & "<tr>" & vbCrLf
                    tbl = tbl & "<td class='nover'>" & index & "</td>" & vbCrLf
                    tbl = tbl & "<td class='upercase'>" & reader.GetString(2) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='upercase'>" & reader.GetInt64(1) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='upercase'>" & jenkel & "</td>" & vbCrLf
                    tbl = tbl & "<td class='upercase'>" & reader.GetString(3) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='upercase'>" & reader.GetString(4) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='upercase'>" & reader.GetString(10) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='upercase'>" & reader.GetString(9) & "</td>" & vbCrLf
                    tbl = tbl & "<td class='upercase'>" & reader.GetString(7) & "</td>" & vbCrLf
                    tbl = tbl & "</tr>"
                    'data detail status hub
                    tblHub = tblHub & "<tr>" & vbCrLf
                    tblHub = tblHub & "<td class='nover'>" & index & "</td>" & vbCrLf
                    tblHub = tblHub & "<td class='upercase'>" & reader.GetString(11) & "</td>" & vbCrLf
                    status = Split(reader.GetString(17), "-")
                    newStatus = status(1)
                    tblHub = tblHub & "<td class='upercase'>" & newStatus & "</td>" & vbCrLf
                    tblHub = tblHub & "<td class='upercase'>" & reader.GetString(8) & "</td>" & vbCrLf
                    tblHub = tblHub & "<td class='upercase'>" & reader.GetString(12) & "</td>" & vbCrLf
                    tblHub = tblHub & "<td class='upercase'>" & reader.GetString(13) & "</td>" & vbCrLf
                    tblHub = tblHub & "<td class='upercase'>" & reader.GetString(14) & "</td>" & vbCrLf
                    tblHub = tblHub & "<td class='upercase'>" & reader.GetString(15) & "</td>" & vbCrLf
                    tblHub = tblHub & "</tr>"

                Loop
               
                tbl = tbl & "</tbody>"
                tblHub = tblHub & "</tbody>"
                dPddk.Text = tbl
                dHubPd.Text = tblHub
                reader.Close()
            End If
            reader.Close()
            conn.Close()
        Catch ex As Exception
            Response.Write("Ada Error:" & ex.Message)
        End Try
    End Sub

    Private Sub WebForm1_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Try
            '#8 Menutup Koneksi
            conn.Close()
        Catch ex As SqlException
            Response.Write("<script>alert('Ada kesalahan koneksi Database (error: " & ex.ErrorCode & ")!')</script>")
        End Try
    End Sub
End Class