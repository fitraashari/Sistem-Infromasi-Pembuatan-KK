Imports System.Data.SqlClient

Public Class Detail_KK
    Inherits System.Web.UI.Page
    Dim conn As SqlConnection = Nothing
    Dim constr As String = _
        ConfigurationManager.ConnectionStrings("SQLSvrConnect").ConnectionString
    Dim ListPdd As New List(Of Penduduk)()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("login") Is Nothing Then
            'lompat ke default.aspx
            Response.Redirect("Login.aspx")
        End If
        If Not IsPostBack Then
            'buat session baru utk variabel ListMK dg nama 'kk'
            Session("kk") = ListPdd

            Try
                '#2 Buat perintah sql untuk ambil nama dan prodi
                Dim sql As String = _
                    "Select No_KK,Nama_Penduduk from KK,Penduduk where NIK_Kepala_Keluarga = Penduduk.NIK"

                '#3 buat obyek koneksi dan aktifkan koneksi
                conn = New SqlConnection(constr)
                conn.Open()

                '#4 deklarasikan dan buat obyek Command
                Dim cmd As SqlCommand = Nothing
                cmd = New SqlCommand(sql, conn)

                '#5 Eksekusi command
                Dim reader As SqlDataReader = Nothing
                reader = cmd.ExecuteReader()
                ddKK.Items.Clear()                 ' <=== #1
                If reader.HasRows Then
                    ddKK.Items.Add("===No KK | Nama Kepala Keluarga==")
                    Do While reader.Read()
                        ddKK.Items.Add(New ListItem(reader.GetInt64(0) & " | " & reader.GetString(1), reader.GetInt64(0)))
                    Loop
                End If
                reader.Close()
                
                conn.Close()                        ' <== #2
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

        End If
    End Sub
    
    Protected Sub ddNIK_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddStatus.SelectedIndexChanged
        Try
            Dim Sql As String
            If ddStatus.Text = "01-Istri" Then
                Sql = _
                    "SELECT NIK,Nama_Penduduk FROM Penduduk where Penduduk.Jenis_Kelamin = 'P' AND Penduduk.Status_Perkawinan='KAWIN' except SELECT Penduduk.NIK,Nama_Penduduk FROM Penduduk,KK,Detail_KK where Penduduk.NIK = kk.NIK_Kepala_Keluarga OR Penduduk.NIK = Detail_KK.NIK"
            Else
                Sql = _
                    "SELECT NIK,Nama_Penduduk FROM Penduduk except SELECT Penduduk.NIK,Nama_Penduduk FROM Penduduk,KK,Detail_KK where Penduduk.NIK = kk.NIK_Kepala_Keluarga OR Penduduk.NIK = Detail_KK.NIK"
            End If
            '#3 buat obyek koneksi dan aktifkan koneksi
            conn = New SqlConnection(constr)
            conn.Open()

            '#4 deklarasikan dan buat obyek Command
            Dim cmd As SqlCommand = New SqlCommand(Sql, conn)

            '#5 Eksekusi command
            Dim reader As SqlDataReader = Nothing
            reader = cmd.ExecuteReader()
            ddNik.Items.Clear()                 ' <=== #1
            If reader.HasRows Then
                Do While reader.Read()
                    ddNik.Items.Add(New ListItem(reader.GetInt64(0) & " | " & reader.GetString(1), reader.GetInt64(0)))
                Loop
            End If
            reader.Close()
            conn.Close()                        ' <== #2
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        tampilkanPD()
    End Sub
    Private Function cekPd(ByVal nikPD As String) As Boolean
        Dim ketemu As Boolean = False
        'proses cari 
        ListPdd = Session("kk")
        For i = 0 To ListPdd.Count - 1
            If ListPdd.Item(i).NIK = nikPD Then
                ketemu = True
                Exit For
            End If
        Next
        Return ketemu
    End Function
    Protected Sub btAdd_Click(sender As Object, e As EventArgs) Handles btAdd.Click
        'cek apakah matakuliah terpilih sudah ada di ListPDD?
        If Not cekPd(ddNik.Text) Then    'jika tidak ada maka tambahkan MK tsb
            Try
                '#2 Buat perintah sql untuk ambil nama dan prodi
                Dim sql As String = _
                    "SELECT NIK,Nama_Penduduk FROM Penduduk WHERE NIK='" & ddNik.Text & "' "

                '#3 buat obyek koneksi dan aktifkan koneksi
                conn = New SqlConnection(constr)
                conn.Open()

                '#4 deklarasikan dan buat obyek Command
                Dim cmd As SqlCommand = Nothing
                cmd = New SqlCommand(sql, conn)

                '#5 Eksekusi command
                Dim reader As SqlDataReader = Nothing
                reader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    Dim pd As New Penduduk
                    pd.NIK = CStr(reader.GetInt64(0))
                    pd.nmPddk = reader.GetString(1)
                    pd.sttsH = ddStatus.Text
                    'modifikasi isi kk (ditambah )
                    ListPdd = Session("kk")
                    ListPdd.Add(pd)
                    Session("kk") = ListPdd

                End If
                reader.Close()
                conn.Close()
            Catch ex As Exception

                Response.Write(ex.Message)
            End Try
        Else        'Jika MK ditemukan di dalam ListMK maka berikan pesan peringatan
            Response.Write("<script>alert('Penduduk tidak dapat dipilih dua kali!')</script>")
        End If
        tampilkanPD()
    End Sub
    Private Sub tampilkanPD()
        'Judul Kolom
        Dim hdr As New TableRow()
        Dim kolom1 As New TableCell()
        Dim kolom2 As New TableCell()
        Dim kolom3 As New TableCell()
        kolom1.Text = "NIK"
        kolom2.Text = "Nama Penduduk"
        kolom3.Text = "Status Hubungan"
        hdr.Cells.Add(kolom1)
        hdr.Cells.Add(kolom2)
        hdr.Cells.Add(kolom3)
        tbPenduduk.Rows.Add(hdr)
        hdr.BackColor = Drawing.Color.Green
        hdr.ForeColor = Drawing.Color.White
        hdr.BorderWidth = 0
        tbPenduduk.BorderWidth = 0
        'Barisan data mk
        ListPdd = Session("kk")
        For i = 0 To ListPdd.Count - 1
            Dim trow As New TableRow()
            Dim selNik As New TableCell()
            Dim selNmPd As New TableCell()
            Dim selStat As New TableCell()
            selNik.Text = ListPdd.Item(i).NIK
            selNmPd.Text = ListPdd.Item(i).nmPddk
            status = Split(ListPdd.Item(i).sttsH, "-")
            newStatus = status(1)
            selStat.Text = newStatus
            trow.Cells.Add(selNik)
            trow.Cells.Add(selNmPd)
            trow.Cells.Add(selStat)
            tbPenduduk.Rows.Add(trow)
        Next
    End Sub

    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            '#3 buat obyek koneksi dan aktifkan koneksi
            conn = New SqlConnection(constr)
            conn.Open()

            Dim trKK As SqlTransaction = conn.BeginTransaction
            Dim cmd As SqlCommand = Nothing
            Dim sql As String = ""

            Try
                ListPdd = Session("kk")
                For i = 0 To ListPdd.Count - 1
                    sql = "INSERT INTO Detail_KK(No_KK,Status_Hub,NIK)    "
                    sql = sql & " VALUES('" & ddKK.Text & "','" & ListPdd.Item(i).sttsH & "','" & ListPdd.Item(i).NIK & "') "

                    cmd = New SqlCommand(sql, conn, trKK)
                    cmd.ExecuteNonQuery()
                Next
                trKK.Commit()
                Response.Write("<script>alert('Detail KK berhasil disimpan')</script>")
            Catch ex As Exception
                trKK.Rollback()
                Response.Write("<script>alert('Detail KK gagal disimpan')</script>")
            End Try
            conn.Close()
            tampilkanPD()
            Session("kk") = Nothing
        Catch ex As Exception
            Response.Write(ex.Message)
            Exit Sub
        End Try
    End Sub
    Dim status(), newStatus As String
    Protected Sub ddKK_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddKK.SelectedIndexChanged
        '#6 Mengeksekusi Perintah SQL
        Dim Sql As String = "select No_KK,Detail_KK.NIK,Nama_Penduduk,Status_Hub from Detail_KK,Penduduk where Detail_KK.NIK = Penduduk.NIK AND Detail_KK.No_KK = '" & ddKK.Text & "' order by Status_Hub Asc"
        conn = New SqlConnection(constr)
        conn.Open()

        '#4 deklarasikan dan buat obyek Command
        Dim cmd As SqlCommand = Nothing
        cmd = New SqlCommand(Sql, conn)
        Dim reader As SqlDataReader = Nothing
        reader = cmd.ExecuteReader
        anggotaKK.Text = ""

        '#7 Menampilkan Hasil Eksekusi
        If reader.HasRows Then
            Dim tbl As String = "<table class='list'>" & vbCrLf
            tbl = tbl & "<tr class='list'>" & vbCrLf
            tbl = tbl & "<th class='list'>No KK</th>" & vbCrLf
            tbl = tbl & "<th class='list'>NIK</th>" & vbCrLf
            tbl = tbl & "<th class='list'>Nama Penduduk</th>" & vbCrLf
            tbl = tbl & "<th class='list'>Status Hubungan Dalam Keluarga</th>" & vbCrLf
            tbl = tbl & "</tr>"
            Do While reader.Read
                status = Split(reader.GetString(3), "-")
                newStatus = status(1)
                tbl = tbl & "<tr class='list'>"
                tbl = tbl & "<td class='list'>" & reader.GetInt64(0) & "</td>" & vbCrLf
                tbl = tbl & "<td class='list'>" & reader.GetInt64(1) & "</td>" & vbCrLf
                tbl = tbl & "<td class='list'>" & reader.GetString(2) & "</td>" & vbCrLf
                tbl = tbl & "<td class='list'>" & newStatus & "</td>" & vbCrLf
                tbl = tbl & "</tr>" & vbCrLf
            Loop
            tbl = tbl & "</table>"
            anggotaKK.Text = tbl
            reader.Close()
        End If
        tampilkanPD()
    End Sub
End Class