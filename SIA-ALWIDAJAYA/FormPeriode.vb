Imports System.Data.OleDb
Public Class FormPeriode

    Dim mPosted As String

    Sub KondisiAwal()
        cbPeriode.Text = ""
        txtTglDari.Text = ""
        txtTglSampai.Text = ""
        btnTambah.Enabled = True
        btnSimpan.Enabled = False
        btnHapus.Enabled = False
        btnEdit.Enabled = False
        btnKeluar.Enabled = True
        btnKeluar.Text = "Keluar"
        btnEdit.Text = "Edit"
        btnHapus.Text = "Hapus"
        cbPeriode.Text = Format(Now.Year)
        txtTglDari.Text = Now
        txtTglSampai.Text = Now
        Tutup()
        MunculGrid()
    End Sub

    Sub Tutup()
        cbPeriode.Enabled = False
        txtTglDari.Enabled = False
        txtTglSampai.Enabled = False
    End Sub

    Sub Buka()
        cbPeriode.Enabled = True
        txtTglDari.Enabled = True
        txtTglSampai.Enabled = True
    End Sub

    Sub MunculGrid()
        Try
            BukaKoneksi()
            Da = New OleDbDataAdapter("Select * From tbl_periode", CONN)
            Ds = New DataSet
            Ds.Clear()
            Da.Fill(Ds, "tbl_periode")
            DataGridView1.DataSource = (Ds.Tables("tbl_periode"))
        Catch ex As Exception
        End Try
    End Sub

    Public Sub PosisiGrid()
        Try
            DataGridView1.Columns(0).Width = 78
            DataGridView1.Columns(1).Width = 130
            DataGridView1.Columns(2).Width = 130
            DataGridView1.Columns(3).Width = 100
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormPeriode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            KondisiAwal()
            BukaKoneksi()
            PosisiGrid()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            Buka()
            btnKeluar.Text = "Batal"
            btnEdit.Enabled = False
            btnHapus.Enabled = False
            btnSimpan.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If cbPeriode.Text = "" Or txtTglDari.Text = "" Or txtTglSampai.Text = "" Or Len(cbPeriode.Text) < 6 Then
                MsgBox("Pastikan Data diisi Lengkap atau digit periode kurang dari 6", MsgBoxStyle.Information, "")
            Else
                If mPosted = "Posted" Then
                    MsgBox("Periode ini sudah diposting, tidak bisa di simpan", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "")
                    KondisiAwal()
                Else
                    BukaKoneksi()
                    Dim SimpanData As String = "Insert into tbl_periode values ('" & cbPeriode.Text & "','" & txtTglDari.Text & "','" & txtTglSampai.Text & "', '" & "UnPosted" & "')"
                    Command = New OleDbCommand(SimpanData, CONN)
                    Command.ExecuteNonQuery()
                    MsgBox("Data berhasil ditambahkan", MsgBoxStyle.Information, "")
                    KondisiAwal()
                End If
            End If
        Catch ex As Exception
            MsgBox("Data tidak bisa tersimpan karena periode ini sudah ada...", MsgBoxStyle.Exclamation, "Error")
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
            ElseIf mPosted = "Posted" Then
                MsgBox("Periode ini sudah diPosting, tidak bisa diEdit", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pesan")
                KondisiAwal()
                Else
                    BukaKoneksi()
                Dim EditData As String = "Update tbl_periode set DariTgl='" & txtTglDari.Text & "',SampaiTgl='" & txtTglSampai.Text & "' where Periode= '" & cbPeriode.Text & "'"
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
            If mPosted = "Posted" Then
                MsgBox("Periode ini sudah diposting", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pesan")
            ElseIf ans = vbYes Then
                    BukaKoneksi()
                    Dim EditData As String = "Delete from tbl_periode where Periode= '" & cbPeriode.Text & "'"
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

    Private Sub cbPeriode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbPeriode.KeyPress
        If e.KeyChar = Chr(13) Then
            If cbPeriode.Text = "" Then
                MsgBox("Periode masih kosong, silahkan diisi", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pesan")
                cbPeriode.Focus()
            Else
                txtTglDari.Focus()
            End If
        End If
    End Sub

    Private Sub cbPeriode_KeyUp(sender As Object, e As KeyEventArgs) Handles cbPeriode.KeyUp
        If e.KeyCode = Keys.Escape Then
        End If
    End Sub

    Private Sub cbPeriode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPeriode.SelectedIndexChanged
        Try
            BukaKoneksi()
            Command = New OleDbCommand("Select * from tbl_periode where Periode ='" & cbPeriode.Text & "'", CONN)
            Rd = Command.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                txtTglDari.Text = Rd!DariTgl
                txtTglSampai.Text = Rd!SampaiTgl
                mPosted = Rd!Keterangan
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtTglDari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTglDari.KeyPress
        If e.KeyChar = Chr(13) Then
            txtTglSampai.Focus()
        End If
    End Sub

    Private Sub txtTglSampai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTglSampai.KeyPress
        If e.KeyChar = Chr(13) Then
            btnSimpan.Focus()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index

            cbPeriode.Text = DataGridView1.Item(0, i).Value
            txtTglDari.Text = DataGridView1.Item(1, i).Value
            txtTglSampai.Text = DataGridView1.Item(2, i).Value
            mPosted = DataGridView1.Item(3, i).Value
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