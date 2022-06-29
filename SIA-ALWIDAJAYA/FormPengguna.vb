Imports System.Data.OleDb
Public Class FormPengguna
    Sub KondisiAwal()
        txtKodePengguna.Text = ""
        txtNamaPengguna.Text = ""
        txtPassword.Text = ""
        cbLevel.Text = ""
        btnTambah.Enabled = True
        btnSimpan.Enabled = False
        btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnKeluar.Enabled = True
        btnKeluar.Text = "Keluar"
        btnEdit.Text = "Edit"
        btnHapus.Text = "Hapus"
        MunculGrid()
        Tutup()
    End Sub

    Sub Tutup()
        txtKodePengguna.Enabled = False
        txtNamaPengguna.Enabled = False
        txtPassword.Enabled = False
        cbLevel.Enabled = False
    End Sub

    Sub Buka()
        txtKodePengguna.Enabled = True
        txtNamaPengguna.Enabled = True
        txtPassword.Enabled = True
        cbLevel.Enabled = True
    End Sub

    Sub MunculGrid()
        Try
            BukaKoneksi()
            Da = New OleDbDataAdapter("Select * From tbl_pengguna", CONN)
            Ds = New DataSet
            Ds.Clear()
            Da.Fill(Ds, "tbl_pengguna")
            DataGridView1.DataSource = (Ds.Tables("tbl_pengguna"))
        Catch ex As Exception
        End Try
    End Sub

    Public Sub PosisiGrid()
        Try
            DataGridView1.Columns(0).Width = 90
            DataGridView1.Columns(1).Width = 130
            DataGridView1.Columns(2).Width = 100
            DataGridView1.Columns(3).Width = 75
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormPengguna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            txtKodePengguna.Focus()
            btnEdit.Enabled = False
            btnHapus.Enabled = False
            btnSimpan.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        If btnKeluar.Text = "Batal" Then
            Call KondisiAwal()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If txtKodePengguna.Text = "" Or txtNamaPengguna.Text = "" Or txtPassword.Text = "" Or cbLevel.Text = "" Then
                MsgBox("Pastikan Data diisi Lengkap!", MsgBoxStyle.Information, "")
            Else
                BukaKoneksi()
                Dim Simpan As String
                Simpan = "INSERT INTO tbl_pengguna VALUES ('" & txtKodePengguna.Text & "','" & txtNamaPengguna.Text & "','" & txtPassword.Text & "','" & cbLevel.Text & "')"
                Command = New OleDb.OleDbCommand(Simpan, CONN)
                Command.ExecuteNonQuery()
                MsgBox("Berhasil Ditambahkan", MsgBoxStyle.Information, "")
                KondisiAwal()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Buka()
            txtKodePengguna.Enabled = False
            If btnEdit.Text = "Edit" Then
                btnEdit.Text = "Update"
                btnTambah.Enabled = False
                btnSimpan.Enabled = False
                btnHapus.Enabled = False
                btnKeluar.Text = "Batal"
                txtNamaPengguna.Focus()
            ElseIf txtKodePengguna.Text = "" Or txtNamaPengguna.Text = "" Or txtPassword.Text = "" Then
                MsgBox("Pastikan Data diisi Lengkap!", MsgBoxStyle.Information, "")
            Else
                BukaKoneksi()
                Dim EditData As String = "Update tbl_pengguna set NamaPengguna='" & txtNamaPengguna.Text & "',Password='" & txtPassword.Text & "',level='" & cbLevel.Text & "' where KodePengguna= '" & txtKodePengguna.Text & "'"
                Command = New OleDbCommand(EditData, CONN)
                Command.ExecuteNonQuery()
                MsgBox("Data berhasil di Update", MsgBoxStyle.Information, "")
                KondisiAwal()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
       Try
            Dim ans As String
            ans = MsgBox("Anda Yakin Ingin Menghapus?", MsgBoxStyle.YesNo, "Konfirmasi")
            If ans = vbYes Then
                Dim EditData As String = "Delete from tbl_pengguna where KodePengguna= '" & txtKodePengguna.Text & "'"
                Command = New OleDbCommand(EditData, CONN)
                Command.ExecuteNonQuery()
                MsgBox("Data berhasil di Hapus", MsgBoxStyle.Information, "")
                KondisiAwal()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtKodePengguna_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodePengguna.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                BukaKoneksi()
                Command = New OleDbCommand("Select * from tbl_pengguna where KodePengguna ='" & txtKodePengguna.Text & "'", CONN)
                Rd = Command.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    txtNamaPengguna.Text = Rd.Item("NamaPengguna")
                    txtPassword.Text = Rd.Item("Password")
                    cbLevel.Text = Rd.Item("level")
                Else
                    MsgBox("Data Tidak Ada", MsgBoxStyle.Information, "")
                    txtNamaPengguna.Focus()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtNamaPengguna_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNamaPengguna.KeyPress
        If e.KeyChar = Chr(13) Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Chr(13) Then
                txtPassword.Focus()
            End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index

            txtKodePengguna.Text = DataGridView1.Item(0, i).Value
            txtNamaPengguna.Text = DataGridView1.Item(1, i).Value
            txtPassword.Text = DataGridView1.Item(2, i).Value
            cbLevel.Text = DataGridView1.Item(3, i).Value
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