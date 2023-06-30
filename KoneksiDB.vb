Imports MySql.Data.MySqlClient

Module KoneksiDB
    Public conn As MySqlConnection
    Public myAdapter As New MySqlDataAdapter
    Public myCommand As MySqlCommand
    Public myDataSet As DataSet
    Public myReader As MySqlDataReader
    Public sqlQuery As String
    Public LoggedUser As String

    Sub Koneksi()
        sqlQuery = "Server=localhost;user id=root;password=;database=dbperpus"
        conn = New MySqlConnection(sqlQuery)
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                MsgBox("Koneksi ke database berhasil", MsgBoxStyle.Information, "Informasi")
            End If
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Module