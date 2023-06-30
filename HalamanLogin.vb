Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient

Public Class HalamanLogin
    Private Sub HalamanLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TBUsername.Focus()
    End Sub
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        If TBUsername.Text = "" Or TBPass.Text = "" Then
            MsgBox("Masukkan Username dan Password!", MsgBoxStyle.Exclamation, "Lengkapi Data!")
        Else
            Login()
        End If
    End Sub


    'Function Login
    Private Sub Login()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus"
                .Open()
            End With
            sqlQuery = "SELECT username,password FROM admin WHERE username='" + TBUsername.Text + "' AND password='" + TBPass.Text + "'"
            myCommand = New MySqlCommand
            With myCommand
                .Connection = conn
                .CommandText = sqlQuery
            End With
            myAdapter.SelectCommand = myCommand
            Dim myData As MySqlDataReader
            myData = myCommand.ExecuteReader()
            If myData.HasRows = 0 Then
                MsgBox("Username atau password salah!", MsgBoxStyle.Critical, "Login Gagal")
                Clear()
                TBUsername.Focus()
            Else
                MsgBox("Login berhasil, Selamat datang " & TBUsername.Text & "!", MsgBoxStyle.Information, "Login Berhasil")
                LoggedUser = TBUsername.Text
                HalamanUtama.Show()
                Me.Close()
            End If
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub


    'Function Clear TextBox
    Private Sub Clear()
        TBUsername.Text = ""
        TBPass.Text = ""
    End Sub
End Class