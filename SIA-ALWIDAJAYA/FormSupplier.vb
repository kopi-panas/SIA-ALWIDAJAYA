Imports System.Data.OleDb
Public Class FormSupplier
    Sub KondisiAwal()
        txtKodeSupp.Text = ""
        txtNamaSupp.Text = ""
        txtAlamatSupp.Text = ""
        txtTelepon.Text = ""
        btnTambah.Enabled = True
        btnSimpan.Enabled = False
        btnHapus.Enabled = False
        btnEdit.Enabled = False
        btnKeluar.Enabled = True
        btnKeluar.Text = "Keluar"
        btnEdit.Text = "Edit"
        btnHapus.Text = "Hapus"
        MunculGrid()
        Tutup()
    End Sub

    Sub Tutup()
        txtKodeSupp.Enabled = False
        txtNamaSupp.Enabled = False
        txtAlamatSupp.Enabled = False
        txtTelepon.Enabled = False
    End Sub

    Sub Buka()
        txtKodeSupp.Enabled = True
        txtNamaSupp.Enabled = True
        txtAlamatSupp.Enabled = True
        txtTelepon.Enabled = True
    End Sub

    Sub MunculGrid()
        Try
            BukaKoneksi()
            Da = New OleDbDataAdapter("Select * From tbl_supplier", CONN)
            Ds = New DataSet
            Ds.Clear()
            Da.Fill(Ds, "tbl_supplier")
            DataGridView1.DataSource = (Ds.Tables("tbl_supplier"))
        Catch ex As Exception
        End Try
    End Sub

    Public Sub PosisiGrid()
        Try
            DataGridView1.Columns(0).Width = 90
            DataGridView1.Columns(1).Width = 150
            DataGridView1.Columns(2).Width = 170
            DataGridView1.Columns(3).Width = 100
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            txtKodeSupp.Focus()
            btnEdit.Enabled = False
            btnHapus.Enabled = False
            btnSimpan.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If txtKodeSupp.Text = "" Or txtNamaSupp.Text = "" Or txtAlamatSupp.Text = "" Or txtTelepon.Text = "" Then
                MsgBox("Pastikan Data diisi Lengkap!", MsgBoxStyle.Information, "")
            Else
                BukaKoneksi()
                Dim SimpanData As String = "Insert into tbl_supplier values ('" & txtKodeSupp.Text & "','" & txtNamaSupp.Text & "','" & txtAlamatSupp.Text & "','" & txtTelepon.Text & "')"
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
            txtKodeSupp.Enabled = False
            If btnEdit.Text = "Edit" Then
                btnEdit.Text = "Update"
                btnTambah.Enabled = False
                btnSimpan.Enabled = False
                btnHapus.Enabled = False
                btnKeluar.Text = "Batal"
                txtNamaSupp.Focus()
            ElseIf txtKodeSupp.Text = "" Or txtNamaSupp.Text = "" Or txtAlamatSupp.Text = "" Or txtTelepon.Text = "" Then
                MsgBox("Pastikan Data diisi Lengkap!", MsgBoxStyle.Information, "")
            Else
                BukaKoneksi()
                Dim EditData As String = "Update tbl_supplier set NamaSupplier='" & txtNamaSupp.Text & "',AlamatSupplier='" & txtAlamatSupp.Text & "',TeleponSupplier='" & txtTelepon.Text & "' where KodeSupplier= '" & txtKodeSupp.Text & "'"
                Command = New OleDbCommand(EditData, CONN)
                Command.ExecuteNonQuery()
                MsgBox("Data berhasil di Update", MsgBoxStyle.Information, "")
                Call KondisiAwal()
                End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Try
            Dim ans As String
            ans = MsgBox("Anda Yakin Ingin Menghapus?", MsgBoxStyle.YesNo, "Konfirmasi")
            If ans = vbYes Then
                BukaKoneksi()
                Dim EditData As String = "Delete from tbl_supplier where KodeSupplier= '" & txtKodeSupp.Text & "'"
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

    Private Sub txtKodeSupp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodeSupp.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                BukaKoneksi()
                Command = New OleDbCommand("Select * from tbl_supplier where KodeSupplier ='" & txtKodeSupp.Text & "'", CONN)
                Rd = Command.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    txtNamaSupp.Text = Rd.Item("NamaSupplier")
                    txtAlamatSupp.Text = Rd.Item("AlamatSupplier")
                    txtTelepon.Text = Rd.Item("TeleponSupplier")
                Else
                    MsgBox("Data Tidak Ada", MsgBoxStyle.Information, "")
                    txtNamaSupp.Focus()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtNamaSupp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNamaSupp.KeyPress
        If e.KeyChar = Chr(13) Then
            txtAlamatSupp.Focus()
        End If
    End Sub

    Private Sub txtAlamatSupp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAlamatSupp.KeyPress
        If e.KeyChar = Chr(13) Then
            txtTelepon.Focus()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index

            txtKodeSupp.Text = DataGridView1.Item(0, i).Value
            txtNamaSupp.Text = DataGridView1.Item(1, i).Value
            txtAlamatSupp.Text = DataGridView1.Item(2, i).Value
            txtTelepon.Text = DataGridView1.Item(3, i).Value
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