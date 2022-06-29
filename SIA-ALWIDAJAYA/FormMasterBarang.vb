Imports System.Data.OleDb
Public Class FormMasterBarang
    Sub KondisiAwal()
        txtKodeBarang.Text = ""
        txtNamaBarang.Text = ""
        txtHarga.Text = ""
        txtJumlah.Text = ""
        cbSatuan.Text = ""
        btnTambah.Enabled = True
        btnSimpan.Enabled = False
        btnHapus.Enabled = False
        btnEdit.Enabled = False
        btnKeluar.Enabled = True
        btnKeluar.Text = "Keluar"
        btnHapus.Text = "Hapus"
        btnEdit.Text = "Edit"
        MunculGrid()
        MunculSatuan()
        Tutup()
    End Sub

    Sub Tutup()
        txtKodeBarang.Enabled = False
        txtNamaBarang.Enabled = False
        txtHarga.Enabled = False
        txtJumlah.Enabled = False
        cbSatuan.Enabled = False
    End Sub

    Sub Buka()
        txtKodeBarang.Enabled = True
        txtNamaBarang.Enabled = True
        txtHarga.Enabled = True
        txtJumlah.Enabled = True
        cbSatuan.Enabled = True
    End Sub

    Sub MunculGrid()
        Try
            BukaKoneksi()
            Da = New OleDbDataAdapter("Select * From tbl_barang", CONN)
            Ds = New DataSet
            Ds.Clear()
            Da.Fill(Ds, "tbl_barang")
            DataGridView1.DataSource = (Ds.Tables("tbl_barang"))
        Catch ex As Exception
        End Try
    End Sub

    Public Sub PosisiGrid()
        Try
            DataGridView1.Columns(0).Width = 85
            DataGridView1.Columns(1).Width = 180
            DataGridView1.Columns(2).Width = 100
            DataGridView1.Columns(3).Width = 95
            DataGridView1.Columns(4).Width = 100
        Catch ex As Exception
        End Try
    End Sub

    Sub MunculSatuan()
        BukaKoneksi()
        Command = New OleDbCommand("Select Distinct SatuanBarang from tbl_barang", CONN)
        Rd = Command.ExecuteReader
        cbSatuan.Items.Clear()
        Do While Rd.Read
            cbSatuan.Items.Add(Rd.Item("SatuanBarang"))
        Loop
    End Sub

    Private Sub FormMasterBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            KondisiAwal()
            PosisiGrid()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            Buka()
            btnKeluar.Text = "Batal"
            txtKodeBarang.Focus()
            btnEdit.Enabled = False
            btnHapus.Enabled = False
            btnSimpan.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If txtKodeBarang.Text = "" Or txtNamaBarang.Text = "" Or txtHarga.Text = "" Or txtJumlah.Text = "" Or cbSatuan.Text = "" Then
                MsgBox("Pastikan Data diisi Lengkap!", MsgBoxStyle.Information, "")
            Else
                BukaKoneksi()
                Dim SimpanData As String = "Insert into tbl_barang values ('" & txtKodeBarang.Text & "','" & txtNamaBarang.Text & "','" & txtHarga.Text & "','" & txtJumlah.Text & "','" & cbSatuan.Text & "')"
                Command = New OleDbCommand(SimpanData, CONN)
                Command.ExecuteNonQuery()
                MsgBox("Data berhasil ditambahkan", MsgBoxStyle.Information, "")
                KondisiAwal()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Buka()
            txtKodeBarang.Enabled = False
            If btnEdit.Text = "Edit" Then
                btnEdit.Text = "Update"
                btnTambah.Enabled = False
                btnSimpan.Enabled = False
                btnHapus.Enabled = False
                btnKeluar.Text = "Batal"
                txtNamaBarang.Focus()
            ElseIf txtKodeBarang.Text = "" Or txtNamaBarang.Text = "" Or txtHarga.Text = "" Or txtJumlah.Text = "" Or cbSatuan.Text = "" Then
                MsgBox("Pastikan Data diisi Lengkap!", MsgBoxStyle.Information, "")
            Else
                BukaKoneksi()
                Dim EditData As String = "Update tbl_barang set NamaBarang='" & txtNamaBarang.Text & "',HargaBarang='" & txtHarga.Text & "',JumlahBarang='" & txtJumlah.Text & "',SatuanBarang='" & cbSatuan.Text & "' where KodeBarang= '" & txtKodeBarang.Text & "'"
                Command = New OleDbCommand(EditData, CONN)
                Command.ExecuteNonQuery()
                MsgBox("Data berhasil di Update", MsgBoxStyle.Information, "")
                KondisiAwal()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Try
            'Buka()
            'If btnHapus.Text = "Hapus" Then
            '    btnHapus.Text = "Hapus Data"
            '    btnTambah.Enabled = False
            '    btnSimpan.Enabled = False
            '    btnEdit.Enabled = False
            '    btnKeluar.Text = "Batal"
            '    txtKodeBarang.Focus()
            'ElseIf txtKodeBarang.Text = "" Or txtNamaBarang.Text = "" Or txtHarga.Text = "" Or txtJumlah.Text = "" Or cbSatuan.Text = "" Then
            '    MsgBox("Pastikan Data diisi Lengkap!")
            'Else
            Dim ans As String
            ans = MsgBox("Anda Yakin Ingin Menghapus?", MsgBoxStyle.YesNo, "Konfirmasi")
            If ans = vbYes Then
                BukaKoneksi()
                Dim EditData As String = "Delete from tbl_barang where KodeBarang= '" & txtKodeBarang.Text & "'"
                Command = New OleDbCommand(EditData, CONN)
                Command.ExecuteNonQuery()
                MsgBox("Data berhasil di Hapus", MsgBoxStyle.Information, "")
                KondisiAwal()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        If btnKeluar.Text = "Batal" Then
            KondisiAwal()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub txtKodeBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodeBarang.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                BukaKoneksi()
                Command = New OleDbCommand("Select * from tbl_barang where KodeBarang ='" & txtKodeBarang.Text & "'", CONN)
                Rd = Command.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    txtNamaBarang.Text = Rd.Item("NamaBarang")
                    txtHarga.Text = Rd.Item("HargaBarang")
                    txtJumlah.Text = Rd.Item("JumlahBarang")
                    cbSatuan.Text = Rd.Item("SatuanBarang")
                Else
                    MsgBox("Data Tidak Ada", MsgBoxStyle.Information, "")
                    txtNamaBarang.Focus()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtNamaBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNamaBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            txtHarga.Focus()
        End If
    End Sub

    Private Sub txtHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHarga.KeyPress
        If e.KeyChar = Chr(13) Then
            txtJumlah.Focus()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index

            txtKodeBarang.Text = DataGridView1.Item(0, i).Value
            txtNamaBarang.Text = DataGridView1.Item(1, i).Value
            txtHarga.Text = DataGridView1.Item(2, i).Value
            txtJumlah.Text = DataGridView1.Item(3, i).Value
            cbSatuan.Text = DataGridView1.Item(4, i).Value
            btnTambah.Enabled = True
            btnSimpan.Enabled = False
            btnEdit.Enabled = True
            btnHapus.Enabled = True
            btnKeluar.Enabled = True
        Catch ex As Exception
            MsgBox("Tidak ada data yang dipilih!", MsgBoxStyle.Information, "")
        End Try
    End Sub

End Class