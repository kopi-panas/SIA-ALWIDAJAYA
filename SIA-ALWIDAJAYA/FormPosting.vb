Imports System.Data.OleDb
Public Class FormPosting

    Private Sub isicboPeriode()
        Try
            Query = "SELECT tbl_periode.Periode, tbl_periode.Keterangan FROM tbl_periode WHERE (((tbl_periode.Keterangan)= '" & "UnPosted" & "')) ORDER BY tbl_periode.Periode"
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

    Private Sub MembuatPeriodeBerikutnya()
        Try
            If Microsoft.VisualBasic.Right(cbPeriode.Text, 2) = "12" Then
                lblPeriodeBerikutnya.Text = Microsoft.VisualBasic.Left(cbPeriode.Text, 4) + 1 & "01"
            Else
                lblPeriodeBerikutnya.Text = cbPeriode.Text + 1
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormPosting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            BukaKoneksi()
            isicboPeriode()
        Catch ex As Exception
            MsgBox("Koneksi ke database gagal")
        End Try
    End Sub

    'memposting data dari jurnal umum, ajp, dan saldo bulan lalu
    Private Sub btnPosting_Click(sender As Object, e As EventArgs) Handles btnPosting.Click
        Try
            Dim objPosting As New ClassPosting

            Dim mKeterangan As String

            If cbPeriode.Text = "" Then
                MsgBox("Silahkan pilih periode yang diposting", vbExclamation + MsgBoxStyle.OkOnly, "Pesan")
                cbPeriode.Focus()
            Else
                Query = "SELECT Periode, Keterangan FROM tbl_periode WHERE Periode = '" & cbPeriode.Text & "'"
                Da = New OleDbDataAdapter(Query, CONN)
                Ds = New DataSet
                Da.Fill(Ds)

                If Ds.Tables(0).Rows.Count = 0 Then
                    mKeterangan = 0
                Else
                    mKeterangan = Ds.Tables(0).Rows(0).Item(1)
                End If

                If mKeterangan = "UnPosted" Then
                    With objPosting
                        .InsertBukuBesar()
                        .InsertBukuBesarAJP()
                        .InsertNeracaSaldo()
                        .InsertNeracaSaldoAJP()
                        .InsertNeracaLajur()
                        .InsertRugiLaba()
                        .PerubahanModal()
                        .UpdatePrive()
                        .NilaiNeraca()
                        .NilaiNeracaAkumulasi()
                        .UpdateModal()
                        .InsertLabaTakDibagi()
                        .UpDateSaldoAwal()
                        .SaldoBulanLalu()
                        .InsertKeteranganSaldoAwal() 'Menerangkan bahwa setup saldo awal sudah diPosted
                        MsgBox("Proses posting sudah selesai...", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan prosesposting")
                    End With
                Else
                    MsgBox("Maaf... periode ini sudah diposting", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan prosesposting")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub cbPeriode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbPeriode.KeyPress
        MembuatPeriodeBerikutnya()
    End Sub

    Private Sub cbPeriode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPeriode.SelectedIndexChanged
        MembuatPeriodeBerikutnya()
    End Sub
End Class