Imports System.Data.OleDb
Public Class FormCetakSubJU

    Private Sub FormCetakSubJU_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub btnJU_Click(sender As Object, e As EventArgs) Handles btnJU.Click
        jurnalumum.Show()
    End Sub

    Private Sub btnBB_Click(sender As Object, e As EventArgs) Handles btnBB.Click
        jurnalumum.Hide()
        'neracasaldo.Hide()
    End Sub

    Private Sub btnNS_Click(sender As Object, e As EventArgs) Handles btnNS.Click
        bukubesar.Hide()
        'jurnalumum.Hide()
    End Sub
End Class