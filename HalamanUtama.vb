Imports Google.Protobuf.Reflection.FieldDescriptorProto.Types
Imports MySql.Data.MySqlClient
Imports System.Reflection.Emit

Public Class HalamanUtama
    'Load Halaman Utama - Dashboard
    Private Sub HalamanUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PnlDash.Visible = True
        PnlAdmin.Visible = False
        PnlAnggota.Visible = False
        PnlBuku.Visible = False
        PnlPeminjaman.Visible = False
        PnlPengembalian.Visible = False
        PnlLapPeminjaman.Visible = False
        PnlLapDenda.Visible = False

        PnlDataMaster.Visible = False
        PnlTransaksi.Visible = False
        PnlLaporan.Visible = False

        'Local Date
        Dim todaysdate As String = String.Format("{0:dd}", DateTime.Now)
        Dim todaysday As String = DateTime.Now.DayOfWeek.ToString
        Dim todaysmonth As String = DateTime.Now.ToString("MMMM")
        Dim todaysyear As String = DateTime.Now.ToString("yyyy")
        LblDate.Text = todaysday + ", " + todaysdate + " " + todaysmonth + " " + todaysyear

        'Dashboard Content
        JmlAdmin()
        JmlAnggota()
        JmlBuku()
        NamaUser()
        PeminjamanBukuTerakhir()
        BukuBelumDikembalikan()
        TampilDataBukuTerbaru()
    End Sub


    'Function Dashboard Content
    Private Sub JmlAdmin()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            sqlQuery = "select count(kode_admin) from admin"
            myCommand = New MySqlCommand(sqlQuery, conn)
            With myCommand
                .ExecuteNonQuery()
            End With
            Dim i As String = myCommand.ExecuteScalar()
            LblCard1.Text = "Total Admin: " + i
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            myCommand = Nothing
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub JmlAnggota()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            sqlQuery = "select count(kode_anggota) from anggota"
            myCommand = New MySqlCommand(sqlQuery, conn)
            With myCommand
                .ExecuteNonQuery()
            End With
            Dim i As String = myCommand.ExecuteScalar()
            LblCard2.Text = "Total Anggota: " + i
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            myCommand = Nothing
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub JmlBuku()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            sqlQuery = "select count(kode_buku) from buku"
            myCommand = New MySqlCommand(sqlQuery, conn)
            With myCommand
                .ExecuteNonQuery()
            End With
            Dim i As String = myCommand.ExecuteScalar()
            LblCard3.Text = "Total Buku: " + i
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            myCommand = Nothing
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub NamaUser()
        LblUsername.Text = "Hello, " + LoggedUser
    End Sub
    Private Sub PeminjamanBukuTerakhir()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            sqlQuery = "select count(kode_peminjaman) from peminjaman where tgl_peminjaman >= date_sub(now(), interval 30 day);"
            myCommand = New MySqlCommand(sqlQuery, conn)
            With myCommand
                .ExecuteNonQuery()
            End With
            Dim i As String = myCommand.ExecuteScalar()
            Label2.Text = i
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            myCommand = Nothing
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub BukuBelumDikembalikan()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            sqlQuery = "select count(kode_peminjaman) from peminjaman where status=0"
            myCommand = New MySqlCommand(sqlQuery, conn)
            With myCommand
                .ExecuteNonQuery()
            End With
            Dim i As String = myCommand.ExecuteScalar()
            Label3.Text = i
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            myCommand = Nothing
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub TampilDataBukuTerbaru()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            myAdapter = New MySqlDataAdapter("SELECT * FROM
                                         (SELECT * FROM buku ORDER BY kode_buku DESC LIMIT 10)
                                         AS sub
                                         ORDER BY kode_buku ASC;", conn)
            myDataSet = New DataSet
            myDataSet.Clear()
            myAdapter.Fill(myDataSet, "buku")
            DataBukuTerbaru.DataSource = (myDataSet.Tables("buku"))
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub



    'Button Side Menu
    Private Sub BtnDataMaster_Click(sender As Object, e As EventArgs) Handles BtnDataMaster.Click
        If PnlDataMaster.Visible = False Then
            PnlDataMaster.Visible = True
        Else
            PnlDataMaster.Visible = False
        End If
    End Sub
    Private Sub BtnTransaksi_Click(sender As Object, e As EventArgs) Handles BtnTransaksi.Click
        If PnlTransaksi.Visible = False Then
            PnlTransaksi.Visible = True
        Else
            PnlTransaksi.Visible = False
        End If
    End Sub
    Private Sub BtnLaporan_Click(sender As Object, e As EventArgs) Handles BtnLaporan.Click
        If PnlLaporan.Visible = False Then
            PnlLaporan.Visible = True
        Else
            PnlLaporan.Visible = False
        End If
    End Sub
    Private Sub BtnLogout_Click(sender As Object, e As EventArgs) Handles BtnLogout.Click
        If MsgBox("Yakin akan logout?", MsgBoxStyle.YesNo,
        "Konfirmasi") = MsgBoxResult.No Then Exit Sub
        MsgBox("Logout Berhasil", MsgBoxStyle.Information, "Logout")
        HalamanLogin.Show()
        Me.Close()
    End Sub



    'Klik Side Menu
    Private Sub BtnAdmin_Click(sender As Object, e As EventArgs) Handles BtnAdmin.Click
        PnlDash.Visible = False
        PnlAdmin.Visible = True
        PnlAnggota.Visible = False
        PnlBuku.Visible = False
        PnlPeminjaman.Visible = False
        PnlPengembalian.Visible = False
        PnlLapPeminjaman.Visible = False
        PnlLapDenda.Visible = False
        TampilDataAdmin()
        ClearDataAdmin()
    End Sub

    Private Sub BtnAnggota_Click(sender As Object, e As EventArgs) Handles BtnAnggota.Click
        PnlDash.Visible = False
        PnlAdmin.Visible = False
        PnlAnggota.Visible = True
        PnlBuku.Visible = False
        PnlPeminjaman.Visible = False
        PnlPengembalian.Visible = False
        PnlLapPeminjaman.Visible = False
        PnlLapDenda.Visible = False
        TampilDataAnggota()
        ClearDataAnggota()
    End Sub

    Private Sub BtnBuku_Click(sender As Object, e As EventArgs) Handles BtnBuku.Click
        PnlDash.Visible = False
        PnlAdmin.Visible = False
        PnlAnggota.Visible = False
        PnlBuku.Visible = True
        PnlPeminjaman.Visible = False
        PnlPengembalian.Visible = False
        PnlLapPeminjaman.Visible = False
        PnlLapDenda.Visible = False
        TampilDataBuku()
        ClearDataBuku()
    End Sub

    Private Sub BtnPeminjaman_Click(sender As Object, e As EventArgs) Handles BtnPeminjaman.Click
        PnlDash.Visible = False
        PnlAdmin.Visible = False
        PnlAnggota.Visible = False
        PnlBuku.Visible = False
        PnlPeminjaman.Visible = True
        PnlPengembalian.Visible = False
        PnlLapPeminjaman.Visible = False
        PnlLapDenda.Visible = False
        TampilDataPinjaman()
        TampilDataPeminjamanAnggota()
        ClearDataPeminjaman()
    End Sub

    Private Sub BtnPengembalian_Click(sender As Object, e As EventArgs) Handles BtnPengembalian.Click
        PnlDash.Visible = False
        PnlAdmin.Visible = False
        PnlAnggota.Visible = False
        PnlBuku.Visible = False
        PnlPeminjaman.Visible = False
        PnlPengembalian.Visible = True
        PnlLapPeminjaman.Visible = False
        PnlLapDenda.Visible = False
        TampilDataPengembalian()
        ClearDataPengembalian()
    End Sub

    Private Sub BtnLapPeminjaman_Click(sender As Object, e As EventArgs) Handles BtnLapPeminjaman.Click
        PnlDash.Visible = False
        PnlAdmin.Visible = False
        PnlAnggota.Visible = False
        PnlBuku.Visible = False
        PnlPeminjaman.Visible = False
        PnlPengembalian.Visible = False
        PnlLapPeminjaman.Visible = True
        PnlLapDenda.Visible = False
        TampilDataLapPeminjaman()
        ClearDataLapPeminjaman()
    End Sub

    Private Sub BtnLapDenda_Click(sender As Object, e As EventArgs) Handles BtnLapDenda.Click
        PnlDash.Visible = False
        PnlAdmin.Visible = False
        PnlAnggota.Visible = False
        PnlBuku.Visible = False
        PnlPeminjaman.Visible = False
        PnlPengembalian.Visible = False
        PnlLapPeminjaman.Visible = False
        PnlLapDenda.Visible = True
        TampilDataLapDenda()
    End Sub


    'Menu Admin
    Private Sub BtnClearDataAdmin_Click(sender As Object, e As EventArgs) Handles BtnClearDataAdmin.Click
        ClearDataAdmin()
    End Sub
    'Add Admin
    Private Sub BtnAddAdmin_Click(sender As Object, e As EventArgs) Handles BtnAddAdmin.Click
        TBAdminNama.Enabled = True
        TBAdminUser.Enabled = True
        TBAdminPass.Enabled = True
        TBAdminEmail.Enabled = True
        CBAdminJK.Enabled = True
        TBAdminTelp.Enabled = True
        TBAdminLahir.Enabled = True
        BtnAddDataAdmin.Enabled = True
        BtnSaveDataAdmin.Enabled = False
        BtnClearDataAdmin.Enabled = True
    End Sub
    Private Sub BtnAddDataAdmin_Click(sender As Object, e As EventArgs) Handles BtnAddDataAdmin.Click
        AddDataAdmin()
    End Sub
    'Edit Admin
    Private Sub BtnEditAdmin_Click(sender As Object, e As EventArgs) Handles BtnEditAdmin.Click
        DataAdmin_CellMouseDoubleClick(Nothing, Nothing)
        TBAdminNama.Enabled = True
        TBAdminUser.Enabled = True
        TBAdminPass.Enabled = True
        TBAdminEmail.Enabled = True
        CBAdminJK.Enabled = True
        TBAdminTelp.Enabled = True
        TBAdminLahir.Enabled = True
        BtnAddDataAdmin.Enabled = False
        BtnSaveDataAdmin.Enabled = True
        BtnClearDataAdmin.Enabled = True
    End Sub
    Private Sub BtnSaveDataAdmin_Click(sender As Object, e As EventArgs) Handles BtnSaveDataAdmin.Click
        UpdateDataAdmin()
    End Sub
    'Delete Admin
    Private Sub BtnDeleteAdmin_Click(sender As Object, e As EventArgs) Handles BtnDeleteAdmin.Click
        DeleteDataAdmin()
    End Sub


    'Menu Anggota
    Private Sub BtnClearDataAnggota_Click(sender As Object, e As EventArgs) Handles BtnClearDataAnggota.Click
        ClearDataAnggota()
    End Sub
    'Add Anggota
    Private Sub BtnAddAnggota_Click(sender As Object, e As EventArgs) Handles BtnAddAnggota.Click
        TBAnggotaNama.Enabled = True
        TBAnggotaEmail.Enabled = True
        CBAnggotaJK.Enabled = True
        TBAnggotaTelp.Enabled = True
        TBAnggotaLahir.Enabled = True
        TBAnggotaGabung.Enabled = True
        BtnAddDataAnggota.Enabled = True
        BtnSaveDataAnggota.Enabled = False
        BtnClearDataAnggota.Enabled = True
    End Sub
    Private Sub BtnAddDataAnggota_Click(sender As Object, e As EventArgs) Handles BtnAddDataAnggota.Click
        AddDataAnggota()
    End Sub
    'Edit Anggota
    Private Sub BtnEditAnggota_Click(sender As Object, e As EventArgs) Handles BtnEditAnggota.Click
        DataAnggota_CellMouseDoubleClick(Nothing, Nothing)
        TBAnggotaNama.Enabled = True
        TBAnggotaEmail.Enabled = True
        CBAnggotaJK.Enabled = True
        TBAnggotaTelp.Enabled = True
        TBAnggotaLahir.Enabled = True
        TBAnggotaGabung.Enabled = True
        BtnAddDataAnggota.Enabled = False
        BtnSaveDataAnggota.Enabled = True
        BtnClearDataAnggota.Enabled = True
    End Sub
    Private Sub BtnSaveDataAnggota_Click(sender As Object, e As EventArgs) Handles BtnSaveDataAnggota.Click
        UpdateDataAnggota()
    End Sub
    'Delete Anggota
    Private Sub BtnDeleteAnggota_Click(sender As Object, e As EventArgs) Handles BtnDeleteAnggota.Click
        DeleteDataAnggota()
    End Sub


    'Menu Buku
    Private Sub BtnClearDataBuku_Click(sender As Object, e As EventArgs) Handles BtnClearDataBuku.Click
        ClearDataBuku()
    End Sub
    'Add Buku
    Private Sub BtnAddBuku_Click(sender As Object, e As EventArgs) Handles BtnAddBuku.Click
        TBBukuJudul.Enabled = True
        TBBukuJudul.Enabled = True
        TBBukuPenulis.Enabled = True
        TBBukuPenerbit.Enabled = True
        TBBukuBahasa.Enabled = True
        TBBukuHal.Enabled = True
        TBBukuTerbit.Enabled = True
        TBBukuLokasi.Enabled = True
        CBBukuAda.Enabled = True
        BtnAddDataBuku.Enabled = True
        BtnSaveDataBuku.Enabled = False
        BtnClearDataBuku.Enabled = True
    End Sub
    Private Sub BtnAddDataBuku_Click(sender As Object, e As EventArgs) Handles BtnAddDataBuku.Click
        AddDataBuku()
    End Sub
    'Edit Buku
    Private Sub BtnEditBuku_Click(sender As Object, e As EventArgs) Handles BtnEditBuku.Click
        DataBuku_CellMouseDoubleClick(Nothing, Nothing)
        TBBukuJudul.Enabled = True
        TBBukuPenulis.Enabled = True
        TBBukuPenerbit.Enabled = True
        TBBukuBahasa.Enabled = True
        TBBukuHal.Enabled = True
        TBBukuTerbit.Enabled = True
        TBBukuLokasi.Enabled = True
        CBBukuAda.Enabled = True
        BtnAddDataBuku.Enabled = False
        BtnSaveDataBuku.Enabled = True
        BtnClearDataBuku.Enabled = True
    End Sub
    Private Sub BtnSaveDataBuku_Click(sender As Object, e As EventArgs) Handles BtnSaveDataBuku.Click
        UpdateDataBuku()
    End Sub
    'Delete Buku
    Private Sub BtnDeleteBuku_Click(sender As Object, e As EventArgs) Handles BtnDeleteBuku.Click
        DeleteDataBuku()
    End Sub


    'Menu Peminjaman
    Private Sub BtnClearDataPeminjaman_Click(sender As Object, e As EventArgs) Handles BtnClearDataPeminjaman.Click
        ClearDataPeminjaman()
    End Sub
    'Add Peminjaman
    Private Sub BtnAddPeminjaman_Click(sender As Object, e As EventArgs) Handles BtnAddPeminjaman.Click
        TBPinjamTgl.Enabled = True
        TBPinjamKembali.Enabled = True
        BtnAddDataPeminjaman.Enabled = True
        BtnClearDataPeminjaman.Enabled = True
    End Sub
    Private Sub BtnAddDataPeminjaman_Click(sender As Object, e As EventArgs) Handles BtnAddDataPeminjaman.Click
        AddDataPeminjaman()
    End Sub


    'Menu Pengembalian
    Private Sub BtnClearDataPengembalian_Click(sender As Object, e As EventArgs) Handles BtnClearDataPengembalian.Click
        ClearDataPengembalian()
    End Sub
    'Add Pengemmbalian
    Private Sub BtnAddPengembalian_Click(sender As Object, e As EventArgs) Handles BtnAddPengembalian.Click
        TBTglDikembalikan.Enabled = True
        BtnAddDataPengembalian.Enabled = True
        BtnClearDataPengembalian.Enabled = True
    End Sub
    Private Sub BtnAddDataPengembalian_Click(sender As Object, e As EventArgs) Handles BtnAddDataPengembalian.Click
        AddDataPengembalian()
    End Sub


    'Menu Laporan Peminjaman
    Private Sub BtnClearDataLapPeminjaman_Click(sender As Object, e As EventArgs) Handles BtnClearDataLapPeminjaman.Click
        ClearDataLapPeminjaman()
    End Sub
    'Edit Laporan Peminjaman
    Private Sub BtnEditLapPeminjaman_Click(sender As Object, e As EventArgs) Handles BtnEditLapPeminjaman.Click
        TBLapKodePeminjaman.Enabled = True
        TBLapKodeBuku.Enabled = True
        TBLapKodeAnggota.Enabled = True
        TBLapNamaAnggota.Enabled = True
        TBLapJudul.Enabled = True
        TBLapPenulis.Enabled = True
        TBLapTglPeminjaman.Enabled = True
        TBLapTglPengembalian.Enabled = True
        CBLapStatus.Enabled = True
        TBLapTglPengembalian.Enabled = True
        BtnSaveDataLapPeminjaman.Enabled = True
        BtnClearDataLapPeminjaman.Enabled = True
    End Sub
    Private Sub BtnSaveDataLapPeminjaman_Click(sender As Object, e As EventArgs) Handles BtnSaveDataLapPeminjaman.Click
        UpdateDataLapPeminjaman()
    End Sub
    'Delete Laporan Peminjaman
    Private Sub BtnDeleteLapPeminjaman_Click(sender As Object, e As EventArgs) Handles BtnDeleteLapPeminjaman.Click
        DeleteDataLapPeminjaman()
    End Sub


    'Menu Laporan Denda


    'Tombol Back - Kembali ke Dashboard
    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back1.Click, Back2.Click, Back3.Click, Back4.Click, Back5.Click, Back6.Click, Back7.Click
        BtnBack()
    End Sub
    Private Sub BtnBack()
        PnlDash.Visible = True
        PnlAdmin.Visible = False
        PnlAnggota.Visible = False
        PnlBuku.Visible = False
        PnlPeminjaman.Visible = False
        PnlPengembalian.Visible = False
        PnlLapPeminjaman.Visible = False
        PnlLapDenda.Visible = False
    End Sub


    'Function Menampilkan Data ke DataGrid
    Private Sub TampilDataAdmin()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            myAdapter = New MySqlDataAdapter("select * from admin order by kode_admin", conn)
            myDataSet = New DataSet
            myDataSet.Clear()
            myAdapter.Fill(myDataSet, "admin")
            DataAdmin.DataSource = (myDataSet.Tables("admin"))
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub TampilDataAnggota()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            myAdapter = New MySqlDataAdapter("select * from anggota order by kode_anggota", conn)
            myDataSet = New DataSet
            myDataSet.Clear()
            myAdapter.Fill(myDataSet, "anggota")
            DataAnggota.DataSource = (myDataSet.Tables("anggota"))
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub TampilDataBuku()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            myAdapter = New MySqlDataAdapter("select * from buku order by kode_buku", conn)
            myDataSet = New DataSet
            myDataSet.Clear()
            myAdapter.Fill(myDataSet, "buku")
            DataBuku.DataSource = (myDataSet.Tables("buku"))
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub TampilDataPinjaman()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            myAdapter = New MySqlDataAdapter("select * from buku where ketersediaan='Tersedia' order by kode_buku", conn)
            myDataSet = New DataSet
            myDataSet.Clear()
            myAdapter.Fill(myDataSet, "buku")
            DataPinjamBuku.DataSource = (myDataSet.Tables("buku"))
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub TampilDataPeminjamanAnggota()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            myAdapter = New MySqlDataAdapter("select kode_anggota,nama from anggota order by kode_anggota", conn)
            myDataSet = New DataSet
            myDataSet.Clear()
            myAdapter.Fill(myDataSet, "anggota")
            DataPeminjamanAnggota.DataSource = (myDataSet.Tables("anggota"))
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub TampilDataPengembalian()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            myAdapter = New MySqlDataAdapter("select * from peminjaman where status='0' order by kode_peminjaman", conn)
            myDataSet = New DataSet
            myDataSet.Clear()
            myAdapter.Fill(myDataSet, "peminjaman")
            DataPengembalian.DataSource = (myDataSet.Tables("peminjaman"))
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub TampilDataLapPeminjaman()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            myAdapter = New MySqlDataAdapter("select * from peminjaman order by kode_peminjaman", conn)
            myDataSet = New DataSet
            myDataSet.Clear()
            myAdapter.Fill(myDataSet, "peminjaman")
            DataLapPeminjaman.DataSource = (myDataSet.Tables("peminjaman"))
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub TampilDataLapDenda()
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            myAdapter = New MySqlDataAdapter("select * from peminjaman where tgl_dikembalikan >= tgl_pengembalian order by kode_peminjaman", conn)
            myDataSet = New DataSet
            myDataSet.Clear()
            myAdapter.Fill(myDataSet, "peminjaman")
            DataLapDenda.DataSource = (myDataSet.Tables("peminjaman"))
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
    Private Sub RefreshAll()
        TampilDataAdmin()
        TampilDataAnggota()
        TampilDataBuku()
        TampilDataBukuTerbaru()
        TampilDataLapDenda()
        TampilDataLapPeminjaman()
        TampilDataPeminjamanAnggota()
        TampilDataPengembalian()
        TampilDataPinjaman()
    End Sub


    'Function Add Data
    Private Sub AddDataAdmin()
        conn = New MySqlConnection
        With conn
            .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
            .Open()
        End With
        Try
            Dim simpan As String
            simpan = "insert into admin (nama,username,password,email,telp,jenis_kelamin,tgl_lahir)
                  values('" & TBAdminNama.Text & "',
                         '" & TBAdminUser.Text & "',
                         '" & TBAdminPass.Text & "',
                         '" & TBAdminEmail.Text & "',
                         '" & TBAdminTelp.Text & "',
                         '" & CBAdminJK.Text & "',
                         '" & TBAdminLahir.Text & "')"
            myCommand = New MySqlCommand(simpan, conn)
            With myCommand
                .ExecuteNonQuery()
            End With
            MsgBox("Data baru berhasil dibuat!", MsgBoxStyle.Information)
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            conn.Close()
            conn.Dispose()
            ClearDataAdmin()
            RefreshAll()
        End Try
    End Sub
    Private Sub AddDataAnggota()
        conn = New MySqlConnection
        With conn
            .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
            .Open()
        End With
        Try
            Dim simpan As String
            simpan = "insert into anggota (nama,email,telp,jenis_kelamin,tgl_lahir,tgl_bergabung)
                  values('" & TBAnggotaNama.Text & "',
                         '" & TBAnggotaEmail.Text & "',
                         '" & TBAnggotaTelp.Text & "',
                         '" & CBAnggotaJK.Text & "',
                         '" & TBAnggotaLahir.Text & "',
                         '" & TBAnggotaGabung.Text & "')"
            myCommand = New MySqlCommand(simpan, conn)
            With myCommand
                .ExecuteNonQuery()
            End With
            MsgBox("Data baru berhasil dibuat!", MsgBoxStyle.Information)
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            conn.Close()
            conn.Dispose()
            ClearDataAnggota()
            RefreshAll()
        End Try
    End Sub
    Private Sub AddDataBuku()
        conn = New MySqlConnection
        With conn
            .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
            .Open()
        End With
        Try
            Dim simpan As String
            simpan = "insert into buku (judul,penulis,penerbit,bahasa,jml_hal,tgl_terbit,lokasi,ketersediaan)
                  values('" & TBBukuJudul.Text & "',
                         '" & TBBukuPenulis.Text & "',
                         '" & TBBukuPenerbit.Text & "',
                         '" & TBBukuBahasa.Text & "',
                         '" & TBBukuHal.Text & "',
                         '" & TBBukuTerbit.Text & "',
                         '" & TBBukuLokasi.Text & "',
                         '" & CBBukuAda.Text & "')"
            myCommand = New MySqlCommand(simpan, conn)
            With myCommand
                .ExecuteNonQuery()
            End With
            MsgBox("Data baru berhasil dibuat!", MsgBoxStyle.Information)
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            conn.Close()
            conn.Dispose()
            ClearDataBuku()
            RefreshAll()
        End Try
    End Sub

    Private Sub AddDataPeminjaman()
        conn = New MySqlConnection
        With conn
            .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
            .Open()
        End With
        Try
            Dim simpan As String
            simpan = "insert into peminjaman (kode_buku, kode_anggota,anggota,judul,penulis,tgl_peminjaman,tgl_pengembalian,status)
                  values('" & TBPinjamKodeBuku.Text & "',
                         '" & TBPeminjamanKodeAnggota.Text & "',
                         '" & TBPinjamNamaAnggota.Text & "',
                         '" & TBPinjamJudul.Text & "',
                         '" & TBPinjamJudul.Text & "',
                         '" & TBPinjamTgl.Text & "',
                         '" & TBPinjamKembali.Text & "',
                         '0');
                  update buku set ketersediaan='Tidak Tersedia'
                  where buku.kode_buku='" & TBPinjamKodeBuku.Text & "'"
            myCommand = New MySqlCommand(simpan, conn)
            myCommand.ExecuteNonQuery()
            MsgBox("Data baru berhasil dibuat!", MsgBoxStyle.Information)
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            conn.Close()
            conn.Dispose()
            ClearDataPeminjaman()
            RefreshAll()
        End Try
    End Sub
    Private Sub AddDataPengembalian()
        conn = New MySqlConnection
        With conn
            .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
            .Open()
        End With
        Try
            Dim simpan As String
            simpan = "update peminjaman set status='1', tgl_dikembalikan='" & TBTglDikembalikan.Text & "' where kode_peminjaman='" & TBKodePeminjaman.Text & "';
                  update buku set ketersediaan='Tersedia'
                  where kode_buku='" & TBKembaliKodeBuku.Text & "'"
            myCommand = New MySqlCommand(simpan, conn)
            myCommand.ExecuteNonQuery()
            MsgBox("Data pengembalian berhasil dibuat!", MsgBoxStyle.Information)
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            conn.Close()
            conn.Dispose()
            ClearDataPengembalian()
            RefreshAll()
        End Try
    End Sub



    'Function Update Data
    Private Sub UpdateDataAdmin()
        conn = New MySqlConnection
        With conn
            .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
            .Open()
        End With
        Try
            sqlQuery = "update admin set
                        kode_admin='" & TBAdminKode.Text & "',
                        nama='" & TBAdminNama.Text & "',
                        username='" & TBAdminUser.Text & "',
                        password='" & TBAdminPass.Text & "',
                        email='" & TBAdminEmail.Text & "',
                        telp='" & TBAdminTelp.Text & "',
                        jenis_kelamin='" & CBAdminJK.Text & "',
                        tgl_lahir='" & TBAdminLahir.Text & "'
                        where kode_admin='" & TBAdminKode.Text & "'"
            With myCommand
                .Connection = conn
                .CommandText = sqlQuery
                .ExecuteNonQuery()
            End With
            MsgBox("Perubahan tersimpan")
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            conn.Close()
            conn.Dispose()
            ClearDataAdmin()
            RefreshAll()
        End Try
    End Sub
    Private Sub UpdateDataAnggota()
        conn = New MySqlConnection
        With conn
            .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
            .Open()
        End With
        Try
            sqlQuery = "update anggota set
                        kode_anggota='" & TBAnggotaKode.Text & "',
                        nama='" & TBAnggotaNama.Text & "',
                        email='" & TBAnggotaEmail.Text & "',
                        telp='" & TBAnggotaTelp.Text & "',
                        jenis_kelamin='" & CBAnggotaJK.Text & "',
                        tgl_lahir='" & TBAnggotaLahir.Text & "',
                        tgl_bergabung='" & TBAnggotaGabung.Text & "'
                        where kode_anggota='" & TBAnggotaKode.Text & "'"
            With myCommand
                .Connection = conn
                .CommandText = sqlQuery
                .ExecuteNonQuery()
            End With
            MsgBox("Perubahan tersimpan")
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            conn.Close()
            conn.Dispose()
            ClearDataAnggota()
            RefreshAll()
        End Try
    End Sub
    Private Sub UpdateDataBuku()
        conn = New MySqlConnection
        With conn
            .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
            .Open()
        End With
        Try
            sqlQuery = "update buku set
                        kode_buku='" & TBBukuKode.Text & "',
                        judul='" & TBBukuJudul.Text & "',
                        penulis='" & TBBukuPenulis.Text & "',
                        penerbit='" & TBBukuPenerbit.Text & "',
                        bahasa='" & TBBukuBahasa.Text & "',
                        jml_hal='" & TBBukuHal.Text & "',
                        tgl_terbit='" & TBBukuTerbit.Text & "',
                        lokasi='" & TBBukuLokasi.Text & "',
                        ketersediaan='" & CBBukuAda.Text & "'
                        where kode_buku='" & TBBukuKode.Text & "'"
            myCommand = New MySqlCommand(sqlQuery, conn)
            myCommand.ExecuteNonQuery()
            MsgBox("Perubahan tersimpan")
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            conn.Close()
            conn.Dispose()
            ClearDataBuku()
            RefreshAll()
        End Try
    End Sub
    Private Sub UpdateDataLapPeminjaman()
        conn = New MySqlConnection
        With conn
            .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
            .Open()
        End With
        Try
            sqlQuery = "update peminjaman set
                        kode_buku='" & TBLapKodeBuku.Text & "',
                        kode_anggota='" & TBLapKodeAnggota.Text & "',
                        anggota='" & TBLapNamaAnggota.Text & "',
                        judul='" & TBLapJudul.Text & "',
                        penulis='" & TBLapPenulis.Text & "',
                        tgl_peminjaman='" & TBLapTglPeminjaman.Text & "',
                        tgl_pengembalian='" & TBLapTglPengembalian.Text & "',
                        status='" & CBLapStatus.Checked & "',
                        tgl_dikembalikan='" & TBTglDikembalikan.Text & "'
                        where kode_peminjaman='" & TBLapKodePeminjaman.Text & "'"
            With myCommand
                .Connection = conn
                .CommandText = sqlQuery
                .ExecuteNonQuery()
            End With
            MsgBox("Perubahan tersimpan")
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            conn.Close()
            conn.Dispose()
            ClearDataLapPeminjaman()
            RefreshAll()
        End Try
    End Sub



    'Function Delete Data
    Private Sub DeleteDataAdmin()
        If MsgBox("Yakin akan menghapus data?", MsgBoxStyle.YesNo,
        "Konfirmasi") = MsgBoxResult.No Then Exit Sub
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            sqlQuery = "DELETE FROM admin WHERE kode_admin = " &
                  "'" & DataAdmin.CurrentRow.Cells(0).Value & "'"
            With myCommand
                myCommand.Connection = conn
                myCommand.CommandText = sqlQuery
                myCommand.ExecuteNonQuery()
            End With
            MsgBox("Data terhapus")
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            DataAdmin_CellMouseDoubleClick(Nothing, Nothing)
            conn.Close()
            conn.Dispose()
            ClearDataAdmin()
            RefreshAll()
        End Try
    End Sub
    Private Sub DeleteDataAnggota()
        If MsgBox("Yakin akan menghapus data?", MsgBoxStyle.YesNo,
        "Konfirmasi") = MsgBoxResult.No Then Exit Sub
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            sqlQuery = "DELETE FROM anggota WHERE kode_anggota = " &
                  "'" & DataAnggota.CurrentRow.Cells(0).Value & "'"
            With myCommand
                myCommand.Connection = conn
                myCommand.CommandText = sqlQuery
                myCommand.ExecuteNonQuery()
            End With
            MsgBox("Data terhapus")
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            DataAnggota_CellMouseDoubleClick(Nothing, Nothing)
            conn.Close()
            conn.Dispose()
            ClearDataAnggota()
            RefreshAll()
        End Try
    End Sub
    Private Sub DeleteDataBuku()
        If MsgBox("Yakin akan menghapus data?", MsgBoxStyle.YesNo,
        "Konfirmasi") = MsgBoxResult.No Then Exit Sub
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            sqlQuery = "DELETE FROM buku WHERE kode_buku = " &
                  "'" & DataBuku.CurrentRow.Cells(0).Value & "'"
            With myCommand
                myCommand.Connection = conn
                myCommand.CommandText = sqlQuery
                myCommand.ExecuteNonQuery()
            End With
            MsgBox("Data terhapus")

        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            DataBuku_CellMouseDoubleClick(Nothing, Nothing)
            conn.Close()
            conn.Dispose()
            ClearDataBuku()
            RefreshAll()
        End Try
    End Sub
    Private Sub DeleteDataLapPeminjaman()
        If MsgBox("Yakin akan menghapus data?", MsgBoxStyle.YesNo,
        "Konfirmasi") = MsgBoxResult.No Then Exit Sub
        Try
            conn = New MySqlConnection
            With conn
                .ConnectionString = "server=localhost; user id=root; password= ; database=dbperpus; convert zero datetime=true"
                .Open()
            End With
            sqlQuery = "DELETE FROM peminjaman WHERE kode_peminjaman = " &
                  "'" & DataLapPeminjaman.CurrentRow.Cells(0).Value & "'"
            With myCommand
                myCommand.Connection = conn
                myCommand.CommandText = sqlQuery
                myCommand.ExecuteNonQuery()
            End With
            MsgBox("Data terhapus")
        Catch myerror As MySqlException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            DataLapPeminjaman_CellMouseDoubleClick(Nothing, Nothing)
            conn.Close()
            conn.Dispose()
            ClearDataLapPeminjaman()
            RefreshAll()
        End Try
    End Sub



    'Function Clear Data
    Private Sub ClearDataAdmin()
        TBAdminKode.Text = String.Empty
        TBAdminNama.Text = String.Empty
        TBAdminUser.Text = String.Empty
        TBAdminPass.Text = String.Empty
        TBAdminEmail.Text = String.Empty
        TBAdminTelp.Text = String.Empty
        CBAdminJK.Text = String.Empty
        TBAdminLahir.Text = String.Empty
        TBAdminKode.Enabled = False
        TBAdminNama.Enabled = False
        TBAdminUser.Enabled = False
        TBAdminPass.Enabled = False
        TBAdminEmail.Enabled = False
        TBAdminTelp.Enabled = False
        CBAdminJK.Enabled = False
        TBAdminLahir.Enabled = False
        BtnAddAdmin.Enabled = False
        BtnSaveDataAdmin.Enabled = False
        BtnClearDataAdmin.Enabled = False
    End Sub
    Private Sub ClearDataAnggota()
        TBAnggotaKode.Text = String.Empty
        TBAnggotaNama.Text = String.Empty
        TBAnggotaEmail.Text = String.Empty
        TBAnggotaTelp.Text = String.Empty
        CBAnggotaJK.Text = String.Empty
        TBAnggotaLahir.Text = String.Empty
        TBAnggotaGabung.Text = String.Empty
        TBAnggotaKode.Enabled = False
        TBAnggotaNama.Enabled = False
        TBAnggotaEmail.Enabled = False
        TBAnggotaTelp.Enabled = False
        CBAnggotaJK.Enabled = False
        TBAnggotaLahir.Enabled = False
        TBAnggotaGabung.Enabled = False
        BtnAddDataAnggota.Enabled = False
        BtnSaveDataAnggota.Enabled = False
        BtnClearDataAnggota.Enabled = False
    End Sub
    Private Sub ClearDataBuku()
        TBBukuKode.Text = String.Empty
        TBBukuJudul.Text = String.Empty
        TBBukuPenulis.Text = String.Empty
        TBBukuPenerbit.Text = String.Empty
        TBBukuBahasa.Text = String.Empty
        TBBukuHal.Text = String.Empty
        TBBukuTerbit.Text = String.Empty
        TBBukuLokasi.Text = String.Empty
        CBBukuAda.Text = String.Empty
        TBBukuKode.Enabled = False
        TBBukuJudul.Enabled = False
        TBBukuPenulis.Enabled = False
        TBBukuPenerbit.Enabled = False
        TBBukuBahasa.Enabled = False
        TBBukuHal.Enabled = False
        TBBukuTerbit.Enabled = False
        TBBukuLokasi.Enabled = False
        CBBukuAda.Enabled = False
        BtnAddDataBuku.Enabled = False
        BtnSaveDataBuku.Enabled = False
        BtnClearDataBuku.Enabled = False
    End Sub
    Private Sub ClearDataPeminjaman()
        TBPinjamKodeBuku.Text = String.Empty
        TBPeminjamanKodeAnggota.Text = String.Empty
        TBPinjamNamaAnggota.Text = String.Empty
        TBPinjamJudul.Text = String.Empty
        TBPinjamJudul.Text = String.Empty
        TBPinjamTgl.Text = String.Empty
        TBPinjamKembali.Text = String.Empty
        TBPinjamKodeBuku.Enabled = False
        TBPinjamNamaAnggota.Enabled = False
        TBPinjamJudul.Enabled = False
        TBPinjamJudul.Enabled = False
        TBPinjamTgl.Enabled = False
        TBPinjamKembali.Enabled = False
        BtnAddDataPeminjaman.Enabled = False
        BtnClearDataPeminjaman.Enabled = False
    End Sub
    Private Sub ClearDataPengembalian()
        TBKodePeminjaman.Text = String.Empty
        TBKembaliKodeAnggota.Text = String.Empty
        TBKembaliNamaAnggota.Text = String.Empty
        TBKembaliKodeBuku.Text = String.Empty
        TBKembaliJudul.Text = String.Empty
        TBKembaliPenulis.Text = String.Empty
        TBKembaliTglPinjam.Text = String.Empty
        TBKembaliTglKembali.Text = String.Empty
        TBTglDikembalikan.Text = String.Empty
        TBKodePeminjaman.Enabled = False
        TBKembaliKodeAnggota.Enabled = False
        TBKembaliNamaAnggota.Enabled = False
        TBKembaliKodeBuku.Enabled = False
        TBKembaliJudul.Enabled = False
        TBKembaliPenulis.Enabled = False
        TBKembaliTglPinjam.Enabled = False
        TBKembaliTglKembali.Enabled = False
        TBTglDikembalikan.Enabled = False
        BtnAddDataPengembalian.Enabled = False
        BtnClearDataPengembalian.Enabled = False
    End Sub
    Private Sub ClearDataLapPeminjaman()
        TBLapKodePeminjaman.Text = String.Empty
        TBLapKodeBuku.Text = String.Empty
        TBLapKodeAnggota.Text = String.Empty
        TBLapNamaAnggota.Text = String.Empty
        TBLapJudul.Text = String.Empty
        TBLapPenulis.Text = String.Empty
        TBLapTglPeminjaman.Text = String.Empty
        TBLapTglPengembalian.Text = String.Empty
        CBLapStatus.Checked = False
        TBTglDikembalikan.Text = String.Empty
        TBLapKodePeminjaman.Enabled = False
        TBLapKodeBuku.Enabled = False
        TBLapKodeAnggota.Enabled = False
        TBLapNamaAnggota.Enabled = False
        TBLapJudul.Enabled = False
        TBLapPenulis.Enabled = False
        TBLapTglPeminjaman.Enabled = False
        TBLapTglPengembalian.Enabled = False
        CBLapStatus.Enabled = False
        TBTglDikembalikan.Text = False
        BtnSaveDataLapPeminjaman.Enabled = False
        BtnClearDataLapPeminjaman.Enabled = False
    End Sub



    'Function double-click datagrid
    Private Sub DataAdmin_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataAdmin.CellMouseDoubleClick
        TBAdminKode.Text = DataAdmin.CurrentRow.Cells(0).Value
        TBAdminNama.Text = DataAdmin.CurrentRow.Cells(1).Value
        TBAdminUser.Text = DataAdmin.CurrentRow.Cells(2).Value
        TBAdminPass.Text = DataAdmin.CurrentRow.Cells(3).Value
        TBAdminEmail.Text = DataAdmin.CurrentRow.Cells(4).Value
        TBAdminTelp.Text = DataAdmin.CurrentRow.Cells(5).Value
        CBAdminJK.Text = DataAdmin.CurrentRow.Cells(6).Value
        TBAdminLahir.Text = CDate(DataAdmin.CurrentRow.Cells(7).Value).ToString("yyyy-MM-dd")
        BtnAddAdmin.Enabled = False
        BtnSaveDataAdmin.Enabled = True
    End Sub
    Private Sub DataAnggota_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataAnggota.CellMouseDoubleClick
        TBAnggotaKode.Text = DataAnggota.CurrentRow.Cells(0).Value
        TBAnggotaNama.Text = DataAnggota.CurrentRow.Cells(1).Value
        TBAnggotaEmail.Text = DataAnggota.CurrentRow.Cells(2).Value
        TBAnggotaTelp.Text = DataAnggota.CurrentRow.Cells(3).Value
        CBAnggotaJK.Text = DataAnggota.CurrentRow.Cells(4).Value
        TBAnggotaLahir.Text = CDate(DataAnggota.CurrentRow.Cells(5).Value).ToString("yyyy-MM-dd")
        TBAnggotaGabung.Text = CDate(DataAnggota.CurrentRow.Cells(6).Value).ToString("yyyy-MM-dd")
        BtnAddDataAnggota.Enabled = False
        BtnSaveDataAnggota.Enabled = True
    End Sub
    Private Sub DataBuku_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataBuku.CellMouseDoubleClick
        TBBukuKode.Text = DataBuku.CurrentRow.Cells(0).Value
        TBBukuJudul.Text = DataBuku.CurrentRow.Cells(1).Value
        TBBukuPenulis.Text = DataBuku.CurrentRow.Cells(2).Value
        TBBukuPenerbit.Text = DataBuku.CurrentRow.Cells(3).Value
        TBBukuBahasa.Text = DataBuku.CurrentRow.Cells(4).Value
        TBBukuHal.Text = DataBuku.CurrentRow.Cells(5).Value
        TBBukuTerbit.Text = CDate(DataBuku.CurrentRow.Cells(6).Value).ToString("yyyy-MM-dd")
        TBBukuLokasi.Text = DataBuku.CurrentRow.Cells(7).Value
        CBBukuAda.Text = DataBuku.CurrentRow.Cells(8).Value
        BtnAddDataBuku.Enabled = False
        BtnSaveDataBuku.Enabled = True
    End Sub
    Private Sub DataPinjamBuku_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataPinjamBuku.CellMouseDoubleClick
        TBPinjamKodeBuku.Text = DataPinjamBuku.CurrentRow.Cells(0).Value
        TBPinjamJudul.Text = DataPinjamBuku.CurrentRow.Cells(1).Value
        TBPinjamJudul.Text = DataPinjamBuku.CurrentRow.Cells(2).Value
    End Sub
    Private Sub DataPeminjamanAnggota_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataPeminjamanAnggota.CellMouseDoubleClick
        TBPeminjamanKodeAnggota.Text = DataPeminjamanAnggota.CurrentRow.Cells(0).Value
        TBPinjamNamaAnggota.Text = DataPeminjamanAnggota.CurrentRow.Cells(1).Value
    End Sub
    Private Sub DataPengembalianBuku_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataPengembalian.CellMouseDoubleClick
        TBKodePeminjaman.Text = DataPengembalian.CurrentRow.Cells(0).Value
        TBKembaliKodeAnggota.Text = DataPengembalian.CurrentRow.Cells(2).Value
        TBKembaliNamaAnggota.Text = DataPengembalian.CurrentRow.Cells(3).Value
        TBKembaliKodeBuku.Text = DataPengembalian.CurrentRow.Cells(1).Value
        TBKembaliJudul.Text = DataPengembalian.CurrentRow.Cells(4).Value
        TBKembaliPenulis.Text = DataPengembalian.CurrentRow.Cells(5).Value
        TBKembaliTglPinjam.Text = CDate(DataPengembalian.CurrentRow.Cells(6).Value).ToString("yyyy-MM-dd")
        TBKembaliTglKembali.Text = CDate(DataPengembalian.CurrentRow.Cells(7).Value).ToString("yyyy-MM-dd")
    End Sub
    Private Sub DataLapPeminjaman_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataLapPeminjaman.CellMouseDoubleClick
        TBLapKodePeminjaman.Text = DataLapPeminjaman.CurrentRow.Cells(0).Value
        TBLapKodeBuku.Text = DataLapPeminjaman.CurrentRow.Cells(1).Value
        TBLapKodeAnggota.Text = DataLapPeminjaman.CurrentRow.Cells(2).Value
        TBLapNamaAnggota.Text = DataLapPeminjaman.CurrentRow.Cells(3).Value
        TBLapJudul.Text = DataLapPeminjaman.CurrentRow.Cells(4).Value
        TBLapPenulis.Text = DataLapPeminjaman.CurrentRow.Cells(5).Value
        TBLapTglPeminjaman.Text = CDate(DataLapPeminjaman.CurrentRow.Cells(6).Value).ToString("yyyy-MM-dd")
        TBLapTglPengembalian.Text = CDate(DataLapPeminjaman.CurrentRow.Cells(7).Value).ToString("yyyy-MM-dd")
        CBLapStatus.Checked = DataLapPeminjaman.CurrentRow.Cells(8).Value
        If CBLapStatus.Checked = True Then
            TBLapTglPengembalian.Text = CDate(DataLapPeminjaman.CurrentRow.Cells(9).Value).ToString("yyyy-MM-dd")
        Else
            TBLapTglPengembalian.Text = ""
        End If
    End Sub
    Private Sub DataLapDenda_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataLapDenda.CellMouseDoubleClick
        TBDendaKodePeminjaman.Text = DataLapDenda.CurrentRow.Cells(0).Value
        TBDendaKodeBuku.Text = DataLapDenda.CurrentRow.Cells(1).Value
        TBDendaKodeAnggota.Text = DataLapDenda.CurrentRow.Cells(2).Value
        TBDendaNamaAnggota.Text = DataLapDenda.CurrentRow.Cells(3).Value
        TBDendaJudul.Text = DataLapDenda.CurrentRow.Cells(4).Value
        TBDendaPenulis.Text = DataLapDenda.CurrentRow.Cells(5).Value
        TBDendaTglPeminjaman.Text = CDate(DataLapDenda.CurrentRow.Cells(6).Value).ToString("yyyy-MM-dd")
        TBDendaTglPengembalian.Text = CDate(DataLapDenda.CurrentRow.Cells(7).Value).ToString("yyyy-MM-dd")
        CBDendaStatus.Checked = DataLapDenda.CurrentRow.Cells(8).Value
        If CBDendaStatus.Checked = True Then
            TBDendaDikembalikan.Text = CDate(DataLapDenda.CurrentRow.Cells(9).Value).ToString("yyyy-MM-dd")
        Else
            TBDendaDikembalikan.Text = ""
        End If
        Dim dikembalikan As Date = TBDendaDikembalikan.Text
        Dim pengembalian As Date = TBDendaTglPengembalian.Text
        Dim keterlambatan As Integer = (dikembalikan.Date - pengembalian.Date).Days
        Dim jmlDenda As Integer = keterlambatan * 500
        TBDendaKeterlambatan.Text = keterlambatan.ToString + " hari"
        TBDendaJmlDenda.Text = jmlDenda.ToString("Rp #,###") + ",00"
    End Sub
End Class