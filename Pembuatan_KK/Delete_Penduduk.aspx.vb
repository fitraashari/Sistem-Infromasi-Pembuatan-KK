﻿Imports System.Data.SqlClient

Public Class Delete_Penduduk
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("login") Is Nothing Then
            'lompat ke login.aspx
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Private Sub btnTidak_Click(sender As Object, e As EventArgs) Handles btnTidak.Click
        Response.Redirect("List_Penduduk.aspx")
    End Sub

    Private Sub btnYa_Click(sender As Object, e As EventArgs) Handles btnYa.Click
        '#1 Deklarasikan variabel obyek sqlconnection
        Dim conn As SqlConnection = Nothing
        Dim conStr As String = ""
        Try
            conStr = ConfigurationManager.ConnectionStrings("SQLSvrConnect").ConnectionString
            conn = New SqlConnection(conStr)
            conn.Open()

            '#3Mendeklarasikan dan menciptakan obyek Command
            Dim cmd As SqlCommand = Nothing
            cmd = New SqlCommand()
            cmd.Connection = conn

            '#4 Menuliskan perintah SQL dan mengekse
            Dim sql As String = "Delete from Penduduk where NIK='" & Request.Params("nik") & "'"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            '#5 Menutup Koneksi
            conn.Close()

            '#6 Redirect ke listmhs.aspx
            Response.Redirect("List_Penduduk.aspx")

        Catch ex As Exception
            Response.Write("Terjadi Error:" & ex.Message)
            Exit Sub
        End Try
    End Sub
End Class