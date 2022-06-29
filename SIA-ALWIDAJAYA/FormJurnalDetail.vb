Imports System.Data.OleDb
Public Class FormJurnalDetail

    Private Sub PosisiList()
        With ListView1.Columns
            .Add("Periode", 0)
            .Add("Tanggal", 90, HorizontalAlignment.Right)
            .Add("No.Transaksi", 110)
            .Add("Keterangan", 325)
            .Add("Status", 0)
        End With
    End Sub

    Private Sub IsiList()
        Try
            Query = "SELECT tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status FROM(tbl_jurnalumumv) GROUP BY tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status HAVING(((tbl_jurnalumum.Periode) = '" & cbPeriode.Text & "')) ORDER BY tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status "

            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            ListView1.Items.Clear()
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With ListView1
                    .Items.Add(Ds.Tables(0).Rows(a).Item(0))
                    .Items(a).SubItems.Add(Format(Ds.Tables(0).Rows(a).Item(1), "dd/MM/yyyy"))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(2))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(3))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(4))
                    If (a Mod 2 = 0) Then
                        .Items(a).BackColor = Color.LightSteelBlue
                    Else
                        .Items(a).BackColor = Color.LightBlue
                    End If
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AmbilData()
        Try
            With ListView1.SelectedItems
                FormJurnalUmum.lblPeriode.Text = .Item(0).SubItems(0).Text
                FormJurnalUmum.txtTgl.Text = .Item(0).SubItems(1).Text
                FormJurnalUmum.lblNoTransaksi.Text = .Item(0).SubItems(2).Text
                FormJurnalUmum.txtKeterangan.Text = .Item(0).SubItems(3).Text
                FormJurnalUmum.mPosted = .Item(0).SubItems(4).Text
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub IsiComboPeriode()
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

    Private Sub FormJurnalDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            BukaKoneksi()
            cbPeriode.Text = FormJurnalUmum.lblPeriode.Text

            PosisiList()
            IsiList()
            IsiComboPeriode()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        AmbilData()
        FormJurnalUmum.IsiListGridDJurnal()
        FormJurnalUmum.RumusSubDebet()
        FormJurnalUmum.RumusSubKredit()
    End Sub

    Private Sub btnYa_Click(sender As Object, e As EventArgs) Handles btnYa.Click
        AmbilData()
        FormJurnalUmum.IsiListGridDJurnal()
        FormJurnalUmum.RumusSubDebet()
        FormJurnalUmum.RumusSubKredit()
    End Sub

    Private Sub txtNoTransaksi_TextChanged(sender As Object, e As EventArgs) Handles txtNoTransaksi.TextChanged
        Try
            Query = "SELECT tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status FROM(tbl_jurnalumum) GROUP BY tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status HAVING(((tbl_jurnalumum.Periode) = '" & cbPeriode.Text & "') And ((tbl_jurnalumum.NoTransaksi) Like '" & txtNoTransaksi.Text & "%" & "')) ORDER BY tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            ListView1.Items.Clear()
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With ListView1
                    .Items.Add(Ds.Tables(0).Rows(a).Item(0))
                    .Items(a).SubItems.Add(Format(Ds.Tables(0).Rows(a).Item(1), "dd/MM/yyyy"))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(2))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(3))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(4))
                    If (a Mod 2 = 0) Then
                        .Items(a).BackColor = Color.LightSteelBlue
                    Else
                        .Items(a).BackColor = Color.LightBlue
                    End If
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbPeriode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPeriode.SelectedIndexChanged
        Try
            Query = "SELECT tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status FROM(tbl_jurnalumum) GROUP BY tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status HAVING(((tbl_jurnalumum.Periode) = '" & cbPeriode.Text & "')) ORDER BY tbl_jurnalumum.Periode DESC , tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            ListView1.Items.Clear()
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With ListView1
                    .Items.Add(Ds.Tables(0).Rows(a).Item(0))
                    .Items(a).SubItems.Add(Format(Ds.Tables(0).Rows(a).Item(1), "dd/MM/yyyy"))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(2))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(3))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(4))
                    If (a Mod 2 = 0) Then
                        .Items(a).BackColor = Color.LightSteelBlue
                    Else
                        .Items(a).BackColor = Color.LightBlue
                    End If
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub
End Class