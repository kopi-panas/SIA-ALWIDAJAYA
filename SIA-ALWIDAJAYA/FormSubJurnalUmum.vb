Imports System.Data.OleDb
Public Class FormSubJurnalUmum

    Sub dgv()
        Dim band As DataGridViewBand = DataGridView1.Columns(4)
        band.Visible = False
    End Sub

    Private Sub IsiGrid()
        Try
            BukaKoneksi()
            Da = New OleDbDataAdapter("SELECT tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status FROM(tbl_jurnalumum) GROUP BY tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status HAVING(((tbl_jurnalumum.Periode) = '" & cbPeriode.Text & "')) ORDER BY tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status", CONN)
            Ds = New DataSet
            Ds.Clear()
            Da.Fill(Ds, "tbl_jurnalumum")
            DataGridView1.DataSource = (Ds.Tables("tbl_jurnalumum"))
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With DataGridView1
                    .Columns.Add(Ds.Tables(0).Rows(a).Item(0))
                    .Columns.Add(Ds.Tables(0).Rows(a).Item(1))
                    .Columns.Add(Ds.Tables(0).Rows(a).Item(2))
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub IsiPeriode()
        Try
            Query = "SELECT * FROM tbl_periode ORDER BY Periode Desc"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            cbPeriode.Items.Clear()
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With cbPeriode
                    .Items.Add(Ds.Tables(0).Rows(a).Item(0))
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormSubJurnalUmum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            BukaKoneksi()
            IsiPeriode()
            cbPeriode.Text = FormJurnalUmum.lblPeriode.Text
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub btnYa_Click(sender As Object, e As EventArgs) Handles btnYa.Click
        Me.Close()
        FormJurnalUmum.IsiListGridDJurnal()
        'FormJurnalUmum.RumusSubDebet()
        'FormJurnalUmum.RumusSubKredit()
    End Sub

    Private Sub txtNoTransaksi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoTransaksi.KeyPress
        If e.KeyChar = Chr(13) Then
            BukaKoneksi()
            Command = New OleDbCommand("Select * from tbl_jurnalumum where NoTransaksi= '" & txtNoTransaksi.Text & "'", CONN)
            Rd = Command.ExecuteReader
            Rd.Read()
        End If
    End Sub

    Private Sub cbPeriode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbPeriode.KeyPress
        If e.KeyChar = Chr(13) Then
            If cbPeriode.Text = "" Then
                MsgBox("Periode kosong", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pesan Periode")
                cbPeriode.Focus()
            Else
                txtNoTransaksi.Focus()
            End If
        End If
    End Sub

    Private Sub cbPeriode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPeriode.SelectedIndexChanged
        Try
            IsiGrid()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index

            FormJurnalUmum.lblPeriode.Text = DataGridView1.Item(0, i).Value
            FormJurnalUmum.txtTgl.Text = DataGridView1.Item(1, i).Value
            FormJurnalUmum.lblNoTransaksi.Text = DataGridView1.Item(2, i).Value
            FormJurnalUmum.txtKeterangan.Text = DataGridView1.Item(3, i).Value
            FormJurnalUmum.mPosted = DataGridView1.Item(4, i).Value
            FormJurnalUmum.btnTambah.Enabled = False
            FormJurnalUmum.btnSimpan.Enabled = False
            FormJurnalUmum.btnBatal.Enabled = True
            FormJurnalUmum.btnHapus.Enabled = True
            btnKeluar.Enabled = True
        Catch ex As Exception
            MsgBox("Tidak ada data yang dipilih!", MsgBoxStyle.Information, "")
        End Try
    End Sub

End Class