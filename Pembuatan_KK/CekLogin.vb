Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class CekLogin
    Private fuserid As String
    Private fnama As String
    Private fpassword As String
    Private flvl As String

    Public Property userid() As String
        Get
            Return fuserid
        End Get
        Set(value As String)
            fuserid = value
        End Set
    End Property

    Public Property nama() As String
        Get
            Return fnama
        End Get
        Set(value As String)
            fnama = value
        End Set
    End Property
    Public Property lvl() As String
        Get
            Return flvl
        End Get
        Set(value As String)
            flvl = value
        End Set
    End Property

    Public Property password() As String
        Get
            Return fpassword
        End Get
        Set(value As String)
            fpassword = value
        End Set
    End Property

    Public Function auth() As Boolean
        Dim hasil As Boolean = False
        'validasi userid dan password
        Try
            Dim constr As String = _
                ConfigurationManager.ConnectionStrings("SQLSvrConnect").ConnectionString
            Dim conn As SqlConnection = New SqlConnection(constr)
            conn.Open()
            Dim sql As String = "SELECT * FROM login WHERE nameuser='" & fuserid & _
                "'  AND password='" & fpassword & "'  "
            Dim cmd As SqlCommand = New SqlCommand(sql, conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                fnama = reader.GetString(2)
                flvl = reader.GetString(3)
                hasil = True
            End If
            reader.Close()
            conn.Close()
        Catch ex As Exception

        End Try
        Return hasil
    End Function
End Class
