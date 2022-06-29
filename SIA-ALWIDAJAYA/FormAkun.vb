Imports System.Data.OleDb
Public Class FormAkun
    Sub KondisiAwal()
        txtNoAkun.Text = ""
        txtNamaAkun.Text = ""
        cbKelompok.Text = ""
        cbKet.Text = ""
        btnTambah.Enabled = True
        btnSimpan.Enabled = False
        btnHapus.Enabled = False
        btnEdit.Enabled = False
        btnKeluar.Enabled = True
        btnKeluar.Text = "Keluar"
        btnHapus.Text = "Hapus"
        btnEdit.Text = "Edit"
        Tutup()
        MunculGrid()
    End Sub

    Sub Tutup()
        txtNoAkun.Enabled = False
        txtNamaAkun.Enabled = False
        cbKelompok.Enabled = False
        cbKet.Enabled = False
    End Sub

    Sub Buka()
        txtNoAkun.Enabled = True
        txtNamaAkun.Enabled = True
        cbKelompok.Enabled = True
        cbKet.Enabled = True
    End Sub

    Private Sub FormAkun_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            KondisiAwal()
            PosisiGrid()
        Catch ex As Exception
        End Try
    End Sub

    Sub MunculGrid()
        Try
            BukaKoneksi()
            Da = New OleDbDataAdapter("Select * From tbl_coa", CONN)
            Ds = New DataSet
            Ds.Clear()
            Da.Fill(Ds, "tbl_coa")
            DataGridView1.DataSource = (Ds.Tables("tbl_coa"))
        Catch ex As Exception
        End Try
    End Sub

    Public Sub PosisiGrid()
        Try
            DataGridView1.Columns(0).Width = 85
            DataGridView1.Columns(1).Width = 210
            DataGridView1.Columns(2).Width = 100
            DataGridView1.Columns(3).Width = 105
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtNoAkun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoAkun.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                BukaKoneksi()
                Command = New OleDbCommand("Select * from tbl_coa where NoAkun ='" & txtNoAkun.Text & "'", CONN)
                Rd = Command.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    txtNamaAkun.Text = Rd.Item("NamaAkun")
                    cbKelompok.Text = Rd.Item("Kelompok")
                    cbKet.Text = Rd.Item("Keterangan")
                Else
                    MsgBox("Data Tidak Ada", MsgBoxStyle.Information, "")
                    txtNamaAkun.Focus()
                End If
            End If
        Catch ex As Exception
        End Try
        'If e.KeyChar = Chr(13) Then
        '    txtNamaAkun.Focus()
        'End If
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            Buka()
            btnKeluar.Text = "Batal"
            txtNoAkun.Focus()
            btnEdit.Enabled = False
            btnHapus.Enabled = False
            btnSimpan.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If txtNoAkun.Text = "" Or txtNoAkun.Text = "" Or cbKelompok.Text = "" Or cbKet.Text = "" Then
                MsgBox("Pastikan Data diisi Lengkap!", MsgBoxStyle.Information, "")
            Else
                BukaKoneksi()
                Dim SimpanData As String = "Insert into tbl_coa values ('" & txtNoAkun.Text & "','" & txtNamaAkun.Text & "','" & cbKelompok.Text & "','" & cbKet.Text & "')"
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
            If btnEdit.Text = "Edit" Then
                btnEdit.Text = "Update"
                btnTambah.Enabled = False
                btnSimpan.Enabled = False
                btnHapus.Enabled = False
                btnKeluar.Text = "Batal"
                txtNoAkun.Focus()
            ElseIf txtNoAkun.Text = "" Or txtNoAkun.Text = "" Or cbKelompok.Text = "" Or cbKet.Text = "" Then
                MsgBox("Pastikan Data diisi Lengkap!", MsgBoxStyle.Information, "")
            Else
                BukaKoneksi()
                Dim EditData As String = "Update tbl_coa set NamaAkun='" & txtNamaAkun.Text & "',Kelompok='" & cbKelompok.Text & "',Keterangan='" & cbKet.Text & "' where NoAkun= '" & txtNoAkun.Text & "'"
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
            Dim ans As String
            ans = MsgBox("Anda Yakin Ingin Menghapus?", MsgBoxStyle.YesNo, "Konfirmasi")
            If ans = vbYes Then
                BukaKoneksi()
                Dim EditData As String = "Delete from tbl_coa where NoAkun= '" & txtNoAkun.Text & "'"
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index

            txtNoAkun.Text = DataGridView1.Item(0, i).Value
            txtNamaAkun.Text = DataGridView1.Item(1, i).Value
            cbKelompok.Text = DataGridView1.Item(2, i).Value
            cbKet.Text = DataGridView1.Item(3, i).Value
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
