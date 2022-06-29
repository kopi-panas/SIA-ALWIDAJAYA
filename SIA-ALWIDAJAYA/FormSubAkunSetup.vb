Imports System.Data.OleDb
Public Class FormSubAkunSetup

    Private Sub PosisiList()
        With ListView1.Columns
            .Add("No Akun", 100)
            .Add("Nama Akun", 300)
        End With
    End Sub

    Private Sub IsiList()
        Try
            Query = "SELECT * FROM tbl_coa"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            ListView1.Items.Clear()
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With ListView1
                    .Items.Add(Ds.Tables(0).Rows(a).Item(0))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(1))
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
        With ListView1.SelectedItems
            FormSetupSaldoAwal.txtNoAkun.Text = .Item(0).SubItems(0).Text
            FormSetupSaldoAwal.lblNamaAkun.Text = .Item(0).SubItems(1).Text
        End With
    End Sub

    Private Sub FormSubAkunSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            BukaKoneksi()
            PosisiList()
            IsiList()
        Catch ex As Exception
            MsgBox("Koneksi ke database gagal")
        End Try
    End Sub

    Private Sub btnYa_Click(sender As Object, e As EventArgs) Handles btnYa.Click
        AmbilData()
        Me.Close()
    End Sub

    Private Sub btnTidak_Click(sender As Object, e As EventArgs) Handles btnTidak.Click
        Me.Close()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        AmbilData()
        Me.Close()
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        If e.KeyChar = Chr(13) Then
            AmbilData()
            Me.Close()
        End If
    End Sub
End Class